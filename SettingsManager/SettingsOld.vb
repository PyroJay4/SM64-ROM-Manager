Imports System.Drawing
Imports System.Windows.Forms
Imports IniParser
Imports IniParser.Model
Imports OpenGLCamera

Public Class SettingsOld

    Shared IniSettings As New IniData
    Public Shared ReadOnly SettingsFile As String = Application.StartupPath & "\Data\Settings.ini"

    Shared Sub SaveSettings()
        With (New FileIniDataParser)
            .WriteFile(SettingsFile, IniSettings)
        End With
    End Sub
    Shared Sub LoadSettings()
        NewSettingsFile()

        If Not IO.File.Exists(SettingsFile) Then
            SaveSettings()
            Return
        End If

        Dim tIni As IniData = (New FileIniDataParser).ReadFile(SettingsFile)
        For Each s As SectionData In tIni.Sections
            IniSettings.Sections.Add(s)
        Next
    End Sub
    Shared Sub NewSettingsFile()
        IniSettings = New IniData

        IniSettings.Global.AddKey("Auto-Updates", True.ToString)
        IniSettings.Global.AddKey("Integer Value Mode", "0")
        IniSettings.Global.AddKey("Auto Update Checksum", False.ToString)
        IniSettings.Global.AddKey("Emulator Path", "")
        IniSettings.Global.AddKey("Action if Update-Patches", CInt(DialogResult.None))

        IniSettings.Sections.AddSection("Level Manager")

        IniSettings.Sections.AddSection("Area Editor")
        IniSettings("Area Editor").AddKey("Default Camera Mode", CameraMode.ORBIT)
        IniSettings("Area Editor").AddKey("Default Window Mode", FormWindowState.Normal)
        IniSettings("Area Editor").AddKey("Enable History", True.ToString)
        IniSettings("Area Editor").AddKey("RibbonControl.Expanded", True.ToString)

        IniSettings.Sections.AddSection("Style Manager")
        IniSettings("Style Manager").AddKey("Metro Color Params BaseColor", DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Office2016Purple.BaseColor.ToArgb)
        IniSettings("Style Manager").AddKey("Metro Color Params CanvasColor", DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Office2016Purple.CanvasColor.ToArgb)
        IniSettings("Style Manager").AddKey("Metro Color Params ThemeName", DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Office2016Purple.ThemeName)
        IniSettings("Style Manager").AddKey("Always keep blue Colors", True.ToString)

        IniSettings.Sections.AddSection("Model Converter")
        IniSettings("Model Converter").AddKey("Up-Axis", "0")

        IniSettings.Sections.AddSection("File Parser")
        IniSettings("File Parser").AddKey("Loader Module", S3DFileParser.LoaderModule.Assimp)

        IniSettings.Sections.AddSection("Recent ROMs")
        IniSettings.Sections.AddSection("Recent Model Files")
    End Sub

    Public Class General
        Shared Property AutoUpdates() As Boolean
            Get
                Return IniSettings.Global("Auto-Updates")
            End Get
            Set(value As Boolean)
                IniSettings.Global("Auto-Updates") = value.ToString
            End Set
        End Property
        Shared Property IntegerValueMode As Integer
            Get
                Return CInt(IniSettings.Global("Integer Value Mode"))
            End Get
            Set(value As Integer)
                IniSettings.Global("Integer Value Mode") = CStr(value)
            End Set
        End Property
        Shared Property AutoUpdateChecksum As Boolean
            Get
                Return IniSettings.Global("Auto Update Checksum")
            End Get
            Set(value As Boolean)
                IniSettings.Global("Auto Update Checksum") = value.ToString
            End Set
        End Property
        Shared Property EmulatorPath As String
            Get
                Return IniSettings.Global("Emulator Path")
            End Get
            Set(value As String)
                IniSettings.Global("Emulator Path") = value
            End Set
        End Property
        Shared Property ActionIfUpdatePatches As DialogResult
            Get
                Return CInt(IniSettings.Global("Action if Update-Patches"))
            End Get
            Set(value As DialogResult)
                IniSettings.Global("Action if Update-Patches") = CInt(value)
            End Set
        End Property
    End Class

    Public Class RecentFiles

        Public Const RecentRomsSection As String = "Recent ROMs"
        Public Const RecentModelFilesSection As String = "Recent Model Files"

        Shared Sub StoreRecentFile(section As String, fileName As String)
            Dim files As New List(Of String)
            For Each k As KeyData In IniSettings(section)
                If k.Value <> fileName Then files.Add(k.Value)
            Next

            files.Add(fileName)

            If files.Count > 20 Then
                files.RemoveAt(0)
            End If

            IniSettings(section).RemoveAllKeys()
            For Each f As String In files
                IniSettings(section).AddKey(f.GetHashCode, f)
            Next
        End Sub
        Shared Sub StoreRecentFiles(section As String, fileNames As String())
            ClearRecentFilesList(section)
            Dim cIndex As String = 1
            For Each f As String In fileNames
                IniSettings(section).AddKey(cIndex, f)
                cIndex += 1
            Next
        End Sub
        Shared Function GetRecentFiles(section As String) As String()
            Dim rr As New List(Of String)
            For Each r As KeyData In IniSettings(section)
                If r.Value <> "" AndAlso IO.File.Exists(r.Value) Then rr.Add(r.Value)
            Next
            rr.Reverse()
            Return rr.ToArray
        End Function
        Shared Sub ClearRecentFilesList(section As String)
            IniSettings(section).RemoveAllKeys()
        End Sub
    End Class

    Public Class LevelManager
        'Shared Property RangeForLevelsStart As UInteger
        '    Get
        '        RangeForLevelsStart = IniSettings("Level Manager")("Range for Levels Start")
        '        If RangeForLevelsStart = 0 Then Return SM64Lib.RomManager.ManagerSettings.defaultRangeForLevelsStart
        '    End Get
        '    Set(value As UInteger)
        '        IniSettings("Level Manager")("Range for Levels Start") = If(value = SM64Lib.RomManager.ManagerSettings.defaultRangeForLevelsStart, 0, value)
        '    End Set
        'End Property
        'Shared Property RangeForLevelsEnd As UInteger
        '    Get
        '        RangeForLevelsEnd = IniSettings("Level Manager")("Range for Levels End")
        '        If RangeForLevelsEnd = 0 Then Return SM64Lib.RomManager.ManagerSettings.defaultRangeForLevelsEnd
        '    End Get
        '    Set(value As UInteger)
        '        IniSettings("Level Manager")("Range for Levels End") = If(value = SM64Lib.RomManager.ManagerSettings.defaultRangeForLevelsEnd, 0, value)
        '    End Set
        'End Property
        'Shared Property AddRangeToEndOfLevelscript As UInteger
        '    Get
        '        Return IniSettings("Level Manager")("Add Range to end of Levelscript")
        '    End Get
        '    Set(value As UInteger)
        '        IniSettings("Level Manager")("Add Range to end of Levelscript") = value
        '    End Set
        'End Property
        'Shared Property AddRangeToEndOfBank0xE As UInteger
        '    Get
        '        Return IniSettings("Level Manager")("Add Range to end of Bank 0xE")
        '    End Get
        '    Set(value As UInteger)
        '        IniSettings("Level Manager")("Add Range to end of Bank 0xE") = value
        '    End Set
        'End Property
    End Class

    Public Class AreaEditor
        Shared Property DefaultCameraMode As CameraMode
            Get
                Return [Enum].Parse(GetType(CameraMode), IniSettings("Area Editor")("Default Camera Mode"))
            End Get
            Set(value As CameraMode)
                IniSettings("Area Editor")("Default Camera Mode") = value.ToString
            End Set
        End Property
        Shared Property DefaultWindowMode As FormWindowState
            Get
                Return [Enum].Parse(GetType(FormWindowState), IniSettings("Area Editor")("Default Window Mode"))
            End Get
            Set(value As FormWindowState)
                IniSettings("Area Editor")("Default Window Mode") = value.ToString
            End Set
        End Property
        Shared Property EnableHistory As Boolean
            Get
                Return Convert.ToBoolean(IniSettings("Area Editor")("Enable History"))
            End Get
            Set(value As Boolean)
                IniSettings("Area Editor")("Enable History") = value.ToString
            End Set
        End Property
        Shared Property RibbonControlExpanded As Boolean
            Get
                Return Convert.ToBoolean(IniSettings("Area Editor")("RibbonControl.Expanded"))
            End Get
            Set(value As Boolean)
                IniSettings("Area Editor")("RibbonControl.Expanded") = value.ToString
            End Set
        End Property
    End Class

    Public Class StyleManager
        Shared Property MetroColorParams As DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters
            Get
                Dim themesList As New List(Of DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters)(DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.GetAllPredefinedThemes)
                Dim baseColor As Color = Color.FromArgb(IniSettings("Style Manager")("Metro Color Params BaseColor"))
                Dim cavansColor As Color = Color.FromArgb(IniSettings("Style Manager")("Metro Color Params CanvasColor"))
                Dim themeName As String = IniSettings("Style Manager")("Metro Color Params ThemeName")
                Return themesList.FirstOrDefault(Function(n) n.BaseColor = baseColor And n.CanvasColor = cavansColor And n.ThemeName = themeName)
            End Get
            Set(value As DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters)
                IniSettings("Style Manager")("Metro Color Params BaseColor") = value.BaseColor.ToArgb
                IniSettings("Style Manager")("Metro Color Params CanvasColor") = value.CanvasColor.ToArgb
                IniSettings("Style Manager")("Metro Color Params ThemeName") = value.ThemeName
            End Set
        End Property
        Shared Property AlwaysKeepBlueColors
            Get
                Return Convert.ToBoolean(IniSettings("Style Manager")("Always keep blue Colors"))
            End Get
            Set(value)
                IniSettings("Style Manager")("Always keep blue Colors") = value.ToString
            End Set
        End Property
    End Class

    Public Class ModelConverter
        Shared Property UpAxis As S3DFileParser.UpAxis
            Get
                Return CInt(IniSettings("Model Converter")("Up-Axis"))
            End Get
            Set(value As S3DFileParser.UpAxis)
                IniSettings("Model Converter")("Up-Axis") = CInt(value)
            End Set
        End Property
    End Class

    Public Class FileParser
        Shared Property LoaderModule As S3DFileParser.LoaderModule
            Get
                Return CInt(IniSettings("File Parser")("Loader Module"))
            End Get
            Set(value As S3DFileParser.LoaderModule)
                IniSettings("File Parser")("Loader Module") = CInt(value)
            End Set
        End Property
    End Class

End Class

