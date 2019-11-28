Imports System.IO
Imports System.Windows.Forms
Imports Pilz.Configuration

Public Class Settings

    Private Shared enableAutoSave As Boolean = False
    Private Shared managerInstance As SettingsManager(Of SettingsStruc)

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Shared ReadOnly Property Instance As SettingsStruc
        Get
            If managerInstance Is Nothing Then
                managerInstance = New SettingsManager(Of SettingsStruc)(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Data\Settings.json"), enableAutoSave)
            End If
            Return managerInstance.Instance
        End Get
    End Property

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Shared ReadOnly Property MySettingsManager As SettingsManager(Of SettingsStruc)
        Get
            Return managerInstance
        End Get
    End Property

    Public Shared Property AutoSave As Boolean
        Get
            Return enableAutoSave
        End Get
        Set
            enableAutoSave = Value
            If managerInstance IsNot Nothing Then
                managerInstance.AutoSaveOnExit = Value
            End If
        End Set
    End Property

    Public Shared Property SettingsConfigFilePath As String
        Get
            Return Instance.SettingsManager.ConfigFilePath
        End Get
        Set
            Instance.SettingsManager.ConfigFilePath = Value
        End Set
    End Property

    Public Shared Sub SaveSettings()
        Instance.SettingsManager.Save()
    End Sub

    Public Shared Sub ResetSettings()
        Instance.ResetValues()
    End Sub

#Region "Secions"

    Public Shared ReadOnly Property AreaEditor As AreaEditorSettingsStruc
        Get
            Return Instance.AreaEditor
        End Get
    End Property

    Public Shared ReadOnly Property General As GeneralSettingsStruc
        Get
            Return Instance.General
        End Get
    End Property

    Public Shared ReadOnly Property StyleManager As StyleManagerSettingsStruc
        Get
            Return Instance.StyleManager
        End Get
    End Property

    Public Shared ReadOnly Property FileParser As FileParserSettingsStruc
        Get
            Return Instance.FileParser
        End Get
    End Property

    Public Shared ReadOnly Property RecentFiles As RecentFilesSettingsStruc
        Get
            Return Instance.RecentFiles
        End Get
    End Property

    Public Shared ReadOnly Property ModelConverter As ModelConverterSettingsStruc
        Get
            Return Instance.ModelConverter
        End Get
    End Property

    Public Shared ReadOnly Property JobsToDo As JobsToDoStruc
        Get
            Return Instance.JobsToDo
        End Get
    End Property

#End Region

End Class
