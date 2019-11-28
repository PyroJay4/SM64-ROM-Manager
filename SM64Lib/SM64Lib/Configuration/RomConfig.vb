Imports System.IO
Imports Newtonsoft.Json.Linq

Namespace Configuration

    Public Class RomConfig

        Public ReadOnly Property CustomConfigs As New Dictionary(Of String, String)
        Public ReadOnly Property LevelNames As New Dictionary(Of Byte, String)
        Public Property SelectedTextProfileInfo As String = String.Empty

        Public Shared Function Load(filePath As String) As RomConfig
            Return JObject.Parse(File.ReadAllText(filePath)).ToObject(Of RomConfig)
        End Function

        Public Sub Save(filePath As String)
            File.WriteAllText(filePath, JObject.FromObject(Me).ToString)
        End Sub

    End Class

End Namespace
