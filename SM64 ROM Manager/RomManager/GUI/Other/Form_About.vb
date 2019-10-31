Imports DevComponents.DotNetBar

Public Class Form_About

    Private Sub PictureBox_Donate_Click(sender As Object, e As EventArgs) Handles PictureBox_Donate.Click
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=BCA34KB48SNRG&source=url")
    End Sub

End Class