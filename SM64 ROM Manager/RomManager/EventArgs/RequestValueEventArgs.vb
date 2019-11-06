Imports SM64Lib

Namespace EventArguments

    Public Class RequestValueEventArgs(Of TValue)
        Inherits EventArgs

        Public Property Value As TValue

        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(value As TValue)
            Me.New
            Me.Value = value
        End Sub

    End Class

End Namespace
