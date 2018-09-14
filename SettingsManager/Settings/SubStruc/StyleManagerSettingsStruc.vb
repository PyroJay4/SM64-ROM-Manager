Imports SettingsMgr

Public Class StyleManagerSettingsStruc

    Public Property AlwaysKeepBlueColors As Boolean
    Public Property MetroColorParams As DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters

    Public Sub ResetValues()
        AlwaysKeepBlueColors = True
        MetroColorParams = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Office2016Purple
    End Sub
End Class
