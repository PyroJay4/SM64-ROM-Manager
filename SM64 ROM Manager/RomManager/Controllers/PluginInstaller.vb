Imports System.Reflection
Imports Pilz.Reflection.PluginSystem

Public Module PluginInstaller

    Public Function GetAllPlugins() As IEnumerable(Of PluginInfo)
        Dim list As New List(Of PluginInfo)

        For Each kvp In Publics.PluginManager.Plugins
            list.Add(New PluginInfo(kvp.Value))
        Next

        Return list
    End Function

    Public Sub RemovePlugin(p As PluginInfo)

    End Sub

    Public Sub InstallPluginFromSingleFile(p As PluginInfo)

    End Sub

    Public Sub InstallPluginFromZipFile(p As PluginInfo)

    End Sub

    Public Sub InstallPluginFromDirectory(p As PluginInfo)

    End Sub

    Public Class PluginInfo

        Public ReadOnly Property Plugin As Plugin
        Public ReadOnly Property Name As String
        Public ReadOnly Property Version As Version
        Public ReadOnly Property Developer As String
        Public ReadOnly Property Location As String

        Public Sub New(p As Plugin)
            Plugin = p

            Dim asmName As AssemblyName = p.Assembly.GetName
            Name = asmName.Name
            Version = asmName.Version

            Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(p.Assembly.Location)
            Developer = fvi.CompanyName

            Location = p.Assembly.Location
        End Sub

    End Class

End Module
