Imports System.IO
Imports System.Numerics
Imports SM64Lib.Data
Imports SM64Lib.Script

Namespace Global.SM64Lib.Levels.Script

    Public Class ObjBParams
        Public Property BParam1 As Byte = 0
        Public Property BParam2 As Byte = 0
        Public Property BParam3 As Byte = 0
        Public Property BParam4 As Byte = 0

        Public Sub New()
        End Sub

        Public Sub New(BParam1 As Byte, BParam2 As Byte, BParam3 As Byte, BParam4 As Byte)
            Me.BParam1 = BParam1
            Me.BParam2 = BParam2
            Me.BParam3 = BParam3
            Me.BParam4 = BParam4
        End Sub
    End Class

    Namespace Commands

        Public Class clJumpToSegAddr 'Jump to
            Public Shared Function GetSegJumpAddr(Command As LevelscriptCommand) As Integer
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim jumpaddr = SwapInts.SwapInt32(br.ReadInt32)
                Command.Position = 0
                Return jumpaddr
            End Function
            Public Shared Sub SetSegJumpAddr(Command As LevelscriptCommand, SegJumpAddr As Integer)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(SwapInts.SwapUInt32(SegJumpAddr))
                Command.Position = 0
            End Sub
        End Class

        Public Class clStartArea 'Start Area
            Public Shared Function GetAreaID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 2
                Dim areaid As Integer = br.ReadByte
                Command.Position = 0
                Return areaid
            End Function
            Public Shared Sub SetAreaID(Command As LevelscriptCommand, AreaID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 2
                bw.Write(AreaID)
                Command.Position = 0
            End Sub

            Public Shared Function GetSegGeolayoutAddr(Command As LevelscriptCommand) As UInteger
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim SegGeolayoutAddr As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                Command.Position = 0
                Return SegGeolayoutAddr
            End Function
            Public Shared Sub SetSegGeolayoutAddr(Command As LevelscriptCommand, SegGeolayoutAddr As UInteger)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(SwapInts.SwapUInt32(SegGeolayoutAddr))
                Command.Position = 0
            End Sub
        End Class

        Public Class clNormal3DObject 'Object
            Public Shared Function GetActs(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 2
                Dim Acts As Integer = br.ReadByte
                Command.Position = 0
                Return Acts
            End Function
            Public Shared Sub SetActs(Command As LevelscriptCommand, Acts As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 2
                bw.Write(Acts)
                Command.Position = 0
            End Sub

            Public Shared Function GetModelID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim ModelID As Integer = br.ReadByte
                Command.Position = 0
                Return ModelID
            End Function
            Public Shared Sub SetModelID(Command As LevelscriptCommand, ModelID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(ModelID)
                Command.Position = 0
            End Sub

            Public Shared Function GetPosition(Command As LevelscriptCommand) As Vector3
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim Pos As New Vector3
                Pos.X = SwapInts.SwapInt16(br.ReadInt16)
                Pos.Y = SwapInts.SwapInt16(br.ReadInt16)
                Pos.Z = SwapInts.SwapInt16(br.ReadInt16)
                Command.Position = 0
                Return Pos
            End Function
            Public Shared Sub SetPosition(Command As LevelscriptCommand, Pos As Vector3)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(SwapInts.SwapInt16(Pos.X))
                bw.Write(SwapInts.SwapInt16(Pos.Y))
                bw.Write(SwapInts.SwapInt16(Pos.Z))
                Command.Position = 0
            End Sub

            Public Shared Function GetRotation(Command As LevelscriptCommand) As Vector3
                Dim br As New BinaryReader(Command)
                Command.Position = 10
                Dim Rot As New Vector3
                Rot.X = SwapInts.SwapInt16(br.ReadInt16)
                Rot.Y = SwapInts.SwapInt16(br.ReadInt16)
                Rot.Z = SwapInts.SwapInt16(br.ReadInt16)
                Command.Position = 0
                Return Rot
            End Function
            Public Shared Sub SetRotation(Command As LevelscriptCommand, Rot As Vector3)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 10
                bw.Write(SwapInts.SwapInt16(Rot.X))
                bw.Write(SwapInts.SwapInt16(Rot.Y))
                bw.Write(SwapInts.SwapInt16(Rot.Z))
                Command.Position = 0
            End Sub

            Public Shared Function GetParams(Command As LevelscriptCommand) As ObjBParams
                Dim br As New BinaryReader(Command)
                Command.Position = 16
                Dim Params As New ObjBParams
                Params.BParam1 = br.ReadByte
                Params.BParam2 = br.ReadByte
                Params.BParam3 = br.ReadByte
                Params.BParam4 = br.ReadByte
                Command.Position = 0
                Return Params
            End Function
            Public Shared Sub SetParams(Command As LevelscriptCommand, Params As ObjBParams)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 16
                bw.Write(Params.BParam1)
                bw.Write(Params.BParam2)
                bw.Write(Params.BParam3)
                bw.Write(Params.BParam4)
                Command.Position = 0
            End Sub

            Public Shared Function GetSegBehaviorAddr(Command As LevelscriptCommand) As UInteger
                Dim br As New BinaryReader(Command)
                Command.Position = 20
                Dim SegBehaviorAddr As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                Command.Position = 0
                Return SegBehaviorAddr
            End Function
            Public Shared Sub SetSegBehaviorAddr(Command As LevelscriptCommand, SegBehaviorAddr As UInteger)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 20
                bw.Write(SwapInts.SwapUInt32(SegBehaviorAddr))
                Command.Position = 0
            End Sub

            Public Shared Sub UpdateScrollingTexturePointer(Command As LevelscriptCommand, Difference As UInteger)
                MsgBox("UpdateScrollingTexturePointer() is not done!")
            End Sub

            Public Shared Function GetListBoxText(Command As LevelscriptCommand) As String
                Return "GetListBoxText() is not done!"
            End Function
        End Class

        Public Class clWarp 'Warp
            Public Shared Function GetWarpID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 2
                Dim ID As Byte = br.ReadByte
                Command.Position = 0
                Return ID
            End Function
            Public Shared Sub SetWarpID(Command As LevelscriptCommand, ID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 2
                bw.Write(ID)
                Command.Position = 0
            End Sub

            Public Shared Function GetDestinationLevelID(Command As LevelscriptCommand) As Levels
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim LevelID As Levels = br.ReadByte
                Command.Position = 0
                Return LevelID
            End Function
            Public Shared Sub SetDestinationLevelID(Command As LevelscriptCommand, LevelID As Levels)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(CByte(LevelID))
                Command.Position = 0
            End Sub

            Public Shared Function GetDestinationAreaID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim ID As Byte = br.ReadByte
                Command.Position = 0
                Return ID
            End Function
            Public Shared Sub SetDestinationAreaID(Command As LevelscriptCommand, ID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(ID)
                Command.Position = 0
            End Sub

            Public Shared Function GetDestinationWarpID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 5
                Dim ID As Byte = br.ReadByte
                Command.Position = 0
                Return ID
            End Function
            Public Shared Sub SetDestinationWarpID(Command As LevelscriptCommand, ID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 5
                bw.Write(ID)
                Command.Position = 0
            End Sub

            Public Shared Function GetCreateCheckpoint(cmd As LevelscriptCommand) As Boolean
                Dim data As New BinaryStreamData(cmd)
                data.Position = 6
                Return Bits.GetBoolOfByte(data.ReadByte, 0)
            End Function
            Public Shared Sub SetCreateCheckpoint(cmd As LevelscriptCommand, value As Boolean)
                Dim data As New BinaryStreamData(cmd)
                data.Position = 6
                Dim b As Byte = data.ReadByte
                b = Bits.SetInByte(b, 0, value)
                data.Position -= 1
                data.Write(b)
            End Sub

        End Class

        Public Class clInstantWarp
            Public Shared Function GetCollisionType(cmd As LevelscriptCommand) As Byte
                cmd.Position = 2
                Dim value As Byte = cmd.ReadByte
                cmd.Position = 0
                Return value
            End Function
            Public Shared Sub SetCollisionType(cmd As LevelscriptCommand, collisionType As Byte)
                cmd.Position = 2
                cmd.WriteByte(collisionType)
                cmd.Position = 0
            End Sub

            Public Shared Function GetAreaID(cmd As LevelscriptCommand) As Byte
                cmd.Position = 3
                Dim value As Byte = cmd.ReadByte
                cmd.Position = 0
                Return value
            End Function
            Public Shared Sub SetAreaID(cmd As LevelscriptCommand, areaID As Byte)
                cmd.Position = 3
                cmd.WriteByte(areaID)
                cmd.Position = 0
            End Sub

            Public Shared Function GetLocation(cmd As LevelscriptCommand) As Vector3
                Dim br As New BinaryReader(cmd)
                cmd.Position = 4

                Dim x As Int16 = SwapInts.SwapInt16(br.ReadInt16)
                Dim y As Int16 = SwapInts.SwapInt16(br.ReadInt16)
                Dim z As Int16 = SwapInts.SwapInt16(br.ReadInt16)

                cmd.Position = 0
                Return New Vector3(x, y, z)
            End Function
            Public Shared Sub SetLocation(cmd As LevelscriptCommand, loc As Vector3)
                Dim bw As New BinaryWriter(cmd)
                cmd.Position = 4

                bw.Write(SwapInts.SwapInt16(loc.X))
                bw.Write(SwapInts.SwapInt16(loc.Y))
                bw.Write(SwapInts.SwapInt16(loc.Z))

                cmd.Position = 0
            End Sub
        End Class

        Public Class clAreaCollision 'Area Collision
            Public Shared Function GetAreaCollision(Command As LevelscriptCommand) As UInteger
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim AreaCollision As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                Command.Position = 0
                Return AreaCollision
            End Function
            Public Shared Sub SetAreaCollision(Command As LevelscriptCommand, AreaCollision As UInteger)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(SwapInts.SwapUInt32(AreaCollision))
                Command.Position = 0
            End Sub
        End Class

        Public Class clTerrian 'Terrian-Type
            Public Shared Function GetTerrainType(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim Type As Integer = br.ReadByte
                Command.Position = 0
                Return Type
            End Function
            Public Shared Sub SetTerrainType(Command As LevelscriptCommand, Type As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(Type)
                Command.Position = 0
            End Sub
        End Class

        Public Class clAreaMusic 'Area Music
            Public Shared Function GetMusicID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 5
                Dim MusicID As Integer = br.ReadByte
                Command.Position = 0
                Return MusicID
            End Function
            Public Shared Sub SetMusicID(Command As LevelscriptCommand, MusicID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 5
                bw.Write(MusicID)
                Command.Position = 0
            End Sub
        End Class

        Public Class clAreaMusicSimple 'Area Music
            Public Shared Function GetMusicID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim MusicID As Integer = br.ReadByte
                Command.Position = 0
                Return MusicID
            End Function
            Public Shared Sub SetMusicID(Command As LevelscriptCommand, MusicID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(MusicID)
                Command.Position = 0
            End Sub
        End Class

        Public Class clLoadRomToRam '0x17 Load ROM to RAM
            Public Shared Function GetParam1(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 2
                Dim value As Integer = br.ReadByte
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetParam1(Command As LevelscriptCommand, value As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 2
                bw.Write(value)
                Command.Position = 0
            End Sub

            Public Shared Function GetSegmentedID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim value As Integer = br.ReadByte
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetSegmentedID(Command As LevelscriptCommand, ID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(ID)
                Command.Position = 0
            End Sub

            Public Shared Function GetRomStart(Command As LevelscriptCommand) As Integer
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim value As Integer = SwapInts.SwapInt32(br.ReadInt32)
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetRomStart(Command As LevelscriptCommand, Address As Integer)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(SwapInts.SwapInt32(Address))
                Command.Position = 0
            End Sub

            Public Shared Function GetRomEnd(Command As LevelscriptCommand) As Integer
                Dim br As New BinaryReader(Command)
                Command.Position = 8
                Dim value As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetRomEnd(Command As LevelscriptCommand, Address As Integer)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 8
                bw.Write(SwapInts.SwapUInt32(Address))
                Command.Position = 0
            End Sub

            Public Shared Function GetSegmentedAddressToJump(Command As LevelscriptCommand) As Integer
                Dim br As New BinaryReader(Command)
                Command.Position = 12
                Dim value As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetSegmentedAddressToJump(Command As LevelscriptCommand, Address As Integer)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 12
                bw.Write(SwapInts.SwapUInt32(Address))
                Command.Position = 0
            End Sub
        End Class

        Public Class clDefaultPosition
            Public Shared Function GetAreaID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 2
                Dim value = br.ReadByte
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetAreaID(Command As LevelscriptCommand, value As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 2
                bw.Write(value)
                Command.Position = 0
            End Sub

            Public Shared Function GetPosition(Command As LevelscriptCommand) As Vector3
                Dim br As New BinaryReader(Command)
                Command.Position = 6
                Dim value As New Vector3
                value.X = SwapInts.SwapInt16(br.ReadInt16)
                value.Y = SwapInts.SwapInt16(br.ReadInt16)
                value.Z = SwapInts.SwapInt16(br.ReadInt16)
                Command.Position = 0
                Return value
            End Function
            Public Shared Sub SetPosition(Command As LevelscriptCommand, value As Vector3)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 6
                bw.Write(SwapInts.SwapInt16(value.X))
                bw.Write(SwapInts.SwapInt16(value.Y))
                bw.Write(SwapInts.SwapInt16(value.Z))
                Command.Position = 0
            End Sub
            Public Shared Sub SetPosition(Command As LevelscriptCommand, X As Int32, Y As Int32, Z As Int32)
                SetPosition(Command, New Vector3(X, Y, Z))
            End Sub

            Public Shared Function GetRotation(Command As LevelscriptCommand) As Int16
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim value = SwapInts.SwapInt16(br.ReadInt16)
                Command.Position = 0
                value = value Mod 360
                If value < 0 Then value *= -1
                Return value
            End Function
            Public Shared Sub SetRotation(Command As LevelscriptCommand, value As Int16)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                If value < 0 Then value *= -1
                value = value Mod 360
                bw.Write(SwapInts.SwapInt16(value))
                Command.Position = 0
            End Sub
        End Class

        Public Class clLoadPolygonWithoutGeo
            Inherits clLoadPolygonWithGeo

            Public Shared Function GetDrawingLayer(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim areaid As Integer = br.ReadByte
                Command.Position = 0
                Return areaid >> 4
            End Function
            Public Shared Sub SetDrawingLayer(Command As LevelscriptCommand, layer As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(layer << 4)
                Command.Position = 0
            End Sub
        End Class

        Public Class clLoadPolygonWithGeo
            Public Shared Function GetModelID(Command As LevelscriptCommand) As Byte
                Dim br As New BinaryReader(Command)
                Command.Position = 3
                Dim areaid As Integer = br.ReadByte
                Command.Position = 0
                Return areaid
            End Function
            Public Shared Sub SetModelID(Command As LevelscriptCommand, ModelID As Byte)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 3
                bw.Write(ModelID)
                Command.Position = 0
            End Sub

            Public Shared Function GetSegAddress(Command As LevelscriptCommand) As Integer
                Dim br As New BinaryReader(Command)
                Command.Position = 4
                Dim SegGeolayoutAddr = SwapInts.SwapInt32(br.ReadInt32)
                Command.Position = 0
                Return SegGeolayoutAddr
            End Function
            Public Shared Sub SetSegAddress(Command As LevelscriptCommand, SegAddress As Integer)
                Dim bw As New BinaryWriter(Command)
                Command.Position = 4
                bw.Write(SwapInts.SwapInt32(SegAddress))
                Command.Position = 0
            End Sub
        End Class

        Public Class clShowDialog
            Public Shared Function GetDialogID(cmd As LevelscriptCommand) As Byte
                cmd.Position = 3
                Dim dialogID As Byte = cmd.ReadByte
                cmd.Position = 0
                Return dialogID
            End Function
            Public Shared Sub SetDialogID(cmd As LevelscriptCommand, dialogID As Byte)
                cmd.Position = 3
                cmd.WriteByte(dialogID)
                cmd.Position = 0
            End Sub
        End Class

        Public Class clScrollingTexture

            Public Shared Function GetCountOfFaces(cmd As LevelscriptCommand) As UShort
                Dim br As New BinaryReader(cmd)
                cmd.Position = 4
                Dim val As UShort = SwapInts.SwapUInt16(br.ReadUInt16)
                cmd.Position = 0
                Return val
            End Function
            Public Shared Sub SetCountOfFaces(cmd As LevelscriptCommand, count As UShort)
                Dim bw As New BinaryWriter(cmd)
                cmd.Position = 4
                bw.Write(SwapInts.SwapUInt16(count))
                cmd.Position = 0
            End Sub

            Public Shared Function GetVertexPointer(cmd As LevelscriptCommand) As UInteger
                Dim br As New BinaryReader(cmd)
                cmd.Position = &H10
                Dim value As Integer = SwapInts.SwapInt32(br.ReadInt32)
                Return value
            End Function
            Public Shared Sub SetVertexPointer(cmd As LevelscriptCommand, ptr As UInteger)
                Dim bw As New BinaryWriter(cmd)
                cmd.Position = &H10
                bw.Write(SwapInts.SwapInt32(ptr))
                cmd.Position = 0
            End Sub

            Public Shared Function GetCycleDuration(cmd As LevelscriptCommand) As Byte
                cmd.Position = 7
                Dim val As Byte = cmd.ReadByte
                cmd.Position = 0
                Return val
            End Function
            Public Shared Sub SetCycleDuration(cmd As LevelscriptCommand, ptr As Byte)
                cmd.Position = 7
                cmd.WriteByte(ptr)
                cmd.Position = 0
            End Sub

            Public Shared Function GetScrollBehavior(cmd As LevelscriptCommand) As Byte
                cmd.Position = 6
                Dim val As Byte = cmd.ReadByte And &HE0
                cmd.Position = 0
                Return val
            End Function
            Public Shared Sub SetScrollBehavior(cmd As LevelscriptCommand, behav As Byte)
                Dim val As Byte = GetScrollType(cmd)
                val = val Or behav

                cmd.Position = 6
                cmd.WriteByte(val)
                cmd.Position = 0
            End Sub

            Public Shared Function GetScrollType(cmd As LevelscriptCommand) As Byte
                cmd.Position = 6
                Dim val As Byte = cmd.ReadByte And &H1F
                cmd.Position = 0
                Return val
            End Function
            Public Shared Sub SetScrollType(cmd As LevelscriptCommand, behav As Byte)
                Dim val As Byte = GetScrollBehavior(cmd)
                val = val Or behav

                cmd.Position = 6
                cmd.WriteByte(val)
                cmd.Position = 0
            End Sub

            Public Shared Function GetScrollSpeed(cmd As LevelscriptCommand) As Int16
                Dim br As New BinaryReader(cmd)
                cmd.Position = 8
                Dim val As Int16 = SwapInts.SwapInt16(br.ReadInt16)
                cmd.Position = 0
                Return val
            End Function
            Public Shared Sub SetScrollSpeed(cmd As LevelscriptCommand, count As Int16)
                Dim bw As New BinaryWriter(cmd)
                cmd.Position = 8
                bw.Write(SwapInts.SwapInt16(Math.Min(count, &HFFF)))
                cmd.Position = 0
            End Sub

        End Class

    End Namespace

End Namespace
