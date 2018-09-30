Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports S3DFileParser
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Fast3D.DisplayLists.Script
Imports SM64Lib.Model.Fast3D.DisplayLists.Script.Commands
Imports SM64Lib.Script

Namespace Global.SM64Lib.Model.Fast3D.DisplayLists

    Public Class DisplayListCollection
        Inherits List(Of DisplayList)

        Public Function ToObject3D(rommgr As RomManager, AreaID As Byte?) As Object3D
            Dim obj As New Object3D

            For Each dl As DisplayList In Me
                dl.ToObject3D(obj, rommgr, AreaID)
            Next

            Return obj
        End Function

        Public Overloads Sub Clear()
            Me.Close()
            MyBase.Clear()
        End Sub

        Public Sub Close()
            For Each dl In Me
                dl.Close()
            Next
        End Sub
    End Class

    Public Class DisplayList

        Public ReadOnly Property Script As New Script.DisplayListScript
        Public Property GeoPointer As Geopointer = Nothing
        'Public Property Data As Stream = Nothing

        Public Sub New()
        End Sub

        Public Sub New(gp As Geopointer)
            Me._GeoPointer = gp
        End Sub

        Public Sub TryFromStream(gp As Geopointer, rommgr As RomManager, AreaID As Byte?)
            Try
                FromStream(gp, rommgr, AreaID)
            Catch ex As Exception
            End Try
        End Sub
        Public Function TryFromStreamAsync(gp As Geopointer, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() TryFromStream(gp, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub FromStream(gp As Geopointer, rommgr As RomManager, AreaID As Byte?)
            _GeoPointer = gp
            Script.FromStream(rommgr, gp.SegPointer, AreaID)
        End Sub
        Public Function FromStreamAsync(gp As Geopointer, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() FromStream(gp, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub TryToObject3D(obj As Object3D, rommgr As RomManager, AreaID As Byte?)
            Try
                ToObject3D(obj, rommgr, AreaID)
            Catch ex As Exception
            End Try
        End Sub
        Public Function TryToObject3DAsync(obj As Object3D, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() TryToObject3D(obj, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub ToObject3D(obj As Object3D, rommgr As RomManager, AreaID As Byte?)
            SM64Convert.Fast3DParser.Convert(obj, Me, rommgr, AreaID)
        End Sub
        Public Function ToObject3DAsync(obj As Object3D, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() ToObject3D(obj, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub Close()
            Script.Close()
        End Sub

    End Class

    Namespace Script

        Public Class DisplayListScript
            Inherits List(Of DisplayListCommand)

            Public Sub FromStream(rommgr As RomManager, segAddress As Integer, AreaID As Byte?)
                Close()

                Dim lastPositions As New Stack(Of Integer)
                Dim curSeg As SegmentedBank = FromStream_GetSegBank(rommgr, segAddress, AreaID)

                If curSeg Is Nothing Then Return
                curSeg.Data.Position = curSeg.BankOffsetFromSegAddr(segAddress)

                Do While curSeg.Data.Position < curSeg.Length
                    'Read Command
                    Dim cmdbytes() As Byte = New Byte(7) {}
                    curSeg.Data.Read(cmdbytes, 0, cmdbytes.Length)

                    'Create & Add Command
                    Dim cmd As New DisplayListCommand(cmdbytes)
                    Me.Add(cmd)

                    Select Case cmd.CommandType
                        Case CommandTypes.F3D_NOOP
                            Dim br As New BinaryStreamData(cmd)
                            cmd.Position = 0
                            Dim checkVal As Integer = br.ReadInt32
                            cmd.Position = 0
                            If checkVal <> 0 Then Exit Do

                        Case CommandTypes.F3D_DisplayList
                            Dim br As New BinaryStreamData(cmd)
                            cmd.Position = 4
                            Dim segAddr As Integer = br.ReadInt32
                            cmd.Position = 0

                            curSeg = FromStream_GetSegBank(rommgr, segAddr, AreaID)

                            If curSeg IsNot Nothing Then
                                If cmdbytes(1) <> 1 Then
                                    lastPositions.Push(curSeg.Data.Position)
                                Else
                                    lastPositions.Clear()
                                End If
                                curSeg.Data.Position = curSeg.BankOffsetFromSegAddr(segAddr)
                            Else Exit Do
                            End If

                        Case CommandTypes.F3D_EndDisplaylist
                            If lastPositions.Count > 0 Then
                                curSeg.Data.Position = lastPositions.Pop
                            Else
                                Exit Do
                            End If

                    End Select

                Loop
            End Sub

            Private Function FromStream_GetSegBank(rommgr As RomManager, segAddr As Integer, areaID As Byte?) As SegmentedBank
                Dim seg As SegmentedBank = rommgr.GetSegBank(segAddr >> 24, areaID)
                seg?.ReadDataIfNull(rommgr.RomFile)
                Return seg
            End Function

            Public Sub ToStream(s As Stream, pos As UInteger)
                s.Position = pos
                For Each cmd As DisplayListCommand In Me
                    s.Write(cmd.ToArray, 0, cmd.Length)
                Next
            End Sub

            Public Sub Close()
                For Each cmd In Me
                    cmd.Close()
                Next
            End Sub
        End Class

        Public Class DisplayListCommand
            Inherits MemoryStream
            Implements ICommand
            Public Property CommandType As CommandTypes = CommandTypes.F3D_EndDisplaylist

            Public Property RomAddress As Integer = 0 Implements ICommand.RomAddress
            Public Property BankAddress As Integer = 0 Implements ICommand.BankAddress

            Public ReadOnly Property IsDirty As Boolean Implements ICommand.IsDirty
                Get
                    Throw New NotImplementedException()
                End Get
            End Property

            Public Sub New(CommandType As Byte)
                Me.CommandType = Command()
                SetLength(&H8)
                Position = 0
                WriteByte(CommandType)
                Position = 0
            End Sub

            Public Sub New(CommandType As String)
                Me.New(Convert.ToByte(CommandType, 16))
            End Sub

            Public Sub New(bytes() As Byte)
                CommandType = bytes(0)
                SetLength(bytes.Count)
                For Each b In bytes
                    WriteByte(b)
                Next
                Position = 0
            End Sub

            Public Overrides Function ToString() As String
                ToString = $"{RomAddress.ToString("X")}:"
                For Each b As Byte In Me.ToArray
                    ToString &= " " & b.ToString("X2")
                Next
            End Function

        End Class

        Namespace Commands

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
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 2
                    Dim value = br.ReadInt16
                    cmd.Position = 0
                    Return value
                End Function

                Shared Function GetSegmentedAddress(cmd As DisplayListCommand) As Int32
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim value = br.ReadInt32
                    cmd.Position = 0
                    Return value
                End Function
                Shared Sub SetSegmentedAddress(cmd As DisplayListCommand, value As Int32)
                    Dim bw As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    bw.Write(value)
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
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim tsX As UInt16 = br.ReadUInt16
                    Dim tsY As UInt16 = br.ReadUInt16
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
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim tsX As UInt16 = br.ReadUInt16
                    Dim tsY As UInt16 = br.ReadUInt16
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
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim value = br.ReadInt32
                    cmd.Position = 0
                    Return value
                End Function

                Shared Sub SetSegmentedAddress(cmd As DisplayListCommand, value As Int32)
                    Dim bw As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    bw.Write(value)
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
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim var As Integer = br.ReadInt32
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

                    Dim bw As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    bw.Write(var)
                    cmd.Position = 0
                End Sub
            End Class

            Public Class F3D_MOVEMEM
                Shared Function GetSegmentedOffset(cmd As DisplayListCommand) As Int32
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim value = br.ReadInt32
                    cmd.Position = 0
                    Return value
                End Function
                Shared Sub SetSegmentedOffset(cmd As DisplayListCommand, value As Integer)
                    Dim bw As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    bw.Write(value)
                    cmd.Position = 0
                End Sub

                Shared Function GetLightValueMode(cmd As DisplayListCommand) As Byte
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 1
                    Dim value = br.ReadByte
                    cmd.Position = 0
                    Return value
                End Function
            End Class

            Public Class F3D_CLEARGEOMETRYMODE
                Shared Function GetGeometryMode(cmd As DisplayListCommand) As UInteger
                    Dim br As New BinaryStreamData(cmd)
                    cmd.Position = 4
                    Dim flag As UInteger = br.ReadUInt32
                    cmd.Position = 0
                    Return flag
                End Function
            End Class

            Public Class F3D_SETRGEOMETRYMODE
                Inherits F3D_CLEARGEOMETRYMODE
            End Class

        End Namespace

        Public Enum CommandTypes
            F3D_NOOP = &H0
            F3D_Movemem = &H3
            F3D_DisplayList = &H6
            F3D_EndDisplaylist = &HB8
            F3D_Vertex = &H4
            F3D_Triangle1 = &HBF
            F3D_ClearGeometryMode = &HB6
            F3D_SetGeometryMode = &HB7
            G_Loadtlut = &HF0
            G_SetTileSize = &HF2
            G_SetImage = &HFD
            G_Loadback = &HF3
            G_SetTile = &HF5
            G_Texture = &HBB
        End Enum

    End Namespace

End Namespace
