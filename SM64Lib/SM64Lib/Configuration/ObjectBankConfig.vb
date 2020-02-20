Namespace Configuration

    Public Class ObjectBankConfig

        Public ReadOnly Property CustomObjectConfigs As New Dictionary(Of Integer, CustomObjectConfig)

        Public Function GetCustomObjectConfig(id As Integer) As CustomObjectConfig
            Dim conf As CustomObjectConfig = Nothing

            If Not CustomObjectConfigs.TryGetValue(id, conf) Then
                conf = New CustomObjectConfig
            End If

            Return conf
        End Function

    End Class

End Namespace
