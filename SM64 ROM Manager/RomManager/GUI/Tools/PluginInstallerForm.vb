Public Class PluginInstallerForm

    'C o n s t r u c t o r s

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors
    End Sub

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

    Private Function GetSelectedPlugin() As IEnumerable(Of PluginInfo)
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
        Dim plugins As IEnumerable(Of PluginInfo) = GetSelectedPlugin()

        For Each p As PluginInfo In plugins
            RemovePlugin(p)
        Next

        If plugins.Any Then
            LoadAllPlugins()
        End If
    End Sub

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
        RemoveSelectedItems()
    End Sub

    Private Sub ButtonItem_SingleFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_SingleFile.Click

    End Sub

    Private Sub ButtonItem_ZipFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_ZipFile.Click

    End Sub

    Private Sub ButtonItem_Directory_Click(sender As Object, e As EventArgs) Handles ButtonItem_Directory.Click

    End Sub

End Class
