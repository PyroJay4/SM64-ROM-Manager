Imports System.ComponentModel
Imports SM64_ROM_Manager.Updating

Public Class UpdateClientGUI

    'F i e l d s

    Private WithEvents MyUpdateClient As UpdateClient
    Private curProgressDialog As SimpleActionDialog = Nothing

    'P r o p e r t i e s

    Public Property UseHiddenSearch As Boolean = False

    Public ReadOnly Property UpdateClient As UpdateClient
        Get
            Return MyUpdateClient
        End Get
    End Property

    'C o n s t r u c t o r s

    Public Sub New(updateClient As UpdateClient)
        MyUpdateClient = updateClient
    End Sub

    'F e a t u r e s

    Public Sub UpdateInteractive()
        UpdateClient.UpdateInteractive()
    End Sub

    'U p d a t e C l i e n t - E v e n t s

    Private Sub MyUpdateClient_UpdateStatusChanged(newStatus As UpdateStatus, progress As Integer) Handles MyUpdateClient.UpdateStatusChanged
        Dim useGui As Boolean = False

        If Not (newStatus = UpdateStatus.Searching AndAlso UseHiddenSearch) Then
            useGui = True
        End If

        If useGui Then
            If curProgressDialog IsNot Nothing Then
                Task.Run(
                    Sub()
                        curProgressDialog = New SimpleActionDialog()
                        curProgressDialog.SetCurrentState(UpdateStatus.Waiting)
                        curProgressDialog.Show()
                    End Sub).Wait()
            End If
        End If

        curProgressDialog.Invoke(Sub() curProgressDialog.SetCurrentState(newStatus, progress))
    End Sub

    Private Sub MyUpdateClient_DownloadingUpdate(foundPackage As UpdatePackageInfo, e As CancelEventArgs) Handles MyUpdateClient.DownloadingUpdate

    End Sub

    Private Sub MyUpdateClient_InstallingUpdate(pkg As UpdatePackageInfo, e As CancelEventArgs) Handles MyUpdateClient.InstallingUpdate

    End Sub

    Private Sub MyUpdateClient_UpdateInstallerStarted() Handles MyUpdateClient.UpdateInstallerStarted
        curProgressDialog?.Close()
    End Sub

End Class
