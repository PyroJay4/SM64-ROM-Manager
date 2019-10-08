Imports Pilz.Reflection.PluginSystem

Public Class PluginInstaller

    Public Function GetAllPlugins() As IEnumerable(Of Plugin)
        Return Publics.PluginManager.Plugins
    End Function

    Public Sub RemovePlugin(p As Plugin)

    End Sub

    Public Sub InstallSingleFile()

    End Sub

    Public Sub InstallZipFile()

    End Sub

    Public Sub InstallDirectory()

    End Sub

End Class
