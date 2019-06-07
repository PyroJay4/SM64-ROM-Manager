Public Class HexEditModeStruc

    Public Property Mode As HexEditModes
    Public Property CustomPath As String

    Public Sub ResetValues()
        Mode = HexEditModes.BuildInHexEditor
        CustomPath = String.Empty
    End Sub

End Class
