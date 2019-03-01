Namespace Global.SM64Lib.Model.Collision

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

End Namespace