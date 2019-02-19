Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports S3DFileParser

Public Class Renderer

    Private obj3d As Object3D
    Private dicTextureIDs As New Dictionary(Of Image, Integer)
    Private dicColorIDs As New Dictionary(Of Color, Integer)
    Private emptyTexture As Bitmap = Nothing
    Private lineTexture As Bitmap = Nothing
    Private selectedLineTexture As Bitmap = Nothing
    Public Property ModelScaling As Single = 1.0F
    Public ReadOnly Property HasRendered As Boolean = False
    Public ReadOnly Property SelectedElements As List(Of Object)

    Private ReadOnly Property VertexBuffers As New Dictionary(Of Mesh, Integer)
    Private ReadOnly Property IndicesBuffers As New Dictionary(Of Mesh, List(Of Integer))
    Private ReadOnly Property UVBuffers As New Dictionary(Of Mesh, Integer)
    Private ReadOnly Property VertexColorBuffers As New Dictionary(Of Mesh, Integer)
    Private ReadOnly Property NormalBuffers As New Dictionary(Of Mesh, Integer)

    Public ReadOnly Property Model As Object3D
        Get
            Return obj3d
        End Get
    End Property

    Public Sub New(obj3d As Object3D)
        Me.obj3d = obj3d.ToOneMesh

        'Set Texture used for faces without texture
        emptyTexture = ColorToTexture(Color.LightGray)

        'Set Texture used for lines
        lineTexture = ColorToTexture(Color.Black)

        'Set Texture used for lines of selected faces
        selectedLineTexture = ColorToTexture(Color.Orange)
    End Sub

    Private Function ColorToTexture(color As Color) As Image
        Dim tex As New Bitmap(1, 1)
        tex.SetPixel(0, 0, color)
        Return tex
    End Function

    ''' <summary>
    ''' Updates the Data of a Vertex in the buffer.
    ''' </summary>
    ''' <param name="m">The Mesh where the Vertex is listed.</param>
    ''' <param name="v">The Vertex to update.</param>
    Public Sub UpdateVertexData(m As Mesh, v As Vertex)
        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBuffers(m))
        GL.BufferSubData(BufferTarget.ArrayBuffer, CType(m.Vertices.IndexOf(v) * Vector3.SizeInBytes, IntPtr), Vector3.SizeInBytes, New Vector3(v.X, v.Y, v.Z))
    End Sub

    ''' <summary>
    ''' Updates the Data of a Normal in the buffer.
    ''' </summary>
    ''' <param name="m">The Mesh where the Vertex is listed.</param>
    ''' <param name="n">The Normal to update.</param>
    Public Sub UpdateNormalData(m As Mesh, n As Normal)
        GL.BindBuffer(BufferTarget.ArrayBuffer, NormalBuffers(m))
        GL.BufferSubData(BufferTarget.ArrayBuffer, CType(m.Normals.IndexOf(n) * Vector3.SizeInBytes, IntPtr), Vector3.SizeInBytes, New Vector3(n.X, n.Y, n.Z))
    End Sub

    ''' <summary>
    ''' Updates the Data of a Vertex Color in the buffer.
    ''' </summary>
    ''' <param name="m">The Mesh where the Vertex is listed.</param>
    ''' <param name="vc">The Vertex Color to update.</param>
    Public Sub UpdateVertexColorData(m As Mesh, vc As VertexColor)
        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexColorBuffers(m))
        GL.BufferSubData(BufferTarget.ArrayBuffer, CType(m.VertexColors.IndexOf(vc) * Vector4.SizeInBytes, IntPtr), Vector4.SizeInBytes, New Vector4(vc.R, vc.G, vc.B, vc.A))
    End Sub

    ''' <summary>
    ''' Updates the Data of a UV in the buffer.
    ''' </summary>
    ''' <param name="m">The Mesh where the Vertex is listed.</param>
    ''' <param name="uv">The UV to update.</param>
    Public Sub UpdateUVData(m As Mesh, uv As UV)
        GL.BindBuffer(BufferTarget.ArrayBuffer, UVBuffers(m))
        GL.BufferSubData(BufferTarget.ArrayBuffer, CType(m.UVs.IndexOf(uv) * Vector2.SizeInBytes, IntPtr), Vector2.SizeInBytes, New Vector2(uv.U, uv.V))
    End Sub

    ''' <summary>
    ''' Updates the indicies of a face in the buffer.
    ''' </summary>
    ''' <param name="m">The Mesh where the Vertex is listed.</param>
    ''' <param name="f">The Face to update.</param>
    Public Sub UpdateFaceIndicies(m As Mesh, f As Face)
        Dim faceIndex As Integer = m.Faces.IndexOf(f)
        Dim uintlen As Byte = Len(New UInteger)
        Dim indicies As New Vector3(m.Vertices.IndexOf(f.Points(0).Vertex),
                                    m.Vertices.IndexOf(f.Points(1).Vertex),
                                    m.Vertices.IndexOf(f.Points(2).Vertex))

        GL.BindBuffer(BufferTarget.ArrayBuffer, IndicesBuffers(m)(faceIndex))
        GL.BufferSubData(BufferTarget.ArrayBuffer, CType(uintlen * faceIndex, IntPtr), uintlen, indicies)
    End Sub

    ''' <summary>
    ''' Replace an Image with a new one.
    ''' </summary>
    ''' <param name="oldImage"></param>
    ''' <param name="newImage"></param>
    Public Sub UpdateTexture(oldImage As Image, newImage As Image)
        If dicTextureIDs.ContainsKey(oldImage) Then
            Dim id As Integer = dicTextureIDs(oldImage)
            dicTextureIDs.Remove(oldImage)
            dicTextureIDs.Add(newImage, id)
            ContentPipe.LoadTexture(newImage, id)
        End If
    End Sub

    ''' <summary>
    ''' Updates an Image.
    ''' </summary>
    ''' <param name="image"></param>
    Public Sub UpdateTexture(image As Image)
        If dicTextureIDs.ContainsKey(image) Then
            ContentPipe.LoadTexture(dicTextureIDs(image))
        End If
    End Sub

    ''' <summary>
    ''' Creates the Buffers and store the requied Data.
    ''' </summary>
    Public Sub RenderModel()
        ReleaseBuffers()

        For Each mesh As Mesh In obj3d.Meshes

            Dim nibo As New List(Of Integer)
            Dim enablecols As Boolean = mesh.VertexColors.Count > 0
            Dim enablenorms As Boolean = (Not enablecols) AndAlso mesh.Normals.Count > 0
            Dim verts As New List(Of Vector3)
            Dim uvs As New List(Of Vector2)
            Dim cols As New List(Of Vector4)
            Dim norms As New List(Of Vector3)
            Dim curvi As ULong = 0
            IndicesBuffers.Add(mesh, nibo)

            For i As Integer = 0 To mesh.Faces.Count - 1
                With mesh.Faces(i)
                    Dim indices As New List(Of UInteger)
                    For Each p As S3DFileParser.Point In .Points
                        indices.Add(curvi)
                        curvi += 1

                        If verts IsNot Nothing Then
                            verts.Add(New Vector3(p.Vertex.X, p.Vertex.Y, p.Vertex.Z))
                        Else
                            verts.Add(New Vector3(0, 0, 0))
                        End If

                        If p.UV IsNot Nothing Then
                            uvs.Add(New Vector2(p.UV.U, p.UV.V))
                        Else
                            uvs.Add(New Vector2(0, 0))
                        End If

                        If enablecols AndAlso p.VertexColor IsNot Nothing Then
                            cols.Add(New Vector4(p.VertexColor.R, p.VertexColor.G, p.VertexColor.B, p.VertexColor.A))
                        Else
                            cols.Add(New Vector4(1, 1, 1, 1))
                        End If

                        If enablenorms AndAlso p.Normal IsNot Nothing Then
                            norms.Add(New Vector3(p.Normal.X, p.Normal.Y, p.Normal.Z))
                        Else
                            norms.Add(New Vector3(1, 1, 1))
                        End If
                    Next

                    nibo.Add(GL.GenBuffer)
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, nibo(i))
                    GL.BufferData(
                            BufferTarget.ElementArrayBuffer,
                            CType(Len(New UInteger) * indices.Count, IntPtr),
                            indices.ToArray,
                            BufferUsageHint.StaticDraw)

                    If .Material?.Image IsNot Nothing Then
                        If Not dicTextureIDs.ContainsKey(.Material.Image) Then
                            dicTextureIDs.Add(.Material.Image, ContentPipe.LoadTexture(.Material.Image))
                        End If
                    ElseIf .Material?.Color IsNot Nothing Then
                        If Not dicColorIDs.ContainsKey(.Material.Color) Then
                            dicColorIDs.Add(.Material.Color, ContentPipe.LoadTexture(ColorToTexture(.Material.Color)))
                        End If
                    Else
                        If Not dicTextureIDs.ContainsKey(emptyTexture) Then
                            dicTextureIDs.Add(emptyTexture, ContentPipe.LoadTexture(emptyTexture))
                        End If
                    End If
                End With
            Next

            Dim nvbo As Integer = GL.GenBuffer
            VertexBuffers.Add(mesh, nvbo)
            GL.BindBuffer(BufferTarget.ArrayBuffer, nvbo)
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                CType(Vector3.SizeInBytes * verts.Count, IntPtr),
                verts.ToArray,
                BufferUsageHint.StaticDraw
                )

            Dim ntbo As Integer = GL.GenBuffer
            UVBuffers.Add(mesh, ntbo)
            GL.BindBuffer(BufferTarget.ArrayBuffer, ntbo)
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                CType(Vector2.SizeInBytes * uvs.Count, IntPtr),
                uvs.ToArray,
                BufferUsageHint.StaticDraw
                )

            If enablecols Then
                Dim ncbo As Integer = GL.GenBuffer
                VertexColorBuffers.Add(mesh, ncbo)
                GL.BindBuffer(BufferTarget.ArrayBuffer, ncbo)
                GL.BufferData(
                        BufferTarget.ArrayBuffer,
                        CType(Vector4.SizeInBytes * cols.Count, IntPtr),
                        cols.ToArray,
                        BufferUsageHint.StaticDraw
                        )
            End If

            If enablenorms Then
                Dim nnbo As Integer = GL.GenBuffer
                NormalBuffers.Add(mesh, nnbo)
                GL.BindBuffer(BufferTarget.ArrayBuffer, nnbo)
                GL.BufferData(
                        BufferTarget.ArrayBuffer,
                        CType(Vector3.SizeInBytes * norms.Count, IntPtr),
                        norms.ToArray,
                        BufferUsageHint.StaticDraw
                        )
            End If

        Next

        If Not dicTextureIDs.ContainsKey(lineTexture) Then
            dicTextureIDs.Add(lineTexture, ContentPipe.LoadTexture(lineTexture))
        End If

        _HasRendered = True
    End Sub

    Public Sub DrawModel(mode As RenderMode)
        DrawModel(mode, Vector3.Zero, Quaternion.Identity, New Vector3(ModelScaling, ModelScaling, ModelScaling))
    End Sub
    Public Sub DrawModel(mode As RenderMode, pos As Vector3, rot As Quaternion)
        DrawModel(mode, pos, rot, New Vector3(ModelScaling, ModelScaling, ModelScaling))
    End Sub
    Public Sub DrawModel(mode As RenderMode, pos As Vector3, rot As Quaternion, scale As Vector3)
        If mode = RenderMode.None Then Return
        If Not _HasRendered Then Return

        GL.PushMatrix()
        GL.Translate(pos.X, pos.Y, pos.Z)
        GL.Rotate(rot.X, 1, 0, 0)
        GL.Rotate(rot.Y, 0, 1, 0)
        GL.Rotate(rot.Z, 0, 0, 1)
        GL.Scale(scale) 'GL.Scale(scale.X, scale.Y, scale.Z)
        GL.EnableClientState(ArrayCap.VertexArray)
        GL.EnableClientState(ArrayCap.TextureCoordArray)

        For Each mesh As Mesh In obj3d.Meshes
            If VertexColorBuffers.ContainsKey(mesh) Then
                GL.EnableClientState(ArrayCap.ColorArray)
            ElseIf NormalBuffers.ContainsKey(mesh) Then
                GL.EnableClientState(ArrayCap.NormalArray)
            End If

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBuffers(mesh))
            GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero)

            GL.BindBuffer(BufferTarget.ArrayBuffer, UVBuffers(mesh))
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, IntPtr.Zero)

            If VertexColorBuffers.ContainsKey(mesh) Then
                GL.BindBuffer(BufferTarget.ArrayBuffer, VertexColorBuffers(mesh))
                GL.ColorPointer(4, ColorPointerType.Float, 0, IntPtr.Zero)
            ElseIf NormalBuffers.ContainsKey(mesh) Then
                GL.BindBuffer(BufferTarget.ArrayBuffer, NormalBuffers(mesh))
                GL.NormalPointer(NormalPointerType.Float, 0, IntPtr.Zero)
            End If

            For i As Integer = 0 To mesh.Faces.Count - 1
                Dim l As Face = mesh.Faces(i)

                GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndicesBuffers(mesh)(i))

                Dim texID As Integer
                Dim isEmptyTexture As Boolean = l.Material?.Image Is Nothing
                Dim isEmptyColor As Boolean = l.Material?.Color Is Nothing

                If (mode And RenderMode.Fill) = RenderMode.Fill Then
                    texID = If(isEmptyTexture, If(isEmptyColor, dicTextureIDs(emptyTexture), dicColorIDs(l.Material.Color)), dicTextureIDs(l.Material.Image))

                    GL.BindTexture(TextureTarget.Texture2D, texID)

                    If Not isEmptyTexture Then
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, l.Material.Wrap.X)
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, l.Material.Wrap.Y)
                    End If

                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill)

                    GL.DrawElements(PrimitiveType.Triangles, l.Points.Count,
                                    DrawElementsType.UnsignedInt, IntPtr.Zero)

                End If

                If (mode And RenderMode.Outline) = RenderMode.Outline Then

                    If (mode And RenderMode.Fill) = RenderMode.Fill Then
                        texID = dicTextureIDs(lineTexture)
                        GL.BindTexture(TextureTarget.Texture2D, texID)
                    Else
                        texID = If(isEmptyTexture, If(isEmptyColor, dicTextureIDs(emptyTexture), dicColorIDs(l.Material.Color)), dicTextureIDs(l.Material.Image))
                        GL.BindTexture(TextureTarget.Texture2D, texID)

                        If Not isEmptyTexture Then
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, l.Material.Wrap.X)
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, l.Material.Wrap.Y)
                        End If
                    End If

                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line)

                    GL.DrawElements(PrimitiveType.Triangles, l.Points.Count,
                                    DrawElementsType.UnsignedInt, IntPtr.Zero)

                End If
            Next

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill) 'Reset for RenderEngineOld

            If VertexColorBuffers.ContainsKey(mesh) Then
                GL.DisableClientState(ArrayCap.ColorArray)
            ElseIf NormalBuffers.ContainsKey(mesh) Then
                GL.DisableClientState(ArrayCap.NormalArray)
            End If
        Next

        GL.DisableClientState(ArrayCap.VertexArray)
        GL.DisableClientState(ArrayCap.TextureCoordArray)
        GL.PopMatrix()
    End Sub

    Public Sub DrawFacePicking()
        DrawFacePicking(Vector3.Zero, Quaternion.Identity, New Vector3(ModelScaling, ModelScaling, ModelScaling))
    End Sub
    Public Sub DrawFacePicking(pos As Vector3, rot As Quaternion)
        DrawFacePicking(pos, rot, New Vector3(ModelScaling, ModelScaling, ModelScaling))
    End Sub
    Public Sub DrawFacePicking(pos As Vector3, rot As Quaternion, scale As Vector3)
        If Not _HasRendered Then Return

        GL.PushMatrix()
        GL.Translate(pos.X, pos.Y, pos.Z)
        GL.Rotate(rot.X, 1, 0, 0)
        GL.Rotate(rot.Y, 0, 1, 0)
        GL.Rotate(rot.Z, 0, 0, 1)
        GL.Scale(scale)
        GL.EnableClientState(ArrayCap.VertexArray)

        For iMesh As Integer = 0 To obj3d.Meshes.Count - 1
            Dim mesh As Mesh = obj3d.Meshes(iMesh)

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBuffers(mesh))
            GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero)

            For iFace As Integer = 0 To mesh.Faces.Count - 1
                Dim l As Face = mesh.Faces(iFace)

                GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndicesBuffers(mesh)(iFace))

                GL.Color4(Color.FromArgb(&H20000000 + (iMesh << 16) + iFace)) 'Color: "2f ff xx xx" -> where 'f' = mesh index and where 'x' is face index

                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill)

                GL.DrawElements(PrimitiveType.Triangles, l.Points.Count,
                                    DrawElementsType.UnsignedInt, IntPtr.Zero)
            Next

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill)
        Next

        GL.DisableClientState(ArrayCap.VertexArray)
        GL.PopMatrix()
    End Sub

    Public Sub ReleaseBuffers()
        If Not HasRendered Then Return

        For Each kvp As KeyValuePair(Of Mesh, Integer) In VertexBuffers
            GL.DeleteBuffer(kvp.Value)
        Next
        VertexBuffers.Clear()

        For Each kvp As KeyValuePair(Of Mesh, Integer) In UVBuffers
            GL.DeleteBuffer(kvp.Value)
        Next
        UVBuffers.Clear()

        For Each kvp As KeyValuePair(Of Mesh, Integer) In VertexColorBuffers
            GL.DeleteBuffer(kvp.Value)
        Next
        VertexColorBuffers.Clear()

        For Each kvp As KeyValuePair(Of Mesh, Integer) In NormalBuffers
            GL.DeleteBuffer(kvp.Value)
        Next
        NormalBuffers.Clear()

        For Each kvp As KeyValuePair(Of Mesh, List(Of Integer)) In IndicesBuffers
            For Each i As Integer In kvp.Value
                GL.DeleteBuffer(i)
            Next
            kvp.Value.Clear()
        Next
        IndicesBuffers.Clear()

        For Each kvp As KeyValuePair(Of Image, Integer) In dicTextureIDs
            GL.DeleteBuffer(kvp.Value)
        Next
        dicTextureIDs.Clear()

        For Each kvp As KeyValuePair(Of Color, Integer) In dicColorIDs
            GL.DeleteBuffer(kvp.Value)
        Next
        dicColorIDs.Clear()

        _HasRendered = False
    End Sub

    Protected Overrides Sub Finalize()
        'ReleaseBuffers()
    End Sub

End Class

Public Enum RenderMode As Byte
    None = &H0
    Fill = &H1
    Outline = &H2
    FillOutline = Fill Or Outline
End Enum
