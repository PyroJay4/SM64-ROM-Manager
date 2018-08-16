Imports System.IO
Imports S3DFileParser
Imports System.Numerics
Imports System.Windows.Forms
Imports Extensions

Namespace Global.SM64Lib.Model.Collision

    Public Class CollisionMap
        Implements IToObject3D

        Public Property Vertices As New VertexList
        Public Property Triangles As New TriangleList
        Public Property SpecialBoxes As New List(Of BoxData)
        Private ReadOnly ColtypesWithParams() As Byte = {14, 44, 36, 37, 39, 45}
        Private _Length As Integer = 0

        Public Sub FromRom(FileName As String, RomOffset As Integer)
            Dim fs As New FileStream(FileName, FileMode.Open, FileAccess.Read)
            FromStream(fs, RomOffset)
            fs.Close()
        End Sub
        Public Function FromRomAsync(FileName As String, RomOffset As Integer) As Task
            Dim t As New Task(Sub() FromRom(FileName, RomOffset))
            t.Start()
            Return t
        End Function

        Public Sub FromStream(s As Stream, RomOffset As Integer)
            Vertices.Clear()
            Triangles.Clear()
            SpecialBoxes.Clear()

            Dim br As New BinaryReader(s)
            s.Position = RomOffset

            Do
                Dim curVal As Int16 = SwapInts.SwapInt16(br.ReadInt16)
                Select Case curVal
                    Case &H40 'S T A R T   O F   V E R T I C E S
                        'Lese Eckpunkte / Read Vertices
                        For i As Integer = 1 To SwapInts.SwapUInt16(br.ReadUInt16)
                            Dim nVert As New Vertex With {
                            .X = SwapInts.SwapInt16(br.ReadInt16),
                            .Y = SwapInts.SwapInt16(br.ReadInt16),
                            .Z = SwapInts.SwapInt16(br.ReadInt16)}
                            Vertices.Add(nVert)
                        Next

                        'Lese und erstelle Polygone / Read and build polygones
                        If Vertices.Count > 0 Then
                            Dim ende As Boolean = False
                            Do Until ende
                                Dim Coltype As Int16 = SwapInts.SwapInt16(br.ReadInt16)
                                If Not Coltype.IsInRange(&H40, &H44) Then
                                    For i As Integer = 1 To SwapInts.SwapUInt16(br.ReadUInt16)
                                        Dim pol As New Triangle With {.CollisionType = Coltype}

                                        For iv As Integer = 0 To pol.Vertices.Count - 1
                                            pol.Vertices(iv) = Vertices(SwapInts.SwapInt16(br.ReadInt16))
                                        Next

                                        If ColtypesWithParams.Contains(Coltype) Then
                                            For ip As Integer = 0 To pol.ColParams.Count - 1
                                                pol.ColParams(ip) = br.ReadByte
                                            Next
                                        End If

                                        Triangles.Add(pol)
                                    Next
                                Else
                                    ende = True
                                End If
                            Loop
                        End If

                    Case &H41 'E N D   O F   0 x 4 0   C O M M A N D

                    Case &H42 'E N D   O F   C O L L I S I O N   D A T A
                        Exit Do

                    Case &H43 'S P E C I A L   O B J E C T
                            'Dont know what this is.

                    Case &H44 'W A T E R   B O X E S
                        SpecialBoxes.AddRange(ReadBoxData(s))

                End Select
            Loop

            _Length = s.Position - RomOffset
        End Sub
        Public Function FromStreamAsync(s As Stream, RomOffset As Integer) As Task
            Dim t As New Task(Sub() FromStream(s, RomOffset))
            t.Start()
            Return t
        End Function

        Private Shared Function ReadBoxData(s As Stream) As BoxData()
            Dim br As New BinaryReader(s)
            Dim spBoxes As New List(Of BoxData)
            For i As Integer = 1 To SwapInts.SwapInt16(br.ReadInt16)
                Dim wb As New BoxData
                wb.Type = SwapInts.SwapInt16(br.ReadInt16)
                wb.X1 = SwapInts.SwapInt16(br.ReadInt16)
                wb.Z1 = SwapInts.SwapInt16(br.ReadInt16)
                wb.X2 = SwapInts.SwapInt16(br.ReadInt16)
                wb.Z2 = SwapInts.SwapInt16(br.ReadInt16)
                wb.Y = SwapInts.SwapInt16(br.ReadInt16)
                spBoxes.Add(wb)
                Application.DoEvents()
            Next
            Return spBoxes.ToArray
        End Function

        Public Sub FromObject3D(ObjSettings As ObjInputSettings, model As Object3D, Optional colSettings As CollisionSettings = Nothing)
            Dim dicMatNames As New Dictionary(Of Material, String)

            'Clear Lists
            Vertices.Clear()
            Triangles.Clear()

            'Create MatNames
            For Each kvp As KeyValuePair(Of String, Material) In model.Materials
                dicMatNames.Add(kvp.Value, kvp.Key)
            Next

            'Add Faces
            Dim dicVertices As New Dictionary(Of S3DFileParser.Vertex, Vertex)

            For Each m As S3DFileParser.Mesh In model.Meshes
                For Each f As S3DFileParser.Face In m.Faces.OrderBy(Function(n) n.Material)
                    Dim cs As CollisionSettings.Entry = colSettings.GetEntry(dicMatNames(f.Material))

                    If Not cs.IsNonSolid Then
                        Dim t As New Triangle

                        t.CollisionType = cs.CollisionType
                        t.ColParams(0) = cs.CollisionParam1
                        t.ColParams(0) = cs.CollisionParam2

                        For i As Integer = 0 To Math.Min(f.Points.Count - 1, 2)
                            Dim v As Vertex
                            Dim curVert As S3DFileParser.Vertex = f.Points(i).Vertex

                            If dicVertices.ContainsKey(curVert) Then
                                v = dicVertices(curVert)
                            Else
                                v = New Vertex
                                v.X = LongToInt16(Round(curVert.X * ObjSettings.Scaling))
                                v.Y = LongToInt16(Round(curVert.Y * ObjSettings.Scaling))
                                v.Z = LongToInt16(Round(curVert.Z * ObjSettings.Scaling))
                                Vertices.Add(v)
                                dicVertices.Add(curVert, v)
                            End If

                            t.Vertices(i) = v
                        Next

                        Triangles.Add(t)
                    End If
                Next
            Next
        End Sub
        Public Function FromObject3DAsync(ObjSettings As ObjInputSettings, model As Object3D, Optional colSettings As CollisionSettings = Nothing) As Task
            Dim t As New Task(Sub() FromObject3D(ObjSettings, model, colSettings))
            t.Start()
            Return t
        End Function

        Public Sub ToStream(ByRef s As Stream, RomOffset As Integer)
            Dim bw As New BinaryWriter(s)
            s.Position = RomOffset

            'V E R T I C E S

            If Vertices.Count > 0 Then
                'Start vertices
                bw.Write(SwapInts.SwapInt16(&H40))
                bw.Write(SwapInts.SwapUInt16(Vertices.Count))

                'Write vertices data
                For Each vert In Vertices
                    bw.Write(SwapInts.SwapInt16(vert.X))
                    bw.Write(SwapInts.SwapInt16(vert.Y))
                    bw.Write(SwapInts.SwapInt16(vert.Z))
                Next
            End If

            'P O L Y G O N E S

            For Each curType As Byte In UsedPolytypes()
                'Search for all triangles with current collision type
                Dim tries As Triangle() = Triangles.Where(Function(n) n.CollisionType = curType).ToArray

                If tries.Length > 0 Then
                    'Write new collision type
                    bw.Write(SwapInts.SwapInt16(curType))

                    'Write count of triangles
                    bw.Write(SwapInts.SwapUInt16(tries.Length))

                    'Check if collisiontype has params
                    Dim hasParams As Boolean = ColtypesWithParams.Contains(curType)

                    For Each tri As Triangle In tries
                        'Write Vertex Indicies
                        For Each vert As Vertex In tri.Vertices
                            bw.Write(SwapInts.SwapUInt16(vert.Index))
                        Next

                        'Write Collision Params, if avaiable
                        If hasParams Then
                            For ip As Integer = 0 To tri.ColParams.Count - 1
                                bw.Write(tri.ColParams(ip))
                            Next
                        End If
                    Next
                End If
            Next

            'For Each t In UsedPolytypes()
            '    Dim tries As Triangle() = Triangles.Where(Function(n) n.CollisionType = t).ToArray
            '    If tries.Count = 0 Then Continue For

            '    'Write collision type
            '    bw.Write(SwapInts.SwapInt16(t))

            '    'Write count of triangles
            '    bw.Write(SwapInts.SwapUInt16(tries.Length))

            '    For Each tri As Triangle In tries
            '        'Write Vertex Indicies
            '        For Each v As Vertex In tri.Vertices
            '            bw.Write(SwapInts.SwapInt16(v.Index))
            '        Next

            '        'Write Collision Params, if avaiable.
            '        If ColtypesWithParams.Contains(tri.CollisionType) Then
            '            For ip As Integer = 0 To tri.ColParams.Count - 1
            '                bw.Write(CByte(tri.ColParams(ip)))
            '            Next
            '        End If
            '    Next
            'Next

            'E N D   0 x 4 0   C O M M A N D

            bw.Write(SwapInts.SwapInt16(&H41))

            'S P E C I A L   O B J E C T S

            'Dont know what this is.

            'S P E C I A L   B O X E S

            If SpecialBoxes.Count > 0 Then
                bw.Write(SwapInts.SwapInt16(&H44))
                WriteBoxData(s, SpecialBoxes)
            End If

            'E N D   C O L L I S I O N   D A T A

            bw.Write(SwapInts.SwapInt16(&H42))
        End Sub
        Private Shared Sub WriteBoxData(s As Stream, bodex As IEnumerable(Of BoxData))
            Dim bw As New BinaryWriter(s)

            bw.Write(SwapInts.SwapInt16(bodex.Count))

            Dim cWBID As Integer = 0
            For Each wb In bodex
                bw.Write(SwapInts.SwapInt16(wb.Type))
                bw.Write(SwapInts.SwapInt16(wb.X1))
                bw.Write(SwapInts.SwapInt16(wb.Z1))
                bw.Write(SwapInts.SwapInt16(wb.X2))
                bw.Write(SwapInts.SwapInt16(wb.Z2))
                bw.Write(SwapInts.SwapInt16(wb.Y))
                cWBID += 1
            Next
        End Sub

        Public Property Length As Long
            Get
                Length = _Length
                HexRoundUp2(Length)
                Return Length
            End Get
            Set(value As Long)
                _Length = value
            End Set
        End Property

        Public Function UsedPolytypes() As Byte()
            Dim types As New List(Of Byte)

            For Each tri As Triangle In Triangles
                If Not types.Contains(tri.CollisionType) Then
                    types.Add(tri.CollisionType)
                End If
            Next

            Return types.ToArray
        End Function

        Private Function DropToGroud_GetFoundList(pos As Vector3) As Single()
            Dim found As New List(Of Single)

            For Each tri As Triangle In Triangles
                Dim a As New Vector3(tri.Vertices(0).X, tri.Vertices(0).Y, tri.Vertices(0).Z)
                Dim b As New Vector3(tri.Vertices(1).X, tri.Vertices(1).Y, tri.Vertices(1).Z)
                Dim c As New Vector3(tri.Vertices(2).X, tri.Vertices(2).Y, tri.Vertices(2).Z)

                If PointInTriangle(New Vector2(pos.X, pos.Z), a, b, c) Then
                    found.Add(barryCentric(a, b, c, pos))
                End If
            Next

            Return found.ToArray
        End Function

        Public Function DropToButtom(pos As Vector3) As Single
            Dim found() As Single = DropToGroud_GetFoundList(pos)
            Return found.Min
        End Function

        Public Function DropToTop(pos As Vector3) As Single
            Dim found() As Single = DropToGroud_GetFoundList(pos)
            Return found.Max
        End Function

        Public Function DropToNearesGround(pos As Vector3) As Single
            Dim found() As Single = DropToGroud_GetFoundList(pos)

            If found.Count = 0 Then Return pos.Y

            Dim closest_index As Integer = 0
            Dim closest_abs As Single = 9999999.0F

            For i As Integer = 0 To found.Count - 1
                Dim abs As Single = Math.Abs(pos.Y - found(i))

                If abs < closest_abs Then
                    closest_abs = abs
                    closest_index = i
                End If
            Next

            Return found(closest_index)
        End Function

        Private Shared Function PointInTriangle(p As Vector2, p0 As Vector3, p1 As Vector3, p2 As Vector3) As Boolean
            Dim s = p0.Z * p2.X - p0.X * p2.Z + (p2.Z - p0.Z) * p.X + (p0.X - p2.X) * p.Y
            Dim t = p0.X * p1.Z - p0.Z * p1.X + (p0.Z - p1.Z) * p.X + (p1.X - p0.X) * p.Y

            If (s < 0) <> (t < 0) Then Return False

            Dim A = -p1.Z * p2.X + p0.Z * (p2.X - p1.X) + p0.X * (p1.Z - p2.Z) + p1.X * p2.Z
            If A < 0.0 Then
                s = -s
                t = -t
                A = -A
            End If
            Return s > 0 AndAlso t > 0 AndAlso (s + t) <= A
        End Function

        Private Shared Function barryCentric(p1 As Vector3, p2 As Vector3, p3 As Vector3, pos As Vector3) As Single
            Dim det As Single = (p2.Z - p3.Z) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Z - p3.Z)
            Dim l1 As Single = ((p2.Z - p3.Z) * (pos.X - p3.X) + (p3.X - p2.X) * (pos.Z - p3.Z)) / det
            Dim l2 As Single = ((p3.Z - p1.Z) * (pos.X - p3.X) + (p1.X - p3.X) * (pos.Z - p3.Z)) / det
            Dim l3 As Single = 1.0F - l1 - l2
            Return l1 * p1.Y + l2 * p2.Y + l3 * p3.Y
        End Function

        Public Function ToObject3D() As Object3D Implements IToObject3D.ToObject3D
            Dim obj As New Object3D
            Dim m As New Mesh

            'Vertices
            For Each vert In Vertices
                m.Vertices.Add(New S3DFileParser.Vertex With {
                               .X = vert.X,
                               .Y = vert.Y,
                               .Z = vert.Z
                               })
            Next

            'Triangles
            For Each tri In Triangles
                Dim newTri As New Face
                For i As Integer = 0 To 2
                    Dim p As New Point With {.Vertex = m.Vertices(tri.Vertices(i).Index)}
                    newTri.Points.Add(p)
                Next
                newTri.Tag = tri.CollisionType
                m.Faces.Add(newTri)
            Next

            obj.Meshes.Add(m)
            Return obj
        End Function

        Public Function ToObject3DAsync() As Task(Of Object3D) Implements IToObject3D.ToObject3DAsync
            Dim t As New Task(Of Object3D)(AddressOf ToObject3D)
            t.Start()
            Return t
        End Function
    End Class

    Public Class Vertex
        Public Property X As Int16 = 0
        Public Property Y As Int16 = 0
        Public Property Z As Int16 = 0
        Public Property ParentList As VertexList = Nothing
        Public ReadOnly Property Index As Integer
            Get
                Return ParentList.IndexOf(Me)
            End Get
        End Property
    End Class
    Public Class VertexList
        Inherits List(Of Vertex)

        Public Overloads Sub Add(item As Vertex)
            MyBase.Add(item)
            item.ParentList = Me
        End Sub

        Public Overloads Sub Insert(index As Integer, item As Vertex)
            MyBase.Insert(index, item)
            item.ParentList = Me
        End Sub
    End Class

    Public Class Triangle
        Public Property CollisionType As Byte = 0
        Public ColParams() As Byte = {0, 0}
        Public Vertices(2) As Vertex
        Public Property ParentList As TriangleList = Nothing
        Public ReadOnly Property Index As Integer
            Get
                Return ParentList.IndexOf(Me)
            End Get
        End Property
    End Class
    Public Class TriangleList
        Inherits List(Of Triangle)

        Public Overloads Sub Add(item As Triangle)
            MyBase.Add(item)
            item.ParentList = Me
        End Sub

        Public Overloads Sub Insert(index As Integer, item As Triangle)
            MyBase.Insert(index, item)
            item.ParentList = Me
        End Sub
    End Class

    Public Class BoxData

        Public Property Type As BoxDataType = BoxDataType.Water
        Public Property X1 As Int16 = 0
        Public Property X2 As Int16 = 0
        Public Property Z1 As Int16 = 0
        Public Property Z2 As Int16 = 0
        Public Property Y As Int16 = 0

        Public Sub New()
            X1 = 8192
            X2 = -8192
            Z1 = 8192
            Z2 = -8192
            Y = 0
        End Sub

        Public Sub New(SpecialBox As Level.SpecialBox, Y As Int16)
            X1 = SpecialBox.X1
            X2 = SpecialBox.X2
            Z1 = SpecialBox.Z1
            Z2 = SpecialBox.Z2
            Me.Y = Y
        End Sub

        Public Sub New(WaterBox As BoxData)
            X1 = WaterBox.X1
            X2 = WaterBox.X2
            Z1 = WaterBox.Z1
            Z2 = WaterBox.Z2
            Y = WaterBox.Y
        End Sub
    End Class
    Public Enum BoxDataType As Int16
        Water = &H0
        ToxicHaze = &H32
        Mist = &H33
    End Enum

End Namespace