Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.Levels.Script.Commands
Imports SM64Lib.SegmentedBanking

Namespace Global.SM64Lib.Levels.Script

    Public Class Levelscript
        Inherits LevelscriptCommandCollection

        Public Overloads Sub Close()
            For i As Integer = 0 To Me.Count - 1
                Me(i).Close()
            Next
            Clear()
        End Sub

        Public Sub New()
        End Sub

        Public Sub Read(rommgr As RomManager, scriptStartInBank As Integer, Optional EndAtCommands As LevelscriptCommandTypes = LevelscriptCommandTypes.EndOfLevel, Optional segDic As Dictionary(Of Byte, SegmentedBank) = Nothing, Optional storeToRommgr As Boolean = True)
            Dim s As Stream = Nothing
            Dim br As BinaryReader = Nothing
            Dim fs As FileStream = Nothing
            Dim brfs As BinaryReader = Nothing
            Dim tb As New List(Of Byte)
            Dim cb As LevelscriptCommandTypes = Nothing
            Dim enableDo As Boolean = True
            Dim curSegBank As SegmentedBank = Nothing
            Dim dicBankBinaryReaders As New Dictionary(Of Byte, BinaryReader)
            Dim brStack As New Stack(Of BinaryReader)
            Dim sStack As New Stack(Of Stream)
            Dim jumpStack As New Stack(Of Integer)
            Dim segStack As New Stack(Of SegmentedBank)

            Close()

            Read_GetStream(curSegBank, s, br, fs, brfs, rommgr, scriptStartInBank, dicBankBinaryReaders, segDic)

            Do While enableDo
                Try
                    cb = br.ReadByte

                    Dim lenth As Byte = 0
                    lenth = br.ReadByte
                    If lenth = 0 Then lenth = 4

                    tb.Add(cb)
                    tb.Add(lenth)
                    For i As Integer = 3 To lenth
                        tb.Add(br.ReadByte)
                    Next

                    Dim curLvlCmd As New LevelscriptCommand(tb.ToArray)
                    Dim bankOffset As Integer = br.BaseStream.Position - lenth
                    curLvlCmd.RomAddress = curSegBank?.RomStart + bankOffset
                    curLvlCmd.BankAddress = curSegBank?.BankAddress + bankOffset
                    Add(curLvlCmd)
                    tb.Clear()

                    Select Case curLvlCmd.CommandType
                        Case LevelscriptCommandTypes.LoadRomToRam, LevelscriptCommandTypes.x1A, LevelscriptCommandTypes.x18, LevelscriptCommandTypes.x00, LevelscriptCommandTypes.x01
                            Dim bank As New SegmentedBank With {
                                .BankID = clLoadRomToRam.GetSegmentedID(curLvlCmd),
                                .RomStart = clLoadRomToRam.GetRomStart(curLvlCmd),
                                .RomEnd = clLoadRomToRam.GetRomEnd(curLvlCmd)
                            }

                            If curLvlCmd.CommandType = LevelscriptCommandTypes.x1A Then bank.MakeAsMIO0()
                            If storeToRommgr Then rommgr?.SetSegBank(bank)

                            If segDic IsNot Nothing Then
                                If segDic.ContainsKey(bank.BankID) Then
                                    segDic(bank.BankID) = bank
                                Else
                                    segDic.Add(bank.BankID, bank)
                                End If
                            End If

                            If {LevelscriptCommandTypes.x00, LevelscriptCommandTypes.x01}.Contains(curLvlCmd.CommandType) Then
                                Dim SegAddr As Integer = clLoadRomToRam.GetSegmentedAddressToJump(curLvlCmd)
                                JumpTo(jumpStack, sStack, brStack, segStack, curSegBank, s, br, fs, brfs, rommgr, SegAddr, dicBankBinaryReaders, segDic)
                            End If

                        Case LevelscriptCommandTypes.JumpToSegAddr
                            Dim SegAddr As Integer = clJumpToSegAddr.GetSegJumpAddr(curLvlCmd)

                            If {&H19, &HE}.Contains(SegAddr >> 24) Then
                                JumpTo(jumpStack, sStack, brStack, segStack, curSegBank, s, br, fs, brfs, rommgr, SegAddr, dicBankBinaryReaders, segDic)
                            End If

                        Case LevelscriptCommandTypes.JumpBack, &HA 'Jump back
                            curSegBank = segStack.Pop
                            s = sStack.Pop
                            br = brStack.Pop
                            s.Position = jumpStack.Pop

                    End Select

                    If curLvlCmd.CommandType = LevelscriptCommandTypes.EndOfLevel OrElse curLvlCmd.CommandType = EndAtCommands Then
                        enableDo = False
                    End If

                Catch ex As Exception
                    enableDo = False
                End Try
            Loop

            'If s Is fs Then s?.Close()
            fs?.Close()
        End Sub

        Private Sub JumpTo(jumpStack As Stack(Of Integer), sStack As Stack(Of Stream), brStack As Stack(Of BinaryReader), segStack As Stack(Of SegmentedBank), ByRef curSegBank As SegmentedBank, ByRef s As Stream, ByRef br As BinaryReader, ByRef fs As FileStream, ByRef brfs As BinaryReader, rommgr As RomManager, scriptStartInBank As Integer, dicBankBinaryReaders As Dictionary(Of Byte, BinaryReader), segDic As Dictionary(Of Byte, SegmentedBank))
            jumpStack.Push(s.Position)
            sStack.Push(s)
            brStack.Push(br)
            segStack.Push(curSegBank)
            Read_GetStream(curSegBank, s, br, fs, brfs, rommgr, scriptStartInBank, dicBankBinaryReaders, segDic)
        End Sub

        Private Sub Read_GetStream(ByRef curSegBank As SegmentedBank, ByRef s As Stream, ByRef br As BinaryReader, ByRef fs As FileStream, ByRef brfs As BinaryReader, rommgr As RomManager, scriptStartInBank As Integer, dicBankBinaryReaders As Dictionary(Of Byte, BinaryReader), segDic As Dictionary(Of Byte, SegmentedBank))
            Dim bankID As Byte = scriptStartInBank >> 24
            curSegBank = rommgr.GetSegBank(bankID)

            If curSegBank Is Nothing AndAlso segDic?.ContainsKey(bankID) Then
                curSegBank = segDic(bankID)
            End If

            If curSegBank?.Data IsNot Nothing Then
                s = curSegBank.Data

                If dicBankBinaryReaders.ContainsKey(curSegBank.BankID) Then
                    br = dicBankBinaryReaders(curSegBank.BankID)
                Else
                    br = New BinaryReader(curSegBank.Data)
                    dicBankBinaryReaders.Add(curSegBank.BankID, br)
                End If

            Else
                If fs Is Nothing Then fs = New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
                If brfs Is Nothing Then brfs = New BinaryReader(fs)
                s = fs
                br = brfs
            End If

            If curSegBank IsNot Nothing Then
                s.Position = If(s Is fs,
                    curSegBank.SegToRomAddr(scriptStartInBank),
                    curSegBank.BankOffsetFromSegAddr(scriptStartInBank)
                    )
            End If
        End Sub

        Public Sub Write(s As Stream, LevelscriptStart As Integer)
            Write(New BinaryStreamData(s), LevelscriptStart)
        End Sub

        Public Sub Write(data As BinaryData, LevelscriptStart As Integer)
            Dim JumpList As New List(Of Integer)

            'Write new Levelscript
            data.Position = LevelscriptStart
            For Each c As LevelscriptCommand In Me
                For Each b As Byte In c.ToArray
                    data.Write(b)
                Next
            Next
        End Sub

    End Class

End Namespace
