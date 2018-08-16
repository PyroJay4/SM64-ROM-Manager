Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports S3DFileParser.Exceptions

Namespace Obj

    Public Class ObjFile

        Public Shared Function FromFile(FileName As String, LoadMaterials As Boolean, UpAxis As UpAxis) As Object3D
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

            Dim newObj As New Object3D
            Dim newMesh As New Mesh
            Dim curObjPath As String = Path.GetDirectoryName(FileName)

            Dim mtllibs As New Dictionary(Of String, MaterialLib)

            Dim curMaterialLib As MaterialLib = Nothing
            Dim curMaterial As Material = Nothing

            Dim srObj As New StreamReader(FileName, Text.Encoding.ASCII)
            Dim line As String = ""

            Do Until srObj.EndOfStream
                line = srObj.ReadLine.Trim

                If line <> "" Then

                    Select Case True
                        Case line.StartsWith("mtllib ")
                            Dim name As String = line.Substring(7)

                            If Not mtllibs.ContainsKey(name) Then
                                Dim mtlfile As String = Path.Combine(curObjPath, name)
                                If Not File.Exists(mtlfile) Then Throw New MaterialException("Material Library not found!")

                                Dim newmtl As New MaterialLib
                                newmtl.FromFile(mtlfile, LoadMaterials)
                                mtllibs.Add(name, newmtl)
                                curMaterialLib = newmtl

                                For Each kvp As KeyValuePair(Of String, Material) In curMaterialLib.Materials
                                    If Not newObj.Materials.ContainsKey(kvp.Key) Then newObj.Materials.Add(kvp.Key, kvp.Value)
                                Next
                            Else
                                curMaterialLib = mtllibs(name)
                            End If

                        Case line.StartsWith("usemtl ")
                            curMaterial = curMaterialLib.Materials(line.Substring(7))

                        Case line.StartsWith("v ")
                            If line.Contains("nan") Then line = line.Replace("nan", "0")
                            Dim splitXYZ() As String = line.Substring(2).Split(" "c)

                            Dim tX As Double = Convert.ToDouble(splitXYZ(0))
                            Dim tY As Double = Convert.ToDouble(splitXYZ(1))
                            Dim tZ As Double = Convert.ToDouble(splitXYZ(2))

                            Dim v As New Vertex
                            Select Case UpAxis
                                Case UpAxis.Y
                                    v.X = tX
                                    v.Y = tY
                                    v.Z = tZ
                                Case UpAxis.Z
                                    v.X = tY
                                    v.Y = tZ
                                    v.Z = tX
                            End Select
                            newMesh.Vertices.Add(v)

                        Case line.StartsWith("vt ")
                            Dim uvstr() As String = line.Substring(3).Split(" "c)
                            Dim uv As New UV With {
                            .U = Convert.ToSingle(uvstr(0)),
                            .V = Convert.ToSingle(uvstr(1))}
                            newMesh.UVs.Add(uv)

                        Case line.StartsWith("vn ")
                            Dim splitXYZ() As String = line.Substring(3).Split(" "c)

                            Dim tX As Single = Convert.ToSingle(splitXYZ(0))
                            Dim tY As Single = Convert.ToSingle(splitXYZ(1))
                            Dim tZ As Single = Convert.ToSingle(splitXYZ(2))

                            Dim n As New Normal
                            Select Case UpAxis
                                Case UpAxis.Y
                                    n.X = tX
                                    n.Y = tY
                                    n.Z = tZ
                                Case UpAxis.Z
                                    n.X = tZ
                                    n.Y = tY
                                    n.Z = tX
                            End Select
                            newMesh.Normals.Add(n)

                        Case line.StartsWith("vc ")
                            Dim splitRGB() As String = line.Substring(3).Split(" "c)

                            Dim tX As Single = Convert.ToSingle(splitRGB(0))
                            Dim tY As Single = Convert.ToSingle(splitRGB(1))
                            Dim tZ As Single = Convert.ToSingle(splitRGB(2))

                            Dim vc As New VertexColor
                            Select Case UpAxis
                                Case UpAxis.Y
                                    vc.R = tX
                                    vc.G = tY
                                    vc.B = tZ
                                Case UpAxis.Z
                                    vc.R = tY
                                    vc.G = tZ
                                    vc.B = tX
                            End Select
                            newMesh.VertexColors.Add(vc)

                        Case line.StartsWith("f ")
                            Dim tri As New Face With {.Material = curMaterial}

                            For Each xyz As String In line.Substring(2).Split(" "c)
                                xyz = xyz.Trim
                                If xyz = "" Then Continue For

                                Dim splitsub() As String = Nothing
                                Dim p As New Point

                                Select Case True
                                    Case xyz.Contains("/")
                                        splitsub = xyz.Split("/"c)
                                    Case xyz.Contains("\")
                                        splitsub = xyz.Split("\"c)
                                    Case Else
                                        splitsub = {0, 0, 0}
                                End Select

                                Dim v1 As String = splitsub(0)
                                Dim v2 As String = splitsub(1)
                                Dim v3 As String = splitsub(2)

                                If v1 <> "" Then
                                    p.Vertex = newMesh.Vertices(Convert.ToInt32(v1) - 1)
                                End If

                                If v2 <> "" Then
                                    p.UV = newMesh.UVs(Convert.ToInt32(v2) - 1)
                                Else
                                    Dim newUV As New UV With {.U = 0, .V = 0}
                                    p.UV = newUV
                                    newMesh.UVs.Add(newUV)
                                End If

                                If v3 <> "" Then
                                    p.Normal = newMesh.Normals(Convert.ToInt32(v3) - 1)
                                End If

                                If splitsub.Count > 3 Then
                                    Dim v4 As String = splitsub(3)
                                    If v4 <> "" Then p.VertexColor = newMesh.VertexColors(Convert.ToInt32(v4) - 1)
                                End If

                                tri.Points.Add(p)
                            Next

                            newMesh.Faces.Add(tri)

                    End Select

                End If

            Loop
            newObj.Meshes.Add(newMesh)

            curThread.CurrentCulture = curCultInfo

            srObj.Close()
            Return newObj
        End Function

        Public Shared Sub ToFile(FileName As String, obj As Object3D)
            Dim fs As New FileStream(FileName, FileMode.Create, FileAccess.ReadWrite)
            Dim sw As New StreamWriter(fs, Text.Encoding.ASCII)

            If obj.Materials.Count > 0 Then
                Dim mtlName As String = Path.GetFileNameWithoutExtension(FileName) & ".mtl"
                Dim mtlFile As String = Path.Combine(Path.GetDirectoryName(FileName), mtlName)
                sw.WriteLine($"mtllib {mtlName}")
                MaterialLib.ToFile(mtlFile, obj)
            End If

            Dim curVertCount As Integer = 1
            Dim curUVCount As Integer = 1
            Dim curNormCount As Integer = 1
            Dim curVertColCount As Integer = 1

            For Each m As Mesh In obj.Meshes

                For Each vert As Vertex In m.Vertices
                    sw.WriteLine($"v {vert.X.ToString.Replace(",", ".")} {vert.Y.ToString.Replace(",", ".")} {vert.Z.ToString.Replace(",", ".")}")
                Next

                For Each uv As UV In m.UVs
                    sw.WriteLine($"vt {uv.U.ToString.Replace(",", ".")} {uv.V.ToString.Replace(",", ".")}")
                Next

                For Each norm As Normal In m.Normals
                    sw.WriteLine($"vn {norm.X.ToString.Replace(",", ".")} {norm.Y.ToString.Replace(",", ".")} {norm.Z.ToString.Replace(",", ".")}")
                Next

                For Each vertcol As VertexColor In m.VertexColors
                    sw.WriteLine($"vc {vertcol.R.ToString.Replace(",", ".")} {vertcol.G.ToString.Replace(",", ".")} {vertcol.B.ToString.Replace(",", ".")}")
                Next

                Dim curMtl As Material = Nothing

                For Each f As Face In m.Faces
                    If curMtl IsNot f.Material Then
                        curMtl = f.Material
                        sw.WriteLine($"usemtl _{GetIndexOfMaterialInList(obj, curMtl)}")
                    End If

                    sw.Write("f")

                    For Each p As Point In f.Points
                        sw.Write(" ")
                        sw.Write(curVertCount + m.Vertices.IndexOf(p.Vertex))

                        sw.Write("/")
                        If p.UV IsNot Nothing Then sw.Write(curUVCount + m.UVs.IndexOf(p.UV))

                        sw.Write("/")
                        If p.Normal IsNot Nothing Then sw.Write(curNormCount + m.Normals.IndexOf(p.Normal))

                        If m.VertexColors.Count > 0 Then
                            sw.Write("/")
                            If p.VertexColor IsNot Nothing Then sw.Write(curVertColCount + m.VertexColors.IndexOf(p.VertexColor))
                        End If
                    Next

                    sw.WriteLine()
                Next

                curVertCount += m.Vertices.Count
                curUVCount += m.UVs.Count
                curNormCount += m.Normals.Count
                curVertColCount += m.VertexColors.Count
            Next

            sw.Flush()
            fs.Close()
        End Sub

        Public Shared Function GetIndexOfMaterialInList(obj As Object3D, matToFind As Material) As Integer
            For Index As Integer = 0 To obj.Materials.Count - 1
                If obj.Materials.ElementAt(Index).Value.Equals(matToFind) Then
                    Return Index
                End If
            Next
            Return -1
        End Function

    End Class

    Public Class MaterialLib

        Public ReadOnly Property Materials As New Dictionary(Of String, Material)

        Public Sub FromFile(fileName As String, LoadMaterials As Boolean)
            Dim curMatLibPath As String = Path.GetDirectoryName(fileName)

            Dim curMat As Material = Nothing
            Dim curName As String = ""

            Dim srMtl As New StreamReader(fileName, Text.Encoding.ASCII)
            Dim line As String = ""

            Do Until srMtl.EndOfStream
                line = srMtl.ReadLine

                Select Case True
                    Case line.StartsWith("newmtl ")
                        curMat = New Material
                        curName = line.Substring(7)
                        Materials.Add(curName, curMat)

                    Case line.ToLower.StartsWith("kd ")
                        Dim splitColor() As String = line.Substring(3).Split(" "c)
                        Dim col As Color = Color.FromArgb(
                            Convert.ToSingle(Math.Round(255 * splitColor(0))),
                            Convert.ToSingle(Math.Round(255 * splitColor(1))),
                            Convert.ToSingle(Math.Round(255 * splitColor(2))))
                        curMat.Color = col

                    Case line.ToLower.StartsWith("d ")
                        curMat.Opacity = Convert.ToSingle(line.Substring(2))

                    Case line.ToLower.StartsWith("tr ")
                        curMat.Opacity = 1 - Convert.ToSingle(line.Substring(2))

                    Case line.ToLower.StartsWith("map_kd ")
                        If LoadMaterials Then
                            Dim mtlpath As String = line.Substring(7)
                            Dim combipath As String = Path.Combine(curMatLibPath, line.Substring(7))
                            Dim imgfile As String

                            If File.Exists(combipath) Then
                                imgfile = combipath
                            ElseIf File.Exists(line.Substring(7)) Then
                                imgfile = mtlpath
                            Else
                                imgfile = ""
                            End If

                            If imgfile <> "" Then
                                Dim fs As New FileStream(imgfile, FileMode.Open, FileAccess.Read)
                                curMat.Image = Image.FromStream(fs)
                                fs.Close()
                            End If
                        End If

                End Select

                Application.DoEvents()
            Loop

            srMtl.Close()
        End Sub

        Public Shared Sub ToFile(fileName As String, obj As Object3D)
            Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
            Dim sw As New StreamWriter(fs, Text.Encoding.ASCII)
            Dim imgDirName As String = Path.GetFileNameWithoutExtension(fileName)
            Dim imgDirFull As String = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName))

            For Each kvp As KeyValuePair(Of String, Material) In obj.Materials
                Dim mat As Material = kvp.Value
                Dim name As String = "_" & ObjFile.GetIndexOfMaterialInList(obj, mat)
                sw.WriteLine($"newmtl {name}")

                If mat.Color IsNot Nothing Then
                    sw.WriteLine($"kd {mat.Color.Value.R.ToString.Replace(",", ".")} {mat.Color.Value.G.ToString.Replace(",", ".")} {mat.Color.Value.B.ToString.Replace(",", ".")}")
                End If

                If mat.Opacity IsNot Nothing Then
                    sw.WriteLine($"d {mat.Opacity.Value.ToString.Replace(",", ".")}")
                End If

                If mat.Image IsNot Nothing Then
                    Dim imgFile As String = name & ".png"

                    If Not Directory.Exists(imgDirFull) Then Directory.CreateDirectory(imgDirFull)
                    mat.Image.Save(Path.Combine(imgDirFull, imgFile), Imaging.ImageFormat.Png)

                    sw.WriteLine($"map_kd {Path.Combine(imgDirName, imgFile)}")
                End If
            Next

            sw.Flush()
            fs.Close()
        End Sub

    End Class
End Namespace