Imports SM64Lib.Music

Namespace EventArguments

    Public Class EnabledEventArgs
        Inherits EventArgs

        Public Property Enabled As Boolean

        Public Sub New(enabled As Boolean)
            Me.Enabled = enabled
        End Sub

    End Class

End Namespace
