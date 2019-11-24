Public Class UpdateClientGUI

    Public ReadOnly Property UpdateClient As UpdateClient
    Public Property UseHiddenSearch As Boolean = False

    Public Sub New(updateClient As UpdateClient)
        Me.updateClient = updateClient
    End Sub

    Public Sub UpdateInteractive()
        Throw New NotImplementedException
    End Sub

End Class
