Imports Pilz.Configuration

Public Class SettingsStruc
    Inherits SettingsBase

    Public Property AreaEditor As AreaEditorSettingsStruc
    Public Property General As GeneralSettingsStruc
    Public Property StyleManager As StyleManagerSettingsStruc
    Public Property FileParser As FileParserSettingsStruc
    Public Property RecentFiles As RecentFilesSettingsStruc
    Public Property ModelConverter As ModelConverterSettingsStruc
    Public Property JobsToDo As JobsToDoStruc
    Public Property TextManager As TextManagerSettingsStruc

    Public Overrides Sub ResetValues()
        If AreaEditor Is Nothing Then AreaEditor = New AreaEditorSettingsStruc
        AreaEditor.ResetValues()
        If General Is Nothing Then General = New GeneralSettingsStruc
        General.ResetValues()
        If StyleManager Is Nothing Then StyleManager = New StyleManagerSettingsStruc
        StyleManager.ResetValues()
        If FileParser Is Nothing Then FileParser = New FileParserSettingsStruc
        FileParser.ResetValues()
        If RecentFiles Is Nothing Then RecentFiles = New RecentFilesSettingsStruc
        RecentFiles.ResetValues()
        If ModelConverter Is Nothing Then ModelConverter = New ModelConverterSettingsStruc
        ModelConverter.ResetValues()
        If JobsToDo Is Nothing Then JobsToDo = New JobsToDoStruc
        JobsToDo.Clear()
        If TextManager Is Nothing Then TextManager = New TextManagerSettingsStruc
        TextManager.ResetValues()
    End Sub

End Class
