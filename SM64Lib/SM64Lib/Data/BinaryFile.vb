Imports System.IO

Namespace Global.SM64Lib.Data

    Public Class BinaryFile
        Inherits BinaryStreamData

        Public Sub New(filePath As String, fileMode As FileMode, fileAccess As FileAccess)
            MyBase.New(New FileStream(filePath, fileMode, fileAccess))
        End Sub

    End Class

End Namespace
