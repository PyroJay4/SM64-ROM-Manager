Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports System.Windows.Forms
Imports SM64Lib.Geolayout.Script
Imports SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Levels.ScrolTex
Imports SM64Lib.SegmentedBanking
Imports SM64Lib.ObjectBanks.Data

Namespace Global.SM64Lib.Levels

    Public Class Level

        'S h a r e d   M e m b e r s

        Friend Shared ReadOnly LevelscriptStart() As Byte = {&H80, &H8, &H0, &H0, &H19, &H0, &H0, &H1C, &H8, &H0, &H0, &HA, &H0, &HA0, &H0, &H78, &H0, &HA0, &H0, &H78, &H4, &H0, &H0, &H0, &HC, &H0, &H0, &H0}

        'F i e l d s

        Private _Bank0x19 As SegmentedBank = Nothing

        'A u t o   P r o p e r t i e s

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

        Public Sub New()
        End Sub

        'M e t h o d s

        Public Sub CreateNewLevelscript()
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

            If Bank0x19 IsNot Nothing Then
                rommgr.SetSegBank(Bank0x19)
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
            'Remove old commands
            If OldEntryIndex <> -1 Then
                For Each obdCmd As ObjectBankDataCommand In ObjectBankData(BankIndex)(OldEntryIndex).Commands
                    For Each cmd In Levelscript.Where(Function(n) CompareTwoByteArrays(n.ToArray, obdCmd.Command)).ToArray
                        cmd.Close()
                        Levelscript.Remove(cmd)
                    Next
                Next
            End If

            If NewEntryIndex <> -1 Then
                For Each obdCmd As ObjectBankDataCommand In ObjectBankData(BankIndex)(NewEntryIndex).Commands
                    Dim startIndex As Integer = Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1D)
                    If Not (obdCmd.Command.Last = &H1A OrElse obdCmd.Command.Last = &H17) Then
                        startIndex += 1
                    End If

                    Dim cmd As New LevelscriptCommand(obdCmd.Command)
                    Levelscript.Insert(startIndex, cmd)
                    startIndex += 1
                Next
            End If
        End Sub

        Private Function GetObjectBank(BankIndex As Integer) As Integer
            Dim Found As New List(Of Boolean)

            For obdDataIndex As Integer = 0 To ObjectBankData(BankIndex).Count - 1
                Dim obdData As ObjectBankData = ObjectBankData(BankIndex)(obdDataIndex)

                For Each obdCmd As ObjectBankDataCommand In obdData.Commands
                    Found.Add(Levelscript.Where(Function(n) CompareTwoByteArrays(n.ToArray, obdCmd.Command)).Any)
                Next

                If Not Found.Contains(False) Then
                    Return obdDataIndex
                End If

                Found.Clear()
            Next

            Return -1
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
