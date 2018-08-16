Imports SettingsManager

Public Module TextValueConverter

    Public Function ValueFromText(Text As String, Optional DefaultValue As Integer = 0) As Integer
        Try
            Return CInt(Text.Replace("$", "&H").Replace("0x", "&H").Trim)
        Catch ex As Exception
            Return DefaultValue
        End Try
    End Function
    Public Function TextFromValue(Value As Integer, Optional IVM As Integer = -1, Optional charCount As Integer = 0) As String
        'If Value = 0 Then Return "0"
        If IVM = -1 Then IVM = Settings.General.IntegerValueMode
        Select Case IVM
            Case 0 : Return Value.ToString(GetCharCountAsZeroString(charCount))
            Case 1 : Return "0x" & Value.ToString("X" & If(charCount > 0, charCount.ToString, ""))
            Case 2 : Return "&H" & Value.ToString("X" & If(charCount > 0, charCount.ToString, ""))
            Case 3 : Return "$" & Value.ToString("X" & If(charCount > 0, charCount.ToString, ""))
            Case Else : Return ""
        End Select
    End Function
    Private Function GetCharCountAsZeroString(charCount As Integer) As String
        GetCharCountAsZeroString = ""
        Do While GetCharCountAsZeroString.Length < charCount
            GetCharCountAsZeroString &= "0"
        Loop
    End Function

End Module
