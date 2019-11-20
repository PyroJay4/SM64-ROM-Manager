Imports Newtonsoft.Json.Linq

Public Class UpdateInfo

    Public Property UpdateInstallerLink As String
    Public Property Packages As New List(Of UpdatePackageInfo)

    Public Shared Function Parse(str As String) As UpdateInfo
        Return JObject.Parse(str).ToObject(Of UpdateInfo)
    End Function

    Public Overrides Function ToString() As String
        Return JObject.FromObject(Me).ToString
    End Function

End Class
