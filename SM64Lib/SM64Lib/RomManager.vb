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

Namespace Global.SM64Lib

    Public Class RomManager

        Private textsProfile As Text.Profiles.TextProfile
        Private ReadOnly segBankList As New Dictionary(Of Byte, SegmentedBank)
        Private ReadOnly areaSegBankList As New Dictionary(Of Byte, Dictionary(Of Byte, SegmentedBank))
        Private dicUpdatePatches As New Dictionary(Of String, String)
        Private _ProgramVersion As Version = Nothing

        'Public ReadOnly Property Settings As New RomManagerSettings
        Public ReadOnly Property LevelInfoData As New Levels.LevelInfoDataTabelList
        Public ReadOnly Property Levels As New Levels.LevelList
        Public Property RomFile As String = ""
        Public ReadOnly Property IsSM64EditorMode As Boolean = False
        Public ReadOnly Property TextTables As Text.TextTable() = {Nothing, Nothing, Nothing}
        Public ReadOnly Property MusicList As New MusicList
        Public Property GlobalObjectBank As CustomObjectBank = Nothing

        ''' <summary>
        ''' Gets or sets the lastly used program version for this ROM.
        ''' </summary>
        ''' <returns></returns>
        Public Property ProgramVersion As Version
            Get
                If _ProgramVersion Is Nothing Then
                    Return LoadVersion()
                Else
                    Return _ProgramVersion
                End If
            End Get
            Set(value As Version)
                _ProgramVersion = value
            End Set
        End Property

        ''' <summary>
        ''' Gets if the ROM has unsaved chnages and need to be saved.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return MusicList.NeedToSave OrElse
                    TextTables.Where(Function(n) n IsNot Nothing AndAlso n.NeedToSave).Count > 0 OrElse
                    Levels.NeedToSave
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

        ''' <summary>
        ''' Gets if Update Patches are avaiable for this ROM.
        ''' </summary>
        ''' <returns></returns>
        Public Function AreRomUpdatesAvaiable() As Boolean
            Return dicUpdatePatches.Where(Function(n) New Version(n.Key) > Me.ProgramVersion).Count > 0
        End Function

        ''' <summary>
        ''' Creates a new instance with input ROM.
        ''' </summary>
        ''' <param name="FileName">The ROM that will be opened.</param>
        Public Sub New(FileName As String)
            RomFile = FileName

            LevelInfoData.ReadFromFile(MyDataPath & "\Other\Level Tabel.json")

            SetSegBank(&H0, 0, New FileInfo(FileName).Length) 'Bank 0 means the whole ROM.
            SetSegBank(&H15, &H2ABCA0, &H2AC6B0)
            'SetSegBank(&H2, &H108A40, &H114750)
            SetSegBank(&H2, &H803156, 0) 'Text Table??

            LoadDictionaryUpdatePatches()
        End Sub

        Private Sub LoadDictionaryUpdatePatches()
            Dim jsFile As String = File.ReadAllText(MyDataPath & "\Patchs\Update-Patches\Update-Patches.json")
            Dim obj As JObject = JObject.Parse(jsFile)

            dicUpdatePatches = obj.ToObject(GetType(Dictionary(Of String, String)))
        End Sub

        ''' <summary>
        ''' Gets or sets the Game Name which is used for the EEP-ROM (Save file).
        ''' </summary>
        ''' <returns></returns>
        Public Property GameName As String
            Get
                Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Read)
                Dim br As New BinaryReader(fs)
                fs.Position = &H20
                GameName = Encoding.ASCII.GetString(br.ReadBytes(&H14)).Trim
                fs.Close()
            End Get
            Set(value As String)
                Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Write)
                Dim bw As New BinaryWriter(fs)
                fs.Position = &H20
                For Each b As Byte In Encoding.ASCII.GetBytes(value)
                    bw.Write(b)
                Next
                Do While fs.Position < &H34
                    bw.Write(CByte(&H20))
                Loop
                fs.Close()
            End Set
        End Property

        Friend Function GetStream(access As FileAccess) As Stream
            Return New FileStream(RomFile, FileMode.Open, access)
        End Function

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
            Dim needUpdateChecksum As Boolean = MusicList.NeedToSaveMusicHackSettings

            If Not DontPatchUpdates Then
                'Patch update-patches
                For Each kvp As KeyValuePair(Of String, String) In dicUpdatePatches.Where(Function(n) New Version(n.Key) > Me.ProgramVersion).OrderBy(Function(n) n.Key)
                    PatchClass.ApplyPPF(RomFile, MyDataPath & "\Patchs\Update-Patches\" & kvp.Value)
                    needUpdateChecksum = True
                Next
            End If

            'Write Version
            WriteVersion(Assembly.GetEntryAssembly.GetName.Version)

            'Texts
            SaveAllTextTables()

            'Music
            Dim lastpos As Integer
            MusicList.Write(RomFile, lastpos)
            HexRoundUp2(lastpos)

            'Global Object Bank
            'SaveGlobalObjectBank(lastpos)
            HexRoundUp2(lastpos)

            'Levels
            SaveLevels(lastpos) 'If IgnoreNeedToSave OrElse Levels.NeedToSave Then

            If needUpdateChecksum Then PatchClass.UpdateChecksum(RomFile)
        End Sub

        Private Sub WriteVersion(newVersion As Version)
            Me.ProgramVersion = newVersion

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)
            fs.Position = &H1201FFC

            fs.WriteByte(ProgramVersion.Major)
            fs.WriteByte(ProgramVersion.Minor)
            fs.WriteByte(ProgramVersion.Build)
            fs.WriteByte(ProgramVersion.Revision)

            fs.Close()
        End Sub

        Private Function LoadVersion() As Version
            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Read)
            fs.Position = &H1201FFC

            Dim major As Byte = fs.ReadByte
            Dim minor As Byte = fs.ReadByte
            Dim build As Byte = fs.ReadByte
            Dim revision As Byte = fs.ReadByte

            fs.Close()

            If major = 1 AndAlso minor = 0 AndAlso build = 0 AndAlso revision = 0 Then
                major = 0
                minor = 3
            End If

            ProgramVersion = New Version(major, minor, build, revision)

            Return Me.ProgramVersion
        End Function

        ''' <summary>
        ''' </summary>
        ''' <param name="index">0 = Dialogs, 1 = Level Names, 2 = Act Names</param>
        Private Function GetTextProfile(index As Integer) As Text.Profiles.TextSection
            If textsProfile Is Nothing Then
                textsProfile = JObject.Parse(File.ReadAllText(Path.Combine(MyDataPath, "Text Manager\Profiles.json"))).ToObject(Of Text.Profiles.TextProfile)
            End If

            Select Case index
                Case 0
                    Return textsProfile.Dialogs
                Case 1
                    Return textsProfile.Levels
                Case 2
                    Return textsProfile.Acts
            End Select

            Return Nothing
        End Function

        ''' <summary>
        ''' Loads the Text Tables.
        ''' </summary>
        ''' <param name="index">0 = Dialogs, 1 = Level Names, 2 = Act Names</param>
        Public Sub LoadTextTable(index As Integer, Optional CheckIfAlreadyLoaded As Boolean = True)
            If CheckIfAlreadyLoaded AndAlso TextTables(index) IsNot Nothing Then Return

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Read)
            Dim prof As Text.Profiles.TextSection = GetTextProfile(index)

            Try
                TextTables(index) = New Text.TextTable(index, prof.Data.DataMaxSize, prof.Data.TableMaxItems)
                TextTables(index).FromStream(fs, &H2000000, SegmentedBanks.Bank0x2RomStart, prof.Data.TableRomOffset)
            Catch ex As Exception
            End Try

            fs.Close()
        End Sub

        ''' <summary>
        ''' Saves the Text Tables.
        ''' </summary>
        ''' <param name="index">0 = Dialogs, 1 = Level Names, 2 = Act Names</param>
        Public Sub SaveTextTable(index As Integer)
            If TextTables(index) Is Nothing Then Return

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)
            Dim prof As Text.Profiles.TextSection = GetTextProfile(index)

            TextTables(index).ToStream(fs, SegmentedBanks.Bank0x2RomStart, &H2000000, ValueFromText(prof.Data.TableRomOffset), ValueFromText(prof.Data.DataRomOffset), ValueFromText(prof.Data.TableRomOffset2))

            fs.Close()
        End Sub

        ''' <summary>
        ''' Saves all Text Tables.
        ''' </summary>
        ''' <param name="IgnoreNeedToSave">If True, everything will be saved even if there are no changes.</param>
        Public Sub SaveAllTextTables(Optional IgnoreNeedToSave As Boolean = False)
            For i As Integer = 0 To TextTables.Length - 1
                If IgnoreNeedToSave OrElse TextTables(i)?.NeedToSave Then SaveTextTable(i)
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

                    If IsSM64EditorMode Then
                        curLevel = New Levels.Level(SM64Lib.Levels.LevelType.SM64Editor)
                        SM64Lib.Levels.LevelManager.LoadSM64EditorLevel(curLevel, Me, ldi.ID, offset)
                    Else
                        curLevel = New Levels.Level(SM64Lib.Levels.LevelType.SM64RomManager)
                        SM64Lib.Levels.LevelManager.LoadRomManagerLevel(curLevel, Me, ldi.ID, offset)
                    End If

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

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)
            fs.Position = curOff

            For Each lvl As Levels.Level In Levels
                Dim res As Levels.LevelManager.LevelSaveResult
                res = SM64Lib.Levels.LevelManager.SaveRomManagerLevel(lvl, Me, fs, curOff)
                lvl.LastRomOffset = res.Bank0x19.RomStart
                HexRoundUp2(curOff)
            Next

            fs.Close()
        End Sub

        ''' <summary>
        ''' Loads the global object bank, if avaiable (WIP)
        ''' </summary>
        Public Sub LoadGlobalObjectBank()
            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Read)
            Dim br As New BinaryReader(fs)

            'Read Bank Addres & Length from Rom
            fs.Position = &H120FFF0
            Dim seg As New SegmentedBank(&H7)
            seg.RomStart = SwapInts.SwapInt32(br.ReadInt32)
            seg.RomEnd = SwapInts.SwapInt32(br.ReadInt32)

            If seg.RomStart <> &H1010101 AndAlso seg.RomStart > -1 Then
                'Set Segmented Bank
                SetSegBank(seg)

                'Load Object Bank
                GlobalObjectBank = New CustomObjectBank
                GlobalObjectBank.ReadFromSeg(Me, seg)
            Else
                'Set Object Bank to Null
                GlobalObjectBank = Nothing
            End If

            fs.Close()
        End Sub

        Private Sub SaveGlobalObjectBank(ByRef offset As Integer)
            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)
            Dim bw As New BinaryWriter(fs)
            Dim seg As SegmentedBank = GlobalObjectBank.WriteToSeg(&H7, 0)

            'Set Segmented Bank
            seg.RomStart = offset
            SetSegBank(seg)

            'Write Segmented Bank
            seg.WriteData(fs)
            offset = fs.Position

            'Write Bank Address & Length to Rom
            fs.Position = &H120FFF0
            bw.Write(SwapInts.SwapInt32(seg.RomStart))
            bw.Write(SwapInts.SwapInt32(seg.RomEnd))

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
            ResetLevelPointer(level.LevelID)
        End Sub

        ''' <summary>
        ''' Changes the Level ID from a existing Level.
        ''' </summary>
        ''' <param name="level">The Level where to change the Level ID.</param>
        ''' <param name="newLevelID">The new Level ID.</param>
        ''' <param name="EnableActSelector">Activate/Deactivate the Act Selector fot the Level.</param>
        Public Sub ChangeLevelID(level As Levels.Level, newLevelID As UShort, Optional EnableActSelector As Boolean? = Nothing)
            ResetLevelPointer(level.LevelID)
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

            Dim br As New BinaryReader(New FileStream(RomFile, FileMode.Open, FileAccess.Read))
            br.BaseStream.Position = &H1200000
            Dim tCheckData = SwapInts.SwapInt64(br.ReadInt64)
            br.BaseStream.Close()

            _IsSM64EditorMode = ({&H800800001900001C, &H800800000E0000C4}).Contains(tCheckData)

            Return True
        End Function

        Private Sub PrepairROM()
            'Patch things
            Dim proc As New Process
            With proc.StartInfo
                .FileName = MyDataPath & "\Tools\ApplyPPF3.exe"
                .UseShellExecute = False
                .Arguments = String.Format("a ""{0}"" ""{1}""", RomFile, MyDataPath & "\Patchs\SM64_ROM_Manager.ppf")
                .CreateNoWindow = True
            End With
            proc.Start()
            proc.WaitForExit()

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)

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
                .FileName = MyDataPath & "\Tools\sm64extend.exe"
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
                    Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Write)
                    fs.Position = &H10
                    For Each b As String In ("63 5A 2B FF 8B 02 23 26").Split(" ") : fs.WriteByte("&H" & b) : Next
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
            Dim fsPointer As New FileStream(Application.StartupPath & "\Data\Other\Original Level Pointers.bin", FileMode.Open, FileAccess.Read)
            Dim fsRom As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)

            Dim data(&H14) As Byte
            fsPointer.Position = info.Pointer - &H2AC094
            fsPointer.Read(data, 0, data.Count)

            fsRom.Position = info.Pointer
            fsRom.Write(data, 0, data.Count)

            fsPointer.Close()
            fsRom.Close()
        End Sub

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

    End Class

End Namespace
