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
        If Not String.IsNullOrEmpty(Configuration.RestartHostApplication) Then
            Process.Start(Configuration.RestartHostApplication, Configuration.RestartHostApplicationArguments)
        End If
    End Sub

    Public Sub InstallUpdate()
        'Extract Package
        ChangeStatus(UpdateInstallerStatus.Extracting)
        ExtractPackage()

        'Install Package
        InstallPackage()

        'Delete Package
        DeletePackage()

        'Finish
        ChangeStatus(UpdateInstallerStatus.Done)
    End Sub

    Public Sub WaitForHostApplication()
        Dim enabled As Boolean = True
        Dim stw As New Stopwatch
        stw.Start()

        Do While enabled
            If stw.ElapsedMilliseconds >= Configuration.MillisecondsToWaitForHostApplicationToClose Then
                stw.Stop()
                For Each p As Process In Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Configuration.HostApplicationProcessPath))
                    p.Kill()
                    Do Until p.HasExited
                    Loop
                Next
            End If
        Loop
    End Sub

    Private Sub ExtractPackage()
        Dim packagePath As String = Configuration.PackagePath
        Dim zipPath As String = Path.Combine(packagePath, ZIP_PACKAGE_FILENAME)
        dataPath = Path.Combine(packagePath, Path.GetFileNameWithoutExtension(ZIP_PACKAGE_FILENAME))
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

        For Each sFile As FileInfo In sourceDir.EnumerateFiles(String.Empty, SearchOption.TopDirectoryOnly)
            Dim dFile As New FileInfo(Path.Combine(destinationDir.FullName, sFile.Name))

            If dFile.Exists Then
                dFile.Delete()
            End If

            sFile.CopyTo(dFile.FullName)
        Next

        For Each sDir As DirectoryInfo In sourceDir.EnumerateDirectories(String.Empty, SearchOption.TopDirectoryOnly)
            Dim dDir As DirectoryInfo = destinationDir.CreateSubdirectory(sDir.Name)
            CopyFiles(sDir, dDir)
        Next
    End Sub

    Private Sub RunAddOns()
        For Each addOnPath As String In Directory.GetFiles(Path.Combine(dataPath, ZIP_UPDATE_INSTALLER_ADDONS_DIRECTORY))
            Dim asm As Assembly = Assembly.Load(addOnPath)
            Dim t As Type = asm.GetType($"{UPDATE_INSTALLER_ADDON_NAMESPACE}.{UPDATE_INSTALLER_ADDON_TYPE}", False)

            If t IsNot Nothing Then
                Dim m As MethodInfo = t.GetMethod(UPDATE_INSTALLER_ADDON_METHOD, BindingFlags.Static Or BindingFlags.Public)
                Dim dicParams As New Dictionary(Of String, Object) From {
                    {"hostAppPath", Configuration.HostApplicationPath}
                }
                m.Invoke(Nothing, {dicParams})
            End If
        Next
    End Sub

    Private Sub DeletePackage()
        Directory.Delete(Configuration.PackagePath)
    End Sub

End Class
