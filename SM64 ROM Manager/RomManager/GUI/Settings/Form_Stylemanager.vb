Imports DevComponents.DotNetBar
Imports SettingsManager

Public Class Form_Stylemanager

    Private isLoading As Boolean = True
    Private themes As Metro.ColorTables.MetroColorGeneratorParameters()

    Public Property StyleManager As StyleManager = Nothing

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors()

    End Sub

    Private Sub Form_Stylemanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxEx1.Items.Clear()
        themes = Metro.ColorTables.MetroColorGeneratorParameters.GetAllPredefinedThemes
        For Each s In themes
            ComboBoxEx1.Items.Add(s.ThemeName)
        Next
        ComboBoxEx1.SelectedIndex = Array.IndexOf(themes, Settings.StyleManager.MetroColorParams)
        CheckBoxX_KeepEditorControlBarBlue.Checked = Settings.StyleManager.AlwaysKeepBlueColors
        isLoading = False
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Controls.ComboBoxEx, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        If isLoading Then Return
        Dim newTheme = themes(sender.SelectedIndex)
        StyleManager.MetroColorParameters = newTheme
        Settings.StyleManager.MetroColorParams = newTheme

        For Each frm As Form In Application.OpenForms
            frm.UpdateAmbientColors()
        Next
    End Sub

    Private Sub CheckBoxX_KeepEditorControlBarBlue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX_KeepEditorControlBarBlue.CheckedChanged
        If isLoading Then Return
        Settings.StyleManager.AlwaysKeepBlueColors = sender.Checked
    End Sub
End Class