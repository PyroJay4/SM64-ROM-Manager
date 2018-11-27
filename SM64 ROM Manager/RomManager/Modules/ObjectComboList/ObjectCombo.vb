Namespace LevelEditor

    Public Class ObjectCombo

        Public Property Name As String = "Unknown Combo"
        Public Property ModelID As Byte = 0
        Public Property ModelAddress As Integer = 0
        Public Property BehaviorAddress As UInteger = 0
        Public Property BParam1 As New BParam
        Public Property BParam2 As New BParam
        Public Property BParam3 As New BParam
        Public Property BParam4 As New BParam

        Public Class BParam
            Public Property Name As String = "New B. Param"
            Public Property Description As String = ""
        End Class

    End Class

End Namespace
