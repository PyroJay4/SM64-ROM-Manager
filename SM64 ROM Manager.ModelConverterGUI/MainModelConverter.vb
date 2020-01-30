﻿Imports System.IO
Imports DevComponents.DotNetBar
Imports SM64Lib.Model
Imports SM64Lib.Levels
Imports SM64Lib
Imports System.Numerics
Imports Pilz.S3DFileParser
Imports SM64_ROM_Manager.SettingsManager
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.PreviewN
Imports System.Windows.Forms
Imports System.Drawing
Imports SM64_ROM_Manager.Publics
Imports SM64Lib.Model.Fast3D
Imports SM64_ROM_Manager.ModelConverterGUI.My.Resources
Imports System.Deployment.Application
Imports System.Collections.Specialized
Imports SM64_ROM_Manager.ModelConverterGUI
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.RenderingN

Public Class MainModelConverter

    'C o n s t a n t s

    Private Const EXT_CONVERSION_PREFERENCES As String = ".conpref"
    Private Const EXT_GRAPHICS_SETTINGS As String = ".gf"
    Private Const EXT_COLLISION_SETTINGS As String = ".col"

    'F i e l d s

    Private DResult As DialogResult = DialogResult.None
    Private objSettings As New ObjectInputSettings
    Private objVisualMap As Object3D = Nothing
    Private objCollisionMap As Object3D = Nothing
    Private curModelFile As String = ""
    Private curCollisionFile As String = ""
    Private curColSettings As Collision.CollisionSettings
    Private curTexFormatSettings As TextureFormatSettings
    Private centredVisualMap As Boolean = False
    Private centredCollisionMap As Boolean = False
    Private curDiffusePos As Vertex = Nothing
    Private isSliderMouseDown As Boolean = False

    'P r o p e r t i e s

    Public Property ResModel As ObjectModel = Nothing
    Public Property ForceDisplaylist As SByte = -1

    'C o n s t r u c t o r
    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors()
    End Sub

    'F e a t u r e s

    Private Function GetColorFromShadingByte(value As Byte) As Color
        Return Color.FromArgb(&HFF, value, value, value)
    End Function

    Public Overloads Function ShowDialog() As DialogResult
        ComboBoxEx_UpAxis.SelectedIndex = Settings.FileParser.UpAxis
        ComboBox_FogTyp.SelectedIndex = 0

        LoadGuiSettings()
        LoadRecentFiles()

        Dim res As DialogResult = Nothing
        Dim ende As Boolean = False

        Do Until ende
            Try
                res = MyBase.ShowDialog()
                ende = True
            Catch ex As Exception
            End Try
        Loop

        Return res
    End Function

    Private Sub LoadGuiSettings()
        Dim guiInputSettings As GuiInputPreferences

        If CheckBoxX_ConvertModel.Checked AndAlso File.Exists(curModelFile) Then
            guiInputSettings = GuiInputPreferences.Load(curModelFile & EXT_CONVERSION_PREFERENCES)
        ElseIf CheckBoxX_ConvertCollision.Checked AndAlso File.Exists(curCollisionFile) Then
            guiInputSettings = GuiInputPreferences.Load(curCollisionFile & EXT_CONVERSION_PREFERENCES)
        Else
            guiInputSettings = New GuiInputPreferences
        End If

        NUD_Scaling.Value = guiInputSettings.Scaling
        SwitchButton_EnableReduceVertices.Value = guiInputSettings.ReduceDupVerts
        SwitchButton_ResizeTextures.Value = guiInputSettings.ResizeTextures
        SwitchButton_CenterModel.Value = guiInputSettings.CenterModel

        ColorPickerButton_ShadingAmbient.SelectedColor = guiInputSettings.Shading.AmbientColor
        ColorPickerButton_ShadingDiffuse.SelectedColor = guiInputSettings.Shading.DiffuseColor
        curDiffusePos = guiInputSettings.Shading.DiffusePosition

        Dim isFogNotNothing As Boolean = guiInputSettings.Fog IsNot Nothing
        SwitchButton_EnableFog.Value = isFogNotNothing
        If isFogNotNothing Then
            ColorPickerButton_FogColor.SelectedColor = guiInputSettings.Fog.Color
            ComboBox_FogTyp.SelectedIndex = guiInputSettings.Fog.Type
        End If
    End Sub

    Private Sub SaveGuiSettings(importVMap As Boolean, importColMap As Boolean)
        Dim guiInputSettings As New GuiInputPreferences

        guiInputSettings.Scaling = NUD_Scaling.Value
        guiInputSettings.ReduceDupVerts = SwitchButton_EnableReduceVertices.Value
        guiInputSettings.ResizeTextures = SwitchButton_ResizeTextures.Value
        guiInputSettings.CenterModel = SwitchButton_CenterModel.Value

        guiInputSettings.Shading.AmbientColor = ColorPickerButton_ShadingAmbient.SelectedColor
        guiInputSettings.Shading.DiffuseColor = ColorPickerButton_ShadingDiffuse.SelectedColor
        guiInputSettings.Shading.DiffusePosition = curDiffusePos

        If SwitchButton_EnableFog.Value Then
            guiInputSettings.Fog = New Fog With {.Color = ColorPickerButton_FogColor.SelectedColor, .Type = ComboBox_FogTyp.SelectedIndex}
        Else
            guiInputSettings.Fog = Nothing
        End If

        If importVMap Then
            guiInputSettings.Save(curModelFile & EXT_CONVERSION_PREFERENCES)
        End If
        If importColMap Then
            guiInputSettings.Save(curCollisionFile & EXT_CONVERSION_PREFERENCES)
        End If
    End Sub

    'G u i

    Private Async Sub Button_ConvertModel_Click(sender As Object, e As EventArgs) Handles Button_ConvertModel.Click
        'Set Convert Settings
        With objSettings
            .ReduceDupVertLevel = If(SwitchButton_EnableReduceVertices.Value, ObjectInputSettings.ReduceDuplicateVerticesLevel.Level1, ObjectInputSettings.ReduceDuplicateVerticesLevel.Level0)
            .ResizeTextures = SwitchButton_ResizeTextures.Value
            .CenterModel = SwitchButton_CenterModel.Value
            .ForceDisplaylist = ForceDisplaylist

            .Shading.AmbientColor = ColorPickerButton_ShadingAmbient.SelectedColor
            .Shading.DiffuseColor = ColorPickerButton_ShadingDiffuse.SelectedColor
            .Shading.DiffusePosition = curDiffusePos

            If SwitchButton_EnableFog.Value Then
                .Fog = New Fog With {.Color = ColorPickerButton_FogColor.SelectedColor, .Type = ComboBox_FogTyp.SelectedIndex}
            Else
                .Fog = Nothing
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
            If vmap.Meshes.Where(Function(n) n.Vertices.Where(Function(v) CheckIfInBounds(v)).Any).Any Then
                Dim msg As String = If(vmap Is colmap, "model", "visual map")
                MessageBoxEx.Show(String.Format(MainModelconverter_Resources.MsgBox_ModelTooBig, msg), MainModelconverter_Resources.MsgBox_ModelTooBig_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        If colmap IsNot Nothing AndAlso vmap IsNot colmap Then
            If colmap.Meshes.Where(Function(n) n.Vertices.Where(Function(v) CheckIfInBounds(v)).Any).Any Then
                MessageBoxEx.Show(String.Format(MainModelconverter_Resources.MsgBox_ModelTooBig, "collision map"), MainModelconverter_Resources.MsgBox_ModelTooBig_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        EnableCirProgress()

        'Prepaire Textures
        If vmap IsNot Nothing Then
            PrepaireTexture(vmap, curTexFormatSettings, SwitchButton_ResizeTextures.Value)
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
            Dim mapsToCenter As New List(Of Mesh)
            If vmap IsNot Nothing Then mapsToCenter.AddRange(vmap.Meshes)
            If colmap IsNot Nothing AndAlso vmap IsNot colmap Then mapsToCenter.AddRange(colmap.Meshes)
            Mesh.CenterModel(mapsToCenter)
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

        SaveGuiSettings(vmap IsNot Nothing, colmap IsNot Nothing)
        EnableCirProgress(True)
        DialogResult = DialogResult.OK
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

    Private Sub PrepaireTexture(model As Object3D, texSettings As TextureFormatSettings, fitImageSize As Boolean)
        For Each mat In model.Materials
            If mat.Value.Image IsNot Nothing Then
                Dim entry = curTexFormatSettings.GetEntry(mat.Key)
                PrepaireImage(mat.Value.Image, entry.RotateFlip, N64Graphics.N64Graphics.StringCodec(texSettings.GetEntry(mat.Key).TextureFormat), fitImageSize)
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
        If DResult = DialogResult.None Then
            DResult = DialogResult.Cancel
        End If
    End Sub

    Private Async Sub Button_LM_LoadModel_Click(sender As Object, e As EventArgs) Handles Button_LoadModel.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = GetExtensionFilter(Settings.FileParser.FileLoaderModule, 0) '"All supported files|*.obj;*.dae|OBJ Files (*.obj)|*.obj|Collada Files (*.dae)|*.dae"

        Dim p As StringCollection = Settings.RecentFiles.RecentModelFiles
        If p.Count > 0 Then ofd.InitialDirectory = Path.GetDirectoryName(p(0))

        If ofd.ShowDialog = DialogResult.OK Then
            Await LoadModel(ofd.FileName)
        End If
    End Sub

    Private Async Sub Button3_LM_LoadCol_Click(sender As Object, e As EventArgs) Handles Button_LoadCol.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = GetExtensionFilter(Settings.FileParser.FileLoaderModule, 0) '"All supported files|*.obj;*.dae|OBJ Files (*.obj)|*.obj|Collada Files (*.dae)|*.dae"

        Dim p As StringCollection = Settings.RecentFiles.RecentModelFiles
        If p.Count > 0 Then ofd.InitialDirectory = Path.GetDirectoryName(p(0))

        If ofd.ShowDialog = DialogResult.OK Then
            Await LoadCollision(ofd.FileName)
        End If
    End Sub

    Private Async Function LoadModel(fileName As String) As Task
        EnableCirProgress()

        Dim m As File3DLoaderModule = GetLoaderModuleFromID(Settings.FileParser.FileLoaderModule)
        Dim useascoltoo As Boolean = CheckBoxX_ConvertCollision.Checked AndAlso objCollisionMap Is Nothing OrElse objCollisionMap Is objVisualMap

#If Not DEBUG Then
        Try
#End If

        objVisualMap = m.Invoke(fileName, New LoaderOptions(True, ComboBoxEx_UpAxis.SelectedIndex))

        curTexFormatSettings = New TextureFormatSettings
        Await curTexFormatSettings.Load(fileName & EXT_GRAPHICS_SETTINGS)

        objVisualMap.RemoveUnusedMaterials()

        AddRecentFile(Settings.RecentFiles.RecentModelFiles, fileName)
        LoadRecentFiles()
        LabelX_Modelfile.Text = Path.GetFileName(fileName)
        curModelFile = fileName
        centredVisualMap = False
        LoadGuiSettings()

        If useascoltoo Then
            curCollisionFile = fileName
            objCollisionMap = objVisualMap
            LabelX_Colfile.Text = Path.GetFileName(fileName)

            curColSettings = New Collision.CollisionSettings
            Await curColSettings.Load(fileName & EXT_COLLISION_SETTINGS)
        End If

        EnableModelControls()

#If Not DEBUG Then
        Catch ex As Exceptions.MaterialException
            MessageBoxEx.Show(String.Format(MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial, ex.Message), MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As FileNotFoundException
            ShowVCPP2017IsMissingMessage()
        End Try
#End If

        EnableCirProgress(True)
    End Function

    Private Async Function LoadCollision(fileName As String) As Task
        EnableCirProgress()

        Dim m As File3DLoaderModule = GetLoaderModuleFromID(Settings.FileParser.FileLoaderModule)

#If Not DEBUG Then
        Try
#End If

        objCollisionMap = m.Invoke(fileName, New LoaderOptions(True, ComboBoxEx_UpAxis.SelectedIndex))

        curColSettings = New Collision.CollisionSettings
        Await curColSettings.Load(fileName & EXT_COLLISION_SETTINGS)

        objCollisionMap.RemoveUnusedMaterials()

        AddRecentFile(Settings.RecentFiles.RecentModelFiles, fileName)
        LoadRecentFiles()
        LabelX_Colfile.Text = Path.GetFileName(fileName)
        curCollisionFile = fileName
        centredCollisionMap = False
        LoadGuiSettings()

        EnableModelControls()
        EnableCirProgress(True)

#If Not DEBUG Then
        Catch ex As Exceptions.MaterialException
            MessageBoxEx.Show(String.Format(MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial, ex.Message), MainModelconverter_Resources.MsgBox_ErrorLoadingMaterial_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As FileNotFoundException
            ShowVCPP2017IsMissingMessage()
        End Try
#End If
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

        MergeRecentFiles(Settings.RecentFiles.RecentModelFiles)
        For Each f As String In Settings.RecentFiles.RecentModelFiles
            Dim sf As String = Path.GetFileName(f)
            Dim ico As Image = Pilz.Win32.Internals.IconExtractor.ExtractIcon(f, True).ToBitmap

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
        curColSettings.Save(curCollisionFile & EXT_COLLISION_SETTINGS)
    End Sub

    Private Sub ButtonX_GraphicsEditor_Click(sender As Object, e As EventArgs) Handles ButtonX_GraphicsEditor.Click
        Dim frm As New TextureGraphicFormatEditor(objVisualMap)
        frm.TextureFormatSettings = curTexFormatSettings
        frm.ShowDialog()
        curTexFormatSettings.Save(curModelFile & EXT_GRAPHICS_SETTINGS)
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
            Dim mp As New ModelPreviewOfficeForm(objVisualMap, NUD_Scaling.Value)
            mp.Show()
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX_CollisionMapPreview.Click
        If objCollisionMap IsNot Nothing Then
            Dim mp As New ModelPreviewOfficeForm(objCollisionMap, NUD_Scaling.Value)
            mp.Show()
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

    Private Sub MainModelConverter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Environment.ProcessorCount >= 4 Then
            CollisionEditor.LoadFloorTypesFromDatabaseAsync()
        End If
    End Sub

    Private Sub ButtonItem_ResetDiffusePosition_Click(sender As Object, e As EventArgs) Handles ButtonItem_ResetDiffusePosition.Click
        curDiffusePos = Nothing
        ButtonItem_ResetDiffusePosition.Visible = False
    End Sub

    Private Sub ButtonItem_SetupDiffusePosition_Click(sender As Object, e As EventArgs) Handles ButtonItem_SetupDiffusePosition.Click
        Dim cx, cy, cz As Integer
        If curDiffusePos IsNot Nothing Then
            cx = curDiffusePos.X
            cy = curDiffusePos.Y
            cz = curDiffusePos.Z
        End If

        Dim editor As New DialogSetUpPoint("Diffuse point", True, True, True, cx, cy, cz)
        If editor.ShowDialog = DialogResult.OK Then
            If curDiffusePos Is Nothing Then
                curDiffusePos = New Vertex
            End If
            curDiffusePos.X = editor.IntegerInput_X.Value
            curDiffusePos.Y = editor.IntegerInput_Y.Value
            curDiffusePos.Z = editor.IntegerInput_Z.Value
            ButtonItem_ResetDiffusePosition.Visible = True
        End If
    End Sub

    Private Sub ColorPickerButton_ShadingDiffuse_PopupOpen(sender As Object, e As EventArgs) Handles ColorPickerButton_ShadingDiffuse.PopupContainerLoad
        ColorPickerButton_ShadingDiffuse.SubItems.Add(ButtonItem_SetupDiffusePosition)
        ColorPickerButton_ShadingDiffuse.SubItems.Add(ButtonItem_ResetDiffusePosition)
    End Sub

End Class
