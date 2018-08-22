Imports System.IO
Imports System.Windows.Forms
Imports SM64Lib.Levels.Script.Commands

Namespace Global.SM64Lib.Levels.Script

    Public Class Levelscript
        Inherits LevelscriptCommandCollection

        Public Overloads Sub Close()
            For i As Integer = 0 To Me.Count - 1
                Me(i).Close()
            Next
            Me.Clear()
        End Sub

        Public Sub New()
            Me.Clear()
        End Sub

        Public Sub Read(rommgr As RomManager, scriptStartInBank As Integer, Optional EndAtCommand As LevelscriptCommandTypes = LevelscriptCommandTypes.EndOfLevel)
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

            Me.Close()

            Read_GetStream(curSegBank, s, br, fs, brfs, rommgr, scriptStartInBank, dicBankBinaryReaders)

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
                    Me.Add(curLvlCmd)
                    tb.Clear()

                    Select Case curLvlCmd.CommandType
                        Case EndAtCommand, LevelscriptCommandTypes.EndOfLevel
                            enableDo = False

                        Case LevelscriptCommandTypes.LoadRomToRam
                            rommgr.SetSegBank(clLoadRomToRam.GetSegmentedID(curLvlCmd),
                                              clLoadRomToRam.GetRomStart(curLvlCmd),
                                              clLoadRomToRam.GetRomEnd(curLvlCmd))

                        Case LevelscriptCommandTypes.JumpToSegAddr
                            Dim SegAddr As Integer = clJumpToSegAddr.GetSegJumpAddr(curLvlCmd)

                            If ({&H19, &HE}).Contains(SegAddr >> 24) Then
                                jumpStack.Push(s.Position)
                                sStack.Push(s)
                                brStack.Push(br)
                                segStack.Push(curSegBank)
                                Read_GetStream(curSegBank, s, br, fs, brfs, rommgr, SegAddr, dicBankBinaryReaders)
                            End If

                        Case LevelscriptCommandTypes.JumpBack, &HA 'Jump back
                            curSegBank = segStack.Pop
                            s = sStack.Pop
                            br = brStack.Pop
                            s.Position = jumpStack.Pop

                    End Select
                Catch ex As Exception
                    enableDo = False
                End Try
            Loop

            If s Is fs Then s?.Close()
        End Sub

        Private Sub Read_GetStream(ByRef curSegBank As SegmentedBank, ByRef s As Stream, ByRef br As BinaryReader, ByRef fs As FileStream, ByRef brfs As BinaryReader, rommgr As RomManager, scriptStartInBank As Integer, dicBankBinaryReaders As Dictionary(Of Byte, BinaryReader))
            curSegBank = rommgr.GetSegBank((scriptStartInBank And &HFF000000) >> 24)
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
                    curSegBank.BankOffsetFromSegAddr(scriptStartInBank))
            End If
        End Sub

        Public Sub Write(s As Stream, LevelscriptStart As Integer)
            Dim bw As New BinaryWriter(s)

            Dim JumpList As New List(Of Integer)

            'Write new Levelscript
            s.Position = LevelscriptStart
            For Each c As LevelscriptCommand In Me
                For Each b As Byte In c.ToArray
                    bw.Write(b)
                Next
            Next
        End Sub
    End Class

End Namespace
