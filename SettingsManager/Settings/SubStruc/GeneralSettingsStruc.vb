Imports SettingsMgr

Public Class GeneralSettingsStruc

    Public Property AutoUpdates As Boolean
    Public Property IntegerValueMode As Integer
    Public Property EmulatorPath As String
    Public Property ActionIfUpdatePatches As Windows.Forms.DialogResult

    Public Sub ResetValues()
        AutoUpdates = True
        IntegerValueMode = 0
        EmulatorPath = ""
        ActionIfUpdatePatches = Windows.Forms.DialogResult.None
    End Sub
End Class
