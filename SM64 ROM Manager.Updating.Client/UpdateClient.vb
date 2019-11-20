Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json.Linq

Public Class UpdateClient

    'F i e l d s

    Private ReadOnly dicPackagePaths As New Dictionary(Of UpdatePackageInfo, String)

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
    End Sub

    'P r i v a t e   F e a t u r e s

    Private Function GetMyAppDataPath() As String
        Static p As String = String.Empty

        If String.IsNullOrEmpty(p) Then
            p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "")

            If Not Directory.Exists(p) Then
                Directory.CreateDirectory(p)
            End If
        End If

        Return p
    End Function

    'U p d a t e   R o u t i n e s

    Public Sub UpdateInteractive()
        Dim latestVersion As UpdatePackageInfo = CheckForUpdate()
        If latestVersion IsNot Nothing Then
            UpdateInteractive(latestVersion)
        End If
    End Sub

    Public Sub UpdateInteractive(package As UpdatePackageInfo)
        If DownloadPackage(package) Then
            InstallPackage(package)
        End If
    End Sub

    'F e a t u r e s

    Public Function GetUpdateInfo() As UpdateInfo
        Dim str As String = WebClient.DownloadString(UpdateUrl)
        Dim info As UpdateInfo = UpdateInfo.Parse(str)
        Return info
    End Function

    Public Function CheckForUpdate() As UpdatePackageInfo
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

    Public Function InstallPackage(package As UpdatePackageInfo) As Boolean
        Dim packagePath As String = Nothing
        Dim hasDownloaded As Boolean = dicPackagePaths.TryGetValue(package, packagePath)

        If hasDownloaded Then
            'Download update installer
            Dim installerPath As String = Path.Combine(GetMyAppDataPath, "UpdateInstaller.exe")
            If File.Exists(installerPath) Then
                File.Delete(installerPath)
            End If
            WebClient.DownloadFile(UpdateInfo.UpdateInstallerLink, installerPath)

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

            'Close Host Application
            If AutoCloseHostApplication Then
                Environment.Exit(0)
            End If
        End If

        Return hasDownloaded
    End Function

End Class
