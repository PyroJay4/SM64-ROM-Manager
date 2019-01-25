Namespace Attributes

    Public Class MenuEntryMethodAttribute
        Inherits Attribute

        Public ReadOnly Property MenuCode As String
        Public ReadOnly Property Params As Object()

        Public Sub New(menuCode As String, ParamArray params As Object())
            Me.MenuCode = menuCode
            Me.Params = params
        End Sub

    End Class

End Namespace
