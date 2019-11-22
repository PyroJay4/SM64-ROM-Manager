Imports System.IO

Friend Module MyPaths

    Public Function GetMyAppDataPath() As String
        Static p As String = String.Empty

        If String.IsNullOrEmpty(p) Then
            p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PilzUpdater")

            If Not Directory.Exists(p) Then
                Directory.CreateDirectory(p)
            End If
        End If

        Return p
    End Function

End Module
