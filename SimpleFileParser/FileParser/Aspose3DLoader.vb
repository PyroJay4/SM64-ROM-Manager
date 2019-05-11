Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports Aspose.ThreeD
Imports Aspose.ThreeD.Entities
Imports Aspose.ThreeD.Formats
Imports Aspose.ThreeD.Shading
Imports Aspose.ThreeD.Utilities

Namespace Aspose3DModule

    Public Class Aspose3DLoader

        Private Shared hasActivatedMemoryPatching As Boolean = False

        Private Shared Sub ActivateMemoryPatching()
            If Not hasActivatedMemoryPatching Then
                LicenseHelper.ModifyInMemory.ActivateMemoryPatching()
                hasActivatedMemoryPatching = True
            End If
        End Sub

        Public Shared Function FromFile(fileName As String, LoadMaterials As Boolean, UpAxis As UpAxis) As Object3D
            ActivateMemoryPatching()

            'Create new Model
            Dim obj3d As New Object3D

            'Create new temporary CultureInfo
            Dim curThread As Thread = Thread.CurrentThread
            Dim curCultInfo As CultureInfo = curThread.CurrentCulture
            Dim newCultInfo As New CultureInfo(curCultInfo.Name)
            newCultInfo.NumberFormat.NumberDecimalSeparator = "."
            newCultInfo.NumberFormat.PercentDecimalSeparator = "."
            newCultInfo.NumberFormat.CurrencyDecimalSeparator = "."
            newCultInfo.NumberFormat.NumberGroupSeparator = ","
            newCultInfo.NumberFormat.PercentGroupSeparator = ","
            newCultInfo.NumberFormat.CurrencyGroupSeparator = ","
            curThread.CurrentCulture = newCultInfo

            'Load Model from file
            Dim scene As New Scene(fileName)

            'Reset Cultur-Info
            curThread.CurrentCulture = curCultInfo

            'Triangulate the Model
            PolygonModifier.Triangulate(scene)

            'Create Dictionary for Materials
            Dim dicMaterials As New Dictionary(Of Aspose.ThreeD.Shading.Material, Material)

            'Create List of all avaiable Map-States
            Dim MapNames As String() = {Aspose.ThreeD.Shading.Material.MapDiffuse, Aspose.ThreeD.Shading.Material.MapAmbient, Aspose.ThreeD.Shading.Material.MapSpecular, Aspose.ThreeD.Shading.Material.MapEmissive, Aspose.ThreeD.Shading.Material.MapNormal}
            Dim ColorNames As String() = {"DiffuseColor", "AmbientColor", "SpecularColor", "EmissiveColor"}

            For Each node As Node In scene.RootNode.ChildNodes

                'Add new Materials, if not added
                For Each mat As Aspose.ThreeD.Shading.Material In node.Materials
                    If Not dicMaterials.ContainsKey(mat) Then

                        'Create new Material
                        Dim newMat As New Material

                        'Get TextureBase
                        Dim texBase As TextureBase = Nothing
                        Dim curmnindex As Byte = 0
                        Do While texBase Is Nothing AndAlso curmnindex < MapNames.Length
                            texBase = mat.GetTexture(MapNames(curmnindex))
                            curmnindex += 1
                        Loop

                        If texBase IsNot Nothing Then
                            If LoadMaterials Then
                                'Get Texture Image
                                Dim imgFile As String = texBase.GetPropertyValue("FileName")
                                imgFile = imgFile.Replace("/", "\")

                                'Load and set Image
                                If imgFile <> "" Then
                                    Dim fs As New FileStream(imgFile, FileMode.Open, FileAccess.Read)
                                    newMat.Image = Image.FromStream(fs)
                                    fs.Close()
                                End If
                            End If
                        End If

                        'Get Texture Color
                        Dim texcol As Vector3? = Nothing
                        Dim curcnindex As Byte = 0
                        Do While texcol Is Nothing AndAlso curcnindex < ColorNames.Length
                            texcol = mat.GetPropertyValue(ColorNames(curcnindex))
                            curcnindex += 1
                        Loop

                        If texcol IsNot Nothing Then
                            newMat.Color = Color.FromArgb(texcol?.x, texcol?.y, texcol?.z)
                        End If

                        'Add Material to Object3D
                        obj3d.Materials.Add(mat.Name, newMat)

                        'Add Dictionary-Entry
                        dicMaterials.Add(mat, newMat)

                    End If
                Next

                'Get Aspose-Mesh
                Dim curMesh As Entities.Mesh = node.GetEntity(Of Entities.Mesh)

                If curMesh IsNot Nothing Then

                    'Create new Mesh
                    Dim newMesh As New Mesh

                    'Create Vertices
                    For Each vert As Vector4 In curMesh.ControlPoints
                        'Create new Vertex
                        Dim newVert As New Vertex

                        'Set Vertex Data
                        newVert.X = vert.x
                        newVert.Y = vert.y
                        newVert.Z = vert.z

                        'Add new Vertex
                        newMesh.Vertices.Add(newVert)
                    Next

                    'Create Normals
                    Dim veNormals As VertexElementNormal = curMesh.GetElement(VertexElementType.Normal)
                    If veNormals IsNot Nothing Then
                        For Each n As Vector4 In veNormals.Data
                            'Create new Normal
                            Dim newNormal As New Normal

                            'Set Normal Data
                            newNormal.X = n.x
                            newNormal.Y = n.y
                            newNormal.Z = n.z

                            'Add new Normal
                            newMesh.Normals.Add(newNormal)
                        Next
                    End If

                    'Create Normals
                    Dim veUVs As VertexElementUV = curMesh.GetElement(VertexElementType.UV)
                    If veUVs IsNot Nothing Then
                        For Each uv As Vector4 In veUVs.Data
                            'Create new UV
                            Dim newUV As New UV

                            'Set UV Data
                            newUV.U = uv.x
                            newUV.V = uv.y

                            'Add new UV
                            newMesh.UVs.Add(newUV)
                        Next
                    End If

                    'Create Normals
                    Dim veVertexColor As VertexElementVertexColor = curMesh.GetElement(VertexElementType.VertexColor)
                    If veVertexColor IsNot Nothing Then
                        For Each n As Vector4 In veVertexColor.Data
                            'Create new Normal
                            Dim newVC As New VertexColor

                            'Set Normal Data
                            newVC.R = n.x
                            newVC.G = n.y
                            newVC.B = n.z
                            newVC.A = n.w

                            'Add new Normal
                            newMesh.VertexColors.Add(newVC)
                        Next
                    End If

                    'Get Material-Indicies
                    Dim veMaterials As VertexElementMaterial = curMesh.GetElement(VertexElementType.Material)

                    'Definde Index for VertexElement.Indicies
                    Dim veIndex As Integer = 0

                    'Build Polygones
                    For iPoly = 0 To curMesh.Polygons.Count - 1
                        'Get current Polygon
                        Dim poly As Integer() = curMesh.Polygons(iPoly)

                        'Create new Face
                        Dim f As New Face

                        'Set Texture, if avaiable
                        If veMaterials IsNot Nothing Then
                            f.Material = dicMaterials(node.Materials(veMaterials.Indices(iPoly)))
                        ElseIf node.Material IsNot Nothing Then
                            f.Material = dicMaterials(node.Material)
                        End If

                        For Each index As Integer In poly
                            'Create new Point
                            Dim p As New Point

                            'Set Vertex
                            p.Vertex = newMesh.Vertices(index)

                            'Set Normal
                            If veNormals IsNot Nothing Then
                                p.Normal = newMesh.Normals(veNormals.Indices(veIndex))
                            End If

                            'Set UV
                            If veUVs IsNot Nothing Then
                                p.UV = newMesh.UVs(veUVs.Indices(veIndex))
                            End If

                            'Set Vertex Color
                            If veVertexColor IsNot Nothing Then
                                p.VertexColor = newMesh.VertexColors(veVertexColor.Indices(veIndex))
                            End If

                            'Add new Point
                            f.Points.Add(p)

                            'Increment VertexElementIndicies-Index
                            veIndex += 1
                        Next

                        'Add new Face
                        newMesh.Faces.Add(f)
                    Next

                    'Add new Mesh
                    obj3d.Meshes.Add(newMesh)

                End If

            Next

            'Return the new Object3D
            Return obj3d
        End Function

    End Class

End Namespace
