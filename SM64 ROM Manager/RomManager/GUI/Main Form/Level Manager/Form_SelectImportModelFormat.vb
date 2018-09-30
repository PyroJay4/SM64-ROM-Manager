Public Class Form_SelectImportModelFormat

    Public Property Mode As eMode = eMode.ConvertNew

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Mode = eMode.ConvertNew
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Mode = eMode.FromFile
    End Sub

    Public Enum eMode
        FromFile
        ConvertNew
    End Enum
End Class