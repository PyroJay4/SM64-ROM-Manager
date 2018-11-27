Namespace LevelEditor

    Public Class BehaviorInfo

        Public Property Name As String = "Unknown Behavior"
        Public Property BehaviorAddress As UInteger = 0
        Public Property BParam1 As New BParam
        Public Property BParam2 As New BParam
        Public Property BParam3 As New BParam
        Public Property BParam4 As New BParam

        Public ReadOnly Property BehaviorAddressText As String
            Get
                Return TextFromValue(BehaviorAddress, Math.Max(1, SettingsManager.Settings.General.IntegerValueMode))
            End Get
        End Property

        Public Class BParam
            Public Property Name As String = "New B. Param"
            Public Property Values As New List(Of BParamValue)
        End Class

        Public Class BParamValue
            Public Property Name As String = ""
            Public Property Value As Byte = 0

            Public ReadOnly Property ValueText As String
                Get
                    Return TextFromValue(Value)
                End Get
            End Property
        End Class

    End Class

End Namespace
