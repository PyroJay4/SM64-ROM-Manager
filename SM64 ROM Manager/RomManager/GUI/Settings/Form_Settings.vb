Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib.TextValueConverter
Imports SM64_ROM_Manager.Publics
Imports DevComponents.Editors
Imports System.Globalization
Imports System.IO
Imports Pilz.S3DFileParser

Public Class Form_Settings

    Private finishedLoading As Boolean = False
    Private ReadOnly crypter As New drsPwEnc.drsPwEnc

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors

        SuperTooltip1.SetSuperTooltip(PictureBox_Warning, New SuperTooltipInfo("Warning", "", "Some changes will completly affect only after a restart of the programm.", Nothing, Nothing, eTooltipColor.System, True, False, Nothing))

        For Each lm In GetAllLoaderModules()
            Dim item As New ComboItem With {
                .Text = lm.Name,
                .Tag = lm}
            ComboBoxEx_LoaderModule.Items.Add(item)
        Next

        For Each lm In GetAllExporterModules()
            Dim item As New ComboItem With {
                .Text = lm.Name,
                .Tag = lm}
            ComboBoxEx_ExporterModule.Items.Add(item)
        Next

        For Each f As String In Directory.GetDirectories(MyDataPath & "\Lang")
            Dim name As String = Path.GetFileName(f)
            Dim cult As New CultureInfo(name)
            If cult IsNot Nothing Then
                ComboBoxEx_Language.Items.Add(New ComboItem With {.Text = cult.NativeName, .Tag = cult})
            End If
        Next
    End Sub

    Private Sub Form_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMySettings()
    End Sub

    Private Sub Form_Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveMySettings()
        PostSaveSettings
    End Sub

    Private Sub LoadMySettings()
        TextBoxX_EmulatorPatch.Text = Settings.General.EmulatorPath
        SwitchButton_SearchUpdates.Value = Settings.Network.AutoUpdates
        ComboBox_DefaultValueType.SelectedIndex = Settings.General.IntegerValueMode
        ComboBox_AreaEditor_DefaultCameraMode.SelectedIndex = Settings.AreaEditor.DefaultCameraMode
        ComboBox_AreaEditor_DefaultWindowMode.SelectedIndex = If(Settings.AreaEditor.DefaultWindowMode = FormWindowState.Maximized, 1, 0)
        TextBoxX_HexEditorCustomPath.Text = Settings.General.HexEditMode.CustomPath
        SwitchButton_UseLegacyCollisionDescriptions.Value = Settings.ModelConverter.UseLegacyCollisionDescriptions
        SwitchButton_TMForceUppercase.Value = Settings.TextManager.ForceUpperCaseForActAndLevelNames
        TextBoxX_ProxyUsr.Text = Settings.Network.ProxyUsername
        TextBoxX_ProxyPwd.Text = If(String.IsNullOrEmpty(Settings.Network.ProxyPasswordEncrypted), String.Empty, crypter.DecryptData(Settings.Network.ProxyPasswordEncrypted))

        Dim curLoaderModule As File3DLoaderModule = GetLoaderModuleFromID(Settings.FileParser.FileLoaderModule)
        For Each item As ComboItem In ComboBoxEx_LoaderModule.Items
            If item.Tag Is curLoaderModule Then
                ComboBoxEx_LoaderModule.SelectedItem = item
            End If
        Next

        Dim curExporterModule As File3DLoaderModule = GetExporterModuleFromID(Settings.FileParser.FileExporterModule)
        For Each item As ComboItem In ComboBoxEx_ExporterModule.Items
            If item.Tag Is curExporterModule Then
                ComboBoxEx_ExporterModule.SelectedItem = item
            End If
        Next

        Select Case Settings.General.ActionIfUpdatePatches
            Case DialogResult.None
                ComboBoxEx1.SelectedIndex = 0
            Case DialogResult.Yes
                ComboBoxEx1.SelectedIndex = 1
            Case DialogResult.No
                ComboBoxEx1.SelectedIndex = 2
        End Select

        Select Case Settings.General.HexEditMode.Mode
            Case HexEditModes.BuildInHexEditor
                ComboBoxEx_HexEditorMode.SelectedIndex = 0
            Case HexEditModes.CustomHexEditor
                ComboBoxEx_HexEditorMode.SelectedIndex = 1
        End Select

        For Each item As ComboItem In ComboBoxEx_Language.Items
            If item.Tag Is Nothing Then
                If String.IsNullOrEmpty(Settings.General.Language) Then
                    ComboBoxEx_Language.SelectedIndex = 0
                End If
            ElseIf CType(item.Tag, CultureInfo).Name = Settings.General.Language Then
                ComboBoxEx_Language.SelectedItem = item
            End If
        Next

        Select Case Settings.General.AutoScaleMode
            Case AutoScaleMode.None
                ComboBoxEx_AutoScaleMode.SelectedIndex = 0
            Case AutoScaleMode.Dpi
                ComboBoxEx_AutoScaleMode.SelectedIndex = 1
            Case AutoScaleMode.Font
                ComboBoxEx_AutoScaleMode.SelectedIndex = 2
        End Select

        Select Case Settings.General.RomChangedNotification
            Case NotificationMode.Off
                ComboBoxEx_NotifyOnRomChanges.SelectedIndex = 0
            Case NotificationMode.Infobox
                ComboBoxEx_NotifyOnRomChanges.SelectedIndex = 1
            Case NotificationMode.Popup
                ComboBoxEx_NotifyOnRomChanges.SelectedIndex = 2
        End Select

        Select Case Settings.Network.MinimumUpdateChannel
            Case Updating.Channels.Alpha
                ComboBoxEx_UpdateLevel.SelectedIndex = 2
            Case Updating.Channels.Beta
                ComboBoxEx_UpdateLevel.SelectedIndex = 1
            Case Updating.Channels.Stable
                ComboBoxEx_UpdateLevel.SelectedIndex = 0
        End Select

        finishedLoading = True
    End Sub

    Private Sub SaveMySettings()
        Settings.General.EmulatorPath = TextBoxX_EmulatorPatch.Text.Trim
        Settings.General.IntegerValueMode = ComboBox_DefaultValueType.SelectedIndex
        Settings.Network.AutoUpdates = SwitchButton_SearchUpdates.Value
        Settings.AreaEditor.DefaultCameraMode = ComboBox_AreaEditor_DefaultCameraMode.SelectedIndex
        Settings.AreaEditor.DefaultWindowMode = If(ComboBox_AreaEditor_DefaultWindowMode.SelectedIndex = 1, FormWindowState.Maximized, FormWindowState.Normal)
        Settings.FileParser.FileLoaderModule = GetLoaderIDFromModule(CType(ComboBoxEx_LoaderModule.SelectedItem, ComboItem).Tag)
        Settings.FileParser.FileExporterModule = GetExporterIDFromModule(CType(ComboBoxEx_ExporterModule.SelectedItem, ComboItem).Tag)
        Settings.ModelConverter.UseLegacyCollisionDescriptions = SwitchButton_UseLegacyCollisionDescriptions.Value
        Settings.TextManager.ForceUpperCaseForActAndLevelNames = SwitchButton_TMForceUppercase.Value
        Settings.Network.ProxyUsername = TextBoxX_ProxyUsr.Text.Trim
        Settings.Network.ProxyPasswordEncrypted = If(String.IsNullOrEmpty(TextBoxX_ProxyPwd.Text), String.Empty, crypter.EncryptData(TextBoxX_ProxyPwd.Text))

        Select Case ComboBoxEx1.SelectedIndex
            Case 0
                Settings.General.ActionIfUpdatePatches = DialogResult.None
            Case 1
                Settings.General.ActionIfUpdatePatches = DialogResult.Yes
            Case 2
                Settings.General.ActionIfUpdatePatches = DialogResult.No
        End Select

        Select Case ComboBoxEx_HexEditorMode.SelectedIndex
            Case 0
                Settings.General.HexEditMode.Mode = HexEditModes.BuildInHexEditor
                Settings.General.HexEditMode.CustomPath = String.Empty
            Case 1
                Settings.General.HexEditMode.Mode = HexEditModes.CustomHexEditor
                Settings.General.HexEditMode.CustomPath = TextBoxX_HexEditorCustomPath.Text.Trim
        End Select

        Select Case ComboBoxEx_AutoScaleMode.SelectedIndex
            Case 0
                Settings.General.AutoScaleMode = AutoScaleMode.None
            Case 1
                Settings.General.AutoScaleMode = AutoScaleMode.Dpi
            Case 2
                Settings.General.AutoScaleMode = AutoScaleMode.Font
        End Select

        Select Case ComboBoxEx_NotifyOnRomChanges.SelectedIndex
            Case 0
                Settings.General.RomChangedNotification = NotificationMode.Off
            Case 1
                Settings.General.RomChangedNotification = NotificationMode.Infobox
            Case 2
                Settings.General.RomChangedNotification = NotificationMode.Popup
        End Select

        Select Case ComboBoxEx_UpdateLevel.SelectedIndex
            Case 0
                Settings.Network.MinimumUpdateChannel = Updating.Channels.Stable
            Case 1
                Settings.Network.MinimumUpdateChannel = Updating.Channels.Beta
            Case 2
                Settings.Network.MinimumUpdateChannel = Updating.Channels.Alpha
        End Select

        Dim selLangItem As ComboItem = ComboBoxEx_Language.SelectedItem
        If selLangItem.Tag Is Nothing Then
            Settings.General.Language = String.Empty
        Else
            Dim cult As CultureInfo = selLangItem.Tag
            Settings.General.Language = cult.Name
        End If
        SetCurrentLanguageCulture(Settings.General.Language)

        For Each from As Form In Application.OpenForms
            from.SetValue("AutoScaleMode", Settings.General.AutoScaleMode)
        Next
    End Sub

    Private Sub PostSaveSettings()
        SetDefaultProxyAuthentification()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim frm As New LevelEditorInputManager
        frm.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        TextBoxX_EmulatorPatch.Text = ""
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        OpenExcuteableFile(TextBoxX_EmulatorPatch, "Select Emulator .exe File ...")
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Settings.ResetSettings()
        LoadMySettings()
    End Sub

    Private Sub Form_Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Settings.SaveSettings()
    End Sub

    Private Sub ComboBoxEx2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx_HexEditorMode.SelectedIndexChanged
        TextBoxX_HexEditorCustomPath.Enabled = ComboBoxEx_HexEditorMode.SelectedIndex = 1
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        OpenExcuteableFile(TextBoxX_HexEditorCustomPath, "Select Hex Editor ...")
    End Sub

    Private Sub OpenExcuteableFile(dest As TextBox, titel As String)
        Dim ofd As New OpenFileDialog With {.Filter = "Executeables (*.exe)|*.exe", .Title = titel}
        If ofd.ShowDialog = DialogResult.OK Then
            dest.Text = ofd.FileName
        End If
    End Sub

    Private Sub ComboBoxEx_Language_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx_Language.SelectedIndexChanged, ComboBoxEx_NotifyOnRomChanges.SelectedIndexChanged, ComboBoxEx_UpdateLevel.SelectedIndexChanged, SwitchButton_UseLegacyCollisionDescriptions.ValueChanged
        EanbleRestartWarning()
    End Sub

    Private Sub EanbleRestartWarning()
        If finishedLoading Then PictureBox_Warning.Visible = True
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        ButtonX6.Enabled = False
    End Sub

End Class
