Imports SM64_ROM_Manager.Updating

Public Class NetworkSettingsStruc

    Public Property AutoUpdates As Boolean
    Public Property MinimumUpdateChannel As Channels
    Public Property UseAdminRightsForUpdates As Boolean
    Public Property ProxyUsername As String
    Public Property ProxyPasswordEncrypted As String

    Public Sub ResetValues()
        AutoUpdates = True
        MinimumUpdateChannel = Channels.Stable
        UseAdminRightsForUpdates = False
    End Sub

End Class
