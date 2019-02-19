Imports Newtonsoft.Json

Namespace LevelEditor

    Public Class TextureInfosJsonClass
        Public Property Name As String
        Public Property FromSegmentAddress As String
        Public Property Width As String
        Public Property Height As String
        Public Property Format As String
        Public Property LoadLvlscript As String
    End Class

    Public Class TextureBlocksJsonClass
        Public Property Name As String
        Public Property Textures As TextureInfosJsonClass()
    End Class

End Namespace
