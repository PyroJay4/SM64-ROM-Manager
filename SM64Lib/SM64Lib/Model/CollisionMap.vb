Imports System.IO
Imports S3DFileParser
Imports System.Numerics
Imports System.Windows.Forms
Imports Extensions
Imports SM64Lib.Data

Namespace Global.SM64Lib.Model.Collision

    Public Class CollisionMap
        Implements IToObject3D

        Public Property Mesh As New ColMesh
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
            FromBinaryData(New BinaryStreamData(s), RomOffset)
        End Sub
        Public Sub FromBinaryData(s As BinaryData, dataOffset As Integer)
            Mesh = New ColMesh
            SpecialBoxes.Clear()

            s.Position = dataOffset

            Do
                Dim curVal As Int16 = s.ReadInt16
                Select Case curVal
                    Case &H40 'S T A R T   O F   V E R T I C E S
                        'Lese Eckpunkte / Read Vertices
                        For i As Integer = 1 To s.ReadUInt16
                            Dim nVert As New Vertex With {
                            .X = s.ReadInt16,
                            .Y = s.ReadInt16,
                            .Z = s.ReadInt16}
                            Mesh.Vertices.Add(nVert)
                        Next

                        'Lese und erstelle Polygone / Read and build polygones
                        If Mesh.Vertices.Count > 0 Then
                            Dim ende As Boolean = False
                            Do Until ende
                                Dim Coltype As Int16 = s.ReadInt16
                                If Not Coltype.IsInRange(&H40, &H44) Then
                                    For i As Integer = 1 To s.ReadUInt16
                                        Dim pol As New Triangle With {.CollisionType = Coltype}

                                        For iv As Integer = 0 To pol.Vertices.Count - 1
                                            pol.Vertices(iv) = Mesh.Vertices(s.ReadInt16)
                                        Next

                                        If ColtypesWithParams.Contains(Coltype) Then
                                            For ip As Integer = 0 To pol.ColParams.Count - 1
                                                pol.ColParams(ip) = s.ReadByte
                                            Next
                                        End If

                                        Mesh.Triangles.Add(pol)
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
                        SpecialBoxes.AddRange(ReadBoxData(s, BoxDataType.Water))

                    Case &H33 'M I S T
                        SpecialBoxes.AddRange(ReadBoxData(s, BoxDataType.Mist))

                    Case &H32 'T O X I C   H A Z E
                        SpecialBoxes.AddRange(ReadBoxData(s, BoxDataType.ToxicHaze))

                End Select
            Loop

            _Length = s.Position - dataOffset
        End Sub
        Public Function FromStreamAsync(s As Stream, RomOffset As Integer) As Task
            Dim t As New Task(Sub() FromStream(s, RomOffset))
            t.Start()
            Return t
        End Function

        Private Shared Function ReadBoxData(s As BinaryData, type As BoxDataType) As BoxData()
            Dim spBoxes As New List(Of BoxData)
            For i As Integer = 1 To s.ReadInt16
                Dim wb As New BoxData
                Dim index As Int16 = s.ReadInt16
                wb.Type = type
                wb.X1 = s.ReadInt16
                wb.Z1 = s.ReadInt16
                wb.X2 = s.ReadInt16
                wb.Z2 = s.ReadInt16
                wb.Y = s.ReadInt16
                spBoxes.Add(wb)
            Next
            Return spBoxes.ToArray
        End Function

        Public Sub FromObject3D(ObjSettings As ObjInputSettings, model As Object3D, Optional colSettings As CollisionSettings = Nothing)
            Dim dicMatNames As New Dictionary(Of Material, String)

            'Clear Lists
            Mesh.Vertices.Clear()
            Mesh.Triangles.Clear()

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
                                Mesh.Vertices.Add(v)
                                dicVertices.Add(curVert, v)
                            End If

                            t.Vertices(i) = v
                        Next

                        Mesh.Triangles.Add(t)
                    End If
                Next
            Next
        End Sub
        Public Function FromObject3DAsync(ObjSettings As ObjInputSettings, model As Object3D, Optional colSettings As CollisionSettings = Nothing) As Task
            Dim t As New Task(Sub() FromObject3D(ObjSettings, model, colSettings))
            t.Start()
            Return t
        End Function

        Public Sub ToStream(s As Stream, RomOffset As Integer)
            ToBinaryData(New BinaryStreamData(s), RomOffset)
        End Sub

        Public Sub ToBinaryData(data As BinaryData, dataOffset As Integer)

            data.Position = dataOffset

            For Each mesh As ColMesh In Me.Mesh.SplitMesh

                'V E R T I C E S

                If mesh.Vertices.Count > 0 Then
                    'Start vertices
                    data.Write(&H40S)
                    data.Write(CShort(mesh.Vertices.Count))

                    'Write vertices data
                    For Each vert In mesh.Vertices
                        data.Write(vert.X)
                        data.Write(vert.Y)
                        data.Write(vert.Z)
                    Next
                End If

                'P O L Y G O N E S

                For Each curType As Byte In UsedPolytypes(mesh)
                    'Search for all triangles with current collision type
                    Dim tries As Triangle() = mesh.Triangles.Where(Function(n) n.CollisionType = curType).ToArray

                    If tries.Length > 0 Then
                        'Write new collision type
                        data.Write(CShort(curType))

                        'Write count of triangles
                        data.Write(CShort(tries.Length))

                        'Check if collisiontype has params
                        Dim hasParams As Boolean = ColtypesWithParams.Contains(curType)

                        For Each tri As Triangle In tries
                            'Write Vertex Indicies
                            For Each vert As Vertex In tri.Vertices
                                data.Write(CShort(vert.Index))
                            Next

                            'Write Collision Params, if avaiable
                            If hasParams Then
                                For ip As Integer = 0 To tri.ColParams.Count - 1
                                    data.Write(tri.ColParams(ip))
                                Next
                            End If
                        Next
                    End If
                Next

                'E N D   0 x 4 0   C O M M A N D

                data.Write(&H41S)

            Next

            'S P E C I A L   O B J E C T S

            'Dont know what this is.

            'S P E C I A L   B O X E S

            If SpecialBoxes.Count > 0 Then
                WriteBoxData(data, SpecialBoxes.OrderBy(Function(n) n.Type))
            End If

            'E N D   C O L L I S I O N   D A T A

            data.Write(&H42S)
        End Sub
        Private Shared Sub WriteBoxData(data As BinaryData, bodex As IEnumerable(Of BoxData))

            If bodex.Any Then
                data.Write(&H44S)
                data.Write(CShort(bodex.Count))

                For Each t As BoxDataType In [Enum].GetValues(GetType(BoxDataType))
                    For Each wb In bodex.Where(Function(n) n.Type = t)
                        data.Write(wb.Index)
                        data.Write(wb.X1)
                        data.Write(wb.Z1)
                        data.Write(wb.X2)
                        data.Write(wb.Z2)
                        data.Write(wb.Y)
                    Next
                Next
            End If
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

        Public Shared Function UsedPolytypes(mesh As ColMesh) As Byte()
            Dim types As New List(Of Byte)

            For Each tri As Triangle In mesh.Triangles
                If Not types.Contains(tri.CollisionType) Then
                    types.Add(tri.CollisionType)
                End If
            Next

            Return types.ToArray
        End Function

        Private Function DropToGroud_GetFoundList(pos As Vector3) As Single()
            Dim found As New List(Of Single)

            For Each tri As Triangle In Mesh.Triangles
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
            For Each vert In Mesh.Vertices
                m.Vertices.Add(New S3DFileParser.Vertex With {
                               .X = vert.X,
                               .Y = vert.Y,
                               .Z = vert.Z
                               })
            Next

            'Triangles
            For Each tri In Mesh.Triangles
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

    Public Class ColMesh

        Public Property Vertices As New VertexList
        Public Property Triangles As New TriangleList

        Public Function SplitMesh() As ColMesh()
            Return SplitMesh(Me)
        End Function

        Public Shared Function SplitMesh(mesh As ColMesh) As ColMesh()
            Dim meshes As New List(Of ColMesh)

            If mesh.Vertices.Count > Int16.MaxValue OrElse mesh.Triangles.Count > Int16.MaxValue Then
                Dim curMesh As New ColMesh
                Dim curVertCopies As New Dictionary(Of Vertex, Vertex)

                For Each t As Triangle In mesh.Triangles
                    Dim newTri As New Triangle

                    newTri.CollisionType = t.CollisionType
                    For i As Integer = 0 To t.ColParams.Length - 1
                        newTri.ColParams(i) = t.ColParams(i)
                    Next

                    For i As Integer = 0 To t.Vertices.Length - 1
                        Dim v As Vertex = t.Vertices(i)
                        If curVertCopies.ContainsKey(v) Then
                            newTri.Vertices(i) = curVertCopies(v)
                        Else
                            Dim newVert As New Vertex
                            newVert.X = v.X
                            newVert.Y = v.Y
                            newVert.Z = v.Z
                            curMesh.Vertices.Add(newVert)
                            curVertCopies.Add(v, newVert)
                            newTri.Vertices(i) = newVert
                        End If
                    Next

                    If curMesh.Vertices.Count > Int16.MaxValue - 3 OrElse curMesh.Triangles.Count >= Int16.MaxValue Then
                        meshes.Add(curMesh)
                        curMesh = New ColMesh
                        curVertCopies.Clear()
                    End If
                Next

                If Not meshes.Contains(curMesh) AndAlso curMesh.Triangles.Count > 0 AndAlso curMesh.Vertices.Count > 0 Then
                    meshes.Add(curMesh)
                End If
            Else
                meshes.Add(mesh)
            End If

            Return meshes.ToArray
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

        Public Overloads Sub AddRange(collection As IEnumerable(Of Vertex))
            For Each v As Vertex In collection
                v.ParentList = Me
            Next
            MyBase.AddRange(collection)
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

        Public Overloads Sub AddRange(collection As IEnumerable(Of Triangle))
            For Each v As Triangle In collection
                v.ParentList = Me
            Next
            MyBase.AddRange(collection)
        End Sub
    End Class

    Public Class BoxData

        Public Property Type As BoxDataType = BoxDataType.Water
        Public Property X1 As Int16
        Public Property X2 As Int16
        Public Property Z1 As Int16
        Public Property Z2 As Int16
        Public Property Y As Int16
        Public Property Index As Int16

        Public Sub New()
            X1 = 8192
            X2 = -8192
            Z1 = 8192
            Z2 = -8192
            Y = 0
            Index = 0
        End Sub

        Public Sub New(SpecialBox As Levels.SpecialBox, Y As Int16)
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
        Water = &H44
        ToxicHaze = &H32
        Mist = &H33
    End Enum

End Namespace