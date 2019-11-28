Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json.Linq

Public Class UpdateClient

    'E b v e n t s

    Public Event UpdateStatusChanged(newStatus As UpdateStatus, progress As Integer)
    Public Event DownloadingUpdate(pkg As UpdatePackageInfo, e As CancelEventArgs)
    Public Event InstallingUpdate(pkg As UpdatePackageInfo, e As CancelEventArgs)
    Public Event UpdateInstallerStarted()
    Public Event NoUpdatesFound()

    'F i e l d s

    Private ReadOnly dicPackagePaths As New Dictionary(Of UpdatePackageInfo, String)
    Private curDownloadingStatus As UpdateStatus = UpdateStatus.Waiting

    'P r o p e r t i e s

    Public ReadOnly Property WebClient As New WebClient
    Public ReadOnly Property UpdateUrl As String
    Public ReadOnly Property CurrentVersion As ApplicationVersion
    Public ReadOnly Property MinimumChannel As Channels
    Public ReadOnly Property UpdateInfo As UpdateInfo = Nothing
    Public ReadOnly Property UpdatePackageInfo As UpdatePackageInfo = Nothing
    Public Property AutoCloseHostApplication As Boolean = False
    Public Property AutoRestartHostApplication As Boolean = False
    Public Property RestartHostApplicationArguments As String
    Public Property HostApplicationPath As String = String.Empty
    Public Property ApplicationName As String = String.Empty
    Public Property InstallAsAdmin As Boolean = False
    Public Property MillisecondsToWaitForHostApplicationToClose As UInteger = 10000
    Public Property ForceClosingHostApplication As Boolean = True
    Public Property UpdateWindowBaseColor As Color = Color.FromArgb(&HFFB7472A)
    Public Property UpdateWindowCanvasColor As Color = Color.FromArgb(&HFFFFFFFF)

    'C o n s t r u c t o r s

    Public Sub New(updateUrl As String, currentVersion As ApplicationVersion, minimumChannel As Channels)
        Me.UpdateUrl = updateUrl
        Me.CurrentVersion = currentVersion
        Me.MinimumChannel = minimumChannel
        AddHandler WebClient.DownloadProgressChanged, AddressOf WebClient_DownloadProgressChanged
    End Sub

    'E v e n t   M e t h o d s

    Private Function RaiseDownloadingUpdate(pkg As UpdatePackageInfo) As Boolean
        Dim e As New CancelEventArgs(False)
        RaiseEvent DownloadingUpdate(pkg, e)
        Return e.Cancel
    End Function

    Private Function RaiseInstallingUpdate(pkg As UpdatePackageInfo) As Boolean
        Dim e As New CancelEventArgs(True)
        RaiseEvent InstallingUpdate(pkg, e)
        Return e.Cancel
    End Function

    'W e b C l i e n t   E v e n t s

    Private Sub WebClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        RaiseUpdateStatusChanged(curDownloadingStatus, e.ProgressPercentage)
    End Sub

    'U p d a t e   R o u t i n e s

    Public Function UpdateInteractiveAsync() As Task
        Return Task.Run(AddressOf UpdateInteractive)
    End Function

    Public Sub UpdateInteractive()
        Dim latestVersion As UpdatePackageInfo = CheckForUpdate()
        If latestVersion Is Nothing Then
            RaiseEvent NoUpdatesFound()
        Else
            UpdateInteractive(latestVersion)
        End If
    End Sub

    Public Sub UpdateInteractive(package As UpdatePackageInfo)
        If Not RaiseDownloadingUpdate(package) AndAlso DownloadPackage(package) Then
            If Not RaiseInstallingUpdate(package) Then
                InstallPackage(package)
            End If
        End If
    End Sub

    Public Sub RaiseUpdateStatusChanged(newStatus As UpdateStatus, Optional progress As Integer = -1)
        RaiseEvent UpdateStatusChanged(newStatus, progress)
    End Sub

    'F e a t u r e s

    Public Function GetUpdateInfo() As UpdateInfo
        Dim str As String = WebClient.DownloadString(UpdateUrl)
        Dim info As UpdateInfo = UpdateInfo.Parse(str)
        Return info
    End Function

    Public Function CheckForUpdate() As UpdatePackageInfo
        RaiseUpdateStatusChanged(UpdateStatus.Searching)

        _UpdateInfo = GetUpdateInfo()

        If UpdateInfo IsNot Nothing Then
            Return CheckForUpdate(UpdateInfo)
        Else
            Return Nothing
        End If
    End Function

    Public Function CheckForUpdate(updateInfo As UpdateInfo) As UpdatePackageInfo
        Dim foundPkgInfo As UpdatePackageInfo = Nothing
        Dim latestVersion As ApplicationVersion = CurrentVersion

        RaiseUpdateStatusChanged(UpdateStatus.Searching)

        For Each pkgInfo As UpdatePackageInfo In updateInfo.Packages
            If pkgInfo.Version.Channel <= MinimumChannel AndAlso pkgInfo.Version > latestVersion Then
                foundPkgInfo = pkgInfo
                latestVersion = pkgInfo.Version
            End If
        Next

        _UpdatePackageInfo = foundPkgInfo
        Return foundPkgInfo
    End Function

    Public Function DownloadPackage(package As UpdatePackageInfo) As Boolean
        curDownloadingStatus = UpdateStatus.DownloadingPackage
        RaiseUpdateStatusChanged(curDownloadingStatus)

        Dim dirPath As String = Path.Combine(GetMyAppDataPath, package.GetHashCode)
        Dim zipPath As String = Path.Combine(dirPath, ZIP_PACKAGE_FILENAME)
        Dim dir As New DirectoryInfo(dirPath)

        Try
            'Ensure existing and empty directory for the Zip File
            If dir.Exists Then
                dir.Delete(True)
            End If
            dir.Create()

            'Download zip package
            WebClient.DownloadFile(package.Packagelink, zipPath)

            'Remember path to package directory
            dicPackagePaths.Add(package, dirPath)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function DownloadUpdateInstaller() As FileInfo
        curDownloadingStatus = UpdateStatus.DownloadingInstaller
        RaiseUpdateStatusChanged(curDownloadingStatus)

        'Ensure update installer path is empty
        Dim installerDirPath As New DirectoryInfo(Path.Combine(GetMyAppDataPath, "UpdateInstallerTool"))
        If installerDirPath.Exists Then
            installerDirPath.Delete(True)
        End If
        Task.Delay(100)
        installerDirPath.Create()
        Task.Delay(100)

        'Download update installer zip
        Dim installerZipPath As String = Path.Combine(installerDirPath.FullName, "UpdatenInstaller.zip")
        WebClient.DownloadFile(UpdateInfo.UpdateInstallerLink, installerZipPath)

        'Extract update installer
        Dim installerExtractPath As DirectoryInfo = installerDirPath.CreateSubdirectory("extracted")
        ZipFile.ExtractToDirectory(installerZipPath, installerExtractPath.FullName)
        File.Delete(installerZipPath)

        'Get UpdateInstaller.exe file
        Return installerExtractPath.EnumerateFiles("*.exe").FirstOrDefault
    End Function

    Private Sub StartUpdateInstaller(packagePath As String, installerPath As String)
        RaiseUpdateStatusChanged(UpdateStatus.StartingInstaller)

        'Create update settings
        Dim updateConfig As New UpdateInstallerConfig With {
            .PackagePath = packagePath,
            .RestartHostApplication = AutoRestartHostApplication,
            .RestartHostApplicationArguments = If(AutoRestartHostApplication, RestartHostApplicationArguments, String.Empty),
            .ApplicationName = ApplicationName,
            .HostApplicationPath = If(String.IsNullOrEmpty(HostApplicationPath), Path.GetDirectoryName(Assembly.GetEntryAssembly.Location), HostApplicationPath),
            .HostApplicationProcessPath = Assembly.GetEntryAssembly.Location,
            .MillisecondsToWaitForHostApplicationToClose = MillisecondsToWaitForHostApplicationToClose,
            .ForceClosingHostApplication = ForceClosingHostApplication,
            .UpdateWindowBaseColor = UpdateWindowBaseColor,
            .UpdateWindowCanvasColor = UpdateWindowCanvasColor
        }

        'Start UpdateInstaller
        Dim procStartInfo As New ProcessStartInfo With {
            .FileName = installerPath,
            .Arguments = updateConfig.ToString,
            .UseShellExecute = False,
            .Verb = If(InstallAsAdmin, "runas", String.Empty)
        }
        Process.Start(procStartInfo)

        RaiseEvent UpdateInstallerStarted()
    End Sub

    Public Function InstallPackage(package As UpdatePackageInfo) As Boolean
        Dim packagePath As String = Nothing
        Dim hasDownloaded As Boolean = dicPackagePaths.TryGetValue(package, packagePath)

        If hasDownloaded Then
            'Download update installer
            Dim installerPath As FileInfo = DownloadUpdateInstaller()

            'Start update installer
            StartUpdateInstaller(packagePath, installerPath.FullName)

            'Close Host Application
            If AutoCloseHostApplication Then
                Environment.Exit(Environment.ExitCode)
            End If
        End If

        Return hasDownloaded
    End Function

End Class
