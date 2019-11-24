Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class UpdateInfoManager

    Public ReadOnly Property UpdateInfo As UpdateInfo

    Public Sub New()
        NewTemplate()
    End Sub

    Public Sub LoadTemplate(filePath As String)
        _UpdateInfo = JObject.Parse(File.ReadAllText(filePath)).ToObject(Of UpdateInfo)
    End Sub

    Public Sub SaveTemplate(filePath As String)
        File.WriteAllText(filePath, JObject.FromObject(UpdateInfo).ToString)
    End Sub

    Public Sub NewTemplate()
        _UpdateInfo = New UpdateInfo
    End Sub

End Class
