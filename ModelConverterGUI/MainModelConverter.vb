Imports System.IO
Imports DevComponents.DotNetBar
Imports SM64Lib.Model
Imports SM64Lib.Levels
Imports SM64Lib
Imports System.Numerics
Imports S3DFileParser
Imports SM64_ROM_Manager.SettingsManager
Imports OpenGLFactory.PreviewN
Imports System.Windows.Forms
Imports System.Drawing
Imports Publics
Imports SM64Lib.Model.Fast3D
Imports ModelConverterGUI.My.Resources
Imports System.Deployment.Application
Imports System.Collections.Specialized

Public Class MainModelConverter

    Private DResult As DialogResult = DialogResult.None
    Public Property ResModel As ObjectModel = Nothing
    Public Property ForceDisplaylist As Geolayout.Geolayer = -1
    Private objSettings As New ObjInputSettings

    Private objVisualMap As Object3D = Nothing
    Private objCollisionMap As Object3D = Nothing

    Private curModelFile As String = ""
    Private curCollisionFile As String = ""
    Private curColSettings As Collision.CollisionSettings
    Private curTexFormatSettings As Fast3D.TextureFormatSettings
    Private centredVisualMap As Boolean = False
    Private centredCollisionMap As Boolean = False

    Private isSliderMouseDown As Boolean = False

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors()

        ColorPickerButton_ShadingLight.SelectedColor = Color.FromArgb(&HFFFFFFFF)
        ColorPickerButton_ShadingDarkNeu.SelectedColor = Color.FromArgb(&HFF7F7F7F)
        ColorPickerButton_FogColor.SelectedColor = Color.White
    End Sub

    Private Function GetColorFromShadingByte(value As Byte) As Color
        Return Color.FromArgb(&HFF, value, value, value)
    End Function

    Public Overloads Function ShowDialog() As DialogResult
        Dim objSettings As New ObjInputSettings
        Return ShowDialog(objSettings)
    End Function

    Public Overloads Function ShowDialog(objSettings As ObjInputSettings) As DialogResult
        If objSettings Is Nothing Then Me.objSettings = New ObjInputSettings
        Me.objSettings = objSettings
        With Me.objSettings
            NUD_Scaling.Value = .Scaling
        End With

        ComboBoxEx_UpAxis.SelectedIndex = Settings.FileParser.UpAxis
        ComboBox_FogTyp.SelectedIndex = 0

        LoadRecentFiles()

        Return MyBase.ShowDialog
    End Function

    Private Async Sub Button_ConvertModel_Click(sender As Object, e As EventArgs) Handles Button_ConvertModel.Click
        'Set Convert Settings
        With objSettings
            .Scaling = 1.0F
            .ReduceDupVertLevel = If(SwitchButton_EnableReduceVertices.Value, ObjInputSettings.ReduceDuplicateVerticesLevel.Level1, ObjInputSettings.ReduceDuplicateVerticesLevel.Level0) 'CType(ComboBox_ReduceDupVertLevel.SelectedIndex, ObjInputSettings.ReduceDuplicateVerticesLevel)
            .ResizeTextures = SwitchButton_ResizeTextures.Value
            .CenterModel = SwitchButton_CenterModel.Value
            .ForceDisplaylist = ForceDisplaylist

            .Shading.Light = ColorPickerButton_ShadingLight.SelectedColor
            .Shading.Dark = ColorPickerButton_ShadingDarkNeu.SelectedColor

            If SwitchButton_EnableFog.Value Then
                .Fog = New Fog With {.Color = ColorPickerButton_FogColor.SelectedColor, .Type = ComboBox_FogTyp.SelectedIndex}
            End If
        End With

        'Get Model
        Dim vmap As Object3D = Nothing
        Dim colmap As Object3D = Nothing
        If CheckBoxX_ConvertModel.Checked Then vmap = objVisualMap
        If CheckBoxX_ConvertCollision.Checked Then colmap = objCollisionMap

        'Check for Triangluation
        If vmap IsNot Nothing Then
            If vmap.Meshes.Where(Function(n) n.Faces.Where(Function(nn) nn.Points.Count <> 3).Count > 0).Count > 0 Then
                MessageBoxEx.Show(MainModelconverter_Resources.MsgBox_VMapIsnotTriangled, MainModelconverter_Resources.MsgBox_VMapIsnotTriangled_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If
        If colmap IsNot Nothing AndAlso vmap IsNot colmap Then
            If colmap.Meshes.Where(Function(n) n.Faces.Where(Function(nn) nn.Points.Count <> 3).Count > 0).Count > 0 Then
                MessageBoxEx.Show(MainModelconverter_Resources.MsgBox_ColMapIsnotTriangled, MainModelconverter_Resources.MsgBox_ColMapIsnotTriangled_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If vmap IsNot Nothing Then
            If vmap.Meshes.Where(Function(n) n.Vertices.Where(Function(v) CheckIfInBounds(v)).Count > 0).Count > 0 Then
                Dim msg As String = If(vmap Is colmap, "You model is too big or your scaling is too large.", "You visual map is too big or your scaling is too large.")
                MessageBoxEx.Show(msg, "Out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If
        If colmap IsNot Nothing AndAlso vmap IsNot colmap Then
            If colmap.Meshes.Where(Function(n) n.Vertices.Where(Function(v) CheckIfInBounds(v)).Count > 0).Count > 0 Then
                MessageBoxEx.Show("You collision map is too big or your scaling is too large.", "Out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        EnableCirProgress()

        'Prepaire Textures
        If vmap IsNot Nothing Then
            PrepaireTexture(vmap, curTexFormatSettings)
        End If

        'Set Null Values
        If vmap IsNot Nothing Then
            vmap.SetNullVertices()
            vmap.SetNullUVs()
            vmap.SetNullNormals()
        End If
        If colmap IsNot Nothing AndAlso vmap IsNot colmap Then
            colmap.SetNullVertices()
        End If

        'Center Model
        If SwitchButton_CenterModel.Value Then
            If vmap IsNot Nothing Then
                If Not centredVisualMap Then
                    vmap.CenterModel()
                    centredVisualMap = True
                End If
            End If
            If colmap IsNot Nothing AndAlso vmap IsNot colmap Then
                If Not centredCollisionMap Then
                    colmap.CenterModel()
                    centredCollisionMap = True
                End If
            End If
        End If

        'Scale Model
        If vmap IsNot Nothing Then
            vmap.ScaleModel(NUD_Scaling.Value)
        End If
        If colmap IsNot Nothing AndAlso vmap IsNot colmap Then
            colmap.ScaleModel(NUD_Scaling.Value)
        End If

        'Convert Model
        ResModel = New ObjectModel

        If vmap Is Nothing Xor colmap Is Nothing Then
            If colmap IsNot Nothing Then
                ResModel.Collision = New Collision.CollisionMap
                Await ResModel.Collision.FromObject3DAsync(objSettings, colmap, curColSettings)
            End If
            If vmap IsNot Nothing Then
                ResModel.Fast3DBuffer = New Fast3D.Fast3DBuffer
                Await ResModel.Fast3DBuffer.FromModelAsync(objSettings, vmap, curTexFormatSettings)
            End If
        Else
            Await ResModel.FromModelAsync(objSettings, vmap, colmap, curTexFormatSettings, curColSettings)
        End If

        EnableCirProgress(True)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function CheckIfInBounds(v As Vertex)
        Dim var As Single

        var = Math.Round(v.X * NUD_Scaling.Value)
        If var > Int16.MaxValue OrElse var < Int16.MinValue Then
            Return True
        End If

        var = Math.Round(v.Y * NUD_Scaling.Value)
        If var > Int16.MaxValue OrElse var < Int16.MinValue Then
            Return True
        End If

        var = Math.Round(v.Z * NUD_Scaling.Value)
        If var > Int16.MaxValue OrElse var < Int16.MinValue Then
            Return True
        End If

        Return False
    End Function

    Private Sub PrepaireTexture(model As Object3D, texSettings As TextureFormatSettings)
        For Each mat In model.Materials
            If mat.Value.Image IsNot Nothing Then
                Dim entry = curTexFormatSettings.GetEntry(mat.Key)
                TextureManager.PrepaireImage(mat.Value.Image, entry.RotateFlip, N64Graphics.N64Graphics.StringCodec(texSettings.GetEntry(mat.Key).TextureFormat))
            End If
        Next
    End Sub

    Private Sub EnableCirProgress(Optional Disable As Boolean = False)
        CircularProgress1.Visible = Not Disable
        CircularProgress1.IsRunning = Not Disable
        Button_LoadModel.Enabled = Disable
        Button_LoadCol.Enabled = Disable
        CloseEnabled = Disable
    End Sub

    Private Sub Form_ModelConverter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DResult = DialogResult.None Then DResult = DialogResult.Cancel
    End Sub

    Private Async Sub Button_LM_LoadModel_Click(sender As Object, e As EventArgs) Handles Button_LoadModel.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = GetExtensionFilter(Settings.FileParser.LoaderModule) '"All supported files|*.obj;*.dae|OBJ Files (*.obj)|*.obj|Collada Files (*.dae)|*.dae"

        Dim p As StringCollection = Settings.RecentFiles.RecentModelFiles
        If p.Count > 0 Then ofd.InitialDirectory = Path.GetDirectoryName(p(0))

        If ofd.ShowDialog <> DialogResult.OK Then Return
        Await LoadModel(ofd.FileName)
    End Sub
    Private Async Sub Button3_LM_LoadCol_Click(sender As Object, e As EventArgs) Handles Button_LoadCol.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = GetExtensionFilter(Settings.FileParser.LoaderModule) '"All supported files|*.obj;*.dae|OBJ Files (*.obj)|*.obj|Collada Files (*.dae)|*.dae"

        Dim p As StringCollection = Settings.RecentFiles.RecentModelFiles
        If p.Count > 0 Then ofd.InitialDirectory = Path.GetDirectoryName(p(0))

        If ofd.ShowDialog <> DialogResult.OK Then Return
        Await LoadCollision(ofd.FileName)
    End Sub

    Private Async Function LoadModel(fileName As String) As Task
        EnableCirProgress()

        Dim useascoltoo As Boolean = CheckBoxX_ConvertCollision.Checked AndAlso objCollisionMap Is Nothing OrElse objCollisionMap Is objVisualMap

        Try
            objVisualMap = Object3D.FromFile(fileName, True, ComboBoxEx_UpAxis.SelectedIndex, Settings.FileParser.LoaderModule)
            curTexFormatSettings = New TextureFormatSettings
            Await curTexFormatSettings.Load(fileName & ".gf")

            objVisualMap.RemoveUnusedMaterials()

            Publics.Publics.AddRecentFile(Settings.RecentFiles.RecentModelFiles, fileName)
            LoadRecentFiles()
            LabelX_Modelfile.Text = Path.GetFileName(fileName)
            curModelFile = fileName
            centredVisualMap = False

            If useascoltoo Then
                curCollisionFile = fileName
                objCollisionMap = objVisualMap
                LabelX_Colfile.Text = Path.GetFileName(fileName)

                curColSettings = New Collision.CollisionSettings
                Await curColSettings.Load(fileName & ".col")
            End If

            EnableModelControls()

        Catch ex As Exceptions.MaterialException
            MessageBoxEx.Show(String.Format(MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial, ex.Message), MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As FileNotFoundException
            ShowVCPP2017IsMissingMessage()
        End Try
        EnableCirProgress(True)
    End Function
    Private Async Function LoadCollision(fileName As String) As Task
        EnableCirProgress()

        Try
            objCollisionMap = Object3D.FromFile(fileName, True, ComboBoxEx_UpAxis.SelectedIndex, Settings.FileParser.LoaderModule)
            curColSettings = New Collision.CollisionSettings
            Await curColSettings.Load(fileName & ".col")

            objCollisionMap.RemoveUnusedMaterials()

            Publics.Publics.AddRecentFile(Settings.RecentFiles.RecentModelFiles, fileName)
            LoadRecentFiles()
            LabelX_Colfile.Text = Path.GetFileName(fileName)
            curCollisionFile = fileName
            centredCollisionMap = False

            EnableModelControls()
            EnableCirProgress(True)

        Catch ex As Exceptions.MaterialException
            MessageBoxEx.Show(String.Format(MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial, ex.Message), MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As FileNotFoundException
            ShowVCPP2017IsMissingMessage()
        End Try
    End Function

    Private Sub ShowVCPP2017IsMissingMessage()
        AddHandler MessageBoxEx.MarkupLinkClick, AddressOf MessageBoxEx_LinkClicked
        MessageBoxEx.Show(MainModelconverter_Resources.MsgBox_MVCppMissing, MainModelconverter_Resources.MsgBox_MVCppMissing_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        RemoveHandler MessageBoxEx.MarkupLinkClick, AddressOf MessageBoxEx_LinkClicked
    End Sub

    Private Sub MessageBoxEx_LinkClicked(sender As Object, e As MarkupLinkClickEventArgs)
        Try
            Process.Start(e.HRef)
        Catch ex As Exception
            Clipboard.SetText(e.HRef)
        End Try
    End Sub

    Private Sub EnableModelControls()
        Button_ConvertModel.Enabled = True
        If objVisualMap IsNot Nothing Then
            ButtonX_VisualMapPreview.Enabled = True
            ButtonX_GraphicsEditor.Enabled = True
        End If
        If objCollisionMap IsNot Nothing Then
            ButtonX_CollisionMapPreview.Enabled = True
            Button_ColEditor.Enabled = True
        End If
    End Sub

    Private Sub LoadRecentFiles()
        Button_LoadModel.SubItems.Clear()
        Button_LoadCol.SubItems.Clear()

        Publics.Publics.MergeRecentFiles(Settings.RecentFiles.RecentModelFiles)
        For Each f As String In Settings.RecentFiles.RecentModelFiles
            Dim sf As String = Path.GetFileName(f)
            Dim ico As Image = IconExtractor.ExtractIcon(f, True).ToBitmap

            Dim btnItem As New ButtonItem
            btnItem.ButtonStyle = eButtonStyle.ImageAndText
            btnItem.Text = sf
            AddHandler btnItem.Click, AddressOf ButtonItem_RecentModelFile_Click
            btnItem.Image = ico
            Button_LoadModel.SubItems.Add(btnItem)

            btnItem = New ButtonItem(sf)
            btnItem.ButtonStyle = eButtonStyle.ImageAndText
            btnItem.Text = sf
            AddHandler btnItem.Click, AddressOf ButtonItem_RecentModelFile_Click
            btnItem.Image = ico
            Button_LoadCol.SubItems.Add(btnItem)
        Next

        Button_LoadModel.Refresh()
        Button_LoadCol.Refresh()
    End Sub

    Private Async Sub ButtonItem_RecentModelFile_Click(sender As ButtonItem, e As EventArgs)
        Dim f As String = Settings.RecentFiles.RecentModelFiles(sender.Parent.SubItems.IndexOf(sender))
        If f <> "" Then
            If Button_LoadModel.SubItems.Contains(sender) Then
                Await LoadModel(f)
            ElseIf Button_LoadCol.SubItems.Contains(sender) Then
                Await LoadCollision(f)
            End If
        End If
    End Sub

    Private Sub LabelX_Colfile_Click(sender As Object, e As EventArgs) Handles LabelX_Colfile.TextChanged
        EnableModelControls()
    End Sub

    Private Sub Button_ColEditor_Click(sender As Object, e As EventArgs) Handles Button_ColEditor.Click
        Dim frm As New CollisionEditor(objCollisionMap)
        frm.CollisionSettings = curColSettings
        frm.ShowDialog()
        curColSettings.Save(curCollisionFile & ".col")
    End Sub

    Private Sub ButtonX_GraphicsEditor_Click(sender As Object, e As EventArgs) Handles ButtonX_GraphicsEditor.Click
        Dim frm As New TextureGraphicFormatEditor(objVisualMap)
        frm.TextureFormatSettings = curTexFormatSettings
        frm.ShowDialog()
        curTexFormatSettings.Save(curModelFile & ".gf")
    End Sub

    Private Sub SwitchButton_EnableFog_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_EnableFog.ValueChanged
        ComboBox_FogTyp.Enabled = SwitchButton_EnableFog.Value
        ColorPickerButton_FogColor.Enabled = SwitchButton_EnableFog.Value

        Select Case SwitchButton_EnableFog.Value
            Case True
                If objSettings.Fog Is Nothing Then
                    objSettings.Fog = New Fog
                End If
            Case False
                objSettings.Fog = Nothing
        End Select
    End Sub

    Private Sub CheckBoxX_ConvertModel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX_ConvertModel.CheckedChanged
        Dim isChecked As Boolean = CheckBoxX_ConvertModel.Checked
        LabelX_Modelfile.Enabled = isChecked
        Button_LoadModel.Enabled = isChecked
    End Sub
    Private Sub CheckBoxX_ConvertCollision_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX_ConvertCollision.CheckedChanged
        Dim isChecked As Boolean = CheckBoxX_ConvertCollision.Checked
        LabelX_Colfile.Enabled = isChecked
        Button_LoadCol.Enabled = isChecked
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX_VisualMapPreview.Click
        If objVisualMap IsNot Nothing Then
            Dim mp As New ModelPreview(objVisualMap, NUD_Scaling.Value)
            mp.ShowDialog()
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX_CollisionMapPreview.Click
        If objCollisionMap IsNot Nothing Then
            Dim mp As New ModelPreview(objCollisionMap, NUD_Scaling.Value)
            mp.ShowDialog()
        End If
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx_UpAxis.SelectedIndexChanged
        Settings.FileParser.UpAxis = ComboBoxEx_UpAxis.SelectedIndex
    End Sub

    Private Sub Slider1_MouseDown(sender As Object, e As MouseEventArgs)
        isSliderMouseDown = True
    End Sub

    Private Sub Slider1_MouseUp(sender As Object, e As MouseEventArgs)
        isSliderMouseDown = False
    End Sub

End Class
