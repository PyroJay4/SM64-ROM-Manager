Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.SettingsManager
Imports TextValueConverter
Imports Publics

Public Class Form_Settings

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Me.UpdateAmbientColors

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        'StyleManager.UpdateAmbientColors(Me)
        ComboBoxEx_LoaderModule.Items.AddRange([Enum].GetNames(GetType(S3DFileParser.LoaderModule)))

    End Sub

    Private Sub Form_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxX_EmulatorPatch.Text = Settings.General.EmulatorPath
        SwitchButton_SearchUpdates.Value = Settings.General.AutoUpdates
        ComboBox_DefaultValueType.SelectedIndex = Settings.General.IntegerValueMode
        ComboBox_AreaEditor_DefaultCameraMode.SelectedIndex = Settings.AreaEditor.DefaultCameraMode
        ComboBox_AreaEditor_DefaultWindowMode.SelectedIndex = If(Settings.AreaEditor.DefaultWindowMode = FormWindowState.Maximized, 1, 0)
        ComboBoxEx_LoaderModule.SelectedIndex = Settings.FileParser.LoaderModule
        TextBoxX_HexEditorCustomPath.Text = Settings.General.HexEditMode.CustomPath

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

        Select Case Settings.General.AutoScaleMode
            Case AutoScaleMode.None
                ComboBoxEx_AutoScaleMode.SelectedIndex = 0
            Case AutoScaleMode.Dpi
                ComboBoxEx_AutoScaleMode.SelectedIndex = 1
            Case AutoScaleMode.Font
                ComboBoxEx_AutoScaleMode.SelectedIndex = 2
        End Select
    End Sub

    Private Sub Form_Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Settings.General.EmulatorPath = TextBoxX_EmulatorPatch.Text.Trim
        Settings.General.IntegerValueMode = ComboBox_DefaultValueType.SelectedIndex
        Settings.General.AutoUpdates = SwitchButton_SearchUpdates.Value
        Settings.AreaEditor.DefaultCameraMode = ComboBox_AreaEditor_DefaultCameraMode.SelectedIndex
        Settings.AreaEditor.DefaultWindowMode = If(ComboBox_AreaEditor_DefaultWindowMode.SelectedIndex = 1, FormWindowState.Maximized, FormWindowState.Normal)
        Settings.FileParser.LoaderModule = ComboBoxEx_LoaderModule.SelectedIndex

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
        For Each from As Form In Application.OpenForms
            from.SetValue("AutoScaleMode", Settings.General.AutoScaleMode)
        Next
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
End Class
