Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Global.SM64Lib.Geolayout.Script

    Namespace Commands
        Public Class cgBackground
            Shared Function GetBackgroundID(command As GeolayoutCommand) As Int16
                Dim br As New BinaryReader(command)
                command.Position = &H2
                Dim value = SwapInts.SwapInt16(br.ReadInt16)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetBackgroundID(command As GeolayoutCommand, ID As Int16)
                Dim bw As New BinaryWriter(command)
                command.Position = &H2
                bw.Write(SwapInts.SwapInt16(ID))
                command.Position = 0
            End Sub

            Shared Function GetBackgroundPointer(command As GeolayoutCommand) As Integer
                Dim br As New BinaryReader(command)
                command.Position = &H4
                Dim value = SwapInts.SwapInt32(br.ReadInt32)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetBackgroundPointer(command As GeolayoutCommand, Pointer As Integer)
                Dim bw As New BinaryWriter(command)
                command.Position = &H4
                bw.Write(SwapInts.SwapInt32(Pointer))
                command.Position = 0
            End Sub

            Shared Function GetRrgbaColor(command As GeolayoutCommand) As Drawing.Color
                command.Position = &H2
                Dim b1 As Byte = command.ReadByte
                Dim b2 As Byte = command.ReadByte
                command.Position = 0

                Return N64Graphics.N64Graphics.RGBA16Color(b1, b2)
            End Function

            Shared Sub SetRgbaColor(command As GeolayoutCommand, color As Drawing.Color)
                Dim r As Integer = color.R / 8
                Dim g As Integer = color.G / 8
                Dim b As Integer = color.B / 8
                Dim a As Integer = If(color.A = &HFF, 1, 0)

                Dim bw As New BinaryWriter(command)
                command.Position = &H2
                bw.Write(SwapInts.SwapUInt16((r << 11) Or (g << 6) Or (b << 1) Or a))
                command.Position = 0
            End Sub
        End Class

        Public Class cgCameraPreset
            Shared Function GetCameraPreset(ByRef command As GeolayoutCommand) As Byte
                Dim br As New BinaryReader(command)
                command.Position = &H3
                Dim value = br.ReadByte
                command.Position = 0
                Return value
            End Function
            Shared Sub SetCameraPreset(ByRef command As GeolayoutCommand, Preset As Byte)
                Dim bw As New BinaryWriter(command)
                command.Position = &H3
                bw.Write(Preset)
                command.Position = 0
            End Sub
        End Class

        Public Class cgx18
            Shared Function GetParam1(ByRef command As GeolayoutCommand) As UShort
                Dim br As New BinaryReader(command)
                command.Position = &H2
                Dim value = SwapInts.SwapUInt16(br.ReadUInt16)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetParam1(ByRef command As GeolayoutCommand, ID As UShort)
                Dim bw As New BinaryWriter(command)
                command.Position = &H2
                bw.Write(SwapInts.SwapUInt16(ID))
                command.Position = 0
            End Sub

            Shared Function GetAsmPointer(ByRef command As GeolayoutCommand) As Integer
                Dim br As New BinaryReader(command)
                command.Position = &H4
                Dim value = SwapInts.SwapInt32(br.ReadInt32)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetAsmPointer(ByRef command As GeolayoutCommand, AsmPointer As Integer)
                Dim bw As New BinaryWriter(command)
                command.Position = &H4
                bw.Write(SwapInts.SwapInt32(AsmPointer))
                command.Position = 0
            End Sub
        End Class

        Public Class cgLoadDisplayList
            Shared Function GetDrawingLayer(ByRef command As GeolayoutCommand) As Byte
                Dim br As New BinaryReader(command)
                command.Position = &H1
                Dim value = br.ReadByte
                command.Position = 0
                Return value
            End Function
            Shared Sub SetDrawingLayer(ByRef command As GeolayoutCommand, Layer As Byte)
                Dim bw As New BinaryWriter(command)
                command.Position = &H1
                bw.Write(Layer)
                command.Position = 0
            End Sub

            Shared Function GetSegGeopointer(ByRef command As GeolayoutCommand) As Integer
                Dim br As New BinaryReader(command)
                command.Position = &H4
                Dim value = SwapInts.SwapInt32(br.ReadInt32)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetSegGeopointer(ByRef command As GeolayoutCommand, SegPointer As Integer)
                Dim bw As New BinaryWriter(command)
                command.Position = &H4
                bw.Write(SwapInts.SwapInt32(SegPointer))
                command.Position = 0
            End Sub
        End Class

        Public Class cgLoadDisplayListWithOffset
            Shared Function GetDrawingLayer(ByRef command As GeolayoutCommand) As Byte
                Dim br As New BinaryReader(command)
                command.Position = &H1
                Dim value = br.ReadByte
                command.Position = 0
                Return value
            End Function
            Shared Sub SetDrawingLayer(ByRef command As GeolayoutCommand, Layer As Byte)
                Dim bw As New BinaryWriter(command)
                command.Position = &H1
                bw.Write(Layer)
                command.Position = 0
            End Sub

            Shared Function GetOffset(ByRef command As GeolayoutCommand) As Vector3
                Dim br As New BinaryReader(command)
                command.Position = 2
                Dim value As New Vector3
                value.X = SwapInts.SwapInt16(br.ReadInt16)
                value.Y = SwapInts.SwapInt16(br.ReadInt16)
                value.Z = SwapInts.SwapInt16(br.ReadInt16)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetOffset(ByRef Command As GeolayoutCommand, value As Vector3)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 2
                bw.Write(SwapInts.SwapInt16(value.X))
                bw.Write(SwapInts.SwapInt16(value.Y))
                bw.Write(SwapInts.SwapInt16(value.Z))
                Command.Position = 0
            End Sub
            Shared Sub SetOffset(ByRef Command As GeolayoutCommand, X As Int32, Y As Int32, Z As Int32)
                SetOffset(Command, New Vector3(X, Y, Z))
            End Sub

            Shared Function GetSegGeopointer(ByRef command As GeolayoutCommand) As UInteger
                Dim br As New BinaryReader(command)
                command.Position = &H8
                Dim value = SwapInts.SwapUInt32(br.ReadUInt32)
                command.Position = 0
                Return value
            End Function
            Shared Sub SetSegGeopointer(ByRef command As GeolayoutCommand, SegPointer As UInteger)
                Dim bw As New BinaryWriter(command)
                command.Position = &H8
                bw.Write(SwapInts.SwapUInt32(SegPointer))
                command.Position = 0
            End Sub
        End Class
    End Namespace

End Namespace