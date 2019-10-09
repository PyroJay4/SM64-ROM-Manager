Imports DevComponents.DotNetBar
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class PluginInstallerForm

    'C o n s t r u c t o r s

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors
    End Sub

    'F e a t u r e s

    Private Sub LoadAllPlugins()
        ListViewEx_Plugins.SuspendLayout()
        ListViewEx_Plugins.Items.Clear()

        For Each p As PluginInfo In GetAllPlugins()
            Dim lvi As New ListViewItem With {
                .Tag = p,
                .Text = p.Name
            }
            lvi.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = p.Version.ToString})
            lvi.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = p.Developer})
            lvi.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = p.Location})
            ListViewEx_Plugins.Items.Add(lvi)
        Next

        ListViewEx_Plugins.ResumeLayout()
    End Sub

    Private Function GetSelectedPlugins() As IEnumerable(Of PluginInfo)
        Dim items As ListView.SelectedListViewItemCollection = ListViewEx_Plugins.SelectedItems
        Dim plugins As New List(Of PluginInfo)

        For Each item As ListViewItem In items
            If TypeOf item.Tag Is PluginInfo Then
                plugins.Add(item.Tag)
            End If
        Next

        Return plugins
    End Function

    Private Sub RemoveSelectedItems()
        Dim plugins As IEnumerable(Of PluginInfo) = GetSelectedPlugins()

        For Each p As PluginInfo In plugins
            RemovePlugin(p)
        Next

        If plugins.Any Then
            LoadAllPlugins()
        End If
    End Sub

    Private Sub InstallPlugin(ext As String, installDir As Boolean)
        Dim ofd As New CommonOpenFileDialog

        If installDir Then
            ofd.IsFolderPicker = True
        Else
            Dim extFilter As String = $"*.{ext}"
            ofd.Filters.Add(New CommonFileDialogFilter(extFilter, extFilter))
        End If

        If ofd.ShowDialog = CommonFileDialogResult.Ok Then
            InstallPluginFrom(ofd.FileName, installDir)
        End If
    End Sub

    'G U I

    Private Sub PluginInstallerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListViewEx_Plugins.ResetHeaderHandler()
    End Sub

    Private Sub PluginInstallerForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadAllPlugins()
    End Sub

    Private Sub ButtonX_Close_Click(sender As Object, e As EventArgs) Handles ButtonX_Close.Click
        Close()
    End Sub

    Private Sub ButtonX_Remove_Click(sender As Object, e As EventArgs) Handles ButtonX_Remove.Click
        Try
            RemoveSelectedItems()
        Catch ex As InvalidOperationException
            MessageBoxEx.Show(ex.Message, "Plugin is used", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonItem_SingleFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_SingleFile.Click
        InstallPlugin("dll", False)
    End Sub

    Private Sub ButtonItem_ZipFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_ZipFile.Click
        InstallPlugin("zip", False)
    End Sub

    Private Sub ButtonItem_Directory_Click(sender As Object, e As EventArgs) Handles ButtonItem_Directory.Click
        InstallPlugin(String.Empty, True)
    End Sub

End Class
