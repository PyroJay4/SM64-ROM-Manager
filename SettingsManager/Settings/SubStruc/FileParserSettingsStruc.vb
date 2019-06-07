Imports Pilz.S3DFileParser
Imports SettingsMgr

Public Class FileParserSettingsStruc

    'Public Property LoaderModule As Integer = S3DFileParser.LoaderModule
    Public Property FileLoaderModule As String
    Public Property FileExporterModule As String
    Public Property UpAxis As UpAxis

    Public Sub ResetValues()
        'LoaderModule = S3DFileParser.LoaderModule.Assimp
        FileLoaderModule = "#1"
        FileExporterModule = "#0"
        UpAxis = UpAxis.Y
    End Sub
End Class
