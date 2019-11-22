Imports System.IO
Imports System.IO.Compression

Public Class UpdatePackagePackager

    Public Property UpdatePackageTemplate As UpdatePackageTemplate

    Public Sub New(updatePackageTemplate As UpdatePackageTemplate)
        Me.UpdatePackageTemplate = updatePackageTemplate
    End Sub

    Public Sub Export(exportPath As String)
        Dim tempPath As String = GetMyAppDataPath()
        Dim packageDir As New DirectoryInfo(Path.Combine(tempPath, "UpdatePackageCreation"))

        'Ensure package directory exists and is empty
        If packageDir.Exists Then
            packageDir.Delete()
        End If
        packageDir.Create()

        'Copy local data to temp data directory
        Dim dataDir As DirectoryInfo = packageDir.CreateSubdirectory(ZIP_APP_DATA_FILES_DIRECTORY)
        Dim localDataDir As New DirectoryInfo(UpdatePackageTemplate.FilesToCopyPath)
        localDataDir.CopyTo(dataDir.FullName, SearchOption.AllDirectories)

        'Copy all UpdateInstaller AddOns
        Dim addOnsDir As DirectoryInfo = packageDir.CreateSubdirectory(ZIP_UPDATE_INSTALLER_ADDONS_DIRECTORY)
        Dim curAddOnID As UInteger = 0
        For Each fAddOn As String In UpdatePackageTemplate.UpdateInstallerAddOns
            File.Copy(fAddOn, Path.Combine(addOnsDir.FullName, $"installer_addon_{curAddOnID}.dll"))
            curAddOnID += 1
        Next

        'Export to ZIP
        ZipFile.CreateFromDirectory(packageDir.FullName, exportPath)

        'Delete temp directory
        packageDir.Delete(True)
    End Sub

End Class
