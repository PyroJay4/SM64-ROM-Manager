Imports System.IO
Imports DevComponents.DotNetBar
Imports nUpdate.Updating
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports Publics
Imports System.Collections.Specialized
Imports System.Threading
Imports System.Globalization
Imports SM64Lib.Music
Imports SM64Lib.Levels
Imports PatchScripts
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib.Exceptions

Public Class MainForm

    Private updateManager As UpdateManager = Nothing
    Private rommgr As RomManager = Nothing
    Private WithEvents RomWatcher As FileSystemWatcher = Nothing

    Friend loadRecentROM As Boolean = False
    Friend FinishedLoading As Boolean = False
    Friend LoadingROM As Boolean = False
    Friend savingRom As Boolean = False

    Friend Property StatusText As String
        Get
            Return LabelItem1.Text
        End Get
        Set(value As String)
            If value = "" Then value = Form_Main_Resources.Status_Ready
            LabelItem1.Text = value
            Bar1.Refresh()
        End Set
    End Property

    Public Sub New()
        SuspendLayout()

        InitializeComponent()

        updateManager = New UpdateManager(New Uri("http://pilzinsel64.square7.ch/Updates/SM64_ROM_Manager_New/updates.json"), "<RSAKeyValue><Modulus>w5WpraTgIe2QlQGkvrJDcdrtRkb1AQ0iDMO0JMsCd7rPoUYw7cu7YnRreeadU5jBiit4G82oB/TOtT+quJPDBixxKjof9gKVqrxeKtMYU/3vwRQg0+Y77GFD6tMLNlJwrk1NzgS3FN2Zlpl9LplgeQr9g5RSKMyu+VJ5OTZOHZAyHpvMnPSD9V1Kpyj/WFf2ADf9PL3Z4vEJfcmoFdGY6i4hq4IAIe5o5lYGB5zC/QOfDuAHEO+oGbOkFs65BeHDZWkLnzBOYPI4rnHZpU9E/ChcJVerNln45D9XGElDVXy7AIdy417mefjqnPaqMgm/22aTUW3f1Jsy3kcUhe1/f5eE/PHQoFvLPjcezY5mPUkW5JT1Y+2tIROvXh5zejyb+/2ctyVLSqLhG6wh4UNFd60Be4mV2NJ+Acn9IagdvMW3AvUmbSgQK4Jmq2OP656XkrdDi2vGibdMOB2Nt+O/q5+GpbzrEAnX+t9ikxmT568PpfjGBVvh+DmQxhiEaKT28HKWuDwLOdq6bnnnw6LlqF0odHqf2L09uXULJQo9W8zMoA5lyNbgHTfrj1ik9X4xheZkqmwJWIyYrRsPsyLN6Eani4vqVeVgBfJxdon45x5tPqYhadHoIHWU8WxnIGBnDAmaBZ/6lQpfTmbo3c8T2WuNjQAarzmnFKHP6GqP9X7JFhGQklTI5LFNsz6IjFRoHl/R5bUi6GJddoFitKXT4XjaJw+zR4Vp6W37wLjbe/r7Wd+vBST3YxTELQ+zQ3lxOb3Ht+0psinyaqqWVG8jh69axesPDIXvqDmZsYTlbm8YWyHeViX6xDo1+gYCZkFnCqdpXaB2B2a/bnvV1DKRDWCUi122BzCkUQg104F2ncnTnwrEwGXBQzVcZkkCtNhoiQRbOz+kJZz3tdmF+IPdhsdevpB4XwVbb/aTCkx2T68LOrGCuaKZ8EmHzTEbX2thSs7q3+ImfxCC9pubzCgwQEiS4MD/k+BMfDt7JQEPSP8EvBDxLLJ8Ls34/GnX5DSkUwMC3a/DUoZ0FgV8aIJEPSequjB/HtVQaR9t8j8ynr9FpsxGS0Qa0UZLt5ACG76Z4wgnLdrPKJMD0hcscmdiy4ov3a3AkuvkvIeGDwWFRMFrwq4F+5+i5AvC+f+jjwRjCckOEUsUrgcycsLXDMKjD0VGRLQIr+qegB1I7Wrl15ctvS+z3YIgx+SrGNbrEzLKxV5Habe/HKZrQ2t8JzflurHJByifFQ/Szp0BkoOXkVmkuczAw0a/DglU2um1Ic8cXAuNIWP0PbYpvVDUnChZrFMVO5QFMAdI8Ei9LHbjlTNdegXtHXIGJS9uXdf8285rlHsyVkCHbtFyZRsQSkuDuQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", New CultureInfo("en"), New UpdateVersion(Application.ProductVersion))
        updateManager.CloseHostApplication = True
        updateManager.RestartHostApplication = True

        'Set instance on Tabs   
        tabGeneral.MainForm = Me
        tabLevelManager.MainForm = Me
        tabTextManager.MainForm = Me
        tabMusicManager.MainForm = Me

        'Enable Auto-Save for Settings
        Settings.AutoSave = True

        'Takeover the settings from old settings file
        TakeoverOldSettings()

        SetStyleManagerStyle()

        ResumeLayout()

        'TEMPORARY: Set the new client size until DotNetBar fixed the border issue
        ClientSize = New Size(712, 689)
    End Sub

    Private Sub TakeoverOldSettings()
        If File.Exists(SettingsOld.SettingsFile) Then
            'Load old Settings
            SettingsOld.LoadSettings()

            'Takeover the old settings
            Settings.General.ActionIfUpdatePatches = SettingsOld.General.ActionIfUpdatePatches
            Settings.General.AutoUpdates = SettingsOld.General.AutoUpdates
            Settings.General.EmulatorPath = SettingsOld.General.EmulatorPath
            Settings.General.IntegerValueMode = SettingsOld.General.IntegerValueMode
            Settings.AreaEditor.RibbonControlExpanded = SettingsOld.AreaEditor.RibbonControlExpanded
            Settings.AreaEditor.DefaultCameraMode = SettingsOld.AreaEditor.DefaultCameraMode
            Settings.AreaEditor.DefaultWindowMode = SettingsOld.AreaEditor.DefaultWindowMode
            Settings.FileParser.LoaderModule = SettingsOld.FileParser.LoaderModule
            Settings.FileParser.UpAxis = SettingsOld.ModelConverter.UpAxis
            Settings.StyleManager.AlwaysKeepBlueColors = SettingsOld.StyleManager.AlwaysKeepBlueColors
            Settings.StyleManager.MetroColorParams = SettingsOld.StyleManager.MetroColorParams
            Settings.RecentFiles.RecentROMs.AddRange(SettingsOld.RecentFiles.GetRecentFiles(SettingsOld.RecentFiles.RecentRomsSection))
            Settings.RecentFiles.RecentModelFiles.AddRange(SettingsOld.RecentFiles.GetRecentFiles(SettingsOld.RecentFiles.RecentModelFilesSection))

            'Save the new settings
            Settings.SaveSettings()

            'Delete old Settings file
            File.Delete(SettingsOld.SettingsFile)
        End If
    End Sub

    Private Sub SetStyleManagerStyle()
        StyleManager.Style = eStyle.Metro
        StyleManager.MetroColorGeneratorParameters = New Metro.ColorTables.MetroColorGeneratorParameters(Color.FromArgb(Settings.StyleManager.MetroColorParams.CanvasColor.ToArgb Or &HFF000000),
                                                                                                         Color.FromArgb(Settings.StyleManager.MetroColorParams.BaseColor.ToArgb Or &HFF000000))

        UpdateAmbientColors()

        tabTextManager.Line_TM_Green.ForeColor = Color.Green
        tabTextManager.Line_TM_Warning1.ForeColor = Color.Orange
        tabTextManager.Line_TM_Warning2.ForeColor = Color.Red
    End Sub

    Private Sub SetRomMgr(rommgr As RomManager)
        Me.rommgr = rommgr
        tabGeneral.RomMgr = rommgr
        tabLevelManager.RomMgr = rommgr
        tabTextManager.RomMgr = rommgr
        tabMusicManager.RomMgr = rommgr
    End Sub

    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshAppTitel()
    End Sub

    Private Sub Form_Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        StatusText = Form_Main_Resources.Status_StartingUp

        LoadRecentROMs()
        tabLevelManager.LoadListBoxEntries()
        FinishedLoading = True

        StatusText = ""

        CheckCommandLineArgs()

        SearchForUpdates()
    End Sub

    Private Sub CheckCommandLineArgs()
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
                    OpenROMFile(fileToOpen)
            End Select
        End If
    End Sub

    Private Sub SearchForUpdates()
        Dim ui As New UpdaterUI(updateManager, SynchronizationContext.Current, True)
        ui.ShowUserInterface()
    End Sub

    Friend Sub RefreshAppTitel()
        Dim appversion As New Version(Application.ProductVersion)
        Me.Text = $"{Application.ProductName} (v{appversion.ToString(If(appversion.Revision <> 0, 4, If(appversion.Build <> 0, 3, 2)))} - Beta){If(rommgr?.RomFile <> "", $" - ""{Path.GetFileName(rommgr?.RomFile)}""", "")}"
    End Sub

    Private Sub TabControl_Main_SelectedIndexChanged(sender As TabControl, e As TabStripTabChangedEventArgs) Handles TabControl1.SelectedTabChanged
        Select Case True
            Case sender.SelectedTab.Equals(TabItem_TextManager)
                tabTextManager.TM_ReloadTable()
        End Select
    End Sub

    Private Sub MenuItem11_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        Environment.Exit(Environment.ExitCode)
    End Sub

    Private Async Sub MenuItem_LaunchROM_Click(sender As Object, e As EventArgs) Handles ButtonItem_LaunchROM.Click
        Await WaitWhileSavingRom()
        LaunchRom(rommgr)
    End Sub

    Private Function WaitWhileSavingRom() As Task
        Dim t As New Task(Sub()
                              Do While savingRom
                              Loop
                          End Sub)
        t.Start()
        Return t
    End Function

    Private Sub ButtonItem12_Click(sender As Object, e As EventArgs) Handles ButtonItem_SaveRom.Click
        If AllowSavingRom() Then
            StatusText = Form_Main_Resources.Status_SavingRom
            savingRom = True

            SaveRom(rommgr)

            savingRom = False
            StatusText = ""
        End If
    End Sub

    Private Function AllowSavingRom() As Boolean
        If tabTextManager.OverLimit Then
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_TextsOverLimit, Form_Main_Resources.MsgBox_TextsOverLimit_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub Form_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If rommgr?.NeedToSave Then
            Select Case MessageBoxEx.Show(Form_Main_Resources.MsgBox_UnsavedChanges, Form_Main_Resources.MsgBox_UnsavedChanges_Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    If AllowSavingRom() Then
                        SaveRom(rommgr)
                    Else
                        e.Cancel = True
                    End If

                Case DialogResult.No

                Case Else
                    e.Cancel = True
                    Return

            End Select
        End If
    End Sub

    Private Sub MenuItem_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItem25.Click
        Dim frm As New Form_Settings
        frm.ShowDialog()
    End Sub

    Private Sub MenuItem_About_Click(sender As Object, e As EventArgs) Handles ButtonItem30.Click
        Dim frm As New Form_About
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Dim frm As New Form_SM64TextConverter
        frm.Show()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        Form_Stylemanager.Show()
    End Sub

    Private Sub ButtonItem29_Click(sender As Object, e As EventArgs) Handles ButtonItem29.Click
        Dim ui As New UpdaterUI(updateManager, SynchronizationContext.Current, False)
        ui.ShowUserInterface()
    End Sub

    Private Sub SuperTabControl_Main_SelectedTabChanging(sender As Object, e As TabStripTabChangingEventArgs) Handles TabControl1.SelectedTabChanging
        If FinishedLoading Then
            If rommgr Is Nothing AndAlso e.NewTab IsNot TabControl1 Then
                e.Cancel = True
                ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
            End If
        End If
    End Sub
    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem23.Click
        If rommgr IsNot Nothing Then
            PatchClass.UpdateChecksum(rommgr.RomFile)
        End If
    End Sub

    Private Sub ButtonItem_ModelImporter_Click(sender As Object, e As EventArgs) Handles ButtonItem_ModelImporter.Click
        Dim frm As New ModelImporterGUI.ModelImporter
        frm.RomFile = rommgr?.RomFile
        frm.Show()
    End Sub

    Private Sub ButtonItem17_Click(sender As Object, e As EventArgs) Handles ButtonItem17.Click
        Dim tweaks As New TweakViewer(rommgr)
        tweaks.Show()
    End Sub

    Private Sub ButtonItem_TrajectoryEditor_Click(sender As Object, e As EventArgs) Handles ButtonItem_TrajectoryEditor.Click
        Dim editor As New TrajectoryEditor(rommgr)
        editor.ShowDialog(Me)
    End Sub

    Private Sub MenuItem20_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        TabControl1.SelectedTab = TabItem_LevelManager
    End Sub
    Private Sub MenuItem16_Click(sender As Object, e As EventArgs) Handles ButtonItem11.Click
        TabControl1.SelectedTab = TabItem_TextManager
    End Sub
    Private Sub MenuItem17_Click(sender As Object, e As EventArgs) Handles ButtonItem10.Click
        TabControl1.SelectedTab = TabItem_MusicManager
    End Sub

    Private Sub SuperTabControl_Main_TabItemClose(sender As Object, e As TabStripActionEventArgs) Handles TabControl1.TabItemClose
        e.Cancel = True
        e.TabItem.Visible = False
    End Sub

    Private Sub SuperTabControl_Main_ControlAdded(sender As Object, e As ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TabControl1.Tabs.Count - 1
    End Sub

#Region "General"

    Friend Sub LoadRecentROMs()
        tabGeneral.ItemPanel_RecentFiles.Items.Clear()

        Dim di_Open As New ButtonItem With {.Text = Form_Main_Resources.Button_OpenRom, .SymbolSet = eSymbolSet.Material, .Symbol = "58055", .SymbolColor = Color.FromArgb(215, 172, 106), .ButtonStyle = eButtonStyle.ImageAndText, .SymbolSize = 12}
        AddHandler di_Open.Click, AddressOf MenuItem_OpenROM_Click
        tabGeneral.ItemPanel_RecentFiles.Items.Add(di_Open)

        Dim cindex As Integer = 1
        MergeRecentFiles(Settings.RecentFiles.RecentROMs)
        For Each r As String In Settings.RecentFiles.RecentROMs
            Dim bi As New ButtonItem
            bi.Text = Path.GetFileName(r)
            bi.Image = IconExtractor.ExtractIcon(r, True).ToBitmap
            bi.ButtonStyle = eButtonStyle.ImageAndText
            If cindex = 1 Then bi.BeginGroup = True
            AddHandler bi.Click, AddressOf MenuItem_RecentROMs_Click
            tabGeneral.ItemPanel_RecentFiles.Items.Add(bi)
            cindex += 1
        Next

        tabGeneral.ItemPanel_RecentFiles.Refresh()
    End Sub

    Friend Sub MenuItem_OpenROM_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Dim ofd_SM64RM_LM_LoadROM As New OpenFileDialog
        With ofd_SM64RM_LM_LoadROM
            .Filter = "SM64 ROMs (*.z64)|*.z64"

            MergeRecentFiles(Settings.RecentFiles.RecentROMs)
            Dim lastFiles As StringCollection = Settings.RecentFiles.RecentROMs
            If lastFiles.Count > 0 Then .InitialDirectory = Path.GetDirectoryName(lastFiles(0))

            If .ShowDialog <> DialogResult.OK Then Return
            OpenROMFile(.FileName)
        End With
    End Sub

    Friend Sub MenuItem_RecentROMs_Click(sender As Object, e As EventArgs)
        OpenROMFile(Settings.RecentFiles.RecentROMs(tabGeneral.ItemPanel_RecentFiles.Items.IndexOf(sender) - 1))
        tabGeneral.Refresh()
    End Sub

    Private Sub OpenROMFile(Romfile As String)
        If Not loadRecentROM Then
            Try
                Dim romFileInfo As New FileInfo(Romfile)
                Dim newrommgr As New SM64Lib.RomManager(Romfile)
                StatusText = Form_Main_Resources.Status_Checking

                If romFileInfo.Length = 8 * 1024 * 1024 Then
                    If MessageBoxEx.Show(Form_Main_Resources.MsgBox_PrepaireRom, Form_Main_Resources.MsgBox_PrepaireRom_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> DialogResult.OK Then
                        StatusText = ""
                        Return
                    End If
                End If

                If Not newrommgr.CheckROM() Then
                    StatusText = ""
                    Return
                ElseIf newrommgr.IsSM64EditorMode Then
                    Throw New SM64Lib.Exceptions.RomCompatiblityException("This ROM was used by the SM64 Editor and isn't compatible with the SM64 ROM Manager.")
                End If

                loadRecentROM = True

                AddRecentFile(Settings.RecentFiles.RecentROMs, Romfile)
                LoadRecentROMs()

                SetRomMgr(newrommgr)
                LoadROM(Romfile)

                tabGeneral.LabelX_G_Filename.Text = Path.GetFileName(Romfile)
                TabControl1.Enabled = True
                ButtonItem_LaunchROM.Enabled = True
                RefreshAppTitel()

                CreateRomWatcherForCurrentRom()

            Catch ex As RomCompatiblityException
                MessageBoxEx.Show(ex.Message, "Loading ROM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As ReadOnlyException
                MessageBoxEx.Show(ex.Message, "Loading ROM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBoxEx.Show("A unknown error happend at loading ROM.", "Loading ROM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            loadRecentROM = False
            StatusText = ""
        End If
    End Sub

    Private Sub LoadROM(Romfile As String)
        LoadingROM = True
        StatusText = Form_Main_Resources.Status_LoadingRom

        'Load Global Object Banks
        'rommgr.LoadGlobalObjectBank()

        'Load Levels
        rommgr.LoadLevels()

        'Load ROM Infos
        tabGeneral.TextBoxX_G_GameName.ReadOnly = True
        tabGeneral.TextBoxX_G_GameName.Text = rommgr.GameName
        tabGeneral.TextBoxX_G_GameName.ReadOnly = False
        tabGeneral.LabelX_G_Filesize.Text = String.Format("{0} Megabyte", CInt(New FileInfo(Romfile).Length / 1024 / 1024))

        'Load Music
        StatusText = Form_Main_Resources.Status_LoadingMusic
        rommgr.LoadMusic()
        MusicSettings_CreateList()
        StatusText = ""

        tabLevelManager.LM_LoadLevelList()

        TabControl_Main_SelectedIndexChanged(TabControl1, Nothing)

        StatusText = ""
        LoadingROM = False
    End Sub

#End Region

#Region "Music"

    Friend Sub MusicSettings_CreateList()
        Dim IndexBefore1 As Integer = tabMusicManager.ListBoxAdv_MS_MusicSequences.SelectedIndex
        Dim IndexBefore2 As Integer = tabLevelManager.ComboBox_LM_Music.SelectedIndex

        tabMusicManager.TextBoxX_MS_Sequencename.ReadOnly = True
        tabMusicManager.ListBoxAdv_MS_MusicSequences.Items.Clear()
        tabLevelManager.ComboBox_LM_Music.Items.Clear()

        For Each s As MusicSequence In rommgr.MusicList
            tabMusicManager.ListBoxAdv_MS_MusicSequences.Items.Add(New ButtonItem)
            tabLevelManager.ComboBox_LM_Music.Items.Add("")
        Next
        MusicSettings_RefreshList()

        tabMusicManager.SwitchButton_MS_OverwriteSizeRestrictions.Value = rommgr.MusicList.EnableMusicHack
        tabMusicManager.TextBoxX_MS_Sequencename.ReadOnly = False

        If IndexBefore1 < 0 Then IndexBefore1 = 1
        If IndexBefore2 < 0 Then IndexBefore2 = 3
        If tabMusicManager.ListBoxAdv_MS_MusicSequences.Items.Count > IndexBefore1 Then
            tabMusicManager.ListBoxAdv_MS_MusicSequences.SelectedIndex = IndexBefore1
            tabMusicManager.ListBoxAdv_MS_MusicSequences.SelectedIndex = IndexBefore1
        End If
        If tabLevelManager.ComboBox_LM_Music.Items.Count > IndexBefore2 Then
            tabLevelManager.ComboBox_LM_Music.SelectedIndex = IndexBefore2
        End If
    End Sub

    Friend Sub MusicSettings_RefreshList()
        For i As Integer = 0 To rommgr.MusicList.Count - 1
            Dim tName As String = $"{TextFromValue(i,, 2)} - {rommgr.MusicList(i).Name}"
            tabMusicManager.ListBoxAdv_MS_MusicSequences.Items(i).Text = tName
            tabLevelManager.ComboBox_LM_Music.Items(i) = tName
        Next
        tabMusicManager.ListBoxAdv_MS_MusicSequences.Refresh()
        tabLevelManager.ComboBox_LM_Music.Refresh()
    End Sub

    Friend Sub MusicSettings_RemoveEntry()
        Dim index As Integer = tabMusicManager.ListBoxAdv_MS_MusicSequences.SelectedIndex
        If index >= 0 Then
            rommgr.MusicList.RemoveAt(index)
            tabMusicManager.ListBoxAdv_MS_MusicSequences.Items.RemoveAt(index)
            tabLevelManager.ComboBox_LM_Music.Items.RemoveAt(index)

            For Each lvl As Level In rommgr.Levels
                For Each a As LevelArea In lvl.Areas
                    If a.BGMusic = index Then
                        Do While a.BGMusic >= rommgr.MusicList.Count
                            a.BGMusic -= 1
                        Loop
                    ElseIf a.BGMusic > index Then
                        a.BGMusic -= 1
                    End If
                Next
            Next

            MusicSettings_CreateList()
        End If
    End Sub

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs) Handles ButtonItem9.Click
        Dim patcher As New ApplyPPF.ApplyPPFDialog(rommgr?.RomFile, "")
        patcher.ShowDialog(Me)
    End Sub

    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs) Handles ButtonItem14.Click
        Dim ibce As ItemBoxContentEditor = GetFirstOpenForm(Of ItemBoxContentEditor)()

        If ibce Is Nothing Then
            ibce = New ItemBoxContentEditor(rommgr)
        End If

        ibce.Show()
    End Sub

    Private Sub ButtonItem13_Click(sender As Object, e As EventArgs) Handles ButtonItem13.Click
        Dim spo As StarPositionEditor = GetFirstOpenForm(Of StarPositionEditor)()

        If spo Is Nothing Then
            spo = New StarPositionEditor(rommgr)
        End If

        spo.Show()
    End Sub

    Private Sub CreateRomWatcherForCurrentRom()
        If rommgr IsNot Nothing Then
            RomWatcher = New FileSystemWatcher(Path.GetDirectoryName(rommgr.RomFile), Path.GetFileName(rommgr.RomFile)) With {.EnableRaisingEvents = True, .SynchronizingObject = Me}
        Else
            RomWatcher = Nothing
        End If
    End Sub

    Private Sub RomWatcher_Changed(sender As Object, e As FileSystemEventArgs) Handles RomWatcher.Changed
    End Sub

    Private Sub RomWatcher_Renamed(sender As Object, e As RenamedEventArgs) Handles RomWatcher.Renamed
        If rommgr IsNot Nothing AndAlso e.OldFullPath = rommgr.RomFile Then
            rommgr.RomFile = e.FullPath
            RefreshAppTitel()
        End If
    End Sub

    Private Sub RomWatcher_Deleted(sender As Object, e As FileSystemEventArgs) Handles RomWatcher.Deleted
        If rommgr IsNot Nothing AndAlso e.FullPath = rommgr.RomFile Then
            If MessageBoxEx.Show("The Rom that was opend in this program has been removed!<br/>This programm will close now.", "Rom was removed", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                Close()
            End If
        End If
    End Sub

#End Region

End Class
