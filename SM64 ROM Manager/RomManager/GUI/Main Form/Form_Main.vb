Imports System.ComponentModel
Imports System.Globalization
Imports System.IO, System.Text, System.Drawing
Imports System.Numerics
Imports System.Reflection
Imports System.Threading
Imports DevComponents.DotNetBar
Imports IniParser, IniParser.Model, IniParser.Parser
Imports nUpdate.Updating
Imports SettingsManager
Imports SM64Lib.Levels.Script.Commands
Imports Publics
Imports TextValueConverter
Imports ModelConverterGUI
Imports System.Net
Imports S3DFileParser
Imports AutoUpdaterDotNET
Imports System.Resources
Imports SM64_ROM_Manager.My.Resources
Imports PatchScripts

Public Class Form_Main

#Region "Properties"

    Private PressedKeys As New List(Of Keys)
    Private FinishedLoading As Boolean = False
    Public LoadingROM As Boolean = False
    Public isSM64EditorMode As Boolean = False
    Private dicOpendAreaEditors As New Dictionary(Of Byte, Form_AreaEditor)
    Private loadRecentROM As Boolean = False
    Private updateManager As UpdateManager = Nothing
    Private rommgr As SM64Lib.RomManager = Nothing

    Private lvg_SpecialBox_Water As New ListViewGroup(Form_Main_Resources.Text_Water)
    Private lvg_SpecialBox_Mist As New ListViewGroup(Form_Main_Resources.Text_Mist)
    Private lvg_SpecialBox_ToxicHaze As New ListViewGroup(Form_Main_Resources.Text_ToxicHaze)

    Private Property StatusText As String
        Get
            Return LabelItem_Status.Text
        End Get
        Set(value As String)
            If value = "" Then value = Form_Main_Resources.Status_Ready
            LabelItem_Status.Text = value
            MetroStatusBar1.Refresh()
        End Set
    End Property

#End Region

#Region "Main Tab Items"
    Private Sub SuperTabControl_Main_TabItemClose(sender As Object, e As TabStripActionEventArgs) Handles SuperTabControl_Main.TabItemClose
        e.Cancel = True
        e.TabItem.Visible = False
    End Sub

    Private Sub MenuItem20_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        SuperTabControl_Main.SelectedTab = SuperTabItem_LM
    End Sub
    Private Sub MenuItem15_Click(sender As Object, e As EventArgs) Handles ButtonItem58.Click
        Dim frm As New Form_CustomImporter
        frm.Show()
    End Sub
    Private Sub MenuItem16_Click(sender As Object, e As EventArgs) Handles ButtonItem11.Click
        SuperTabControl_Main.SelectedTab = SuperTabItem_TM
    End Sub
    Private Sub MenuItem17_Click(sender As Object, e As EventArgs) Handles ButtonItem10.Click
        SuperTabControl_Main.SelectedTab = SuperTabItem_MS
    End Sub
    Private Sub MenuItem18_Click(sender As Object, e As EventArgs) Handles ButtonItem32.Click

    End Sub

    Private Sub SuperTabControl_Main_ControlAdded(sender As Object, e As ControlEventArgs) Handles SuperTabControl_Main.ControlAdded
        SuperTabControl_Main.SelectedTabIndex = SuperTabControl_Main.Tabs.Count - 1
    End Sub

    Private Sub TabControl_Main_SelectedIndexChanged(sender As TabControl, e As TabStripTabChangedEventArgs) Handles SuperTabControl_Main.SelectedTabChanged
        Select Case True
            Case sender.SelectedTab.Equals(SuperTabItem_TM)
                TM_ReloadTable()
        End Select
    End Sub
#End Region

#Region "Main Form"

    Public Sub LoadListBoxEntries()
        Dim temp_1 As String = MyDataPath & "\Other\Object Bank Data\Bank 0x{0}.txt"
        For Each t As String In {"B", "C", "D", "9"}
            SM64Lib.ObjectBankData.Add(FileIniParser.ReadFile(String.Format(temp_1, t)))
        Next

        With ComboBox_LM_OB0x0C.Items
            .Clear()
            .Add(Form_Main_Resources.Text_Disabled)
            For Each s In SM64Lib.ObjectBankData(1).Sections
                .Add(s.SectionName)
            Next
        End With
        With ComboBox_LM_OB0x0D.Items
            .Clear()
            .Add(Form_Main_Resources.Text_Disabled)
            For Each s In SM64Lib.ObjectBankData(2).Sections
                .Add(s.SectionName)
            Next
        End With
        With ComboBox_LM_OB0x09.Items
            .Clear()
            .Add(Form_Main_Resources.Text_Disabled)
            For Each s In SM64Lib.ObjectBankData(3).Sections
                .Add(s.SectionName)
            Next
        End With
    End Sub

    Private Sub InitIniparser()

    End Sub

    Public Sub New()
        Me.SuspendLayout()

        InitializeComponent()

        ListViewEx_LM_Specials.Groups.AddRange({lvg_SpecialBox_Water, lvg_SpecialBox_ToxicHaze, lvg_SpecialBox_Mist})
        ListViewEx_LM_Specials.Scrollable = True

        'WebRequest.DefaultWebProxy.Credentials = New NetworkCredential("username", "password")

        updateManager = New UpdateManager(New Uri("http://pilzinsel64.square7.ch/Updates/SM64_ROM_Manager_New/updates.json"), "<RSAKeyValue><Modulus>w5WpraTgIe2QlQGkvrJDcdrtRkb1AQ0iDMO0JMsCd7rPoUYw7cu7YnRreeadU5jBiit4G82oB/TOtT+quJPDBixxKjof9gKVqrxeKtMYU/3vwRQg0+Y77GFD6tMLNlJwrk1NzgS3FN2Zlpl9LplgeQr9g5RSKMyu+VJ5OTZOHZAyHpvMnPSD9V1Kpyj/WFf2ADf9PL3Z4vEJfcmoFdGY6i4hq4IAIe5o5lYGB5zC/QOfDuAHEO+oGbOkFs65BeHDZWkLnzBOYPI4rnHZpU9E/ChcJVerNln45D9XGElDVXy7AIdy417mefjqnPaqMgm/22aTUW3f1Jsy3kcUhe1/f5eE/PHQoFvLPjcezY5mPUkW5JT1Y+2tIROvXh5zejyb+/2ctyVLSqLhG6wh4UNFd60Be4mV2NJ+Acn9IagdvMW3AvUmbSgQK4Jmq2OP656XkrdDi2vGibdMOB2Nt+O/q5+GpbzrEAnX+t9ikxmT568PpfjGBVvh+DmQxhiEaKT28HKWuDwLOdq6bnnnw6LlqF0odHqf2L09uXULJQo9W8zMoA5lyNbgHTfrj1ik9X4xheZkqmwJWIyYrRsPsyLN6Eani4vqVeVgBfJxdon45x5tPqYhadHoIHWU8WxnIGBnDAmaBZ/6lQpfTmbo3c8T2WuNjQAarzmnFKHP6GqP9X7JFhGQklTI5LFNsz6IjFRoHl/R5bUi6GJddoFitKXT4XjaJw+zR4Vp6W37wLjbe/r7Wd+vBST3YxTELQ+zQ3lxOb3Ht+0psinyaqqWVG8jh69axesPDIXvqDmZsYTlbm8YWyHeViX6xDo1+gYCZkFnCqdpXaB2B2a/bnvV1DKRDWCUi122BzCkUQg104F2ncnTnwrEwGXBQzVcZkkCtNhoiQRbOz+kJZz3tdmF+IPdhsdevpB4XwVbb/aTCkx2T68LOrGCuaKZ8EmHzTEbX2thSs7q3+ImfxCC9pubzCgwQEiS4MD/k+BMfDt7JQEPSP8EvBDxLLJ8Ls34/GnX5DSkUwMC3a/DUoZ0FgV8aIJEPSequjB/HtVQaR9t8j8ynr9FpsxGS0Qa0UZLt5ACG76Z4wgnLdrPKJMD0hcscmdiy4ov3a3AkuvkvIeGDwWFRMFrwq4F+5+i5AvC+f+jjwRjCckOEUsUrgcycsLXDMKjD0VGRLQIr+qegB1I7Wrl15ctvS+z3YIgx+SrGNbrEzLKxV5Habe/HKZrQ2t8JzflurHJByifFQ/Szp0BkoOXkVmkuczAw0a/DglU2um1Ic8cXAuNIWP0PbYpvVDUnChZrFMVO5QFMAdI8Ei9LHbjlTNdegXtHXIGJS9uXdf8285rlHsyVkCHbtFyZRsQSkuDuQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", New CultureInfo("en"), New UpdateVersion(Application.ProductVersion))
        updateManager.CloseHostApplication = True
        updateManager.RestartHostApplication = True
        'AddHandler AutoUpdater.ApplicationExitEvent, AddressOf CloseApplicationForUpdate
        'AutoUpdater.AppCastURL = ""
        'AutoUpdater.Start()

        'Load Settings
        Settings.LoadSettings()

        'Set Style
        StyleManager1.MetroColorParameters = Settings.StyleManager.MetroColorParams
        UpdateAmbientColors()

        'Change Colors for Text Bounds Lines
        Line_TM_Green.ForeColor = Color.Green
        Line_TM_Warning1.ForeColor = Color.Orange
        Line_TM_Warning2.ForeColor = Color.Red

        ResumeLayout()
    End Sub

    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitIniparser()
        RefreshAppTitel()
    End Sub
    Private Sub Form_Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        StatusText = Form_Main_Resources.Status_StartingUp

        LoadRecentROMs()
        LoadListBoxEntries()
        FinishedLoading = True

        StatusText = ""

        CheckCommandLineArgs()

        SearchForUpdates()
    End Sub

    Private Sub CloseApplicationForUpdate()
        Environment.Exit(0)
    End Sub

    Private Sub SearchForUpdates()
        Dim ui As New UpdaterUI(updateManager, SynchronizationContext.Current, True)
        ui.ShowUserInterface()
    End Sub

#End Region

#Region "Load ROM"
    Private Sub MenuItem_OpenROM_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Dim ofd_SM64RM_LM_LoadROM As New OpenFileDialog
        With ofd_SM64RM_LM_LoadROM
            .Filter = "SM64 ROMs (*.z64)|*.z64"

            Dim lastFile As String = Settings.RecentFiles.GetRecentFiles(Settings.RecentFiles.RecentRomsSection).FirstOrDefault
            If lastFile <> "" Then .InitialDirectory = Path.GetDirectoryName(lastFile)

            If .ShowDialog <> DialogResult.OK Then Return
            OpenROMFile(.FileName)
        End With
    End Sub
    Private Sub MenuItem_RecentROMs_Click(sender As Object, e As EventArgs)
        OpenROMFile(Settings.RecentFiles.GetRecentFiles("Recent ROMs")(ItemPanel_RecentFiles.Items.IndexOf(sender) - 1))
        Application.DoEvents()
        ItemPanel_RecentFiles.Refresh()
    End Sub

    Private Sub SetUpRomManagerSettings()
        If rommgr IsNot Nothing Then
        End If
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

                Settings.RecentFiles.StoreRecentFile("Recent ROMs", Romfile)
                LoadRecentROMs()

                rommgr = newrommgr
                SetUpRomManagerSettings()
                LoadROM(Romfile)

                LabelX_G_Filename.Text = Path.GetFileName(Romfile)
                SuperTabControl_Main.Enabled = True
                ButtonItem_LaunchROM.Enabled = True
                RefreshAppTitel()

            Catch ex As SM64Lib.Exceptions.RomCompatiblityException
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
        rommgr.LoadGlobalObjectBank()

        'Load Levels
        rommgr.LoadLevels()

        'Load ROM Infos
        TextBoxX_G_GameName.ReadOnly = True
        TextBoxX_G_GameName.Text = rommgr.GameName
        TextBoxX_G_GameName.ReadOnly = False
        LabelX_G_Filesize.Text = String.Format("{0} Megabyte", CInt(New FileInfo(Romfile).Length / 1024 / 1024))

        'Load Music
        StatusText = Form_Main_Resources.Status_LoadingMusic
        rommgr.LoadMusic()
        MusicSettings_CreateList()
        StatusText = ""

        If Not isSM64EditorMode Then
            ListBoxAdv_LM_Levels.Items.Clear()
            If ListBoxAdv_LM_Levels.Items.Count > 0 Then ListBoxAdv_LM_Levels.SelectedIndex = 0

            LM_ReloadLevelListBox()
            ListBoxAdv_LM_Areas.Items.Clear()
        End If

        TabControl_Main_SelectedIndexChanged(SuperTabControl_Main, Nothing)

        StatusText = ""
        LoadingROM = False
    End Sub
#End Region

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

    Private Sub MenuItem11_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        Environment.Exit(Environment.ExitCode)
    End Sub

    Private Sub MenuItem_LaunchROM_Click(sender As Object, e As EventArgs) Handles ButtonItem_LaunchROM.Click
        Do While LM_SavingRom
            Application.DoEvents()
        Loop

        LaunchRom(rommgr)
    End Sub

    Private Sub Button_G_SaveGameName_Click(sender As Object, e As EventArgs) Handles Button_G_SaveGameName.Click
        Try
            TextBoxX_G_GameName.Text = TextBoxX_G_GameName.Text.Trim
            rommgr.GameName = TextBoxX_G_GameName.Text
        Catch ex As Exception
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_GameNameHasInvalidChars, Global_Ressources.Text_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Button_G_SaveGameName.Enabled = False
    End Sub

    Private Sub TextBoxX_G_GameName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_G_GameName.TextChanged
        If TextBoxX_G_GameName.ReadOnly Then Return
        Button_G_SaveGameName.Enabled = True
    End Sub

    Private Sub MenuItem_XmlToM64Converter_Click(sender As Object, e As EventArgs)
        Dim frm As New Form_XmlToM64Converter
        frm.Show()
    End Sub

    Private Sub AddNewMenuItemtoList(ByRef newMenuItems As List(Of ButtonItem), newMenuItem As ButtonItem, ParentName As String)
        For Each mi As ButtonItem In newMenuItems
            If mi.Name = ParentName Then
                mi.SubItems.Add(newMenuItem)
            Else
                For Each mi2 As ButtonItem In mi.SubItems
                    AddNewMenuItemtoList(newMenuItems, newMenuItem, ParentName)
                Next
            End If
        Next
    End Sub

    Private Sub Form_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If rommgr?.NeedToSave Then
            Select Case MessageBoxEx.Show(Form_Main_Resources.MsgBox_UnsavedChanges, Form_Main_Resources.MsgBox_UnsavedChanges_Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    rommgr.SaveLevels()

                Case DialogResult.No

                Case Else
                    e.Cancel = True
                    Return

            End Select
        End If

        Settings.SaveSettings()
    End Sub

    Private Sub LoadRecentROMs()
        ItemPanel_RecentFiles.Items.Clear()

        Dim di_Open As New ButtonItem With {.Text = Form_Main_Resources.Button_OpenRom, .SymbolSet = eSymbolSet.Material, .Symbol = "58055", .SymbolColor = Color.FromArgb(215, 172, 106), .ButtonStyle = eButtonStyle.ImageAndText, .SymbolSize = 12}
        AddHandler di_Open.Click, AddressOf MenuItem_OpenROM_Click
        ItemPanel_RecentFiles.Items.Add(di_Open)

        Dim cindex As Integer = 1
        For Each r As String In Settings.RecentFiles.GetRecentFiles("Recent ROMs")
            Dim bi As New ButtonItem With {.Text = Path.GetFileName(r), .Image = IconExtractor.ExtractIcon(r, True).ToBitmap, .ButtonStyle = eButtonStyle.ImageAndText}
            AddHandler bi.Click, AddressOf MenuItem_RecentROMs_Click
            ItemPanel_RecentFiles.Items.Add(bi)
            cindex += 1
        Next

        ItemPanel_RecentFiles.Refresh()
    End Sub

    Private Sub Form_Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not e.Alt Then Return
        If Not e.Shift Then Return
        If Not e.Control Then Return

        If PressedKeys.Contains(e.KeyCode) Then Return
        Dim KeysToPress() As Keys = {Keys.R, Keys.A, Keys.Z, Keys.D1, Keys.D9}
        If PressedKeys.Count = KeysToPress.Count Then Return
        If e.KeyCode = KeysToPress(PressedKeys.Count) Then PressedKeys.Add(e.KeyCode)
        If PressedKeys.Count = KeysToPress.Count Then MsgBox("")
    End Sub

    Private Sub MenuItem_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItem25.Click
        Dim frm As New Form_Settings
        frm.ShowDialog()
        SetUpRomManagerSettings()
    End Sub

    Private Sub MenuItem_About_Click(sender As Object, e As EventArgs) Handles ButtonItem30.Click
        Dim frm As New Form_About
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Dim frm As New MainModelConverter
        If frm.ShowDialog <> DialogResult.OK Then Return

        Dim sfd As New SaveFileDialog
        sfd.Filter = "Fast3D + Collision File (*.f3dc)|*.f3dc"
        If sfd.ShowDialog <> DialogResult.OK Then Return

        'frm.resModel.ToFile(sfd.FileName)
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Dim frm As New Form_SM64TextConverter
        frm.Show()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        Form_Stylemanager.StyleManager = StyleManager1
        Form_Stylemanager.Show()
    End Sub

    Private Sub ButtonItem12_Click(sender As Object, e As EventArgs) Handles ButtonItem_SaveRom.Click
        StatusText = Form_Main_Resources.Status_SavingRom
        LM_SavingRom = True

        SaveRom(rommgr)

        LM_SavingRom = False
        StatusText = ""
    End Sub

    Private Sub RefreshAppTitel()
        Dim appversion As New Version(Application.ProductVersion)
        Me.Text = $"{Application.ProductName} (v{appversion.ToString(If(appversion.Revision <> 0, 4, If(appversion.Build <> 0, 3, 2)))} - Beta){If(rommgr?.RomFile <> "", $" - ""{Path.GetFileName(rommgr?.RomFile)}""", "")}"
    End Sub

    Private Sub ListBoxAdv_LM_Levels_ItemDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBoxAdv_LM_Levels.ItemDoubleClick, ListBoxAdv_LM_Areas.ItemDoubleClick
        Button_LM_AreaEditor.PerformClick()
    End Sub

    Private Sub ButtonItem29_Click(sender As Object, e As EventArgs) Handles ButtonItem29.Click
        'SearchForUpdates()
        Dim ui As New UpdaterUI(updateManager, SynchronizationContext.Current, False)
        ui.ShowUserInterface()
    End Sub

    Private Sub SuperTabControl_Main_SelectedTabChanging(sender As Object, e As TabStripTabChangingEventArgs) Handles SuperTabControl_Main.SelectedTabChanging
        If rommgr Is Nothing AndAlso e.NewTab IsNot SuperTabItem_General Then
            e.Cancel = True
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        End If
    End Sub

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem23.Click
        If rommgr IsNot Nothing Then
            PatchClass.UpdateChecksum(rommgr.RomFile)
        End If
    End Sub

    Private Sub ButtonItem24_Click(sender As Object, e As EventArgs) Handles ButtonItem24.Click
        Dim frm As New ValueInputDialog
        frm.InfoLabel.Text = Form_Main_Resources.Text_NewLength & ":"
        frm.ValueTextBox.Text = TextFromValue(CurrentLevel.bank0x19.Length)

        Dim [continue] As Boolean = True
        Dim minSize As UInteger = SM64Lib.RomManager.ManagerSettings.defaultLevelscriptSize

        Do While [continue]
            If frm.ShowDialog = DialogResult.OK Then
                Dim newVal As Integer = ValueFromText(frm.ValueTextBox.Text)
                If newVal < minSize Then
                    MessageBoxEx.Show(String.Format(Form_Main_Resources.MsgBox_InvalidBankSize, minSize.ToString("X")), Form_Main_Resources.MsgBox_InvalidBankSize_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    CurrentLevel.bank0x19.Length = newVal
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_BankSizeChangedSuccess, Form_Main_Resources.MsgBox_BankSizeChangedSuccess_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    [continue] = False
                End If
            Else
                [continue] = False
            End If
        Loop
    End Sub

    Private Sub ButtonX_LM_LevelsMore_PopupOpen(sender As Object, e As EventArgs) Handles ButtonX_LM_LevelsMore.PopupOpen
        ButtonItem24.Visible = CurrentLevel?.bank0x19 IsNot Nothing
    End Sub

    Private Sub ButtonItem_ModelImporter_Click(sender As Object, e As EventArgs) Handles ButtonItem_ModelImporter.Click
        Dim frm As New ModelImporterGUI.ModelImporter With {.StyleManager = Me.StyleManager1}
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
End Class
