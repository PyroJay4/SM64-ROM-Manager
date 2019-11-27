Imports System.IO
Imports DevComponents.DotNetBar
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports SM64_ROM_Manager.My.Resources

Public Class PluginInstallerForm

    'M e m b e r s

    Private Shared removedPlugins As New List(Of PluginInfo)

    'C o n s t r u c t o r s

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors
    End Sub

    'F e a t u r e s

    Private Sub LoadAllPlugins()
        ListViewEx_Plugins.SuspendLayout()

        LoadInstalledPlugins()
        LoadRemovedPlugins()

        ListViewEx_Plugins.ResumeLayout()
    End Sub

    Private Sub LoadInstalledPlugins()
        LoadPlugins(ListViewEx_Plugins.Groups("Lvg_Installed"), GetAllPlugins.Where(Function(n) Not removedPlugins.Where(Function(b) b.Plugin Is n.Plugin).Any))
    End Sub

    Private Sub LoadRemovedPlugins()
        LoadPlugins(ListViewEx_Plugins.Groups("Lvg_Removed"), removedPlugins)
    End Sub

    Private Sub LoadPlugins(lvg As ListViewGroup, plugins As IEnumerable(Of PluginInfo))
        ListViewEx_Plugins.SuspendLayout()

        Dim itemsToRemove As New List(Of ListViewItem)
        For Each item As ListViewItem In ListViewEx_Plugins.Items
            If item.Group Is lvg Then
                itemsToRemove.Add(item)
            End If
        Next
        For Each item As ListViewItem In itemsToRemove
            ListViewEx_Plugins.Items.Remove(item)
        Next

        For Each p As PluginInfo In plugins
            ListViewEx_Plugins.Items.Add(GetListViewItem(p, lvg))
        Next

        ListViewEx_Plugins.ResumeLayout()
    End Sub

    Private Function GetListViewItem(p As PluginInfo, lvg As ListViewGroup) As ListViewItem
        Dim lvi As New ListViewItem With {
                .Tag = p,
                .Text = p.Name,
                .Group = lvg
            }

        lvi.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = p.Version.ToString})
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = p.Developer})
        lvi.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = p.Location})

        Return lvi
    End Function

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

        Try
            For Each p As PluginInfo In plugins
                RemovePlugin(p)
                removedPlugins.Add(p)
            Next

            If plugins.Any Then
                LoadAllPlugins()
            End If

            MessageBoxEx.Show(Plugin_Installer_Resources.MsgBox_PluginInstalled, Plugin_Installer_Resources.MsgBox_PluginInstalled_Titel, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As InvalidOperationException
            MessageBoxEx.Show(ex.Message, Plugin_Installer_Resources.MsgBox_PluginInstalled_Error_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InstallPlugin(ext As String, filterName As String, installDir As Boolean)
        Dim ofd As New CommonOpenFileDialog

        If installDir Then
            ofd.IsFolderPicker = True
        Else
            ofd.Filters.Add(New CommonFileDialogFilter(filterName, $"*.{ext}"))
        End If

        If ofd.ShowDialog() = CommonFileDialogResult.Ok Then
            Try
                'Install Plugin
                Dim res = InstallPluginFrom(ofd.FileName, installDir)

                'Load Plugin
                If res.isDirectory Then
                    Publics.PluginManager.LoadPlugins(res.destinationPath)
                Else
                    Publics.PluginManager.LoadPlugin(res.destinationPath)
                End If

                'Reload list
                LoadInstalledPlugins()

                MessageBoxEx.Show(Plugin_Installer_Resources.MsgBox_PluginRemoved, Plugin_Installer_Resources.MsgBox_PluginRemoved_Titel, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As InvalidOperationException
                MessageBoxEx.Show(ex.Message, Plugin_Installer_Resources.MsgBox_PluginRemoved_Error_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
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
        InstallPlugin("dll", String.Empty, False)
    End Sub

    Private Sub ButtonItem_ZipFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_ZipFile.Click
        InstallPlugin("zip", String.Empty, False)
    End Sub

    Private Sub ButtonItem_Directory_Click(sender As Object, e As EventArgs) Handles ButtonItem_Directory.Click
        InstallPlugin(String.Empty, String.Empty, True)
    End Sub

End Class
