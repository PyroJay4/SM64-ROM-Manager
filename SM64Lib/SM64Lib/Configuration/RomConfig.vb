Imports System.IO
Imports Newtonsoft.Json.Linq

Namespace Configuration

    Public Class RomConfig

        Public ReadOnly Property CustomConfigs As New Dictionary(Of String, String)
        Friend ReadOnly Property LevelNames As New Dictionary(Of Byte, String)

        Friend Sub New()
        End Sub

        Friend Shared Function Load(filePath As String) As RomConfig
            Return JObject.Parse(File.ReadAllText(filePath)).ToObject(Of RomConfig)
        End Function

        Friend Sub Save(filePath As String)
            File.WriteAllText(filePath, JObject.FromObject(filePath))
        End Sub

    End Class

End Namespace
