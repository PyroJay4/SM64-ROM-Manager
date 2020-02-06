Imports System.IO
Imports System.IO.Compression
Imports System.Reflection

Friend Class UpdateInstaller

    'E v e n t s

    Public Event StatusChanges(sender As Object, e As UpdateInstallerStatusChangedEventArgs)

    'F i e l d s

    Private dataPath As String = String.Empty

    'P r o p e r t i e s

    Public ReadOnly Property Configuration As UpdateInstallerConfig

    'C o n s t r c u t o r s

    Public Sub New(config As UpdateInstallerConfig)
        Configuration = config
    End Sub

    'F e a t u r e s

    Private Sub ChangeStatus(newStatus As UpdateInstallerStatus)
        RaiseEvent StatusChanges(Me, New UpdateInstallerStatusChangedEventArgs(newStatus))
    End Sub

    Public Sub StartHostApplication()
        If Not String.IsNullOrEmpty(Configuration.RestartHostApplication) AndAlso File.Exists(Configuration.HostApplicationProcessPath) Then
            Process.Start(Configuration.HostApplicationProcessPath, Configuration.RestartHostApplicationArguments)
        End If
    End Sub

    Public Sub InstallUpdate()
        'Extract Package
        ChangeStatus(UpdateInstallerStatus.Extracting)
        ExtractPackage()

        'Install Package
        InstallPackage()

        'Delete Package
        ChangeStatus(UpdateInstallerStatus.RemovingFiles)
        DeletePackage()

        'Finish
        ChangeStatus(UpdateInstallerStatus.Done)
    End Sub

    Public Sub WaitForHostApplication()
        Dim forcedKill As Boolean = False
        Dim enabled As Boolean = True
        Dim stw As New Stopwatch
        stw.Start()

        Dim getProcesses =
            Function() As Process()
                Return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Configuration.HostApplicationProcessPath))
            End Function

        Do While enabled
            If getProcesses().Any Then
                If stw.ElapsedMilliseconds >= Configuration.MillisecondsToWaitForHostApplicationToClose Then
                    If Not forcedKill AndAlso Configuration.ForceClosingHostApplication Then
                        For Each p As Process In getProcesses()
                            p.Kill()
                        Next
                        stw.Reset()
                        forcedKill = True
                    Else
                        stw.Stop()
                        enabled = False
                    End If
                End If
            Else
                enabled = False
            End If
        Loop
    End Sub

    Private Sub ExtractPackage()
        Dim packagePath As String = Configuration.PackagePath
        Dim zipPath As String = Path.Combine(packagePath, ZIP_PACKAGE_FILENAME)
        dataPath = Path.Combine(packagePath, Path.GetFileNameWithoutExtension(ZIP_PACKAGE_FILENAME))

        Dim dataPathDir As New DirectoryInfo(dataPath)
        If dataPathDir.Exists Then
            dataPathDir.Delete(True)
            Task.Delay(100)
        End If

        ZipFile.ExtractToDirectory(zipPath, dataPath)
    End Sub

    Private Sub InstallPackage()
        'Copy files
        ChangeStatus(UpdateInstallerStatus.CopyingFiles)
        CopyFiles()

        'Run installation addon
        ChangeStatus(UpdateInstallerStatus.RunningAddons)
        RunAddOns()
    End Sub

    Private Sub CopyFiles()
        Dim sourceDir As New DirectoryInfo(Path.Combine(dataPath, ZIP_APP_DATA_FILES_DIRECTORY))
        Dim destDir As New DirectoryInfo(Configuration.HostApplicationPath)
        CopyFiles(sourceDir, destDir)
    End Sub

    Private Sub CopyFiles(sourceDir As DirectoryInfo, destinationDir As DirectoryInfo)
        If Not destinationDir.Exists Then
            destinationDir.Create()
        End If

        For Each sFile As FileInfo In sourceDir.EnumerateFiles("*", SearchOption.TopDirectoryOnly)
            Dim dFile As New FileInfo(Path.Combine(destinationDir.FullName, sFile.Name))
            Try
                sFile.CopyTo(dFile.FullName, True)
            Catch ex As Exception
            End Try
        Next

        For Each sDir As DirectoryInfo In sourceDir.EnumerateDirectories("*", SearchOption.TopDirectoryOnly)
            Dim dDir As DirectoryInfo = destinationDir.CreateSubdirectory(sDir.Name)
            CopyFiles(sDir, dDir)
        Next
    End Sub

    Private Sub RunAddOns()
        For Each addOnPath As String In Directory.GetFiles(Path.Combine(MyAppPath, "AddOns")) 'Directory.GetFiles(Path.Combine(dataPath, ZIP_UPDATE_INSTALLER_ADDONS_DIRECTORY))
            Dim asm As Assembly = Assembly.LoadFile(addOnPath)
            Dim t As Type = asm.GetType($"{UPDATE_INSTALLER_ADDON_NAMESPACE}.{UPDATE_INSTALLER_ADDON_TYPE}", False)

            If t IsNot Nothing Then
                Dim m As MethodInfo = t.GetMethod(UPDATE_INSTALLER_ADDON_METHOD, BindingFlags.Static Or BindingFlags.Public)
                'Dim dicParams As New Dictionary(Of String, Object) From {
                '    {"hostAppPath", Configuration.HostApplicationPath},
                '    {"curAppVersion", Configuration.CurrentApplicationVersion},
                '    {"newAppVersion", Configuration.NewApplicationVersion}
                '}
                m.Invoke(Nothing, {Configuration})
            End If
        Next
    End Sub

    Private Sub DeletePackage()
        Directory.Delete(Configuration.PackagePath, True)
    End Sub

End Class
