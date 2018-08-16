Namespace Global.SM64Lib.Script

    Public Class BaseCommandCollection(Of TCmd, eTypes)
        Inherits List(Of BaseCommand(Of eTypes))

        Public Overrides Function ToString() As String
            Dim Lines As New List(Of String)
            For Each cmd As BaseCommand(Of eTypes) In Me
                Lines.Add(cmd.ToString)
            Next
            Return Microsoft.VisualBasic.Join(Lines.ToArray, vbNewLine)
        End Function

        Public Sub Close()
            For Each cmd As BaseCommand(Of eTypes) In Me
                cmd.Close()
            Next
        End Sub
    End Class

End Namespace
