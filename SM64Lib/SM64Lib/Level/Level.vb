Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports System.Windows.Forms
Imports SM64Lib.Geolayout.Script
Imports SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Levels.ScrolTex

Namespace Global.SM64Lib.Levels

    Public Class Level

        'S h a r e d   M e m b e r s

        Friend Shared ReadOnly LevelscriptStart() As Byte = {&H80, &H8, &H0, &H0, &H19, &H0, &H0, &H1C, &H8, &H0, &H0, &HA, &H0, &HA0, &H0, &H78, &H0, &HA0, &H0, &H78, &H4, &H0, &H0, &H0, &HC, &H0, &H0, &H0}

        'F i e l d s

        Private _Bank0x19 As SegmentedBank = Nothing

        'A u t o   P r o p e r t i e s

        Public ReadOnly Property LevelType As LevelType = LevelType.SM64RomManager
        Public Property Levelscript As New Levelscript
        Public ReadOnly Property Areas As New List(Of LevelArea)
        Public Property ObjectBank0x0C As ObjectBank0x0C = 0
        Public Property ObjectBank0x0D As ObjectBank0x0D = 0
        Public Property ObjectBank0x0E As ObjectBank0x0E = 0
        Public Property DefaultTerrainType As Integer = 0
        Public Property LevelID As UShort = 0
        Public Property SegmentedID As Byte = &H19
        Public ReadOnly Property Background As New LevelBG
        Public Property ActSelector As Boolean = False
        Public Property HardcodedCameraSettings As Boolean = False
        Public Property Closed As Boolean = False
        Public Property LastRomOffset As Integer = -1
        Public Property LevelFast3DBuffer As MemoryStream = Nothing
        Public ReadOnly Property SM64EditorMode As Boolean = False
        Public Property NeedToSaveLevelscript As Boolean = False
        Public Property NeedToSaveBanks0E As Boolean = False
        Public Property OneBank0xESystemEnabled As Boolean = True
        Public Property EnableGlobalObjectBank As Boolean = False

        'O t h e r   P r o p e r t i e s

        Public Property Bank0x19 As SegmentedBank
            Get
                Return _Bank0x19
            End Get
            Friend Set(value As SegmentedBank)
                _Bank0x19 = value
            End Set
        End Property

        Public ReadOnly Property ObjectsCount As Integer
            Get
                Dim tcount As Integer = 0
                For Each a In Areas
                    tcount += a.Objects.Count
                Next
                Return tcount
            End Get
        End Property

        Public ReadOnly Property WarpsCount As Integer
            Get
                Dim tcount As Integer = 0
                For Each a In Areas
                    tcount += a.Warps.Count
                Next
                Return tcount
            End Get
        End Property

        'C o n s t r u c t o r s

        Public Sub New(LevelID As UShort, LevelIndex As Integer)
            Me.LevelID = LevelID
            CreateNewLevelscript()
            HardcodedCameraSettings = False
            ActSelector = ActSelectorDefaultValues(LevelIndex)
        End Sub

        Public Sub New(type As LevelType)
            LevelType = type
        End Sub

        'M e t h o d s

        Public Sub CreateNewLevelscript()
            _LevelType = LevelType.SM64RomManager

            With Levelscript
                .Close()
                .Clear()

                'Start Loading Commands
                .Add(New LevelscriptCommand({&H1B, &H4, &H0, &H0}))

                'Loading Commands
                .Add(New LevelscriptCommand({&H17, &HC, &H1, &HE, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}))

                'Start Model Commands
                .Add(New LevelscriptCommand({&H1D, &H4, &H0, &H0}))

                'Load Marios Model
                .Add(New LevelscriptCommand({&H25, &HC, &H0, &H1, &H0, &H0, &H0, &H1, &H13, &H0, &H2E, &HC0}))

                'Start End-Of-Level Commands
                .Add(New LevelscriptCommand({&H1E, &H4, &H0, &H0}))

                'End-Of-Level Commands
                .Add(New LevelscriptCommand({&H2B, &HC, &H1, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H11, &H8, &H0, &H0, &H80, &H24, &HBC, &HD8}))
                .Add(New LevelscriptCommand({&H12, &H8, &H0, &H1, &H80, &H24, &HBC, &HD8}))
                .Add(New LevelscriptCommand({&H1C, &H4, &H0, &H0}))
                .Add(New LevelscriptCommand({&H4, &H4, &H0, &H1}))
                .Add(New LevelscriptCommand({&H2, &H4, &H0, &H0}))

                'Add the general object bank
                ChangeObjectBank(0, 0, -1)
            End With

            For Each c As LevelscriptCommand In Levelscript
                If c.CommandType <> LevelscriptCommandTypes.LoadRomToRam Then Continue For
                If clLoadRomToRam.GetSegmentedID(c) <> &HE Then Continue For
            Next
        End Sub

        Public Sub SetSegmentedBanks(rommgr As RomManager)
            For Each cmd As LevelscriptCommand In Levelscript
                Select Case cmd.CommandType
                    Case LevelscriptCommandTypes.LoadRomToRam, LevelscriptCommandTypes.x1A, LevelscriptCommandTypes.x18
                        cmd.Position = 0
                        Dim bankID As Byte = clLoadRomToRam.GetSegmentedID(cmd)
                        Dim startAddr As Integer = clLoadRomToRam.GetRomStart(cmd)
                        Dim endAddr As Integer = clLoadRomToRam.GetRomEnd(cmd)
                        Dim seg As SegmentedBank = rommgr.SetSegBank(bankID, startAddr, endAddr)
                        If cmd.CommandType = LevelscriptCommandTypes.x1A Then seg.MakeAsMIO0()
                End Select
            Next

            If bank0x19 IsNot Nothing Then
                rommgr.SetSegBank(bank0x19)
            End If
        End Sub

        Public Function GetDefaultPositionCmd() As LevelscriptCommand
            Return Levelscript.FirstOrDefault(Function(n) n.CommandType = LevelscriptCommandTypes.DefaultPosition)
        End Function

        Public Sub ChangeObjectBank(BankEntries As ObjectBank0x0C)
            ChangeObjectBank(1, BankEntries - 1, ObjectBank0x0C - 1)
            ObjectBank0x0C = BankEntries
        End Sub

        Public Function GetObjectBank0x0C() As ObjectBank0x0C
            Return GetObjectBank(1) + 1
        End Function

        Public Sub ChangeObjectBank(BankEntries As ObjectBank0x0D)
            ChangeObjectBank(2, BankEntries - 1, ObjectBank0x0D - 1)
            ObjectBank0x0D = BankEntries
        End Sub

        Public Function GetObjectBank0x0D() As ObjectBank0x0D
            Return GetObjectBank(2) + 1
        End Function

        Public Sub ChangeObjectBank(BankEntries As ObjectBank0x0E)
            ChangeObjectBank(3, BankEntries - 1, ObjectBank0x0E - 1)
            ObjectBank0x0E = BankEntries
        End Sub

        Public Function GetObjectBank0x0E() As ObjectBank0x0E
            Return GetObjectBank(3) + 1
        End Function

        Private Sub ChangeObjectBank(BankIndex As Integer, NewEntryIndex As Integer, OldEntryIndex As Integer)
            Dim oldiniindex As String = GetObjectBankSectionNameOfIndex(BankIndex, OldEntryIndex)
            Dim newiniindex As String = GetObjectBankSectionNameOfIndex(BankIndex, NewEntryIndex)

            'Remove old commands
            If OldEntryIndex <> -1 Then
                For Each cmditem As String In {"cmd22", "cmd06", "cmd1A", "cmd17"}
                    Dim tKeyValue As String = ObjectBankData(BankIndex)(oldiniindex)(cmditem)
                    If tKeyValue = String.Empty Then Continue For

                    For Each s As String In tKeyValue.Split("|")
                        Dim stringBytes() As String = s.Split(" ")

                        Dim bytesList As New List(Of Byte)
                        For Each sb As String In stringBytes
                            If Not sb = String.Empty Then bytesList.Add(CByte("&H" & sb))
                        Next

                        For Each cmd In Levelscript.Where(Function(n) CompareTwoByteArrays(n.ToArray, bytesList.ToArray)).ToArray
                            cmd.Close()
                            Levelscript.Remove(cmd)
                        Next
                    Next
                Next
            End If

            'Add new commands
            If NewEntryIndex <> -1 Then
                For Each cmditem As String In {"cmd22", "cmd06", "cmd1A", "cmd17"}
                    Dim tKeyValue As String = ObjectBankData(BankIndex)(newiniindex)(cmditem)
                    If tKeyValue = String.Empty Then Continue For

                    Dim startIndex As Integer = Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1D)
                    If Not (cmditem.EndsWith("1A") OrElse cmditem.EndsWith("17")) Then
                        startIndex += 1
                    End If

                    For Each s As String In tKeyValue.Split("|")
                        Dim stringBytes() As String = s.Split(" ")

                        Dim bytesList As New List(Of Byte)
                        For Each sb As String In stringBytes
                            If Not sb = String.Empty Then bytesList.Add(CByte("&H" & sb))
                        Next

                        Dim cmd As New LevelscriptCommand(bytesList.ToArray)
                        Levelscript.Insert(startIndex, cmd)
                        startIndex += 1
                    Next
                Next
            End If
        End Sub

        Private Function GetObjectBank(BankIndex As Integer) As Integer
            Dim Found As New List(Of Boolean)

            For Each s In ObjectBankData(BankIndex).Sections
                For Each cmdkey In {"cmd22", "cmd06", "cmd1A", "cmd17"}
                    Dim tKeyValue As String = s.Keys(cmdkey)
                    If tKeyValue = String.Empty Then Continue For

                    For Each k As String In tKeyValue.Split("|")
                        Dim stringBytes() As String = k.Split(" ")

                        Dim bytesList As New List(Of Byte)
                        For Each sb As String In stringBytes
                            If Not sb = String.Empty Then bytesList.Add(CByte("&H" & sb))
                        Next

                        Found.Add(Levelscript.Where(Function(n) CompareTwoByteArrays(n.ToArray, bytesList.ToArray)).Count > 0)
                    Next
                Next

                If Not Found.Contains(False) Then Return GetObjectBankSectionIndexOfName(BankIndex, s.SectionName)
                Found.Clear()
            Next

            Return -1
        End Function

        Private Function GetObjectBankSectionNameOfIndex(Bank As Integer, Index As Integer) As String
            If Index < 0 Then Return ""
            Dim NameLists As New List(Of String)
            For Each s In ObjectBankData(Bank).Sections
                NameLists.Add(s.SectionName)
            Next
            Return NameLists(Index)
        End Function

        Private Function GetObjectBankSectionIndexOfName(Bank As Integer, Name As String) As Integer
            Dim cIndex As Integer = 0
            For Each s In ObjectBankData(Bank).Sections
                If s.SectionName = Name Then Return cIndex
                cIndex += 1
            Next
            Return 0
        End Function

        Public Sub Close()
            For Each c In Levelscript
                c.Close()
            Next
            Levelscript.Clear()
            For Each a In Areas
                a.Close()
            Next
            Areas.Clear()
            Closed = True
        End Sub

        Public Overrides Function ToString() As String
            Dim output As String = ""
            For Each cmd In Levelscript
                Dim tbytelist As String = ""
                For Each b As Byte In cmd.ToArray
                    If tbytelist IsNot String.Empty Then tbytelist &= " "
                    tbytelist &= Hex(b)
                Next
                If output IsNot String.Empty Then output &= vbNewLine
                output &= tbytelist
            Next
            Return output
        End Function

    End Class

End Namespace
