Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace Model.Fast3D

    Public Module TextureManager

        Public Sub PrepaireImage(ByRef bmp As Bitmap, rotateFlipTexture As RotateFlipType, texFormat As N64Graphics.N64Codec, fitImageSize As Boolean)
            If fitImageSize Then
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
            End If

            RotateFlipImage(bmp, rotateFlipTexture)
        End Sub

        Public Function ResizeImage(image As Image, size As Size, Optional preserveAspectRatio As Boolean = False, Optional forceSize As Boolean = False) As Image
            Dim result As New Size

            If preserveAspectRatio Then
                Dim val As Single = image.Size.Width / size.Width
                Dim num As Single = image.Size.Height / size.Height

                If num > val Then
                    result.Width = CInt(Math.Truncate(size.Width * val))
                    result.Height = size.Height
                ElseIf num < val Then
                    result.Width = size.Width
                    result.Height = CInt(Math.Truncate(size.Height * num))
                Else
                    result = size
                End If
            Else
                result = size
            End If

            Dim newImage As Image = New Bitmap(image, If(forceSize, size, result))
            Using g As Graphics = Graphics.FromImage(newImage)
                g.SmoothingMode = SmoothingMode.HighQuality
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.PageUnit = GraphicsUnit.Pixel
                'g.InterpolationMode = InterpolationMode.HighQualityBicubic

                Dim pointToDraw As Point
                If forceSize AndAlso (result.Width / result.Height) <> (size.Width / size.Height) Then
                    Dim px, py As Integer
                    px = (size.Width - result.Width) / 2
                    py = (size.Height - result.Height) / 2
                    pointToDraw = New Point(px, py)
                Else
                    pointToDraw = Point.Empty
                End If

                g.Clear(Color.Transparent)
                g.DrawImage(image, New Rectangle(pointToDraw, result))

                g.Dispose()
            End Using

            Return newImage
        End Function

        Public Sub RotateFlipImage(bmp As Bitmap, rotateFlipTexture As RotateFlipType)
            If rotateFlipTexture <> RotateFlipType.RotateNoneFlipNone Then
                bmp.RotateFlip(rotateFlipTexture)
            End If
        End Sub

        Public Function GetMaxPixls(texFormat As N64Graphics.N64Codec) As Integer
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

    End Module

End Namespace
