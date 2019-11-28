Public Module TextValueConverter

    Public Event WantIntegerValueMode(e As WantIntegerValueModeEventArgs)

    Public Function ValueFromText(Text As String, Optional DefaultValue As Integer = 0, Optional useIVM As Integer = -1) As Integer
        Return LongFromText(Text, DefaultValue, useIVM)
    End Function

    Public Function LongFromText(Text As String, Optional DefaultValue As Long = 0, Optional useIVM As Long = -1) As Long
        Try
            Dim IVM As Integer = If(IVM > -1, IVM, GetIntegerValueMode())
            Select Case True
                Case Text.StartsWith("0x"), Text.StartsWith("&h"), useIVM = 1, useIVM = 2
                    Return Convert.ToInt32(Text.Substring(2), 16)
                Case Text.StartsWith("$"), useIVM = 3
                    Return Convert.ToInt32(Text.Substring(1), 16)
                Case Text.StartsWith("0b"), Text.StartsWith("&b")
                    Return Convert.ToInt32(Text.Substring(2), 2)
                Case Else
                    If IVM = 0 OrElse useIVM = 0 Then
                        Try
                            Return Convert.ToInt32(Text)
                        Catch ex As Exception
                        End Try
                        Try
                            Return Convert.ToInt32(Text, 16)
                        Catch ex As Exception
                        End Try
                    Else
                        Try
                            Return Convert.ToInt32(Text, 16)
                        Catch ex As Exception
                        End Try
                        Try
                            Return Convert.ToInt32(Text)
                        Catch ex As Exception
                        End Try
                    End If
                    Return 0
            End Select
        Catch ex As Exception
            Return DefaultValue
        End Try
    End Function

    Public Function TextFromValue(Value As Long, Optional IVM As Integer = -1, Optional charCount As Integer = 0) As String
        If IVM = -1 Then
            IVM = GetIntegerValueMode()
        End If

        Select Case IVM
            Case 0 : Return Value.ToString(GetCharCountAsZeroString(charCount))
            Case 1 : Return "0x" & Value.ToString("X" & If(charCount > 0, charCount.ToString, ""))
            Case 2 : Return "&H" & Value.ToString("X" & If(charCount > 0, charCount.ToString, ""))
            Case 3 : Return "$" & Value.ToString("X" & If(charCount > 0, charCount.ToString, ""))
            Case Else : Return String.Empty
        End Select
    End Function

    Private Function GetCharCountAsZeroString(charCount As Integer) As String
        GetCharCountAsZeroString = ""
        Do While GetCharCountAsZeroString.Length < charCount
            GetCharCountAsZeroString &= "0"
        Loop
    End Function

    Private Function GetIntegerValueMode() As Integer
        Dim e As New WantIntegerValueModeEventArgs
        RaiseEvent WantIntegerValueMode(e)
        Return e.IntegerValueMode
    End Function

End Module

Public Class WantIntegerValueModeEventArgs
    Inherits EventArgs
    Public Property IntegerValueMode As Integer
End Class
