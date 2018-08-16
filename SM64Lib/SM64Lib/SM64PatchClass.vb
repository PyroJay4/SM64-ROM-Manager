Imports System.IO
Imports System.Windows.Forms

Namespace Global.SM64Lib.Patching

    Public Class SM64PatchClass

        Private IsFsByRef As Boolean = False
        Private fs As Stream = Nothing
        Private bw As BinaryWriter = Nothing
        Private br As BinaryReader = Nothing

#Region "Other"
        Public Sub ApplyPPF(Romfile As String, PPFFile As String)
            RunProcess(MyDataPath & "\Tools\ApplyPPF3.exe", String.Format("a ""{0}"" ""{1}""", Romfile, PPFFile))
        End Sub

        Private Function RunProcess(Filename As String, Optional Args As String = "") As Integer
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
            RunProcess(MyDataPath & "\Tools\rn64crc.exe", $"""{Romfile}"" -u")
            'RunProcess(pAppData & "\Tools\chksum64.exe", $"""{Romfile}"" -o")
        End Sub

        Public Sub RestoreChecksum()
            fs.Position = &H66C
            bw.Write(SwapInts.SwapUInt32(350748678))
            fs.Position = &H678
            bw.Write(SwapInts.SwapUInt32(369623043))
        End Sub
#End Region

#Region "SM64PatchClass"
        Public Sub Openfs(Romfile As String, OnlyRead As Boolean)
            fs.Dispose()
            Openfs(New FileStream(Romfile, FileMode.Open, If(OnlyRead, FileAccess.Read, FileAccess.ReadWrite)))
            IsFsByRef = False
        End Sub

        Public Sub Openfs(ByRef fs As Stream)
            Me.fs = fs
            br = New BinaryReader(fs)
            If fs.CanWrite Then bw = New BinaryWriter(fs)
            IsFsByRef = True
        End Sub

        Public Sub Closefs()
            If IsFsByRef Then fs.Close()
        End Sub
#End Region

#Region "Act Selector"
        Public Sub ActSelector_ApplyPatch()
            fs.Position = &H1202EC0
            For Each b As Byte In {0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &HF}
                bw.Write(b)
            Next
            fs.Position = &H6F38
            bw.Write(SwapInts.SwapUInt32(&H2B010001))
            fs.Position = &H6F50
            bw.Write(SwapInts.SwapUInt32(&H8100BC0))
            fs.Position = &H1202F00
            For Each b As Byte In {60, 1, 128, 51, 132, 33, 221, 248, 60, 8, 128, 64, 53, 8, 46, 192, 1, 1, 64, 33, 145, 8, 0, 0, 36, 1, 0, 1, 16, 40, 0, 3, 36, 0, 0, 0, 8, 9, 47, 228, 0, 0, 16, 37, 8, 9, 47, 214, 36, 0, 0, 0, 1, 1, 1, 1}
                bw.Write(b)
            Next
        End Sub

        Public Property ActSelector_Enabled(Levelindex As Integer) As Boolean
            Get
                fs.Position = &H1202EC0 + Levelindex
                Return Convert.ToBoolean(br.ReadByte)
            End Get
            Set(value As Boolean)
                fs.Position = &H1202EC0 + Levelindex
                bw.Write(If(value, CByte(&H1), CByte(&H0)))
            End Set
        End Property
#End Region

#Region "Hardcoded Camera"
        Public Sub HardcodedCamera_ApplyPatch()
            fs.Position = &H41AD8
            bw.Write(SwapInts.SwapUInt32(202378196UI))
            bw.Write(SwapInts.SwapUInt32(2409889856UI))
            fs.Position = &H1202F50
            bw.Write(SwapInts.SwapUInt32(666763240UI))
            bw.Write(SwapInts.SwapUInt32(2948530196UI))
            bw.Write(SwapInts.SwapUInt32(1006731315UI))
            bw.Write(SwapInts.SwapUInt32(2216812024UI))
            bw.Write(SwapInts.SwapUInt32(1007190080UI))
            bw.Write(SwapInts.SwapUInt32(889728592UI))
            bw.Write(SwapInts.SwapUInt32(16859169UI))
            bw.Write(SwapInts.SwapUInt32(2433220608UI))
            bw.Write(SwapInts.SwapUInt32(604045313UI))
            bw.Write(SwapInts.SwapUInt32(271056899UI))
            bw.Write(SwapInts.SwapUInt32(603979776UI))
            bw.Write(SwapInts.SwapUInt32(65011720UI))
            bw.Write(SwapInts.SwapUInt32(666697752UI))
            bw.Write(SwapInts.SwapUInt32(201997228UI))
            bw.Write(SwapInts.SwapUInt32(0UI))
            bw.Write(SwapInts.SwapUInt32(2411659284UI))
            bw.Write(SwapInts.SwapUInt32(65011720UI))
            bw.Write(SwapInts.SwapUInt32(666697752UI))
            fs.Position = &H1202E50
            For index As Integer = 0 To 43
                bw.Write(CByte(&H1))
            Next
        End Sub

        Public Sub HardcodedCamera_DisableAll()
            For i As Integer = 0 To 30
                fs.Position = &H1202E50 + GetLevelIDFromIndex(i)
                bw.Write(CByte(&H0))
            Next
        End Sub

        Public Sub HardcodedCamera_EnableAll()
            For i As Integer = 0 To 30
                fs.Position = &H1202E50 + GetLevelIDFromIndex(i)
                bw.Write(CByte(&H1))
            Next
        End Sub

        Public Property HardcodedCamera_Enabled(Levelindex As Integer) As Boolean
            Get
                fs.Position = &H1202E50 + GetLevelIDFromIndex(Levelindex)
                If br.ReadByte = &H1 Then Return True Else Return False
            End Get
            Set(value As Boolean)
                If Not fs.CanWrite Then Return
                fs.Position = &H1202E50 + GetLevelIDFromIndex(Levelindex)
                If value Then
                    bw.Write(CByte(&H1))
                Else : bw.Write(CByte(&H0))
                End If
            End Set
        End Property
#End Region

    End Class

End Namespace
