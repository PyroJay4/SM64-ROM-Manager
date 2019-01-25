Imports System.IO
Imports System.Reflection

Namespace Plugins

    Public Class PluginManager

        Public ReadOnly Property PluginPath As String
        Public ReadOnly Property Plugins As New Dictionary(Of String, Plugin)

        Public Sub New(pluginPath As String)
            Me.PluginPath = pluginPath
        End Sub

        Public Sub LoadPlugins()
            For Each f As String In Directory.GetFiles(PluginPath, "*.dll", SearchOption.AllDirectories)
                LoadPlugin(f)
            Next
        End Sub

        Public Sub LoadPlugin(filePath As String)
            Try
                Dim plugin As New Plugin(filePath)
                Plugins.Add(filePath, plugin)
            Catch ex As Exception
            End Try
        End Sub

        Public Function GetAllImplementMethods(ParamArray menuCodes As String()) As IEnumerable(Of PluginFunction)
            Dim list As New List(Of PluginFunction)

            For Each kvp In Plugins
                list.AddRange(kvp.Value.GetImplementMethods(menuCodes))
            Next

            Return list
        End Function

        Public Function GetAllImplementMethod(menuCode As String) As PluginFunction
            For Each kvp In Plugins
                For Each f As PluginFunction In kvp.Value.GetImplementMethods(menuCode)
                    Return f
                Next
            Next

            Return Nothing
        End Function

    End Class

End Namespace
