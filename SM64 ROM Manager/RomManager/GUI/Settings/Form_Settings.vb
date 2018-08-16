Imports DevComponents.DotNetBar
Imports SettingsManager
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
        SwitchButton_UpdateChecksum.Value = Settings.General.AutoUpdateChecksum
        ComboBox_DefaultValueType.SelectedIndex = Settings.General.IntegerValueMode
        SwitchButton_AreaEditor_HistoryFeature.Value = Settings.AreaEditor.EnableHistory
        ComboBox_AreaEditor_DefaultCameraMode.SelectedIndex = Settings.AreaEditor.DefaultCameraMode
        ComboBox_AreaEditor_DefaultWindowMode.SelectedIndex = If(Settings.AreaEditor.DefaultWindowMode = FormWindowState.Maximized, 1, 0)
        ComboBoxEx_LoaderModule.SelectedIndex = Settings.FileParser.LoaderModule

        Select Case Settings.General.ActionIfUpdatePatches
            Case DialogResult.None
                ComboBoxEx1.SelectedIndex = 0
            Case DialogResult.Yes
                ComboBoxEx1.SelectedIndex = 1
            Case DialogResult.No
                ComboBoxEx1.SelectedIndex = 2
        End Select
    End Sub

    Private Sub Form_Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Settings.General.EmulatorPath = TextBoxX_EmulatorPatch.Text.Trim
        Settings.General.AutoUpdateChecksum = SwitchButton_UpdateChecksum.Value
        Settings.General.IntegerValueMode = ComboBox_DefaultValueType.SelectedIndex
        Settings.General.AutoUpdates = SwitchButton_SearchUpdates.Value
        Settings.AreaEditor.EnableHistory = SwitchButton_AreaEditor_HistoryFeature.Value
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
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim frm As New LevelEditorInputManager
        frm.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        TextBoxX_EmulatorPatch.Text = ""
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim ofd As New OpenFileDialog With {.Filter = "Executeables (*.exe)|*.exe", .Title = "Select Emulator .exe File ..."}
        If ofd.ShowDialog = DialogResult.OK Then
            TextBoxX_EmulatorPatch.Text = ofd.FileName
        End If
    End Sub
End Class
