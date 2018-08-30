Imports System.ComponentModel
Imports System.Configuration
Imports System.Windows.Forms
Imports OpenGLCamera

Public Class Settings

    Private Shared ReadOnly needToSave As New List(Of SettingsBase)
    Private Shared ReadOnly addedHandler As New List(Of SettingsBase)

#Region "Functions"

    Public Shared Sub SaveSettings()
        For Each s As SettingsBase In needToSave
            s.Save()
        Next

        needToSave.Clear()
    End Sub

    Public Shared Sub ResetSettings()
        AreaEditor.Reset()
        General.Reset()
        StyleManager.Reset()
        FileParser.Reset()

        needToSave.Clear()
        addedHandler.Clear()
    End Sub

    Private Shared Sub AddToNeedtoSave(sender As Object, e As PropertyChangedEventArgs)
        If Not needToSave.Contains(sender) Then
            needToSave.Add(sender)
        End If
    End Sub

    Private Shared Sub AddHandlers(s As ApplicationSettingsBase)
        If Not addedHandler.Contains(s) Then
            AddHandler s.PropertyChanged, AddressOf AddToNeedtoSave
        End If
    End Sub

#End Region

#Region "Settings"

    Public Shared ReadOnly Property AreaEditor As AreaEditorSettings
        Get
            Dim s = AreaEditorSettings.Default
            AddHandlers(s)
            Return s
        End Get
    End Property

    Public Shared ReadOnly Property General As GeneralSettings
        Get
            Dim s = GeneralSettings.Default
            AddHandlers(s)
            Return s
        End Get
    End Property

    Public Shared ReadOnly Property StyleManager As StyleManagerSettings
        Get
            Dim s = StyleManagerSettings.Default
            AddHandlers(s)

            If s.MetroColorParams.Equals(DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Default) Then
                s.MetroColorParams = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Office2016Purple
            End If

            Return s
        End Get
    End Property

    Public Shared ReadOnly Property FileParser As FileParserSettings
        Get
            Dim s = FileParserSettings.Default
            AddHandlers(s)
            Return s
        End Get
    End Property

    Public Shared ReadOnly Property RecentFiles As RecentFilesSettings
        Get
            Dim s = RecentFilesSettings.Default
            AddHandlers(s)
            Return s
        End Get
    End Property

#End Region

End Class
