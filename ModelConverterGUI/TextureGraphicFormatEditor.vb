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
    Private hasInit As Boolean = False

    Public Sub New(obj As Object3D)
        Me.SuspendLayout()

        InitializeComponent()

        obj3d = obj
        AcceptButton = Button_SaveColsettings

        LoadDisplayListTypes()
        LoadN64TextureFormatTypes()
        LoadRotateFlip()

        UpdateAmbientColors()

        hasInit = True

        Me.ResumeLayout()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadTexturesFromModel()
    End Sub

    Private Sub LoadDisplayListTypes()
        For Each name As String In [Enum].GetNames(GetType(SM64Lib.Model.Fast3D.TextureFormatSettings.SelectDisplaylistMode))
            ComboBoxEx_SelectDisplaylist.Items.Add(name)
        Next
        ComboBoxEx_SelectDisplaylist.SelectedIndex = 0
    End Sub

    Private Sub LoadRotateFlip()
        With ComboBoxEx_RotateFlip.Items
            .Add(New ComboItem With {.Text = "None", .Tag = RotateFlipType.RotateNoneFlipNone})
            .Add(New ComboItem With {.Text = "Y", .Tag = RotateFlipType.RotateNoneFlipY})
            .Add(New ComboItem With {.Text = "X", .Tag = RotateFlipType.RotateNoneFlipX})
            .Add(New ComboItem With {.Text = "X & Y", .Tag = RotateFlipType.RotateNoneFlipXY})

            '.Add(New ComboItem With {.Text = "None / None", .Tag = RotateFlipType.RotateNoneFlipNone})
            '.Add(New ComboItem With {.Text = "Y / None", .Tag = RotateFlipType.RotateNoneFlipY})
            '.Add(New ComboItem With {.Text = "X / None", .Tag = RotateFlipType.RotateNoneFlipX})
            '.Add(New ComboItem With {.Text = "X & Y / None", .Tag = RotateFlipType.RotateNoneFlipXY})
            '.Add(New ComboItem With {.Text = "Y / 180°", .Tag = RotateFlipType.Rotate180FlipY})
            '.Add(New ComboItem With {.Text = "X / 180°", .Tag = RotateFlipType.Rotate180FlipX})
            '.Add(New ComboItem With {.Text = "X & Y / 180°", .Tag = RotateFlipType.Rotate180FlipXY})
        End With
        ComboBoxEx_RotateFlip.SelectedIndex = 0
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

        For i As Integer = 0 To names.Count - 3
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
            ComboBoxEx_SelectDisplaylist.SelectedIndex = CByte(curEntry.SelectDisplaylistMode)
            CheckBoxX_EnableMirror.Checked = curEntry.EnableMirror
            CheckBoxX_EnableClamp.Checked = curEntry.EnableClamp
            CheckBoxX_EnableCrystalEffect.Checked = curEntry.EnableCrystalEffect
            ComboBoxEx_RotateFlip.SelectedItem = GetRotateFlipComboItem(curEntry.RotateFlip)

            loadingtexItemSettings = False

            If Not found Then
                ComboBox_ColType.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Function GetRotateFlipComboItem(type As RotateFlipType) As ComboItem
        Dim var As ComboItem = Nothing

        For Each item As ComboItem In ComboBoxEx_RotateFlip.Items
            If var Is Nothing AndAlso item.Tag = type Then
                var = item
            End If
        Next

        If var Is Nothing AndAlso ComboBoxEx_RotateFlip.Items.Count > 0 Then
            var = ComboBoxEx_RotateFlip.Items(0)
        End If

        Return var
    End Function

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
                curEntry.SelectDisplaylistMode = ComboBoxEx_SelectDisplaylist.SelectedIndex
                curEntry.EnableMirror = CheckBoxX_EnableMirror.Checked
                curEntry.EnableClamp = CheckBoxX_EnableClamp.Checked
                curEntry.EnableCrystalEffect = CheckBoxX_EnableCrystalEffect.Checked
                curEntry.RotateFlip = CType(ComboBoxEx_RotateFlip.SelectedItem, ComboItem).Tag
            Next

        End If
    End Sub

    Private Sub ButtonItem_IsScollTex_Click(sender As Object, e As EventArgs) Handles CheckBoxX_EnableTextureAnimation.CheckedChanged, ComboBoxEx_SelectDisplaylist.SelectedIndexChanged, CheckBoxX_EnableClamp.CheckedChanged, CheckBoxX_EnableMirror.CheckedChanged, CheckBoxX_EnableCrystalEffect.CheckedChanged, ComboBoxEx_RotateFlip.SelectedIndexChanged
        If hasInit AndAlso Not loadingtexItemSettings Then
            Dim selItem As ComboItem = ComboBox_ColType.SelectedItem
            Dim id As String = selItem.Tag
            UpdateTextureListItemSettings(id)
        End If
    End Sub

End Class
