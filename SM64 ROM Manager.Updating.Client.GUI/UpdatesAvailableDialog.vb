Imports DevComponents.DotNetBar

Friend Class UpdatesAvailableDialog

    Public Sub New(appIcon As Image, curVersion As String, curChannel As String, curBuild As String, newVersion As String, newChannel As String, newBuild As String, changelog As String, installAsAdmin As Boolean)
        InitializeComponent()
        StyleManager.UpdateAmbientColors(Me)

        If installAsAdmin Then
            ButtonX_Install.Image = GetUacShieldImage()
        End If

        PictureBox_AppIcon.Image = If(appIcon, Icon.ToBitmap)
        LabelX_CurrentVersion.Text = curVersion
        LabelX_CurrentChannel.Text = curChannel
        LabelX_CurrentBuild.Text = curBuild
        LabelX_NewVersion.Text = newVersion
        LabelX_NewChannel.Text = newChannel
        LabelX_NewBuild.Text = newBuild
        RichTextBoxEx_Changelog.Text = changelog
    End Sub

End Class
