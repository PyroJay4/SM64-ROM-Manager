Imports System.Drawing

Namespace SM64Convert

    Public Class TextureLoadedInfos

        Public ReadOnly Property Name As String
        Public ReadOnly Property TextureFormat As N64Graphics.N64Codec
        Public ReadOnly Property TextureSegAddress As Integer
        Public ReadOnly Property TexturePaletteSegAddress As Integer
        Public ReadOnly Property TextureRomAddress As Integer
        Public ReadOnly Property TexturePaletteRomAddress As Integer
        Public ReadOnly Property TextureSize As Size
        Public ReadOnly Property IsReadOnly As Boolean

        Public Sub New(name As String, textureFormat As N64Graphics.N64Codec, textureSegAddress As Integer, texturePaletteSegAddress As Integer, textureRomAddress As Integer, texturePaletteRomAddress As Integer, textureSize As Size)
            Me.New(name, textureFormat, textureSegAddress, texturePaletteSegAddress, textureRomAddress, texturePaletteRomAddress, textureSize, False)
        End Sub

        Public Sub New(name As String, textureFormat As N64Graphics.N64Codec, textureSegAddress As Integer, texturePaletteSegAddress As Integer, textureRomAddress As Integer, texturePaletteRomAddress As Integer, textureSize As Size, isReadOnly As Boolean)
            Me.Name = name
            Me.TextureFormat = textureFormat
            Me.TextureSegAddress = textureSegAddress
            Me.TexturePaletteSegAddress = texturePaletteSegAddress
            Me.TextureRomAddress = textureRomAddress
            Me.TexturePaletteRomAddress = texturePaletteRomAddress
            Me.TextureSize = textureSize
            Me.IsReadOnly = isReadOnly
        End Sub

    End Class

End Namespace
