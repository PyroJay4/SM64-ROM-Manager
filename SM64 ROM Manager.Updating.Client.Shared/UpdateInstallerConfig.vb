Imports Newtonsoft.Json.Linq

Public Class UpdateInstallerConfig

    Public Property PackagePath As String
    Public Property RestartHostApplication As Boolean
    Public Property RestartHostApplicationArguments As String
    Public Property ApplicationName As String
    Public Property HostApplicationPath As String
    Public Property HostApplicationProcessPath As String
    Public Property ForceClosingHostApplication As Boolean
    Public Property MillisecondsToWaitForHostApplicationToClose As UInteger

    Public Shared Function Parse(str As String) As UpdateInstallerConfig
        Return JObject.Parse(Text.Encoding.Default.GetString(Convert.FromBase64String(str))).ToObject(Of UpdateInstallerConfig)
    End Function

    Public Overrides Function ToString() As String
        Return Convert.ToBase64String(Text.Encoding.Default.GetBytes(JObject.FromObject(Me).ToString))
    End Function

End Class
