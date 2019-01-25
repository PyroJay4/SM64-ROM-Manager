Imports System.Reflection

Namespace Plugins

    Public Class PluginFunction

        Public ReadOnly Property Method As MethodInfo
        Public ReadOnly Property Plugin As Plugin
        Public ReadOnly Property Params As Object()
        Public ReadOnly Property MenuCode As String

        Public Sub New(method As MethodInfo, plugin As Plugin)
            Me.method = method
            Me.Plugin = plugin
        End Sub

        Public Sub New(method As MethodInfo, plugin As Plugin, params As Object(), menuCode As String)
            Me.New(method, plugin)
            Me.Params = params
            Me.MenuCode = menuCode
        End Sub

        Public Sub Invoke()
            method.Invoke(Nothing, Nothing)
        End Sub

        Public Sub Invoke(ParamArray params As Object())
            method.Invoke(Nothing, params)
        End Sub

        Public Function InvokeGet(ParamArray params As Object()) As Object
            Return method.Invoke(Nothing, params)
        End Function

    End Class

End Namespace
