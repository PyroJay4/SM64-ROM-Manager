Imports SM64Lib

Namespace EventArguments

    Public Class StatusTextChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property NewStatus As String

        Public Sub New(newStatus)
            Me.NewStatus = newStatus
        End Sub

    End Class

End Namespace
