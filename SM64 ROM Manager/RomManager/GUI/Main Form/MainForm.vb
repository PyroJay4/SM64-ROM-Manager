Imports System.IO
Imports DevComponents.DotNetBar
Imports nUpdate.Updating
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64_ROM_Manager.Publics
Imports System.Collections.Specialized
Imports System.Threading
Imports System.Globalization
Imports SM64Lib.Music
Imports SM64Lib.Levels
Imports SM64Lib.TextValueConverter
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib.Exceptions
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports DevComponents.DotNetBar.Controls
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Reflection
Imports Microsoft.Win32
Imports Pilz.Reflection
Imports TaskDialog = DevComponents.DotNetBar.TaskDialog
Imports SM64_ROM_Manager.EventArguments

Public Class MainForm

    Private WithEvents Controller As New MainController(Me)
    Private WithEvents WarningBox_RomChanged As WarningBox
    Private finishedLoading As Boolean = False
    Private changingTab As Boolean = False

    Public Sub New()
        'CheckForIllegalCrossThreadCalls = False

        'Stop drawing
        SuspendLayout()

        'Init Components
        InitializeComponent()

        'Set instance on Tabs   
        tabGeneral.Controller = Controller
        tabLevelManager.Controller = Controller
        tabTextManager.TMController = Controller.TextManagerController
        tabMusicManager.Controller = Controller

        'Set my style
        SetStyleManagerStyle()
        Controller.TextManagerController.SendRequestReloadTextManagerLineColors()

        'Resume drawing
        ResumeLayout()
    End Sub

    Private Sub SetStyleManagerStyle()
        UpdateAmbientColors()

        tabTextManager.Line_TM_Green.ForeColor = Color.Green
        tabTextManager.Line_TM_Warning1.ForeColor = Color.Orange
        tabTextManager.Line_TM_Warning2.ForeColor = Color.Red
    End Sub

    'C o n t r o l l e r   E v e n t s

    Private Sub Controller_StatusTextChanged(e As StatusTextChangedEventArgs) Handles Controller.StatusTextChanged
        LabelItem1.Text = e.NewStatus
        Bar1.Refresh()
    End Sub

    Private Sub Controller_OtherStatusInfosChanged(e As OtherStatusInfosChangedEventArgs) Handles Controller.OtherStatusInfosChanged
        LabelItem_OtherInfoText.Text = e.Text
        LabelItem_OtherInfoText.ForeColor = e.ForeColor
        Bar1.Refresh()
    End Sub

    Private Sub Controller_RomLoaded() Handles Controller.RomLoaded
        TabControl1.Enabled = True
        ButtonItem_LaunchROM.Enabled = True
        RefreshAppTitel()
        TabControl_Main_SelectedIndexChanged(TabControl1, Nothing)
    End Sub

    Private Sub Controller_RecentFilesChanged() Handles Controller.RecentFilesChanged
        LoadRecentROMs()
    End Sub

    Private Sub Controller_RomFileRenamed() Handles Controller.RomFileRenamed
        RefreshAppTitel()
    End Sub

    Private Sub Controller_RomFileDeleted() Handles Controller.RomFileDeleted
        If MessageBoxEx.Show(Form_Main_Resources.MsgBox_RomRemoved, Form_Main_Resources.MsgBox_RomRemoved_Titel, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            Close()
        End If
    End Sub

    Private Sub Controller_RomChangesAvaiable(e As RomChangesAvaiableEventArgs) Handles Controller.RomChangesAvailable
        NotifyRomChangesAvailable(e.Mute)
    End Sub

    Private Sub Controller_RequestIsChangingTab(e As EnabledEventArgs) Handles Controller.RequestIsChangingTab
        e.Enabled = changingTab
    End Sub

    'R o m   C h a n g e s   N o t i f i c a t i o n

    Private Sub NotifyRomChangesAvailable(ByRef mute As Boolean)
        Dim notifyMode As NotificationMode = Settings.General.RomChangedNotification
        Dim showWarningBox As Boolean = notifyMode = NotificationMode.Infobox

        'Show popup
        If notifyMode = NotificationMode.Popup AndAlso Not mute Then
            Dim tdinfo As New TaskDialogInfo With {
                .Title = Form_Main_Resources.MsgBox_RomChanged_Title,
                .Header = Form_Main_Resources.MsgBox_RomChanged_Title,
                .TaskDialogIcon = eTaskDialogIcon.Information,
                .Text = Form_Main_Resources.MsgBox_RomChanged,
                .DialogButtons = eTaskDialogButton.Yes Or eTaskDialogButton.No
            }
            Select Case TaskDialog.Show(tdinfo)
                Case eTaskDialogResult.Yes
                    Controller.ReloadRom()
                    showWarningBox = False
                Case Else
                    showWarningBox = True
                    mute = True
            End Select
        End If

        'Create WarningBox
        If showWarningBox AndAlso WarningBox_RomChanged Is Nothing Then
            WarningBox_RomChanged = New WarningBox With {
                .Text = Form_Main_Resources.WarningBox_RomChanged_Text,
                .OptionsText = Form_Main_Resources.WarningBox_RomChanged_ReloadRom,
                .Dock = DockStyle.Top,
                .CloseButtonVisible = False
            }
            AddHandler WarningBox_RomChanged.OptionsClick, AddressOf WarningBox_RomChanged_OptionsClick
            AddHandler WarningBox_RomChanged.CloseClick, AddressOf WarningBox_RomChanged_CloseClick
        End If

        'Set Warningbox size and add it
        If WarningBox_RomChanged IsNot Nothing AndAlso showWarningBox Then
            If Not Panel1.Controls.Contains(WarningBox_RomChanged) Then
                Panel1.Controls.Add(WarningBox_RomChanged)
            End If

            TabControl1.Top += WarningBox_RomChanged.Height
            TabControl1.Height -= WarningBox_RomChanged.Height
            WarningBox_RomChanged.Visible = True
            WarningBox_RomChanged.BringToFront()
        End If
    End Sub

    Private Sub WarningBox_RomChanged_CloseClick(sender As Object, e As EventArgs)
        WarningBox_RomChanged.Visible = False
        TabControl1.Top -= WarningBox_RomChanged.Height
        TabControl1.Height += WarningBox_RomChanged.Height
    End Sub

    Private Sub WarningBox_RomChanged_OptionsClick(sender As Object, e As EventArgs)
        'Reload ROM
        Controller.ReloadRom()

        'Close WarningBox
        WarningBox_RomChanged_CloseClick(sender, e)
    End Sub

    'R e c e n t   R O M s

    Private Sub LoadRecentROMs()
        tabGeneral.ItemPanel_RecentFiles.Items.Clear()

        Dim di_Open As New ButtonItem With {.Text = Form_Main_Resources.Button_OpenRom, .Image = MyIcons.icons8_open_folder_16px, .ButtonStyle = eButtonStyle.ImageAndText} ', .SymbolSet = eSymbolSet.Material, .Symbol = "58055", .SymbolColor = Color.FromArgb(215, 172, 106), .SymbolSize = 12
        AddHandler di_Open.Click, AddressOf MenuItem_OpenROM_Click
        tabGeneral.ItemPanel_RecentFiles.Items.Add(di_Open)

        Dim cindex As Integer = 1
        MergeRecentFiles(Settings.RecentFiles.RecentROMs)
        For Each r As String In Settings.RecentFiles.RecentROMs
            If File.Exists(r) Then
                Dim bi As New ButtonItem
                bi.Text = Path.GetFileName(r)
                bi.Tooltip = r
                bi.Image = ExtractIcon(r, True).ToBitmap
                bi.ButtonStyle = eButtonStyle.ImageAndText
                If cindex = 1 Then bi.BeginGroup = True
                AddHandler bi.Click, AddressOf MenuItem_RecentROMs_Click
                tabGeneral.ItemPanel_RecentFiles.Items.Add(bi)
                cindex += 1
            End If
        Next

        tabGeneral.ItemPanel_RecentFiles.Refresh()
    End Sub

    Private Sub MenuItem_OpenROM_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Controller.OpenRom()
    End Sub

    Private Sub MenuItem_RecentROMs_Click(sender As Object, e As EventArgs)
        If Controller.OpenRom(Settings.RecentFiles.RecentROMs(tabGeneral.ItemPanel_RecentFiles.Items.IndexOf(sender) - 1)) Then
            tabGeneral.Refresh()
        End If
    End Sub

    'G u i

    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshAppTitel()
    End Sub

    Private Async Sub Form_Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Controller.StatusText = Form_Main_Resources.Status_StartingUp

        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top

        LoadRecentROMs()
        tabLevelManager.LoadObjectBankListBoxEntries()
        finishedLoading = True

        Controller.StatusText = String.Empty

        Controller.CheckCommandLineArgs()

        Controller.LoadPlugins()
        AddMyPluginCommands()

        If Settings.Network.AutoUpdates Then
            Await Controller.SearchForUpdates(True)
        End If
    End Sub

    Private Sub AddMyPluginCommands()
        Dim lastFunc As PluginSystem.PluginFunction = Nothing
        Dim isFirst As Boolean = True

        For Each func As PluginSystem.PluginFunction In PluginManager.GetFunctions("pluginmenu")
            Dim btn As New ButtonItem

            If lastFunc IsNot func Then
                lastFunc = func
            End If

            btn.Text = func.Params(0)
            btn.Tag = func

            AddHandler btn.Click,
                Sub(sender As ButtonItem, e As EventArgs)
                    CType(sender.Tag, PluginSystem.PluginFunction).Invoke()
                End Sub

            ButtonItem_Bar_Plugins.BeginGroup = isFirst
            ButtonItem_Bar_Plugins.SubItems.Add(btn)

            isFirst = False
        Next

        Bar2.Refresh()
    End Sub

    Private Sub RefreshAppTitel()
        Dim appversion As New Version(Application.ProductVersion)
        Dim romPathExt As String = If(Controller.Romfile <> "", $" - ""{Path.GetFileName(Controller.Romfile)}""", "")
        Dim versionText As String = $"v{appversion.ToString(If(appversion.Revision <> 0, 4, If(appversion.Build <> 0, 3, 2)))}"

        If Not String.IsNullOrEmpty(DevelopmentStage) Then
            Dim addDevelopmentalNumber As Boolean = True

            Select Case DevelopmentStage
                Case 3
                    versionText &= " Alpha"
                Case 2
                    versionText &= " Beta"
                Case 1
                    versionText &= " RC"
                Case 0
                    addDevelopmentalNumber = False
            End Select

            If addDevelopmentalNumber Then
                versionText &= " " & DevelopmentBuild
            End If
        End If

        Text = $"{Application.ProductName} ({versionText}){romPathExt}"
    End Sub

    Private Sub TabControl_Main_SelectedIndexChanged(sender As TabControl, e As TabStripTabChangedEventArgs) Handles TabControl1.SelectedTabChanged
        changingTab = False

        If e IsNot Nothing Then
            Select Case True
                Case e.NewTab Is TabItem_TextManager
                    Controller.TextManagerController.SendRequestReloadTextManagerLists()
                Case Else
                    If e.OldTab Is TabItem_TextManager Then
                        Controller.SetOtherStatusInfos(String.Empty, Nothing)
                    End If
            End Select
        End If
    End Sub

    Private Sub MenuItem11_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        Environment.Exit(Environment.ExitCode)
    End Sub

    Private Async Sub MenuItem_LaunchROM_Click(sender As Object, e As EventArgs) Handles ButtonItem_LaunchROM.Click
        Await Controller.WaitWhileSavingRom()
        Controller.LaunchRom()
    End Sub

    Private Sub ButtonItem12_Click(sender As Object, e As EventArgs) Handles ButtonItem_SaveRom.Click
        Controller.SaveRom()
    End Sub

    Private Sub Form_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Controller.DoesRomManagerNeedToSave Then
            Select Case MessageBoxEx.Show(Form_Main_Resources.MsgBox_UnsavedChanges, Form_Main_Resources.MsgBox_UnsavedChanges_Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    If Not Controller.SaveRom Then
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
        Controller.OpenSettings()
    End Sub

    Private Sub MenuItem_About_Click(sender As Object, e As EventArgs) Handles ButtonItem30.Click
        Controller.OpenAbout()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Controller.OpenTextConverter()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        Controller.OpenStyleManager()
    End Sub

    Private Async Sub ButtonItem29_Click(sender As Object, e As EventArgs) Handles ButtonItem29.Click
        If Not Await Controller.SearchForUpdates(False) Then
            ShowToadnotifiaction(Me, "Cannot connect to the update server.", eToastGlowColor.Red)
        End If
    End Sub

    Private Sub SuperTabControl_Main_SelectedTabChanging(sender As Object, e As TabStripTabChangingEventArgs) Handles TabControl1.SelectedTabChanging
        changingTab = True

        If finishedLoading Then
            If Not Controller.HasRomManager AndAlso e.NewTab IsNot TabItem_General Then
                e.Cancel = True
                ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
            End If
        End If
    End Sub

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem23.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.UpdateChecksum()
        End If
    End Sub

    Private Sub ButtonItem_ModelImporter_Click(sender As Object, e As EventArgs) Handles ButtonItem_ModelImporter.Click
        Controller.OpenModelImporter()
    End Sub

    Private Sub ButtonItem17_Click(sender As Object, e As EventArgs) Handles ButtonItem17.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenTweakViewer()
        End If
    End Sub

    Private Sub ButtonItem_TrajectoryEditor_Click(sender As Object, e As EventArgs) Handles ButtonItem_TrajectoryEditor.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenTrajectoryEditor()
        End If
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

    Private Sub ButtonItem15_Click(sender As Object, e As EventArgs) Handles ButtonItem15.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenRgbEditor()
        End If
    End Sub

    Private Sub ButtonItem16_Click(sender As Object, e As EventArgs) Handles ButtonItem16.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenCoinsEditor()
        End If
    End Sub

    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Controller.CheckRomChanged()
    End Sub

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs) Handles ButtonItem9.Click
        Controller.OpenApplyPPFDialog()
    End Sub

    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs) Handles ButtonItem14.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenItemBoxContentEditor()
        End If
    End Sub

    Private Sub ButtonItem13_Click(sender As Object, e As EventArgs) Handles ButtonItem13.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenStarPositionEditor()
        End If
    End Sub

    Private Sub ButtonItem_M64ToMidiConverter_Click(sender As Object, e As EventArgs) Handles ButtonItem_M64ToMidiConverter.Click
        Controller.ConvertM64ToMidi()
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs) Handles ButtonItem19.Click
        Controller.TextManagerController.OpenTextProfileEditor()
    End Sub

    Private Sub ButtonItem18_Click(sender As Object, e As EventArgs) Handles ButtonItem18.Click
        If Not Controller.HasRomManager Then
            ShowToadnotifiaction(Me, Form_Main_Resources.Notify_ShouldLoadRomFirst, eToastGlowColor.Red)
        Else
            Controller.OpenGlobalObjectBankManager()
        End If
    End Sub

    Private Sub ButtonItem_Bar_Plugins_ManagePlugins_Click(sender As Object, e As EventArgs) Handles ButtonItem_Bar_Plugins_ManagePlugins.Click, ButtonItem20.Click
        Controller.OpenPluginManager()
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Controller.OpenObjectBankDataEditor()
    End Sub

    Private Sub ButtonItem_BugReport_Click(sender As Object, e As EventArgs) Handles ButtonItem_BugReport.Click
        Controller.OpenBugReportDialog()
    End Sub

    Private Sub ButtonItem_FeatureRequest_Click(sender As Object, e As EventArgs) Handles ButtonItem_FeatureRequest.Click
        Controller.OpenFeatureRequestDialog()
    End Sub

End Class
