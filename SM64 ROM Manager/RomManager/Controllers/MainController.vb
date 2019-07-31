Imports System.IO
Imports DevComponents.DotNetBar.Controls
Imports nUpdate.Updating
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib
Imports SM64_ROM_Manager.Publics
Imports SM64_ROM_Manager.My.Resources
Imports SM64_ROM_Manager.EventArguments
Imports System.Threading
Imports DevComponents.DotNetBar
Imports Pilz.Reflection
Imports SM64Lib.Exceptions
Imports System.Globalization
Imports PatchScripts
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports System.Collections.Specialized
Imports SM64Lib.Music
Imports SM64Lib.Data
Imports SM64Lib.Levels
Imports SM64Lib.Text.Profiles
Imports SM64Lib.Text
Imports SM64_ROM_Manager.LevelEditor
Imports System.Numerics
Imports SM64Lib.Levels.Script.Commands
Imports SM64_ROM_Manager.ModelConverterGUI
Imports SM64Lib.Geolayout
Imports SM64Lib.Model
Imports SM64Lib.Script
Imports SM64Lib.ObjectBanks
Imports Pilz.S3DFileParser
Imports SM64Lib.Levels.Script

Public Class MainController

    'E v e n t s

    Public Event RomLoading()
    Public Event RomLoaded()
    Public Event RomMusicLoaded()
    Public Event RomLevelsLoaded()
    Public Event StatusTextChanged(e As StatusTextChangedEventArgs)
    Public Event OtherStatusInfosChanged(e As OtherStatusInfosChangedEventArgs)
    Public Event RecentFilesChanged()
    Public Event RomFileRenamed()
    Public Event RomFileDeleted()
    Public Event RomFileChanged()
    Public Event RomChangesAvailable(e As RomChangesAvaiableEventArgs)
    Public Event MusicSequenceRemoved(e As MusicSequenceEventArgs)
    Public Event MusicSequenceAdded(e As MusicSequenceEventArgs)
    Public Event MusicSequenceChanged(e As MusicSequenceEventArgs)
    Public Event RequestReloadTextManagerLists()
    Public Event RequestReloadTextManagerLineColors()
    Public Event TextItemChanged(e As TextItemEventArgs)
    Public Event TextItemAdded(e As TextItemEventArgs)
    Public Event TextItemRemoved(e As TextItemEventArgs)
    Public Event RequestIsChangingTab(e As EnabledEventArgs)
    Public Event LevelSpecialItemAdded(e As SpecialItemEventArgs)
    Public Event LevelSpecialItemRemoved(e As SpecialItemEventArgs)
    Public Event LevelSpecialItemChanged(e As SpecialItemEventArgs)
    Public Event LevelAdded(e As LevelEventArgs)
    Public Event LevelRemoved(e As LevelEventArgs)
    Public Event LevelAreaAdded(e As LevelAreaEventArgs)
    Public Event LevelAreaRemoved(e As LevelAreaEventArgs)
    Public Event LevelIDChanged(e As LevelEventArgs)
    Public Event LevelBackgroundModeChanged(e As LevelBackgroundModeChangedEventArgs)
    Public Event LevelBackgroundImageChanged(e As LevelBackgroundImageChangedEventArgs)
    Public Event LevelAreaBackgroundModeChanged(e As LevelAreaBackgroundModeChangedEventArgs)

    'C o n s t a n t s

    Public Const PLUGINCODE_PLUGINMENU As String = "pluginmenu"

    'F i e l d s

    Private ReadOnly mainForm As MainForm
    Private ReadOnly updateManager As UpdateManager = Nothing
    Private romManager As RomManager = Nothing
    Private _StatusText As String = String.Empty
    Private loadRecentROM As Boolean = False
    Private loadingROM As Boolean = False
    Private savingRom As Boolean = False
    Private hasRomChanged As Byte = 0
    Private WithEvents RomWatcher As FileSystemWatcher = Nothing

    'P r o p e r t i e s

    Private ReadOnly Property DialogNamesFilePath As String
        Get
            Static p As String = Path.Combine(MyDataPath, "Text Manager\dialogs.txt")
            Return p
        End Get
    End Property

    Public ReadOnly Property Romfile As String
        Get
            Return romManager?.RomFile
        End Get
    End Property

    Public Property StatusText As String
        Get
            Return _StatusText
        End Get
        Set
            If String.IsNullOrEmpty(Value) Then Value = Form_Main_Resources.Status_Ready
            _StatusText = Value
            RaiseEvent StatusTextChanged(New StatusTextChangedEventArgs(_StatusText))
        End Set
    End Property

    Public ReadOnly Property HasRomManager As Boolean
        Get
            Return romManager IsNot Nothing
        End Get
    End Property

    Public Property EnableMusicHack As Boolean
        Get
            Return romManager.MusicList.EnableMusicHack
        End Get
        Set(value As Boolean)
            If value <> romManager.MusicList.EnableMusicHack Then
                romManager.MusicList.EnableMusicHack = value
                romManager.MusicList.NeedToSaveMusicHackSettings = True
            End If
        End Set
    End Property

    Public ReadOnly Property IsLoadingRom As Boolean
        Get
            Return loadingROM
        End Get
    End Property

    'C o n s t r u c t o r

    Public Sub New(mainForm As MainForm)
        Me.mainForm = mainForm

        'Do some default inits
        DoDefaultInitsAfterApplicationStartup()

        'Updates
        Dim updateVersion As New UpdateVersion(Application.ProductVersion) With {
            .DevelopmentalStage = CInt(DevelopmentalStage),
            .DevelopmentBuild = DevelopmentBuild
        }

        updateManager = New UpdateManager(New Uri("http://pilzinsel64.square7.ch/Updates/SM64_ROM_Manager_New/updates.json"), "<RSAKeyValue><Modulus>w5WpraTgIe2QlQGkvrJDcdrtRkb1AQ0iDMO0JMsCd7rPoUYw7cu7YnRreeadU5jBiit4G82oB/TOtT+quJPDBixxKjof9gKVqrxeKtMYU/3vwRQg0+Y77GFD6tMLNlJwrk1NzgS3FN2Zlpl9LplgeQr9g5RSKMyu+VJ5OTZOHZAyHpvMnPSD9V1Kpyj/WFf2ADf9PL3Z4vEJfcmoFdGY6i4hq4IAIe5o5lYGB5zC/QOfDuAHEO+oGbOkFs65BeHDZWkLnzBOYPI4rnHZpU9E/ChcJVerNln45D9XGElDVXy7AIdy417mefjqnPaqMgm/22aTUW3f1Jsy3kcUhe1/f5eE/PHQoFvLPjcezY5mPUkW5JT1Y+2tIROvXh5zejyb+/2ctyVLSqLhG6wh4UNFd60Be4mV2NJ+Acn9IagdvMW3AvUmbSgQK4Jmq2OP656XkrdDi2vGibdMOB2Nt+O/q5+GpbzrEAnX+t9ikxmT568PpfjGBVvh+DmQxhiEaKT28HKWuDwLOdq6bnnnw6LlqF0odHqf2L09uXULJQo9W8zMoA5lyNbgHTfrj1ik9X4xheZkqmwJWIyYrRsPsyLN6Eani4vqVeVgBfJxdon45x5tPqYhadHoIHWU8WxnIGBnDAmaBZ/6lQpfTmbo3c8T2WuNjQAarzmnFKHP6GqP9X7JFhGQklTI5LFNsz6IjFRoHl/R5bUi6GJddoFitKXT4XjaJw+zR4Vp6W37wLjbe/r7Wd+vBST3YxTELQ+zQ3lxOb3Ht+0psinyaqqWVG8jh69axesPDIXvqDmZsYTlbm8YWyHeViX6xDo1+gYCZkFnCqdpXaB2B2a/bnvV1DKRDWCUi122BzCkUQg104F2ncnTnwrEwGXBQzVcZkkCtNhoiQRbOz+kJZz3tdmF+IPdhsdevpB4XwVbb/aTCkx2T68LOrGCuaKZ8EmHzTEbX2thSs7q3+ImfxCC9pubzCgwQEiS4MD/k+BMfDt7JQEPSP8EvBDxLLJ8Ls34/GnX5DSkUwMC3a/DUoZ0FgV8aIJEPSequjB/HtVQaR9t8j8ynr9FpsxGS0Qa0UZLt5ACG76Z4wgnLdrPKJMD0hcscmdiy4ov3a3AkuvkvIeGDwWFRMFrwq4F+5+i5AvC+f+jjwRjCckOEUsUrgcycsLXDMKjD0VGRLQIr+qegB1I7Wrl15ctvS+z3YIgx+SrGNbrEzLKxV5Habe/HKZrQ2t8JzflurHJByifFQ/Szp0BkoOXkVmkuczAw0a/DglU2um1Ic8cXAuNIWP0PbYpvVDUnChZrFMVO5QFMAdI8Ei9LHbjlTNdegXtHXIGJS9uXdf8285rlHsyVkCHbtFyZRsQSkuDuQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", New CultureInfo("en"), updateVersion) With {
            .HostApplicationOptions = nUpdate.Shared.Core.HostApplicationOptions.CloseAndRestart,
            .InstallAsAdmin = Settings.General.UseAdminRightsForUpdates,
            .IncludeBeta = Settings.General.IncludeBetaVersions Or (DevelopmentalStage >= 2),
            .IncludeAlpha = Settings.General.IncludeAlphaVersions Or DevelopmentalStage = 3
        }

        'Enable Auto-Save for Settings
        Settings.AutoSave = True
    End Sub

    'P r i v a t e   F e a u t u r e s

    Private Sub SetRomMgr(rommgr As RomManager)
        Me.romManager = rommgr
        UpdateRomDate()
    End Sub

    'M a i n   F e a t u r e s

    Public Sub UpdateRomDate()
        lastRomChangedDate = Date.Now
    End Sub

    Public Sub SetOtherStatusInfos(text As String, foreColor As Color)
        RaiseEvent OtherStatusInfosChanged(New OtherStatusInfosChangedEventArgs(text, foreColor))
    End Sub

    Public Sub SearchForUpdates(searchHidden As Boolean)
        Dim ui As New UpdaterUI(updateManager, SynchronizationContext.Current, True)
        ui.UseHiddenSearch = searchHidden
        ui.ShowUserInterface()
    End Sub

    Public Sub CheckCommandLineArgs()
        Dim fileToOpen As String = Nothing

        For Each arg In Environment.GetCommandLineArgs
            If arg = Application.ExecutablePath Then Continue For
            Select Case arg
                Case Else : If fileToOpen Is Nothing Then fileToOpen = arg
            End Select
        Next

        If fileToOpen IsNot Nothing Then
            Select Case Path.GetExtension(fileToOpen).ToLower
                Case ".z64"
                    OpenRom(fileToOpen)
            End Select
        End If
    End Sub

    Public Function WaitWhileSavingRom() As Task
        Dim t As New Task(
            Sub()
                Do While savingRom
                Loop
            End Sub)
        t.Start()
        Return t
    End Function

    Public Sub LaunchRom()
        General.LaunchRom(romManager)
    End Sub

    Public Function AllowSavingRom() As Boolean
        If IsTextOverLimit() Then
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_TextsOverLimit, Form_Main_Resources.MsgBox_TextsOverLimit_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Public Function SaveRom() As Boolean
        If AllowSavingRom() Then
            StatusText = Form_Main_Resources.Status_SavingRom
            savingRom = True

            General.SaveRom(romManager)

            savingRom = False
            StatusText = String.Empty

            Return True
        Else
            Return False
        End If
    End Function

    Public Function DoesRomManagerNeedToSave() As Boolean
        If romManager Is Nothing Then
            Return False
        Else
            Return romManager.NeedToSave
        End If
    End Function

    Public Function OpenRom() As Boolean
        Dim ret As Boolean = False
        Dim ofd_SM64RM_LoadROM As New OpenFileDialog With {
            .Filter = "SM64 ROMs (*.z64)|*.z64"
        }

        Dim lastFiles As StringCollection = Settings.RecentFiles.RecentROMs
        If lastFiles.Count > 0 Then
            ofd_SM64RM_LoadROM.InitialDirectory = Path.GetDirectoryName(lastFiles(0))
        End If

        If ofd_SM64RM_LoadROM.ShowDialog = DialogResult.OK Then
            ret = OpenRom(ofd_SM64RM_LoadROM.FileName)
        End If

        Return ret
    End Function

    Public Function OpenRom(Romfile As String) As Boolean
        Dim success As Boolean = False

        If Not loadRecentROM Then

#If Not DEBUG Then
            Try
#End If

            Dim romFileInfo As New FileInfo(Romfile)
            Dim newrommgr As New RomManager(Romfile)
            StatusText = Form_Main_Resources.Status_Checking

            If romFileInfo.Length = 8 * 1024 * 1024 Then
                If MessageBoxEx.Show(Form_Main_Resources.MsgBox_PrepaireRom, Form_Main_Resources.MsgBox_PrepaireRom_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> DialogResult.OK Then
                    Throw New RomCompatiblityException("Rom Length is incompatible!")
                End If
            End If

            If Not newrommgr.CheckROM() Then
                Throw New RomCompatiblityException("Rom Check was false!")
            ElseIf newrommgr.IsSM64EditorMode Then
                Throw New RomCompatiblityException(Form_Main_Resources.Exception_RomWasUsedBySM64E)
            End If

            loadRecentROM = True

            AddRecentFile(Settings.RecentFiles.RecentROMs, Romfile)
            MergeRecentFiles(Settings.RecentFiles.RecentROMs)
            RaiseEvent RecentFilesChanged()

            SetRomMgr(newrommgr)
            LoadROM(Romfile)

            CreateRomWatcherForCurrentRom()

            success = True

#If Not DEBUG Then
            Catch ex As RomCompatiblityException
                MessageBoxEx.Show(ex.Message, "Loading ROM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As ReadOnlyException
                MessageBoxEx.Show(ex.Message, "Loading ROM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBoxEx.Show(Form_Main_Resources.MsgBox_RomRemoved, Form_Main_Resources.MsgBox_RomRemoved_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
#End If

            loadRecentROM = False
            StatusText = String.Empty
        End If

        Return success
    End Function

    Public Sub LoadROM(Romfile As String)
        loadingROM = True
        StatusText = Form_Main_Resources.Status_LoadingRom
        RaiseEvent RomLoading()

        'Load Global Object Banks
        'rommgr.LoadGlobalObjectBank()

        'Load Levels
        romManager.LoadLevels()
        RaiseEvent RomLevelsLoaded()

        'Load Music
        StatusText = Form_Main_Resources.Status_LoadingMusic
        romManager.LoadMusic()
        RaiseEvent RomMusicLoaded()
        StatusText = String.Empty

        RaiseEvent RomLoaded()
        StatusText = String.Empty
        loadingROM = False
    End Sub

    Private Sub CreateRomWatcherForCurrentRom()
        If romManager IsNot Nothing Then
            General.RomWatcher = New FileSystemWatcher(Path.GetDirectoryName(romManager.RomFile), Path.GetFileName(romManager.RomFile)) With {.EnableRaisingEvents = True, .SynchronizingObject = mainForm}
            hasRomChanged = 0
        Else
            General.RomWatcher = Nothing
        End If
        RomWatcher = General.RomWatcher
    End Sub

    Public Sub CheckRomChanged()
        If hasRomChanged = 1 Then
            Dim e As New RomChangesAvaiableEventArgs

            RaiseEvent RomChangesAvailable(e)

            If e.Mute Then
                hasRomChanged = 2
            End If
        End If
    End Sub

    Public Sub ReloadRom()
        OpenRom(romManager.RomFile)
    End Sub

    Public Sub UpdateChecksum()
        If romManager IsNot Nothing Then
            StatusText = "Calculating checksum ..."
            PatchClass.UpdateChecksum(romManager.RomFile)
            StatusText = String.Empty
        End If
    End Sub

    Public Sub ConvertM64ToMidi()
        Dim ofd As New CommonOpenFileDialog
        Dim sfd As CommonSaveFileDialog
        Dim chunks As Byte = 2

        ofd.Filters.Add(New CommonFileDialogFilter("M64 Sequences", "*.m64"))
        ofd.EnsureFileExists = True

        If ofd.ShowDialog = CommonFileDialogResult.Ok Then
            sfd = New CommonSaveFileDialog
            sfd.Filters.Add(New CommonFileDialogFilter("MIDI File [Experimental]", "*.mid"))
            sfd.Controls.Add(GetMidiExportDialogControls)

            If sfd.ShowDialog() = CommonFileDialogResult.Ok Then
                'Get chunks
                Select Case CType(sfd.Controls("MidiChunksSelector"), CommonFileDialogComboBox).SelectedIndex
                    Case 0
                        chunks = 1
                    Case 1
                        chunks = 2
                End Select

                'Create midi file
                Dim fs As New FileStream(ofd.FileName, FileMode.Open, FileAccess.ReadWrite)

                'Convert .m64 to .midi
                Try
                    OutputMIDI.ConvertToMIDI(sfd.FileName, fs, chunks, True)
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_ConvertToMidi_Succes, Form_Main_Resources.MsgBox_ConvertToMidi_Succes_Titel, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_ConvertToMidi_Failed & vbNewLine & ex.Message, Form_Main_Resources.MsgBox_ConvertToMidi_Failed_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    fs.Close()
                End Try
            End If
        End If
    End Sub

    Public Function GetCurrentRomManager() As RomManager
        Return romManager
    End Function

    'T o o l s

    Public Sub OpenTweakViewer()
        Dim tweaks As New TweakViewer(romManager)
        tweaks.Show()
    End Sub

    Public Sub OpenModelImporter()
        Dim frm As New ModelImporterGUI.ModelImporter
        frm.RomFile = romManager?.RomFile
        frm.Show()
    End Sub

    Public Sub OpenTrajectoryEditor()
        Dim editor As New TrajectoryEditor(romManager)
        editor.ShowDialog(mainForm)
    End Sub

    Public Sub OpenRgbEditor()
        Dim editor As New RGBEditor(romManager)
        editor.Show()
    End Sub

    Public Sub OpenCoinsEditor()
        Dim frm As New Form_CoinsSettings(romManager)
        frm.Show(mainForm)
    End Sub

    Public Sub OpenAbout()
        Dim frm As New Form_About
        frm.ShowDialog()
    End Sub

    Public Sub OpenTextConverter()
        Dim frm As New Form_SM64TextConverter
        frm.Show()
    End Sub

    Public Sub OpenStyleManager()
        Form_Stylemanager.Show()
    End Sub

    Public Sub OpenSettings()
        Dim frm As New Form_Settings
        frm.ShowDialog()
    End Sub

    Public Sub OpenApplyPPFDialog()
        Dim patcher As New ApplyPPF.ApplyPPFDialog(romManager?.RomFile, String.Empty)
        patcher.ShowDialog(mainForm)
    End Sub

    Public Sub OpenItemBoxContentEditor()
        Dim ibce As ItemBoxContentEditor = GetFirstOpenForm(Of ItemBoxContentEditor)()

        If ibce Is Nothing Then
            ibce = New ItemBoxContentEditor(romManager)
        End If

        ibce.Show()
    End Sub

    Public Sub OpenStarPositionEditor()
        Dim spo As StarPositionEditor = GetFirstOpenForm(Of StarPositionEditor)()

        If spo Is Nothing Then
            spo = New StarPositionEditor(romManager)
        End If

        spo.Show()
    End Sub

    Public Sub OpenTextProfileEditor()
        If romManager IsNot Nothing Then
            romManager.LoadTextProfileIfNotLoaded()

            Dim editor As New TextProfileEditor With {
                .ProfileInfo = romManager.TextInfoProfile
            }

            editor.ShowDialog()

            If editor.HasSaved Then
                romManager.ClearTextGroups()
                SendRequestReloadTextManagerLists()
            End If
        End If
    End Sub

    Private Sub OpenScriptDumper(Of TCmd, eTypes)(script As BaseCommandCollection(Of TCmd, eTypes))
        Dim frm As New ScriptDumper(Of TCmd, eTypes)
        frm.Script = script
        frm.Show()
    End Sub

    Private Sub OpenCustomBankManager(customBank As CustomObjectBank)
        Dim mgr As New CustomBankManager(romManager, customBank)
        mgr.Show()
    End Sub

    Private Function OpenLevelSelectDialog() As LevelInfoDataTabelList.Level
        Dim frm As New LevelSelectorDialog(romManager)

        If frm.ShowDialog = DialogResult.OK Then
            Return frm.SelectedLevel
        Else
            Return Nothing
        End If
    End Function

    'R o m   W a t c h e r

    Private Sub RomWatcher_Changed(sender As Object, e As FileSystemEventArgs) Handles RomWatcher.Changed
        If romManager IsNot Nothing AndAlso romManager.RomFile = e.FullPath AndAlso hasRomChanged <> 2 Then
            hasRomChanged = 1
            RaiseEvent RomFileChanged()
        End If
    End Sub

    Private Sub RomWatcher_Renamed(sender As Object, e As RenamedEventArgs) Handles RomWatcher.Renamed
        If romManager IsNot Nothing AndAlso e.OldFullPath = romManager.RomFile Then
            romManager.RomFile = e.FullPath
            RaiseEvent RomFileRenamed()
        End If
    End Sub

    Private Sub RomWatcher_Deleted(sender As Object, e As FileSystemEventArgs) Handles RomWatcher.Deleted
        If romManager IsNot Nothing AndAlso e.FullPath = romManager.RomFile Then
            RaiseEvent RomFileDeleted()
        End If
    End Sub

    'G e n e r a l

    Public Sub SetGameName(name As String)
        name = name.Trim
        romManager.GameName = name
    End Sub

    Public Function GetGameNAme() As String
        Return romManager.GameName
    End Function

    Public Function GetRomFileSize() As Double
        Return New FileInfo(romManager.RomFile).Length / 1024 / 1024
    End Function

    Public Function IsChangingTab()
        Dim e As New EnabledEventArgs(False)
        RaiseEvent RequestIsChangingTab(e)
        Return e.Enabled
    End Function

    'L e v e l   M a n a g e r

    Private Function GetLevelAndArea(levelIndex As Integer, Optional areaIndex As Integer = -1) As (level As Level, area As LevelArea)
        Dim lvl As Level = romManager.Levels.ElementAtOrDefault(levelIndex)
        Dim area As LevelArea = lvl?.Areas?.ElementAtOrDefault(areaIndex)
        Return (lvl, area)
    End Function

    Private ReadOnly Property OpenAreaEditors As IEnumerable(Of Form_AreaEditor)
        Get
            Dim list As New List(Of Form_AreaEditor)

            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is Form_AreaEditor Then
                    list.Add(frm)
                End If
            Next

            Return list
        End Get
    End Property

    Private Function GetAreaEditor(level As Level)
        Return OpenAreaEditors.FirstOrDefault(Function(n) n.cLevel Is level)
    End Function

    Public Sub OpenAreaEditor(levelIndex As Integer, areaIndex As Integer)
        If levelIndex >= 0 Then
            Dim curLvl As Level = romManager.Levels(levelIndex)
            Dim openAreaEditor As Form_AreaEditor = GetAreaEditor(curLvl)

            If openAreaEditor Is Nothing Then
                Dim curArea As LevelArea = curLvl.Areas.ElementAtOrDefault(areaIndex)
                Dim frm As New Form_AreaEditor(romManager, curLvl, curLvl.LevelID, curArea?.AreaID)
                frm.Show()
            Else
                openAreaEditor.BringToFront()
            End If
        End If
    End Sub

    Public Sub SetUpLevelDefaultStartPosition(levelIndex As Integer)
        Dim ShowX As Boolean = False
        Dim ShowY As Boolean = False
        Dim ShowZ As Boolean = False
        Dim XVal As Integer = 0
        Dim YVal As Integer = 0
        Dim ZVal As Integer = 0
        Dim Title As String = ""
        Dim dsp = romManager.Levels(levelIndex).GetDefaultPositionCmd

        If dsp IsNot Nothing Then
            'Edit all values
            ShowX = True : ShowY = True : ShowZ = True

            'Show current values (get from command)
            Dim curPos As Vector3 = clDefaultPosition.GetPosition(dsp)
            With curPos
                XVal = .X
                YVal = .Y
                ZVal = .Z
            End With

            'Set Titel
            Title = Form_Main_Resources.Text_StartPosition

            'Open Dialog
            Dim frm As New Form_SetUpPoint(Title, ShowX, ShowY, ShowZ, XVal, YVal, ZVal)
            If frm.ShowDialog() = DialogResult.OK Then
                'Get new values
                XVal = ValueFromText(frm.IntegerInput_X.Value)
                YVal = ValueFromText(frm.IntegerInput_Y.Value)
                ZVal = ValueFromText(frm.IntegerInput_Z.Value)

                'Set new values
                With curPos
                    .X = XVal
                    .Y = YVal
                    .Z = ZVal
                End With

                'Set new values to command
                clDefaultPosition.SetPosition(dsp, curPos)
            End If
        End If
    End Sub

    Public Sub AddLevelAreaSpecialItem(levelIndex As Integer, areaIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        Dim sb As New SpecialBox

        Dim method =
            Sub()
                lvl.area.SpecialBoxes.Add(sb)
                RaiseEvent LevelSpecialItemAdded(New SpecialItemEventArgs(lvl.area.SpecialBoxes.IndexOf(sb), levelIndex, areaIndex))
            End Sub

        AddEditLevelAreaSpecialItem(sb, method)
    End Sub

    Public Sub EditLevelAreaSpecialItem(levelIndex As Integer, areaIndex As Integer, sbIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        Dim sb As SpecialBox = lvl.area.SpecialBoxes(sbIndex)

        Dim method =
            Sub()
                RaiseEvent LevelSpecialItemChanged(New SpecialItemEventArgs(sbIndex, levelIndex, areaIndex))
            End Sub

        AddEditLevelAreaSpecialItem(sb, method)
    End Sub

    Private Sub AddEditLevelAreaSpecialItem(sb As SpecialBox, finishMethod As Action)
        Dim frm As New Form_AddSpecialItem(sb)

        'Set what happens after the form has close
        AddHandler frm.FormClosed,
            Sub()
                Dim newType As SpecialBoxType

                If frm.DialogResult = DialogResult.OK Then
                    Select Case True
                        Case frm.CheckBoxX_Water.Checked
                            newType = SpecialBoxType.Water
                        Case frm.CheckBoxX_Mist.Checked
                            newType = SpecialBoxType.Mist
                        Case frm.CheckBoxX_ToxicHaze.Checked
                            newType = SpecialBoxType.ToxicHaze
                    End Select

                    'Reorder Positions in BoxData
                    ReorderBoxDataPositions(sb)

                    'Define new Type for SpecialBox
                    sb.Type = newType

                    'Invoke finish method
                    finishMethod()
                End If
            End Sub

        'Show the Form
        frm.Show()
    End Sub

    Public Function GetSpecialBoxInfos(levelIndex As Integer, areaIndex As Integer, sbIndex As Integer) As (boxType As SpecialBoxType, waterType As WaterType, x1 As Short, z1 As Short, x2 As Short, z2 As Short, y As Short, scale As Short, alpha As Byte, invisibleWater As Boolean)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        Dim sb As SpecialBox = lvl.area.SpecialBoxes(sbIndex)

        Return (sb.Type, sb.WaterType, sb.X1, sb.Z1, sb.X2, sb.Z2, sb.Y, sb.Scale, sb.Alpha, sb.InvisibleWater)
    End Function

    Public Sub LoadObjectBankData()
        Dim temp_1 As String = Path.Combine(MyDataPath, "Other\Object Bank Data\Bank 0x{0}.txt")

        ObjectBankData.Clear()

        For Each t As String In {"B", "C", "D", "9"}
            ObjectBankData.Add(FileIniParser.ReadFile(String.Format(temp_1, t)))
        Next
    End Sub

    Public Function GetLevelsCount() As Integer
        Return romManager.Levels.Count
    End Function

    Public Function GetUsedLevelIDs() As IEnumerable(Of UShort)
        Return romManager.Levels.Select(Function(n) n.LevelID)
    End Function

    Public Function GetLevelName(levelID As UShort) As String
        Return romManager.LevelInfoData.FirstOrDefault(Function(n) n.ID = levelID).Name
    End Function

    Public Function GetUsedLevelAreaIDs(levelIndex As UShort) As Byte()
        Return romManager.Levels.ElementAtOrDefault(levelIndex)?.Areas?.Select(Function(n) n.AreaID).ToArray
    End Function

    Public Sub AddNewLevel()
        Dim selLvl As LevelInfoDataTabelList.Level = OpenLevelSelectDialog()

        If selLvl IsNot Nothing Then
            Dim lvl As Level = romManager.AddLevel(selLvl.ID)
            romManager.Levels.Last.ActSelector = selLvl.Type = LevelInfoDataTabelList.LevelTypes.Level

            RaiseEvent LevelAdded(New LevelEventArgs(romManager.Levels.IndexOf(lvl), lvl.LevelID))
        End If
    End Sub

    Public Sub AddNewArea(levelIndex As Integer)
        Dim ReamingIDs As New List(Of Byte) From {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H0}
        Dim curLevel As Level = GetLevelAndArea(levelIndex, -1).level

        'Check for left area IDs
        For Each a As LevelArea In curLevel.Areas
            ReamingIDs.Remove(a.AreaID)
        Next

        'Convert a model
        If ReamingIDs.Count > 0 Then
            Dim frm As New MainModelConverter
            frm.CheckBoxX_ConvertCollision.Enabled = False
            frm.CheckBoxX_ConvertModel.Enabled = False

            If frm.ShowDialog = DialogResult.OK Then
                'Create new area
                Dim tArea As New LevelArea(ReamingIDs(0))
                tArea.AreaModel = frm.ResModel
                tArea.ScrollingTextures.AddRange(frm.ResModel.Fast3DBuffer.ConvertResult.ScrollingCommands.ToArray)

                'Add area to level
                curLevel.Areas.Add(tArea)

                RaiseEvent LevelAreaAdded(New LevelAreaEventArgs(levelIndex, curLevel.Areas.IndexOf(tArea), tArea.AreaID))
            End If
        Else
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_MaxCountAreasReached, Form_Main_Resources.MsgBox_MaxCountAreasReached_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Public Function GetLevelAreasCount(levelIndex As Integer) As Byte
        Return GetLevelAndArea(levelIndex, -1).level.Areas.Count
    End Function

    Public Sub RemoveLevelArea(levelIndex As Integer, areaIndex As Integer)
        If levelIndex >= 0 AndAlso areaIndex >= 0 Then
            If MessageBoxEx.Show("You are going to remove the selected area. Continue?", "Remove Area", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim lvl = GetLevelAndArea(levelIndex, areaIndex)

                lvl.level.Areas.RemoveAt(areaIndex)

                RaiseEvent LevelAreaRemoved(New LevelAreaEventArgs(levelIndex, areaIndex, lvl.area.AreaID))
            End If
        End If
    End Sub

    Private Function GetLengthOfLevelAreas(level As Level, Optional ExcaptIndex As Integer = -1) As Long
        Dim val As Integer = 0
        Dim tIndex As Integer = 0

        For Each a As LevelArea In level.Areas
            If tIndex <> ExcaptIndex Then
                val += a.AreaModel.Length
                tIndex += 1
            End If
        Next

        Return val
    End Function

    Public Sub SetLevelSettings(levelIndex As Integer, defStartPosDestAreaID As Byte, defStartPosDestRotation As Short, enableActSelector As Boolean, enableHardcodedCamera As Boolean, objBank0x0C As ObjectBank0x0C, objBank0x0D As ObjectBank0x0D, objBank0x0E As ObjectBank0x0E, enableShowMsg As Boolean, showMsgDialogID As Byte)
        Dim lvl As Level = GetLevelAndArea(levelIndex, -1).level

        'Default Start Position
        clDefaultPosition.SetAreaID(lvl.GetDefaultPositionCmd, defStartPosDestAreaID)
        clDefaultPosition.SetRotation(lvl.GetDefaultPositionCmd, defStartPosDestRotation)

        'Act Selector
        lvl.ActSelector = enableActSelector

        'Hardcoded Camera
        lvl.HardcodedCameraSettings = enableHardcodedCamera

        'Object Banks
        lvl.ChangeObjectBank(objBank0x0C)
        lvl.ChangeObjectBank(objBank0x0D)
        lvl.ChangeObjectBank(objBank0x0E)
    End Sub

    Public Sub SetLevelBackgroundMode(levelIndex As Integer, mode As Integer)
        Dim lvl As Level = GetLevelAndArea(levelIndex, -1).level
        Dim image As Image = Nothing

        Select Case mode
            Case 0 ' Game Image
                lvl.Background.Enabled = True
                lvl.Background.IsCustom = False
            Case 1 'Custom Image
                lvl.Background.Enabled = True
                lvl.Background.IsCustom = True
                image = lvl.Background.GetImage
            Case 2 'Disable
                lvl.Background.Enabled = False
                lvl.Background.IsCustom = False
        End Select
    End Sub

    Public Sub SetLevelBackgroundID(levelIndex As Integer, id As BackgroundIDs)
        Dim lvl As Level = GetLevelAndArea(levelIndex, -1).level
        lvl.Background.ID = id
        lvl.Background.Enabled = True
        lvl.Background.IsCustom = False
    End Sub

    Public Sub SetLevelAreaBackgroundType(levelIndex As Integer, areaIndex As Integer, typ As AreaBGs)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        lvl.area.Background.Type = typ
        RaiseEvent LevelAreaBackgroundModeChanged(New LevelAreaBackgroundModeChangedEventArgs(typ, lvl.area.Background.Color))
    End Sub

    Public Sub SetLevelAreaBackgroundColor(levelIndex As Integer, areaIndex As Integer, color As Color)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        lvl.area.Background.Type = AreaBGs.Color
        lvl.area.Background.Color = color
    End Sub

    Public Function GetLevelAreaBackgroundInfo(levelIndex As Integer, areaIndex As Integer) As (typ As AreaBGs, color As Color)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        Return (lvl.area.Background.Type, lvl.area.Background.Color)
    End Function

    Public Sub LoadLevelCustomBackgroundImage(levelIndex As Integer)
        Dim bg As LevelBG = GetLevelAndArea(levelIndex, -1).level.Background

        Dim ofd As New OpenFileDialog
        ofd.Filter = "All supported Image files|*.png;*.jpeg;*.jpg;*.bmp;*.gif"

        If ofd.ShowDialog = DialogResult.OK Then
            Dim sImg As Stream = New MemoryStream(File.ReadAllBytes(ofd.FileName))
            Dim tBGImage As New Bitmap(sImg)

            If tBGImage.Size <> New Size(248, 248) And tBGImage.Size <> New Size(256, 256) Then
                MessageBoxEx.Show(Form_Main_Resources.MsgBox_InvalidBgImageSize, Form_Main_Resources.MsgBox_InvalidBgImageSize_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                bg.SetImage(tBGImage)
                bg.ID = BackgroundIDs.Desert
                bg.IsCustom = True
                bg.Enabled = True

                RaiseEvent LevelBackgroundImageChanged(New LevelBackgroundImageChangedEventArgs(bg.ID, bg.GetImage))
            End If

            sImg.Close()
        End If
    End Sub

    Public Sub SaveLevelAreaSettings(levelIndex As Integer, areaIndex As Integer, terrainTypes As TerrainTypes, musicID As Byte, environmentEffects As EnvironmentEffects, cameraPrset As CameraPresets, enable2DCamera As Boolean, enableShowMsg As Boolean, showMsgDialogID As Byte)
        Dim area As LevelArea = GetLevelAndArea(levelIndex, areaIndex).area
        area.TerrainType = terrainTypes
        area.BGMusic = musicID
        area.Geolayout.EnvironmentEffect = environmentEffects
        area.Geolayout.CameraPreset = cameraPrset
        area.Enable2DCamera = enable2DCamera
        area.ShowMessage.Enabled = enableShowMsg
        area.ShowMessage.DialogID = showMsgDialogID
    End Sub

    Public Sub ImportLevelAreaModel(levelIndex As Integer, areaIndex As Integer, importVisualMap As Boolean, importCollision As Boolean)
        Dim area As LevelArea = GetLevelAndArea(levelIndex, areaIndex).area

        Dim frm As New MainModelConverter
        frm.CheckBoxX_ConvertModel.Checked = importVisualMap
        frm.CheckBoxX_ConvertCollision.Checked = importCollision

        If frm.ShowDialog = DialogResult.OK Then
            If frm.CheckBoxX_ConvertCollision.Checked AndAlso frm.CheckBoxX_ConvertModel.Checked Then
                Dim OldAreaModel As ObjectModel = area.AreaModel
                area.AreaModel = frm.ResModel
            ElseIf frm.CheckBoxX_ConvertCollision.Checked Then
                Dim OldAreaModel As ObjectModel = area.AreaModel
                area.AreaModel.Collision = frm.ResModel.Collision
            ElseIf frm.CheckBoxX_ConvertModel.Checked Then
                Dim OldAreaModel As ObjectModel = area.AreaModel
                area.AreaModel = frm.ResModel
                area.AreaModel.Collision = OldAreaModel.Collision
            End If

            If frm.CheckBoxX_ConvertModel.Checked Then
                area.ScrollingTextures.Clear()
                area.ScrollingTextures.AddRange(area.AreaModel.Fast3DBuffer.ConvertResult.ScrollingCommands.ToArray)
            End If

            area.SetSegmentedBanks(romManager)
        End If
    End Sub

    Public Function GetSpecialBoxesCount(levelIndex As Integer, areaIndex As Integer) As Integer
        Dim area As LevelArea = GetLevelAndArea(levelIndex, areaIndex).area
        Return area.SpecialBoxes.Count
    End Function

    Public Sub RemoveLevelSpecialBox(levelIndex As Integer, areaIndex As Integer, sbIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        lvl.area.SpecialBoxes.RemoveAt(sbIndex)
        RaiseEvent LevelSpecialItemRemoved(New SpecialItemEventArgs(sbIndex, levelIndex, areaIndex))
    End Sub

    Public Function DoesCameraPresetProvide2DCamera(preset As CameraPresets) As Boolean
        Return preset = &HE
    End Function

    Public Sub CopyLevelLastRomOffset(levelIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex)
        Clipboard.SetText(lvl.level.LastRomOffset.ToString("X8"))
    End Sub

    Public Sub OpenScrollingTextureEditor(levelIndex As Integer, areaIndex As Integer)
        If levelIndex > -1 AndAlso areaIndex > -1 Then
            Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
            Dim editor As New ScrollTexEditor(lvl.area)
            editor.Show()
        End If
    End Sub

    Public Sub OpenScriptDumperWithLevelscript(levelIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex)
        If lvl.level IsNot Nothing Then
            OpenScriptDumper(lvl.level.Levelscript)
        End If
    End Sub

    Public Sub OpenScriptDumperWithLevelAreaScript(levelIndex As Integer, areaIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        If lvl.area IsNot Nothing Then
            OpenScriptDumper(lvl.area.Levelscript)
        End If
    End Sub

    Public Sub OpenScriptDumperWithLevelAreaGeolayoutScript(levelIndex As Integer, areaIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)
        If lvl.area IsNot Nothing Then
            OpenScriptDumper(lvl.area.Geolayout.Geolayoutscript)
        End If
    End Sub

    Public Function HasLevelBank0x19(levelIndex As Integer) As Boolean
        Dim lvl = GetLevelAndArea(levelIndex)
        Return lvl.level?.Bank0x19 IsNot Nothing
    End Function

    Public Sub OpenCustomBankManager(levelIndex As Integer, areaIndex As Integer)
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)

        If lvl.area IsNot Nothing Then
            OpenCustomBankManager(lvl.area.CustomObjects)
        End If
    End Sub

    Public Async Function ExportLevelVisualMap(levelIndex As Integer, areaIndex As Integer) As Task
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)

        If lvl.area IsNot Nothing Then
            StatusText = Form_Main_Resources.Status_LoadingModel
            Dim mdl As Object3D = Await LoadAreaVisualMapAsObject3DAsync(romManager, lvl.area)

            ExportLevelModel(levelIndex, areaIndex, mdl)
        End If
    End Function

    Public Async Function ExportLevelCollision(levelIndex As Integer, areaIndex As Integer) As Task
        Dim lvl = GetLevelAndArea(levelIndex, areaIndex)

        If lvl.area IsNot Nothing Then
            StatusText = Form_Main_Resources.Status_LoadingModel
            Dim mdl As Object3D = Await lvl.area.AreaModel.Collision.ToObject3DAsync

            ExportLevelModel(levelIndex, areaIndex, mdl)
        End If
    End Function

    Private Sub ExportLevelModel(levelIndex As Integer, areaIndex As Integer, mdl As Object3D)
        StatusText = Form_Main_Resources.Status_ExportingModel
        ExportModel(mdl, GetExporterModuleFromID(Settings.FileParser.FileExporterModule))
        StatusText = String.Empty
    End Sub

    Public Function GetLevelAreaSettings(levelIndex As Integer, areaIndex As Integer) As (terrainType As TerrainTypes, bgMusic As Byte, camPreset As CameraPresets, envEffect As EnvironmentEffects, enable2DCam As Boolean, bgType As AreaBGs, bgColor As Color, enableShowMsg As Boolean, showMsgDialogID As Byte)
        Dim area As LevelArea = GetLevelAndArea(levelIndex, areaIndex).area

        'Set Area Segmented Banks
        area.SetSegmentedBanks(romManager)

        'Get Area Settings
        Return (area.TerrainType, area.BGMusic, area.Geolayout.CameraPreset, area.Geolayout.EnvironmentEffect, area.Enable2DCamera, area.Background.Type, area.Background.Color, area.ShowMessage.Enabled, area.ShowMessage.DialogID)
    End Function

    Public Sub RemoveLevel(levelIndex As Integer)
        If MessageBoxEx.Show("You are going to remove the selected level. Continue?", "Remove Area", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim infos = GetLevelAndArea(levelIndex)
            If infos.level IsNot Nothing Then
                romManager.RemoveLevel(infos.level)
                RaiseEvent LevelRemoved(New LevelEventArgs(levelIndex, infos.level.LevelID))
            End If
        End If
    End Sub

    Public Function GetLevelSettings(levelIndex As Integer) As (objBank0x0C As ObjectBank0x0C, objBank0x0D As ObjectBank0x0D, objBank0x0E As ObjectBank0x0E, enableActSelector As Boolean, enableHardcodedCamera As Boolean, hasDefStartPos As Boolean, defStartPosAreaID As Byte, defStartPosYRot As Short, bgMode As Integer, bgImage As Image, bgOriginal As BackgroundIDs, areasCount As Byte)
        Dim lvl As Level = GetLevelAndArea(levelIndex).level
        Dim defPosCmd As LevelscriptCommand = lvl.GetDefaultPositionCmd
        Dim bgMode As Byte
        Dim bgImage As Image = Nothing
        Dim bgOriginal As BackgroundIDs
        Dim defPosAreaID As Byte
        Dim defPosYRot As Short

        lvl.SetSegmentedBanks(romManager)

        If Not lvl.Background.Enabled Then
            bgMode = 2
            bgOriginal = lvl.Background.ID
        ElseIf lvl.Background.IsCustom Then
            bgMode = 1
            bgImage = lvl.Background.GetImage
        Else
            bgMode = 0
        End If
        bgOriginal = lvl.Background.ID

        If defPosCmd IsNot Nothing Then
            defPosAreaID = clDefaultPosition.GetAreaID(defPosCmd)
            defPosYRot = clDefaultPosition.GetRotation(defPosCmd)
        End If

        Return (lvl.ObjectBank0x0C, lvl.ObjectBank0x0D, lvl.ObjectBank0x0E, lvl.ActSelector, lvl.HardcodedCameraSettings, defPosCmd IsNot Nothing, defPosAreaID, defPosYRot, bgMode, bgImage, bgOriginal, lvl.Areas.Count)
    End Function

    Public Sub ChangeLevelID(levelIndex As Integer)
        Dim lvl As Level = GetLevelAndArea(levelIndex).level

        If lvl IsNot Nothing Then
            Dim selLevel As LevelInfoDataTabelList.Level = OpenLevelSelectDialog()
            romManager.ChangeLevelID(lvl, selLevel.ID, selLevel.Type)
        End If

        RaiseEvent LevelIDChanged(New LevelEventArgs(levelIndex, lvl.LevelID))
    End Sub

    Public Sub ImportLevel()
        Dim ofd As New OpenFileDialog With {.Filter = "SM64 ROMs (*.z64)|*.z64"}
        If ofd.ShowDialog = DialogResult.OK Then
            Dim frm As New ImportLevelDialog(romManager)
            If frm.LoadROM(ofd.FileName) Then
                If frm.ShowDialog = DialogResult.OK Then
                    Dim lvl As Level = romManager.Levels.Last
                    RaiseEvent LevelAdded(New LevelEventArgs(romManager.Levels.IndexOf(lvl), lvl.LevelID))
                End If
            End If
        End If
    End Sub

    Public Sub SetLevelBank0x19Length(levelIndex As Integer)
        Dim lvl As Level = GetLevelAndArea(levelIndex).level

        If lvl IsNot Nothing Then
            Dim frm As New ValueInputDialog
            frm.InfoLabel.Text = Form_Main_Resources.Text_NewLength & ":"
            frm.ValueTextBox.Text = TextFromValue(lvl.Bank0x19.Length)

            Dim [continue] As Boolean = True
            Dim minSize As UInteger = RomManagerSettings.DefaultLevelscriptSize

            Do While [continue]
                If frm.ShowDialog = DialogResult.OK Then
                    Dim newVal As Integer = ValueFromText(frm.ValueTextBox.Text)
                    If newVal < minSize Then
                        MessageBoxEx.Show(String.Format(Form_Main_Resources.MsgBox_InvalidBankSize, minSize.ToString("X")), Form_Main_Resources.MsgBox_InvalidBankSize_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        lvl.Bank0x19.Length = newVal
                        MessageBoxEx.Show(Form_Main_Resources.MsgBox_BankSizeChangedSuccess, Form_Main_Resources.MsgBox_BankSizeChangedSuccess_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        [continue] = False
                    End If
                Else
                    [continue] = False
                End If
            Loop
        End If
    End Sub

    'T e x t   M a n a g e r

    Private Function GetTextGroup(name As String) As TextGroup
        Return romManager?.TextGroups?.FirstOrDefault(Function(n) n.TextGroupInfo.Name = name)
    End Function

    Public Sub SendRequestReloadTextManagerLists()
        RaiseEvent RequestReloadTextManagerLists()
    End Sub

    Public Sub SendRequestReloadTextManagerLineColors()
        RaiseEvent RequestReloadTextManagerLineColors()
    End Sub

    Public Function IsTextOverLimit() As Boolean
        If romManager IsNot Nothing Then
            For itbl As Integer = 0 To romManager.TextGroups.Length - 1
                Dim tbl As TextGroup = romManager.TextGroups(itbl)

                If TypeOf tbl Is TextTableGroup Then
                    If CalcTextSpaceBytesCount(tbl.TextGroupInfo.Name, Nothing).percent > 1 Then
                        Return True
                    End If
                ElseIf TypeOf tbl Is TextArrayGroup Then
                    For iItem = 0 To CType(tbl, TextArrayGroup).Count - 1
                        If CalcTextSpaceBytesCount(tbl.TextGroupInfo.Name, iItem).percent > 1 Then
                            Return True
                        End If
                    Next
                End If
            Next
        End If

        Return False
    End Function

    Public Function CalcTextSpaceBytesCount(tableName As String, itemIndex As Integer) As (used As Integer, max As Integer, left As Integer, percent As Single)
        If Not String.IsNullOrEmpty(tableName) Then
            Dim curTable As TextGroup = romManager.LoadTextGroup(tableName)
            Dim curTextItem As TextItem = curTable.ElementAtOrDefault(itemIndex)

            Dim max As Integer = 0
            Dim used As Integer = 0
            Dim percent As Single
            Dim left As Integer

            If TypeOf curTable Is TextTableGroup Then
                Dim curGroupCast As TextTableGroup = curTable
                max = curGroupCast.TextGroupInfo.Data.DataMaxSize
                used = curGroupCast.DataLength
            ElseIf TypeOf curTable Is TextArrayGroup Then
                Dim curTextItemCast As TextArrayItem = curTextItem
                max = curTextItemCast.ItemInfo.MaxLength
                used = curTextItemCast.Data.Length
            End If

            If max > 0 Then
                percent = used / max
                left = max - used
            Else
                percent = 0
                left = max
            End If

            Return (used, max, left, percent)
        End If
    End Function

    Public Function GetTextGroupInfosCount() As Integer
        Return romManager.GetTextGroupInfos.Length
    End Function

    Public Function GetTextGroupInfoNames() As String()
        Return romManager.GetTextGroupInfos.Select(Function(n) n.Name).ToArray
    End Function

    Public Function GetTextGroupInfos(tableName As String) As (name As String, encoding As String, isDialogGroup As Boolean, isTableGroup As Boolean, isArrayGroup As Boolean)
        Dim info As TextGroupInfo = romManager.GetTextGroupInfos.FirstOrDefault(Function(n) n.Name = tableName)
        If info IsNot Nothing Then
            Dim isTable As Boolean = TypeOf info Is TextTableGroupInfo
            Dim isArray As Boolean = TypeOf info Is TextArrayGroupInfo
            Dim isDialog As Boolean = isTable AndAlso CType(info, TextTableGroupInfo).TableType = TextTableType.Dialogs
            Return (info.Name, info.EncodingString, isDialog, isTable, isArray)
        Else
            Return Nothing
        End If
    End Function

    Public Sub LoadTextGroup(tableName As String)
        romManager.LoadTextGroup(tableName)
    End Sub

    Public Function GetTextGroupEntriesCount(tableName As String) As Integer
        Return romManager.LoadTextGroup(tableName)?.Count
    End Function

    Public Function GetTextItemInfos(tableName As String, itemIndex As Integer) As (text As String, horizontalPosition As DialogHorizontalPosition, verticalPosition As DialogVerticalPosition, linesPerSite As Integer)
        Dim item As TextItem = romManager.LoadTextGroup(tableName)?.ElementAtOrDefault(itemIndex)
        Dim hPos As DialogHorizontalPosition = Nothing
        Dim vPos As DialogVerticalPosition = Nothing
        Dim lines As Integer = Nothing

        If TypeOf item Is TextTableDialogItem Then
            Dim dialogItem As TextTableDialogItem = item
            hPos = dialogItem.HorizontalPosition
            vPos = dialogItem.VerticalPosition
            lines = dialogItem.LinesPerSite
        ElseIf TypeOf item Is TextTableItem Then
        ElseIf TypeOf item Is TextArrayItem Then
        End If

        Return (item.Text, hPos, vPos, lines)
    End Function

    Public Function GetTextNameList(tableName As String) As String()
        Dim nameList() As String = {}

        Select Case tableName
            Case "Dialogs"
                nameList = CreateDialogNameList()
            Case "Levels"
                nameList = CreateLevelNameList()
            Case "Acts"
                nameList = CreateActNameList()
        End Select

        Return nameList
    End Function

    Private Function CreateLevelNameList() As String()
        Dim list As New List(Of String)

        For lvlnumber As Integer = 1 To 26
            Dim item As String = ""

            Select Case lvlnumber
                Case Is <= 15
                    Dim lvltxt As String = lvlnumber
                    Dim name As String = romManager.LevelInfoData.FirstOrDefault(Function(n) n.Number = lvltxt)?.Name
                    item = String.Format("Level {0}{1}", lvlnumber.ToString("00"), If(name IsNot Nothing, ": " & lvltxt, ""))
                Case 16
                    item = String.Format("Bowser 1")
                Case 17 : item = String.Format("Bowser 2")
                Case 18 : item = String.Format("Bowser 3")
                Case 19
                    item = String.Format("Princess's Secret Slide")
                Case 20 : item = String.Format("Metal Cap")
                Case 21 : item = String.Format("Wing Cap")
                Case 22 : item = String.Format("Vanish Cap")
                Case 23 : item = String.Format("Rainbow Secret Level")
                Case 24 : item = String.Format("Secret Aquarium")
                Case 25
                    item = String.Format("Unkown")
                Case 26 : item = String.Format("Secret Stars")
            End Select

            list.Add(item)
        Next

        Return list.ToArray
    End Function

    Private Function CreateActNameList() As String()
        Dim list As New List(Of String)

        For level As Integer = 1 To 17
            For act As Integer = 1 To 6
                Dim item As String = ""

                Select Case level
                    Case 16
                        item = String.Format(Form_Main_Resources.Text_SecretStar)
                        act = 6
                    Case 17
                        item = String.Format(Form_Main_Resources.Text_Unknown)
                    Case Else
                        item = String.Format(Form_Main_Resources.Text_LevelStar, level.ToString("00"), act)
                End Select

                list.Add(item)
            Next
        Next

        Return list.ToArray
    End Function

    Private Function CreateDialogNameList() As String()
        Dim list() As String = {}

        Dim file_dialogs As String = DialogNamesFilePath
        If File.Exists(file_dialogs) Then
            list = File.ReadAllLines(file_dialogs)
        End If

        For i As Integer = 0 To list.Length - 1
            list(i) = list(i).Substring(6)
        Next

        Return list
    End Function

    Public Sub SetTextItemText(tableName As String, tableIndex As Integer, text As String)
        Dim group As TextGroup = GetTextGroup(tableName)
        Dim item As TextItem = group(tableIndex)

        item.Text = text.TrimEnd

        group.NeedToSave = True

        RaiseEvent TextItemChanged(New TextItemEventArgs(tableName, tableIndex))
    End Sub

    Public Sub SetTextItemDialogData(tableName As String, tableIndex As Integer, vPos As DialogVerticalPosition, hPos As DialogHorizontalPosition, linesPerSite As Integer)
        Dim group As TextGroup = GetTextGroup(tableName)
        Dim item As TextTableDialogItem = group(tableIndex)

        item.VerticalPosition = vPos
        item.HorizontalPosition = hPos
        item.LinesPerSite = linesPerSite

        group.NeedToSave = True

        RaiseEvent TextItemChanged(New TextItemEventArgs(tableIndex, tableIndex))
    End Sub

    Public Sub AddNewTextTableItem(tableName As String)
        Dim group As TextGroup = GetTextGroup(tableName)

        If TypeOf group Is TextTableGroup Then
            Dim item As TextItem = Nothing

            If CType(group, TextTableGroup).TextGroupInfo.TableType = TextTableType.Dialogs Then
                item = New TextTableDialogItem({}, group.TextGroupInfo)
            Else
                item = New TextTableItem({}, group.TextGroupInfo)
            End If

            group.Add(item)

            RaiseEvent TextItemAdded(New TextItemEventArgs(tableName, group.Count - 1))
        End If
    End Sub

    Public Sub RemoveTextTableItem(tableName As String, tableIndex As Integer)
        Dim group As TextGroup = GetTextGroup(tableName)

        group.RemoveAt(tableIndex)

        RaiseEvent TextItemRemoved(New TextItemEventArgs(tableName, tableIndex))
    End Sub

    'M u s i c   M a n a g e r

    Private Function OpenFileDialog_SelectMusicSequenceFile() As (fileName As String, filterIndex As Integer, hasExitedWithOK As Boolean)
        Dim ofd As New OpenFileDialog With {.Filter = "M64 Sequence (*.m64)|*.m64"}
        Dim isOK As DialogResult = ofd.ShowDialog = DialogResult.OK
        Return (ofd.FileName, ofd.FilterIndex, isOK)
    End Function

    Public Sub ExtractMusicSequence(index As Integer)
        Dim curMusic As MusicSequence = GetMusicSequenceByIndex(index)
        Dim sfd As New CommonSaveFileDialog

        sfd.Filters.Add(New CommonFileDialogFilter("M64 Sequence", ".m64"))
        sfd.Filters.Add(New CommonFileDialogFilter("MIDI File", ".mid"))
        sfd.DefaultFileName = curMusic.Name
        sfd.Controls.Add(GetMidiExportDialogControls)

        AddHandler sfd.FileTypeChanged,
            Sub(sender As Object, e As EventArgs)
                Dim dialog As CommonSaveFileDialog = sender
                Dim filterIndex As Integer = dialog.SelectedFileTypeIndex
                Dim c As CommonFileDialogControl = dialog.Controls("MidiChunksSelector")
                c.Visible = filterIndex = 2
                dialog.DefaultExtension = dialog.Filters(dialog.SelectedFileTypeIndex - 1).Extensions.First
            End Sub

        If sfd.ShowDialog = DialogResult.OK Then
            StatusText = Form_Main_Resources.Status_ExportingSequence

            Select Case sfd.SelectedFileTypeIndex
                Case 1 '.m64

                    Try
                        Dim fs As New FileStream(sfd.FileName, FileMode.Create, FileAccess.Write)
                        fs.Write(curMusic.BinaryData, 0, curMusic.BinaryData.Length)
                        fs.Close()
                    Catch ex As Exception
                        MessageBoxEx.Show(Form_Main_Resources.MsgBox_ErrorSavingSequence, Global_Resources.Text_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Case 2 '.midi
                    Dim chunks As Byte = 2
                    Select Case CType(sfd.Controls("MidiChunksSelector"), CommonFileDialogComboBox).SelectedIndex
                        Case 0
                            chunks = 1
                        Case 1
                            chunks = 2
                    End Select

                    'Create input stream
                    Dim ms As New MemoryStream(curMusic.BinaryData)
                    ms.Position = 0

                    'Convert .m64 to .midi
                    Try
                        OutputMIDI.ConvertToMIDI(sfd.FileName, ms, chunks, True)
                    Catch ex As Exception
                        MessageBoxEx.Show(Form_Main_Resources.MsgBox_ExportToMidi_Failed & vbNewLine & ex.Message, Form_Main_Resources.MsgBox_ExportToMidi_Failed_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        ms.Close()
                    End Try

            End Select

            StatusText = ""
        End If
    End Sub

    Public Sub ReplaceMusicSequence(index As Integer)
        Dim res = OpenFileDialog_SelectMusicSequenceFile()

        If res.hasExitedWithOK Then
            StatusText = Form_Main_Resources.Status_ImportingSequence
            Dim curMusic As MusicSequence = romManager.MusicList(index)

            ImportMusicFileToSequence(curMusic, res.fileName, res.filterIndex)

            RaiseEvent MusicSequenceChanged(New MusicSequenceEventArgs(index, curMusic))
        End If

        StatusText = String.Empty
    End Sub

    Public Sub AddNewMusicSequence()
        Select Case romManager?.MusicList.Count
            Case 127
                If MessageBoxEx.Show(Form_Main_Resources.MsgBox_LimitSequenceCountReached, Form_Main_Resources.MsgBox_LimitSequenceCountReached_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Return
                End If
            Case Is >= 255
                MessageBoxEx.Show(Form_Main_Resources.MsgBox_MaxSequenceCountReached, Form_Main_Resources.MsgBox_MaxSequenceCountReached_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
        End Select

        Dim res = OpenFileDialog_SelectMusicSequenceFile()
        If res.hasExitedWithOK Then
            Dim curMusic As MusicSequence = Nothing

            StatusText = Form_Main_Resources.Status_CreatingNewSequence
            curMusic = New MusicSequence
            romManager.MusicList.Add(curMusic)

            ImportMusicFileToSequence(curMusic, res.fileName, res.filterIndex)

            RaiseEvent MusicSequenceAdded(New MusicSequenceEventArgs(romManager.MusicList.IndexOf(curMusic), curMusic))
        End If

        StatusText = String.Empty
    End Sub

    Private Sub ImportMusicFileToSequence(sequence As MusicSequence, fileName As String, mode As Integer)
        Select Case mode
            Case 1
                Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
                sequence.BinaryData = New Byte(fs.Length - 1) {}
                fs.Read(sequence.BinaryData, 0, fs.Length)
                fs.Close()
        End Select

        sequence.Name = Path.GetFileNameWithoutExtension(fileName)

        sequence.InstrumentSets.Sets.Clear()
        sequence.InstrumentSets.Sets.Add(37)

        romManager.MusicList.NeedToSaveSequences = True
        romManager.MusicList.NeedToSaveSequenceNames = True
    End Sub

    Public Sub RemoveMusicSequence(index As Integer)
        If index >= 0 Then
            Dim sequence As MusicSequence = GetMusicSequenceByIndex(index)

            'Remove sequence
            romManager.MusicList.RemoveAt(index)

            'Fix Music in Levels
            For Each lvl As Level In romManager.Levels
                For Each a As LevelArea In lvl.Areas
                    If a.BGMusic = index Then
                        Do While a.BGMusic >= romManager.MusicList.Count
                            a.BGMusic -= 1
                        Loop
                    ElseIf a.BGMusic > index Then
                        a.BGMusic -= 1
                    End If
                Next
            Next

            RaiseEvent MusicSequenceRemoved(New MusicSequenceEventArgs(index, sequence))
        End If
    End Sub

    Public Function GetMusicSequenceByIndex(index As Integer) As MusicSequence
        Return romManager.MusicList.ElementAtOrDefault(index)
    End Function

    Public Sub EditMusicSequenceInHexEditor(index As Integer)
        Dim sequence As MusicSequence = GetMusicSequenceByIndex(index)
        OpenHexEditor(sequence.BinaryData)
        romManager.MusicList.NeedToSaveSequences = True
        RaiseEvent MusicSequenceChanged(New MusicSequenceEventArgs(index, sequence))
    End Sub

    Public Sub SetMusicSequenceName(index As Integer, name As String)
        Dim sequence As MusicSequence = GetMusicSequenceByIndex(index)
        name = name.Trim

        If Not String.IsNullOrEmpty(name) AndAlso sequence IsNot Nothing Then
            sequence.Name = name

            romManager.MusicList.NeedToSaveSequenceNames = True

            RaiseEvent MusicSequenceChanged(New MusicSequenceEventArgs(index, sequence))
        End If
    End Sub

    Public Sub SetMusicSequenceInstrumentSet(index As Integer, instSet As Byte)
        Dim sequence As MusicSequence = GetMusicSequenceByIndex(index)

        If sequence IsNot Nothing Then
            sequence.InstrumentSets.Sets.Clear()
            sequence.InstrumentSets.Sets.Add(instSet)

            romManager.MusicList.NeedToSaveNInsts = True

            RaiseEvent MusicSequenceChanged(New MusicSequenceEventArgs(index, sequence))
        End If
    End Sub

    Public Function GetMusicSeuenceCount() As Integer
        Return romManager.MusicList.Count
    End Function

    Public Function GetMusicSequenceInfos(index As Integer) As (name As String, instSet As Byte, length As Integer)
        Dim sequence As MusicSequence = GetMusicSequenceByIndex(index)
        Return (sequence.Name, sequence.InstrumentSets.Sets(0), sequence.Lenght)
    End Function

End Class
