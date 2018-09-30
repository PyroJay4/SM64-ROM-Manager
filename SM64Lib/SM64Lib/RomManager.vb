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

Namespace Global.SM64Lib

    Public Class RomManager

        Private textsProfile As Text.Profiles.Profile

        Public ReadOnly Property LevelInfoData As New LevelInfoDataTabelList
        Public ReadOnly Property Levels As New Levels.LevelList
        Public ReadOnly Property RomFile As String = ""
        Public ReadOnly Property IsSM64EditorMode As Boolean = False
        Public ReadOnly Property Settings As New ManagerSettings
        Public ReadOnly Property TextTables As Text.TextTable() = {Nothing, Nothing, Nothing}
        Public ReadOnly Property MusicList As New MusicList
        Public Property GlobalObjectBank As CustomObjectBank = Nothing

        Private ReadOnly segBankList As New Dictionary(Of Byte, SegmentedBank)
        Private ReadOnly areaSegBankList As New Dictionary(Of Byte, Dictionary(Of Byte, SegmentedBank))
        Private dicUpdatePatches As New Dictionary(Of String, String)

        Private _ProgramVersion As Version = Nothing
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

        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return MusicList.NeedToSave OrElse
                    TextTables.Where(Function(n) n IsNot Nothing AndAlso n.NeedToSave).Count > 0 OrElse
                    Levels.NeedToSave
            End Get
        End Property

        Public ReadOnly Property HasGlobalObjectBank As Boolean
            Get
                Return GlobalObjectBank IsNot Nothing
            End Get
        End Property

        Public Function AreRomUpdatesAvaiable() As Boolean
            Return dicUpdatePatches.Where(Function(n) New Version(n.Key) > Me.ProgramVersion).Count > 0
        End Function

        Public Sub New(FileName As String)
            RomFile = FileName

            LevelInfoData.ReadFromFile(MyDataPath & "\Other\Level Tabel.json")

            SetSegBank(&H15, &H2ABCA0, &H2AC6B0)
            SetSegBank(&H2, &H108A40, &H114750)
            'SetSegBank(&H2, &H803156, 0) 'Text Table??

            LoadDictionaryUpdatePatches()
        End Sub

        Private Sub LoadDictionaryUpdatePatches()
            Dim jsFile As String = File.ReadAllText(MyDataPath & "\Patchs\Update-Patches\Update-Patches.json")
            Dim obj As JObject = JObject.Parse(jsFile)

            dicUpdatePatches = obj.ToObject(GetType(Dictionary(Of String, String)))
        End Sub

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
        Public Function GetBinaryRom(access As FileAccess)
            Return New BinaryRom(Me, access)
        End Function

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

        Public Sub WriteVersion(newVersion As Version)
            Me.ProgramVersion = newVersion

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)
            fs.Position = &H1201FFC

            fs.WriteByte(ProgramVersion.Major)
            fs.WriteByte(ProgramVersion.Minor)
            fs.WriteByte(ProgramVersion.Build)
            fs.WriteByte(ProgramVersion.Revision)

            fs.Close()
        End Sub

        Public Function LoadVersion() As Version
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
        Private Function GetTextProfile(index As Integer) As Text.Profiles.Section
            If textsProfile Is Nothing Then
                textsProfile = JObject.Parse(File.ReadAllText(Path.Combine(MyDataPath, "Text Manager\Profiles.json"))).ToObject(Of Text.Profiles.Profile)
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
        ''' </summary>
        ''' <param name="index">0 = Dialogs, 1 = Level Names, 2 = Act Names</param>
        Public Sub LoadTextTable(index As Integer, Optional CheckIfAlreadyLoaded As Boolean = True)
            If CheckIfAlreadyLoaded AndAlso TextTables(index) IsNot Nothing Then Return

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.Read)
            Dim prof As Text.Profiles.Section = GetTextProfile(index)

            Try
                TextTables(index) = New Text.TextTable(index, prof.Data.DataMaxSize, prof.Data.TableMaxItems)
                TextTables(index).FromStream(fs, &H2000000, SegmentedBanks.Bank0x2RomStart, prof.Data.TableRomOffset)
            Catch ex As Exception
            End Try

            fs.Close()
        End Sub
        ''' <summary>
        ''' </summary>
        ''' <param name="index">0 = Dialogs, 1 = Level Names, 2 = Act Names</param>
        Public Sub SaveTextTable(index As Integer)
            If TextTables(index) Is Nothing Then Return

            Dim fs As New FileStream(RomFile, FileMode.Open, FileAccess.ReadWrite)
            Dim prof As Text.Profiles.Section = GetTextProfile(index)

            TextTables(index).ToStream(fs, SegmentedBanks.Bank0x2RomStart, &H2000000, ValueFromText(prof.Data.TableRomOffset), ValueFromText(prof.Data.DataRomOffset), ValueFromText(prof.Data.TableRomOffset2))

            fs.Close()
        End Sub

        Public Sub SaveAllTextTables(Optional IgnoreNeedToSave As Boolean = False)
            For i As Integer = 0 To TextTables.Length - 1
                If IgnoreNeedToSave OrElse TextTables(i)?.NeedToSave Then SaveTextTable(i)
            Next
        End Sub

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

        Public Sub SaveLevels(Optional StartAddress As Integer = -1, Optional ClearRomForSave As Boolean = True)
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

        Public Sub AddLevel(LevelID As Byte)
            Dim newLevel As New Levels.Level(LevelID, LevelInfoData.GetByLevelID(LevelID).Index) 'GetLevelIndexFromID(LevelID)
            Levels.Add(newLevel)
        End Sub

        Public Sub RemoveLevel(level As Levels.Level)
            Levels.Remove(level)
            ResetLevelPointer(level.LevelID)
        End Sub
        Public Sub ChangeLevelID(level As Levels.Level, newLevelID As UShort, Optional EnableActSelector As Boolean? = Nothing)
            ResetLevelPointer(level.LevelID)
            level.LevelID = newLevelID
            If EnableActSelector IsNot Nothing Then level.ActSelector = EnableActSelector
        End Sub

        Public Sub LoadMusic()
            MusicList.Read(RomFile)
        End Sub

        Public Sub ClearRomForSave(Romfile As String, StartAddress As Integer, Optional EndAddress As Integer = -1)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.ReadWrite)

            If EndAddress = -1 Then _
                EndAddress = fs.Length

            fs.Position = StartAddress
            For i As Integer = fs.Position To EndAddress
                fs.WriteByte(&H1)
            Next

            fs.Close()
        End Sub

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
            PatchClass.Openfs(fs)
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
                    For Each b As String In ("63 5A 2B FF 8B 02 23 26").Split(" ") : fs.WriteByte(CByte("&H" & b)) : Next
                    fs.Close()
                    CreateROM(True)
                End If
            End If
        End Sub

        Public Sub ResetLevelPointer(ID As Byte)
            ResetLevelPointer(LevelInfoData.GetByLevelID(ID))
        End Sub
        Public Sub ResetLevelPointer(info As LevelInfoDataTabelList.Level)
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

        Public Class ManagerSettings
            Public Const defaultRangeForLevelsStart As UInteger = &H1410000
            Public Const defaultRangeForLevelsEnd As UInteger = &H3FFFFFF
            Public Const defaultLevelscriptSize As UInteger = &HA000

            Public Property AddRangeAddToLevelscript As UInteger = 0
            Public Property AddRangeAddToBank0xE As UInteger = 0
            Public Property RangeForLevelsStart As UInteger = defaultRangeForLevelsStart
            Public Property RangeForLevelsEnd As UInteger = defaultRangeForLevelsEnd
        End Class

    End Class

    Public Class SegmentedBank

        Public Property RomStart As Integer = 0
        Public Property BankID As Byte = 0
        Private _RomEnd As Integer = 0
        Public ReadOnly Property IsMIO0 As Boolean = False
        Public Property Data As MemoryStream = Nothing

        Public Property RomEnd As Integer
            Get
                If _Data Is Nothing Then
                    Return _RomEnd
                Else
                    Return _RomStart + _Data.Length
                End If
            End Get
            Set(value As Integer)
                If _Data Is Nothing Then
                    _RomEnd = value
                Else
                    Dim newLength As Long = value - _RomStart
                    If _Data.Length <> newLength Then
                        _Data.SetLength(newLength)
                    End If
                End If
            End Set
        End Property

        Public Property BankAddress As Integer
            Get
                Return CUInt(BankID) << 24
            End Get
            Set(value As Integer)
                BankID = (value >> 24) And &HFF
            End Set
        End Property

        Public Property Length As Integer
            Get
                If _Data Is Nothing Then
                    Return RomEnd - RomStart
                Else
                    Return _Data.Length
                End If
            End Get
            Set(value As Integer)
                If _Data Is Nothing Then
                    RomEnd = RomStart + value
                Else
                    _Data.SetLength(value)
                End If
            End Set
        End Property

        Public Sub New()
        End Sub
        Public Sub New(bankID As Byte)
            Me.BankID = bankID
        End Sub
        Public Sub New(bankID As Byte, length As UInteger)
            Me.BankID = bankID
            Me.Length = length
        End Sub
        Public Sub New(bankID As Byte, data As MemoryStream)
            Me.BankID = bankID
            Me.Data = data
        End Sub
        Public Sub New(data As MemoryStream)
            Me.Data = data
        End Sub

        Public Sub MakeAsMIO0()
            _IsMIO0 = True
        End Sub

        Public Function SegToRomAddr(SegmentedAddress As Integer) As Integer
            Return SegmentedAddress - Me.BankAddress + Me.RomStart
        End Function
        Public Function RomToSegAddr(RomAddress As Integer) As Integer
            Return RomAddress - Me.RomStart + Me.BankAddress
        End Function
        Public Function BankOffsetFromSegAddr(segPointer As Integer) As Integer
            Return segPointer - Me.BankAddress
        End Function
        Public Function BankOffsetFromRomAddr(RomAddr As Integer) As Integer
            Return RomAddr - Me.RomStart
        End Function

        Public Function ReadData(rommgr As RomManager) As MemoryStream
            Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
            Dim ms As MemoryStream

            ms = ReadDataIfNull(fs)
            fs.Close()

            _Data = ms
            Return ms
        End Function
        Public Function ReadDataIfNull(s As Stream) As MemoryStream
            If _Data Is Nothing Then
                ReadData(s)
            End If
            Return _Data
        End Function
        Public Function ReadDataIfNull(fileName As String) As MemoryStream
            If _Data Is Nothing Then
                Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
                ReadData(fs)
                fs.Close()
            End If
            Return _Data
        End Function
        Public Function ReadDataIfNull(rommgr As RomManager) As MemoryStream
            Return ReadDataIfNull(rommgr.RomFile)
        End Function
        Public Function ReadData(s As Stream) As MemoryStream
            Dim ms As New MemoryStream

            If RomStart > 0 AndAlso Length > 0 AndAlso s.Length >= RomEnd Then
                Dim data As Byte() = New Byte(Length - 1) {}
                s.Position = RomStart
                s.Read(data, 0, data.Length)

                If IsDataMIO0(data) Then
                    data = LIBMIO0.MIO0.mio0_decode(data)
                End If

                ms.Write(data, 0, data.Length)

                ms.Position = 0
            End If

            If _Data IsNot Nothing Then _Data.Close()
            _Data = ms

            Return ms
        End Function

        Private Function IsDataMIO0(arr As Byte()) As Boolean
            Dim check As Integer =
                (CInt(arr(0)) << 24) Or
                (CInt(arr(1)) << 16) Or
                (CInt(arr(2)) << 8) Or
                arr(3)
            Return check = &H4D494F30
        End Function

        Public Sub WriteData(rommgr As RomManager)
            If _Data IsNot Nothing Then
                Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.ReadWrite)
                WriteData(fs)
                fs.Close()
            End If
        End Sub
        Public Sub WriteData(s As Stream)
            If _Data IsNot Nothing Then
                _Data.Position = 0
                s.Position = RomStart
                For i As Integer = 1 To _Data.Length
                    s.WriteByte(_Data.ReadByte)
                Next
            End If
        End Sub

    End Class

End Namespace
