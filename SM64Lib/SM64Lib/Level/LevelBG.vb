Imports System.Drawing
Imports System.IO
Imports N64Graphics

Namespace Global.SM64Lib.Levels

    Public Class LevelBG

        'F i e l d s

        Private _ImageBytes As Byte() = Nothing
        Private _Image As Bitmap = Nothing

        'A u t o   P r o p e r t i e s

        Public Property Enabled As Boolean = True
        Public Property IsCustom As Boolean = False
        Public Property ID As Geolayout.BackgroundIDs = Geolayout.BackgroundIDs.Ocean

        'A u t o   P r o p e r t i e s

        Public ReadOnly Property Image As Bitmap
            Get
                If _Image IsNot Nothing Then
                    Return _Image
                Else
                    Dim img As Image = GetImage()
                    _Image = img
                    Return img
                End If
            End Get
        End Property

        Public Property ImageData As Byte()
            Get
                Return _ImageBytes
            End Get
            Set(value As Byte())
                _ImageBytes = value
            End Set
        End Property

        Public ReadOnly Property ImageLength As Integer
            Get
                Return _ImageBytes.Length
            End Get
        End Property

        Public ReadOnly Property HasImage As Boolean
            Get
                Return _ImageBytes IsNot Nothing
            End Get
        End Property

        'C o n s t r c u t o r s

        Public Sub New()
        End Sub

        Public Sub New(ID As Geolayout.BackgroundIDs)
            Me.ID = ID
        End Sub

        Public Sub New(Image As Image)
            Me.ID = Geolayout.BackgroundIDs.Custom
            SetImage(Image)
        End Sub

        'M e t h o d s

        Public Sub WriteImage(s As Stream, offset As Integer)
            'Write Image Data
            s.Position = offset
            s.Write(_ImageBytes, 0, _ImageBytes.Length)
        End Sub

        Public Sub ReadImage(s As Stream, offset As Integer)
            'Read Image Data
            ReDim _ImageBytes(&H20000 - 1)
            s.Position = offset
            s.Read(_ImageBytes, 0, _ImageBytes.Length)
            _Image = Nothing
        End Sub

        Public Sub SetImage(image As Image)
            SetImage(New Bitmap(image))
        End Sub

        Public Sub SetImage(bmp As Bitmap)
            Dim s As New Size(248, 248) '((&H20140 - &H140) / 256 / 2 / 32) * 31)
            If bmp.Size <> s Then
                bmp = ResizeImage(bmp, s, False)
            End If
            _ImageBytes = BackgroundImageConverter.GetBytes(bmp)
            _Image = Nothing
        End Sub

        Public Function GetImage() As Image
            If _ImageBytes IsNot Nothing Then
                Dim s As New Size(248, 248) '((_ImageByts.Length - &H140) / 256 / 2 / 32) * 31)
                Dim img As Bitmap = BackgroundImageConverter.GetImage(_ImageBytes, s)
                _Image = img
                Return img
            Else
                Return Nothing
            End If
        End Function

        Public Shared Function GetBackgroundPointerTable() As Byte()
            Return New Byte() {
                &HA, &H0, &H0, &H0, &HA, &H0, &H8, &H0, &HA, &H0, &H10, &H0,
                &HA, &H0, &H18, &H0, &HA, &H0, &H20, &H0, &HA, &H0, &H28, &H0,
                &HA, &H0, &H30, &H0, &HA, &H0, &H38, &H0, &HA, &H0, &H0, &H0,
                &HA, &H0, &H8, &H0, &HA, &H0, &H40, &H0, &HA, &H0, &H48, &H0,
                &HA, &H0, &H50, &H0, &HA, &H0, &H58, &H0, &HA, &H0, &H60, &H0,
                &HA, &H0, &H68, &H0, &HA, &H0, &H70, &H0, &HA, &H0, &H78, &H0,
                &HA, &H0, &H40, &H0, &HA, &H0, &H48, &H0, &HA, &H0, &H80, &H0,
                &HA, &H0, &H88, &H0, &HA, &H0, &H90, &H0, &HA, &H0, &H98, &H0,
                &HA, &H0, &HA0, &H0, &HA, &H0, &HA8, &H0, &HA, &H0, &HB0, &H0,
                &HA, &H0, &HB8, &H0, &HA, &H0, &H80, &H0, &HA, &H0, &H88, &H0,
                &HA, &H0, &HC0, &H0, &HA, &H0, &HC8, &H0, &HA, &H0, &HD0, &H0,
                &HA, &H0, &HD8, &H0, &HA, &H0, &HE0, &H0, &HA, &H0, &HE8, &H0,
                &HA, &H0, &HF0, &H0, &HA, &H0, &HF8, &H0, &HA, &H0, &HC0, &H0,
                &HA, &H0, &HC8, &H0, &HA, &H1, &H0, &H0, &HA, &H1, &H8, &H0,
                &HA, &H1, &H10, &H0, &HA, &H1, &H18, &H0, &HA, &H1, &H20, &H0,
                &HA, &H1, &H28, &H0, &HA, &H1, &H30, &H0, &HA, &H1, &H38, &H0,
                &HA, &H1, &H0, &H0, &HA, &H1, &H8, &H0, &HA, &H1, &H40, &H0,
                &HA, &H1, &H48, &H0, &HA, &H1, &H50, &H0, &HA, &H1, &H58, &H0,
                &HA, &H1, &H60, &H0, &HA, &H1, &H68, &H0, &HA, &H1, &H70, &H0,
                &HA, &H1, &H78, &H0, &HA, &H1, &H40, &H0, &HA, &H1, &H48, &H0,
                &HA, &H1, &H80, &H0, &HA, &H1, &H88, &H0, &HA, &H1, &H90, &H0,
                &HA, &H1, &H98, &H0, &HA, &H1, &HA0, &H0, &HA, &H1, &HA8, &H0,
                &HA, &H1, &HB0, &H0, &HA, &H1, &HB8, &H0, &HA, &H1, &H80, &H0,
                &HA, &H1, &H88, &H0, &HA, &H1, &HC0, &H0, &HA, &H1, &HC8, &H0,
                &HA, &H1, &HD0, &H0, &HA, &H1, &HD8, &H0, &HA, &H1, &HE0, &H0,
                &HA, &H1, &HE8, &H0, &HA, &H1, &HF0, &H0, &HA, &H1, &HF8, &H0,
                &HA, &H1, &HC0, &H0, &HA, &H1, &HC8, &H0
            }
        End Function

        'C l a s s e s

        Private Class BackgroundImageConverter

            Public Shared Function GetImage(data As Byte(), size As Size) As Bitmap
                Dim ms As New MemoryStream(data)
                Dim br As New BinaryReader(ms)
                Dim img As New Bitmap(size.Width, size.Height)
                Dim current_address As UInteger = 0

                For y As Integer = 0 To size.Height / 31 - 1
                    For x As Integer = 0 To size.Width / 31 - 1
                        ParseBlock(br, img, current_address, New Rectangle(x * 31, y * 31, 31, 31))
                        current_address += 2048
                    Next
                Next

                ms.Close()
                Return img
            End Function

            Private Shared Sub ParseBlock(br As BinaryReader, map As Bitmap, address As UInteger, rect As Rectangle)
                For yy As Integer = 0 To rect.Height - 1
                    For xx As Integer = 0 To rect.Width - 1
                        Dim offset As Integer = address + ((yy * (rect.Width + 1)) + xx) * 2
                        br.BaseStream.Position = offset

                        Dim pixel As UShort = SwapInts.SwapUInt16(br.ReadUInt16)
                        Dim red As Byte = ((pixel >> 11) And &H1F) * 8
                        Dim green As Byte = ((pixel >> 6) And &H1F) * 8
                        Dim blue As Byte = ((pixel >> 1) And &H1F) * 8
                        Dim alpha As Byte = If((pixel And 1) > 0, &HFF, 0)

                        Dim pixcol As Color = Color.FromArgb(alpha, red, green, blue)
                        map.SetPixel(rect.X + xx, rect.Y + yy, pixcol)
                    Next
                Next
            End Sub

            Public Shared Function GetBytes(img As Bitmap) As Byte()
                Dim ms As New MemoryStream
                Dim bw As New BinaryWriter(ms)
                Dim wTiles As Integer = img.Width / 31
                Dim hTiles As Integer = img.Height / 31
                Dim current_address As Integer = 0

                For y As Integer = 0 To hTiles - 1
                    For x As Integer = 0 To wTiles - 1
                        ConvertBlock(bw, img, current_address, x * 31, y * 31, 0, 0, 0, 0, 31, 31, 32)

                        If x < wTiles - 1 Then
                            ConvertBlock(bw, img, current_address, ((x + 1) * 31) - 30, y * 31, 30, 0, 1, 0, 31, 31, 32)
                            ConvertBlock(bw, img, current_address, ((x + 1) * 31) - 30, y * 31, 30, 30, 1, 1, 31, 31, 32)
                        Else
                            ConvertBlock(bw, img, current_address, -30, y * 31, 30, 0, 1, 0, 31, 31, 32)
                            ConvertBlock(bw, img, current_address, -30, y * 31, 30, 30, 1, 1, 31, 31, 32)
                        End If

                        If y < hTiles - 1 Then
                            ConvertBlock(bw, img, current_address, (x * 31), ((y + 1) * 31) - 30, 0, 30, 0, 1, 31, 31, 32)
                        Else
                            ConvertBlock(bw, img, current_address, (x * 31), -30, 0, 30, 0, 1, 31, 31, 32)
                        End If

                        current_address += 2048
                    Next
                Next

                Dim temp As Byte() = ms.ToArray
                ms.Close()
                Return temp
            End Function

            Private Shared Sub ConvertBlock(bw As BinaryWriter, map As Bitmap, address As UInteger, src_x As Integer, src_y As Integer, start_x As Integer, start_y As Integer, offset_x As Integer, offset_y As Integer, w As Integer, h As Integer, lineWidth As Integer)
                For yy = start_y To h - 1
                    For xx = start_x To w - 1
                        Dim pixel As Color = map.GetPixel(src_x + xx, src_y + yy)

                        Dim r As Integer = pixel.R \ 8
                        Dim g As Integer = pixel.G \ 8
                        Dim b As Integer = pixel.B \ 8
                        Dim a As Integer = If(pixel.A = &HFF, 1, 0)

                        bw.BaseStream.Position = address + (((yy + offset_y) * lineWidth + (xx + offset_x)) * 2)
                        bw.Write(SwapInts.SwapUInt16((r << 11) Or (g << 6) Or (b << 1) Or a))
                    Next
                Next
            End Sub

        End Class

    End Class

End Namespace
