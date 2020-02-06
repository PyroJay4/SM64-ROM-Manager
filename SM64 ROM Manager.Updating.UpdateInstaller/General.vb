Imports System.IO
Imports System.Reflection

Friend Module General

    Public ReadOnly Property MyAppPath As String
        Get
            Static p As String = String.Empty

            If String.IsNullOrEmpty(p) Then
                p = Path.GetDirectoryName(Assembly.GetEntryAssembly.Location)
            End If

            Return p
        End Get
    End Property

End Module
