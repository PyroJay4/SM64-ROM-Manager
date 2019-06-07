Imports System.Collections.Specialized
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports Microsoft.Win32
Imports Pilz.Reflection.PluginSystem
Imports Pilz.S3DFileParser
Imports SM64_ROM_Manager.SettingsManager

Public Module Publics

    Private allLoaderModules As List(Of File3DLoaderModule) = Nothing
    Private allExporterModules As List(Of File3DLoaderModule) = Nothing

    Public Sub SetVisualTheme()
        Dim setTheme = Nothing

        If Settings.StyleManager.UseWindows10Style Then
            Dim curVers As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion", False)
            If CStr(curVers.GetValue("ProductName", "-")).StartsWith("Windows 10") Then
                Dim keyPersonalize As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", False)
                Dim useapptheme As Integer = keyPersonalize.GetValue("AppsUseLightTheme", 1)
                Select Case useapptheme
                    Case 0
                        setTheme = StyleManagerSettingsStruc.VisualThemeDark
                    Case 1
                        setTheme = StyleManagerSettingsStruc.VisualThemeLight
                End Select
            End If
        End If

        If setTheme Is Nothing Then
            setTheme = Settings.StyleManager.MetroColorParams
        End If

        StyleManager.Style = eStyle.Metro
        StyleManager.MetroColorGeneratorParameters = setTheme
    End Sub

    Public Sub ExportModel(model As Object3D, modul As String)
        ExportModel(model, GetExporterModuleFromID(modul))
    End Sub

    Public Sub ExportModel(model As Object3D, modul As File3DLoaderModule)
        Dim sfd As New SaveFileDialog
        Dim strFilter As String = GetExtensionFilter(modul)
        sfd.Filter = strFilter.Substring(strFilter.IndexOf("|", strFilter.IndexOf("|") + 1) + 1)

        'If modul <> LoaderModule.SimpleFileParser Then
        '    MessageBoxEx.Show("Assimp and Aspose probably crashes at exporting.<br/>Please switch to SimpleFileParser in <b>Settings --> File Parser</b>.<br/>Assimp and Aspose will be working soon.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        If sfd.ShowDialog = DialogResult.OK Then
            'Await model.ToFileAsync(sfd.FileName, modul)
            modul.Invoke(model, sfd.FileName)
        End If
    End Sub

    Private Function GetFileLoaderModuleFromP(p As PluginFunction) As File3DLoaderModule
        Dim dic As New Dictionary(Of String, String)
        p.Invoke(dic)

        Dim convMethod As PluginFunction = p.Plugin.GetFunctions("loadermoduleload").FirstOrDefault(Function(n) n.Params(0) = p.Params(0))

        Return New File3DLoaderModule(p.Params(0),
                                      CType([Delegate].CreateDelegate(GetType(File3DLoaderModule.LoaderAction), convMethod.Method), File3DLoaderModule.LoaderAction),
                                      dic)
    End Function

    Private Function GetFileExporterModuleFromP(p As PluginFunction) As File3DLoaderModule
        Dim dic As New Dictionary(Of String, String)
        p.Invoke(dic)

        Dim convMethod As PluginFunction = p.Plugin.GetFunctions("loadermoduleexport").FirstOrDefault(Function(n) n.Params(0) = p.Params(0))

        Return New File3DLoaderModule(p.Params(0),
                                      CType([Delegate].CreateDelegate(GetType(File3DLoaderModule.ExporterAction), convMethod.Method), File3DLoaderModule.ExporterAction),
                                      dic)
    End Function

    Public Function GetAllLoaderModules() As IEnumerable(Of File3DLoaderModule)
        If allLoaderModules Is Nothing Then
            allLoaderModules = New List(Of File3DLoaderModule)

            allLoaderModules.AddRange(File3DLoaderModule.LoaderModules)

            For Each p In PluginManager.GetFunctions("loadermoduleimpformats")
                allLoaderModules.Add(GetFileLoaderModuleFromP(p))
            Next
        End If

        Return allLoaderModules
    End Function

    Public Function GetAllExporterModules() As IEnumerable(Of File3DLoaderModule)
        If allExporterModules Is Nothing Then
            allExporterModules = New List(Of File3DLoaderModule)

            allExporterModules.AddRange(File3DLoaderModule.ExporterModules)

            For Each p In PluginManager.GetFunctions("loadermoduleexpformats")
                allExporterModules.Add(GetFileExporterModuleFromP(p))
            Next
        End If

        Return allExporterModules
    End Function

    Public Function GetLoaderModuleFromID(moduleID As String) As File3DLoaderModule
        Dim modules = GetAllLoaderModules()
        Return GetFileLoaderModuleFromIDInternal(moduleID, modules, 1)
    End Function

    Public Function GetExporterModuleFromID(moduleID As String) As File3DLoaderModule
        Dim modules = GetAllExporterModules()
        Return GetFileLoaderModuleFromIDInternal(moduleID, modules, 0)
    End Function

    Private Function GetFileLoaderModuleFromIDInternal(moduleID As String, modules As IEnumerable(Of File3DLoaderModule), defaultModule As Integer) As File3DLoaderModule
        If moduleID.StartsWith("#") Then
            Return modules(moduleID.Substring(1))
        Else
            For Each m In modules
                If m.Name = moduleID Then
                    Return m
                End If
            Next
        End If

        Return modules(defaultModule)
    End Function

    Public Function GetLoaderIDFromModule(loaderModule As File3DLoaderModule) As String
        Dim known = File3DLoaderModule.LoaderModules
        Return GetFileLoaderIDFromModule(loaderModule, known)
    End Function

    Public Function GetExporterIDFromModule(loaderModule As File3DLoaderModule) As String
        Dim known = File3DLoaderModule.ExporterModules
        Return GetFileLoaderIDFromModule(loaderModule, known)
    End Function

    Private Function GetFileLoaderIDFromModule(loaderModule As File3DLoaderModule, known As File3DLoaderModule()) As String
        For i As Integer = 0 To known.Count - 1
            If known(i) Is loaderModule Then
                Return "#" & i
            End If
        Next

        Return loaderModule.Name
    End Function



    Public Sub AddRecentFile(ByRef collection As StringCollection, fileName As String)
        If collection.Contains(fileName) Then
            collection.Remove(fileName)
        End If

        collection.Insert(0, fileName)
    End Sub

    Public Sub MergeRecentFiles(ByRef collection As StringCollection)
        Dim toRemove As New List(Of String)

        For Each f As String In collection
            If Not IO.File.Exists(f) Then
                toRemove.Add(f)
            End If
        Next

        For Each f As String In toRemove
            collection.Remove(f)
        Next
    End Sub

End Module
