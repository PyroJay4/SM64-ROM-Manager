Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports DevComponents.Editors
Imports N64Graphics
Imports SM64_ROM_Manager.Publics
Imports Pilz.S3DFileParser
Imports SM64Lib.Model.Fast3D
Imports SM64Lib.Model.Conversion.Fast3DWriting
Imports SM64Lib.Geolayout
Imports SM64_ROM_Manager.ModelConverterGUI.My.Resources

Public Class TextureGraphicFormatEditor

    Private LoadingTextures As Boolean = False
    Private obj3d As Object3D = Nothing
    Public Property TextureFormatSettings As TextureFormatSettings = Nothing
    Private loadingtexItemSettings As Boolean = False
    Private hasInit As Boolean = False
    Private colorImages As New List(Of Integer)
    Private ReadOnly realTextures As New Dictionary(Of Integer, Image)

    Public Sub New(obj As Object3D)
        SuspendLayout()

        InitializeComponent()

        obj3d = obj
        AcceptButton = Button_SaveColsettings

        LoadDisplayListTypes()
        LoadN64TextureFormatTypes()
        LoadRotateFlip()

        UpdateAmbientColors()

        hasInit = True

        ResumeLayout()
    End Sub

    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadTexturesFromModel()
    End Sub

    Private Sub LoadDisplayListTypes()
        ComboBoxEx_SelectDisplaylist.Items.AddRange(
            {
            New ComboItem With {.Text = MainModelconverter_Resources.Automatic},
            New ComboItem With {.Text = $"0 - {MainModelconverter_Resources.Layer0}", .Tag = DefaultGeolayers.SolidAntiAlias},
            New ComboItem With {.Text = $"1 - {MainModelconverter_Resources.Layer1}", .Tag = DefaultGeolayers.Solid},
            New ComboItem With {.Text = $"2 - {MainModelconverter_Resources.Layer2}", .Tag = DefaultGeolayers.SolidDecal},
            New ComboItem With {.Text = $"3 - {MainModelconverter_Resources.Layer3}", .Tag = DefaultGeolayers.TranslucentDecal},
            New ComboItem With {.Text = $"4 - {MainModelconverter_Resources.Layer4}", .Tag = DefaultGeolayers.Alpha},
            New ComboItem With {.Text = $"5 - {MainModelconverter_Resources.Layer5}", .Tag = DefaultGeolayers.Transparent},
            New ComboItem With {.Text = $"6 - {MainModelconverter_Resources.Layer6}", .Tag = DefaultGeolayers.TransparentForeground},
            New ComboItem With {.Text = $"7 - {MainModelconverter_Resources.Layer7}", .Tag = DefaultGeolayers.TranslucentDecal2}
            })
        ComboBoxEx_SelectDisplaylist.SelectedIndex = 0
    End Sub

    Private Sub LoadRotateFlip()
        With ComboBoxEx_RotateFlip.Items
            .Add(New ComboItem With {.Text = "None", .Tag = RotateFlipType.RotateNoneFlipNone})
            .Add(New ComboItem With {.Text = "Y", .Tag = RotateFlipType.RotateNoneFlipY})
            .Add(New ComboItem With {.Text = "X", .Tag = RotateFlipType.RotateNoneFlipX})
            .Add(New ComboItem With {.Text = "X & Y", .Tag = RotateFlipType.RotateNoneFlipXY})
        End With
        ComboBoxEx_RotateFlip.SelectedIndex = 0
    End Sub

    Private Sub LoadTexturesFromModel()
        Dim firstItem As ListViewItem = Nothing
        Dim imgList As New ImageList

        'Clear Items
        ListViewEx1.Items.Clear()
        colorImages.Clear()
        realTextures.Clear()

        'Setup Imagelist
        imgList.ImageSize = New Size(64, 64)
        ListViewEx1.LargeImageList = imgList

        For Each mat As KeyValuePair(Of String, Material) In obj3d.Materials
            Dim imageIndex As Integer = imgList.Images.Count
            Dim item As New ListViewItem With {
                .Text = mat.Key,
                .ImageIndex = imageIndex,
                .Tag = mat
            }

            If mat.Value.Image IsNot Nothing Then
                Dim bmp As Image = ResizeImage(mat.Value.Image, imgList.ImageSize, True, True)
                realTextures.Add(imageIndex, mat.Value.Image)
                imgList.Images.Add(bmp)
            Else
                Dim img As Image = GetImageFromColor(mat.Value.Color, New Size(32, 32))
                colorImages.Add(item.ImageIndex)
                imgList.Images.Add(img)
            End If

            If firstItem Is Nothing Then firstItem = item
            ListViewEx1.Items.Add(item)
        Next

        'Select First Item
        If firstItem IsNot Nothing Then
            firstItem.Selected = True
        End If

        ListViewEx1.Refresh()
    End Sub

    Private Function GetImageFromColor(color As Color, size As Size) As Bitmap
        Dim bmp As New Bitmap(size.Width, size.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(color)
        Return bmp
    End Function

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
            Dim curEntry As TextureFormatSettings.Entry = TextureFormatSettings.GetEntry(matName)
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
                Dim realImg As Image

                If realTextures.ContainsKey(curItem.ImageIndex) Then
                    realImg = realTextures(curItem.ImageIndex)
                Else
                    realImg = ListViewEx1.LargeImageList.Images(curItem.ImageIndex)
                End If

                PictureBox1.Image = realImg
            Else
                PictureBox1.Image = Nothing
                LabelX1.Text = ""
            End If

            CheckBoxX_EnableTextureAnimation.Checked = curEntry.IsScrollingTexture
            CheckBoxX_EnableMirrorS.Checked = curEntry.EnableMirrorS
            CheckBoxX_EnableMirrorT.Checked = curEntry.EnableMirrorT
            CheckBoxX_EnableClampS.Checked = curEntry.EnableClampS
            CheckBoxX_EnableClampT.Checked = curEntry.EnableClampT
            CheckBoxX_EnableCrystalEffect.Checked = curEntry.EnableCrystalEffect
            ComboBoxEx_RotateFlip.SelectedItem = GetRotateFlipComboItem(curEntry.RotateFlip)

            For Each item As ComboItem In ComboBoxEx_SelectDisplaylist.Items
                Select Case curEntry.DisplaylistSelection.SelectionMode
                    Case DisplaylistSelectionMode.Automatic
                        ComboBoxEx_SelectDisplaylist.SelectedIndex = 0
                    Case DisplaylistSelectionMode.Default
                        If item.Tag = curEntry.DisplaylistSelection.DefaultGeolayer Then
                            ComboBoxEx_SelectDisplaylist.SelectedItem = item
                        End If
                End Select
            Next

            Dim enTexTools As Boolean = Not colorImages.Contains(curItem.ImageIndex)
            CheckBoxX_EnableTextureAnimation.Enabled = enTexTools
            CheckBoxX_EnableMirrorS.Enabled = enTexTools
            CheckBoxX_EnableClampS.Enabled = enTexTools
            CheckBoxX_EnableCrystalEffect.Enabled = enTexTools
            ComboBoxEx_RotateFlip.Enabled = enTexTools

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

        LabelX_MaxPixels.Text = $"Maximal Pixels: {GetMaxPixls(N64Graphics.N64Graphics.StringCodec(id))}"

        If Not loadingtexItemSettings Then
            UpdateTextureListItemSettings(id)
        End If
    End Sub

    Private Sub UpdateTextureListItemSettings(id As String)
        If ListViewEx1.SelectedIndices.Count > 0 Then

            For Each item As ListViewItem In ListViewEx1.SelectedItems
                Dim mat As KeyValuePair(Of String, Material) = item.Tag
                Dim curEntry As TextureFormatSettings.Entry = TextureFormatSettings.GetEntry(mat.Key)

                curEntry.IsScrollingTexture = CheckBoxX_EnableTextureAnimation.Checked
                curEntry.TextureFormat = id
                curEntry.EnableMirrorS = CheckBoxX_EnableMirrorS.Checked
                curEntry.EnableMirrorT = CheckBoxX_EnableMirrorT.Checked
                curEntry.EnableClampS = CheckBoxX_EnableClampS.Checked
                curEntry.EnableClampT = CheckBoxX_EnableClampT.Checked
                curEntry.EnableCrystalEffect = CheckBoxX_EnableCrystalEffect.Checked
                curEntry.RotateFlip = CType(ComboBoxEx_RotateFlip.SelectedItem, ComboItem).Tag

                Dim selDL As Object = CType(ComboBoxEx_SelectDisplaylist.SelectedItem, ComboItem).Tag
                If TypeOf selDL Is DefaultGeolayers Then
                    curEntry.DisplaylistSelection.SelectionMode = DisplaylistSelectionMode.Default
                    curEntry.DisplaylistSelection.DefaultGeolayer = selDL
                Else
                    curEntry.DisplaylistSelection.SelectionMode = DisplaylistSelectionMode.Automatic
                End If
            Next

        End If
    End Sub

    Private Sub ButtonItem_IsScollTex_Click(sender As Object, e As EventArgs) Handles CheckBoxX_EnableTextureAnimation.CheckedChanged, ComboBoxEx_SelectDisplaylist.SelectedIndexChanged, CheckBoxX_EnableClampS.CheckedChanged, CheckBoxX_EnableMirrorS.CheckedChanged, CheckBoxX_EnableCrystalEffect.CheckedChanged, ComboBoxEx_RotateFlip.SelectedIndexChanged, CheckBoxX_EnableMirrorT.CheckedChanged, CheckBoxX_EnableClampT.CheckedChanged
        If hasInit AndAlso Not loadingtexItemSettings Then
            Dim selItem As ComboItem = ComboBox_ColType.SelectedItem
            Dim id As String = selItem.Tag
            UpdateTextureListItemSettings(id)
        End If
    End Sub

End Class
