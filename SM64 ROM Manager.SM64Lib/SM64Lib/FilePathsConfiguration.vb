Public Class FilePathsConfiguration

    'S T A T I C   M E M B E R S

    Public Shared ReadOnly Property DefaultConfiguration As New FilePathsConfiguration

    Public Shared ReadOnly Property AllFileKeys As String()
        Get
            Return {
                "rn64crc.exe",
                "Apply 3D Coins.ppf",
                "Remove 3D Coins.ppf",
                "ApplyPPF3.exe",
                "Level Tabel.json",
                "Update-Patches.json",
                "Update Patches Folder",
                "Text Profiles.json",
                "SM64_ROM_Manager.ppf",
                "sm64extend.exe",
                "Original Level Pointers.bin"
            }
        End Get
    End Property

    'F I E L D S

    Private ReadOnly dic As New Dictionary(Of String, String)

    'P R O P E R T I E S

    Public ReadOnly Property Files As IReadOnlyDictionary(Of String, String)
        Get
            Return dic
        End Get
    End Property

    'C O N S T R U C T O R

    Public Sub New()
        For Each key As String In AllFileKeys
            dic.Add(key, String.Empty)
        Next
    End Sub

    'M E T H O D S

    Public Sub SetFilePath(key As String, path As String)
        dic(key) = path
    End Sub

End Class
