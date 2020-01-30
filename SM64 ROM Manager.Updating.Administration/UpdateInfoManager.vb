Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class UpdateInfoManager

    Public ReadOnly Property UpdateInfo As UpdateInfo

    Public Sub New()
        NewInfo()
    End Sub

    Public Sub Load(filePath As String)
        _UpdateInfo = JObject.Parse(File.ReadAllText(filePath)).ToObject(Of UpdateInfo)
    End Sub

    Public Sub Save(filePath As String)
        File.WriteAllText(filePath, JObject.FromObject(UpdateInfo).ToString)
    End Sub

    Public Sub NewInfo()
        _UpdateInfo = New UpdateInfo
    End Sub

End Class
