Imports System.IO
Imports System.Numerics
Imports S3DFileParser.ObjModule

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
            Next
        Next
    End Sub

    Public Sub OffsetModel(off As Vector3)
        For Each m As Mesh In Meshes
            For Each v As Vertex In m.Vertices
                v.X += off.X
                v.Y += off.Y
                v.Z += off.Z
            Next
        Next
    End Sub

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
