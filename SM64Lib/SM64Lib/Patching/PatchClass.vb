Imports System.IO
Imports System.Windows.Forms
Imports SM64Lib.Data
Imports SM64Lib.Levels.Script

Namespace Patching

    Public Class PatchClass

        Private data As BinaryData = Nothing

#Region "Other"
        Public Shared Sub ApplyPPF(Romfile As String, PPFFile As String)
            RunProcess(MyFilePaths("ApplyPPF3.exe"), String.Format("a ""{0}"" ""{1}""", Romfile, PPFFile))
        End Sub

        Private Shared Function RunProcess(Filename As String, Optional Args As String = "") As Integer
            Dim p As New Process()
            With p.StartInfo
                .CreateNoWindow = True
                .FileName = Filename
                .Arguments = Args
                .UseShellExecute = False
            End With
            p.Start()
            Do Until p.HasExited : Application.DoEvents() : Loop
            Return p.ExitCode
        End Function
#End Region

#Region "Checksum"
        Public Sub UpdateChecksum(Romfile As String)
            RunProcess(MyFilePaths("rn64crc.exe"), $"""{Romfile}"" -u")
        End Sub

        Public Sub RestoreChecksum()
            data.Position = &H66C
            data.Write(350748678UI)
            data.Position = &H678
            data.Write(369623043UI)
        End Sub
#End Region

#Region "SM64PatchClass"

        Public Sub Open(Romfile As String, OnlyRead As Boolean)
            Open(New BinaryFile(Romfile, FileMode.Open, If(OnlyRead, FileAccess.Read, FileAccess.ReadWrite)))
        End Sub

        Public Sub Open(data As BinaryData)
            Me.data = data
        End Sub

        Public Sub Open(s As Stream)
            Open(New BinaryStreamData(s))
        End Sub

        Public Sub Close()
            data.Close()
        End Sub

#End Region

#Region "Act Selector"
        Public Sub ActSelector_ApplyPatch()
            'Write Original Data
            data.Position = &H1202EC0
            For Each b As Byte In {0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 17} '{0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17}
                data.Write(b)
            Next

            'Update Pointers
            data.Position = &H6F38
            data.Write(&H2B010001UI)
            data.Position = &H6F50
            data.Write(&H8100BC0UI)
            data.Write(0)

            'Write Function
            data.Position = &H1202F00
            For Each b As Byte In {60, 1, 128, 51, 132, 33, 221, 248, 60, 8, 128, 64, 53, 8, 46, 192, 1, 1, 64, 33, 145, 8, 0, 0, 36, 1, 0, 1, 16, 40, 0, 3, 36, 0, 0, 0, 8, 9, 47, 228, 0, 0, 16, 37, 8, 9, 47, 214, 36, 0, 0, 0, 1, 1, 1, 1}
                data.Write(b)
            Next
        End Sub

        Public Property ActSelector_Enabled(LevelID As Integer) As Boolean
            Get
                data.Position = &H1202EC0 + LevelID
                Return Convert.ToBoolean(data.ReadByte)
            End Get
            Set(value As Boolean)
                data.Position = &H1202EC0 + LevelID
                data.Write(If(value, CByte(&H1), CByte(&H0)))
            End Set
        End Property
#End Region

#Region "Hardcoded Camera"

        Public Sub HardcodedCamera_ApplyPatch()
            data.Position = &H41AD8
            data.Write(202378196UI)
            data.Write(2409889856UI)

            data.Position = &H1202F50
            data.Write(666763240UI)
            data.Write(2948530196UI)
            data.Write(1006731315UI)
            data.Write(2216812024UI)
            data.Write(1007190080UI)
            data.Write(889728592UI)
            data.Write(16859169UI)
            data.Write(2433220608UI)
            data.Write(604045313UI)
            data.Write(271056899UI)
            data.Write(603979776UI)
            data.Write(65011720UI)
            data.Write(666697752UI)
            data.Write(201997228UI)
            data.Write(0UI)
            data.Write(2411659284UI)
            data.Write(65011720UI)
            data.Write(666697752UI)

            data.Position = &H1202E50
            For index As Integer = 0 To 43
                data.Write(CByte(&H1))
            Next
        End Sub

        Public Sub HardcodedCamera_DisableAll()
            For i As Integer = 0 To 30
                data.Position = &H1202E50 + GetLevelIDFromIndex(i)
                data.Write(CByte(&H0))
            Next
        End Sub

        Public Sub HardcodedCamera_EnableAll()
            For i As Integer = 0 To 30
                data.Position = &H1202E50 + GetLevelIDFromIndex(i)
                data.Write(CByte(&H1))
            Next
        End Sub

        Public Property HardcodedCamera_Enabled(Levelindex As Integer) As Boolean
            Get
                data.Position = &H1202E50 + GetLevelIDFromIndex(Levelindex)
                If data.ReadByte = &H1 Then Return True Else Return False
            End Get
            Set(value As Boolean)
                If Not data.CanWrite Then Return
                data.Position = &H1202E50 + GetLevelIDFromIndex(Levelindex)
                If value Then
                    data.Write(CByte(&H1))
                Else
                    data.Write(CByte(&H0))
                End If
            End Set
        End Property

#End Region

#Region "Set Lives"

        Public Sub SetPauseMenuWarp(levelID As Int16, areaID As Int16, warpID As Int16)
            'Level ID
            data.Position = &H666A
            data.Write(levelID)

            'Area ID
            data.Position = &H666E
            data.Write(areaID)

            'Warp ID
            data.Position = &H6672
            data.Write(warpID)
        End Sub

#End Region

    End Class

End Namespace
