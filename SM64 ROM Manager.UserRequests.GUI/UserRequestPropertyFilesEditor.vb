Imports System.IO
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.UserRequests.GUI.My.Resources

Public Class UserRequestPropertyFilesEditor

    'F i e l d s

    Private ReadOnly prop As UserRequestProperty
    Private ReadOnly files As New List(Of String)

    'C o n s t r u c t o r

    Public Sub New(prop As UserRequestProperty)
        InitializeComponent()
        Me.prop = prop
        MapFiles()
        RefreshList()
    End Sub

    'F e a t u r e s

    Private Sub MapFiles()
        files.Clear()
        If Not String.IsNullOrEmpty(prop.Value) Then
            files.AddRange(UserRequestManager.TranslateFilesStringToArray(prop.Value))
        End If
    End Sub

    Private Sub WriteFiles()
        prop.Value = UserRequestManager.TranslateFilesArrayToString(files.ToArray)
    End Sub

    Private Sub RefreshList()
        ItemPanel_Files.BeginUpdate()
        ItemPanel_Files.Items.Clear()

        For Each f As String In files
            Dim btn As New ButtonItem With {
                .Text = Path.GetFileName(f),
                .Tag = f,
                .Image = Pilz.Win32.Internals.IconExtractor.ExtractIcon(f, True)?.ToBitmap,
                .ButtonStyle = eButtonStyle.ImageAndText,
                .ImagePosition = eImagePosition.Left
            }

            AddHandler btn.Click,
                Sub(sender, e)
                    ItemPanel_Files.SelectedItem = sender
                End Sub

            ItemPanel_Files.Items.Add(btn)
        Next

        ItemPanel_Files.EndUpdate()
        ItemPanel_Files.SelectedIndex = -1
    End Sub

    Private Sub AddFiles()
        Dim ofd_AddUSerRequestFiles As New OpenFileDialog With {
            .Multiselect = True
        }

        If ofd_AddUSerRequestFiles.ShowDialog = DialogResult.OK Then
            For Each f As String In ofd_AddUSerRequestFiles.FileNames
                Dim fi As New FileInfo(f)
                If Not files.Contains(f) Then
                    files.Add(f)
                End If
            Next
        End If

        WriteFiles()
        RefreshList()
    End Sub

    Private Sub RemoveFile()
        Dim index As Integer = ItemPanel_Files.SelectedIndex

        If index >= 0 Then
            files.RemoveAt(index)
        End If

        WriteFiles()
        RefreshList()
    End Sub

    'G u i

    Private Sub ButtonX_Add_Click(sender As Object, e As EventArgs) Handles ButtonX_Add.Click
        AddFiles()
    End Sub

    Private Sub ButtonX_Remove_Click(sender As Object, e As EventArgs) Handles ButtonX_Remove.Click
        RemoveFile()
    End Sub

    Private Sub ItemPanel_Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemPanel_Files.SelectedIndexChanged
        ButtonX_Remove.Enabled = ItemPanel_Files.SelectedIndex >= 0
    End Sub

End Class
