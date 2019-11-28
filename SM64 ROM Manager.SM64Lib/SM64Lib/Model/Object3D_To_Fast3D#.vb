Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports System.Windows.Forms
Imports N64Graphics
Imports SM64Lib.Level.ScrolTex
Imports SM64Lib.Model.Fast3D

Namespace Global.SM64Lib.SM64Convert

    Public Class Fast3DWriter

        Public Class ConvertResult

            Public Property State As States = States.Successfully

            Public Property PtrStart As UInteger = 0
            Public Property PtrVertex As UInteger = 0
            Public Property PtrSolid As UInteger = 0
            Public Property PtrAlpha As UInteger = 0
            Public Property PtrTrans As UInteger = 0

            Public ReadOnly Property ScrollingCommands As New List(Of ManagedScrollingTexture)

            Public ReadOnly Property Data As New MemoryStream

            Public Enum States
                Successfully
                [Error]
            End Enum

        End Class

        Public Class ConvertSettings
            Public Property RomAddress As UInteger?
            Public Property SegmentedAddress As UInteger?
            Public Property SizeLimit As UInteger = &H150000
            Public Property Scale As Double = 500
            Public Property OffsetPosition As Vector3 = Vector3.Zero
            Public Property ReduceVertLevel As ReduceVericesLevel = ReduceVericesLevel.Level1
            Public Property ColorTexData As String = ""
            Public Property GeoModeData As String = ""
            Public Property TexTypeData As String = ""
            Public Property FlipTexturesVerticaly As Boolean = False
            Public Property ResizeTextures As Boolean = False
            Public Property CenterModel As Boolean = False
            Public Property Fog As Model.Fog = Nothing
            Public Property Mode As ConvertingMode = ConvertingMode.VisualMap
            Public Property CollisionData As String = ""
            Public Property ForceDisplaylist As Geolayout.Geolayer = -1
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

        Public Enum ConvertingMode
            VisualMap
            Collision
        End Enum
        ''' <summary>
        ''' Reduces the number of duplicate verticies.
        ''' </summary>
        Public Enum ReduceVericesLevel As Byte
            ''' <summary>
            ''' No reduction.
            ''' </summary>
            Level0 = 0
            ''' <summary>
            ''' Reduce only in the same 0x04 group.
            ''' </summary>
            Level1 = 1
            ''' <summary>
            ''' Reduce and push up. (A little buggy, will fully fix in next version)
            ''' </summary>
            Level2 = 2
        End Enum

        Private Enum MaterialType
            NOT_DEFINED
            TEXTURE_SOLID
            TEXTURE_ALPHA
            TEXTURE_TRANSPARENT
            COLOR_SOLID
            COLOR_TRANSPARENT
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
            Public hasTexture As Boolean
            Public hasTextureAlpha As Boolean
            Public hasTransparency As Boolean
            Public isTextureCopy As Boolean
            Public enableTextureColor As Boolean
            Public enableAlphaMask As Boolean ' For I4/I8 textures.
            Public cameFromBMP As Boolean ' For I4/I8 textures.
            Public color As UInteger = 0
            Public opacity As Byte = 0
            Public opacityOrg As Byte = 0
            Public offset As UInteger = 0
            Public texColOffset As UInteger = 0
            Public texColDark As Single = 0
            Public size As UInteger = 0
            Public paletteSize As UInteger = 0
            Public texWidth As UInteger = 0
            Public texHeight As UInteger = 0
            Public type As MaterialType = MaterialType.NOT_DEFINED
            Public texType As N64Codec = N64Codec.RGBA16
            Public collision As UShort = 0
            Public collisionp1 As Byte = 0
            Public collisionp2 As Byte = 0
            Public enableGeoMode As Boolean
            Public geoMode As UInteger = 0
            Public texture As TextureEntry = Nothing
            Public enableScrolling As Boolean = False
        End Class
        Private Class FinalVertexData
            Public Property Data As Byte() = New Byte(15) {}
            Public Property EnableVertexColor As Boolean = False
            Public ReadOnly Property EnableVertexAlpha As Boolean
                Get
                    Return Data.LastOrDefault() = &H0
                End Get
            End Property
            Public ReadOnly Property EnableVertexTransparent As Boolean
                Get
                    Dim lod As Byte = Data.LastOrDefault()
                    Return lod < &HFF AndAlso lod > &H0
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
        End Class
        Private Class f3d
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
            Public id As UInteger = 0
            Public offset As UInteger = 0
            Public width As UInteger = 0
            Public height As UInteger = 0
            Public data As Byte() = {}
            Public palette As Byte() = {}
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
        Private Class Import
            Public address As UInteger = 0
            Public curPos As UInteger = 0
            Public limit As UInteger = 0
            'C++ TO VB CONVERTER TODO TASK: VB does not have an equivalent for pointers to value types:
            'ORIGINAL LINE: Byte * data;
            Public data() As Byte = {}
        End Class
        Private Class PutData
            Public data As UInteger = 0
            Public address As UInteger = 0
        End Class
        Private Class TweakPatch
            Public address As UInteger = 0
            Public data As New List(Of Byte)
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

        Private importData As New List(Of Import)
        Private curImp As New Import
        Private setNextLimit As UInteger = 0

        Private verts As New List(Of Vertex)
        Private norms As New List(Of Normal)
        Private vertexColors As New List(Of VertexColor)
        Private uvs As New List(Of TexCord)
        Private materials As New List(Of Material)
        Private vertexGroups As New List(Of VertexGroupList)
        Private finalVertData As New List(Of FinalVertexData)
        Private textureBank As New List(Of TextureEntry)
        Private ptrs As New List(Of ObjPtrs)
        Private putImports As New List(Of PutData)
        Private tweaks As New List(Of TweakPatch)
        Private scrollTexts As New List(Of ScrollTex)

        Private currentMaterial As Material
        Private currentFace As Integer = 0
        Private lastPos As Integer = 0
        Private lastOffset As Integer = 0
        Private lastFVertPos As Integer = 0
        Private createSolidDL As Boolean = False
        Private createAlphaDL As Boolean = False
        Private createTransDL As Boolean = False
        Private definedSegPtr As Boolean = False
        Private lastN64Codec As MaterialType = MaterialType.NOT_DEFINED
        Private geoModeData As String = ""
        Private colorTexData As String = ""
        Private texTypeData As String = ""
        Private col_data As String = ""
        Private currentPreName As String = Nothing

        ' Tool Variables 
        Private collisionString As String
        Private romPos As UInteger = 0
        Private curSeg As Byte = 0
        Private startSegOffset As UInteger = 0
        Private curSegOffset As UInteger = 0
        Private verbose As Boolean = False
        Private flipTexturesVertically As Boolean = False
        Private centerVerts As Boolean = False
        Private resizeTextures As Boolean = False
        Private importDataSize As UInteger = 0
        Private reduceVertLevel As ReduceVericesLevel = ReduceVericesLevel.Level1
        Private modelScale As Single = 1.0F
        Private xOff As Int16 = 0
        Private yOff As Int16 = 0
        Private zOff As Int16 = 0
        Private enableFog As Boolean = False
        Private fogTyp As Model.FogPreset = Model.FogPreset.SubtleFog1
        Private fogRed As Byte = &HFF
        Private fogGreen As Byte = &HFF
        Private fogBlue As Byte = &HFF
        Private defaultColor() As Byte = {&HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &H7F, &H7F, &H7F, &HFF, &H7F, &H7F, &H7F, &HFF}
        Private settings As ConvertSettings = Nothing
        Private br As BinaryReader = Nothing
        Private bw As BinaryWriter = Nothing
        Private impstream As Stream = Nothing
        Private collisionPointer As UInteger = 0
        Private conRes As New ConvertResult
        Private conMode As ConvertingMode = Nothing
        Private ReadOnly ColtypesWithParams() As Byte = {14, 44, 36, 37, 39, 45}

        Private ReadOnly Property ImportCollision As Boolean
            Get
                Return conMode = ConvertingMode.Collision
            End Get
        End Property
        Private ReadOnly Property ImportModel As Boolean
            Get
                Return conMode = ConvertingMode.VisualMap
            End Get
        End Property
        Private ReadOnly Property CurSegAddress As UInteger
            Get
                Return CUInt(curSeg) << 24
            End Get
        End Property

        Private Function MAX(a, b) As Object
            Return If(a > b, a, b)
        End Function
        Private Function G_TX_DXT_FRAC() As Object
            Return 11
        End Function
        Private Function TXL2WORDS(txls, b_txl) As Object
            Return MAX(1, ((txls) * (b_txl) / 8))
        End Function
        Private Function CALC_DXT(width, b_txl) As Object
            Return ((1 << G_TX_DXT_FRAC()) / TXL2WORDS(width, b_txl)) '(((1 << G_TX_DXT_FRAC()) + TXL2WORDS(width, b_txl) - 1) / TXL2WORDS(width, b_txl))
        End Function
        Private Function TXL2WORDS_4b(txls) As Object
            Return MAX(1, ((txls) / 16))
        End Function
        Private Function CALC_DXT_4b(width) As Object
            Return ((1 << G_TX_DXT_FRAC()) / TXL2WORDS_4b(width)) '(((1 << G_TX_DXT_FRAC()) + TXL2WORDS_4b(width) - 1) / TXL2WORDS_4b(width))
        End Function
        Private Function SCALE_8_5(Val As Byte) As Byte
            Return ((((Val) + 4) * &H1F) / &HFF)
        End Function

        Private Sub setLightAndDarkValues(s As S3DFileParser.Shading)
            defaultColor(0) = s.Light.R
            defaultColor(1) = s.Light.G
            defaultColor(2) = s.Light.B
            defaultColor(3) = s.Light.A
            defaultColor(4) = s.Light.R
            defaultColor(5) = s.Light.G
            defaultColor(6) = s.Light.B
            defaultColor(7) = s.Light.A
            defaultColor(8) = s.Dark.R
            defaultColor(9) = s.Dark.G
            defaultColor(10) = s.Dark.B
            defaultColor(11) = s.Dark.A
            defaultColor(12) = s.Dark.R
            defaultColor(13) = s.Dark.G
            defaultColor(14) = s.Dark.B
            defaultColor(15) = s.Dark.A
        End Sub
        Private Sub resetVariables()
            vertexGroups.Clear()
            verts.Clear()
            norms.Clear()
            vertexColors.Clear()
            uvs.Clear()
            materials.Clear()
            finalVertData.Clear()
            currentFace = 0
            lastPos = 0
            lastOffset = 0
            lastN64Codec = MaterialType.NOT_DEFINED
        End Sub

        Private Sub checkGeoModeInfo(m As Material)
            m.geoMode = 0
            Dim gma() As String = geoModeData.Split(",")

            For Each gme As String In gma
                Dim gmd() As String = gme.Split(":")
                If m.Name.Equals(gmd(0)) Then
                    m.geoMode = gmd(1)
                    m.enableGeoMode = True
                    Return
                End If

            Next
        End Sub
        Private Sub checkColorTexInfo(m As Material)
            m.color = 0
            m.texColOffset = 0
            m.texColDark = 0.8F

            Dim gma() As String = colorTexData.Split(",")

            For Each gme As String In gma

                Dim gmd() As String = gme.Split(":")

                If m.Name.Equals(gmd(0)) Then

                    m.color = gmd(1)
                    m.enableTextureColor = True

                    If gmd.Count > 2 Then m.texColDark = Convert.ToDouble(gmd(2))

                    Return
                End If

            Next
        End Sub
        Private Sub processMaterialColor(str As String, mat As Material)
            Dim splitColor() As String = str.Replace(".", ",").Split(" ")
            Dim r As UInteger = Convert.ToSingle(splitColor(0)) * 255
            Dim g As UInteger = Convert.ToSingle(splitColor(1)) * 255
            Dim b As UInteger = Convert.ToSingle(splitColor(2)) * 255
            mat.color = r << 24 Or g << 16 Or b << 8 Or &HFF
        End Sub
        Private Sub processMaterialColorAlpha(alpha As Single, mat As Material)
            mat.color = mat.color And &HFFFFFF00UI
            mat.color = mat.color Or CByte((&HFF * alpha) And &HFF)
            mat.type = MaterialType.COLOR_TRANSPARENT
            If alpha < 1.0F Then
                mat.hasTransparency = True
            End If
        End Sub
        Private Sub checkN64CodecInfo(m As Material)
            Dim gma() As String = texTypeData.Split(",")

            For Each gme As String In gma
                Dim gmd() As String = gme.Split(":")

                If m.Name.Equals(gmd(0)) Then
                    Select Case gmd(1)
                        Case "rgba16"
                            m.texType = N64Codec.RGBA16
                        Case "rgba32"
                            m.texType = N64Codec.RGBA32
                        Case "ia4"
                            m.texType = N64Codec.IA4
                        Case "ia8"
                            m.texType = N64Codec.IA8
                        Case "ia16"
                            m.texType = N64Codec.IA16
                        Case "i4"
                            m.texType = N64Codec.I4
                            If gmd.Count > 2 AndAlso gmd(2) = "a" Then m.enableAlphaMask = True
                        Case "i8"
                            m.texType = N64Codec.I8
                            If gmd.Count > 2 AndAlso gmd(2) = "a" Then m.enableAlphaMask = True
                    End Select

                    Return
                End If

            Next

            m.texType = N64Codec.RGBA16
        End Sub

        Private Function checkForTextureCopy(mat As Material, cur As Byte()) As Boolean
            If textureBank.Count = 0 Then Return False

            For Each entry As TextureEntry In textureBank
                Dim pass As Boolean = False

                If entry.data.Count <> cur.Count Then Continue For

                For i As Integer = 0 To entry.data.Count - 1
                    If entry.data.Count <> cur.Count Then Exit For

                    If entry.data(i) <> cur(i) Then
                        pass = False
                        Exit For
                    End If

                    pass = True
                Next

                If pass Then
                    mat.offset = entry.offset
                    mat.texWidth = entry.width
                    mat.texHeight = entry.height
                    mat.size = 0
                    mat.texture = entry
                    mat.isTextureCopy = True
                    Return True
                End If

            Next

            Return False
        End Function

        Private Sub ProcessImage(img As Image, mat As Material)
            Dim data As Byte() = Nothing
            Dim palette As Byte() = Nothing

            'Load Texture from File
            Dim bmp As New Bitmap(img)

            'Convert texture
            N64Graphics.N64Graphics.Convert(data, palette, mat.texType, bmp)

            mat.texWidth = bmp.Width
            mat.texHeight = bmp.Height

            mat.type = MaterialType.TEXTURE_SOLID

            For y As Integer = 0 To bmp.Height - 1
                For x As Integer = 0 To bmp.Width - 1
                    Dim pix As Color = bmp.GetPixel(x, y)

                    Select Case mat.texType
                        Case N64Codec.RGBA16

                            If pix.A = 0 Then
                                mat.hasTextureAlpha = True
                                mat.type = MaterialType.TEXTURE_ALPHA
                                mat.hasTransparency = False
                            ElseIf pix.A < &HFF OrElse mat.opacity < &HFF Then
                                If mat.type <> MaterialType.TEXTURE_ALPHA Then
                                    If mat.opacity = &HFF Then
                                        mat.opacity = (CInt(mat.opacity) * pix.A) And &HFF
                                    End If
                                    mat.type = MaterialType.TEXTURE_TRANSPARENT
                                    mat.hasTransparency = True
                                End If
                            End If

                        Case N64Codec.RGBA32

                            If pix.A < &HFF OrElse mat.opacity < &HFF Then
                                If mat.opacity = &HFF Then mat.opacity *= (CInt(mat.opacity) * pix.A) And &HFF
                                mat.type = MaterialType.TEXTURE_TRANSPARENT
                                mat.hasTransparency = True
                            End If

                        Case N64Codec.I4, N64Codec.I8

                            If pix.A < &HFF OrElse mat.opacity < &HFF OrElse mat.enableAlphaMask Then
                                If mat.opacity = &HFF Then mat.opacity *= (CInt(mat.opacity) * pix.A) And &HFF
                                mat.type = MaterialType.TEXTURE_TRANSPARENT
                                mat.hasTransparency = True
                            End If

                        Case N64Codec.IA4, N64Codec.IA8, N64Codec.IA16

                            'Dim intensity As Byte = ((pix.R + pix.G + pix.B) \ 3)
                            'If Bits = 4 Then
                            '    intensity \= 32
                            '    alpha = If(pix.A < &HFF, 0, 1)
                            'ElseIf Bits = 8 Then
                            '    intensity \= 16
                            '    alpha \= 16
                            'End If

                            'If (alpha > 0 AndAlso alpha < &HFF) OrElse mat.opacity < &HFF Then
                            '    If mat.type <> MaterialType.TEXTURE_ALPHA Then
                            '        If mat.opacity = &HFF Then
                            '            mat.opacity *= (CInt(mat.opacity) * pix.A) And &HFF
                            '        End If
                            '        mat.type = MaterialType.TEXTURE_TRANSPARENT
                            '        mat.hasTransparency = True
                            '    End If
                            'ElseIf alpha = 0 Then
                            '    If mat.type <> MaterialType.TEXTURE_TRANSPARENT Then
                            '        mat.type = MaterialType.TEXTURE_ALPHA
                            '    End If
                            'End If

                            If pix.A = 0 Then
                                mat.hasTextureAlpha = True
                                mat.type = MaterialType.TEXTURE_ALPHA
                                mat.hasTransparency = False
                            ElseIf pix.A < &HFF OrElse mat.opacity < &HFF Then
                                If mat.type <> MaterialType.TEXTURE_ALPHA Then
                                    If mat.opacity = &HFF Then
                                        mat.opacity = (CInt(mat.opacity) * pix.A) And &HFF
                                    End If
                                    mat.type = MaterialType.TEXTURE_TRANSPARENT
                                    mat.hasTransparency = True
                                End If
                            End If

                    End Select
                Next
            Next

            Dim entry As TextureEntry = Nothing
            If Not checkForTextureCopy(mat, data) Then
                entry = New TextureEntry With {
                    .offset = lastOffset,
                    .data = data,
                    .palette = If(palette, New Byte() {}),
                    .width = bmp.Width,
                    .height = bmp.Height,
                    .id = textureBank.Count
                }
                textureBank.Add(entry)
                mat.texture = entry
            End If

            mat.hasTexture = True
        End Sub

        Private Sub addMaterialPosition(str As String)
            For Each m In materials
                If m.Name = str Then
                    Dim mp As New VertexGroupList With {
                        .Position = currentFace,
                        .Material = m
                    }
                    currentMaterial = m
                    mp.Length = 0
                    vertexGroups.Add(mp)
                    lastPos = currentFace
                    Return
                End If

            Next
        End Sub

        Private Sub processObject3DModel(obj As S3DFileParser.Object3D, texFormatSettings As TextureFormatSettings)
            'Process Materials
            lastOffset = curSegOffset
            Dim size As Integer = 0
            For Each kvp In obj.Materials
                Dim curEntry As TextureFormatSettings.Entry = texFormatSettings.GetEntry(kvp.Key)
                Dim m As New Material With {
                    .type = MaterialType.COLOR_SOLID,
                    .color = 0,
                    .hasTexture = False,
                    .hasTextureAlpha = False,
                    .hasTransparency = False,
                    .isTextureCopy = False,
                    .Name = kvp.Key,
                    .collision = 0,
                    .opacity = &HFF,
                    .opacityOrg = &HFF,
                    .enableGeoMode = False,
                    .enableTextureColor = False,
                    .enableAlphaMask = False,
                    .cameFromBMP = False,
                    .enableScrolling = curEntry.IsScrollingTexture
                    }

                'Set default size
                size = &H10

                'Check some things
                checkGeoModeInfo(m)
                checkColorTexInfo(m)

                'Add material
                materials.Add(m)

                If ImportModel Then
                    'Process Material Color
                    If Not m.enableTextureColor Then
                        Dim r As UInteger = kvp.Value.Color.Value.R * 255
                        Dim g As UInteger = kvp.Value.Color.Value.G * 255
                        Dim b As UInteger = kvp.Value.Color.Value.B * 255
                        m.color = r << 24 Or g << 16 Or b << 8 Or &HFF
                    End If

                    'Process Material Color Alpha
                    If kvp.Value.Opacity IsNot Nothing Then
                        Dim tempopacity As Single = kvp.Value.Opacity
                        With m
                            .opacity = (tempopacity * &HFF) And &HFF
                            .opacityOrg = .opacity
                        End With
                        processMaterialColorAlpha(tempopacity, m)
                    End If

                    'Check Texture Type
                    If texFormatSettings IsNot Nothing Then
                        m.texType = N64Graphics.N64Graphics.StringCodec(texFormatSettings.GetEntry(kvp.Key).TextureFormat)
                    End If

                    'Process Material Image
                    If kvp.Value.Image IsNot Nothing Then
                        ProcessImage(kvp.Value.Image, m)
                        size = m.texture.data.Length
                    End If
                End If

                'Set offset and size
                If Not m.isTextureCopy Then
                    m.offset = lastOffset
                    m.size = size
                    lastOffset += size
                    If m.texture?.palette IsNot Nothing Then
                        m.paletteSize = m.texture.palette.Length
                        lastOffset += m.paletteSize
                    End If
                End If
                If m.enableTextureColor Then
                    lastOffset += &H10
                End If
            Next

            For Each mesh As S3DFileParser.Mesh In obj.Meshes
                Dim curIndexStart As Integer = verts.Count

                'Process Vertices
                For Each vert In mesh.Vertices
                    Dim v As New Vertex With {
                        .X = LongToInt16(Round((vert.X * modelScale) + xOff)),
                        .Y = LongToInt16(Round((vert.Y * modelScale) + yOff)),
                        .Z = LongToInt16(Round((vert.Z * modelScale) + zOff))
                    }
                    verts.Add(v)
                Next

                If ImportModel Then
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
                    For Each tuv As S3DFileParser.UV In mesh.UVs
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
                End If

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
                        lastPos = currentFace
                    End If

                    If ImportModel Then
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
                        With face.Points(0)
                            If .Vertex IsNot Nothing Then va = verts(curIndexStart + mesh.Vertices.IndexOf(.Vertex))
                            If .UV IsNot Nothing Then ta = uvs(curIndexStart + mesh.UVs.IndexOf(.UV))
                            If .Normal IsNot Nothing Then na = norms(curIndexStart + mesh.Normals.IndexOf(.Normal))
                            If .VertexColor IsNot Nothing Then vca = vertexColors(curIndexStart + mesh.VertexColors.IndexOf(.VertexColor))
                        End With

                        Dim vb As Vertex = Nothing
                        Dim tb As TexCord = Nothing
                        Dim tbnew As New TexCord
                        Dim nb As Normal = Nothing
                        Dim vcb As VertexColor = Nothing
                        With face.Points(1)
                            If .Vertex IsNot Nothing Then vb = verts(curIndexStart + mesh.Vertices.IndexOf(.Vertex))
                            If .UV IsNot Nothing Then tb = uvs(curIndexStart + mesh.UVs.IndexOf(.UV))
                            If .Normal IsNot Nothing Then nb = norms(curIndexStart + mesh.Normals.IndexOf(.Normal))
                            If .VertexColor IsNot Nothing Then vcb = vertexColors(curIndexStart + mesh.VertexColors.IndexOf(.VertexColor))
                        End With

                        Dim vc As Vertex = Nothing
                        Dim tc As TexCord = Nothing
                        Dim tcnew As New TexCord
                        Dim nc As Normal = Nothing
                        Dim vcc As VertexColor = Nothing
                        With face.Points(2)
                            If .Vertex IsNot Nothing Then vc = verts(curIndexStart + mesh.Vertices.IndexOf(.Vertex))
                            If .UV IsNot Nothing Then tc = uvs(curIndexStart + mesh.UVs.IndexOf(.UV))
                            If .Normal IsNot Nothing Then nc = norms(curIndexStart + mesh.Normals.IndexOf(.Normal))
                            If .VertexColor IsNot Nothing Then vcc = vertexColors(curIndexStart + mesh.VertexColors.IndexOf(.VertexColor))
                        End With

                        Dim fa As New FinalVertexData
                        Dim fb As New FinalVertexData
                        Dim fc As New FinalVertexData

                        ' Modify UV cordinates based on material.
                        tanew.U = ta.U * CSng(mat.texWidth / 32.0)
                        tanew.V = ta.V * CSng(mat.texHeight / 32.0)
                        tbnew.U = tb.U * CSng(mat.texWidth / 32.0)
                        tbnew.V = tb.V * CSng(mat.texHeight / 32.0)
                        tcnew.U = tc.U * CSng(mat.texWidth / 32.0)
                        tcnew.V = tc.V * CSng(mat.texHeight / 32.0)

                        FixUVs(tanew, tbnew, tcnew, mat.texWidth, mat.texHeight)

                        ' Vertex Structure: xxxxyyyyzzzz0000uuuuvvvvrrggbbaa
                        fa.Data(0) = (va.X >> 8) And &HFF
                        fa.Data(1) = va.X And &HFF
                        fa.Data(2) = (va.Y >> 8) And &HFF
                        fa.Data(3) = va.Y And &HFF
                        fa.Data(4) = (va.Z >> 8) And &HFF
                        fa.Data(5) = va.Z And &HFF
                        fa.Data(6) = 0
                        fa.Data(7) = 0
                        fa.Data(8) = (tanew.U >> 8) And &HFF
                        fa.Data(9) = tanew.U And &HFF
                        fa.Data(10) = (tanew.V >> 8) And &HFF
                        fa.Data(11) = tanew.V And &HFF
                        If vca IsNot Nothing Then
                            fa.Data(12) = vca.R
                            fa.Data(13) = vca.G
                            fa.Data(14) = vca.B
                            fa.Data(15) = vca.A
                            fa.EnableVertexColor = True
                        Else
                            fa.Data(12) = na.A
                            fa.Data(13) = na.B
                            fa.Data(14) = na.C
                            fa.Data(15) = na.D
                            fa.EnableVertexColor = False
                        End If

                        fb.Data(0) = (vb.X >> 8) And &HFF
                        fb.Data(1) = vb.X And &HFF
                        fb.Data(2) = (vb.Y >> 8) And &HFF
                        fb.Data(3) = vb.Y And &HFF
                        fb.Data(4) = (vb.Z >> 8) And &HFF
                        fb.Data(5) = vb.Z And &HFF
                        fb.Data(6) = 0
                        fb.Data(7) = 0
                        fb.Data(8) = (tbnew.U >> 8) And &HFF
                        fb.Data(9) = tbnew.U And &HFF
                        fb.Data(10) = (tbnew.V >> 8) And &HFF
                        fb.Data(11) = tbnew.V And &HFF
                        If vcb IsNot Nothing Then
                            fb.Data(12) = vcb.R
                            fb.Data(13) = vcb.G
                            fb.Data(14) = vcb.B
                            fb.Data(15) = vcb.A
                            fb.EnableVertexColor = True
                        Else
                            fb.Data(12) = nb.A
                            fb.Data(13) = nb.B
                            fb.Data(14) = nb.C
                            fb.Data(15) = nb.D
                            fb.EnableVertexColor = False
                        End If

                        fc.Data(0) = (vc.X >> 8) And &HFF
                        fc.Data(1) = vc.X And &HFF
                        fc.Data(2) = (vc.Y >> 8) And &HFF
                        fc.Data(3) = vc.Y And &HFF
                        fc.Data(4) = (vc.Z >> 8) And &HFF
                        fc.Data(5) = vc.Z And &HFF
                        fc.Data(6) = 0
                        fc.Data(7) = 0
                        fc.Data(8) = (tcnew.U >> 8) And &HFF
                        fc.Data(9) = tcnew.U And &HFF
                        fc.Data(10) = (tcnew.V >> 8) And &HFF
                        fc.Data(11) = tcnew.V And &HFF
                        If vcc IsNot Nothing Then
                            fc.Data(12) = vcc.R
                            fc.Data(13) = vcc.G
                            fc.Data(14) = vcc.B
                            fc.Data(15) = vcc.A
                            fc.EnableVertexColor = True
                        Else
                            fc.Data(12) = nc.A
                            fc.Data(13) = nc.B
                            fc.Data(14) = nc.C
                            fc.Data(15) = nc.D
                            fc.EnableVertexColor = False
                        End If

                        finalVertData.AddRange({fa, fb, fc})
                    End If

                    currentFace += 1
                Next
            Next
        End Sub

        Private Sub FixUVs(uv1 As TexCord, uv2 As TexCord, uv3 As TexCord, matWidth As Integer, matHeight As Integer)
            If matWidth <= 0 OrElse matHeight <= 0 Then Return

            Dim uvs As TexCord() = Nothing
            Dim temp As Integer = 0
            Dim jump As Integer = 0

            jump = matWidth * &H40
            uvs = ({uv1, uv2, uv3}).OrderBy(Function(n) n.U).ToArray

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
            uvs = ({uv1, uv2, uv3}).OrderBy(Function(n) n.V).ToArray

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
                                updateIndexList(fvg, j, i)
                                updatePositions(mp.StartIndex)
                                dupCnt += 1
                            End If
                            j += 1
                        Loop
                    Next

                    If g < mp.GroupsCount - 1 AndAlso level > 1 Then
                        If moveVertsBack(mp.FinalVertexGroups(g), mp.FinalVertexGroups(g + 1)) Then
                            g -= 1
                        End If
                    End If
                Next

            Next
        End Sub
        Private Sub updateIndexList(grp As FvGroup, removed As Byte, replaceWith As Byte)
            For i As Integer = 0 To grp.NumTri * 3 - 1
                If grp.indexList(i) < removed Then Continue For
                If grp.indexList(i) = removed Then
                    grp.indexList(i) = replaceWith
                Else
                    grp.indexList(i) -= 1
                End If
            Next
        End Sub
        Private Sub updatePositions(vs As Integer)
            For Each mp As VertexGroupList In vertexGroups
                If mp.StartIndex <= vs Then Continue For
                If mp.StartIndex < &H10 Then Continue For
                mp.StartIndex -= &H10
            Next
        End Sub
        Private Function moveVertsBack([to] As FvGroup, from As FvGroup) As Boolean
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

        Private Sub makeVertexGroupsAndBuildDisplayLists()
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

        Private Function strF3D(str As String) As f3d
            Dim cmd As New f3d

            Dim b = str.Replace(".", ",").Split(" ")
            For i As Integer = 0 To b.Count - 1
                cmd.data(i) = CByte($"&H{b(i)}")
            Next

            Return cmd
        End Function

        Private Sub fillColorData(ByRef colorData() As Byte, mt As Material, ByRef darkMult As Single)
            Dim lr, lg, lb, a As Byte
            Dim dr, dg, db As UShort
            lr = (mt.color >> 24) And &HFF
            lg = (mt.color >> 16) And &HFF
            lb = (mt.color >> 8) And &HFF
            dr = lr * darkMult
            dg = lg * darkMult
            db = lb * darkMult
            If dr > &HFF Then dr = &HFF
            If dg > &HFF Then dg = &HFF
            If db > &HFF Then db = &HFF
            a = mt.color And &HFF
            colorData(0) = lr
            colorData(1) = lg
            colorData(2) = lb
            colorData(3) = a
            colorData(4) = lr
            colorData(5) = lg
            colorData(6) = lb
            colorData(7) = a
            colorData(8) = dr
            colorData(9) = dg
            colorData(10) = db
            colorData(11) = a
            colorData(12) = dr
            colorData(13) = dg
            colorData(14) = db
            colorData(15) = a
        End Sub

        Private Sub addFogStart(ByRef cmds As List(Of f3d), alpha As Boolean)
            cmds.Add(strF3D("BA 00 14 02 00 10 00 00"))

            Dim cmdF8 As String = ""
            cmdF8 = $"F8 00 00 00 {fogRed} {fogGreen} {fogBlue} FF"
            cmds.Add(strF3D(cmdF8))

            If alpha Then ' If texture has any alpha bits
                cmds.Add(strF3D("B9 00 03 1D C8 11 30 78"))
            Else ' solid texture
                cmds.Add(strF3D("B9 00 03 1D C8 11 20 78"))
            End If

            Select Case fogTyp
                Case Model.FogPreset.SubtleFog1
                    cmds.Add(strF3D("BC 00 00 08 19 00 E8 00"))
                Case Model.FogPreset.SubtleFog2
                    cmds.Add(strF3D("BC 00 00 08 12 00 F0 00"))
                Case Model.FogPreset.ModerateFog1
                    cmds.Add(strF3D("BC 00 00 08 0E 49 F2 B7"))
                Case Model.FogPreset.ModerateFog2
                    cmds.Add(strF3D("BC 00 00 08 0C 80 F4 80"))
                Case Model.FogPreset.ModerateFog3
                    cmds.Add(strF3D("BC 00 00 08 0A 00 F7 00"))
                Case Model.FogPreset.ModerateFog4
                    cmds.Add(strF3D("BC 00 00 08 08 55 F8 AB"))
                Case Model.FogPreset.IntenseFog
                    cmds.Add(strF3D("BC 00 00 08 07 24 F9 DC"))
                Case Model.FogPreset.VeryIntenseFog
                    cmds.Add(strF3D("BC 00 00 08 05 00 FC 00"))
                Case Model.FogPreset.HardcoreFog
                    cmds.Add(strF3D("BC 00 00 08 02 50 FF 00"))
            End Select

            cmds.Add(strF3D("B7 00 00 00 00 01 00 00"))
        End Sub
        Private Sub addFogEnd(ByRef cmds As List(Of f3d))
            cmds.Add(strF3D("BA 00 14 02 00 00 00 00"))
            cmds.Add(strF3D("B9 00 03 1D 00 44 30 78"))
            cmds.Add(strF3D("B6 00 00 00 00 01 00 00")) 'B6 00 00 00 00 01 02 00 --> Smoothen Shading?
        End Sub

        Private Function getTypeFromMaterial(mat As Material) As Byte
            Select Case mat.texType
                Case N64Codec.I4
                    Return &H80
                Case N64Codec.I8
                    Return &H88
                Case N64Codec.IA4
                    Return &H60
                Case N64Codec.IA8
                    Return &H68
                Case N64Codec.IA16
                    Return &H70
                Case N64Codec.RGBA32
                    Return &H18
                Case Else
                    Return &H10 ' RGBA16
            End Select
        End Function

        Private Function bytesPerType(type As N64Codec) As Byte
            Select Case type
                Case N64Codec.RGBA32
                    Return 4
                Case N64Codec.I4, N64Codec.IA4
                    Return 0 ' Special case
                Case N64Codec.IA8, N64Codec.I8
                    Return 1
                Case Else
                    Return 2
            End Select
        End Function

        Private Function getTexelIncrement(type As N64Codec) As Byte
            Select Case type
                Case N64Codec.I4, N64Codec.IA4
                    Return 3
                Case N64Codec.IA8, N64Codec.I8
                    Return 1
                Case Else
                    Return 0
            End Select
        End Function
        Private Function getTexelShift(type As N64Codec) As Byte
            Select Case type
                Case N64Codec.I4, N64Codec.IA4
                    Return 2
                Case N64Codec.IA8, N64Codec.I8
                    Return 1
                Case Else
                    Return 0
            End Select
        End Function

        Private Sub addCmdFD(ByRef cmds As List(Of f3d), mat As Material)
            If mat.hasTexture Then
                Dim off As UInteger = startSegOffset + mat.offset + &H10
                Dim cmd As String = ""
                Dim type As Byte = getTypeFromMaterial(mat)
                If mat.texType = N64Codec.I4 Then
                    type = &H90
                ElseIf mat.texType = N64Codec.IA4 OrElse mat.texType = N64Codec.IA8 Then
                    type = &H70
                End If
                cmd = $"FD {Hex(type)} 00 00 {Hex(curSeg And &HFF)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"
                cmds.Add(strF3D(cmd))

                If mat.texture.palette.Length > 0 Then
                    off += mat.size
                    cmd = $"FD 50 00 00 {Hex(curSeg And &HFF)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"
                    cmds.Add(strF3D(cmd))
                End If
            End If
        End Sub

        Private Sub addCmdF5(ByRef cmds As List(Of f3d), mat As Material, first As Boolean)
            Dim type As Byte = getTypeFromMaterial(mat)
            Dim cmd As String = ""
            If first Then
                If mat.hasTexture Then
                    If mat.texType = N64Codec.I4 Then
                        type = &H90
                    ElseIf mat.texType = N64Codec.IA4 OrElse mat.texType = N64Codec.IA8 Then
                        type = &H70
                    End If
                    cmd = $"F5 {Hex(type)} 00 00 07 00 00 00"
                    cmds.Add(strF3D(cmd))
                End If
            Else
                If mat.hasTexture Then
                    Dim lineScale As Single = 1.0F
                    Dim bpt As Byte = bytesPerType(mat.texType)
                    If bpt <> 0 Then
                        lineScale = bpt / 4.0
                    Else
                        lineScale = 0.125F
                    End If
                    If mat.texType = N64Codec.RGBA32 Then
                        lineScale /= 2
                    End If
                    Dim line As UShort = CUShort(Math.Truncate(mat.texWidth * lineScale)) And &H1FF
                    Dim upper As UInteger = ((CUInt(type) << 16) Or (CUInt(line) << 8)) And &HFFFFFF
                    Dim maskS As Byte = Math.Ceiling(Math.Log(mat.texWidth, 2)) And &HF
                    Dim maskT As Byte = Math.Ceiling(Math.Log(mat.texHeight, 2)) And &HF
                    Dim lower As UInteger = ((CUInt(maskT) << 14) Or (CUInt(maskS) << 4)) And &HFFFFFF
                    cmd = $"F5 {Hex((upper >> 16) And &HFF)} {Hex((upper >> 8) And &HFF)} {Hex(upper And &HFF)} 00 {Hex((lower >> 16) And &HFF)} {Hex((lower >> 8) And &HFF)} {Hex(lower And &HFF)}"
                    cmds.Add(strF3D(cmd))
                End If
            End If
        End Sub

        Private Sub addCmdF3(ByRef cmds As List(Of f3d), mat As Material)
            Dim numTexels As UInteger = ((mat.texWidth * mat.texHeight + getTexelIncrement(mat.texType)) >> getTexelShift(mat.texType)) - 1
            Dim bpt As Integer = bytesPerType(mat.texType)
            Dim tl As UInteger

            If bpt <> 0 Then
                tl = CALC_DXT(mat.texWidth, bpt) And &HFFF
            Else
                tl = CALC_DXT_4b(mat.texWidth) And &HFFF
            End If

            Dim lower As UInteger = ((numTexels << 12) Or tl) And &HFFFFFF

            Dim cmd As String = $"F3 00 00 00 07 {Hex((lower >> 16) And &HFF)} {Hex((lower >> 8) And &HFF)} {Hex(lower And &HFF)}"
            cmds.Add(strF3D(cmd))
        End Sub

        Private Sub addCmdF2(ByRef cmds As List(Of f3d), mat As Material)
            Dim width As UShort = ((mat.texWidth - 1) << 2) And &HFFF
            Dim height As UShort = ((mat.texHeight - 1) << 2) And &HFFF
            Dim data As UInteger = (CInt(width) << 12) Or height
            Dim cmd As String = ""
            cmd = $"F2 00 00 00 00 {Hex((data >> 16) And &HFF)} {Hex((data >> 8) And &HFF)} {Hex(data And &HFF)}"
            cmds.Add(strF3D(cmd))
        End Sub

        Private Sub addCmdFC(ByRef cmds As List(Of f3d), ByVal mat As Material)
            If mat.hasTexture Then
                If mat.texType = N64Codec.RGBA32 Then
                    cmds.Add(strF3D("FC 11 96 23 FF 2F FF FF"))
                ElseIf mat.texType = N64Codec.IA4 OrElse mat.texType = N64Codec.IA8 OrElse mat.texType = N64Codec.IA16 Then
                    cmds.Add(strF3D("FC 12 18 24 FF 33 FF FF")) 'cmds.Add(strF3D("FC 12 9A 25 FF 37 FF FF"))
                ElseIf mat.texType = N64Codec.I4 OrElse mat.texType = N64Codec.I8 Then
                    If mat.enableAlphaMask Then
                        cmds.Add(strF3D("FC 12 7E A0 FF FF F3 F8"))
                    Else
                        cmds.Add(strF3D("FC 30 B2 61 FF FF FF FF"))
                    End If
                ElseIf mat.hasTransparency Then 'mat.type = MaterialType.TEXTURE_TRANSPARENT
                    cmds.Add(strF3D("FC 12 2E 24 FF FF FB FD"))
                ElseIf mat.hasTextureAlpha Then
                    If enableFog Then
                        cmds.Add(strF3D("FC FF FF FF FF FC F2 38"))
                    Else
                        cmds.Add(strF3D("FC 12 18 24 FF 33 FF FF"))
                    End If
                Else
                    If enableFog Then
                        cmds.Add(strF3D("FC 12 7F FF FF FF F8 38"))
                    Else
                        cmds.Add(strF3D("FC 12 7E 24 FF FF F9 FC"))
                    End If
                End If
            Else
                If mat.type = MaterialType.COLOR_TRANSPARENT Then
                    cmds.Add(strF3D("FC FF FF FF FF FE FB FD"))
                Else
                    cmds.Add(strF3D("FC FF FF FF FF FE 7B 3D"))
                End If
            End If
        End Sub

        Private Sub addCmd03(ByRef cmds As List(Of f3d), mat As Material, addOffset As UInteger)
            If mat.type = MaterialType.COLOR_SOLID Then
                Dim off As UInteger = startSegOffset + mat.offset + &H10
                cmds.Add(strF3D($"03 86 00 10 {Hex(curSeg)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"))
                off = startSegOffset + mat.offset + &H18
                cmds.Add(strF3D($"03 88 00 10 {Hex(curSeg)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"))
            Else
                Dim off As UInteger = startSegOffset
                If mat.enableTextureColor Then off = startSegOffset + addOffset + mat.texColOffset
                cmds.Add(strF3D($"03 86 00 10 {Hex(curSeg)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"))
                off = startSegOffset + 8
                If mat.enableTextureColor Then off = startSegOffset + addOffset + mat.texColOffset + &H8
                cmds.Add(strF3D($"03 88 00 10 {Hex(curSeg)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"))
            End If
        End Sub

        Private Sub addTriCmds(ByRef cmds As List(Of f3d), mat As Material, grp As FvGroup, offset As Integer, ByRef enabledVertexColors As Boolean)
            If grp.VertexDataCount < 3 Then Return

            Dim off As UInteger = startSegOffset + offset
            Dim amount As Integer = grp.VertexDataCount * &H10

            If mat.enableScrolling Then
                AddScrollingTexture(grp, off, mat.offset)
            End If

            If grp.EnableVertexColors Then
                If Not enabledVertexColors Then
                    cmds.Add(strF3D("B6 00 00 00 00 02 00 00"))
                    enabledVertexColors = True
                End If
            Else
                If enabledVertexColors Then
                    cmds.Add(strF3D("B7 00 00 00 00 02 00 00"))
                    enabledVertexColors = False
                End If
            End If

            cmds.Add(strF3D($"04 {Hex((amount - &H10) And &HFF)} 00 {Hex(amount And &HFF)} {Hex(curSeg)} {Hex((off >> 16) And &HFF)} {Hex((off >> 8) And &HFF)} {Hex(off And &HFF)}"))

            For i As Integer = 0 To grp.NumTri - 1
                Dim a As Byte = grp.indexList(i * 3) * &HA
                Dim b As Byte = grp.indexList(i * 3 + 1) * &HA
                Dim c As Byte = grp.indexList(i * 3 + 2) * &HA

                cmds.Add(strF3D($"BF 00 00 00 00 {Hex(a)} {Hex(b)} {Hex(c)}"))
            Next

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

        Private Sub addColorCmdFB(ByRef cmds As List(Of f3d), mat As Material)
            Dim r As Byte = (mat.color >> 24) And &HFF
            Dim g As Byte = (mat.color >> 16) And &HFF
            Dim b As Byte = (mat.color >> 8) And &HFF
            cmds.Add(strF3D($"FB 00 00 00 {Hex(r)} {Hex(g)} {Hex(b)} {Hex(mat.opacity)}"))
        End Sub

        Private Sub memcpy(data() As Byte, location As UInteger)
            impstream.Position = location
            bw.Write(data, 0, data.Count)
        End Sub

        Private Sub importOBJ(model As S3DFileParser.Object3D, texFormatSettings As TextureFormatSettings)
            Dim startVerts As Integer = 0
            Dim importStart As Integer = 0

            processObject3DModel(model, texFormatSettings)
            makeVertexGroupsAndBuildDisplayLists()

            removeDuplicateVertices(reduceVertLevel)

            If curSegOffset Mod 8 <> 0 Then curSegOffset += 8 - (curSegOffset Mod 8)
            conRes.PtrStart = CurSegAddress Or curSegOffset
            importStart = romPos + curSegOffset
            curSegOffset += &H10

            For Each mt As Material In materials
                If Not mt.isTextureCopy Then curSegOffset += mt.size + mt.paletteSize
                If mt.enableTextureColor Then
                    mt.texColOffset = curSegOffset
                    curSegOffset += 10
                End If
            Next

            startVerts = curSegOffset
            conRes.PtrVertex = CurSegAddress Or curSegOffset

            For Each mp As VertexGroupList In vertexGroups
                For g As Integer = 0 To mp.GroupsCount - 1
                    If mp.FinalVertexGroups(g).VertexDataCount < 1 Then Continue For
                    curSegOffset += mp.FinalVertexGroups(g).VertexDataCount * &H10
                Next
            Next

            'Check if Solid DL is requied
            For Each m As Material In materials
                If Not m.hasTransparency Then
                    createSolidDL = True
                End If
            Next

            'Check which DLs should be created
            For Each mat As Material In materials
                If mat.hasTransparency Then
                    createTransDL = True
                ElseIf mat.hasTextureAlpha Then
                    createAlphaDL = True
                Else
                    createSolidDL = True
                End If
            Next

            ''Check if for Vertex Color Alpha Trans
            'For Each fv As FinalVertexData In finalVertData
            '    If fv.EnableVertexAlpha Then
            '        createAlphaDL = True
            '    ElseIf fv.EnableVertexTransparent Then
            '        createTransDL = True
            '    Else
            '        createSolidDL = True
            '    End If
            'Next

            'Check for forced DL-Type
            Dim enableForcing As Boolean = settings.ForceDisplaylist <> -1
            If enableForcing Then
                createSolidDL = createSolidDL AndAlso (settings.ForceDisplaylist = Geolayout.Geolayer.Solid)
                createAlphaDL = createAlphaDL AndAlso (settings.ForceDisplaylist = Geolayout.Geolayer.Alpha)
                createTransDL = createTransDL AndAlso (settings.ForceDisplaylist = Geolayout.Geolayer.Transparent)
            End If

            Dim solidCmds As New List(Of f3d)
            Dim alphaCmds As New List(Of f3d)
            Dim transCmds As New List(Of f3d)
            Dim enabledVertexColors As Boolean

            'Create Solid DL
            If createSolidDL Then
                enabledVertexColors = False
                conRes.PtrSolid = CurSegAddress Or curSegOffset
                solidCmds.Add(strF3D("E7 00 00 00 00 00 00 00"))
                solidCmds.Add(strF3D("B7 00 00 00 00 00 00 00"))
                solidCmds.Add(strF3D("BB 00 00 01 FF FF FF FF"))
                solidCmds.Add(strF3D("E8 00 00 00 00 00 00 00"))
                solidCmds.Add(strF3D("E6 00 00 00 00 00 00 00"))
                If enableFog Then addFogStart(solidCmds, False)

                For i As Integer = 0 To vertexGroups.Count - 1
                    Dim mp As VertexGroupList = vertexGroups(i)
                    If (mp.Material.hasTextureAlpha OrElse mp.Material.hasTransparency) AndAlso Not enableForcing Then Continue For
                    If mp.Material.enableGeoMode Then
                        solidCmds.Add(strF3D("B6 00 00 00 FF FF FF FF"))
                        solidCmds.Add(strF3D($"B7 00 00 00 {Hex((mp.Material.geoMode >> 24) And &HFF)} {Hex((mp.Material.geoMode >> 16) And &HFF)} {Hex((mp.Material.geoMode >> 8) And &HFF)} {Hex(mp.Material.geoMode And &HFF)}"))
                    End If
                    If mp.Material.hasTexture Then
                        addCmdFD(solidCmds, mp.Material)
                        addCmdF5(solidCmds, mp.Material, True)
                        solidCmds.Add(strF3D("E6 00 00 00 00 00 00 00"))
                        addCmdF3(solidCmds, mp.Material)
                        solidCmds.Add(strF3D("E7 00 00 00 00 00 00 00"))
                        addCmdF5(solidCmds, mp.Material, False)
                        addCmdF2(solidCmds, mp.Material)
                    End If
                    If lastN64Codec <> mp.Material.type Then
                        addCmdFC(solidCmds, mp.Material)
                        addCmd03(solidCmds, mp.Material, importStart - romPos)
                        lastN64Codec = mp.Material.type
                    Else
                        If i > 0 Then
                            If vertexGroups(i - 1).Material.enableTextureColor AndAlso mp.Material.enableTextureColor Then
                                If vertexGroups(i - 1).Material.color <> mp.Material.color Then addCmd03(solidCmds, mp.Material, importStart - romPos)
                            ElseIf mp.Material.enableTextureColor Then
                                addCmd03(solidCmds, mp.Material, importStart - romPos)
                            End If
                        End If
                        If lastN64Codec = MaterialType.COLOR_SOLID AndAlso mp.Material.type = MaterialType.COLOR_SOLID Then
                            addCmd03(solidCmds, mp.Material, importStart - romPos)
                        End If
                    End If

                    Dim grpOff As Integer = 0
                    For ii As Integer = 0 To mp.GroupsCount - 1
                        addTriCmds(solidCmds, mp.Material, mp.FinalVertexGroups(ii), startVerts + (mp.StartIndex + grpOff), enabledVertexColors)
                        grpOff += mp.FinalVertexGroups(ii).VertexDataCount * &H10
                    Next

                    If mp.Material.enableGeoMode Then
                        If i + 1 < vertexGroups.Count AndAlso vertexGroups(i + 1).Material.enableGeoMode Then Continue For
                        solidCmds.Add(strF3D("B6 00 00 00 FF FF FF FF"))
                        solidCmds.Add(strF3D("B7 00 00 00 00 02 20 05"))
                    End If


                Next

                If enabledVertexColors Then solidCmds.Add(strF3D("B7 00 00 00 00 02 00 00"))
                If enableFog Then addFogEnd(solidCmds)
                solidCmds.Add(strF3D("BB 00 00 00 FF FF FF FF"))
                solidCmds.Add(strF3D("B8 00 00 00 00 00 00 00"))

                curSegOffset += solidCmds.Count * 8
                MergeScrollingTextures()
            End If

            'Create Alpha DL
            If createAlphaDL Then
                enabledVertexColors = False
                conRes.PtrAlpha = CurSegAddress Or curSegOffset

                alphaCmds.Add(strF3D("E7 00 00 00 00 00 00 00"))
                If enableFog Then alphaCmds.Add(strF3D("B9 00 02 01 00 00 00 00"))
                alphaCmds.Add(strF3D("B7 00 00 00 00 00 00 00"))
                alphaCmds.Add(strF3D("BB 00 00 01 FF FF FF FF"))
                alphaCmds.Add(strF3D("E8 00 00 00 00 00 00 00"))
                alphaCmds.Add(strF3D("E6 00 00 00 00 00 00 00"))
                If enableFog Then addFogStart(alphaCmds, True)

                For i As Integer = 0 To vertexGroups.Count - 1
                    Dim mp As VertexGroupList = vertexGroups(i)
                    If (Not mp.Material.hasTextureAlpha OrElse mp.Material.hasTransparency OrElse mp.EnableVertexAlpha) AndAlso Not enableForcing Then Continue For
                    If mp.Material.enableGeoMode Then
                        alphaCmds.Add(strF3D("B6 00 00 00 FF FF FF FF"))
                        alphaCmds.Add(strF3D($"B7 00 00 00 {Hex((mp.Material.geoMode >> 24) And &HFF)} {Hex((mp.Material.geoMode >> 16) And &HFF)} {Hex((mp.Material.geoMode >> 8) And &HFF)} {Hex(mp.Material.geoMode And &HFF)}"))
                    End If
                    If lastN64Codec <> mp.Material.type Then
                        addCmdFC(alphaCmds, mp.Material)
                        addCmd03(alphaCmds, mp.Material, importStart - romPos)
                        lastN64Codec = mp.Material.type
                    End If
                    If mp.Material.hasTexture Then
                        addCmdFD(alphaCmds, mp.Material)
                        addCmdF5(alphaCmds, mp.Material, True)
                        alphaCmds.Add(strF3D("E6 00 00 00 00 00 00 00"))
                        addCmdF3(alphaCmds, mp.Material)
                        alphaCmds.Add(strF3D("E7 00 00 00 00 00 00 00"))
                        addCmdF5(alphaCmds, mp.Material, False)
                        addCmdF2(alphaCmds, mp.Material)
                    End If
                    Dim grpOff As Integer = 0
                    For ii As Integer = 0 To mp.GroupsCount - 1
                        addTriCmds(alphaCmds, mp.Material, mp.FinalVertexGroups(ii), startVerts + (mp.StartIndex + grpOff), enabledVertexColors)
                        grpOff += mp.FinalVertexGroups(ii).VertexDataCount * &H10
                    Next
                    If mp.Material.enableGeoMode Then
                        alphaCmds.Add(strF3D("B6 00 00 00 FF FF FF FF"))
                        alphaCmds.Add(strF3D("B7 00 00 00 00 02 20 05"))
                    End If

                Next

                If enableFog Then addFogEnd(alphaCmds)
                If enabledVertexColors Then alphaCmds.Add(strF3D("B7 00 00 00 00 02 00 00"))
                alphaCmds.Add(strF3D("FC FF FF FF FF FE 79 3C"))
                alphaCmds.Add(strF3D("BB 00 00 00 FF FF FF FF"))
                alphaCmds.Add(strF3D("B8 00 00 00 00 00 00 00"))

                curSegOffset += alphaCmds.Count * 8
                MergeScrollingTextures()
            End If

            'Create Trans DL
            If createTransDL Then
                Dim resetBF As Boolean = False
                Dim lastMat As Material = Nothing
                enabledVertexColors = False

                conRes.PtrTrans = CurSegAddress Or curSegOffset

                transCmds.Add(strF3D("E7 00 00 00 00 00 00 00"))
                transCmds.Add(strF3D("B7 00 00 00 00 00 00 00"))
                transCmds.Add(strF3D("BB 00 00 01 FF FF FF FF"))
                transCmds.Add(strF3D("E8 00 00 00 00 00 00 00"))
                transCmds.Add(strF3D("E6 00 00 00 00 00 00 00"))

                For i As Integer = 0 To vertexGroups.Count - 1
                    Dim mp As VertexGroupList = vertexGroups(i)
                    If Not mp.Material.hasTransparency OrElse (mp.EnableVertexColors AndAlso Not mp.EnableVertexAlpha) AndAlso Not enableForcing Then Continue For

                    If lastN64Codec <> mp.Material.type Then
                        If mp.Material.type = MaterialType.TEXTURE_TRANSPARENT Then
                            If mp.Material.opacityOrg < &HFF Then
                                transCmds.Add(strF3D($"FB 00 00 00 FF FF FF {Hex(mp.Material.opacityOrg)}"))
                                resetBF = True
                            End If
                        End If
                        addCmdFC(transCmds, mp.Material)
                        addCmd03(transCmds, mp.Material, importStart - romPos)
                        If mp.Material.type = MaterialType.COLOR_TRANSPARENT Then
                            addColorCmdFB(transCmds, mp.Material)
                            resetBF = True
                        End If
                        lastN64Codec = mp.Material.type
                    Else
                        If i > 0 Then
                            If (vertexGroups(i - 1).Material.enableTextureColor AndAlso mp.Material.enableTextureColor) Then
                                If vertexGroups(i - 1).Material.color <> mp.Material.color Then addCmd03(transCmds, mp.Material, importStart - romPos)
                            ElseIf mp.Material.enableTextureColor Then
                                addCmd03(transCmds, mp.Material, importStart - romPos)
                            End If
                        End If
                        If lastN64Codec = MaterialType.COLOR_TRANSPARENT AndAlso mp.Material.type = MaterialType.COLOR_TRANSPARENT Then
                            If mp.Material IsNot lastMat Then
                                addColorCmdFB(transCmds, mp.Material)
                                resetBF = True
                            End If
                        End If
                    End If

                    If mp.Material.hasTexture Then
                        addCmdFD(transCmds, mp.Material)
                        addCmdF5(transCmds, mp.Material, True)
                        transCmds.Add(strF3D("E6 00 00 00 00 00 00 00"))
                        addCmdF3(transCmds, mp.Material)
                        transCmds.Add(strF3D("E7 00 00 00 00 00 00 00"))
                        addCmdF5(transCmds, mp.Material, False)
                        addCmdF2(transCmds, mp.Material)
                    End If

                    Dim grpOff As Integer = 0
                    For ii As Integer = 0 To mp.GroupsCount - 1
                        addTriCmds(transCmds, mp.Material, mp.FinalVertexGroups(ii), startVerts + (mp.StartIndex + grpOff), enabledVertexColors)
                        grpOff += mp.FinalVertexGroups(ii).VertexDataCount * &H10
                    Next
                    lastMat = mp.Material
                Next

                If resetBF Then strF3D("FB 00 00 00 FF FF FF FF")

                If enabledVertexColors Then transCmds.Add(strF3D("B7 00 00 00 00 02 00 00"))
                transCmds.Add(strF3D("FC FF FF FF FF FE 79 3C"))
                transCmds.Add(strF3D("BB 00 00 00 FF FF FF FF"))
                transCmds.Add(strF3D("B8 00 00 00 00 00 00 00"))

                curSegOffset += transCmds.Count * 8
                MergeScrollingTextures()
            End If

            Dim size As Integer = curSegOffset - (importStart - romPos)
            Dim importData As Integer = impstream.Position

            memcpy(defaultColor, importData)

            Dim curOff As Integer = &H10
            For Each mt As Material In materials
                If mt.hasTexture Then
                    If Not mt.isTextureCopy Then
                        memcpy(mt.texture.data, importData + curOff)
                        curOff += mt.size
                        If mt.paletteSize > 0 Then
                            memcpy(mt.texture.palette, importData + curOff)
                            curOff += mt.paletteSize
                        End If
                    End If
                    If mt.enableTextureColor Then
                        Dim colorData(15) As Byte
                        fillColorData(colorData, mt, mt.texColDark)
                        memcpy(colorData, importData + curOff)
                        curOff += &H10
                    End If
                Else
                    Dim colorData(15) As Byte
                    fillColorData(colorData, mt, 0.8)
                    memcpy(colorData, importData + curOff)
                    curOff += &H10
                End If
            Next

            For Each mp As VertexGroupList In vertexGroups
                For g As Integer = 0 To mp.GroupsCount - 1
                    If mp.FinalVertexGroups(g).VertexDataCount >= 1 Then
                        For i As Integer = 0 To mp.FinalVertexGroups(g).VertexDataCount - 1
                            memcpy(mp.FinalVertexGroups(g).FinalVertexData(i).Data, importData + curOff)
                            curOff += &H10
                        Next
                    End If
                Next
            Next

            If createSolidDL Then
                For Each cmd As f3d In solidCmds
                    memcpy(cmd.data, importData + curOff)
                    curOff += &H8
                Next
            End If
            If createAlphaDL Then
                For Each cmd As f3d In alphaCmds
                    memcpy(cmd.data, importData + curOff)
                    curOff += &H8
                Next
            End If
            If createTransDL Then
                For Each cmd As f3d In transCmds
                    memcpy(cmd.data, importData + curOff)
                    curOff += &H8
                Next
            End If

            curImp.curPos += size

            importDataSize = size
            resetVariables()
            currentPreName = Nothing
        End Sub

        Public Function ConvertModel(s As Stream, settings As ConvertSettings, input As S3DFileParser.Object3D, texFormatSettings As TextureFormatSettings) As ConvertResult
            Me.settings = settings
            impstream = s
            br = New BinaryReader(s)
            bw = New BinaryWriter(s)

            Dim preName As String = ""

            With settings
                'Limit
                setNextLimit = .SizeLimit
                Array.Resize(curImp.data, setNextLimit)

                'Rom Address
                If .RomAddress IsNot Nothing Then
                    romPos = .RomAddress
                    definedSegPtr = False

                    'Segmented Address
                    If .SegmentedAddress IsNot Nothing Then
                        startSegOffset = .SegmentedAddress And &HFFFFFF
                        curSeg = (.SegmentedAddress >> 24) And &HFF
                        curSegOffset = startSegOffset  'startSegOffset
                        definedSegPtr = True
                    End If

                    'Create new Import
                    Dim i As New Import
                    i.address = romPos
                    If setNextLimit <> 0 Then
                        i.limit = setNextLimit
                        setNextLimit = 0
                    Else
                        i.limit = &H150000
                    End If
                    ReDim i.data(i.limit - 1)
                    importData.Add(i)
                    curImp = i
                End If

                'Scale
                modelScale = .Scale

                'Offset Position
                xOff = .OffsetPosition.X
                yOff = .OffsetPosition.Y
                zOff = .OffsetPosition.Z

                'Reduce Vertices Level
                reduceVertLevel = .ReduceVertLevel

                'Shading
                setLightAndDarkValues(input.Shading)

                'ColorTexData
                If .ColorTexData <> "" Then
                    colorTexData = .ColorTexData
                End If

                'GeoModeData
                If .GeoModeData <> "" Then
                    geoModeData = .GeoModeData
                End If

                'TexTypeData
                If .TexTypeData <> "" Then
                    texTypeData = .TexTypeData
                End If

                'Flip Textures
                flipTexturesVertically = .FlipTexturesVerticaly

                'Resize Textures
                resizeTextures = .ResizeTextures

                'Center Model
                centerVerts = .CenterModel

                'Collision Data
                col_data = .CollisionData

                'Fog
                If .Fog IsNot Nothing Then
                    enableFog = True
                    fogTyp = .Fog.Type
                    fogRed = .Fog.Color.R
                    fogGreen = .Fog.Color.G
                    fogBlue = .Fog.Color.B
                Else
                    enableFog = False
                End If

                'Import
                conMode = .Mode
                Select Case .Mode
                    Case ConvertingMode.VisualMap
                        'Import
                        importOBJ(input, texFormatSettings)
                    Case ConvertingMode.Collision
                        'Import Collision
                        'importOBJCollision(input)
                End Select

            End With

            resetVariables()

            Return conRes
        End Function

        Public Function ConvertModelAsync(s As Stream, settings As ConvertSettings, input As S3DFileParser.Object3D, texFormatSettings As TextureFormatSettings) As Task(Of ConvertResult)
            Dim t As New Task(Of ConvertResult)(Function() ConvertModel(s, settings, input, texFormatSettings))
            t.Start()
            Return t
        End Function

    End Class

End Namespace
