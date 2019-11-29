Public Class GeneralSettingsStruc

    Public Property IntegerValueMode As Integer
    Public Property EmulatorPath As String
    Public Property ActionIfUpdatePatches As Windows.Forms.DialogResult
    Public Property AutoScaleMode As Windows.Forms.AutoScaleMode
    Public Property HexEditMode As HexEditModeStruc
    Public Property Language As String
    Public Property RomChangedNotification As NotificationMode

    Public Sub ResetValues()
        IntegerValueMode = 0
        EmulatorPath = ""
        ActionIfUpdatePatches = Windows.Forms.DialogResult.None
        AutoScaleMode = Windows.Forms.AutoScaleMode.None
        If HexEditMode Is Nothing Then HexEditMode = New HexEditModeStruc
        HexEditMode.ResetValues()
        Language = String.Empty
        RomChangedNotification = NotificationMode.Popup
    End Sub

End Class
