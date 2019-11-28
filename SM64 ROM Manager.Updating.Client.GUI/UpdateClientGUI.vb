Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Threading
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.Updating
Imports SM64_ROM_Manager.Updating.Client.GUI.My.Resources

Public Class UpdateClientGUI

    'F i e l d s

    Private WithEvents UpdateClient As UpdateClient
    Private curProgressDialog As SimpleActionDialog = Nothing

    'P r o p e r t i e s

    Public Property UseHiddenSearch As Boolean = False

    Private ReadOnly Property MyAppIcon As Image
        Get
            Return Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly.Location).ToBitmap
        End Get
    End Property

    'C o n s t r u c t o r s

    Public Sub New(updateClient As UpdateClient)
        Me.UpdateClient = updateClient
    End Sub

    'F e a t u r e s

    Public Sub UpdateInteractive()
        UpdateClient.UpdateInteractive()
    End Sub

    Private Sub EndUpdating()
        curProgressDialog?.Invoke(Sub() curProgressDialog.Close())
        UpdateClient = Nothing
    End Sub

    'U p d a t e C l i e n t - E v e n t s

    Private Sub MyUpdateClient_UpdateStatusChanged(newStatus As UpdateStatus, progress As Integer) Handles UpdateClient.UpdateStatusChanged
        Dim useGui As Boolean = False

        If Not (newStatus = UpdateStatus.Searching AndAlso UseHiddenSearch) Then
            useGui = True
        End If

        If useGui AndAlso curProgressDialog Is Nothing Then
            Dispatcher.CurrentDispatcher.Invoke(
                Sub()
                    curProgressDialog = New SimpleActionDialog
                    curProgressDialog.SetCurrentState(UpdateStatus.Waiting)
                    curProgressDialog.Show()
                End Sub)
        End If

        curProgressDialog?.Invoke(Sub() curProgressDialog.SetCurrentState(newStatus, progress))
    End Sub

    Private Sub MyUpdateClient_DownloadingUpdate(pkg As UpdatePackageInfo, e As CancelEventArgs) Handles UpdateClient.DownloadingUpdate
        Dim dialog As New UpdatesAvailableDialog(MyAppIcon,
                                                 UpdateClient.CurrentVersion.Version.ToString, UpdateClient.CurrentVersion.Channel.ToString, UpdateClient.CurrentVersion.Build,
                                                 pkg.Version.Version.ToString, pkg.Version.Channel.ToString, pkg.Version.Build,
                                                 pkg.Changelog, UpdateClient.InstallAsAdmin)

        curProgressDialog?.Invoke(Sub() curProgressDialog.Hide())

        If dialog.ShowDialog <> DialogResult.OK Then
            e.Cancel = True
            EndUpdating()
        Else
            e.Cancel = False
            curProgressDialog?.Invoke(Sub() curProgressDialog.Show())
        End If
    End Sub

    Private Sub MyUpdateClient_InstallingUpdate(pkg As UpdatePackageInfo, e As CancelEventArgs) Handles UpdateClient.InstallingUpdate
    End Sub

    Private Sub MyUpdateClient_FinishWork() Handles UpdateClient.UpdateInstallerStarted
        EndUpdating()
    End Sub

    Private Sub MyUpdateClient_NoUpdatesFound() Handles UpdateClient.NoUpdatesFound
        EndUpdating()
        MessageBoxEx.Show(UpdatingClientGuiLangRes.MsgBox_NoUpdatesFound, UpdatingClientGuiLangRes.MsgBox_NoUpdatesFound_Titel, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
