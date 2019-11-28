Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Geolayout.Script

    Namespace Commands
        Public Class cgBackground
            Shared Function GetBackgroundID(command As GeolayoutCommand) As Int16
                command.Position = &H2
                Dim value = command.ReadInt16
                command.Position = 0
                Return value
            End Function
            Shared Sub SetBackgroundID(command As GeolayoutCommand, ID As Int16)
                command.Position = &H2
                command.Write(ID)
                command.Position = 0
            End Sub

            Shared Function GetBackgroundPointer(command As GeolayoutCommand) As Integer
                command.Position = &H4
                Dim value = command.ReadInt32
                command.Position = 0
                Return value
            End Function
            Shared Sub SetBackgroundPointer(command As GeolayoutCommand, Pointer As Integer)
                command.Position = &H4
                command.Write(Pointer)
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
                Dim b1, b2 As Byte
                N64Graphics.N64Graphics.ColorRGBA16(color, b1, b2)

                command.Position = &H2
                command.WriteByte(b1)
                command.WriteByte(b2)
                command.Position = 0
            End Sub
        End Class

        Public Class cgCameraPreset
            Shared Function GetCameraPreset(ByRef command As GeolayoutCommand) As Byte
                command.Position = &H3
                Dim value = command.ReadByte
                command.Position = 0
                Return value
            End Function
            Shared Sub SetCameraPreset(ByRef command As GeolayoutCommand, Preset As Byte)
                command.Position = &H3
                command.Write(Preset)
                command.Position = 0
            End Sub
        End Class

        Public Class cgx18
            Shared Function GetParam1(ByRef command As GeolayoutCommand) As UShort
                command.Position = &H2
                Dim value = command.ReadUInt16
                command.Position = 0
                Return value
            End Function
            Shared Sub SetParam1(ByRef command As GeolayoutCommand, ID As UShort)
                command.Position = &H2
                command.Write(ID)
                command.Position = 0
            End Sub

            Shared Function GetAsmPointer(ByRef command As GeolayoutCommand) As Integer
                command.Position = &H4
                Dim value = command.ReadInt32
                command.Position = 0
                Return value
            End Function
            Shared Sub SetAsmPointer(ByRef command As GeolayoutCommand, AsmPointer As Integer)
                command.Position = &H4
                command.Write(AsmPointer)
                command.Position = 0
            End Sub
        End Class

        Public Class cgLoadDisplayList
            Shared Function GetDrawingLayer(ByRef command As GeolayoutCommand) As Byte
                command.Position = &H1
                Dim value = command.ReadByte
                command.Position = 0
                Return value
            End Function
            Shared Sub SetDrawingLayer(ByRef command As GeolayoutCommand, Layer As Byte)
                command.Position = &H1
                command.Write(Layer)
                command.Position = 0
            End Sub

            Shared Function GetSegGeopointer(ByRef command As GeolayoutCommand) As Integer
                command.Position = &H4
                Dim value = command.ReadInt32
                command.Position = 0
                Return value
            End Function
            Shared Sub SetSegGeopointer(ByRef command As GeolayoutCommand, SegPointer As Integer)
                command.Position = &H4
                command.Write(SegPointer)
                command.Position = 0
            End Sub
        End Class

        Public Class cgLoadDisplayListWithOffset
            Shared Function GetDrawingLayer(ByRef command As GeolayoutCommand) As Byte
                command.Position = &H1
                Dim value = command.ReadByte
                command.Position = 0
                Return value
            End Function
            Shared Sub SetDrawingLayer(ByRef command As GeolayoutCommand, Layer As Byte)
                command.Position = &H1
                command.Write(Layer)
                command.Position = 0
            End Sub

            Shared Function GetOffset(ByRef command As GeolayoutCommand) As Vector3
                command.Position = 2
                Dim value As New Vector3
                value.X = command.ReadInt16
                value.Y = command.ReadInt16
                value.Z = command.ReadInt16
                command.Position = 0
                Return value
            End Function
            Shared Sub SetOffset(ByRef Command As GeolayoutCommand, value As Vector3)
                Command.Position = 2
                Command.Write(CShort(value.X))
                Command.Write(CShort(value.Y))
                Command.Write(CShort(value.Z))
                Command.Position = 0
            End Sub
            Shared Sub SetOffset(ByRef Command As GeolayoutCommand, X As Int32, Y As Int32, Z As Int32)
                SetOffset(Command, New Vector3(X, Y, Z))
            End Sub

            Shared Function GetSegGeopointer(ByRef command As GeolayoutCommand) As UInteger
                command.Position = &H8
                Dim value = command.ReadUInt32
                command.Position = 0
                Return value
            End Function
            Shared Sub SetSegGeopointer(ByRef command As GeolayoutCommand, SegPointer As UInteger)
                command.Position = &H8
                command.Write(SegPointer)
                command.Position = 0
            End Sub
        End Class
    End Namespace

End Namespace
