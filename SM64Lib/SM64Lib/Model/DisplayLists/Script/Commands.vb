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
        Shared Function GetNumberOfVertices(cmd As DisplayListCommand) As Byte
            cmd.Position = 1
            Dim value As Byte = cmd.ReadByte
            cmd.Position = 0
            Return value >> 4
        End Function

        Shared Function GetStartIndexInVertexBuffer(cmd As DisplayListCommand) As Byte
            cmd.Position = 1
            Dim value As Byte = cmd.ReadByte
            cmd.Position = 0
            Return value And &HF
        End Function

        Shared Function GetLengthOfVertexData(cmd As DisplayListCommand) As Int16
            cmd.Position = 2
            Dim value = cmd.ReadInt16
            cmd.Position = 0
            Return value
        End Function

        Shared Function GetSegmentedAddress(cmd As DisplayListCommand) As Int32
            cmd.Position = 4
            Dim value = cmd.ReadInt32
            cmd.Position = 0
            Return value
        End Function
        Shared Sub SetSegmentedAddress(cmd As DisplayListCommand, value As Int32)
            cmd.Position = 4
            cmd.Write(value)
            cmd.Position = 0
        End Sub
    End Class

    Public Class F3D_TRI1
        Shared Function GetVertice(cmd As DisplayListCommand, VerticeNumber As Byte) As Byte
            cmd.Position = 5 + VerticeNumber - 1
            Dim value = cmd.ReadByte
            cmd.Position = 0
            If value > 0 Then value /= &HA
            Return value
        End Function
    End Class

    Public Class G_SETTILE

        Shared Function GetTextureFormat(cmd As DisplayListCommand) As N64Graphics.N64Codec
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

        Shared Function GetWrapT(cmd As DisplayListCommand) As Byte
            cmd.Position = 5
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return (val >> 2) And &H2
        End Function
        Shared Function GetWrapS(cmd As DisplayListCommand) As Byte
            cmd.Position = 6
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return val And &H2
        End Function
    End Class

    Public Class G_TEXTURE
        Shared Function GetTextureSize(cmd As DisplayListCommand) As Size
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

        Shared Function GetTextureScaling(cmd As DisplayListCommand) As Vector2
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

    Public Class G_SETIMG
        Shared Function GetSegmentedAddress(cmd As DisplayListCommand) As Int32
            cmd.Position = 4
            Dim value = cmd.ReadInt32
            cmd.Position = 0
            Return value
        End Function

        Shared Sub SetSegmentedAddress(cmd As DisplayListCommand, value As Int32)
            cmd.Position = 4
            cmd.Write(value)
            cmd.Position = 0
        End Sub

        Shared Function GetColorFormat(cmd As DisplayListCommand) As ColorFormat
            cmd.Position = 1
            Dim val As Byte = cmd.ReadByte
            cmd.Position = 0
            Return val >> 5
        End Function

        Shared Function GetBitSize(cmd As DisplayListCommand) As BitSize
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

    Public Class G_SETTILESIZE
        Shared Function GetSize(cmd As DisplayListCommand) As Size
            cmd.Position = 4
            Dim var As Integer = cmd.ReadInt32
            cmd.Position = 0

            Dim w As Int16 = (var >> 12) And &HFFF
            Dim h As Int16 = var And &HFFF

            w = (w >> 2) + 1
            h = (h >> 2) + 1

            Return New Size(w, h)
        End Function

        Shared Sub SetSize(cmd As DisplayListCommand, size As Size)
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
        Shared Function GetSegmentedOffset(cmd As DisplayListCommand) As Int32
            cmd.Position = 4
            Dim value = cmd.ReadInt32
            cmd.Position = 0
            Return value
        End Function
        Shared Sub SetSegmentedOffset(cmd As DisplayListCommand, value As Integer)
            cmd.Position = 4
            cmd.Write(value)
            cmd.Position = 0
        End Sub

        Shared Function GetLightValueMode(cmd As DisplayListCommand) As Byte
            cmd.Position = 1
            Dim value = cmd.ReadByte
            cmd.Position = 0
            Return value
        End Function
    End Class

    Public Class F3D_CLEARGEOMETRYMODE
        Shared Function GetGeometryMode(cmd As DisplayListCommand) As UInteger
            cmd.Position = 4
            Dim flag As UInteger = cmd.ReadUInt32
            cmd.Position = 0
            Return flag
        End Function
    End Class

    Public Class F3D_SETRGEOMETRYMODE
        Inherits F3D_CLEARGEOMETRYMODE
    End Class

End Namespace
