Imports SM64Lib

Namespace EventArguments

    Public Class OtherStatusInfosChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property Text As String
        Public ReadOnly Property ForeColor As Color

        Public Sub New(text As String, foreColor As Color)
            Me.Text = text
            Me.ForeColor = foreColor
        End Sub

    End Class

End Namespace
