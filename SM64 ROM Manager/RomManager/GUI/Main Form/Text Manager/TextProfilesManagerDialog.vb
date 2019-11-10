Imports DevComponents.DotNetBar
Imports SM64Lib.Text.Profiles

Public Class TextProfilesManagerDialog

    'C o n s t a n t s

    Private Const IMPORT_EXPORT_DIALOG_FILTER As String = "JSON (*.json)|*.json"

    'P r o p e r t i e s

    Public Property MyTextProfiles As MyTextProfileInfoManager

    'C o n s t r u c t o r s

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors
    End Sub

    'F e a t u r e s

    Private Sub LoadList()
        Dim itemToSelect As BaseItem = Nothing

        ItemPanel_Profiles.BeginUpdate()

        For Each info As TextProfileInfo In MyTextProfiles.Manager.GetTextProfiles
            Dim newItem As BaseItem = AddToItemPanel(info)
            If itemToSelect Is Nothing Then
                itemToSelect = newItem
            End If
        Next

        ItemPanel_Profiles.EndUpdate()
        ItemPanel_Profiles.SelectedItem = itemToSelect
    End Sub

    Private Sub LoadProfile(info As TextProfileInfo)
        Dim isNull As Boolean = info Is Nothing
        Dim canEdit As Boolean = Not isNull AndAlso info IsNot MyTextProfiles.Manager.DefaultTextProfileInfo

        ButtonX_Delete.Enabled = canEdit
        ButtonX_Export.Enabled = canEdit
        ButtonX_Edit.Enabled = canEdit
        TextBoxX_ProfileName.Enabled = Not isNull
        TextBoxX_ProfileName.ReadOnly = Not canEdit
        TextBoxX_ProfileName.Text = If(isNull, String.Empty, info.Name)
    End Sub

    Private Function GetSelectedProfile() As TextProfileInfo
        Return ItemPanel_Profiles.SelectedItem?.Tag
    End Function

    Private Sub CreateProfile()
        Dim info As TextProfileInfo = MyTextProfiles.Manager.CreateTextProfile
        MyTextProfiles.SaveTextProfile(info)

        Dim item As BaseItem = AddToItemPanel(info)
        ItemPanel_Profiles.Refresh()
        ItemPanel_Profiles.SelectedItem = item
        ItemPanel_Profiles.EnsureVisible(item)
    End Sub

    Private Function AddToItemPanel(info As TextProfileInfo) As BaseItem
        Dim btn As New ButtonItem With {
            .Tag = info,
            .Text = info.Name
        }

        AddHandler btn.Click,
            Sub(sender, e)
                ItemPanel_Profiles.SelectedItem = sender
            End Sub

        ItemPanel_Profiles.Items.Add(btn)

        Return btn
    End Function

    Private Sub EditProfile(info As TextProfileInfo)
        Dim editor As New TextProfileEditor With {
            .ProfileInfo = info
        }
        editor.ShowDialog()
        MyTextProfiles.SaveTextProfile(info)
    End Sub

    Private Sub RemoveProfile(info As TextProfileInfo)
        MyTextProfiles.RemoveTextProfile(info)

        Dim items As BaseItem() = New BaseItem(ItemPanel_Profiles.Items.Count - 1) {}
        ItemPanel_Profiles.Items.CopyTo(items, 0)

        ItemPanel_Profiles.BeginUpdate()
        For Each item As BaseItem In items
            If item?.Tag Is info Then
                ItemPanel_Profiles.Items.Remove(item)
            End If
        Next
        ItemPanel_Profiles.EndUpdate()
    End Sub

    Private Sub SetProfileName(info As TextProfileInfo, newName As String)
        If info IsNot Nothing AndAlso Not String.IsNullOrEmpty(Text) Then
            info.Name = newName
            UpdateItems(info)
        End If
    End Sub

    Private Sub UpdateItems(info As TextProfileInfo)
        ItemPanel_Profiles.BeginUpdate()

        For Each item As BaseItem In ItemPanel_Profiles.Items
            If item.Tag Is info Then
                item.Text = info.Name
            End If
        Next

        ItemPanel_Profiles.EndUpdate()
    End Sub

    Private Sub Import()
        Dim ofd_ImportTextProfileInfo As New OpenFileDialog With {
            .Filter = IMPORT_EXPORT_DIALOG_FILTER
        }

        If ofd_ImportTextProfileInfo.ShowDialog = DialogResult.OK Then
            Dim info As TextProfileInfo = MyTextProfiles.Import(ofd_ImportTextProfileInfo.FileName)
            Dim item As BaseItem = AddToItemPanel(info)
            ItemPanel_Profiles.SelectedItem = item
        End If
    End Sub

    Private Sub Export(info As TextProfileInfo)
        Dim sfd_ExportTextProfileInfo As New SaveFileDialog With {
            .Filter = IMPORT_EXPORT_DIALOG_FILTER
        }

        If sfd_ExportTextProfileInfo.ShowDialog = DialogResult.OK Then
            MyTextProfiles.Export(info, sfd_ExportTextProfileInfo.FileName)
        End If
    End Sub

    'G U I

    Private Sub ButtonX_Create_Click(sender As Object, e As EventArgs) Handles ButtonX_Create.Click
        CreateProfile()
    End Sub

    Private Sub ButtonX_Edit_Click(sender As Object, e As EventArgs) Handles ButtonX_Edit.Click
        EditProfile(GetSelectedProfile)
    End Sub

    Private Sub ButtonX_Delete_Click(sender As Object, e As EventArgs) Handles ButtonX_Delete.Click
        RemoveProfile(GetSelectedProfile)
    End Sub

    Private Sub TextBoxX_ProfileName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ProfileName.TextChanged
        SetProfileName(GetSelectedProfile, TextBoxX_ProfileName.Text.Trim)
    End Sub

    Private Sub ButtonX_Import_Click(sender As Object, e As EventArgs) Handles ButtonX_Import.Click
        Import()
    End Sub

    Private Sub ButtonX_Export_Click(sender As Object, e As EventArgs) Handles ButtonX_Export.Click
        Export(GetSelectedProfile)
    End Sub

    Private Sub ItemPanel_Profiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemPanel_Profiles.SelectedIndexChanged
        LoadProfile(GetSelectedProfile)
    End Sub

    Private Sub TextProfilesManagerDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadList()
    End Sub

    Private Sub TextProfilesManagerDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MyTextProfiles.SaveAllTextProfile()
    End Sub

End Class
