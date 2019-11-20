Friend Class UpdateInstallerStatusChangedEventArgs
    Inherits EventArgs

    Public ReadOnly Property NewStatus As UpdateInstallerStatus

    Public Sub New(newStatus As UpdateInstallerStatus)
        MyBase.New
        Me.NewStatus = newStatus
    End Sub

End Class
