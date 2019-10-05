Imports System.Drawing
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports SettingsMgr

Public Class StyleManagerSettingsStruc

    Public Property AlwaysKeepBlueColors As Boolean
    Public Property MetroColorParams As MetroColorGeneratorParameters
    Public Property UseWindows10Style As Boolean

    Public Sub ResetValues()
        AlwaysKeepBlueColors = True
        MetroColorParams = VisualThemeLight 'MetroColorGeneratorParameters.Office2016Purple
        UseWindows10Style = True
    End Sub

    Public Function IsDarkTheme() As Boolean
        Return IsDarkTheme(MetroColorParams)
    End Function

    Public Function IsWhiteTheme() As Boolean
        Return IsWhiteTheme(MetroColorParams)
    End Function

    Public Shared Function IsDarkTheme(theme As MetroColorGeneratorParameters) As Boolean
        Return {VisualThemeDark}.Contains(theme)
    End Function

    Public Shared Function IsWhiteTheme(theme As MetroColorGeneratorParameters) As Boolean
        Return theme.CanvasColor.ToArgb = Color.White.ToArgb
    End Function

    Public Shared ReadOnly Property VisualThemeLight As MetroColorGeneratorParameters
        Get
            Return New MetroColorGeneratorParameters(ColorScheme.GetColor("FFFFFF"), ColorScheme.GetColor("80397B"), "Light")
        End Get
    End Property

    Public Shared ReadOnly Property VisualThemeGray As MetroColorGeneratorParameters
        Get
            Return New MetroColorGeneratorParameters(ColorScheme.GetColor("c0c0c0"), ColorScheme.GetColor("662D62"), "Gray")
        End Get
    End Property

    Public Shared ReadOnly Property VisualThemeDark As MetroColorGeneratorParameters
        Get
            Return New MetroColorGeneratorParameters(ColorScheme.GetColor("262626"), ColorScheme.GetColor("4C2249"), "Dark")
        End Get
    End Property

End Class
