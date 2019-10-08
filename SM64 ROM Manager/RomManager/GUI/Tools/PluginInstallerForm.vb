Public Class PluginInstallerForm



    Private Sub PluginInstallerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewEx_Plugins.ResetHeaderHandler()
    End Sub

    Private Sub ButtonX_Close_Click(sender As Object, e As EventArgs) Handles ButtonX_Close.Click
        Close()
    End Sub

    Private Sub ButtonX_Remove_Click(sender As Object, e As EventArgs) Handles ButtonX_Remove.Click

    End Sub

    Private Sub ButtonItem_SingleFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_SingleFile.Click

    End Sub

    Private Sub ButtonItem_ZipFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_ZipFile.Click

    End Sub

    Private Sub ButtonItem_Directory_Click(sender As Object, e As EventArgs) Handles ButtonItem_Directory.Click

    End Sub

End Class