Imports System.Collections.Specialized
Imports SettingsMgr

Public Class RecentFilesSettingsStruc

    Public Property RecentROMs As StringCollection
    Public Property RecentModelFiles As StringCollection

    Public Sub ResetValues()
        RecentROMs = New StringCollection
        RecentModelFiles = New StringCollection
    End Sub
End Class
