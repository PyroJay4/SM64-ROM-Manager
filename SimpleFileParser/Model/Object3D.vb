Imports System.IO
Imports System.Numerics
Imports S3DFileParser.Obj

Public Class Object3D

    Public ReadOnly Property Meshes As New List(Of Mesh)
    Public ReadOnly Property Materials As New Dictionary(Of String, Material)
    Public Property Shading As New Shading

    Public Sub ScaleModel(factor As Single)
        For Each m As Mesh In Meshes
            For Each v As Vertex In m.Vertices
                v.X *= factor
                v.Y *= factor
                v.Z *= factor
                Application.DoEvents()
            Next
        Next
    End Sub

    Public Sub OffsetModel(off As Vector3)
        For Each m As Mesh In Meshes
            For Each v As Vertex In m.Vertices
                v.X += off.X
                v.Y += off.Y
                v.Z += off.Z
                Application.DoEvents()
            Next
        Next
    End Sub

    Shared Function FromFile(fileName As String, LoadMaterials As Boolean, UpAxis As UpAxis, modul As LoaderModule) As Object3D
        Select Case modul
            Case LoaderModule.SimpleFileParser

                Select Case Path.GetExtension(fileName).ToLower
                    Case ".obj"
                        Return Obj.ObjFile.FromFile(fileName, LoadMaterials, UpAxis)
                    Case Else
                        Throw New FormatException
                End Select

            Case LoaderModule.Assimp

                Publics.LoadAssimpLibs()
                Return AssimpLoader.AssimpLoader.FromFile(fileName, LoadMaterials, UpAxis)

            Case LoaderModule.Aspose

                Return Aspose3DLoader.FromFile(fileName, LoadMaterials, UpAxis)

            Case Else
                Return Nothing

        End Select
    End Function

    Shared Function FromFileAsync(fileName As String, LoadMaterials As Boolean, UpAxis As UpAxis, modul As LoaderModule) As Task(Of Object3D)
        Dim t As New Task(Of Object3D)(Function() FromFile(fileName, LoadMaterials, UpAxis, modul))
        t.Start()
        Return t
    End Function

    Public Sub ToFile(fileName As String, modul As LoaderModule)
        Select Case modul
            Case LoaderModule.SimpleFileParser

                ObjFile.ToFile(fileName, Me)

            Case LoaderModule.Assimp

                Publics.LoadAssimpLibs()
                AssimpLoader.AssimpLoader.ToFile(fileName, Me)

            Case LoaderModule.Aspose

                Throw New NotImplementedException
                '...

        End Select
    End Sub

    Public Function ToFileAsync(fileName As String, modul As LoaderModule) As Task
        Dim t As New Task(Sub() ToFile(fileName, modul))
        t.Start()
        Return t
    End Function

    Public Function GetBoundaries() As ModelBoundaries
        Dim maxX As Single? = Nothing
        Dim maxY As Single? = Nothing
        Dim maxZ As Single? = Nothing
        Dim minX As Single? = Nothing
        Dim minY As Single? = Nothing
        Dim minZ As Single? = Nothing

        For Each m As Mesh In Meshes
            For Each vert As Vertex In m.Vertices
                If maxX Is Nothing OrElse vert.X > maxX Then maxX = vert.X
                If maxY Is Nothing OrElse vert.Y > maxY Then maxY = vert.Y
                If maxZ Is Nothing OrElse vert.Z > maxZ Then maxZ = vert.Z
                If minX Is Nothing OrElse vert.X < minX Then minX = vert.X
                If minY Is Nothing OrElse vert.Y < minY Then minY = vert.Y
                If minZ Is Nothing OrElse vert.Z < minZ Then minZ = vert.Z
            Next
        Next

        If maxX Is Nothing Then maxX = 0
        If maxY Is Nothing Then maxY = 0
        If maxZ Is Nothing Then maxZ = 0
        If minX Is Nothing Then minX = 0
        If minY Is Nothing Then minY = 0
        If minZ Is Nothing Then minZ = 0

        Return New ModelBoundaries(New Vector3(maxX, maxY, maxZ),
                                   New Vector3(minX, minY, minZ))
    End Function

    Public Sub SetNullVertices()
        Dim newVert As New Vertex With {.X = 0, .Y = 0, .Z = 0}
        Dim nullCounter As Integer

        For Each m As Mesh In Meshes
            nullCounter = 0

            For Each f As Face In m.Faces
                For Each p As Point In f.Points
                    If p.Vertex Is Nothing Then
                        p.Vertex = newVert
                        nullCounter += 1
                    End If
                Next
            Next

            If nullCounter > 0 Then
                m.Vertices.Add(newVert)
            End If
        Next
    End Sub

    Public Sub SetNullUVs()
        Dim newUV As New UV With {.U = 0, .V = 0}
        Dim nullCounter As Integer

        For Each m As Mesh In Meshes
            nullCounter = 0

            For Each f As Face In m.Faces
                For Each p As Point In f.Points
                    If p.UV Is Nothing Then
                        p.UV = newUV
                        nullCounter += 1
                    End If
                Next
            Next

            If nullCounter > 0 Then
                m.UVs.Add(newUV)
            End If
        Next
    End Sub

    Public Sub SetNullNormals()
        Dim newNormal As New Normal With {.X = 0, .Y = 0, .Z = 1}
        Dim nullCounter As Integer

        For Each m As Mesh In Meshes
            nullCounter = 0

            For Each f As Face In m.Faces
                For Each p As Point In f.Points
                    If p.Normal Is Nothing Then
                        p.Normal = newNormal
                        nullCounter += 1
                    End If
                Next
            Next

            If nullCounter > 0 Then
                m.Normals.Add(newNormal)
            End If
        Next
    End Sub

    Public Sub RemoveUnusedMaterials()
        'Dim usedMats As New List(Of Material)
        'Dim unusedMats As New List(Of String)

        'For Each f As Face In Faces
        '    If Not usedMats.Contains(f.Material) Then
        '        usedMats.Add(f.Material)
        '    End If
        'Next

        'For Each kvp As KeyValuePair(Of String, Material) In Materials
        '    If Not usedMats.Contains(kvp.Value) Then
        '        unusedMats.Add(kvp.Key)
        '    End If
        'Next

        'For Each k As String In unusedMats
        '    Materials.Remove(k)
        'Next
    End Sub

    Public Function ToOneMesh() As Object3D
        Dim newObject3D As New Object3D
        Dim newMesh As New Mesh

        For Each mat As KeyValuePair(Of String, Material) In Materials
            newObject3D.Materials.Add(mat.Key, mat.Value)
        Next

        For Each m As Mesh In Meshes
            For Each v As Vertex In m.Vertices
                newMesh.Vertices.Add(v)
            Next

            For Each vc As VertexColor In m.VertexColors
                newMesh.VertexColors.Add(vc)
            Next

            For Each n As Normal In m.Normals
                newMesh.Normals.Add(n)
            Next

            For Each uv As UV In m.UVs
                newMesh.UVs.Add(uv)
            Next

            For Each f As Face In m.Faces
                newMesh.Faces.Add(f)
            Next
        Next

        newObject3D.Meshes.Add(newMesh)
        Return newObject3D
    End Function

    Public Sub CenterModel()
        Dim avg As Vector3 = Vector3.Zero
        Dim vertsCount As ULong = 0

        For Each m As Mesh In Meshes
            avg += m.GetCenterModelAvg
            vertsCount += m.Vertices.Count
        Next

        avg /= vertsCount

        CenterModel(avg)
    End Sub
    Public Sub CenterModel(avg As Vector3)
        For Each m As Mesh In Meshes
            m.CenterModel(avg)
        Next
    End Sub

End Class

Public Class Shading
    Public Property Light As Color = Color.FromArgb(&HFFFFFFFF)
    Public Property Dark As Color = Color.FromArgb(&HFF7F7F7F)
End Class

Public Class Mesh

    Public ReadOnly Property Vertices As New List(Of Vertex)
    Public ReadOnly Property Normals As New List(Of Normal)
    Public ReadOnly Property UVs As New List(Of UV)
    Public ReadOnly Property VertexColors As New List(Of VertexColor)
    Public ReadOnly Property Faces As New List(Of Face)

    Friend Function GetCenterModelAvg() As Vector3
        Dim avgX As Integer = 0
        Dim avgY As Integer = 0
        Dim avgZ As Integer = 0

        For Each v As Vertex In Vertices
            avgX += v.X
            avgY += v.Y
            avgZ += v.Z
        Next

        Return New Vector3(avgX, avgY, avgZ)
    End Function

    Public Sub CenterModel()
        Dim avg As Vector3 = GetCenterModelAvg()

        avg /= New Vector3(Vertices.Count)

        CenterModel(avg)
    End Sub

    Public Sub CenterModel(avg As Vector3)
        For Each v As Vertex In Vertices
            v.X -= avg.X
            v.Y -= avg.Y
            v.Z -= avg.Z
        Next
    End Sub

End Class

Public Class Vertex
    Public Property X As Double = 0
    Public Property Y As Double = 0
    Public Property Z As Double = 0
End Class

Public Class Face
    Public ReadOnly Property Points As New List(Of Point)
    Public Property Material As Material = Nothing
    Public Property Tag As Object = Nothing
End Class

Public Class Point
    Public Property Vertex As Vertex = Nothing
    Public Property UV As UV = Nothing
    Public Property VertexColor As VertexColor = Nothing
    Public Property Normal As Normal = Nothing
End Class

Public Class UV
    Public Property U As Single = 0
    Public Property V As Single = 0
End Class

Public Class Normal
    Public Property X As Single = 0
    Public Property Y As Single = 0
    Public Property Z As Single = 0
End Class

Public Class Material
    Implements IComparable

    Public Property Image As Image = Nothing
    Public Property Color As Color? = Nothing
    Public Property Opacity As Single? = Nothing
    Public Property Wrap As New Vector2(10497, 10497)
    Public Property Scale As New Vector2(1.0F, 1.0F)

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj IsNot Nothing Then
            If obj Is Me Then
                Return 0
            Else
                Return -1
            End If
        Else
            Return 1
        End If
    End Function
End Class

Public Class VertexColor
    Public Property R As Single = 1
    Public Property G As Single = 1
    Public Property B As Single = 1
    Public Property A As Single = 1
End Class

Public Class ModelBoundaries
    Public ReadOnly Upper As Vector3
    Public ReadOnly Lower As Vector3

    Public Sub New(upper As Vector3, lower As Vector3)
        Me.Upper = upper
        Me.Lower = lower
    End Sub
End Class

Public Enum UpAxis
    Y
    Z
End Enum

Public Enum LoaderModule
    SimpleFileParser
    Assimp
    Aspose
End Enum
