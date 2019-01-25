Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports DevComponents.Editors
Imports SM64_ROM_Manager.SettingsManager

Public Class Form_Stylemanager

    Private isLoading As Boolean = True

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors()

    End Sub

    Private Sub Form_Stylemanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxEx1.Items.Clear()

        Dim themes As MetroColorGeneratorParameters() = {StyleManagerSettingsStruc.VisualThemeLight, StyleManagerSettingsStruc.VisualThemeGray, StyleManagerSettingsStruc.VisualThemeDark} 'MetroColorGeneratorParameters.GetAllPredefinedThemes
        Dim myTheme As MetroColorGeneratorParameters = Settings.StyleManager.MetroColorParams
        Dim ciToSelect As ComboItem = Nothing

        For Each s In themes
            Dim item As New ComboItem

            item.Text = s.ThemeName
            item.Tag = s

            If myTheme.CanvasColor.ToArgb = s.CanvasColor.ToArgb AndAlso myTheme.BaseColor.ToArgb = s.BaseColor.ToArgb Then
                ciToSelect = item
            End If

            ComboBoxEx1.Items.Add(item)
        Next

        If ciToSelect IsNot Nothing Then
            ComboBoxEx1.SelectedItem = ciToSelect
        ElseIf ComboBoxEx1.Items.Count > 0 Then
            ComboBoxEx1.SelectedIndex = 0
        End If

        If Settings.StyleManager.UseWindows10Style Then
            CheckBoxX1.Checked = True
        Else
            CheckBoxX2.Checked = True
        End If

        CheckBoxX_KeepEditorControlBarBlue.Checked = Settings.StyleManager.AlwaysKeepBlueColors

        isLoading = False
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged, CheckBoxX1.CheckedChanged
        If isLoading Then Return

        Dim newTheme As MetroColorGeneratorParameters = CType(ComboBoxEx1.SelectedItem, ComboItem).Tag
        Settings.StyleManager.MetroColorParams = newTheme
        Settings.StyleManager.UseWindows10Style = CheckBoxX1.Checked

        Publics.SetVisualTheme()

        For Each frm As Form In Application.OpenForms
            frm.UpdateAmbientColors()
            frm.Refresh()
        Next
    End Sub

    Private Sub CheckBoxX_KeepEditorControlBarBlue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX_KeepEditorControlBarBlue.CheckedChanged
        If isLoading Then Return
        Settings.StyleManager.AlwaysKeepBlueColors = sender.Checked
    End Sub

    Private Sub Form_Stylemanager_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Settings.SaveSettings()
    End Sub

    Private Sub CheckBoxX2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX2.CheckedChanged
        ComboBoxEx1.Enabled = CheckBoxX2.Checked
    End Sub

End Class