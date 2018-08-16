Public Class Form_ProgressDialog

    Public Overloads Async Sub ShowDialog() 'As Task(Of DialogResult)
        Await Task.Yield
        MyBase.ShowDialog()
    End Sub

    Public Overloads Sub Close()
        Me.DialogResult = DialogResult.OK
    End Sub
End Class