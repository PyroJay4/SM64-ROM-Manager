Imports DevComponents.DotNetBar

Public Class Form_ImagePreview

    Public Sub New(Image As Image)
        InitializeComponent()
        StyleManager.UpdateAmbientColors(Me)
        PictureBox1.Image = Image
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class