Imports System.Drawing

Namespace Global.SM64Lib.Model.Fast3D

    Public Class TextureManager

        Public Shared Sub PrepaireImage(ByRef bmp As Bitmap, rotateFlipTexture As RotateFlipType, texFormat As N64Graphics.N64Codec)
            Dim maxPixels As Integer = GetMaxPixls(texFormat)

            'Resize Texture
            If bmp.Height * bmp.Width > maxPixels Then
                Dim curPixels As Integer = bmp.Height * bmp.Width
                Dim verhälltnis As Single = Math.Sqrt(curPixels / maxPixels)

                Dim newHeight As Single = bmp.Height / verhälltnis
                Dim newWidth As Single = bmp.Width / verhälltnis

                Dim nhlog As Integer = Math.Truncate(Math.Log(newHeight, 2))
                Dim nwlog As Integer = Math.Truncate(Math.Log(newWidth, 2))

                newHeight = Math.Pow(2, nhlog)
                newWidth = Math.Pow(2, nwlog)

                bmp = ResizeImage(bmp, New Size(newHeight, newWidth))
            End If

            If rotateFlipTexture <> RotateFlipType.RotateNoneFlipNone Then
                bmp.RotateFlip(rotateFlipTexture)
            End If
        End Sub

        Public Shared Function GetMaxPixls(texFormat As N64Graphics.N64Codec) As Integer
            Select Case texFormat
                Case N64Graphics.N64Codec.CI4
                    Return 64 * 64
                Case N64Graphics.N64Codec.CI8
                    Return 32 * 64
                Case N64Graphics.N64Codec.I4
                    Return 128 * 64
                Case N64Graphics.N64Codec.I8
                    Return 64 * 64
                Case N64Graphics.N64Codec.IA4
                    Return 128 * 64
                Case N64Graphics.N64Codec.IA8
                    Return 64 * 64
                Case N64Graphics.N64Codec.IA16
                    Return 32 * 64
                Case N64Graphics.N64Codec.RGBA16
                    Return 32 * 64
                Case N64Graphics.N64Codec.RGBA32
                    Return 32 * 32
                Case Else
                    Return 32 * 32
            End Select
        End Function

    End Class

End Namespace
