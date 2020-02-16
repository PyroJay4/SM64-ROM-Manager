Imports System.IO
Imports SM64_ROM_Manager.Updating.UpdateInstaller

Namespace Global.UpdateInstaller

    Public Module AddOn

        Public Sub Main(config As UpdateInstallerConfig)
            If config.NewApplicationVersion Is Nothing AndAlso config.CurrentApplicationVersion Is Nothing Then
                For Each dir As String In Directory.GetDirectories(Path.Combine(config.HostApplicationPath, "Data\Tweaks"))
                    If Path.GetFileName(dir) <> "Reviewed" Then
                        Directory.Delete(dir, True)
                    End If
                Next
                For Each dir As String In Directory.GetFiles(Path.Combine(config.HostApplicationPath, "Data\Tweaks"))
                    File.Delete(dir)
                Next
            End If
        End Sub

    End Module

End Namespace
