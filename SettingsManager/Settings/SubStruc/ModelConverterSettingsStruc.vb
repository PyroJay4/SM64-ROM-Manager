Public Class ModelConverterSettingsStruc

    Public Property UseLegacyCollisionDescriptions As Boolean
    Public ReadOnly Property InputSettings As New Dictionary(Of String, GuiInputSettings)

    Public Sub ResetValues()
        UseLegacyCollisionDescriptions = False
        InputSettings.Clear()
    End Sub

End Class
