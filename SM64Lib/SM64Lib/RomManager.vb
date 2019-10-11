Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Windows.Forms
Imports IniParser
Imports IniParser.Model
Imports SM64Lib.Geolayout
Imports SM64Lib.Music
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SM64Lib.Levels.Script
Imports SM64Lib.ObjectBanks
Imports SM64Lib.Data
Imports SM64Lib.RomStruc
Imports System.ComponentModel

Namespace Global.SM64Lib

    Public Class RomManager

        'E v e n t s

        Public Event BeforeRomSave(sender As RomManager, e As CancelEventArgs)
        Public Event AfterRomSave(sender As RomManager, e As EventArgs)
        Public Event WritingNewProgramVersion(sender As RomManager, e As RomVersionEventArgs)

        'F i e l d s

        Private ReadOnly segBankList As New Dictionary(Of Byte, SegmentedBank)
        Private ReadOnly areaSegBankList As New Dictionary(Of Byte, Dictionary(Of Byte, SegmentedBank))
        Private dicUpdatePatches As New Dictionary(Of String, RomVersion)
        Private myProgramVersion As New RomVersion
        Private ReadOnly levelIDsToReset As New List(Of UShort)
        Private ReadOnly myTextGroups As New List(Of Text.TextGroup)
        Private myGameName As String = Nothing

        'P r o p e r t i e s

        Public ReadOnly Property LevelInfoData As New Levels.LevelInfoDataTabelList
        Public ReadOnly Property Levels As New Levels.LevelList
        Public Property RomFile As String = ""
        Public ReadOnly Property IsSM64EditorMode As Boolean = False
        Public ReadOnly Property TextInfoProfile As Text.Profiles.TextProfileInfo
        Public ReadOnly Property MusicList As New MusicList
        Public Property GlobalObjectBank As New CustomObjectBank
        Public ReadOnly Property LevelManager As ILevelManager

        ''' <summary>
        ''' Gets or sets the lastly used program version for this ROM.
        ''' </summary>
        ''' <returns></returns>
        Public Property ProgramVersion As RomVersion
            Get
                Static loadedVersion As Boolean = False
                Dim ver As RomVersion

                If Not loadedVersion Then
                    ver = LoadVersion()
                    loadedVersion = True
                Else
                    ver = myProgramVersion
                End If

                Return ver
            End Get
            Set(value As RomVersion)
                myProgramVersion = value
            End Set
        End Property

        ''' <summary>
        ''' Gets if the ROM has unsaved chnages and need to be saved.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return MusicList.NeedToSave OrElse
                    myTextGroups.Where(Function(n) n IsNot Nothing AndAlso n.NeedToSave).Count > 0 OrElse
                    levelIDsToReset.Any OrElse
                    Levels.NeedToSave OrElse
                    GlobalObjectBank.NeedToSave
            End Get
        End Property

        Public ReadOnly Property TextGroups As Text.TextGroup()
            Get
                Return myTextGroups.ToArray
            End Get
        End Property

        ''' <summary>
        ''' Gets if the current ROM has an user created global object bank.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property HasGlobalObjectBank As Boolean
            Get
                Return GlobalObjectBank IsNot Nothing
            End Get
        End Property

        'C o n s t r u c t o r s

        ''' <summary>
        ''' Creates a new instance with input ROM.
        ''' </summary>
        ''' <param name="FileName">The ROM that will be opened.</param>
        Public Sub New(FileName As String)
            Me.New(FileName, New Levels.LevelManager)
        End Sub

        ''' <summary>
        ''' Creates a new instance with input ROM.
        ''' </summary>
        ''' <param name="FileName">The ROM that will be opened.</param>
        Public Sub New(FileName As String, levelManager As ILevelManager)
            RomFile = FileName
            Me.LevelManager = levelManager

            Dim levelTableFile As String = MyFilePaths("Level Tabel.json")
            If File.Exists(levelTableFile) Then
                LevelInfoData.ReadFromFile(levelTableFile)
            End If

            SetSegBank(&H0, 0, New FileInfo(FileName).Length) 'Bank 0 means the whole ROM.
            SetSegBank(&H15, &H2ABCA0, &H2AC6B0)
            'SetSegBank(&H2, &H108A40, &H114750)
            SetSegBank(&H2, &H803156, 0) 'Text Table??

            LoadDictionaryUpdatePatches()
        End Sub

        'R a i s e   E v e n t s

        Private Function RaiseBeforeRomSave() As Boolean
            Dim e As New CancelEventArgs
            RaiseEvent BeforeRomSave(Me, e)
            Return e.Cancel
        End Function

        Private Sub RaiseAfterRomSave()
            RaiseEvent AfterRomSave(Me, New EventArgs)
        End Sub

        'F e a t u r e s

        ''' <summary>
        ''' Gets if Update Patches are avaiable for this ROM.
        ''' </summary>
        ''' <returns></returns>
        Public Function AreRomUpdatesAvaiable() As Boolean
            Return dicUpdatePatches.Where(Function(n) n.Value > ProgramVersion).Count > 0
        End Function

        Private Sub LoadDictionaryUpdatePatches()
            Dim udatePatchsFile As String = MyFilePaths("Update-Patches.json")
            Dim jsFile As String
            Dim obj As JObject

            If File.Exists(udatePatchsFile) Then
                jsFile = File.ReadAllText(udatePatchsFile)
                obj = JObject.Parse(jsFile)

                dicUpdatePatches = obj.ToObject(GetType(Dictionary(Of String, RomVersion)))
            End If
        End Sub

        ''' <summary>
        ''' Gets or sets the Game Name which is used for the EEP-ROM (Save file).
        ''' </summary>
        ''' <returns></returns>
        Public Property GameName As String
            Get
                If myGameName Is Nothing Then
                    Dim fs As New BinaryRom(Me, FileAccess.Read)
                    fs.Position = &H20
                    myGameName = Encoding.ASCII.GetString(fs.Read(&H14)).Trim
                    fs.Close()
                End If
                Return myGameName
            End Get
            Set(value As String)
                Dim fs As New BinaryRom(Me, FileAccess.Write)
                fs.Position = &H20
                For Each b As Byte In Encoding.ASCII.GetBytes(value)
                    fs.Write(b)
                Next
                Do While fs.Position < &H34
                    fs.WriteByte(&H20)
                Loop
                fs.Close()
                myGameName = value
            End Set
        End Property

        ''' <summary>
        ''' Gets a new instance of BinaryRom, a BinaryData object.
        ''' </summary>
        ''' <param name="access"></param>
        ''' <returns></returns>
        Public Function GetBinaryRom(access As FileAccess) As BinaryRom
            Return New BinaryRom(Me, access)
        End Function

        ''' <summary>
        ''' Saves the ROM.
        ''' </summary>
        ''' <param name="IgnoreNeedToSave">If True, everything will be saved even if there are no changes.</param>
        ''' <param name="DontPatchUpdates">If True, Update Patches will be ignored.</param>
        Public Sub SaveRom(Optional IgnoreNeedToSave As Boolean = False, Optional DontPatchUpdates As Boolean = False)
            If Not RaiseBeforeRomSave() Then
                Dim needUpdateChecksum As Boolean = MusicList.NeedToSaveMusicHackSettings

                If Not DontPatchUpdates Then
                    'Patch update-patches
                    For Each kvp As KeyValuePair(Of String, RomVersion) In dicUpdatePatches.Where(Function(n) n.Value > ProgramVersion).OrderBy(Function(n) n.Key)
                        PatchClass.ApplyPPF(RomFile, Path.Combine(MyFilePaths("Update Patches Folder"), kvp.Value.Filename))
                        needUpdateChecksum = True
                    Next
                End If

                'Write Version
                Dim romVerEventArgs As New RomVersionEventArgs(ProgramVersion)
                RaiseEvent WritingNewProgramVersion(Me, romVerEventArgs)
                WriteVersion(romVerEventArgs.RomVersion)

                'Texts
                SaveAllTextGroups(needUpdateChecksum,)

                'Music
                Dim lastpos As Integer
                MusicList.Write(RomFile, lastpos)
                HexRoundUp2(lastpos)

                'Global Object Bank
                SaveGlobalObjectBank(lastpos)
                HexRoundUp2(lastpos)

                'Levels
                SaveLevels(lastpos) 'If IgnoreNeedToSave OrElse Levels.NeedToSave Then

                If needUpdateChecksum Then _
                    PatchClass.UpdateChecksum(RomFile)

                RaiseAfterRomSave()
            End If
        End Sub

        Private Sub WriteVersion(newVersion As RomVersion)
            myProgramVersion = newVersion

            Dim fs As New BinaryRom(Me, FileAccess.ReadWrite)
            fs.Position = &H1201FF8

            fs.Write((newVersion.DevelopmentStage << 24) Or newVersion.DevelopmentBuild)
            fs.WriteByte(newVersion.Version.Major)
            fs.WriteByte(newVersion.Version.Minor)
            fs.WriteByte(newVersion.Version.Build)
            fs.WriteByte(newVersion.Version.Revision)

            fs.Close()
        End Sub

        Private Function LoadVersion() As RomVersion
            Dim fs As New BinaryRom(Me, FileAccess.Read)
            fs.Position = &H1201FF8

            Dim devInfo As Integer = fs.ReadInt32
            Dim major As Byte = fs.ReadByte
            Dim minor As Byte = fs.ReadByte
            Dim build As Byte = fs.ReadByte
            Dim revision As Byte = fs.ReadByte

            fs.Close()

            myProgramVersion.Version = New Version(major, minor, build, revision)

            If devInfo <> &H1010101 Then
                myProgramVersion.DevelopmentStage = devInfo >> 24
                myProgramVersion.DevelopmentBuild = devInfo And &HFFFFFF
            Else
                myProgramVersion.DevelopmentStage = 3
                myProgramVersion.DevelopmentBuild = 0
            End If

            Return myProgramVersion
        End Function

        Public Sub LoadTextProfileIfNotLoaded()
            If TextInfoProfile Is Nothing Then
                LoadTextProfile()
            End If
        End Sub

        Public Sub LoadTextProfile()
            _TextInfoProfile = JObject.Parse(File.ReadAllText(MyFilePaths("Text Profiles.json"))).ToObject(Of Text.Profiles.TextProfileInfo)
        End Sub

        Public Sub SaveTextProfile()
            File.WriteAllText(MyFilePaths("Text Profiles.json"), JObject.FromObject(TextInfoProfile).ToString)
        End Sub

        Private Function GetTextProfile(name As String) As Text.Profiles.TextGroupInfo
            LoadTextProfileIfNotLoaded()
            Return TextInfoProfile.GetGroup(name)
        End Function

        ''' <summary>
        ''' Removes all loaded text groups, so they can be re-loaded.
        ''' </summary>
        Public Sub ClearTextGroups()
            myTextGroups.Clear()
        End Sub

        ''' <summary>
        ''' Loads the Text Tables.
        ''' </summary>
        Public Function LoadTextGroup(name As String, Optional CheckIfAlreadyLoaded As Boolean = True) As Text.TextGroup
            Return LoadTextGroup(myTextGroups.FirstOrDefault(Function(n) n.TextGroupInfo.Name = name), name, CheckIfAlreadyLoaded)
        End Function

        Private Function LoadTextGroup(table As Text.TextGroup, name As String, Optional CheckIfAlreadyLoaded As Boolean = True) As Text.TextGroup
            LoadTextProfileIfNotLoaded()

            If table Is Nothing OrElse Not CheckIfAlreadyLoaded Then
                Dim data As New BinaryRom(Me, FileAccess.Read)
                Dim prof As Text.Profiles.TextGroupInfo = GetTextProfile(name)

                If table IsNot Nothing Then
                    myTextGroups.Remove(table)
                End If

                If TypeOf prof Is Text.Profiles.TextTableGroupInfo Then
                    table = New Text.TextTableGroup(prof)
                ElseIf TypeOf prof Is Text.Profiles.TextArrayGroupInfo Then
                    table = New Text.TextArrayGroup(prof)
                End If

                myTextGroups.Add(table)
                table.Read(data)

                data.Close()
            End If

            Return table
        End Function

        ''' <summary>
        ''' Gets the all known text sections
        ''' </summary>
        ''' <returns></returns>
        Public Function GetTextGroupInfos() As Text.Profiles.TextGroupInfo()
            LoadTextProfileIfNotLoaded()
            Return TextInfoProfile.AllGroups.ToArray
        End Function

        ''' <summary>
        ''' Saves the Text Tables.
        ''' </summary>
        ''' <param name="table">The text table to save.</param>
        Public Sub SaveTextGroup(table As Text.TextGroup)
            SaveTextGroup(Nothing, table)
        End Sub

        ''' <summary>
        ''' Saves the Text Tables.
        ''' </summary>
        ''' <param name="needUpdateChecksum">Outputs if the checksumarea was changed and need to be updated.</param>
        ''' <param name="table">The text table to save.</param>
        Public Sub SaveTextGroup(ByRef needUpdateChecksum As Boolean, table As Text.TextGroup)
            Dim data As New BinaryRom(Me, FileAccess.ReadWrite)
            Dim prof As Text.Profiles.TextGroupInfo = table.TextGroupInfo

            table.Save(data)
            table.NeedToSave = False

            If TypeOf prof Is Text.Profiles.TextTableGroupInfo Then
                needUpdateChecksum = needUpdateChecksum Or (CType(prof, Text.Profiles.TextTableGroupInfo).Segmented.BankAddress = &H80245000UI)
            ElseIf TypeOf prof Is Text.Profiles.TextArrayGroupInfo Then
                For Each t As Text.Profiles.TextArrayItemInfo In CType(prof, Text.Profiles.TextArrayGroupInfo).Texts
                    'If t.RomAddress > &H20 AndAlso t.RomAddress < &H55555 Then
                    '    needUpdateChecksum = True
                    'End If
                Next
            End If

            data.Close()
        End Sub

        ''' <summary>
        ''' Saves all Text Tables.
        ''' </summary>
        ''' <param name="IgnoreNeedToSave">If True, everything will be saved even if there are no changes.</param>
        Public Sub SaveAllTextGroups(Optional IgnoreNeedToSave As Boolean = False)
            SaveAllTextGroups(Nothing,)
        End Sub

        ''' <summary>
        ''' Saves all Text Tables.
        ''' </summary>
        ''' <param name="needUpdateChecksum">Outputs if the checksumarea was changed and need to be updated.</param>
        ''' <param name="IgnoreNeedToSave">If True, everything will be saved even if there are no changes.</param>
        Public Sub SaveAllTextGroups(ByRef needUpdateChecksum As Boolean, Optional IgnoreNeedToSave As Boolean = False)
            For Each table As Text.TextGroup In myTextGroups
                If IgnoreNeedToSave OrElse table.NeedToSave Then
                    SaveTextGroup(needUpdateChecksum, table)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Loads all Levels that are in the ROM.
        ''' </summary>
        Public Sub LoadLevels()
            Levels.Clear()

            Dim seg0x15 As SegmentedBank = GetSegBank(&H15)
            seg0x15.ReadDataIfNull(RomFile)
            Dim br As New BinaryReader(seg0x15.Data)

            For Each ldi In LevelInfoData
                seg0x15.Data.Position = seg0x15.BankOffsetFromRomAddr(ldi.Pointer + 3)
                If br.ReadByte <> &H19 Then Continue For

                Try
                    Dim seg0x19 As SegmentedBank = SetSegBank(&H19, SwapInts.SwapUInt32(br.ReadUInt32), SwapInts.SwapUInt32(br.ReadUInt32))
                    Dim offset As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                    Dim curLevel As Levels.Level

                    'If IsSM64EditorMode Then
                    '    curLevel = New Levels.Level(SM64Lib.Levels.LevelType.SM64Editor)
                    '    LevelManager.LoadLevel(curLevel, Me, ldi.ID, offset)
                    'Else
                    '    curLevel = New Levels.Level(SM64Lib.Levels.LevelType.SM64RomManager)
                    '    LevelManager.LoadLevel(curLevel, Me, ldi.ID, offset)
                    'End If
                    curLevel = New Levels.Level
                    LevelManager.LoadLevel(curLevel, Me, ldi.ID, offset)

                    curLevel.LastRomOffset = seg0x19.RomStart
                    Levels.Add(curLevel)
                Catch ex As Exception
                    'Skip the Level
                End Try
            Next
        End Sub

        ''' <summary>
        ''' Saves all Levels to the ROM.
        ''' </summary>
        ''' <param name="StartAddress">At this position the Levels will be written in ROM.</param>
        Public Sub SaveLevels(Optional StartAddress As Integer = -1)
            Dim curOff As UInteger = StartAddress

            Dim binRom As New BinaryRom(Me, FileAccess.ReadWrite)
            binRom.Position = curOff

            For Each lvl As Levels.Level In Levels
                Dim res As Levels.LevelSaveResult
                res = LevelManager.SaveLevel(lvl, Me, binRom, curOff)
                lvl.LastRomOffset = res.Bank0x19.RomStart
                HexRoundUp2(curOff)
            Next

            binRom.Close()

            ResetListedLevelPointers()
        End Sub

        Private Sub ResetListedLevelPointers()
            For Each id As UShort In levelIDsToReset.ToArray
                If Not Levels.Where(Function(n) n.LevelID = id).Any Then
                    ResetLevelPointer(id)
                End If
                levelIDsToReset.Remove(id)
            Next
        End Sub

        ''' <summary>
        ''' Loads the global object bank, if avaiable (WIP)
        ''' </summary>
        Public Sub LoadGlobalObjectBank()
            Dim fs As New BinaryRom(Me, FileAccess.Read)

            'Read Bank Addres & Length from Rom
            fs.Position = &H120FFF0
            Dim seg As New SegmentedBank(&H7)
            seg.RomStart = fs.ReadInt32
            seg.RomEnd = fs.ReadInt32

            'Make new Object Bank
            GlobalObjectBank = New CustomObjectBank

            If seg.RomStart <> &H1010101 AndAlso seg.RomStart > -1 Then
                'Set Segmented Bank
                SetSegBank(seg)

                'Load Object Bank
                GlobalObjectBank.ReadFromSeg(Me, seg)
            End If

            fs.Close()
        End Sub

        Private Sub SaveGlobalObjectBank(ByRef offset As Integer)
            Dim fs As New BinaryRom(Me, FileAccess.ReadWrite)
            Dim seg As SegmentedBank = GlobalObjectBank.WriteToSeg(&H7)

            'Set Segmented Bank
            seg.RomStart = offset
            SetSegBank(seg)

            'Write Segmented Bank
            seg.WriteData(fs.BaseStream)
            offset = fs.Position

            'Write Bank Address & Length to Rom
            fs.Position = &H120FFF0
            fs.Write(seg.RomStart)
            fs.Write(seg.RomEnd)

            fs.Close()
        End Sub

        ''' <summary>
        ''' Creates and adds a new Level with ID.
        ''' </summary>
        ''' <param name="LevelID">The ID of the Level.</param>
        Public Function AddLevel(LevelID As Byte) As Levels.Level
            Dim newLevel As New Levels.Level(LevelID, LevelInfoData.GetByLevelID(LevelID).Index) 'GetLevelIndexFromID(LevelID)
            Levels.Add(newLevel)
            Return newLevel
        End Function

        ''' <summary>
        ''' Removes a Level from the list and ROM.
        ''' </summary>
        ''' <param name="level">The level to remove.</param>
        Public Sub RemoveLevel(level As Levels.Level)
            Levels.Remove(level)
            levelIDsToReset.Add(level.LevelID)
        End Sub

        ''' <summary>
        ''' Changes the Level ID from a existing Level.
        ''' </summary>
        ''' <param name="level">The Level where to change the Level ID.</param>
        ''' <param name="newLevelID">The new Level ID.</param>
        ''' <param name="EnableActSelector">Activate/Deactivate the Act Selector fot the Level.</param>
        Public Sub ChangeLevelID(level As Levels.Level, newLevelID As UShort, Optional EnableActSelector As Boolean? = Nothing)
            levelIDsToReset.Add(level.LevelID)
            level.LevelID = newLevelID
            If EnableActSelector IsNot Nothing Then level.ActSelector = EnableActSelector
        End Sub

        ''' <summary>
        ''' Loads the Music from the ROM.
        ''' </summary>
        Public Sub LoadMusic()
            MusicList.Read(RomFile)
        End Sub

        ''' <summary>
        ''' Check, if the ROM is a valid SM64 ROM.
        ''' </summary>
        ''' <returns></returns>
        Public Function CheckROM() As Boolean
            Dim fi = New FileInfo(RomFile)
            Dim filelength As Long = fi.Length

            If fi.IsReadOnly Then
                Throw New ReadOnlyException("This ROM file is Read-Only. Remove the write protection and try again.")
            End If

            If filelength = 8 * 1024 * 1024 Then
                CreateROM()
                PrepairROM()
            End If

            Dim br As New BinaryRom(Me, FileAccess.Read)
            br.Position = &H1200000
            Dim tCheckData = br.ReadInt64
            br.Close()

            _IsSM64EditorMode = {&H800800001900001C, &H800800000E0000C4}.Contains(tCheckData)

            If IsSM64EditorMode AndAlso TypeOf LevelManager Is Levels.LevelManager Then
                _LevelManager = New Levels.SM64EditorLevelManager
            End If

            Return True
        End Function

        Private Sub PrepairROM()
            'Patch things
            Dim proc As New Process
            With proc.StartInfo
                .FileName = MyFilePaths("ApplyPPF3.exe")
                .UseShellExecute = False
                .Arguments = String.Format("a ""{0}"" ""{1}""", RomFile, MyFilePaths("SM64_ROM_Manager.ppf"))
                .CreateNoWindow = True
            End With
            proc.Start()
            proc.WaitForExit()

            Dim fs As New BinaryRom(Me, FileAccess.ReadWrite)

            'Write Custom Background Pointer
            fs.Position = &H1202500
            For Each s As String In ("0A 02 00 00 0A 01 88 00 0A 02 00 00 0A 02 00 00 0A 02 00 00 0A 02 00 00 0A 01 48 00 0A 02 00 00 0A 01 48 00 0A 02 00 00 0A 02 00 00").Split(" ")
                fs.WriteByte(CInt("&H" & s))
            Next

            'Patch Act-Selector
            PatchClass.Open(fs)
            PatchClass.ActSelector_ApplyPatch()

            'Hardcoded Camera Settings
            PatchClass.HardcodedCamera_ApplyPatch()
            PatchClass.HardcodedCamera_DisableAll()

            'Restore Checksum Check
            PatchClass.RestoreChecksum()

            fs.Close()

            'Repaire patched music
            MusicList.NeedToSaveSequences = True
            MusicList.Read(RomFile)
            MusicList.NeedToSaveSequenceNames = True
            MusicList.NeedToSaveNInsts = True
            MusicList.NeedToSaveMusicHackSettings = True
            MusicList.Write(RomFile, 0)

            'Update Checksum
            PatchClass.UpdateChecksum(RomFile)
        End Sub

        ''' <summary>
        ''' Extens the ROM.
        ''' </summary>
        ''' <param name="IsSecondTry">If True, no new try will be executed, if failed.</param>
        Public Sub CreateROM(Optional IsSecondTry As Boolean = False)
            'Extend to 64MB
            Dim proc As New Process
            With proc.StartInfo
                .FileName = MyFilePaths("sm64extend.exe")
                .UseShellExecute = False
                .Arguments = String.Format("-a 16 -f ""{0}"" ""{0}""", RomFile)
                .CreateNoWindow = True
            End With
            proc.Start()
            proc.WaitForExit()

            If New FileInfo(RomFile).Length = 8 * 1024 * 1024 Then
                If IsSecondTry Then
                    Throw New Exception("Your ROM is invalid, it isn't possible to extend it.")
                Else
                    Dim fs As New BinaryRom(Me, FileAccess.Write)
                    fs.Position = &H10
                    For Each b As String In "63 5A 2B FF 8B 02 23 26".Split(" ") : fs.WriteByte("&H" & b) : Next
                    fs.Close()
                    CreateROM(True)
                End If
            End If
        End Sub

        ''' <summary>
        ''' Resets the Level Pointer of the Level with the given ID.
        ''' </summary>
        ''' <param name="ID">The ID where to reset the pointer.</param>
        Public Sub ResetLevelPointer(ID As Byte)
            ResetLevelPointer(LevelInfoData.GetByLevelID(ID))
        End Sub

        ''' <summary>
        ''' Resets the Level Pointer of the Level with the given Levelinfo.
        ''' </summary>
        ''' <param name="info">The Levelinfo where to reset the pointer.</param>
        Public Sub ResetLevelPointer(info As Levels.LevelInfoDataTabelList.Level)
            Dim fsPointer As New BinaryFile(Path.Combine(MyFilePaths("Original Level Pointers.bin")), FileMode.Open, FileAccess.Read)
            Dim fsRom As New BinaryRom(Me, FileAccess.ReadWrite)

            Dim data(&H13) As Byte
            fsPointer.Position = info.Pointer - &H2AC094
            fsPointer.Read(data, 0, data.Count)

            fsRom.Position = info.Pointer
            fsRom.Write(data)

            fsPointer.Close()
            fsRom.Close()
        End Sub

#Region "Segmented Banks"

        Public Function SetSegBank(BankID As Byte, RomStart As Integer, RomEnd As Integer) As SegmentedBank
            Return SetSegBank(BankID, RomStart, RomEnd, Nothing)
        End Function
        Public Function SetSegBank(BankID As Byte, RomStart As Integer, RomEnd As Integer, AreaID As Byte?) As SegmentedBank
            Dim newBank As SegmentedBank = New SegmentedBank() With {.BankID = BankID, .RomStart = RomStart, .RomEnd = RomEnd}
            SetSegBank(newBank, AreaID)
            Return newBank
        End Function
        Public Sub SetSegBank(SegBank As SegmentedBank)
            SetSegBank(SegBank, Nothing)
        End Sub
        Public Sub SetSegBank(SegBank As SegmentedBank, AreaID As Byte?)
            Dim sbl As Dictionary(Of Byte, SegmentedBank)

            If AreaID IsNot Nothing Then
                If areaSegBankList.ContainsKey(AreaID) Then
                    sbl = areaSegBankList(AreaID)
                Else
                    sbl = New Dictionary(Of Byte, SegmentedBank)
                    areaSegBankList.Add(AreaID, sbl)
                End If
            Else
                sbl = segBankList
            End If

            If sbl.ContainsKey(SegBank.BankID) Then
                sbl.Remove(SegBank.BankID)
            End If
            sbl.Add(SegBank.BankID, SegBank)
        End Sub
        Public Function GetSegBank(BankID As Byte) As SegmentedBank
            Return GetSegBank(BankID, Nothing)
        End Function
        Public Function GetSegBank(BankID As Byte, AreaID As Byte?) As SegmentedBank
            If AreaID IsNot Nothing AndAlso areaSegBankList.ContainsKey(AreaID) AndAlso areaSegBankList(AreaID).ContainsKey(BankID) Then
                Return areaSegBankList(AreaID)(BankID)
            ElseIf segBankList.ContainsKey(BankID) Then
                Return segBankList(BankID)
            Else
                Return Nothing
            End If
        End Function
        Public Function GetAllSegBanks() As SegmentedBank()
            Dim sb As New List(Of SegmentedBank)
            For Each kvp In segBankList
                sb.Add(kvp.Value)
            Next
            Return sb.ToArray
        End Function

#End Region

    End Class

End Namespace
