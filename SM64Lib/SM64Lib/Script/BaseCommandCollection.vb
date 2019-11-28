Namespace Script

    Public Class BaseCommandCollection(Of TCmd, eTypes)
        Inherits List(Of BaseCommand(Of eTypes))

        Public ReadOnly Property IsDirty As Boolean
            Get
                Return FirstOrDefault(Function(n) n.IsDirty) IsNot Nothing
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim Lines As New List(Of String)
            For Each cmd As BaseCommand(Of eTypes) In Me
                Lines.Add(cmd.ToString)
            Next
            Return String.Join(vbNewLine, Lines.ToArray)
        End Function

        Public Sub Close()
            For Each cmd As BaseCommand(Of eTypes) In Me
                cmd.Close()
            Next
        End Sub
    End Class

End Namespace
