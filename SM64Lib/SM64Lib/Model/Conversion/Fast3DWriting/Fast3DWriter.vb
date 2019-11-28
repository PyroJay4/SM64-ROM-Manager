Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports System.Windows.Forms
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Levels.ScrolTex
Imports SM64Lib.Model.Fast3D
Imports SM64Lib.Model.Fast3D.DisplayLists.Script.Commands
Imports SM64Lib.N64Graphics

Namespace Model.Conversion.Fast3DWriting

    Public Class Fast3DWriter

        Public Class ConvertResult

            Public Property State As States = States.Successfully

            Public Property PtrStart As UInteger = 0
            Public Property PtrVertex As UInteger = 0
            Public ReadOnly Property PtrGeometry As New List(Of Geolayout.Geopointer)

            Public ReadOnly Property ScrollingCommands As New List(Of ManagedScrollingTexture)

            Public ReadOnly Property Data As New MemoryStream

            Public Enum States
                Successfully
                [Error]
            End Enum

        End Class

        Public Class ConvertSettings
            Public Property SegmentedAddress As UInteger?
            Public Property SizeLimit As UInteger = &H150000
            Public Property Scale As Double = 500
            Public Property OffsetPosition As Vector3 = Vector3.Zero
            Public Property ReduceVertLevel As ReduceVericesLevel = ReduceVericesLevel.Level1
            Public Property ColorTexData As String = ""
            Public Property GeoModeData As String = ""
            Public Property TexTypeData As String = ""
            Public Property ResizeTextures As Boolean = False
            Public Property CenterModel As Boolean = False
            Public Property Fog As Model.Fog = Nothing
            Public Property CollisionData As String = ""
            Public Property ForceDisplaylist As SByte = -1
            Public Property OptimizeTransparencyChecks As Boolean = False
            Public Property TextureFormatSettings As TextureFormatSettings = Nothing

            Public ReadOnly Property EnableFog As Boolean
                Get
                    Return Fog IsNot Nothing
                End Get
            End Property
        End Class

        Public Class SettingsException
            Inherits Exception

            Public Sub New()
                MyBase.New("Undefined ConvertSettings error.")
            End Sub

            Public Sub New(message As String)
                MyBase.New(message)
            End Sub
        End Class

        ''' <summary>
        ''' Reduces the number of duplicate verticies.
        ''' </summary>
        Public Enum ReduceVericesLevel As Byte
            ''' <summary>
            ''' No reduction.
            ''' </summary>
            Level0 = 0
            ''' <summary>
            ''' Reduce only in the same 0x04 group. (Best choise!)
            ''' </summary>
            Level1 = 1
            ''' <summary>
            ''' Reduce and push up. (A little buggy!)
            ''' </summary>
            Level2 = 2
        End Enum

        Private Enum MaterialType
            None
            TextureSolid
            TextureAlpha
            TextureTransparent
            ColorSolid
            ColorTransparent
        End Enum

        Private Class Vertex
            Public Property X As Int16 = 0
            Public Property Y As Int16 = 0
            Public Property Z As Int16 = 0
        End Class
        Private Class Normal
            Public Property A As Byte = 0
            Public Property B As Byte = 0
            Public Property C As Byte = 0
            Public Property D As Byte = 0
        End Class
        Private Class VertexColor
            Public Property R As Byte = 0
            Public Property G As Byte = 0
            Public Property B As Byte = 0
            Public Property A As Byte = 0
        End Class
        Private Class TexCord
            Public Property U As Single = 0
            Public Property V As Single = 0
        End Class
        Private Class Material
            Public Property Name As String = ""
            Public Property HasTexture As Boolean
            Public Property HasPalette As Boolean
            Public Property HasTextureAlpha As Boolean
            Public Property HasTransparency As Boolean
            Public Property EnableTextureColor As Boolean
            Public Property EnableAlphaMask As Boolean ' For I4/I8 textures.
            Public Property CameFromBMP As Boolean ' For I4/I8 textures.
            Public Property Color As UInteger = 0
            Public Property Opacity As Byte = 0
            Public Property OpacityOrg As Byte = 0
            Public Property Offset As UInteger = 0
            Public Property PaletteOffset As UInteger = 0
            Public Property Size As UInteger = 0
            Public Property PaletteSize As UInteger = 0
            Public Property TexWidth As UInteger = 0
            Public Property TexHeight As UInteger = 0
            Public Property Type As MaterialType = MaterialType.None
            Public Property TexType As N64Codec = N64Codec.RGBA16
            Public Property Collision As UShort = 0
            Public Property Collisionp1 As Byte = 0
            Public Property Collisionp2 As Byte = 0
            Public Property EnableGeoMode As Boolean
            Public Property GeoMode As UInteger = 0
            Public Property Texture As TextureEntry = Nothing
            Public Property EnableScrolling As Boolean = False
            Public Property DisplaylistSelection As New DisplaylistSelectionSettings
            Public Property FaceCullingMode As FaceCullingMode = FaceCullingMode.Back
            Public Property EnableMirrorS As Boolean = False
            Public Property EnableMirrorT As Boolean = False
            Public Property EnableClampS As Boolean = False
            Public Property EnableClampT As Boolean = False
            Public Property EnableCrystalEffect As Boolean = False
        End Class
        Private Class FinalVertexData
            Public Property Data As Byte() = New Byte(15) {}
            Public Property EnableVertexColor As Boolean = False
            Public ReadOnly Property EnableVertexTransparent As Boolean
                Get
                    Dim db As Byte = Data.LastOrDefault()
                    Return db < &HFF
                End Get
            End Property
        End Class
        Private Class FvGroup
            Public Property NumTri As Int16 = 0
            Public indexList(&H800) As SByte
            Public ReadOnly Property FinalVertexData As New List(Of FinalVertexData)
            Public ReadOnly Property VertexDataCount As Int16
                Get
                    Return FinalVertexData.Count
                End Get
            End Property
            Public ReadOnly Property EnableVertexColors As Boolean
                Get
                    For Each fvd As FinalVertexData In FinalVertexData
                        If fvd.EnableVertexColor Then Return True
                    Next
                    Return False
                End Get
            End Property
            Public ReadOnly Property EnableVertexAlpha As Boolean
                Get
                    For Each fvd As FinalVertexData In FinalVertexData
                        If fvd.EnableVertexTransparent Then Return True
                    Next
                    Return False
                End Get
            End Property
        End Class
        Private Class F3D
            Public data(7) As Byte
        End Class
        Private Class VertexGroupList
            Public Property Position As Integer = 0
            Public Property Length As Integer = 0
            Public Property Material As Material = Nothing
            Public ReadOnly Property GroupsCount As Integer
                Get
                    Return FinalVertexGroups.Count
                End Get
            End Property
            Public Property StartIndex As Integer = 0
            Public ReadOnly Property FinalVertexGroups As New List(Of FvGroup)
            Public ReadOnly Property EnableVertexColors As Boolean
                Get
                    For Each fvg As FvGroup In FinalVertexGroups
                        For Each fvd As FinalVertexData In fvg.FinalVertexData
                            If fvd.EnableVertexColor Then Return True
                        Next
                    Next
                    Return False
                End Get
            End Property
            Public ReadOnly Property EnableVertexAlpha As Boolean
                Get
                    If Not EnableVertexColors Then Return False
                    For Each fvg As FvGroup In FinalVertexGroups
                        For Each fvd As FinalVertexData In fvg.FinalVertexData
                            If fvd.EnableVertexColor Then
                                If fvd.Data.LastOrDefault() < &HFF Then Return True
                            End If
                        Next
                    Next
                    Return False
                End Get
            End Property
        End Class
        Private Class TextureEntry
            Public Property Width As UInteger = 0
            Public Property Height As UInteger = 0
            Public Property Data As Byte() = {}
            Public Property Palette As Byte() = {}
            Public Property OriginalImage As Image = Nothing
        End Class
        Private Class ObjPtrs
            Public name As String = 0
            Public start_ptr As UInteger = 0
            Public import_lenght As UInteger = 0
            Public solid_ptr As UInteger = 0
            Public alpha_ptr As UInteger = 0
            Public trans_ptr As UInteger = 0
            Public geo_ptr As UInteger = 0
            Public col_ptr As UInteger = 0
            Public vertex_start As UInteger = 0
        End Class
        Public Structure ScrollTex

            Public Property Offset As Integer
            Public Property VertsCount As Integer
            Public Property MaterialAddress As Integer

            Public Sub New(offset As Integer, faceCount As Byte, matAddr As Integer)
                Me.Offset = offset
                Me.VertsCount = faceCount
                Me.MaterialAddress = matAddr
            End Sub

        End Structure

        Private verts As New List(Of Vertex)
        Private norms As New List(Of Normal)
        Private vertexColors As New List(Of VertexColor)
        Private uvs As New List(Of TexCord)
        Private materials As New List(Of Material)
        Private vertexGroups As New List(Of VertexGroupList)
        Private finalVertData As New List(Of FinalVertexData)
        Private textureBank As New List(Of TextureEntry)
        Private scrollTexts As New List(Of ScrollTex)

        Private currentMaterial As Material
        Private currentFace As Integer = 0
        Private Const GEOLAYER_SOLID As Byte = 1
        Private Const GEOLAYER_ALPHA As Byte = 4
        Private Const GEOLAYER_TRANSPARENT As Byte = 5
        Private definedSegPtr As Boolean = False
        Private lastN64Codec As MaterialType = MaterialType.None
        Private lastTexType As N64Codec? = Nothing
        Private currentPreName As String = Nothing

        Private curSeg As Byte = 0
        Private startSegOffset As UInteger = 0
        Private defaultColor() As Byte = New Byte(8 + 16 - 1) {}
        Private settings As ConvertSettings = Nothing
        Private impdata As BinaryData = Nothing
        Private conRes As New ConvertResult
        Private ReadOnly ColtypesWithParams() As Byte = {14, 44, 36, 37, 39, 45}

        Private ReadOnly Property CurSegAddress As UInteger
            Get
                Return CUInt(curSeg) << 24
            End Get
        End Property

        Private Function TXL2WORDS(txls, b_txl) As Object
            Return Math.Max(1, ((txls) * (b_txl) / 8))
        End Function
        Private Function CALC_DXT(width, b_txl) As Object
            Return ((1 << 11) / TXL2WORDS(width, b_txl))
        End Function
        Private Function TXL2WORDS_4b(txls) As Object
            Return Math.Max(1, ((txls) / 16))
        End Function
        Private Function CALC_DXT_4b(width) As Object
            Return ((1 << 11) / TXL2WORDS_4b(width))
        End Function

        Private Sub SetLightAndDarkValues(s As Pilz.S3DFileParser.Shading)
            'Ambient light color
            defaultColor(0) = s.AmbientColor.R
            defaultColor(1) = s.AmbientColor.G
            defaultColor(2) = s.AmbientColor.B
            defaultColor(3) = 0
            defaultColor(4) = s.AmbientColor.R
            defaultColor(5) = s.AmbientColor.G
            defaultColor(6) = s.AmbientColor.B
            defaultColor(7) = 0

            'Diffuse light color
            defaultColor(8) = s.DiffuseColor.R
            defaultColor(9) = s.DiffuseColor.G
            defaultColor(10) = s.DiffuseColor.B
            defaultColor(11) = 0
            defaultColor(12) = s.DiffuseColor.R
            defaultColor(13) = s.DiffuseColor.G
            defaultColor(14) = s.DiffuseColor.B
            defaultColor(15) = 0

            'Diffuse light direction
            If s.DiffusePosition IsNot Nothing Then
                Dim d As Single = 127 / Math.Sqrt(s.DiffusePosition.X * s.DiffusePosition.X _
                                                  + s.DiffusePosition.Y * s.DiffusePosition.Y _
                                                  + s.DiffusePosition.Z * s.DiffusePosition.Z)
                If Single.IsInfinity(d) Then d = 0
                defaultColor(16) = Math.Round(s.DiffusePosition.X * d)
                defaultColor(17) = Math.Round(s.DiffusePosition.Y * d)
                defaultColor(18) = Math.Round(s.DiffusePosition.Z * d)
            Else
                defaultColor(16) = &H49 '= Most SM64E Like ||| Default by Nintendo: &H28
                defaultColor(17) = &H49
                defaultColor(18) = &H49
            End If
            defaultColor(19) = 0
            defaultColor(20) = 0
            defaultColor(21) = 0
            defaultColor(22) = 0
            defaultColor(23) = 0
        End Sub

        Private Sub ResetVariables()
            vertexGroups.Clear()
            verts.Clear()
            norms.Clear()
            vertexColors.Clear()
            uvs.Clear()
            materials.Clear()
            finalVertData.Clear()
            currentFace = 0
            lastN64Codec = MaterialType.None
        End Sub

        Private Sub CheckGeoModeInfo(m As Material)
            m.GeoMode = 0
            Dim gma() As String = settings.GeoModeData.Split(",")

            For Each gme As String In gma
                Dim gmd() As String = gme.Split(":")
                If m.Name.Equals(gmd(0)) Then
                    m.GeoMode = gmd(1)
                    m.EnableGeoMode = True
                    Return
                End If
            Next
        End Sub
        Private Sub CheckColorTexInfo(m As Material)
            m.Color = 0

            Dim gma() As String = settings.ColorTexData.Split(",")

            For Each gme As String In gma

                Dim gmd() As String = gme.Split(":")

                If m.Name.Equals(gmd(0)) Then

                    m.Color = gmd(1)
                    m.EnableTextureColor = True

                    Return
                End If

            Next
        End Sub
        Private Sub processMaterialColor(str As String, mat As Material)
            Dim splitColor() As String = str.Replace(".", ",").Split(" ")
            Dim r As UInteger = Convert.ToSingle(splitColor(0)) * 255
            Dim g As UInteger = Convert.ToSingle(splitColor(1)) * 255
            Dim b As UInteger = Convert.ToSingle(splitColor(2)) * 255
            mat.Color = r << 24 Or g << 16 Or b << 8 Or &HFF
        End Sub
        Private Sub processMaterialColorAlpha(alpha As Single, mat As Material)
            mat.Color = mat.Color And &HFFFFFF00UI
            mat.Color = mat.Color Or CByte((&HFF * alpha) And &HFF)
            If alpha < 1.0F Then
                mat.Type = MaterialType.ColorTransparent
                mat.HasTransparency = True
            ElseIf Not mat.HasTexture Then
                mat.Type = MaterialType.ColorSolid
            End If
        End Sub
        Private Sub checkN64CodecInfo(m As Material)
            Dim gma() As String = settings.TexTypeData.Split(",")

            For Each gme As String In gma
                Dim gmd() As String = gme.Split(":")

                If m.Name.Equals(gmd(0)) Then
                    Select Case gmd(1)
                        Case "rgba16"
                            m.TexType = N64Codec.RGBA16
                        Case "rgba32"
                            m.TexType = N64Codec.RGBA32
                        Case "ia4"
                            m.TexType = N64Codec.IA4
                        Case "ia8"
                            m.TexType = N64Codec.IA8
                        Case "ia16"
                            m.TexType = N64Codec.IA16
                        Case "i4"
                            m.TexType = N64Codec.I4
                            If gmd.Count > 2 AndAlso gmd(2) = "a" Then m.EnableAlphaMask = True
                        Case "i8"
                            m.TexType = N64Codec.I8
                            If gmd.Count > 2 AndAlso gmd(2) = "a" Then m.EnableAlphaMask = True
                    End Select

                    Return
                End If

            Next

            m.TexType = N64Codec.RGBA16
        End Sub

        Private Function GetDuplicates(mat As Material) As Material()
            Dim foundCopies As New List(Of Material)

            If mat.HasTexture Then
                For Each checkMat As Material In materials
                    If checkMat IsNot mat Then
                        If checkMat.HasTexture Then
                            If mat.TexType = checkMat.TexType AndAlso CompareTwoByteArrays(mat.Texture.Data, checkMat.Texture.Data) Then
                                If Not foundCopies.Contains(checkMat) Then
                                    foundCopies.Add(checkMat)
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            'For Each copyMat As Material In foundCopies
            '    copyMat.texture = mat.texture
            '    copyMat.offset = mat.offset
            '    copyMat.texWidth = mat.texWidth
            '    copyMat.texHeight = mat.texHeight
            '    copyMat.size = 0
            '    copyMat.isTextureCopy = True
            'Next

            Return foundCopies.ToArray
        End Function

        Private Sub MergeDuplicatedTextures()
            Dim matsToRemove As New List(Of Material)

            For Each mat As Material In materials
                If Not matsToRemove.Contains(mat) Then
                    For Each dup As Material In GetDuplicates(mat)
                        If Not matsToRemove.Contains(dup) Then
                            matsToRemove.Add(dup)
                            For Each mp As VertexGroupList In vertexGroups
                                If mp.Material Is dup Then
                                    mp.Material = mat
                                End If
                            Next
                        End If
                    Next
                End If
            Next

            For Each mat As Material In matsToRemove
                If mat.HasTexture AndAlso textureBank.Contains(mat.Texture) Then
                    textureBank.Remove(mat.Texture)
                End If
                materials.Remove(mat)
            Next
        End Sub

        Private Sub ProcessImage(obj As Pilz.S3DFileParser.Object3D, img As Image, mat As Material)
            Dim entry As TextureEntry = Nothing

            For Each tex As TextureEntry In textureBank
                If tex.OriginalImage Is img Then
                    entry = tex
                End If
            Next

            'Create & Add texture entry
            If entry Is Nothing Then
                entry = New TextureEntry With {
                    .Width = mat.TexWidth,
                    .Height = mat.TexHeight,
                    .OriginalImage = img
                }
            End If

            'Load Texture from File
            Dim bmp As New Bitmap(img)

            'Set texture size
            mat.TexWidth = bmp.Width
            mat.TexHeight = bmp.Height

            'Convert texture
            N64Graphics.N64Graphics.Convert(entry.Data, entry.Palette, mat.TexType, img)

            'Get Texture like it is ingame (fixes bug that sometimes transparency is there even if there isn't)
            If settings.OptimizeTransparencyChecks Then
                bmp = New Bitmap(bmp.Width, bmp.Height)
                Dim g As Graphics = Graphics.FromImage(bmp)
                N64Graphics.N64Graphics.RenderTexture(g, entry.Data, entry.Palette, 0, mat.TexWidth, mat.TexHeight, 1, mat.TexType, N64IMode.AlphaCopyIntensity)
            End If

            mat.Type = MaterialType.TextureSolid

            'Check for alpha and transparency
            For y As Integer = 0 To bmp.Height - 1
                For x As Integer = 0 To bmp.Width - 1
                    Dim pix As Color = bmp.GetPixel(x, y)

                    Select Case mat.TexType
                        Case N64Codec.RGBA16, N64Codec.RGBA32, N64Codec.IA4, N64Codec.IA8, N64Codec.IA16, N64Codec.CI4, N64Codec.CI8

                            If pix.A = 0 AndAlso Not mat.HasTransparency Then
                                mat.HasTextureAlpha = True
                                mat.Type = MaterialType.TextureAlpha
                            ElseIf pix.A < &HFF Then
                                mat.Type = MaterialType.TextureTransparent
                                mat.HasTransparency = True
                            End If

                            'If pix.A = 0 Then
                            '    mat.hasTextureAlpha = True
                            '    mat.type = MaterialType.TextureAlpha
                            '    mat.HasTransparency = False
                            'ElseIf pix.A < &HFF OrElse mat.opacity < &HFF Then
                            '    If mat.Type <> MaterialType.TextureAlpha Then
                            '        If mat.Opacity = &HFF Then
                            '            mat.Opacity = (CInt(mat.Opacity) * pix.A) And &HFF
                            '        End If
                            '        mat.Type = MaterialType.TextureTransparent
                            '        mat.HasTransparency = True
                            '    End If
                            'End If

                        Case N64Codec.I4, N64Codec.I8

                            If pix.A < &HFF OrElse mat.EnableAlphaMask Then
                                mat.Type = MaterialType.TextureTransparent
                                mat.HasTransparency = True
                            End If

                    End Select
                Next
            Next

            If Not textureBank.Contains(entry) Then _
                textureBank.Add(entry)

            mat.Texture = entry
            mat.HasTexture = True
            mat.HasPalette = entry.Palette.Any
        End Sub

        Private Sub ProcessObject3DModel(obj As Pilz.S3DFileParser.Object3D)
            Dim texFormatSettings As TextureFormatSettings = settings.TextureFormatSettings

            'Process Materials
            ProcessObject3DMaterials(obj, texFormatSettings)

            For Each mesh As Pilz.S3DFileParser.Mesh In obj.Meshes
                Dim curIndexStart As Integer = verts.Count

                'Process Vertices
                For Each vert In mesh.Vertices
                    Dim v As New Vertex With {
                        .X = KeepInInt16Range(Round((vert.X * settings.Scale) + settings.OffsetPosition.X)),
                        .Y = KeepInInt16Range(Round((vert.Y * settings.Scale) + settings.OffsetPosition.Y)),
                        .Z = KeepInInt16Range(Round((vert.Z * settings.Scale) + settings.OffsetPosition.Z))
                    }
                    verts.Add(v)
                Next

                'Process Normals
                For Each norm In mesh.Normals
                    Dim n As New Normal With {
                        .A = LongToByte(Round(norm.X * &H7F)),
                        .B = LongToByte(Round(norm.Y * &H7F)),
                        .C = LongToByte(Round(norm.Z * &H7F)),
                        .D = &HFF
                    }
                    norms.Add(n)
                Next

                'Process UVs
                For Each tuv As Pilz.S3DFileParser.UV In mesh.UVs
                    Dim uv As New TexCord With {
                        .U = Round(tuv.U * 32 * 32),
                        .V = Round(-(tuv.V * 32 * 32))
                    }
                    uvs.Add(uv)
                Next

                'Process Vertex Colors
                For Each vertcol In mesh.VertexColors
                    Dim vc As New VertexColor With {
                        .R = LongToByte(Round(vertcol.R * &HFF)),
                        .G = LongToByte(Round(vertcol.G * &HFF)),
                        .B = LongToByte(Round(vertcol.B * &HFF)),
                        .A = LongToByte(Round(vertcol.A * &HFF))
                    }
                    vertexColors.Add(vc)
                Next

                'Process Faces
                Dim curTexture = Nothing
                For Each face In mesh.Faces '.OrderBy(Function(n) n.Texture)
                    If curTexture Is Nothing OrElse Not curTexture.Equals(face.Material) Then
                        curTexture = face.Material

                        Dim curMatName As String = obj.Materials.FirstOrDefault(Function(n) n.Value.Equals(face.Material)).Key
                        Dim curMat = materials.FirstOrDefault(Function(n) n.Name.Equals(curMatName))

                        Dim mp As New VertexGroupList With {
                        .Position = currentFace,
                        .Material = curMat}
                        currentMaterial = curMat
                        mp.Length = 0
                        vertexGroups.Add(mp)
                    End If

                    Dim mat As Material = Nothing
                    Dim indexOfMat As Integer = 0
                    Do While mat Is Nothing AndAlso obj.Materials.Count > indexOfMat
                        If obj.Materials.ElementAt(indexOfMat).Value.Equals(face.Material) AndAlso materials(indexOfMat) IsNot Nothing Then
                            mat = materials(indexOfMat)
                        Else
                            indexOfMat += 1
                        End If
                    Loop

                    Dim va As Vertex = Nothing
                    Dim ta As TexCord = Nothing
                    Dim tanew As New TexCord
                    Dim na As Normal = Nothing
                    Dim vca As VertexColor = Nothing

                    Dim vb As Vertex = Nothing
                    Dim tb As TexCord = Nothing
                    Dim tbnew As New TexCord
                    Dim nb As Normal = Nothing
                    Dim vcb As VertexColor = Nothing

                    Dim vc As Vertex = Nothing
                    Dim tc As TexCord = Nothing
                    Dim tcnew As New TexCord
                    Dim nc As Normal = Nothing
                    Dim vcc As VertexColor = Nothing

                    Dim getVals =
                        Sub(point As Pilz.S3DFileParser.Point, ByRef vert As Vertex, ByRef t As TexCord, ByRef normal As Normal, ByRef vertcol As VertexColor)
                            With point
                                If .Vertex IsNot Nothing Then vert = verts(curIndexStart + mesh.Vertices.IndexOf(.Vertex))
                                If .UV IsNot Nothing Then t = uvs(curIndexStart + mesh.UVs.IndexOf(.UV))
                                If .Normal IsNot Nothing Then normal = norms(curIndexStart + mesh.Normals.IndexOf(.Normal))
                                If .VertexColor IsNot Nothing Then vertcol = vertexColors(curIndexStart + mesh.VertexColors.IndexOf(.VertexColor))
                            End With
                        End Sub
                    getVals(face.Points(0), va, ta, na, vca)
                    getVals(face.Points(1), vb, tb, nb, vcb)
                    getVals(face.Points(2), vc, tc, nc, vcc)

                    Dim fa As New FinalVertexData
                    Dim fb As New FinalVertexData
                    Dim fc As New FinalVertexData

                    ' Modify UV cordinates based on material.
                    Dim modifyUVCordinates =
                        Sub(tnew As TexCord, t As TexCord)
                            tnew.U = t.U * (mat.TexWidth / 32.0) - 16 '"-16" fixes the UVs offset
                            tnew.V = t.V * (mat.TexHeight / 32.0) - 16 '"-16" fixes the UVs offset
                        End Sub
                    modifyUVCordinates(tanew, ta)
                    modifyUVCordinates(tbnew, tb)
                    modifyUVCordinates(tcnew, tc)

                    'Fix UVs to reduce number of (large) faces with broken textures
                    FixUVs(tanew, tbnew, tcnew, mat.TexWidth, mat.TexHeight)

                    ' Vertex Structure: xxxxyyyyzzzz0000uuuuvvvvrrggbbaa
                    Dim buildVertexStructure =
                        Sub(final As FinalVertexData, vert As Vertex, vertcol As VertexColor, tnew As TexCord, normal As Normal)
                            final.Data(0) = (vert.X >> 8) And &HFF
                            final.Data(1) = vert.X And &HFF
                            final.Data(2) = (vert.Y >> 8) And &HFF
                            final.Data(3) = vert.Y And &HFF
                            final.Data(4) = (vert.Z >> 8) And &HFF
                            final.Data(5) = vert.Z And &HFF
                            final.Data(6) = 0
                            final.Data(7) = 0

                            Dim uInt, vInt As Integer
                            uInt = Math.Round(tnew.U)
                            vInt = Math.Round(tnew.V)
                            final.Data(8) = (uInt >> 8) And &HFF
                            final.Data(9) = uInt And &HFF
                            final.Data(10) = (vInt >> 8) And &HFF
                            final.Data(11) = vInt And &HFF

                            If vertcol IsNot Nothing Then
                                final.Data(12) = vertcol.R
                                final.Data(13) = vertcol.G
                                final.Data(14) = vertcol.B
                                final.Data(15) = vertcol.A
                                final.EnableVertexColor = True
                                ' FIXME: Add warning if Type is not TextureSolid
                                If final.EnableVertexTransparent Then
                                    mat.Type = MaterialType.TextureTransparent
                                    mat.HasTransparency = mat.HasTransparency OrElse final.EnableVertexTransparent
                                End If
                            Else
                                final.Data(12) = normal.A
                                final.Data(13) = normal.B
                                final.Data(14) = normal.C
                                final.Data(15) = normal.D
                                final.EnableVertexColor = False
                            End If
                        End Sub
                    buildVertexStructure(fa, va, vca, tanew, na)
                    buildVertexStructure(fb, vb, vcb, tbnew, nb)
                    buildVertexStructure(fc, vc, vcc, tcnew, nc)

                    finalVertData.AddRange({fa, fb, fc})

                    currentFace += 1
                Next
            Next
        End Sub

        Private Sub ProcessObject3DMaterials(obj As Pilz.S3DFileParser.Object3D, texFormatSettings As TextureFormatSettings)
            Dim size As Integer = 0
            Dim tasks As New List(Of Task)

            'Start converting each image
            For Each kvp In obj.Materials
                ProcessObject3DMaterial(obj, kvp, texFormatSettings)
                'Dim t As New Task(Sub() ProcessObject3DMaterial(obj, kvp, texFormatSettings))
                't.Start()
                'tasks.Add(t)
            Next

            'Wait until all images has been converted
            'For Each t As Task In tasks
            '    t.Wait()
            'Next
        End Sub

        Private Sub ProcessObject3DMaterial(obj As Pilz.S3DFileParser.Object3D, kvp As KeyValuePair(Of String, Pilz.S3DFileParser.Material), texFormatSettings As TextureFormatSettings)
            Dim size As Integer = 0
            Dim curEntry As TextureFormatSettings.Entry = texFormatSettings.GetEntry(kvp.Key)

            'Create new Material
            Dim m As New Material With {
                .Type = MaterialType.ColorSolid,
                .Color = 0,
                .HasTexture = False,
                .HasTextureAlpha = False,
                .HasTransparency = False,
                .Name = kvp.Key,
                .Collision = 0,
                .Opacity = &HFF,
                .OpacityOrg = &HFF,
                .EnableGeoMode = False,
                .EnableTextureColor = False,
                .EnableAlphaMask = False,
                .CameFromBMP = False,
                .EnableScrolling = curEntry.IsScrollingTexture,
                .DisplaylistSelection = curEntry.DisplaylistSelection,
                .EnableMirrorS = curEntry.EnableMirrorS,
                .EnableMirrorT = curEntry.EnableMirrorT,
                .EnableClampS = curEntry.EnableClampS,
                .EnableClampT = curEntry.EnableClampT,
                .EnableCrystalEffect = curEntry.EnableCrystalEffect
            }

            'Set default size
            size = &H10

            'Check some things
            CheckGeoModeInfo(m)
            CheckColorTexInfo(m)

            'Add material
            materials.Add(m)

            'Process Material Color
            If Not m.EnableTextureColor Then
                Dim r As UInteger = kvp.Value.Color.Value.R
                Dim g As UInteger = kvp.Value.Color.Value.G
                Dim b As UInteger = kvp.Value.Color.Value.B
                Dim a As UInteger = kvp.Value.Color.Value.A
                m.Color = r << 24 Or g << 16 Or b << 8 Or a
                If a = &HFF Then
                    m.Type = MaterialType.ColorSolid
                Else
                    m.Type = MaterialType.ColorTransparent
                End If
            End If

            'Check Texture Type
            If texFormatSettings IsNot Nothing Then
                m.TexType = N64Graphics.N64Graphics.StringCodec(texFormatSettings.GetEntry(kvp.Key).TextureFormat)
            End If

            'Process Material Image
            If kvp.Value.Image IsNot Nothing Then
                ProcessImage(obj, kvp.Value.Image, m)
                size = m.Texture.Data.Length
            End If

            'Process Material Color Alpha
            If kvp.Value.Opacity IsNot Nothing Then
                Dim tempopacity As Single = kvp.Value.Opacity
                With m
                    .Opacity = (tempopacity * &HFF) And &HFF
                    .OpacityOrg = .Opacity
                End With
                processMaterialColorAlpha(tempopacity, m)
            End If

            'Set offset and size
            m.Size = size
            If m.Texture?.Palette IsNot Nothing Then
                m.PaletteSize = m.Texture.Palette.Length
            End If
        End Sub

        Private Sub FixUVs(uv1 As TexCord, uv2 As TexCord, uv3 As TexCord, matWidth As Integer, matHeight As Integer)
            If matWidth <= 0 OrElse matHeight <= 0 Then Return

            Dim uvs As TexCord() = Nothing
            Dim temp As Integer = 0
            Dim jump As Integer = 0

            jump = matWidth * &H40
            uvs = {uv1, uv2, uv3}.OrderBy(Function(n) n.U).ToArray

            If jump <> 0 Then
                Do While uvs.Last.U > 32767
                    uvs(0).U -= jump
                    uvs(1).U -= jump
                    uvs(2).U -= jump
                Loop
                Do While uvs.First.U < -32768
                    uvs(0).U += jump
                    uvs(1).U += jump
                    uvs(2).U += jump
                Loop
            End If

            jump = matHeight * &H40
            uvs = {uv1, uv2, uv3}.OrderBy(Function(n) n.V).ToArray

            If jump <> 0 Then
                Do While uvs.Last.V > 32767
                    uvs(0).V -= jump
                    uvs(1).V -= jump
                    uvs(2).V -= jump
                Loop
                Do While uvs.First.V < -32768
                    uvs(0).V += jump
                    uvs(1).V += jump
                    uvs(2).V += jump
                Loop
            End If
        End Sub

        Private Sub removeDuplicateVertices(level As ReduceVericesLevel)
            If level < 1 Then Return

            Dim dupCnt As Integer = 0
            For Each mp As VertexGroupList In vertexGroups
                For g As Integer = 0 To mp.GroupsCount - 1
                    Dim fvg As FvGroup = mp.FinalVertexGroups(g)
                    If fvg.VertexDataCount < 1 Then Continue For

                    For i As Integer = 0 To fvg.VertexDataCount - 1
                        Dim j As Integer = i + 1
                        Do While j < fvg.VertexDataCount
                            If CompareTwoByteArrays(fvg.FinalVertexData(i).Data, fvg.FinalVertexData(j).Data, 16) Then
                                moveElementsInGroupUpward(fvg, 1, j)
                                UpdateIndexList(fvg, j, i)
                                UpdatePositions(mp.StartIndex)
                                dupCnt += 1
                            End If
                            j += 1
                        Loop
                    Next

                    If g < mp.GroupsCount - 1 AndAlso level > 1 Then
                        If MoveVertsBack(mp.FinalVertexGroups(g), mp.FinalVertexGroups(g + 1)) Then
                            g -= 1
                        End If
                    End If
                Next
            Next
        End Sub
        Private Sub UpdateIndexList(grp As FvGroup, removed As Byte, replaceWith As Byte)
            For i As Integer = 0 To grp.NumTri * 3 - 1
                If grp.indexList(i) < removed Then Continue For
                If grp.indexList(i) = removed Then
                    grp.indexList(i) = replaceWith
                Else
                    grp.indexList(i) -= 1
                End If
            Next
        End Sub
        Private Sub UpdatePositions(vs As Integer)
            For Each mp As VertexGroupList In vertexGroups
                If mp.StartIndex <= vs Then Continue For
                If mp.StartIndex < &H10 Then Continue For
                mp.StartIndex -= &H10
            Next
        End Sub
        Private Function MoveVertsBack([to] As FvGroup, from As FvGroup) As Boolean
            If from.VertexDataCount < 3 Then Return False
            If [to].VertexDataCount < 14 Then
                [to].FinalVertexData.Add(from.FinalVertexData(0))
                [to].FinalVertexData.Add(from.FinalVertexData(1))
                [to].FinalVertexData.Add(from.FinalVertexData(2))
                [to].indexList([to].NumTri * 3) = [to].VertexDataCount
                [to].indexList([to].NumTri * 3 + 1) = [to].VertexDataCount + 1
                [to].indexList([to].NumTri * 3 + 2) = [to].VertexDataCount + 2
                moveElementsInGroupUpward(from, 3, 0)
                [to].NumTri += 1
                Return True
            End If
            Return False
        End Function
        Private Sub moveElementsInGroupUpward(grp As FvGroup, amount As Integer, start As Integer)
            For i As Integer = 0 To amount - 1
                grp.FinalVertexData.RemoveAt(start)
            Next
        End Sub

        Private Sub BuildVertexGroups()
            Dim vs As Integer = 0

            For i As Integer = 0 To vertexGroups.Count - 1
                With vertexGroups(i)
                    .StartIndex = vs
                    Dim length As Integer = 0
                    If i < vertexGroups.Count - 1 Then
                        length = vertexGroups(i + 1).Position - .Position
                    Else
                        length = currentFace - .Position
                    End If

                    Dim groupsCount As Integer = 0

                    If length Mod 5 = 0 Then
                        groupsCount = length / 5
                    Else
                        groupsCount = Math.Truncate((length / 5)) + 1
                    End If

                    For j As Integer = 0 To groupsCount - 1
                        .FinalVertexGroups.Add(New FvGroup With {.NumTri = 0})
                    Next

                    For g As Integer = 0 To groupsCount - 1
                        Dim s As Integer = 5
                        If g = groupsCount - 1 Then s = length Mod 5
                        If s = 0 Then s = 5

                        Dim curFvg = .FinalVertexGroups(g)
                        curFvg.NumTri = s
                        For j As Integer = 0 To s - 1
                            Dim from As Integer = (.Position + (j + g * 5)) * 3
                            curFvg.FinalVertexData.Add(finalVertData(from))
                            curFvg.FinalVertexData.Add(finalVertData(from + 1))
                            curFvg.FinalVertexData.Add(finalVertData(from + 2))
                            curFvg.indexList(j * 3) = j * 3
                            curFvg.indexList(j * 3 + 1) = j * 3 + 1
                            curFvg.indexList(j * 3 + 2) = j * 3 + 2
                        Next

                        vs += curFvg.VertexDataCount * &H10
                    Next
                End With
            Next
        End Sub

        Private Function StrToF3D(str As String) As F3D
            Dim cmd As New F3D

            Dim b = str.Replace(".", ",").Split(" ")
            For i As Integer = 0 To b.Count - 1
                cmd.data(i) = CByte($"&H{b(i)}")
            Next

            Return cmd
        End Function

        Private Sub ImpF3D(str As String)
            ImpF3D(StrToF3D(str))
        End Sub
        Private Sub ImpF3D(f3d As F3D)
            impdata.Write(f3d.data)
        End Sub

        Private Function GetColorData(mt As Material, ByRef darkMult As Single) As Byte()
            Dim colorData As Byte() = New Byte(8 + 16 - 1) {}
            Dim lr, lg, lb, a As Byte
            Dim dr, dg, db As UShort
            lr = (mt.Color >> 24) And &HFF
            lg = (mt.Color >> 16) And &HFF
            lb = (mt.Color >> 8) And &HFF
            dr = lr * darkMult
            dg = lg * darkMult
            db = lb * darkMult
            If dr > &HFF Then dr = &HFF
            If dg > &HFF Then dg = &HFF
            If db > &HFF Then db = &HFF
            a = mt.Color And &HFF
            colorData(0) = lr
            colorData(1) = lg
            colorData(2) = lb
            colorData(3) = 0
            colorData(4) = lr
            colorData(5) = lg
            colorData(6) = lb
            colorData(7) = 0
            colorData(8) = dr
            colorData(9) = dg
            colorData(10) = db
            colorData(11) = 0
            colorData(12) = dr
            colorData(13) = dg
            colorData(14) = db
            colorData(15) = 0
            For i As Integer = 16 To colorData.Length - 1
                colorData(i) = defaultColor(i)
            Next
            Return colorData
        End Function

        Private Sub ImpFogStart(layer As Integer)
            ImpF3D("BA 00 14 02 00 10 00 00")

            Dim cmdF8 As String = ""
            cmdF8 = $"F8 00 00 00 {Hex(settings.Fog.Color.R)} {Hex(settings.Fog.Color.G)} {Hex(settings.Fog.Color.B)} FF"
            ImpF3D(cmdF8)

            Select Case layer
                Case 0
                    ImpF3D("B9 00 03 1D 00 11 22 30")
                Case 1
                    ImpF3D("B9 00 03 1D 00 11 20 78")
                Case 2
                    ImpF3D("B9 00 03 1D 00 11 2D 58")
                Case 3
                    ImpF3D("B9 00 03 1D 00 10 4D D8")
                    'ImpF3D("B9 00 03 1D 00 11 24 78")
                Case 4
                    ImpF3D("B9 00 03 1D 00 11 30 78")
                Case 5
                    ImpF3D("B9 00 03 1D 00 10 49 D8")
                Case 6
                    ImpF3D("B9 00 03 1D 00 10 4D D8")
                Case 7
                    ImpF3D("B9 00 03 1D 00 10 45 D8")
            End Select

            Select Case settings.Fog.Type
                Case Model.FogPreset.SubtleFog1
                    ImpF3D("BC 00 00 08 19 00 E8 00")
                Case Model.FogPreset.SubtleFog2
                    ImpF3D("BC 00 00 08 12 00 F0 00")
                Case Model.FogPreset.ModerateFog1
                    ImpF3D("BC 00 00 08 0E 49 F2 B7")
                Case Model.FogPreset.ModerateFog2
                    ImpF3D("BC 00 00 08 0C 80 F4 80")
                Case Model.FogPreset.ModerateFog3
                    ImpF3D("BC 00 00 08 0A 00 F7 00")
                Case Model.FogPreset.ModerateFog4
                    ImpF3D("BC 00 00 08 08 55 F8 AB")
                Case Model.FogPreset.IntenseFog
                    ImpF3D("BC 00 00 08 07 24 F9 DC")
                Case Model.FogPreset.VeryIntenseFog
                    ImpF3D("BC 00 00 08 05 00 FC 00")
                Case Model.FogPreset.HardcoreFog
                    ImpF3D("BC 00 00 08 02 50 FF 00")
            End Select

            ImpF3D("B7 00 00 00 00 01 00 00")
        End Sub

        Private Sub ImpFogEnd(layer As Integer)
            ImpF3D("BA 00 14 02 00 00 00 00")
            Select Case layer
                Case 0
                    ImpF3D("B9 00 03 1D 00 44 22 30")
                Case 1
                    ImpF3D("B9 00 03 1D 00 44 20 78")
                Case 2
                    ImpF3D("B9 00 03 1D 00 44 2D 58")
                Case 3
                    ImpF3D("B9 00 03 1D 00 40 4D D8")
                    'ImpF3D("B9 00 03 1D 00 44 24 78")
                Case 4
                    ImpF3D("B9 00 03 1D 00 44 30 78")
                Case 5
                    ImpF3D("B9 00 03 1D 00 40 49 D8")
                Case 6
                    ImpF3D("B9 00 03 1D 00 40 4D D8")
                Case 7
                    ImpF3D("B9 00 03 1D 00 40 45 D8")
            End Select
            ImpF3D("B6 00 00 00 00 01 00 00") 'B6 00 00 00 00 01 02 00 --> Smoothen Shading?
        End Sub

        Private Function GetTypeFromMaterial(mat As Material) As Byte
            Return GetTypeFromTexType(mat.TexType)
        End Function

        Private Function GetTypeFromTexType(texType As N64Codec, Optional advanced As Boolean = False) As Byte
            Select Case texType
                Case N64Codec.CI4 : Return If(advanced, &H50, &H40)
                Case N64Codec.CI8 : Return If(advanced, &H50, &H48)
                Case N64Codec.I4 : Return If(advanced, &H90, &H80)
                Case N64Codec.I8 : Return If(advanced, &H90, &H88)
                Case N64Codec.IA4 : Return If(advanced, &H70, &H60)
                Case N64Codec.IA8 : Return If(advanced, &H70, &H68)
                Case N64Codec.IA16 : Return &H70
                Case N64Codec.RGBA16 : Return &H10
                Case N64Codec.RGBA32 : Return &H18
                Case Else : Return Nothing
            End Select
        End Function

        Private Function BytesPerType(type As N64Codec) As Byte
            Select Case type
                Case N64Codec.RGBA16 : Return 2
                Case N64Codec.RGBA32 : Return 4
                Case N64Codec.I4, N64Codec.IA4, N64Codec.CI4 : Return 0 ' Special case
                Case N64Codec.IA8, N64Codec.I8, N64Codec.CI8 : Return 1
                Case Else : Return 2
            End Select
        End Function

        Private Function GetTexelIncrement(type As N64Codec) As Byte
            Select Case type
                Case N64Codec.I4, N64Codec.IA4 : Return 3
                Case N64Codec.IA8, N64Codec.I8 : Return 1
                Case Else : Return 0
            End Select
        End Function
        Private Function GetTexelShift(type As N64Codec) As Byte
            Select Case type
                Case N64Codec.I4, N64Codec.IA4, N64Codec.CI4 : Return 2
                Case N64Codec.IA8, N64Codec.I8, N64Codec.CI8 : Return 1
                Case Else : Return 0
            End Select
        End Function

        Private Sub ImpCmdFD(offset As UInteger, texType As N64Codec)
            Dim off As UInteger = startSegOffset + offset
            Dim type As Byte = GetTypeFromTexType(texType, True)
            ImpF3D($"FD {Hex(type)} 00 00 {Hex(curSeg And &HFF)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}")
        End Sub

        Private Sub ImpCmdF5_First(texType As N64Codec)
            Dim type As Byte = GetTypeFromTexType(texType, True)
            ImpF3D($"F5 {Hex(type)} 00 00 07 00 00 00")
        End Sub

        Private Sub ImpCmdF5_Second(mat As Material, texWidth As UInteger, texHeight As UInteger)
            'Create upper
            Dim type As Byte = GetTypeFromTexType(mat.TexType)
            Dim lineScale As Single = 1.0F
            Dim bpt As Byte = BytesPerType(mat.TexType)

            If bpt <> 0 Then
                lineScale = bpt / 4.0
            Else
                lineScale = 0.125F
            End If

            If mat.TexType = N64Codec.RGBA32 Then
                lineScale /= 2
            End If

            Dim line As UShort = CUShort(Math.Truncate(texWidth * lineScale)) And &H1FF
            Dim upper As UInteger = ((CUInt(type) << 16) Or (CUInt(line) << 8)) And &HFFFFFF

            'Create lower (shift)
            Dim maskS As Byte = Math.Ceiling(Math.Log(texWidth, 2)) And &HF
            Dim maskT As Byte = Math.Ceiling(Math.Log(texHeight, 2)) And &HF
            Dim lower As UInteger = ((CUInt(maskT) << 14) Or (CUInt(maskS) << 4)) And &HFFFFFF '&HFFC3F0 for only shift

            If mat.EnableMirrorS Then
                lower = lower Or &H100      'S axis
            End If
            If mat.EnableMirrorT Then
                lower = lower Or &H40000    'T axis
            End If

            If mat.EnableClampS Then
                lower = lower Or &H80000    'T axis
            End If
            If mat.EnableClampT Then
                lower = lower Or &H200      'S axis
            End If

            'Create Command
            ImpF3D($"F5 {Hex((upper >> 16) And &HFF)} {Hex((upper >> 8) And &HFF)} {Hex(upper And &HFF)} 00 {Hex((lower >> 16) And &HFF)} {Hex((lower >> 8) And &HFF)} {Hex(lower And &HFF)}")
        End Sub

        Private Sub AddCmdF3(mat As Material)
            Dim numTexels As UInteger = ((mat.TexWidth * mat.TexHeight + GetTexelIncrement(mat.TexType)) >> GetTexelShift(mat.TexType)) - 1
            Dim bpt As Integer = BytesPerType(mat.TexType)
            Dim tl As UInteger
            Dim lower As UInteger
            Dim cmd As String

            If bpt <> 0 Then
                tl = CALC_DXT(mat.TexWidth, bpt) And &HFFF
            Else
                tl = CALC_DXT_4b(mat.TexWidth) And &HFFF
            End If

            lower = ((numTexels << 12) Or tl) And &HFFFFFF
            cmd = $"F3 00 00 00 07 {Hex((lower >> 16) And &HFF)} {Hex((lower >> 8) And &HFF)} {Hex(lower And &HFF)}"

            ImpF3D(cmd)
        End Sub

        Private Sub AddCmdF2(mat As Material)
            Dim width As UShort = ((mat.TexWidth - 1) << 2) And &HFFF
            Dim height As UShort = ((mat.TexHeight - 1) << 2) And &HFFF
            Dim data As UInteger = (CInt(width) << 12) Or height
            Dim cmd As String = $"F2 00 00 00 00 {Hex((data >> 16) And &HFF)} {Hex((data >> 8) And &HFF)} {Hex(data And &HFF)}"
            ImpF3D(cmd)
        End Sub

        Private Sub AddCmdFC(mat As Material, ByRef lastCmd As String)
            Dim cmd As String = String.Empty

            Dim colorFormula As F3D_SETCOMBINE.Formula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.CCMUX.SHADE)
            Dim isColorPresent = ((mat.Color & &HFFFFFF00UI) <> &HFFFFFF00UI)
            If mat.HasTexture Then
                Select Case (mat.Type)
                    Case MaterialType.None, MaterialType.TextureSolid, MaterialType.TextureAlpha, MaterialType.TextureTransparent
                        colorFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.CCMUX.TEXEL0, F3D_SETCOMBINE.CCMUX.SHADE)

                    Case MaterialType.ColorSolid, MaterialType.ColorTransparent
                        If isColorPresent Then
                            colorFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.CCMUX.TEXEL0, F3D_SETCOMBINE.CCMUX.ENVIRONMENT)
                        Else
                            ' TODO: This condition cannot be met with current setup
                            colorFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.CCMUX.TEXEL0, F3D_SETCOMBINE.CCMUX.SHADE)
                        End If
                End Select
            Else
                Select Case (mat.Type)
                    Case MaterialType.None, MaterialType.TextureSolid, MaterialType.TextureAlpha, MaterialType.TextureTransparent
                        colorFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.CCMUX.SHADE)

                    Case MaterialType.ColorSolid, MaterialType.ColorTransparent
                        If isColorPresent Then
                            colorFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.CCMUX.SHADE, F3D_SETCOMBINE.CCMUX.ENVIRONMENT)
                        Else
                            colorFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.CCMUX.SHADE)
                        End If
                End Select
            End If

            Dim alphaFormula As F3D_SETCOMBINE.Formula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.SHADE)
            Dim isTransPresent = ((mat.Color & &HFFUI) <> &HFFUI)
            If mat.HasTexture Then
                Select Case mat.Type
                    Case MaterialType.None, MaterialType.TextureSolid, MaterialType.ColorSolid
                        alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.ONE)

                    Case MaterialType.TextureAlpha, MaterialType.TextureTransparent
                        ' With Fog multiplying SHADE is not something you want because it will be alpha fog so just output TEXEL0 and hope it is fine
                        If settings.EnableFog Then
                            alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.TEXEL0)
                        Else
                            alphaFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.ACMUX.TEXEL0, F3D_SETCOMBINE.ACMUX.SHADE)
                        End If

                    Case MaterialType.ColorTransparent
                        If isTransPresent Then
                            alphaFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.ACMUX.TEXEL0, F3D_SETCOMBINE.ACMUX.ENVIRONMENT)
                        Else
                            If settings.EnableFog Then
                                alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.TEXEL0)
                            Else
                                alphaFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.ACMUX.TEXEL0, F3D_SETCOMBINE.ACMUX.SHADE)
                            End If
                        End If
                End Select
            Else
                Select Case mat.Type
                    Case MaterialType.None, MaterialType.TextureSolid, MaterialType.ColorSolid
                        alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.ONE)

                    Case MaterialType.TextureAlpha, MaterialType.TextureTransparent
                        ' With Fog multiplying SHADE is not something you want because it will be alpha fog so just output TEXEL0
                        If settings.EnableFog Then
                            alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.ONE)
                        Else
                            alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.SHADE)
                        End If

                    Case MaterialType.ColorTransparent
                        If isTransPresent Then
                            ' If there is no material, may as well provide more options for alpha modulate
                            If settings.EnableFog Then
                                alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.ENVIRONMENT)
                            Else
                                alphaFormula = F3D_SETCOMBINE.Formula.Multiply(F3D_SETCOMBINE.ACMUX.ENVIRONMENT, F3D_SETCOMBINE.ACMUX.SHADE)
                            End If
                        Else
                            If settings.EnableFog Then
                                alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.ONE)
                            Else
                                alphaFormula = F3D_SETCOMBINE.Formula.Output(F3D_SETCOMBINE.ACMUX.SHADE)
                            End If
                        End If

                End Select
            End If

            cmd = F3D_SETCOMBINE.Make(colorFormula, alphaFormula, settings.EnableFog)
            If Not String.IsNullOrEmpty(cmd) AndAlso lastCmd <> cmd Then
                ImpF3D(cmd)
                lastCmd = cmd
            End If
        End Sub

        Private Sub ImpTriCmds(mat As Material, grp As FvGroup, offset As Integer, ByRef enabledVertexColors As Boolean)
            If grp.VertexDataCount < 3 Then Return

            Dim off As UInteger = startSegOffset + offset
            Dim amount As Integer = grp.VertexDataCount * &H10

            If mat.EnableScrolling Then
                AddScrollingTexture(grp, off, mat.Offset)
            End If

            If grp.EnableVertexColors Then
                If Not enabledVertexColors Then
                    ImpF3D("B6 00 00 00 00 02 00 00")
                    enabledVertexColors = True
                End If
            Else
                If enabledVertexColors Then
                    ImpF3D("B7 00 00 00 00 02 00 00")
                    enabledVertexColors = False
                End If
            End If

            ImpF3D($"04 {Hex((amount - &H10) And &HFF)} 00 {Hex(amount And &HFF)} {Hex(curSeg)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}")

            For i As Integer = 0 To grp.NumTri - 1
                Dim a As Byte = grp.indexList(i * 3) * &HA
                Dim b As Byte = grp.indexList(i * 3 + 1) * &HA
                Dim c As Byte = grp.indexList(i * 3 + 2) * &HA

                ImpF3D($"BF 00 00 00 00 {Hex(a)} {Hex(b)} {Hex(c)}")
            Next
        End Sub

        Private Sub ImpMaterialCmds(mat As Material, ByRef needToReShiftTMEM As Boolean, ByRef hasCrystalEffectEnabled As Boolean, ByRef needToResetCrystalEffectCommands As Boolean)
            If mat.EnableCrystalEffect AndAlso Not hasCrystalEffectEnabled Then
                ImpF3D("B7 00 00 00 00 04 00 00")
                ImpF3D("BB 00 00 01 08 00 08 00")
                hasCrystalEffectEnabled = True
                needToResetCrystalEffectCommands = True
            ElseIf needToResetCrystalEffectCommands Then
                ImpF3D("B6 00 00 00 00 04 00 00")
                ImpF3D("BB 00 00 01 FF FF FF FF")
                hasCrystalEffectEnabled = False
                needToResetCrystalEffectCommands = True
            End If

            If mat.HasPalette Then
                ImpCmdFD(mat.PaletteOffset, N64Codec.RGBA16)
                ImpF3D("F5 00 01 00 01 00 00 00")
                Dim num As UInt16 = (mat.PaletteSize / 2 - 1) << 6
                ImpF3D($"F0 00 00 00 01 {Hex((num >> 8) And &HFF)} {Hex(num And &HFF)} 00")
            End If

            If mat.HasTexture Then
                ImpCmdFD(mat.Offset, mat.TexType)
                ImpCmdF5_First(mat.TexType)
                ImpF3D("E6 00 00 00 00 00 00 00")
                AddCmdF3(mat)
                ImpF3D("E7 00 00 00 00 00 00 00")
                ImpCmdF5_Second(mat, mat.TexWidth, mat.TexHeight)
                AddCmdF2(mat)
            End If
        End Sub

        Private Sub AddScrollingTexture(grp As FvGroup, vertPtr As Integer, matAddr As Integer)
            Dim scrollTex As New ScrollTex((CInt(curSeg) << 24) Or vertPtr, grp.VertexDataCount, matAddr)
            scrollTexts.Add(scrollTex)
        End Sub

        Private Sub MergeScrollingTextures()
            scrollTexts = New List(Of ScrollTex)(scrollTexts.OrderBy(Function(n) n.Offset))

            Do While scrollTexts.Count > 0
                Dim startOff As Integer = scrollTexts(0).Offset
                Dim endOff As Integer = startOff + scrollTexts(0).VertsCount * &H10
                Dim count As Integer = 0
                Dim curMatAddr As Integer = scrollTexts(0).MaterialAddress

                For Each st As ScrollTex In scrollTexts
                    If st.MaterialAddress = curMatAddr Then
                        If st.Offset <= endOff Then
                            If (endOff - startOff) / &H10 <= UInt16.MaxValue Then
                                Dim newEndOffset = st.Offset + st.VertsCount * &H10
                                endOff = newEndOffset
                            Else
                                Exit For
                            End If
                        ElseIf st.Offset > endOff Then
                            Exit For
                        End If
                        count += 1
                    Else
                        Exit For
                    End If
                Next

                Dim vertsCount As Integer = (endOff - startOff) / &H10
                If vertsCount > 0 Then
                    scrollTexts.RemoveRange(0, count)
                    conRes.ScrollingCommands.Add(New ManagedScrollingTexture(vertsCount, startOff))
                End If
            Loop
        End Sub

        Private Sub ImpColorCmdFB(mat As Material)
            Dim r As Byte = (mat.Color >> 24) And &HFF
            Dim g As Byte = (mat.Color >> 16) And &HFF
            Dim b As Byte = (mat.Color >> 8) And &HFF
            ImpF3D($"FB 00 00 00 {Hex(r)} {Hex(g)} {Hex(b)} {Hex(mat.Opacity)}")
        End Sub

        Private Sub AlignPosition()
            HexRoundUp2(impdata.Position)
        End Sub

        ''' <summary>
        ''' Adds a command that is requied on the end of a display list if CI textures are enabled
        ''' </summary>
        Private Sub ShiftTMEMBack()
            ImpF3D("BA 00 0E 02 00 00 00 00")
        End Sub

        ''' <summary>
        ''' Adds a command to enable CI textures
        ''' </summary>
        Private Sub SetOtherMode_H()
            ImpF3D("BA 00 0E 02 00 00 80 00")
        End Sub

        Private Sub ImportObj(model As Pilz.S3DFileParser.Object3D)
            Dim enabledVertexColors As Boolean
            Dim enableForcing As Boolean = settings.ForceDisplaylist <> -1
            Dim importStart As UInteger = 0
            Dim startVerts As UInteger = 0
            Dim needToRevertShiftTMEM As Boolean = False
            Dim lastMaterial As Material = Nothing
            Dim lastFBColor As UInt32 = Nothing
            Dim hasCrystalEffectEnabled, needToResetCrystalEffectCommands As Boolean
            Dim ciEnabled As Boolean
            Dim citextypes As N64Codec() = {N64Codec.CI4, N64Codec.CI8}
            Dim lastCmdFC As String
            Dim dlsToCreate As New List(Of DisplaylistProps)
            Dim dicMatDlIDs As New Dictionary(Of Material, Integer)

            ProcessObject3DModel(model)

            conRes.PtrStart = CurSegAddress Or impdata.Position
            importStart = impdata.Position

            'Write default color
            impdata.Write(defaultColor)

            'Remove duplicated textures
            ' FIXME: This function does not account for materials properties like Opacity
            'MergeDuplicatedTextures()

            'Write materials
            For Each mt As Material In materials
                If mt.HasTexture Then
                    mt.Offset = impdata.Position
                    impdata.Write(mt.Texture.Data)
                    AlignPosition()

                    If mt.HasPalette Then
                        mt.PaletteOffset = impdata.Position
                        impdata.Write(mt.Texture.Palette)
                        AlignPosition()
                    End If
                End If
            Next

            'Prepaire vertices
            BuildVertexGroups()
            removeDuplicateVertices(settings.ReduceVertLevel)

            'Write vertices
            conRes.PtrVertex = CurSegAddress Or impdata.Position
            startVerts = impdata.Position
            For Each mp As VertexGroupList In vertexGroups
                For g As Integer = 0 To mp.GroupsCount - 1
                    If mp.FinalVertexGroups(g).VertexDataCount >= 1 Then
                        For i As Integer = 0 To mp.FinalVertexGroups(g).VertexDataCount - 1
                            Dim data As Byte() = mp.FinalVertexGroups(g).FinalVertexData(i).Data
                            impdata.Write(data)
                        Next
                    End If
                Next
            Next

            Dim createDefaultDL =
                Function(layerID As DefaultGeolayers) As Integer
                    Dim dlProp As DisplaylistProps = Nothing
                    Dim newLayerID = (layerID + 1) * -1

                    For Each dl As DisplaylistProps In dlsToCreate
                        If dlProp Is Nothing AndAlso dl.ID = newLayerID Then
                            dlProp = dl
                        End If
                    Next

                    If dlProp Is Nothing Then
                        dlProp = New DisplaylistProps(newLayerID)
                    End If

                    dlProp.Layer = layerID

                    If Not dlsToCreate.Contains(dlProp) Then
                        dlsToCreate.Add(dlProp)
                    End If

                    Return dlProp.ID
                End Function

            Dim createCustomDL =
                Function(dlID As Integer) As Integer
                    Dim dlProp As DisplaylistProps = Nothing

                    'Search dlProp
                    For Each prop In settings.TextureFormatSettings.CustomDisplayLists
                        If dlProp Is Nothing AndAlso prop.ID = dlID Then
                            dlProp = prop
                        End If
                    Next

                    If Not dlsToCreate.Contains(dlProp) Then
                        dlsToCreate.Add(dlProp)
                    End If

                    Return dlProp.ID
                End Function

            'Check which DLs should be created
            If enableForcing Then
                Dim dlID As Integer =
                    createDefaultDL(settings.ForceDisplaylist)

                For Each mat As Material In materials
                    dicMatDlIDs.Add(mat, dlID)
                Next
            Else
                For Each mat As Material In materials
                    Dim dlID As Integer = -1

                    Select Case mat.DisplaylistSelection.SelectionMode
                        Case DisplaylistSelectionMode.Automatic
                            If mat.HasTransparency Then
                                dlID = createDefaultDL(DefaultGeolayers.Translucent)
                            ElseIf mat.HasTextureAlpha Then
                                dlID = createDefaultDL(DefaultGeolayers.Alpha)
                            Else
                                dlID = createDefaultDL(DefaultGeolayers.Solid)
                            End If
                        Case DisplaylistSelectionMode.Default
                            dlID = createDefaultDL(mat.DisplaylistSelection.DefaultGeolayer)
                        Case DisplaylistSelectionMode.Custom
                            dlID = createCustomDL(mat.DisplaylistSelection.CustomDisplaylistID)
                    End Select

                    dicMatDlIDs.Add(mat, dlID)
                Next
            End If

            'Create DLs
            For Each dlProps As DisplaylistProps In dlsToCreate
                'Add Geopointer
                conRes.PtrGeometry.Add(New Geopointer(dlProps.Layer, CurSegAddress Or impdata.Position))

                'Reset some stuff
                enabledVertexColors = False
                hasCrystalEffectEnabled = False
                needToResetCrystalEffectCommands = True
                ciEnabled = False
                lastMaterial = Nothing
                lastN64Codec = MaterialType.None
                lastTexType = Nothing
                lastFBColor = Nothing
                lastCmdFC = String.Empty

                'Create DL
                ImpF3D("E7 00 00 00 00 00 00 00")
                If settings.EnableFog Then ImpF3D("B9 00 02 01 00 00 00 00")
                ImpF3D("B7 00 00 00 00 00 00 00")
                ImpF3D("BB 00 00 01 FF FF FF FF")
                ImpF3D("E8 00 00 00 00 00 00 00")
                ImpF3D("E6 00 00 00 00 00 00 00")
                ImpF3D("03 88 00 10 0E 00 00 00")
                ImpF3D("03 86 00 10 0E 00 00 08")
                If settings.EnableFog Then ImpFogStart(dlProps.Layer)

                For i As Integer = 0 To vertexGroups.Count - 1
                    Dim mp As VertexGroupList = vertexGroups(i)

                    If dicMatDlIDs(mp.Material) <> dlProps.ID Then Continue For

                    Dim iscitexture As Boolean = citextypes.Contains(mp.Material.TexType)
                    Dim waslastcitexture As Boolean = lastMaterial IsNot Nothing AndAlso citextypes.Contains(lastMaterial.TexType)

                    'CI Texture things
                    If iscitexture AndAlso Not waslastcitexture Then
                        SetOtherMode_H()
                        ciEnabled = True
                    ElseIf Not iscitexture AndAlso waslastcitexture Then
                        ShiftTMEMBack()
                    End If

                    'Geomode
                    If mp.Material.EnableGeoMode Then
                        ImpF3D("B6 00 00 00 FF FF FF FF")
                        ImpF3D($"B7 00 00 00 {Hex((mp.Material.GeoMode >> 24) And &HFF)} {Hex((mp.Material.GeoMode >> 16) And &HFF)} {Hex((mp.Material.GeoMode >> 8) And &HFF)} {Hex(mp.Material.GeoMode And &HFF)}")
                    End If

                    If lastMaterial IsNot mp.Material Then
                        lastMaterial = mp.Material

                        AddCmdFC(mp.Material, lastCmdFC)
                        If mp.Material.Type = MaterialType.ColorSolid Or mp.Material.Type = MaterialType.ColorTransparent Then
                            If lastFBColor <> mp.Material.Color Then
                                ImpColorCmdFB(mp.Material)
                            End If
                        End If

                        ImpMaterialCmds(mp.Material, needToRevertShiftTMEM, hasCrystalEffectEnabled, needToResetCrystalEffectCommands)
                    End If

                    Dim grpOff As Integer = 0
                    For ii As Integer = 0 To mp.GroupsCount - 1
                        ImpTriCmds(mp.Material, mp.FinalVertexGroups(ii), startVerts + (mp.StartIndex + grpOff), enabledVertexColors)
                        grpOff += mp.FinalVertexGroups(ii).VertexDataCount * &H10
                    Next

                    If mp.Material.EnableGeoMode Then
                        If i + 1 < vertexGroups.Count AndAlso vertexGroups(i + 1).Material.EnableGeoMode Then Continue For
                        ImpF3D("B6 00 00 00 FF FF FF FF")
                        ImpF3D("B7 00 00 00 00 02 20 05")
                    End If
                Next

                If enabledVertexColors Then ImpF3D("B7 00 00 00 00 02 00 00")
                If settings.EnableFog Then ImpFogEnd(dlProps.Layer)
                ImpF3D("FC FF FF FF FF FE 79 3C")
                ImpF3D("BB 00 00 00 FF FF FF FF")
                If needToResetCrystalEffectCommands Then ImpF3D("B6 00 00 00 00 04 00 00")
                If ciEnabled Then ShiftTMEMBack()
                ImpF3D("B8 00 00 00 00 00 00 00")

                MergeScrollingTextures()
            Next

            ResetVariables()
            currentPreName = Nothing
        End Sub

        ''' <summary>
        ''' Converts a Object3D to an N64 Model and an SM64 Collision.
        ''' </summary>
        ''' <param name="s">The stream where to write the Fast3D and Collision data.</param>
        ''' <param name="settings">The convert settings.</param>
        ''' <param name="input">The input model.</param>
        ''' <returns></returns>
        Public Function ConvertModel(s As Stream, settings As ConvertSettings, input As Pilz.S3DFileParser.Object3D) As ConvertResult
            Me.settings = settings
            impdata = New BinaryStreamData(s)

            'Rom Address
            definedSegPtr = False

            'Segmented Address
            If settings.SegmentedAddress IsNot Nothing Then
                startSegOffset = settings.SegmentedAddress And &HFFFFFF
                curSeg = (settings.SegmentedAddress >> 24) And &HFF
                definedSegPtr = True
            End If

            'Shading
            SetLightAndDarkValues(input.Shading)

            'Convert
            ImportObj(input)

            ResetVariables()

            Return conRes
        End Function

    End Class

End Namespace
