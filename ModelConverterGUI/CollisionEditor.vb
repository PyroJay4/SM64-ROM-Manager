Imports DevComponents.DotNetBar
Imports S3DFileParser
Imports System.Windows.Forms
Imports Publics
Imports System.Drawing
Imports SM64Lib
Imports System.IO
Imports DevComponents.Editors
Imports OfficeOpenXml

Public Class CollisionEditor

    Private Shared terrainTypesComboItems As New List(Of ComboItem)
    Private LoadingColItemSettings As Boolean = False
    Private LoadingTextures As Boolean = False
    Private obj3d As Object3D = Nothing
    Public Property CollisionSettings As Model.Collision.CollisionSettings = Nothing

    Public Sub New(obj As Object3D)
        SuspendLayout()

        InitializeComponent()

        obj3d = obj

        Button_SaveColsettings.Visible = True
        LabelX_CollisionType.Visible = True
        LabelX_Param1.Visible = True
        LabelX_Param2.Visible = True
        ComboBox_ColType.Visible = True
        ComboBox_ColType.Enabled = True
        TextBoxX_ColParam1.Visible = True
        TextBoxX_ColParam2.Visible = True
        TextBoxX_ColParam1.Enabled = True
        TextBoxX_ColParam2.Enabled = True
        LabelX_Param1.Enabled = True
        LabelX_Param2.Enabled = True
        AcceptButton = Button_SaveColsettings

        UpdateAmbientColors()

        TextBoxX1.Enabled = False
        TextBoxX_ColParam1.Enabled = False
        TextBoxX_ColParam2.Enabled = False

        ResumeLayout()
    End Sub

    Private Async Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Await LoadFloorTypes()
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
            Dim item As New ListViewItem
            item.Tag = mat
            item.Text = mat.Key
            If mat.Value.Image IsNot Nothing Then
                item.ImageIndex = imgList.Images.Count
                imgList.Images.Add(mat.Value.Image)
            End If
            If firstItem Is Nothing Then firstItem = item
            ListViewEx1.Items.Add(item)
        Next

        'Select First Item
        If firstItem IsNot Nothing Then
            firstItem.Selected = True
        End If

        ListViewEx1.Visible = True
    End Sub

    Private Async Function LoadFloorTypes() As Task
        If Not terrainTypesComboItems.Any Then
            CircularProgress1.Start
            Await Task.Run(AddressOf LoadFloorTypesFromDatabase)
            CircularProgress1.Stop
        End If

        ComboBox_ColType.Items.Clear()
        ComboBox_ColType.SuspendLayout()
        ComboBox_ColType.Items.AddRange(terrainTypesComboItems.ToArray)
        ComboBox_ColType.ResumeLayout()
    End Function

    Private Sub LoadFloorTypesFromDatabase()
        Dim ws As ExcelWorksheet = SurfaceData.Worksheets("Terrain Hexes")

        If ws.Cells.Rows > 0 Then
            For i As Integer = 2 To ws.Cells.Rows
                If ws.Cells(i, 1).Style.Fill.BackgroundColor.Rgb = "" Then
                    Dim typeDec As String = ws.Cells(i, 1).Value
                    Dim title As String = ws.Cells(i, 3).Value
                    Dim typeByte As Byte

                    If Not String.IsNullOrEmpty(typeDec) AndAlso Not String.IsNullOrEmpty(title) Then
                        If Byte.TryParse(typeDec, typeByte) Then
                            Dim item As New ComboItem
                            Dim desc As String
                            Dim notes As String

                            desc = ws.Cells(i, 5).Value
                            notes = ws.Cells(i, 7).Value

                            item.Text = $"{typeByte.ToString("X2")}: {title}"
                            item.Tag = {typeByte, title, desc, notes}

                            If item IsNot Nothing Then
                                terrainTypesComboItems.Add(item)
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If ws.Cells.Rows = 0 OrElse terrainTypesComboItems.Count = 0 Then
            MessageBox.Show("The collision types table is empty.", "Load Collision Types", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Return
        End If
    End Sub

    Private Sub ListBoxAdv_CI_Textures_ItemClick(sender As Object, e As EventArgs) Handles ListViewEx1.SelectedIndexChanged
        If ListViewEx1.SelectedIndices.Count > 0 Then
            Dim curItem As ListViewItem = ListViewEx1.SelectedItems(0)
            Dim mat As KeyValuePair(Of String, Material) = curItem.Tag
            Dim curEntry As Model.Collision.CollisionSettings.Entry = CollisionSettings.GetEntry(mat.Key)
            Dim found As Boolean = False

            LoadingColItemSettings = True

            For Each item As ComboItem In ComboBox_ColType.Items
                If item.Tag(0) = curEntry.CollisionType Then
                    ComboBox_ColType.SelectedItem = item
                    found = True
                    Exit For
                End If
            Next

            CheckBoxX_IsNonSolid.Checked = curEntry.IsNonSolid

            CheckBoxX1.Checked = Not found

            TextBoxX1.Text = TextFromValue(curEntry.CollisionType)

            TextBoxX_ColParam1.Text = TextFromValue(curEntry.CollisionParam1)
            TextBoxX_ColParam2.Text = TextFromValue(curEntry.CollisionParam2)

            If curItem.ImageIndex > -1 Then
                PictureBox1.Image = ListViewEx1.LargeImageList.Images(curItem.ImageIndex)
            Else
                PictureBox1.Image = Nothing
            End If

            LoadingColItemSettings = False
        End If
    End Sub
    Private Sub ComboBox_CI_ColType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ColType.SelectedIndexChanged, TextBoxX_ColParam1.TextChanged, TextBoxX_ColParam2.TextChanged
        Dim selItem As ComboItem = ComboBox_ColType.SelectedItem
        Dim id As Byte = selItem.Tag(0)

        SetParamTipp(id)
        SetToolTip(selItem.Tag)

        If Not LoadingColItemSettings Then
            UpdateTextureListItemSettings(id)
        End If
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX1.TextChanged
        Dim id As Byte = ValueFromText(TextBoxX1.Text)

        SetParamTipp(id)
        SuperTooltip1.SetSuperTooltip(ComboBox_ColType, Nothing)

        If Not LoadingColItemSettings Then
            UpdateTextureListItemSettings(id)
        End If
    End Sub

    Private Sub SetToolTip(data As Object())
        Dim info As New SuperTooltipInfo

        info.HeaderText = $"{TextFromValue(data(0))}: {data(1)}"
        info.BodyText = $"<u>Description:</u>{data(2)}<br/><br/><u>Notes:</u>{data(3)}"

        SuperTooltip1.SetSuperTooltip(ComboBox_ColType, info)
    End Sub

    Private Sub SetParamTipp(id As Byte)
        Dim tParamsTipp = "<u>Params-Tipp:</u><br></br>"
        Select Case id
            Case 14 'Water torrent force and rotation
                LabelX_ColParamsTipp.Text = tParamsTipp & "Water torrent force and rotation"
                LabelX_ColParamsTipp.Visible = True
                TextBoxX_ColParam1.Enabled = True : TextBoxX_ColParam2.Enabled = True
            Case 44 'Wind direction
                LabelX_ColParamsTipp.Text = tParamsTipp & "Wind direction"
                LabelX_ColParamsTipp.Visible = True
                TextBoxX_ColParam1.Enabled = True : TextBoxX_ColParam2.Enabled = True
            Case 36 'Moving sand direction and force
                LabelX_ColParamsTipp.Text = tParamsTipp & "Moving sand direction and force"
                LabelX_ColParamsTipp.Visible = True
                TextBoxX_ColParam1.Enabled = True : TextBoxX_ColParam2.Enabled = True
            Case 37 'Moving sand direction and force
                LabelX_ColParamsTipp.Text = tParamsTipp & "Moving sand direction and force"
                LabelX_ColParamsTipp.Visible = True
                TextBoxX_ColParam1.Enabled = True : TextBoxX_ColParam2.Enabled = True
            Case 39 'Moving sand direction and force
                LabelX_ColParamsTipp.Text = tParamsTipp & "Moving sand direction and force"
                LabelX_ColParamsTipp.Visible = True
                TextBoxX_ColParam1.Enabled = True : TextBoxX_ColParam2.Enabled = True
            Case 45 'Moving sand direction and force
                LabelX_ColParamsTipp.Text = tParamsTipp & "Moving sand direction and force"
                LabelX_ColParamsTipp.Visible = True
                TextBoxX_ColParam1.Enabled = True : TextBoxX_ColParam2.Enabled = True
            Case Else
                LabelX_ColParamsTipp.Visible = False
                TextBoxX_ColParam1.Enabled = False
                TextBoxX_ColParam2.Enabled = False
        End Select
    End Sub

    Private Sub UpdateTextureListItemSettings(ct As Byte)
        If ListViewEx1.SelectedIndices.Count > 0 Then

            Dim cp1 As Byte = ValueFromText(TextBoxX_ColParam1.Text)
            Dim cp2 As Byte = ValueFromText(TextBoxX_ColParam2.Text)

            For Each item As ListViewItem In ListViewEx1.SelectedItems
                Dim mat As KeyValuePair(Of String, Material) = item.Tag
                Dim curEntry As Model.Collision.CollisionSettings.Entry = CollisionSettings.GetEntry(mat.Key)

                curEntry.CollisionType = ct
                curEntry.CollisionParam1 = cp1
                curEntry.CollisionParam2 = cp2
                curEntry.IsNonSolid = CheckBoxX_IsNonSolid.Checked
            Next

        End If
    End Sub

    Private Sub CheckBoxX1_CheckedChanging(sender As Object, e As EventArgs) Handles CheckBoxX1.CheckedChanged
        TextBoxX1.Enabled = CheckBoxX1.Checked
        ComboBox_ColType.Enabled = Not CheckBoxX1.Checked

        If CheckBoxX1.Checked Then
            TextBoxX1_TextChanged(TextBoxX1, New EventArgs)
        Else
            ComboBox_CI_ColType_SelectedIndexChanged(ComboBox_ColType, New EventArgs)
        End If
    End Sub

    Private Sub ButtonItem_IsNonSolid_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX_IsNonSolid.CheckedChanged
        Panel1.Enabled = Not CheckBoxX_IsNonSolid.Checked
        If Not LoadingColItemSettings Then
            Dim selItem As ComboItem = ComboBox_ColType.SelectedItem
            Dim id As Byte = selItem.Tag(0)
            UpdateTextureListItemSettings(id)
        End If
    End Sub

End Class
