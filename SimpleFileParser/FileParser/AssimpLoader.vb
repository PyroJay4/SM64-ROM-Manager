Imports System.IO
Imports Assimp

Namespace AssimpLoader

    Public Class AssimpLoader

        Public Shared Function FromFile(fileName As String, LoadMaterials As Boolean, UpAxis As UpAxis) As Object3D
            Dim newObj As New Object3D

            Dim daeMdl As Scene = Nothing
            Dim ac As New AssimpContext
            Dim channelIndicies As New Dictionary(Of Material, Integer)

            daeMdl = ac.ImportFile(fileName, PostProcessPreset.TargetRealTimeMaximumQuality Or PostProcessSteps.Triangulate)

            For Each et As EmbeddedTexture In daeMdl.Textures
                If et.HasCompressedData Then
                    Dim newMat As New Material

                    Dim ms As New MemoryStream(et.CompressedData)
                    newMat.Image = Image.FromStream(ms)
                    ms.Close()

                    newObj.Materials.Add("tex_" & daeMdl.Textures.IndexOf(et), newMat)
                End If
            Next

            For Each mat As Assimp.Material In daeMdl.Materials
                Dim newMat As New Material
                Dim texSlot As TextureSlot? = Nothing
                Dim col4d As Color4D? = Nothing

                newMat.Opacity = mat.Opacity

                Select Case True
                    Case mat.HasTextureNormal
                        texSlot = mat.TextureNormal
                    Case mat.HasTextureDiffuse
                        texSlot = mat.TextureDiffuse
                    Case mat.HasTextureAmbient
                        texSlot = mat.TextureAmbient
                    Case mat.HasTextureSpecular
                        texSlot = mat.TextureSpecular
                End Select

                Select Case True
                    Case mat.HasColorDiffuse
                        col4d = mat.ColorDiffuse
                    Case mat.HasColorAmbient
                        col4d = mat.ColorAmbient
                    Case mat.HasColorSpecular
                        col4d = mat.ColorSpecular
                End Select

                If texSlot IsNot Nothing Then
                    Dim filePath As String = texSlot.Value.FilePath

                    If LoadMaterials Then
                        If filePath <> "" Then
                            Dim combiPath As String = Path.Combine(Path.GetDirectoryName(fileName), filePath)
                            If File.Exists(combiPath) Then
                                newMat.Image = LoadImage(combiPath)
                            ElseIf File.Exists(filePath) Then
                                newMat.Image = LoadImage(filePath)
                            End If
                        ElseIf texSlot.Value.TextureIndex > -1 AndAlso daeMdl.Textures.Count > texSlot.Value.TextureIndex Then
                            Dim et As EmbeddedTexture = daeMdl.Textures(texSlot.Value.TextureIndex)
                            If et.HasCompressedData Then
                                Dim ms As New MemoryStream(et.CompressedData)
                                newMat.Image = Image.FromStream(ms)
                                ms.Close()
                            End If
                        End If
                    End If

                    channelIndicies.Add(newMat, texSlot.Value.UVIndex)
                End If

                If col4d IsNot Nothing Then
                    newMat.Color = Color.FromArgb(col4d.Value.R * 255, col4d.Value.G * 255, col4d.Value.B * 255)
                End If

                newObj.Materials.Add(mat.Name, newMat)
            Next

            Dim newMesh As New Mesh
            newObj.Meshes.Add(newMesh)

            Dim dicVertices As New Dictionary(Of Vector3D, Vertex)
            Dim dicNormals As New Dictionary(Of Vector3D, Normal)
            Dim dicUVs As New Dictionary(Of Vector3D, UV)
            Dim dicVertexColors As New Dictionary(Of Color4D, VertexColor)

            For Each m As Assimp.Mesh In daeMdl.Meshes
                Dim curMat As Material
                If m.MaterialIndex > -1 AndAlso newObj.Materials.Count > m.MaterialIndex Then
                    curMat = newObj.Materials.ElementAt(m.MaterialIndex).Value
                Else
                    curMat = Nothing
                End If

                For Each n As Vector3D In m.Normals
                    If Not dicNormals.ContainsKey(n) Then
                        Dim newNormal As New Normal

                        Select Case UpAxis
                            Case UpAxis.Y
                                newNormal.X = n.X
                                newNormal.Y = n.Y
                                newNormal.Z = n.Z
                            Case UpAxis.Z
                                newNormal.X = n.Y
                                newNormal.Y = n.Z
                                newNormal.Z = n.X
                        End Select

                        newMesh.Normals.Add(newNormal)
                        dicNormals.Add(n, newNormal)
                    End If
                Next

                For Each v As Vector3D In m.Vertices
                    If Not dicVertices.ContainsKey(v) Then
                        Dim newVert As New Vertex

                        Select Case UpAxis
                            Case UpAxis.Y
                                newVert.X = v.X
                                newVert.Y = v.Y
                                newVert.Z = v.Z
                            Case UpAxis.Z
                                newVert.X = v.Y
                                newVert.Y = v.Z
                                newVert.Z = v.X
                        End Select

                        newMesh.Vertices.Add(newVert)
                        dicVertices.Add(v, newVert)
                    End If
                Next

                For Each uvList As List(Of Vector3D) In m.TextureCoordinateChannels
                    For Each uv As Vector3D In uvList
                        If Not dicUVs.ContainsKey(uv) Then
                            Dim newUV As New UV

                            newUV.U = uv.X
                            newUV.V = uv.Y

                            newMesh.UVs.Add(newUV)
                            dicUVs.Add(uv, newUV)
                        End If
                    Next
                Next

                For Each vcList As List(Of Color4D) In m.VertexColorChannels
                    For Each vc As Color4D In vcList
                        If Not dicVertexColors.ContainsKey(vc) Then
                            Dim newVC As New VertexColor

                            newVC.R = vc.R
                            newVC.G = vc.G
                            newVC.B = vc.B
                            newVC.A = vc.A

                            newMesh.VertexColors.Add(newVC)
                            dicVertexColors.Add(vc, newVC)
                        End If
                    Next
                Next

                For Each f As Assimp.Face In m.Faces
                    If f.HasIndices Then
                        Dim newFace As New Face With {.Material = curMat}

                        For Each index As Integer In f.Indices
                            If index > -1 Then
                                Dim newPoint As New Point

                                If m.HasVertices Then
                                    newPoint.Vertex = dicVertices(m.Vertices(index))
                                End If

                                If m.HasNormals Then
                                    newPoint.Normal = dicNormals(m.Normals(index))
                                End If

                                If curMat IsNot Nothing AndAlso channelIndicies.ContainsKey(curMat) Then
                                    Dim tkey As Integer = channelIndicies(curMat)

                                    If m.HasTextureCoords(tkey) Then
                                        newPoint.UV = dicUVs(m.TextureCoordinateChannels(tkey)(index))
                                    End If

                                    If m.HasVertexColors(tkey) Then
                                        newPoint.VertexColor = dicVertexColors(m.VertexColorChannels(tkey)(index))
                                    End If
                                End If

                                newFace.Points.Add(newPoint)
                            End If
                        Next

                        If newFace.Points.Count = 3 Then
                            newMesh.Faces.Add(newFace)
                        End If
                    End If
                Next
            Next

            Return newObj
        End Function

        Public Shared Sub ToFile(fileName As String, obj As Object3D)
            Dim mdl As New Scene
            Dim dicMatIndex As New Dictionary(Of Material, Integer)

            Dim texDir As String = ""
            If obj.Materials.Count > 0 Then
                texDir = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName))
                If Not Directory.Exists(texDir) Then
                    Directory.CreateDirectory(texDir)
                End If
            End If

            For Each kvp As KeyValuePair(Of String, Material) In obj.Materials
                Dim mat As New Assimp.Material

                mat.Name = If(kvp.Key <> "", kvp.Key, "_" & mdl.Materials.Count)
                mat.Opacity = mat.Opacity

                Dim texslot As New TextureSlot
                texslot.TextureIndex = mdl.Textures.Count
                texslot.TextureType = TextureType.Diffuse
                texslot.UVIndex = 0

                Dim ms As New MemoryStream
                kvp.Value.Image.Save(ms, Imaging.ImageFormat.Png)
                'Dim tex As New EmbeddedTexture("png", ms.GetBuffer)
                ms.Close()

                If kvp.Value.Image IsNot Nothing Then
                    texslot.FilePath = Path.Combine(texDir, mat.Name & ".png")
                    File.WriteAllBytes(texslot.FilePath, ms.GetBuffer)
                End If

                'mdl.Textures.Add(tex)
                mat.AddMaterialTexture(texslot)
                mdl.Materials.Add(mat)

                If kvp.Value.Color IsNot Nothing Then
                    With kvp.Value.Color.Value
                        mat.ColorDiffuse = New Color4D(.R / 255, .G / 255, .B / 255, 1)
                    End With
                End If

                dicMatIndex.Add(kvp.Value, mdl.Materials.Count - 1)
            Next

            Dim dicTexMesh As New Dictionary(Of Material, Assimp.Mesh)
            Dim dicMeshDicVertIndex As New Dictionary(Of Assimp.Mesh, Dictionary(Of Vertex, Integer))
            Dim dicCounter As New Dictionary(Of Assimp.Mesh, Integer)

            For Each mesh As Mesh In obj.Meshes
                For Each f As Face In mesh.Faces
                    Dim m As Assimp.Mesh

                    If dicTexMesh.ContainsKey(f.Material) Then
                        m = dicTexMesh(f.Material)
                    Else
                        m = New Assimp.Mesh("Mesh_" & mdl.MeshCount + 1)
                        m.PrimitiveType = PrimitiveType.Triangle
                        If dicMatIndex.ContainsKey(f.Material) Then
                            m.MaterialIndex = dicMatIndex(f.Material)
                        End If
                        mdl.Meshes.Add(m)
                        dicTexMesh.Add(f.Material, m)
                        dicMeshDicVertIndex.Add(m, New Dictionary(Of Vertex, Integer))
                        dicCounter.Add(m, 0)
                    End If

                    Dim newFace As New Assimp.Face

                    For Each p As Point In f.Points
                        newFace.Indices.Add(dicCounter(m))

                        If p.Vertex IsNot Nothing Then
                            Dim vert As New Vector3D
                            vert.X = p.Vertex.X
                            vert.Y = p.Vertex.Y
                            vert.Z = p.Vertex.Z
                            m.Vertices.Add(vert)
                        Else
                            m.Vertices.Add(New Vector3D(0, 0, 0))
                        End If

                        If p.Normal IsNot Nothing Then
                            Dim norm As New Vector3D
                            norm.X = p.Normal.X
                            norm.Y = p.Normal.Y
                            norm.Z = p.Normal.Z
                            m.Normals.Add(norm)
                        Else
                            m.Normals.Add(New Vector3D(0, 0, 0))
                        End If

                        'If p.UV IsNot Nothing Then
                        '    Dim uv As New Vector3D
                        '    uv.X = p.UV.U
                        '    uv.Y = p.UV.V
                        '    m.TextureCoordinateChannels(0).Add(uv)
                        'Else
                        '    m.TextureCoordinateChannels(0).Add(New Vector3D(0, 0, 0))
                        'End If

                        'If p.VertexColor IsNot Nothing Then
                        '    Dim vc As New Color4D
                        '    vc.R = p.VertexColor.R
                        '    vc.G = p.VertexColor.G
                        '    vc.B = p.VertexColor.B
                        '    vc.A = p.VertexColor.A
                        '    m.VertexColorChannels(0).Add(vc)
                        'Else
                        '    m.VertexColorChannels(0).Add(New Color4D(0, 0, 0, 0))
                        'End If

                        dicCounter(m) += 1
                    Next

                    m.Faces.Add(newFace)
                Next
            Next

            'Add Root Node
            mdl.RootNode = New Node(Path.GetFileName(fileName))

            'Add Mesh Indicies
            For i As Integer = 0 To mdl.MeshCount - 1
                mdl.RootNode.MeshIndices.Add(i)
            Next

            Dim ac As New AssimpContext

            Dim formatID As String = ""
            Dim myExt As String = Path.GetExtension(fileName).ToLower.Substring(1)
            For Each efd As ExportFormatDescription In ac.GetSupportedExportFormats
                If myExt = efd.FileExtension Then
                    formatID = efd.FormatId
                    Exit For
                End If
            Next

            ac.ExportFile(mdl, fileName, formatID)
        End Sub

        Private Shared Function LoadImage(fileName As String) As Image
            If File.Exists(fileName) Then
                Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
                Dim img = Image.FromStream(fs)
                fs.Close()
                Return img
            End If
            Return Nothing
        End Function

    End Class

End Namespace
