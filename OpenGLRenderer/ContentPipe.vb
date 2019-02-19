Imports System
Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class ContentPipe

    Public Shared Function LoadTexture(filepath As String) As Integer
        Dim bitmap As New Bitmap(filepath)
        Return LoadTexture(bitmap)
    End Function

    Public Shared Function LoadTexture(bitmap As Bitmap) As Integer
        Dim id As Integer = GL.GenTexture()
        LoadTexture(bitmap, id)
        Return id
    End Function

    Public Shared Sub LoadTexture(bitmap As Bitmap, id As Integer)
        Dim bmpData As BitmapData = bitmap.LockBits(New Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)
        GL.BindTexture(TextureTarget.Texture2D, id)
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0)
        bitmap.UnlockBits(bmpData)
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, CInt(Math.Truncate(TextureMinFilter.Linear)))
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, CInt(Math.Truncate(TextureMagFilter.Linear)))
    End Sub

End Class
