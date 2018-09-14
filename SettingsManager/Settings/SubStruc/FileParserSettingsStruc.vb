Imports SettingsMgr

Public Class FileParserSettingsStruc

    Public Property LoaderModule As S3DFileParser.LoaderModule
    Public Property UpAxis As S3DFileParser.UpAxis

    Public Sub ResetValues()
        LoaderModule = S3DFileParser.LoaderModule.Assimp
        UpAxis = S3DFileParser.UpAxis.Y
    End Sub
End Class
