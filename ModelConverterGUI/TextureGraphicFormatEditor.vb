Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports DevComponents.Editors
Imports N64Graphics
Imports Publics
Imports S3DFileParser

Public Class TextureGraphicFormatEditor

    Private LoadingTextures As Boolean = False
    Private obj3d As Object3D = Nothing
    Public Property TextureFormatSettings As SM64Lib.Model.Fast3D.TextureFormatSettings = Nothing
    Private loadingtexItemSettings As Boolean = False

    Public Sub New(obj As Object3D)
        Me.SuspendLayout()

        InitializeComponent()

        obj3d = obj
        AcceptButton = Button_SaveColsettings

        UpdateAmbientColors()

        Me.ResumeLayout()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadN64TextureFormatTypes()
        LoadTexturesFromModel()
    End Sub

    Private Sub LoadTexturesFromModel()
        Dim firstItem As ListViewItem = Nothing
        Dim imgList As New ImageList

        'Clear Items
        ListViewEx1.Items.Clear()

        'Setup Imagelist
        imgList.ImageSize = New Size(64, 64)
        ListViewEx1.LargeImageList = imgList

        For Each mat As KeyValuePair(Of String, Material) In obj3d.Materials
            If mat.Value.Image IsNot Nothing Then
                Dim item As New ListViewItem
                item.Text = mat.Key
                item.ImageIndex = imgList.Images.Count
                item.Tag = mat
                imgList.Images.Add(mat.Value.Image)
                If firstItem Is Nothing Then firstItem = item
                ListViewEx1.Items.Add(item)
            End If
        Next

        'Select First Item
        If firstItem IsNot Nothing Then
            firstItem.Selected = True
        End If

        ListViewEx1.Refresh()
    End Sub

    Private Sub LoadN64TextureFormatTypes()
        ComboBox_ColType.SuspendLayout()
        ComboBox_ColType.Items.Clear()

        Dim eType As Type = GetType(N64Codec)
        Dim names As String() = [Enum].GetNames(eType)
        Dim values As Integer() = [Enum].GetValues(eType)

        For i As Integer = 0 To names.Count - 2
            Dim item As New ComboItem
            item.Text = names(i)
            item.Tag = N64Graphics.N64Graphics.CodecString(values(i))
            ComboBox_ColType.Items.Add(item)
        Next

        ComboBox_ColType.ResumeLayout()
    End Sub

    Private Sub ListBoxAdv_CI_Textures_ItemClick(sender As Object, e As EventArgs) Handles ListViewEx1.SelectedIndexChanged
        If ListViewEx1.SelectedIndices.Count > 0 Then
            Dim curItem As ListViewItem = ListViewEx1.SelectedItems(0)
            Dim matName As String = curItem.Tag.Key
            Dim curEntry As SM64Lib.Model.Fast3D.TextureFormatSettings.Entry = TextureFormatSettings.GetEntry(matName)
            Dim found As Boolean = False

            loadingtexItemSettings = True

            For Each item As ComboItem In ComboBox_ColType.Items
                If item.Tag = curEntry.TextureFormat Then
                    ComboBox_ColType.SelectedItem = item
                    found = True
                    Exit For
                End If
            Next

            If curItem.ImageIndex > -1 Then
                PictureBox1.Image = ListViewEx1.LargeImageList.Images(curItem.ImageIndex)
                'LabelX1.Text = $"Height: {PictureBox1.Image.Size.Height} Width: {PictureBox1.Image.Size.Width} ({PictureBox1.Image.Size.Width * PictureBox1.Image.Size.Height} Pixels)"
            Else
                PictureBox1.Image = Nothing
                LabelX1.Text = ""
            End If

            CheckBoxX_EnableTextureAnimation.Checked = curEntry.IsScrollingTexture

            loadingtexItemSettings = False

            If Not found Then
                ComboBox_ColType.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ComboBox_CI_ColType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ColType.SelectedIndexChanged
        Dim selItem As ComboItem = ComboBox_ColType.SelectedItem
        Dim id As String = selItem.Tag

        LabelX_MaxPixels.Text = $"Maximal Pixels: {SM64Lib.Model.Fast3D.TextureManager.GetMaxPixls(N64Graphics.N64Graphics.StringCodec(id))}"

        If Not loadingtexItemSettings Then
            UpdateTextureListItemSettings(id)
        End If
    End Sub

    Private Sub UpdateTextureListItemSettings(id As String)
        If ListViewEx1.SelectedIndices.Count > 0 Then

            For Each item As ListViewItem In ListViewEx1.SelectedItems
                Dim mat As KeyValuePair(Of String, Material) = item.Tag
                Dim curEntry As SM64Lib.Model.Fast3D.TextureFormatSettings.Entry = TextureFormatSettings.GetEntry(mat.Key)
                curEntry.IsScrollingTexture = CheckBoxX_EnableTextureAnimation.Checked
                curEntry.TextureFormat = id
            Next

        End If
    End Sub

    Private Sub ButtonItem_IsScollTex_Click() Handles CheckBoxX_EnableTextureAnimation.CheckedChanged
        If Not loadingtexItemSettings Then
            Dim selItem As ComboItem = ComboBox_ColType.SelectedItem
            Dim id As String = selItem.Tag
            UpdateTextureListItemSettings(id)
        End If
    End Sub

End Class
