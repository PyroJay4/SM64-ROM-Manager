Imports DevComponents.DotNetBar
Imports System.Windows.Forms

Public Class StringInputDialog

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If String.IsNullOrEmpty(TextBoxX1.Text.Trim) Then
            MessageBoxEx.Show("The input is empty! Please enter a text first.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            DialogResult = DialogResult.OK
        End If
    End Sub

    Public Property Value As String
        Get
            Return TextBoxX1.Text
        End Get
        Set
            TextBoxX1.Text = Value
        End Set
    End Property

    Public Property Titel As String
        Get
            Return Text
        End Get
        Set
            Text = Value
        End Set
    End Property

End Class