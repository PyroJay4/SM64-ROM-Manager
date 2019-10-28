Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Fast3D.DisplayLists.Script
Imports SM64Lib.Model.Fast3D.DisplayLists.Script.Commands
Imports SM64Lib.Script

Namespace Global.SM64Lib.Model.Fast3D.DisplayLists.Script.Commands

    Public Class F3D_VTX
        Public Shared Function GetNumberOfVertices(cmd As DisplayListCommand) As Byte
            cmd.Position = 1
            Dim value As Byte = cmd.ReadByte
            cmd.Position = 0
            Return value >> 4
        End Function

        Public Shared Function GetStartIndexInVertexBuffer(cmd As DisplayListCommand) As Byte
            cmd.Position = 1
            Dim value As Byte = cmd.ReadByte
            cmd.Position = 0
            Return value And &HF
        End Function

        Public Shared Function GetLengthOfVertexData(cmd As DisplayListCommand) As Int16
            cmd.Position = 2
            Dim value = cmd.ReadInt16
            cmd.Position = 0
            Return value
        End Function

        Public Shared Function GetSegmentedAddress(cmd As DisplayListCommand) As Int32
            cmd.Position = 4
            Dim value = cmd.ReadInt32
            cmd.Position = 0
            Return value
        End Function
        Public Shared Sub SetSegmentedAddress(cmd As DisplayListCommand, value As Int32)
            cmd.Position = 4
            cmd.Write(value)
            cmd.Position = 0
        End Sub
    End Class

    Public Class F3D_TRI1
        Public Shared Function GetVertice(cmd As DisplayListCommand, VerticeNumber As Byte) As Byte
            cmd.Position = 5 + VerticeNumber - 1
            Dim value = cmd.ReadByte
            cmd.Position = 0
            If value > 0 Then value /= &HA
            Return value
        End Function
    End Class

    Public Class F3D_SETTILE

        Public Shared Function GetTextureFormat(cmd As DisplayListCommand) As N64Graphics.N64Codec
            cmd.Position = 1
            Dim type As Byte = cmd.ReadByte
            cmd.Position = 0

            Select Case type
                Case &H10
                    Return N64Graphics.N64Codec.RGBA16
                Case &H18
                    Return N64Graphics.N64Codec.RGBA32
                Case &H40
                    Return N64Graphics.N64Codec.CI4
                Case &H48
                    Return N64Graphics.N64Codec.CI8
                Case &H60
                    Return N64Graphics.N64Codec.IA4
                Case &H68
                    Return N64Graphics.N64Codec.IA8
                Case &H70
                    Return N64Graphics.N64Codec.IA16
                Case &H80, &H90
                    Return N64Graphics.N64Codec.I4
                Case &H88
                    Return N64Graphics.N64Codec.I8
                Case Else
                    Return Nothing
            End Select
        End Function

        Public Shared Function GetWrapT(cmd As DisplayListCommand) As Byte
            cmd.Position = 5
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return (val >> 2) And &H2
        End Function
        Public Shared Function GetWrapS(cmd As DisplayListCommand) As Byte
            cmd.Position = 6
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return val And &H2
        End Function
    End Class

    Public Class F3D_TEXTURE
        Public Shared Function GetTextureSize(cmd As DisplayListCommand) As Size
            cmd.Position = 4
            Dim tsX As UInt16 = cmd.ReadUInt16
            Dim tsY As UInt16 = cmd.ReadUInt16
            cmd.Position = 0

            tsX = tsX >> 6
            If tsX = 31 Then
                tsX = 32
            ElseIf tsX = 62 Then
                tsX = 64
            End If

            tsY = tsY >> 6
            If tsY = 31 Then
                tsY = 32
            ElseIf tsY = 62 Then
                tsY = 64
            End If

            Return New Size(tsX, tsY)
        End Function

        Public Shared Function GetTextureScaling(cmd As DisplayListCommand) As Vector2
            cmd.Position = 4
            Dim tsX As UInt16 = cmd.ReadUInt16
            Dim tsY As UInt16 = cmd.ReadUInt16
            cmd.Position = 0

            Dim vec As New Vector2

            If tsX <> &HFFFF Then
                vec.X = tsX / 65536.0F
            Else
                vec.X = 1.0F
            End If

            If tsY <> &HFFFF Then
                vec.Y = tsY / 65536.0F
            Else
                vec.Y = 1.0F
            End If

            Return vec
        End Function
    End Class

    Public Class F3D_SETIMG
        Public Shared Function GetSegmentedAddress(cmd As DisplayListCommand) As Int32
            cmd.Position = 4
            Dim value = cmd.ReadInt32
            cmd.Position = 0
            Return value
        End Function

        Public Shared Sub SetSegmentedAddress(cmd As DisplayListCommand, value As Int32)
            cmd.Position = 4
            cmd.Write(value)
            cmd.Position = 0
        End Sub

        Public Shared Function GetColorFormat(cmd As DisplayListCommand) As ColorFormat
            cmd.Position = 1
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return val >> 5
        End Function

        Public Shared Function GetBitSize(cmd As DisplayListCommand) As BitSize
            cmd.Position = 1
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return (val >> 3) And &H3
        End Function

        Public Enum ColorFormat As Byte
            ''' <summary>
            ''' Color and alpha
            ''' </summary>
            RGBA = 0
            ''' <summary>
            ''' Luminance and Chrominance
            ''' </summary>
            YUV = 1
            ''' <summary>
            ''' Index and look-up palette
            ''' </summary>
            CI = 2
            ''' <summary>
            ''' Grayscale and alpha
            ''' </summary>
            IA = 3
            ''' <summary>
            ''' Grayscale
            ''' </summary>
            I = 4
        End Enum
        Public Enum BitSize As Byte
            _4 = 0
            _8 = 1
            _16 = 2
            _32 = 3
        End Enum
    End Class

    Public Class F3D_SETTILESIZE
        Public Shared Function GetSize(cmd As DisplayListCommand) As Size
            cmd.Position = 4
            Dim var As Integer = cmd.ReadInt32
            cmd.Position = 0

            Dim w As Int16 = (var >> 12) And &HFFF
            Dim h As Int16 = var And &HFFF

            w = (w >> 2) + 1
            h = (h >> 2) + 1

            Return New Size(w, h)
        End Function

        Public Shared Sub SetSize(cmd As DisplayListCommand, size As Size)
            Dim w As Int32 = size.Width
            Dim h As Int32 = size.Height

            w = (w - 1) << 2
            h = (h - 1) << 2

            Dim var As Int32 = (w << 12) Or h

            cmd.Position = 4
            cmd.Write(var)
            cmd.Position = 0
        End Sub
    End Class

    Public Class F3D_MOVEMEM
        Public Shared Function GetSegmentedOffset(cmd As DisplayListCommand) As Int32
            cmd.Position = 4
            Dim value = cmd.ReadInt32
            cmd.Position = 0
            Return value
        End Function
        Public Shared Sub SetSegmentedOffset(cmd As DisplayListCommand, value As Integer)
            cmd.Position = 4
            cmd.Write(value)
            cmd.Position = 0
        End Sub

        Public Shared Function GetLightValueMode(cmd As DisplayListCommand) As Byte
            cmd.Position = 1
            Dim value = cmd.ReadByte
            cmd.Position = 0
            Return value
        End Function
    End Class

    Public Class F3D_CLEARGEOMETRYMODE
        Public Shared Function GetGeometryMode(cmd As DisplayListCommand) As UInteger
            cmd.Position = 4
            Dim flag As UInteger = cmd.ReadUInt32
            cmd.Position = 0
            Return flag
        End Function
    End Class

    Public Class F3D_SETRGEOMETRYMODE
        Inherits F3D_CLEARGEOMETRYMODE
    End Class

    Public Class F3D_SETOTHERMODE_H
        Public Shared Function GetModeBits(cmd As DisplayListCommand) As UInteger
            cmd.Position = 4
            Dim bits As UInteger = cmd.ReadUInt32
            cmd.Position = 0
            Return bits
        End Function
    End Class

    Public Class F3D_SETCOMBINE

        Public Enum CCMUX As Byte
            COMBINED = 0
            TEXEL0
            TEXEL1
            PRIMITIVE
            SHADE
            ENVIRONMENT
            CENTER
            COMBINED_ALPHA
            TEXEL0_ALPHA
            TEXEL1_ALPHA
            PRIMITIVE_ALPHA
            SHADE_ALPHA
            ENV_ALPHA
            LOD_FRACTION
            PRIM_LOD_FRAC

            SCALE = 6
            NOISE = 7
            K4 = 7
            K5 = 15
            ONE = 6
            ZERO = 31
        End Enum

        Public Enum ACMUX As Byte
            COMBINED = 0
            TEXEL0
            TEXEL1
            PRIMITIVE
            SHADE
            ENVIRONMENT
            PRIM_LOD_FRAC

            ONE = 6
            ZERO = 7
            LOD_FRACTION = 0
        End Enum

        Public Class Formula
            Public ReadOnly a As Byte
            Public ReadOnly b As Byte
            Public ReadOnly c As Byte
            Public ReadOnly d As Byte

            Public Sub New(a As Byte, b As Byte, c As Byte, d As Byte) ' CC formula is (a - b) * c + d
                Me.a = a
                Me.b = b
                Me.c = c
                Me.d = d
            End Sub

            Shared Function Output(a As CCMUX) As Formula
                Return New Formula(CCMUX.ZERO, CCMUX.ZERO, CCMUX.ZERO, a) ' (0 - 0) * 0 + a = a
            End Function

            Shared Function Output(a As ACMUX) As Formula
                Return New Formula(ACMUX.ZERO, ACMUX.ZERO, ACMUX.ZERO, a)
            End Function

            Shared Function Multiply(a As CCMUX, b As CCMUX) As Formula
                Return New Formula(a, CCMUX.ZERO, b, CCMUX.ZERO) ' (a - 0) * b + 0 = a * b
            End Function

            Shared Function Multiply(a As Byte, b As Byte) As Formula
                Return New Formula(a, ACMUX.ZERO, b, ACMUX.ZERO) ' (a - 0) * b + 0 = a * b
            End Function
        End Class

        Private Shared Function _SHIFTL(v As UInt32, s As UInt32, w As UInt32) As UInt32
            Return (v And ((1 << w) - 1)) << s
        End Function

        Private Shared Function GCCc0w0(saRGB0 As UInt32, mRGB0 As UInt32, saA0 As UInt32, mA0 As UInt32) As UInt32
            Return _SHIFTL(saRGB0, 20, 4) Or _SHIFTL(mRGB0, 15, 5) Or _SHIFTL(saA0, 12, 3) Or _SHIFTL(mA0, 9, 3)
        End Function

        Private Shared Function GCCc1w0(saRGB1 As UInt32, mRGB1 As UInt32) As UInt32
            Return _SHIFTL(saRGB1, 5, 4) Or _SHIFTL(mRGB1, 0, 5)
        End Function

        Private Shared Function GCCc0w1(sbRGB0 As UInt32, aRGB0 As UInt32, sbA0 As UInt32, aA0 As UInt32) As UInt32
            Return _SHIFTL(sbRGB0, 28, 4) Or _SHIFTL(aRGB0, 15, 3) Or _SHIFTL(sbA0, 12, 3) Or _SHIFTL(aA0, 9, 3)
        End Function

        Private Shared Function GCCc1w1(sbRGB1 As UInt32, saA1 As UInt32, mA1 As UInt32, aRGB1 As UInt32, sbA1 As UInt32, aA1 As UInt32) As UInt32
            Return _SHIFTL(sbRGB1, 24, 4) Or _SHIFTL(saA1, 21, 3) Or _SHIFTL(mA1, 18, 3) Or _SHIFTL(aRGB1, 6, 3) Or _SHIFTL(sbA1, 3, 3) Or _SHIFTL(aA1, 0, 3)
        End Function

        ' For Jabo plugin you can't specify anything you want for 2nd cycle, only combined or the same as previous :(
        Public Shared Function Make(color As Formula, alpha As Formula, isFog As Boolean) As String
            If Not isFog Then
                Return Make(color, alpha, color, alpha)
            Else
                Return Make(color, alpha, Formula.Output(CCMUX.COMBINED), Formula.Output(ACMUX.COMBINED))
            End If
        End Function

        ' TODO: Let user specify custom combiner with this
        Public Shared Function Make(color0 As Formula, alpha0 As Formula, color1 As Formula, alpha1 As Formula) As String
            Return Make(color0.a, color0.b, color0.c, color0.d,
                        alpha0.a, alpha0.b, alpha0.c, alpha0.d,
                        color1.a, color1.b, color1.c, color1.d,
                        alpha1.a, alpha1.b, alpha1.c, alpha1.d)
        End Function

        Private Shared Function Make(a0 As CCMUX, b0 As CCMUX, c0 As CCMUX, d0 As CCMUX,
                                     Aa0 As ACMUX, Ab0 As ACMUX, Ac0 As ACMUX, Ad0 As ACMUX,
                                     a1 As CCMUX, b1 As CCMUX, c1 As CCMUX, d1 As CCMUX,
                                     Aa1 As ACMUX, Ab1 As ACMUX, Ac1 As ACMUX, Ad1 As ACMUX) As String
            Dim w0 = _SHIFTL(&HFC, 24, 8) Or _SHIFTL(GCCc0w0(a0, c0, Aa0, Ac0) Or GCCc1w0(a1, c1), 0, 24)
            Dim w1 = GCCc0w1(b0, d0, Ab0, Ad0) Or GCCc1w1(b1, Aa1, Ac1, d1, Ab1, Ad1)

            Dim w0bytes = BitConverter.GetBytes(w0)
            Dim w1bytes = BitConverter.GetBytes(w1)
            ' Little endian assumed
            Dim ret = w0bytes(3).ToString("X")
            ret += " " + w0bytes(2).ToString("X")
            ret += " " + w0bytes(1).ToString("X")
            ret += " " + w0bytes(0).ToString("X")
            ret += " " + w1bytes(3).ToString("X")
            ret += " " + w1bytes(2).ToString("X")
            ret += " " + w1bytes(1).ToString("X")
            ret += " " + w1bytes(0).ToString("X")
            Return ret
        End Function

    End Class

End Namespace
