Imports System.Drawing
Imports System.IO
Imports S3DFileParser
Imports SM64Lib.Data
Imports SM64Lib.Model.Fast3D.DisplayLists
Imports SM64Lib.Model.Fast3D.DisplayLists.Script
Imports SM64Lib.Model.Fast3D.DisplayLists.Script.Commands

Namespace Global.SM64Lib.SM64Convert

    Public Class Fast3DParser

        ''' <summary>Parse a Displaylist to an Object3D.</summary>
        ''' <param name="obj">The Object3D where the model should be parsed to.</param>
        ''' <param name="dl">The Displaylist which should be parsed.</param>
        ''' <param name="rommgr">The RomManager Instance to use.</param>
        ''' <param name="AreaID">The Area ID if avaiable.</param>
        Public Shared Sub Convert(obj As Object3D, dl As DisplayList, rommgr As RomManager, AreaID As Byte?)
            If dl.Script.Count = 0 OrElse dl.GeoPointer Is Nothing Then Return

            Dim cmdIndex As Integer = 0
            Dim cmd As DisplayListCommand = Nothing
            Dim cmdarr As Byte() = Nothing

            Dim knownTextures As New Dictionary(Of Integer, Material)
            Dim knownColors As New Dictionary(Of Integer, Color)
            Dim knownVertices As New Dictionary(Of Integer, Vertex)
            Dim knownNormals As New Dictionary(Of Integer, Normal)
            Dim knownUVs As New Dictionary(Of Integer, UV)
            Dim knownVertexColors As New Dictionary(Of Integer, VertexColor)
            Dim knownShading As New Dictionary(Of Integer, Color)
            Dim dicVertexColorShading As New Dictionary(Of Color, VertexColor)

            Dim pointbuffer As S3DFileParser.Point() = New S3DFileParser.Point(15) {}
            Dim scaledVertices As New List(Of UV)
            Dim curTexture As Material = Nothing
            Dim curTexSize As Size = Nothing
            Dim curTexSegAddr As Integer = -1
            Dim curTexWrapT As Integer = 10497
            Dim curTexWrapS As Integer = 10497
            Dim curTexScale As New Numerics.Vector2(1.0F, 1.0F)
            Dim curTexPalette As Byte() = {}
            Dim curTexFormat As N64Graphics.N64Codec? = Nothing
            Dim curGeometryMode As UInteger = &H22205
            Dim curMesh As Mesh = Nothing
            Dim curColor As Color? = Nothing

            Dim enableVertexColors As Boolean = False

            'Load Main Segmented Bank
            Dim curSeg As SegmentedBank = GetSegBank(rommgr, dl.GeoPointer.SegPointer, AreaID)
            If curSeg Is Nothing Then Return

            curMesh = New Mesh
            obj.Meshes.Add(curMesh)

            Do While cmdIndex < dl.Script.Count AndAlso dl.Script(cmdIndex).CommandType <> CommandTypes.F3D_EndDisplaylist
                cmd = dl.Script(cmdIndex)
                cmdarr = cmd.ToArray
                Dim bdata As New BinaryStreamData(cmd)

                Select Case cmd.CommandType '&H20000
                    Case CommandTypes.F3D_ClearGeometryMode
                        curGeometryMode = (curGeometryMode And (Not F3D_CLEARGEOMETRYMODE.GetGeometryMode(cmd)))

                    Case CommandTypes.F3D_SetGeometryMode
                        curGeometryMode = (curGeometryMode Or F3D_SETRGEOMETRYMODE.GetGeometryMode(cmd))

                    Case CommandTypes.F3D_Movemem
                        Dim segAddr As Integer = F3D_MOVEMEM.GetSegmentedOffset(cmd)
                        Dim smode As Byte = F3D_MOVEMEM.GetLightValueMode(cmd)

                        If smode = &H86 Then 'Load Shading Light
                            If knownShading.ContainsKey(segAddr) Then
                                curColor = knownShading(segAddr)
                            Else
                                Dim colordata As Byte() = New Byte(3) {}
                                Dim seg As SegmentedBank = rommgr.GetSegBank(segAddr >> 24, AreaID)

                                'Read Color Data
                                seg.Data.Position = segAddr And &HFFFFFF
                                seg.Data.Read(colordata, 0, colordata.Length)

                                curColor = Color.FromArgb(&HFF, colordata(0), colordata(1), colordata(2))

                                If Not dicVertexColorShading.ContainsKey(curColor) Then
                                    'Create new Vertex Color
                                    Dim vc As New VertexColor With {.R = colordata(0) / 256.0!, .G = colordata(1) / 256.0!, .B = colordata(2) / 256.0!, .A = 1.0!}
                                    dicVertexColorShading.Add(curColor, vc)
                                End If

                                'Set as Vertex Color
                                knownShading.Add(segAddr, curColor)
                            End If
                        End If

                    Case CommandTypes.G_Loadtlut
                        Dim paletteTileDescritpr As Byte = cmdarr(4)
                        Dim numColorsToLoadInPalette As UShort

                        cmd.Position = 5
                        numColorsToLoadInPalette = bdata.ReadUInt16 >> 6 '+ 1

                        Dim seg As SegmentedBank = rommgr.GetSegBank(curTexSegAddr >> 24, AreaID)
                        curTexPalette = New Byte(numColorsToLoadInPalette * 2 + 1) {}
                        Dim offset As Integer = curTexSegAddr And &HFFFFFF

                        For i As Integer = 1 To numColorsToLoadInPalette + 1
                            Dim ii As Integer = i * 2 - 2
                            seg.Data.Position = offset + ii
                            curTexPalette(ii) = seg.Data.ReadByte
                            curTexPalette(ii + 1) = seg.Data.ReadByte
                        Next

                    Case CommandTypes.F3D_Triangle1
                        Dim f As New Face

                        If curTexFormat IsNot Nothing Then
                            ProcessTexture(obj, rommgr, AreaID, dl, curTexFormat, knownTextures, curTexture, curTexSegAddr, curTexSize, curTexWrapT, curTexWrapS, curTexScale, curTexPalette, curColor)
                            f.Material = curTexture
                        End If

                        For i As Integer = 1 To 3
                            Dim pindex As Byte = F3D_TRI1.GetVertice(cmd, i)
                            If pindex >= pointbuffer.Length Then Return
                            Dim p As S3DFileParser.Point = pointbuffer(pindex)
                            If p IsNot Nothing Then f.Points.Add(p)
                        Next

                        'Shading (as Vertex Color)
                        If curTexture?.Color IsNot Nothing AndAlso (curGeometryMode And &H20000) <> 0 Then
                            Dim vc As VertexColor = dicVertexColorShading(curTexture.Color)
                            For Each p As S3DFileParser.Point In f.Points
                                If p.VertexColor Is Nothing Then
                                    If dicVertexColorShading.ContainsKey(curTexture.Color) Then
                                        p.VertexColor = vc
                                        If Not curMesh.VertexColors.Contains(vc) Then
                                            curMesh.VertexColors.Add(vc)
                                        End If
                                    End If
                                End If
                            Next
                        End If

                        curMesh.Faces.Add(f)

                    Case CommandTypes.F3D_Vertex
                        Dim num As Byte = F3D_VTX.GetNumberOfVertices(cmd)
                        Dim startindex As Byte = F3D_VTX.GetStartIndexInVertexBuffer(cmd)
                        Dim datalength As Int16 = F3D_VTX.GetLengthOfVertexData(cmd)
                        Dim segAddr As Integer = F3D_VTX.GetSegmentedAddress(cmd)

                        If num > 0 Then
                            For i As Integer = 0 To num
                                Dim p As New S3DFileParser.Point
                                Dim curSegAddr As Integer = segAddr + i * &H10
                                Dim cs As SegmentedBank = GetSegBank(rommgr, curSegAddr, AreaID)
                                If cs Is Nothing Then Continue For

                                'Vertex
                                If knownVertices.ContainsKey(curSegAddr) Then
                                    p.Vertex = knownVertices(curSegAddr)
                                Else
                                    Dim vert As Vertex = GetVertexFromStream(cs.Data, cs.BankOffsetFromSegAddr(curSegAddr), dl.GeoPointer.ModelOffset, dl.GeoPointer.ModelScale)
                                    p.Vertex = vert
                                    curMesh.Vertices.Add(vert)
                                    knownVertices.Add(curSegAddr, vert)
                                End If

                                'UV
                                If knownUVs.ContainsKey(curSegAddr) Then
                                    p.UV = knownUVs(curSegAddr)
                                Else
                                    Dim uv As UV = GetUVFromStream(cs.Data, cs.BankOffsetFromSegAddr(curSegAddr), curTexScale, curTexSize)
                                    p.UV = uv
                                    curMesh.UVs.Add(uv)
                                    knownUVs.Add(curSegAddr, uv)
                                End If

                                If (curGeometryMode And &H20000) = 0 Then
                                    'Vertex Color
                                    If knownVertexColors.ContainsKey(curSegAddr) Then
                                        p.VertexColor = knownVertexColors(curSegAddr)
                                    Else
                                        Dim vc As VertexColor = GetVertexColorFromStream(cs.Data, cs.BankOffsetFromSegAddr(curSegAddr))
                                        p.VertexColor = vc
                                        curMesh.VertexColors.Add(vc)
                                        knownVertexColors.Add(curSegAddr, vc)
                                    End If
                                Else
                                    'Normal
                                    If knownNormals.ContainsKey(curSegAddr) Then
                                        p.Normal = knownNormals(curSegAddr)
                                    Else
                                        Dim n As Normal = GetNormalFromStream(cs.Data, cs.BankOffsetFromSegAddr(curSegAddr))
                                        p.Normal = n
                                        curMesh.Normals.Add(n)
                                        knownNormals.Add(curSegAddr, n)
                                    End If
                                End If

                                pointbuffer(startindex + i) = p
                            Next
                        End If

                    Case CommandTypes.G_SetImage
                        Dim newAddr As Integer = G_SETIMG.GetSegmentedAddress(cmd)
                        If newAddr <> &HFFFFFFFF Then
                            curTexSegAddr = newAddr
                            'curColor = Nothing
                        End If

                    Case CommandTypes.G_SetTileSize
                        curTexSize = G_SETTILESIZE.GetSize(cmd)

                    Case CommandTypes.G_SetTile
                        cmd.Position = 4
                        Dim checkVal As Integer = bdata.ReadInt32
                        cmd.Position = 0

                        If checkVal <> &H7000000 Then

                            If (checkVal >> 24 And &HFF) = 0 Then
                                curTexFormat = G_SETTILE.GetTextureFormat(cmd)
                            End If

                            curTexWrapT = G_SETTILE.GetWrapT(cmd)
                            curTexWrapS = G_SETTILE.GetWrapS(cmd)
                        End If

                    Case CommandTypes.G_Texture
                        If (curGeometryMode And &H40000) = &H40000 Then
                            curTexSize = G_TEXTURE.GetTextureSize(cmd)
                        Else
                            curTexScale = G_TEXTURE.GetTextureScaling(cmd)
                        End If

                End Select

                cmdIndex += 1
            Loop
        End Sub

        ''' <summary>Parse a Displaylist to an Object3D.</summary>
        ''' <param name="obj">The Object3D where the model should be parsed to.</param>
        ''' <param name="dl">The Displaylist which should be parsed.</param>
        ''' <param name="rommgr">The RomManager Instance to use.</param>
        ''' <param name="AreaID">The Area ID if avaiable.</param>
        Public Shared Function ConvertAsync(obj As Object3D, dl As DisplayList, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() Convert(obj, dl, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Private Shared Function GetSegBank(rommgr As RomManager, segAddr As Integer, AreaID As Byte?) As SegmentedBank
            Dim seg As SegmentedBank = rommgr.GetSegBank(segAddr >> 24, AreaID)
            seg.ReadDataIfNull(rommgr.RomFile)
            Return seg
        End Function

        Private Shared Sub ProcessTexture(obj As Object3D, rommgr As RomManager, AreaID As Byte?, dl As DisplayList, texFormat As Byte, knownTextures As Dictionary(Of Integer, Material), ByRef curTexture As Material, curTexSegAddr As Integer, curTexSize As Size, curTexWrapT As Integer, curTexWrapS As Integer, curTexScale As Numerics.Vector2, curTexPalette As Byte(), curColor As Color?)
            If curTexSegAddr < 0 Then Return

            If knownTextures.ContainsKey(curTexSegAddr) Then
                curTexture = knownTextures(curTexSegAddr)
            Else
                Try
                    Dim mat As New Material

                    mat.Wrap = New Numerics.Vector2(curTexWrapT, curTexWrapS)
                    mat.Scale = curTexScale
                    mat.Color = curColor

                    Dim seg As SegmentedBank = GetSegBank(rommgr, curTexSegAddr, AreaID)
                    If seg Is Nothing Then Return

                    GetTextureImage(seg.Data, seg.BankOffsetFromSegAddr(curTexSegAddr), mat, texFormat, curTexSize, curTexPalette)

                    curTexture = mat
                    knownTextures.Add(curTexSegAddr, mat)
                    If Not obj.Materials.ContainsKey(curTexSegAddr) Then obj.Materials.Add(curTexSegAddr, mat)
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
            End If
        End Sub

        Private Shared Sub GetTextureImage(s As Stream, pos As Integer, mat As Material, texFormat As N64Graphics.N64Codec, curTexSize As Size, curTexPalette As Byte())
            'Create Image & Graphics
            mat.Image = New Bitmap(curTexSize.Width, curTexSize.Height)
            Dim g = Graphics.FromImage(mat.Image)

            'Get Texture Data
            Dim bytes As Byte() = New Byte(N64Graphics.N64Graphics.PixelsToBytes(texFormat, curTexSize.Width * curTexSize.Height) - 1) {}
            s.Position = pos
            s.Read(bytes, 0, bytes.Length)

            Try
                'Decode Texture
                N64Graphics.N64Graphics.RenderTexture(g,
                                                      bytes.ToArray,
                                                      curTexPalette,
                                                      0,
                                                      curTexSize.Width,
                                                      curTexSize.Height,
                                                      1,
                                                      texFormat,
                                                      N64Graphics.N64IMode.AlphaCopyIntensity)

            Catch ex As Exception
            End Try
        End Sub

        Private Shared Function GetVertexFromStream(s As Stream, vtStart As Integer, modelOffset As Numerics.Vector3, modelScale As Numerics.Vector3) As Vertex
            Dim vert As New Vertex
            Dim br As New BinaryStreamData(s)

            s.Position = vtStart
            vert.X = br.ReadInt16 + modelOffset.X
            vert.Y = br.ReadInt16 + modelOffset.Y
            vert.Z = br.ReadInt16 + modelOffset.Y

            vert.X *= modelScale.X
            vert.Y *= modelScale.Y
            vert.Z *= modelScale.Z

            Return vert
        End Function

        Private Shared Function GetUVFromStream(s As Stream, vtStart As Integer, curTexScale As Numerics.Vector2, curTexSize As Size) As UV
            Dim uv As New UV
            Dim br As New BinaryStreamData(s)

            s.Position = vtStart + 8
            uv.U = br.ReadInt16 * curTexScale.X
            uv.V = br.ReadInt16 * curTexScale.Y

            uv.U /= curTexSize.Width * 32.0F
            uv.V /= curTexSize.Height * 32.0F

            Return uv
        End Function

        Private Shared Function GetNormalFromStream(s As Stream, vtStart As Integer) As Normal
            Dim normal As New Normal

            s.Position = vtStart + 12
            normal.X = s.ReadByte / 255.0F
            normal.Y = s.ReadByte / 255.0F
            normal.Z = s.ReadByte / 255.0F
            'normal.A = s.ReadByte ???

            Return normal
        End Function

        Private Shared Function GetVertexColorFromStream(s As Stream, vtStart As Integer) As VertexColor
            Dim normal As New VertexColor

            s.Position = vtStart + 12
            normal.R = s.ReadByte / 255.0!
            normal.G = s.ReadByte / 255.0!
            normal.B = s.ReadByte / 255.0!
            normal.A = s.ReadByte / 255.0!

            Return normal
        End Function

        Private Shared Function GetCullingMode(geometryMode) As FaceCullingMode
            Return (geometryMode And &H3000) >> 12
        End Function

    End Class

    Public Enum FaceCullingMode
        NoCulling
        Front
        Back
        FrontAndBack = Front Or Back
    End Enum

End Namespace
