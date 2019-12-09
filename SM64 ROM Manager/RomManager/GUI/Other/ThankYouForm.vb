Public Class ThankYouForm

    Private Const WebAddress As String = "http://pilzinsel64.com/about.html"

    Private loaded As Boolean = False

    Private Sub ThankYouForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebBrowser1.Url = New Uri(WebAddress)
        loaded = True
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        If loaded AndAlso e.Url.ToString <> WebAddress Then
            e.Cancel = True
            Process.Start(e.Url.ToString)
        End If
    End Sub

End Class
