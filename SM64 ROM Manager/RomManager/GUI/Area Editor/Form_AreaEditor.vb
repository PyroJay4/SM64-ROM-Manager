Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports OpenTK
Imports TextValueConverter
Imports SM64Lib.Level
Imports SM64Lib.Level.Script, SM64Lib.Level.Script.Commands
Imports OpenTK.Graphics.OpenGL
Imports OpenGLRenderer
Imports SM64Lib.Geolayout.Script.Commands
Imports System.ComponentModel
Imports S3DFileParser
Imports SM64Lib.Model.Fast3D.DisplayLists
Imports OpenGLCamera
Imports SettingsManager
Imports SM64Lib.Geolayout
Imports SM64Lib.Model
Imports ModelConverterGUI
Imports SimpleHistory
Imports System.Reflection
Imports DevComponents.Editors
Imports SM64_ROM_Manager.PropertyValueEditors
Imports Publics

Public Class Form_AreaEditor

#Region "Declerations"

    Friend cVisualMap As Object3D = Nothing
    Friend cCollisionMap As Object3D = Nothing
    Friend rndrVisualMap As Renderer = Nothing 'RenderEngineOld.Model3D = Nothing
    Friend rndrCollisionMap As Renderer = Nothing
    Private cLevel As Level = Nothing
    Private lastKeyLeaveTimer As Date = Date.Now
    Private pressedKeys As New List(Of Keys)
    Private selectedList As ListViewEx = ListViewEx_Objects
    Private areaIdToLoad As Byte = 1
    Private levelID As Byte = 0
    Private origObjPos As New List(Of Numerics.Vector3)
    Private rommgr As SM64Lib.RomManager = Nothing
    Private managedObjects As New List(Of Managed3DObject)
    Private managedWarps As New List(Of IManagedLevelscriptCommand)
    Private objectModels As New Dictionary(Of Byte, Renderer)
    Private myObjectCombos As New ObjectComboList
    Private myLevelsList As New List(Of String)
    Private knownModelIDs As New List(Of Byte)

    'OpenGL & Rendering & Camera
    Private ProjMatrix As Matrix4 = Nothing
    Private FOV As Single = 1.048F
    Private camMtx As Matrix4 = Matrix4.Identity
    Private WithEvents camera As New Camera
    Private savedCamPos As New OpenTK.Vector3
    Private isMouseDown As Boolean = False
    Private WithEvents glControl1 As GLControl = Nothing
    Private curScale As Single = 1.0F

    'History
    Private history As HistoryStack = Nothing
    Private defBindFlags As BindingFlags = BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic
    Private objStateBlackList As New MemberBlackList({""})
    Private dicHistories As New Dictionary(Of LevelArea, HistoryStack)

    'Flags
    Private finishedLoading As Boolean = False
    Private isLoadingAreaIDs As Boolean = False
    Private changingActs As Boolean = False
    Private loadingObj As Boolean = False
    Private isObjRotating As Boolean = False
    Private isObjMoving As Boolean = False
    Private loadingWarp As Boolean = False
    Private rommgr_SavingRom As Boolean = False
    Private isFullscreen As Boolean = False
    Private waitUntilLostFocus As Boolean = False

    'Variables
    Private backupWindowState As WindowState = FormWindowState.Normal
    Private backupCurrentAreaIndex As Integer = -1
    Private lastChangedPropertyName As String = ""

    'Constants
    Private ReadOnly warpBehavIDs() = {&H13000720, &H13000AFC, &H13001C34, &H1300075C, &H13002F8C, &H13002F88, &H13002F90, &H13002F70, &H13002F74, &H13002F64, &H13002F6C, &H130056A4, &H13002F78, &H13002F94, &H13000780, &H13002F80, &H13002F7C, &H130007A0}

    Private ReadOnly Property cArea As LevelArea
        Get
            Dim index As Integer = ComboBoxItem_Area.SelectedIndex
            If index < 0 Then
                Return Nothing
            Else
                Return cLevel.Areas(ComboBoxItem_Area.SelectedIndex)
            End If
        End Get
    End Property

    Private ReadOnly Property IsStrgPressed As Boolean
        Get
            Return pressedKeys.Contains(Keys.ControlKey)
        End Get
    End Property
    Private ReadOnly Property IsShiftPressed As Boolean
        Get
            Return pressedKeys.Contains(Keys.ShiftKey)
        End Get
    End Property

    Private Property ObjectMoveSpeed As Single
        Get
            Return Slider_ObjMoveSpeed.Value / 100
        End Get
        Set(value As Single)
            Slider_ObjMoveSpeed.Value = value * 100
        End Set
    End Property

    Public ReadOnly Property CurrentModelDrawMod As ModelDrawMod
        Get
            Select Case True
                Case ButtonItem_ViewColMap.Checked
                    Return ModelDrawMod.Collision
                Case ButtonItem_ViewVisualMap.Checked
                    Return ModelDrawMod.VisualMap
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property

    Public Property DrawObjectModels As Boolean
        Get
            Return ButtonItem_DrawObjects.Checked
        End Get
        Set(value As Boolean)
            ButtonItem_DrawObjects.Checked = value
        End Set
    End Property

    Private Property FaceDrawMode As RenderMode
        Get
            Dim val As RenderMode = OpenGLRenderer.RenderMode.None
            If ButtonItem_DrawOutline.Checked Then val = val Or OpenGLRenderer.RenderMode.Outline
            If ButtonItem_DrawFill.Checked Then val = val Or OpenGLRenderer.RenderMode.Fill
            Return val
        End Get
        Set(value As RenderMode)
            ButtonItem_DrawOutline.Checked = (value And OpenGLRenderer.RenderMode.Outline) = OpenGLRenderer.RenderMode.Outline
            ButtonItem_DrawFill.Checked = (value And OpenGLRenderer.RenderMode.Fill) = OpenGLRenderer.RenderMode.Fill
        End Set
    End Property

    Private Property KeepObjectsOnNearestGround As Boolean
        Get
            Return ButtonX_KeepOnGround.Checked
        End Get
        Set(value As Boolean)
            ButtonX_KeepOnGround.Checked = value
        End Set
    End Property
    Private Property KeepObjectsOnButtom As Boolean
        Get
            Return ButtonX_KeepOnButtom.Checked
        End Get
        Set(value As Boolean)
            ButtonX_KeepOnButtom.Checked = value
        End Set
    End Property
    Private Property KeepObjectsOnTop As Boolean
        Get
            Return ButtonX_KeepOnTop.Checked
        End Get
        Set(value As Boolean)
            ButtonX_KeepOnTop.Checked = value
        End Set
    End Property
    Private ReadOnly Property KeepObjectOnGround As Boolean
        Get
            Return KeepObjectsOnButtom OrElse KeepObjectsOnNearestGround OrElse KeepObjectsOnTop
        End Get
    End Property

#End Region

#Region "Enums"
    Public Enum ModelDrawMod
        VisualMap
        Collision
    End Enum
#End Region

#Region "Initalize"

    Public Sub New(rommgr As SM64Lib.RomManager, Level As Level, LevelID As Byte, AreaID As Byte)
        'Initialize Components
        InitializeComponent()

        'Stop drawing
        Me.SuspendLayout()

        'Setup other Components
        RibbonControl1.Expanded = Settings.AreaEditor.RibbonControlExpanded

        'Setup Form Settings
        Me.WindowState = Settings.AreaEditor.DefaultWindowMode

        'Setup some Styles
        If Settings.StyleManager.AlwaysKeepBlueColors Then
            PanelEx1.Style.BackColor1.Color = Color.LightSteelBlue
            PanelEx1.Style.BackColor2.Color = Color.LightSteelBlue
        End If

        'Add Groups to ListView Controls
        ListViewEx_Warps.Groups.AddRange({lvg_ConnectedWarps, lvg_WarpsForGame, lvg_PaintingWarps, lvg_InstantWarps})
        'ListViewEx_Objects.Groups.AddRange({lvg_Objects, lvg_MacroObjects})

        'Create new GLControl
        Me.glControl1 = New GLControl
        Me.glControl1.BackColor = Color.Black
        Me.glControl1.Location = New Drawing.Point(0, 0)
        Me.glControl1.MinimumSize = New Size(600, 120)
        Me.glControl1.Name = "glControl1"
        Me.glControl1.Size = New Size(880, 538)
        Me.glControl1.TabIndex = 0
        Me.glControl1.TabStop = False
        Me.glControl1.VSync = True
        Me.glControl1.Dock = DockStyle.Fill
        Panel_GLControl.Controls.Add(Me.glControl1)
        AddHandler Windows.Media.CompositionTarget.Rendering, AddressOf CompositionTarget_Rendering

        'Bring CircularProgress to front
        Me.CircularProgress1.BringToFront()

        'Create GLControl
        glControl1.CreateControl()
        UpdateProjMatrix()
        glControl1.Enabled = False
        camera.updateMatrix(camMtx)

        'Setup some level variables
        cLevel = Level
        Me.rommgr = rommgr
        areaIdToLoad = AreaID
        Me.levelID = LevelID

        'Update Ambient Colors
        UpdateAmbientColors()

        'Resume drawing
        Me.ResumeLayout()
    End Sub

#End Region

#Region "Form & Controls"

    Private Sub ProgressControl(enabled As Boolean)
        CircularProgress1.IsRunning = enabled
        CircularProgress1.Visible = enabled
        Application.DoEvents()
    End Sub

    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Me.Close()
    End Sub

    Private Sub Form_AreaEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ReleaseBuffers()
    End Sub

    Private Async Sub Form_AreaEditor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        glControl1.Enabled = True

        If ObjectCombos.Count = 0 Then ObjectCombos.ReadFromFile(Publics.MyDataPath & "\Area Editor\Object Combos.json")
        Await LoadObjectModels()
        LoadOtherObjectCombos()

        LoadComboBoxObjComboEntries()
        LoadLevelsStringList()
        LoadAreaIDs()

        selectedList = ListViewEx_Objects

        glControl1.Invalidate()
    End Sub

    Private Sub LoadOtherObjectCombos()
        For Each obj As ObjectComboList.ObjectCombo In ObjectCombos
            If (obj.ModelID = 0 OrElse obj.Name.Contains("[MOP")) AndAlso Not myObjectCombos.Contains(obj) Then
                myObjectCombos.Add(obj)
            End If
        Next
    End Sub

    Private Sub LoadComboBoxObjComboEntries()
        Dim myObjectCombosString As New List(Of String)

        For Each c As ObjectComboList.ObjectCombo In myObjectCombos
            myObjectCombosString.Add(c.Name)
        Next

        'Set Property Settings on AdvPropertyGrid1
        Dim propSet As New PropertySettings("ObjectCombo")
        Dim editor As New ComboBoxPropertyEditor(myObjectCombosString.ToArray)
        editor.DropDownWidth = 300
        propSet.ValueEditor = editor
        AdvPropertyGrid1.PropertySettings.Add(propSet)
    End Sub
    Private Sub LoadLevelsStringList()
        myLevelsList.Clear()
        Dim items As New List(Of ComboItem)
        Dim levels As New List(Of Levels)

        For Each lvl In rommgr.LevelInfoData
            Dim displayName As String = $"{TextFromValue(lvl.ID, , 2)} - {lvl.Name}"
            myLevelsList.Add(displayName)

            Dim cbitem As New ComboItem(displayName)
            cbitem.Tag = lvl
            items.Add(cbitem)

            levels.Add(lvl.ID)
        Next

        Dim propSet As New PropertySettings("DestLevelID")
        Dim editor As New LevelsEnumEditor(items.ToArray, levels)

        editor.DropDownWidth = 200
        propSet.ValueEditor = editor

        AdvPropertyGrid1.PropertySettings.Add(propSet)
    End Sub

    Private Sub ButtonX_DropToGround_Click(sender As Object, e As EventArgs) Handles ButtonX_DropToGround.Click, ButtonItem_DropToGround.Click
        StoreObjectHistoryPoint(SelectedObjects, "Position")
        DropObjectsToGround(0)
    End Sub
    Private Sub ButtonX_DropToTop_Click(sender As Object, e As EventArgs) Handles ButtonX_DropToTop.Click, ButtonItem_DropToTop.Click
        StoreObjectHistoryPoint(SelectedObjects, "Position")
        DropObjectsToGround(1)
    End Sub
    Private Sub ButtonX_DropToButtom_Click(sender As Object, e As EventArgs) Handles ButtonX_DropToButtom.Click, ButtonItem_DropToButtom.Click
        StoreObjectHistoryPoint(SelectedObjects, "Position")
        DropObjectsToGround(2)
    End Sub

    Private Sub ButtonX_KeepOnGround_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonX_KeepOnGround.CheckedChanged, ButtonX_KeepOnTop.CheckedChanged, ButtonX_KeepOnButtom.CheckedChanged, ButtonItem_KeepOnButtom.CheckedChanged, ButtonItem_KeepOnTop.CheckedChanged, ButtonItem_KeepOnGround.CheckedChanged
        If sender.Checked Then
            For Each btn As ButtonX In {ButtonX_KeepOnGround, ButtonX_KeepOnTop, ButtonX_KeepOnButtom}
                If btn IsNot sender Then btn.Checked = False
            Next

            If ({ButtonX_KeepOnGround, ButtonItem_KeepOnGround}).Contains(sender) Then
                ButtonX_DropToGround.PerformClick()
            ElseIf ({ButtonX_KeepOnTop, ButtonItem_KeepOnTop}).Contains(sender) Then
                ButtonX_DropToTop.PerformClick()
            ElseIf ({ButtonX_KeepOnButtom, ButtonItem_KeepOnButtom}).Contains(sender) Then
                ButtonX_DropToButtom.PerformClick()
            End If
        End If
    End Sub

    Private Sub Form_AreaEditor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Stop Timer for Key-Events
        'If timer1?.Enabled Then timer1.Stop()

        'Save all Objects
        SaveAllObjectProperties()
        SaveAllWarpProperties()
    End Sub

    Private Sub DockContainerItem4_Click(sender As Object, e As EventArgs) Handles DockContainerItem4.MouseUp
        If sender.Selected Then
            RibbonTabItem_Objects.Select()
        End If
    End Sub
    Private Sub DockContainerItem1_Click(sender As Object, e As EventArgs) Handles DockContainerItem1.MouseUp
        If sender.Selected Then
            RibbonTabItem_Warps.Select()
        End If
    End Sub
    Private Sub DockContainerItem5_Click(sender As Object, e As EventArgs) Handles DockContainerItem5.MouseUp
        If sender.Selected Then
            RibbonTabItem_Collision.Select()
        End If
    End Sub

    Private Sub ButtonItem95_Click(sender As Object, e As EventArgs) Handles ButtonItem95.Click
        If RibbonControl1.Expanded Then
            ButtonItem95.Symbol = "58831"
            RibbonControl1.Expanded = False
        Else
            ButtonItem95.Symbol = "58830"
            RibbonControl1.Expanded = True
        End If
        Settings.AreaEditor.RibbonControlExpanded = RibbonControl1.Expanded
    End Sub

    Private Async Sub RibbonControl1_SelectedRibbonTabChanged(sender As Object, e As EventArgs) Handles RibbonControl1.SelectedRibbonTabChanged
        Dim srti As RibbonTabItem = RibbonControl1.SelectedRibbonTabItem

        Select Case True
            Case srti.Equals(RibbonTabItem_Objects)

                selectedList = ListViewEx_Objects
                DockContainerItem4.Selected = True

            Case srti.Equals(RibbonTabItem_Warps)

                selectedList = ListViewEx_Warps
                DockContainerItem1.Selected = True

            Case srti.Equals(RibbonTabItem_Collision)

                If cCollisionMap Is Nothing Then
                    Await LoadAreaCollisionAsObject3D()
                End If
                LoadCollisionLists()
                DockContainerItem5.Selected = True

            Case Else : Return

        End Select

        PanelDockContainer10.DockContainerItem.Selected = True
    End Sub

    Private Sub ReleaseBuffers()
        For Each kvp As KeyValuePair(Of Byte, Renderer) In objectModels
            kvp.Value.ReleaseBuffers()
        Next

        rndrVisualMap?.ReleaseBuffers()
        rndrCollisionMap?.ReleaseBuffers()
    End Sub

#End Region

#Region "OpenGL"

    Private Sub glControl1_Load(sender As Object, e As EventArgs) Handles glControl1.Load
        GL.Enable(EnableCap.Blend)
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha)

        GL.Enable(EnableCap.DepthTest)
        GL.DepthFunc(DepthFunction.Lequal)

        GL.Enable(EnableCap.Texture2D)
        GL.Enable(EnableCap.AlphaTest)
        GL.AlphaFunc(AlphaFunction.Gequal, 0.5F)

        'GL.Light(LightName.Light0, LightParameter.Ambient, New Graphics.Color4(Color.DarkGray.R, Color.DarkGray.G, Color.DarkGray.B, Color.DarkGray.A))
        'GL.Enable(EnableCap.Lighting)
        'GL.Enable(EnableCap.Light0)

        GL.Enable(EnableCap.CullFace)
    End Sub

    Private Sub glControl1_Paint(sender As Object, e As PaintEventArgs) Handles glControl1.Paint
        MoveCameraViaWASDQE()

        GL.ClearColor(If(Settings.StyleManager.AlwaysKeepBlueColors, Color.CornflowerBlue, Me.BackColor))

        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadMatrix(ProjMatrix)
        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadMatrix(camMtx)

        Select Case CurrentModelDrawMod
            Case ModelDrawMod.Collision
                If rndrCollisionMap IsNot Nothing Then rndrCollisionMap?.DrawModel(FaceDrawMode)
            Case ModelDrawMod.VisualMap
                If rndrVisualMap IsNot Nothing Then rndrVisualMap?.DrawModel(FaceDrawMode)
        End Select

        DrawAllObjects()

        glControl1.SwapBuffers()
    End Sub

    Private Sub glControl1_Resize(sender As Object, e As EventArgs) Handles glControl1.Resize
        glControl1.Context.Update(glControl1.WindowInfo)
        GL.Viewport(0, 0, glControl1.Width, glControl1.Height)
        UpdateProjMatrix()
        glControl1.Invalidate()
    End Sub

    Private Sub UpdateProjMatrix()
        ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(FOV, glControl1.Width / glControl1.Height, 100.0F, 100000.0F)
    End Sub

    Private Sub glControl1_Wheel(sender As Object, e As MouseEventArgs) Handles glControl1.MouseWheel
        camera.resetMouseStuff()
        camera.updateCameraMatrixWithScrollWheel(e.Delta * (If(IsShiftPressed, 3.5F, 1.5F)), camMtx)
        savedCamPos = camera.Position
        glControl1.Invalidate()
    End Sub

    Private Sub glControl1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles glControl1.MouseDown
        isMouseDown = True
        savedCamPos = camera.Position

        If e.Button = MouseButtons.Right Then
            SelectViaGLControl(e.X, e.Y)
            glControl1.Invalidate()
        End If
    End Sub

    Private Sub glControl1_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles glControl1.MouseUp, glControl1.MouseLeave
        camera.resetMouseStuff()
        isMouseDown = False
    End Sub

    Private Sub glControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles glControl1.MouseMove
        If isMouseDown AndAlso e.Button = MouseButtons.Left Then
            If IsShiftPressed Then
                camera.updateCameraOffsetWithMouse(savedCamPos, e.X, e.Y, glControl1.Width, glControl1.Height, camMtx)
            Else
                camera.updateCameraMatrixWithMouse(e.X, e.Y, camMtx)
            End If
            glControl1.Invalidate()
        End If
    End Sub

    Private Sub ModelPreview_KeyDown(sender As Object, e As KeyEventArgs) Handles glControl1.KeyDown
        If Not pressedKeys.Contains(e.KeyCode) Then pressedKeys.Add(e.KeyCode)
    End Sub

    Private Sub ModelPreview_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        lastKeyLeaveTimer = Date.Now
        If pressedKeys.Contains(e.KeyCode) Then pressedKeys.Remove(e.KeyCode)
    End Sub

    Private Sub CompositionTarget_Rendering(sender As Object, e As EventArgs)
        glControl1.Invalidate()
    End Sub

    Public Sub MoveCameraViaWASDQE()
        Dim moveSpeed As Integer = Convert.ToInt32(Math.Round((If(IsShiftPressed, 60, 30)) * (camera.camSpeedMultiplier), 0))
        Dim allowCamMove As Boolean = Not (isMouseDown AndAlso IsShiftPressed)

        For Each k As Keys In pressedKeys
            If allowCamMove Then
                'camera.resetMouseStuff()

                Select Case k
                    Case Keys.W
                        'camera.Move(moveSpeed, moveSpeed, camMtx)
                        camera.updateCameraMatrixWithScrollWheel(moveSpeed, camMtx)
                        savedCamPos = camera.Position
                    Case Keys.S
                        'camera.Move(-moveSpeed, -moveSpeed, camMtx)
                        camera.updateCameraMatrixWithScrollWheel(-moveSpeed, camMtx)
                        savedCamPos = camera.Position
                    Case Keys.A
                        'camera.Move(-moveSpeed, 0, camMtx)
                        camera.updateCameraOffsetDirectly(-moveSpeed, 0, camMtx)
                    Case Keys.D
                        'camera.Move(moveSpeed, 0, camMtx)
                        camera.updateCameraOffsetDirectly(moveSpeed, 0, camMtx)
                    Case Keys.E
                        'camera.Move(0, -moveSpeed, camMtx)
                        camera.updateCameraOffsetDirectly(0, -moveSpeed, camMtx)
                    Case Keys.Q
                        'camera.Move(0, moveSpeed, camMtx)
                        camera.updateCameraOffsetDirectly(0, moveSpeed, camMtx)
                End Select

                'savedCamPos = camera.Position
            End If
        Next

        'If allowCamMove Then
        '    glControl1.Invalidate()
        '    Application.DoEvents()
        'End If
    End Sub

    Public Sub SelectViaGLControl(mx As Integer, my As Integer)
        Dim h As Integer = glControl1.Height

        GL.ClearColor(1.0F, 1.0F, 1.0F, 1.0F)
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadMatrix(ProjMatrix)
        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadMatrix(camMtx)

        'Draw everything
        DrawAllObjects(True)
        '...

        Dim pixel() = New Byte(3) {}
        GL.ReadPixels(mx, h - my, 1, 1, PixelFormat.Rgba, PixelType.UnsignedByte, pixel)
        pixel = New Byte() {pixel(3), pixel(0), pixel(1), pixel(2)}

        Select Case pixel(0) >> 4
            Case 1 'Object

                Dim newIndex As Integer = (CInt(pixel(2)) << 8) Or pixel(3)

                If IsStrgPressed Then
                    ToogleObjectSelection(managedObjects(newIndex))
                Else
                    SelectItemAtIndexInList(ListViewEx_Objects, newIndex, True)
                End If

            Case 2 'Collision Face

                '...

        End Select
    End Sub

#End Region

#Region "Camera & Movements"

    Private moveObj_saved As New List(Of Numerics.Vector3)

    Private moveObj_mouseDown As Boolean = False
    Private moveObj_lastMouseX As Integer = 0
    Private moveObj_lastMouseY As Integer = 0

    Private moveObj_UpDown_mouseDown As Boolean = False
    Private moveObj_UpDown_lastMouseY As Integer = 0

    Private rotObj_mouseDown As Boolean = False
    Private rotObj_lastMouseX As Integer = 0
    Private rotObj_lastMouseY As Integer = 0

    Private rotObj_Yaw_lastMouseY As Integer = 0
    Private rotObj_Yaw_mouseDown As Boolean = False

    Private moveCam_InOut_lastPosY As Integer = 0
    Private moveCam_InOut_mouseDown As Boolean = False

    Private moveCam_strafe_mouseDown As Boolean = False

    Private Sub saveObjectPositionToList()
        moveObj_saved.Clear()
        For Each obj As Managed3DObject In SelectedObjects
            moveObj_saved.Add(obj.Position)
        Next
    End Sub
    Private Sub saveObjectRotationToList()
        moveObj_saved.Clear()
        For Each obj As Managed3DObject In SelectedObjects
            moveObj_saved.Add(obj.Rotation)
        Next
    End Sub

    Public Sub PictureBox_ObjCntrWheel_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrWheel.MouseDown
        moveObj_UpDown_lastMouseY = e.Y
        StoreObjectHistoryPoint(SelectedObjects, "Position")
        moveObj_UpDown_mouseDown = True
    End Sub
    Public Sub PictureBox_ObjCntrWheel_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrWheel.MouseUp
        moveObj_UpDown_mouseDown = False
    End Sub
    Public Sub PictureBox_ObjCntrWheel_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrWheel.MouseMove
        If moveObj_UpDown_mouseDown Then
            For Each obj As Managed3DObject In SelectedObjects
                moveObjectY(obj, e, False)
            Next
            KeepObjectsOnGround()
            glControl1.Invalidate()
            moveObj_UpDown_lastMouseY = e.Y
        End If
    End Sub

    Public Sub PictureBox_ObjCntrCross_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrCross.MouseDown
        If EditObjects AndAlso SelectedObject IsNot Nothing Then
            Dim objs() As Managed3DObject = SelectedObjects
            If objs.Length = 0 Then Return
            StoreObjectHistoryPoint(objs, "Position")
            moveObj_mouseDown = True
            moveObj_lastMouseX = e.X
            moveObj_lastMouseY = e.Y
            saveObjectPositionToList()
        End If
    End Sub
    Public Sub PictureBox_ObjCntrCross_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrCross.MouseUp
        moveObj_mouseDown = False
    End Sub
    Public Sub PictureBox_ObjCntrCross_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrCross.MouseMove
        If moveObj_mouseDown Then
            If EditObjects AndAlso SelectedObject IsNot Nothing Then
                Dim mo_s_incr As Integer = 0

                For Each obj As Object In SelectedObjects
                    moveObjectXZ(obj, e, moveObj_saved(mo_s_incr), False)
                    mo_s_incr += 1
                Next

                KeepObjectsOnGround()
                glControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub moveObjectY(obj As Managed3DObject, e As MouseEventArgs, forRotation As Boolean)
        If Not forRotation Then
            Dim oldPos As Numerics.Vector3 = obj.Position
            Dim newPos As New Numerics.Vector3(oldPos.X,
                                               oldPos.Y - Math.Truncate(30 * (e.Y - moveObj_UpDown_lastMouseY) * ObjectMoveSpeed),
                                               oldPos.Z)

            obj.Position = newPos
            If Not KeepObjectOnGround Then
                AdvPropertyGrid1.RefreshPropertyValues()
            End If

        Else
            Dim oldRot As Numerics.Vector3 = obj.Rotation
            Dim newRot As New Numerics.Vector3(oldRot.X,
                                               keepDegreesWithin360(oldRot.Y - (Math.Truncate((e.Y - rotObj_Yaw_lastMouseY) * ObjectMoveSpeed))),
                                               oldRot.Z)

            obj.Rotation = newRot
            AdvPropertyGrid1.RefreshPropertyValues()
        End If

        UpdateOrbitCamera()
    End Sub
    Private Sub moveObjectXZ(obj As Managed3DObject, e As MouseEventArgs, savedPos As Numerics.Vector3, forRotation As Boolean)
        Dim speedMult As Single = 30.0F
        Dim mx, my As Integer

        If Not forRotation Then
            mx = e.X - moveObj_lastMouseX
            my = -(e.Y - moveObj_lastMouseY)
        Else
            mx = e.X - rotObj_lastMouseX
            my = -(e.Y - rotObj_lastMouseY)
        End If

        Dim CX As Single = Math.Sin(camera.Yaw)
        Dim CZ As Single = -Math.Cos(camera.Yaw)
        Dim CX_2 As Single = Math.Sin(camera.Yaw + (Math.PI / 2))
        Dim CZ_2 As Single = -Math.Cos(camera.Yaw + (Math.PI / 2))

        If Not forRotation Then
            Dim oldPos As Numerics.Vector3 = obj.Position
            Dim newPos As New Numerics.Vector3(CShort(Math.Truncate(savedPos.X - CShort(Math.Truncate(CX * my * speedMult * ObjectMoveSpeed)) - CShort(Math.Truncate(CX_2 * mx * speedMult * ObjectMoveSpeed)))),
                                               oldPos.Y,
                                               CShort(Math.Truncate(savedPos.Z - CShort(Math.Truncate(CZ * my * speedMult * ObjectMoveSpeed)) - CShort(Math.Truncate(CZ_2 * mx * speedMult * ObjectMoveSpeed)))))

            obj.Position = newPos
            If Not KeepObjectOnGround Then
                AdvPropertyGrid1.RefreshPropertyValues()
            End If
        Else
            speedMult = 0.5F
            Dim oldRot As Numerics.Vector3 = obj.Rotation
            Dim newRot As New Numerics.Vector3(Publics.keepDegreesWithin360(Math.Truncate(savedPos.X - CShort(Math.Truncate(CX * my * speedMult * ObjectMoveSpeed)) - CShort(Math.Truncate(CX_2 * mx * speedMult * ObjectMoveSpeed)))),
                                               oldRot.Y,
                                               Publics.keepDegreesWithin360(Math.Truncate(savedPos.Z - CShort(Math.Truncate(CZ * my * speedMult * ObjectMoveSpeed)) - CShort(Math.Truncate(CZ_2 * mx * speedMult * ObjectMoveSpeed)))))

            obj.Rotation = newRot
            AdvPropertyGrid1.RefreshPropertyValues()
        End If

        UpdateOrbitCamera()
    End Sub

    Private Sub PictureBox_ObjRotWheel_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotWheel.MouseDown
        If EditObjects AndAlso SelectedObject IsNot Nothing Then
            rotObj_Yaw_lastMouseY = e.Y
            StoreObjectHistoryPoint(SelectedObjects, "Rotation")
            rotObj_Yaw_mouseDown = True
        End If
    End Sub
    Private Sub PictureBox_ObjRotWheel_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotWheel.MouseUp
        rotObj_Yaw_mouseDown = False
    End Sub
    Private Sub PictureBox_ObjRotWheel_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotWheel.MouseMove
        If rotObj_Yaw_mouseDown Then
            If EditObjects AndAlso SelectedObject IsNot Nothing Then
                For Each obj As Managed3DObject In SelectedObjects
                    moveObjectY(obj, e, True)
                Next
                'KeepObjectsOnGround()
                glControl1.Invalidate()
                rotObj_Yaw_lastMouseY = e.Y
            End If
        End If
    End Sub

    Private Sub PictureBox_ObjRotCross_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotCross.MouseDown
        If EditObjects AndAlso SelectedObject IsNot Nothing Then
            StoreObjectHistoryPoint(SelectedObjects, "Rotation")
            rotObj_mouseDown = True
            rotObj_lastMouseX = e.X
            rotObj_lastMouseY = e.Y
            saveObjectRotationToList()
        End If
    End Sub
    Private Sub PictureBox_ObjRotCross_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotCross.MouseUp
        rotObj_mouseDown = False
    End Sub
    Private Sub PictureBox_ObjRotCross_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotCross.MouseMove
        If rotObj_mouseDown Then
            If EditObjects AndAlso SelectedObject IsNot Nothing Then
                Dim mo_s_incr As Integer = 0

                For Each obj As Managed3DObject In SelectedObjects
                    moveObjectXZ(obj, e, moveObj_saved(mo_s_incr), True)
                    mo_s_incr += 1
                Next

                KeepObjectsOnGround()
                glControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub PictureBox_CamCntrWheel_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_CamCntrWheel.MouseDown
        moveCam_InOut_mouseDown = True
        moveCam_InOut_lastPosY = e.Y
    End Sub
    Private Sub PictureBox_CamCntrWheel_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_CamCntrWheel.MouseUp
        moveCam_InOut_mouseDown = False
    End Sub
    Private Sub PictureBox_CamCntrWheel_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox_CamCntrWheel.MouseMove
        If moveCam_InOut_mouseDown Then
            camera.resetMouseStuff()
            camera.updateCameraMatrixWithScrollWheel((e.Y - moveCam_InOut_lastPosY) * -10, camMtx)
            savedCamPos = camera.Position
            moveCam_InOut_lastPosY = e.Y
            glControl1.Invalidate()
        End If
    End Sub

    Private Sub PictureBox_CamMoveCross_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_CamMoveCross.MouseDown
        savedCamPos = camera.Position
        moveCam_strafe_mouseDown = True
    End Sub
    Private Sub PictureBox_CamMoveCross_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_CamMoveCross.MouseUp
        camera.resetMouseStuff()
        moveCam_strafe_mouseDown = False
    End Sub
    Private Sub PictureBox_CamMoveCross_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox_CamMoveCross.MouseMove
        If moveCam_strafe_mouseDown Then
            camera.updateCameraOffsetWithMouse(savedCamPos, e.X, e.Y, glControl1.Width, glControl1.Height, camMtx)
            glControl1.Invalidate()
        End If
    End Sub

    Private Sub Camera_NeedSelectedObject(e As Camera.NeedSelectedObjectEventArgs) Handles camera.NeedSelectedObject
        If SelectedObject IsNot Nothing Then
            e.Points = SelectedObjects
        ElseIf True Then
            'e.Points = 
        End If
    End Sub

    Private Sub CheckBoxItem_PerspectiveMode_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs) Handles CheckBoxItem_PerspectiveMode.CheckedChanged
        If sender.Checked Then
            ChangeViewMode(1.048F)
        End If
    End Sub
    Private Sub CheckBoxItem_OrthoMode_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs) Handles CheckBoxItem_OrthoMode.CheckedChanged
        If sender.Checked Then
            ChangeViewMode(1.5708F)
        End If
    End Sub

    Private Sub ChangeViewMode(angle As Single)
        If glControl1 IsNot Nothing Then
            FOV = angle
            UpdateProjMatrix()
            glControl1?.Update()
        End If
    End Sub

#End Region

#Region "Model"

    Private Async Function LoadObjectModels() As Task 'Private Async Function LoadObjectModels() As Task
        objectModels.Clear()

        Dim lvlScriptMain As New Levelscript
        lvlScriptMain.Read(rommgr, rommgr.GetSegBank(&H15).BankAddress, LevelscriptCommandTypes.x1E)
        Await parseLevelscriptAndLoadModels(lvlScriptMain)

        Await parseLevelscriptAndLoadModels(cLevel.Levelscript)
    End Function
    Private Async Function parseLevelscriptAndLoadModels(lvlscript As Levelscript) As Task

        For Each cmd As LevelscriptCommand In lvlscript
            Console.WriteLine(cmd.ToString)

            Select Case cmd.CommandType
                Case LevelscriptCommandTypes.LoadPolygonWithGeo
                    Dim modelID As Byte = clLoadPolygonWithGeo.GetModelID(cmd)
                    Dim mdl As New Object3D
                    Dim segPointer As Integer = clLoadPolygonWithGeo.GetSegAddress(cmd)
                    Dim segID As Byte = segPointer >> 24

                    AddObjectCombosToMyObjectCombos(modelID)
                    If Not knownModelIDs.Contains(modelID) Then knownModelIDs.Add(modelID)

                    Dim seg As SM64Lib.SegmentedBank = rommgr.GetSegBank(segID)
                    If segID <> 0 AndAlso seg IsNot Nothing AndAlso Not objectModels.ContainsKey(modelID) Then

                        Dim glscript As New Script.Geolayoutscript
                        glscript.Read(rommgr, segPointer)

                        Dim mdlScale As Numerics.Vector3 = Numerics.Vector3.One
                        Dim mdlScaleNodeIndex As Integer = -1
                        Dim nodeIndex As Integer = 0

                        For Each gmd As Script.GeolayoutCommand In glscript
                            Select Case gmd.CommandType
                                Case Script.GeolayoutCommandTypes.LoadDisplaylist
                                    Dim geolayer As Byte = cgLoadDisplayList.GetDrawingLayer(gmd)
                                    Dim segAddr As Integer = cgLoadDisplayList.GetSegGeopointer(gmd)

                                    If segAddr > 0 Then
                                        Dim dl As New DisplayList
                                        'dl.FromStream(s, New Geopointer(geolayer, segAddr), rommgr)
                                        'dl.ToObject3D(mdl, rommgr, Numerics.Vector3.Zero)
                                        Await dl.FromStreamAsync(New Geopointer(geolayer, segAddr, mdlScale, Numerics.Vector3.Zero), rommgr, Nothing)
                                        Await dl.ToObject3DAsync(mdl, rommgr, Nothing)
                                    End If

                                Case Script.GeolayoutCommandTypes.LoadDisplaylistWithOffset
                                    Dim geolayer As Byte = cgLoadDisplayListWithOffset.GetDrawingLayer(gmd)
                                    Dim segAddr As Integer = cgLoadDisplayListWithOffset.GetSegGeopointer(gmd)

                                    If segAddr > 0 Then
                                        Dim dl As New DisplayList
                                        Dim geop As New Geopointer(geolayer, segAddr, mdlScale, cgLoadDisplayListWithOffset.GetOffset(gmd))
                                        'dl.FromStream(s, New Geopointer(geolayer, segAddr), rommgr)
                                        'dl.ToObject3D(mdl, rommgr, cgLoadDisplayListWithOffset.GetOffset(gmd))
                                        Await dl.FromStreamAsync(geop, rommgr, Nothing)
                                        Await dl.ToObject3DAsync(mdl, rommgr, Nothing)
                                    End If

                                Case Script.GeolayoutCommandTypes.Scale2
                                    Dim br As New BinaryReader(gmd)
                                    gmd.Position = 4
                                    Dim scale As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                                    mdlScale = New Numerics.Vector3(scale / 65536.0!)
                                    mdlScaleNodeIndex = nodeIndex

                                Case Script.GeolayoutCommandTypes.StartOfNode
                                    nodeIndex += 1

                                Case Script.GeolayoutCommandTypes.EndOfNode
                                    nodeIndex -= 1

                            End Select

                            If mdlScaleNodeIndex > -1 AndAlso mdlScaleNodeIndex > nodeIndex Then
                                mdlScaleNodeIndex = -1
                                mdlScale = Numerics.Vector3.One
                            End If
                        Next

                        glscript.Close()
                        If mdl.Meshes.Count > 0 Then
                            Dim rndr As New Renderer(mdl)
                            rndr.RenderModel()
                            objectModels.Add(modelID, rndr)
                        End If

                    End If

                Case LevelscriptCommandTypes.LoadPolygonWithoutGeo
                    Dim modelID As Byte = clLoadPolygonWithoutGeo.GetModelID(cmd)
                    Dim segPointer As Integer = clLoadPolygonWithoutGeo.GetSegAddress(cmd)
                    Dim layer As Integer = clLoadPolygonWithoutGeo.GetDrawingLayer(cmd)
                    Dim segID As Byte = segPointer >> 24

                    AddObjectCombosToMyObjectCombos(modelID)
                    If Not knownModelIDs.Contains(modelID) Then knownModelIDs.Add(modelID)

                    Dim seg As SM64Lib.SegmentedBank = rommgr.GetSegBank(segID)
                    If segID <> 0 AndAlso seg IsNot Nothing AndAlso Not objectModels.ContainsKey(modelID) Then
                        Dim mdl = New Object3D

                        Dim dl As New DisplayList
                        'dl.FromStream(s, New Geopointer(layer, segPointer), rommgr)
                        'dl.ToObject3D(mdl, rommgr, Numerics.Vector3.Zero)
                        Await dl.FromStreamAsync(New Geopointer(layer, segPointer), rommgr, Nothing)
                        Await dl.ToObject3DAsync(mdl, rommgr, Nothing)

                        Dim rndr As New Renderer(mdl)
                        rndr.RenderModel()
                        objectModels.Add(modelID, rndr)
                    End If

                Case LevelscriptCommandTypes.PaintingWarp
                    '...

                Case LevelscriptCommandTypes.JumpToSegAddr
                    Dim bankAddr As Integer = clJumpToSegAddr.GetSegJumpAddr(cmd)
                    Dim segID As Byte = bankAddr >> 24

                    Dim seg As SM64Lib.SegmentedBank = rommgr.GetSegBank(segID)
                    If segID <> 0 AndAlso seg IsNot Nothing Then
                        Dim scrpt As New Levelscript
                        scrpt.Read(rommgr, bankAddr, LevelscriptCommandTypes.JumpBack)
                        'parseLevelscriptAndLoadModels(scrpt, segData, s)
                        Await parseLevelscriptAndLoadModels(scrpt)
                    Else
                        Console.WriteLine("Doesn't know Seg-ID: " & segID.ToString)
                    End If

                Case LevelscriptCommandTypes.LoadRomToRam, LevelscriptCommandTypes.x1A, LevelscriptCommandTypes.x18
                    Dim segID As Byte = clLoadRomToRam.GetSegmentedID(cmd)

                    Dim segg As SM64Lib.SegmentedBank = rommgr.GetSegBank(segID)
                    If segg Is Nothing Then
                        Dim seg As New SM64Lib.SegmentedBank
                        seg.BankID = segID
                        seg.RomStart = clLoadRomToRam.GetRomStart(cmd)
                        seg.RomEnd = clLoadRomToRam.GetRomEnd(cmd)
                        If cmd.CommandType = LevelscriptCommandTypes.x1A Then seg.MakeAsMIO0()
                        'loadRomToTemporarySegData(seg, s)
                        rommgr.SetSegBank(seg)
                    End If

            End Select

        Next

    End Function
    Private Sub AddObjectCombosToMyObjectCombos(modelID As Byte)
        For Each obj As ObjectComboList.ObjectCombo In ObjectCombos
            If obj.ModelID = modelID AndAlso Not myObjectCombos.Contains(obj) Then
                myObjectCombos.Add(obj)
            End If
        Next
    End Sub

    Private Async Function LoadAreaModel() As Task
        If cArea IsNot Nothing Then
            ProgressControl(True)

            Select Case CurrentModelDrawMod
                Case ModelDrawMod.Collision
                    If cCollisionMap Is Nothing Then
                        Await LoadAreaCollisionAsObject3D()
                    End If
                    If rndrCollisionMap Is Nothing Then
                        rndrCollisionMap = New Renderer(cCollisionMap)
                        rndrCollisionMap.RenderModel()
                        LoadCollisionLists()
                    End If
                Case ModelDrawMod.VisualMap
                    If cVisualMap Is Nothing Then
                        Await LoadAreaVisualMapAsObject3D()
                    End If
                    If rndrVisualMap Is Nothing Then
                        rndrVisualMap = New Renderer(cVisualMap)
                        rndrVisualMap.RenderModel()
                    End If
            End Select
            glControl1.Invalidate()

            ProgressControl(False)
        End If
    End Function

    Private Async Function LoadAreaCollisionAsObject3D() As Task
        cCollisionMap = Await cArea.AreaModel.Collision.ToObject3DAsync
    End Function

    Private Async Function LoadAreaVisualMapAsObject3D() As Task
        cVisualMap = Await General.LoadAreaVisualMapAsObject3D(rommgr, cArea)
    End Function

    Public Sub LoadCollisionLists()
        ListViewEx_ColFaces.SuspendLayout()
        ListViewEx_CollVertices.SuspendLayout()

        ListViewEx_ColFaces.Items.Clear()
        ListViewEx_CollVertices.Items.Clear()

        If cArea.AreaModel.Collision IsNot Nothing Then
            Dim vertCounter As Integer = 0
            Dim faceCounter As Integer = 0

            For Each mesh As Mesh In cCollisionMap.Meshes
                Dim lvg_verts As New ListViewGroup

                For Each vert As Vertex In mesh.Vertices
                    Dim lvi As New ListViewItem(vertCounter)
                    lvi.SubItems.Add(vert.X.ToString)
                    lvi.SubItems.Add(vert.Y.ToString)
                    lvi.SubItems.Add(vert.Z.ToString)
                    lvi.Tag = vert
                    lvi.Group = lvg_verts
                    ListViewEx_CollVertices.Items.Add(lvi)
                    vertCounter += 1
                Next

                Dim lvg_faces As New ListViewGroup
                Dim vertsCountBefore As Integer = vertCounter - mesh.Vertices.Count

                For Each f As Face In mesh.Faces
                    Dim lvi As New ListViewItem(faceCounter)
                    For Each p As Point In f.Points
                        lvi.SubItems.Add(mesh.Vertices.IndexOf(p.Vertex) + vertsCountBefore)
                    Next
                    lvi.SubItems.Add(f.Tag.ToString)
                    lvi.Tag = f
                    lvi.Group = lvg_faces
                    ListViewEx_ColFaces.Items.Add(lvi)
                    faceCounter += 1
                Next
            Next
        End If

        ListViewEx_ColFaces.ResumeLayout()
        ListViewEx_CollVertices.ResumeLayout()
    End Sub

    Private Async Sub ButtonItem_ExportCollision_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportCollision.Click, ButtonItem86.Click
        If cArea.AreaModel.Collision IsNot Nothing Then
            Await LoadAreaCollisionAsObject3D()
            Publics.Publics.ExportModel(rndrCollisionMap.Model, LoaderModule.SimpleFileParser)
        End If
    End Sub
    Private Async Sub ButtonItem_ExportVisualMap_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportVisualMap.Click
        If cArea.AreaModel.Fast3DBuffer IsNot Nothing Then
            Await LoadAreaVisualMapAsObject3D()
            Publics.Publics.ExportModel(rndrVisualMap.Model, LoaderModule.SimpleFileParser)
        End If
    End Sub

#End Region

#Region "General"

    Public Sub UpdateOrbitCamera()
        If camera.IsOrbitCamera() Then
            camera.updateOrbitCamera(camMtx)
        End If
    End Sub

    Private Sub ButtonItem_SaveRom_Click(sender As Object, e As EventArgs) Handles ButtonItem_SaveRom.Click
        SaveAllObjectProperties()
        SaveAllWarpProperties()

        ProgressControl(True)
        rommgr_SavingRom = True

        SaveRom(rommgr)

        rommgr_SavingRom = False
        ProgressControl(False)
    End Sub

    Private Sub ButtonItem_LaunchROM_Click(sender As Object, e As EventArgs) Handles ButtonItem_LaunchROM.Click
        Do While rommgr_SavingRom
            Application.DoEvents()
        Loop

        LaunchRom(rommgr)
    End Sub

    Public Sub SetCameraMode(mode As CameraMode)
        camera.SetCameraMode(mode, camMtx)
        'camera.updateMatrix(camMtx)
        glControl1.Invalidate()
    End Sub
    Public Sub SetCameraMode(mode As CameraMode, look As LookDirection)
        camera.SetCameraMode(mode, camMtx)
        camera.setCameraMode_LookDirection(look, camMtx)
        'camera.updateMatrix(camMtx)
        glControl1.Invalidate()
    End Sub
    Public Function GetCamerMode() As CameraMode
        Return camera.CamMode
    End Function

#End Region

#Region "Features"

#Region "Copy & Paste"

    Private Sub ButtonItem_Copy_Click(sender As Object, e As EventArgs) Handles ButtonX_WarpsCopy.Click, ButtonItem_ObjectsCopy.Click, ButtonItem6.Click, ButtonItem9.Click
        CopySelection()
    End Sub
    Private Sub PasteObjectDefault(sender As Object, e As EventArgs) Handles ButtonItem_PasteObjDefault.Click, ButtonItem_PasteObjCombo.Click, ButtonItem_PasteObjRot.Click, ButtonItem_PasteObjPos.Click, ButtonItem_PasteObjBParams.Click, ButtonItem_PasteObjActs.Click, ButtonItem_PasteObjBehavID.Click, ButtonItem_PasteObjModelID.Click, ButtonItem37.Click
        Dim isDefault As Boolean = sender Is ButtonItem_PasteObjDefault OrElse sender Is ButtonItem37
        PasteSelection(New PasteObjectSettings With {
                       .DataFormat = "sm64lvlcmdobj3d",
                       .PasteBehavID = isDefault OrElse sender Is ButtonItem_PasteObjCombo OrElse sender Is ButtonItem_PasteObjBehavID,
                       .PasteActs = isDefault OrElse sender Is ButtonItem_PasteObjActs,
                       .PasteBParams = isDefault OrElse sender Is ButtonItem_PasteObjBParams,
                       .PasteModelID = isDefault OrElse sender Is ButtonItem_PasteObjCombo OrElse sender Is ButtonItem_PasteObjModelID,
                       .PastePosition = isDefault OrElse sender Is ButtonItem_PasteObjPos,
                       .PasteRotation = isDefault OrElse sender Is ButtonItem_PasteObjRot
                       })
    End Sub
    Private Sub PasteWarpDefault(sender As Object, e As EventArgs) Handles ButtonItem_PasteWarpDefault.Click, ButtonX_PasteWarpDefault.Click, ButtonItem_PasteWarpDestWarp.Click, ButtonItem_PasteWarpDestLevel.Click, ButtonItem_PasteWarpDestArea.Click, ButtonItem5.Click
        Dim isDefault As Boolean = sender Is ButtonItem_PasteWarpDefault OrElse sender Is ButtonItem5
        PasteSelection(New PasteWarpSettings With {
                       .DataFormat = "sm64lvlcmdconnectwarp",
                       .PasteDestArea = isDefault OrElse sender Is ButtonItem_PasteWarpDestArea,
                       .PasteDestLevel = isDefault OrElse sender Is ButtonItem_PasteWarpDestLevel,
                       .PasteDestWarp = isDefault OrElse sender Is ButtonItem_PasteWarpDestWarp
                       })
    End Sub

    Private Sub CopySelection()
        Dim cmds As New List(Of LevelscriptCommand)
        Dim format As String = ""

        For Each item As ListViewItem In selectedList.SelectedItems
            Select Case True
                Case EditObjects
                    Dim obj As Managed3DObject = CType(item.Tag, Managed3DObject)
                    obj.SaveProperties()
                    cmds.Add(obj.Command)
                    format = "sm64lvlcmdobj3d"
                Case EditWarps
                    Dim warp As IManagedLevelscriptCommand = CType(item.Tag, IManagedLevelscriptCommand)
                    If TypeOf warp Is ManagedWarp Then
                        warp.SaveProperties()
                        cmds.Add(warp.Command)
                        format = "sm64lvlcmdconnectwarp"
                    End If
            End Select
        Next

        Clipboard.SetData(format, cmds.ToArray)
    End Sub
    Private Sub PasteSelection(pasteSettings As PasteSettings)
        If Clipboard.ContainsData(pasteSettings.DataFormat) Then
            Dim cmds() As LevelscriptCommand = Clipboard.GetData(pasteSettings.DataFormat)

            Dim indexListToUse As ListViewEx = Nothing
            Dim cmdListToUse As List(Of LevelscriptCommand) = Nothing
            Select Case pasteSettings.GetType
                Case GetType(PasteObjectSettings)
                    indexListToUse = ListViewEx_Objects
                    cmdListToUse = cArea.Objects
                Case GetType(PasteWarpSettings)
                    indexListToUse = ListViewEx_Warps
                    cmdListToUse = cArea.Warps
            End Select

            If indexListToUse.SelectedIndices.Count > 0 Then
                Dim curCmdIndex As Integer = 0

                Do
                    Dim curCmd1 As LevelscriptCommand '= cmdListToUse(curListIndex)
                    Dim curCmd2 As LevelscriptCommand = cmds(curCmdIndex)

                    Select Case pasteSettings.GetType
                        Case GetType(PasteObjectSettings)

                            Dim mobj As Managed3DObject = indexListToUse.SelectedItems(curCmdIndex).Tag
                            curCmd1 = mobj.Command
                            mobj.SaveProperties()

                            With CType(pasteSettings, PasteObjectSettings)
                                If .PasteModelID Then clNormal3DObject.SetModelID(curCmd1, clNormal3DObject.GetModelID(curCmd2))
                                If .PasteBehavID Then clNormal3DObject.SetSegBehaviorAddr(curCmd1, clNormal3DObject.GetSegBehaviorAddr(curCmd2))
                                If .PasteBParams Then clNormal3DObject.SetParams(curCmd1, clNormal3DObject.GetParams(curCmd2))
                                If .PasteActs Then clNormal3DObject.SetActs(curCmd1, clNormal3DObject.GetActs(curCmd2))
                                If .PastePosition Then clNormal3DObject.SetPosition(curCmd1, clNormal3DObject.GetPosition(curCmd2))
                                If .PasteRotation Then clNormal3DObject.SetRotation(curCmd1, clNormal3DObject.GetRotation(curCmd2))
                            End With

                            mobj.LoadProperties()

                        Case GetType(PasteWarpSettings)

                            Dim mwarp As IManagedLevelscriptCommand = indexListToUse.SelectedItems(curCmdIndex).Tag
                            curCmd1 = mwarp.Command
                            mwarp.SaveProperties()

                            If TypeOf mwarp Is ManagedWarp Then
                                With CType(pasteSettings, PasteWarpSettings)
                                    If .PasteDestLevel Then clWarp.SetDestinationLevelID(curCmd1, clWarp.GetDestinationLevelID(curCmd2))
                                    If .PasteDestArea Then clWarp.SetDestinationAreaID(curCmd1, clWarp.GetDestinationAreaID(curCmd2))
                                    If .PasteDestWarp Then clWarp.SetDestinationWarpID(curCmd1, clWarp.GetDestinationWarpID(curCmd2))
                                End With
                            End If

                            mwarp.LoadpProperties()

                    End Select

                    curCmdIndex += 1

                    If curCmdIndex = cmds.Length Then
                        If curCmdIndex >= indexListToUse.SelectedIndices.Count Then
                            Exit Do
                        Else
                            curCmdIndex = 0
                        End If
                    End If
                Loop
            End If

            Select Case pasteSettings.GetType
                Case GetType(PasteObjectSettings)
                    UpdateObjectListViewItems()
                    AdvPropertyGrid1.RefreshPropertyValues()
                Case GetType(PasteWarpSettings)
                    UpdateWarpListViewItem()
                    AdvPropertyGrid1.RefreshPropertyValues()
            End Select
        End If
    End Sub

    Private Class PasteSettings
        Public Property DataFormat As String = ""
    End Class
    Private Class PasteObjectSettings
        Inherits PasteSettings

        Public Property PasteModelID As Boolean = False
        Public Property PasteBehavID As Boolean = False
        Public Property PasteBParams As Boolean = False
        Public Property PasteActs As Boolean = False
        Public Property PastePosition As Boolean = False
        Public Property PasteRotation As Boolean = False
    End Class
    Private Class PasteWarpSettings
        Inherits PasteSettings

        Public Property PasteDestLevel As Boolean = False
        Public Property PasteDestArea As Boolean = False
        Public Property PasteDestWarp As Boolean = False
    End Class

#Region "Clear Clipboard"

    Private Sub ButtonItem44_Click(sender As Object, e As EventArgs) Handles ButtonItem44.Click, ButtonItem81.Click
        Clipboard.Clear()
    End Sub

#End Region

#End Region

#Region "History"

    Private Function StoreHistoryPoint(miUndo As MethodInfo, miRedo As MethodInfo, param As Object()) As HistoryPoint
        Return StoreHistoryPoint(miUndo, miRedo, param, param)
    End Function
    Private Function StoreHistoryPoint(obj As Object, miUndo As MethodInfo, miRedo As MethodInfo, param As Object()) As HistoryPoint
        Return StoreHistoryPoint(obj, miUndo, miRedo, param, param)
    End Function
    Private Function StoreHistoryPoint(miUndo As MethodInfo, miRedo As MethodInfo, paramUndo As Object(), paramRedo As Object()) As HistoryPoint
        Return StoreHistoryPoint(Nothing, miUndo, miRedo, paramUndo, paramRedo)
    End Function
    Private Function StoreHistoryPoint(obj As Object, miUndo As MethodInfo, miRedo As MethodInfo, paramUndo As Object(), paramRedo As Object()) As HistoryPoint
        Dim act As New ObjectAction(obj, miUndo, miRedo, paramUndo, paramUndo)
        Return StoreHistoryPoint(act)
    End Function
    Private Function StoreHistoryPoint(ParamArray actions As ObjectAction()) As HistoryPoint
        Dim hp As New HistoryPoint
        hp.Actions.AddRange(actions)
        history.Store(hp)
        Return hp
    End Function

    Private Sub StoreObjectHistoryPointUsingFocus(objs As Object(), ParamArray whitelist As String())
        If Not waitUntilLostFocus Then
            waitUntilLostFocus = True
            StoreObjectHistoryPoint(objs, whitelist)
        End If
    End Sub
    Private Sub StoreObjectHistoryPoint(objs As Object(), ParamArray whitelist As String())
        Dim hps As New List(Of HistoryPoint)

        For Each obj As Object In objs
            hps.Add(HistoryPoint.FromObject(obj, ObjectValueType.Property, defBindFlags, True, whitelist))
        Next

        If objs.Count > 0 Then
            Dim hp As HistoryPoint = HistoryPoint.Concat(hps.ToArray)
            If hp.States.Count > 0 Then
                history.Store(hp)
            End If
        End If
    End Sub

    Private Sub ButtonItem_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItem_Undo.Click
        history.Undo()
        RefreshAfterHistoryAction()
    End Sub
    Private Sub ButtonItem_Redo_Click(sender As Object, e As EventArgs) Handles ButtonItem_Redo.Click
        history.Redo()
        RefreshAfterHistoryAction()
    End Sub
    Private Sub RefreshAfterHistoryAction()
        Me.SuspendLayout()
        UpdateObjectListViewItems()
        UpdateWarpListViewItem()
        AdvPropertyGrid1.RefreshPropertyValues()
        UpdateOrbitCamera()
        Me.ResumeLayout()
        glControl1.Invalidate()
    End Sub

#End Region

#Region "Screenshot"

    Private Sub ButtonItem22_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        If CurrentModelDrawMod = ModelDrawMod.VisualMap Then

            Dim sfd As New SaveFileDialog With {.Filter = "PNG-File (*.png)|*.png|BMP-File (*.bmp)|*.bmp|GIF-File (*.gif)|*.gif|JPEG-File (*.jpeg)|*.jpeg"}
            If sfd.ShowDialog <> DialogResult.OK Then Return

            GL.ClearColor(Color.CornflowerBlue)
            GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
            GL.MatrixMode(MatrixMode.Projection)
            GL.LoadMatrix(ProjMatrix)
            GL.MatrixMode(MatrixMode.Modelview)
            GL.LoadMatrix(camMtx)

            DrawAllObjects(, False)

            If rndrVisualMap IsNot Nothing Then
                rndrVisualMap?.DrawModel(OpenGLRenderer.RenderMode.Fill)
            End If

            Dim img As Image = TakeScreenshotOfGL()
            img.Save(sfd.FileName)

        Else MessageBoxEx.Show("Please select the Visual Map and try again.", "Not Visual Map selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function TakeScreenshotOfGL() As Image
        'Create new Bitmap
        Dim bmp As New Bitmap(glControl1.Width, glControl1.Height)

        'Lock Bits & Get Bitmap Data
        Dim bmpdata As Imaging.BitmapData = bmp.LockBits(New Rectangle(0, 0, glControl1.Size.Width, glControl1.Size.Height), Imaging.ImageLockMode.WriteOnly, Imaging.PixelFormat.Format24bppRgb)

        'Get Screenshot
        GL.ReadPixels(0, 0, glControl1.Size.Width, glControl1.Size.Height, PixelFormat.Bgr, PixelType.UnsignedByte, bmpdata.Scan0)

        'Unlook Bits
        bmp.UnlockBits(bmpdata)

        'Rotate at Y
        bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)

        Return bmp
    End Function

#End Region

#Region "Fullscreen"

    Private Sub ButtonItem2_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItem2.CheckedChanged
        Me.SuspendLayout()

        Select Case ButtonItem2.Checked
            Case True
                isFullscreen = True
                TopMost = True
                ButtonItem2.Text = "Disable Fullscreen"
                FormBorderStyle = FormBorderStyle.None
                backupWindowState = WindowState
                WindowState = FormWindowState.Maximized
                RibbonControl1.CaptionVisible = False
                RibbonControl1.Height -= 28
            Case False
                isFullscreen = False
                TopMost = False
                ButtonItem2.Text = "Enable Fullscreen"
                FormBorderStyle = FormBorderStyle.Sizable
                WindowState = backupWindowState
                RibbonControl1.Height += 28
                RibbonControl1.CaptionVisible = True
        End Select

        Me.ResumeLayout()
    End Sub

#End Region

#End Region

#Region "Lists"

    Private lvg_ConnectedWarps As New ListViewGroup With {.Header = "Connected Warps"}
    Private lvg_WarpsForGame As New ListViewGroup With {.Header = "Warps for Game"}
    Private lvg_PaintingWarps As New ListViewGroup With {.Header = "Painting Warps"}
    Private lvg_InstantWarps As New ListViewGroup With {.Header = "Instant Warps"}
    'Private lvg_Objects As New ListViewGroup With {.Header = "3D Objects"}
    'Private lvg_MacroObjects As New ListViewGroup With {.Header = "Macro 3D Objects"}

    Private Sub LoadAreaIDs()
        isLoadingAreaIDs = True
        ComboBoxItem_Area.Items.Clear()
        Dim indexToSelect As Byte = 0
        For Each a As LevelArea In cLevel.Areas
            ComboBoxItem_Area.Items.Add($"Area {a.AreaID}")
            If a.AreaID = areaIdToLoad Then indexToSelect = cLevel.Areas.IndexOf(a)
        Next
        isLoadingAreaIDs = False
        ComboBoxItem_Area.SelectedIndex = indexToSelect
    End Sub
    Private Sub LoadObjectLists()
        ListViewEx_Objects.SuspendLayout()

        ListViewEx_Objects.Items.Clear()
        managedObjects.Clear()

        Dim i As Integer = 0
        For Each objj In cArea.Objects
            Dim objNew As New Managed3DObject(objj, myObjectCombos)
            managedObjects.Add(objNew)
            Dim lvi As New ListViewItem
            lvi.Tag = objNew
            lvi.SubItems.Add(New ListViewItem.ListViewSubItem)
            SetObjectPropertiesToListViewItem(lvi, objNew, i)
            ListViewEx_Objects.Items.Add(lvi)
            i += 1
        Next

        'Select first Item
        SelectItemAtIndexInList(ListViewEx_Objects, 0, True)

        ListViewEx_Objects.ResumeLayout()
    End Sub
    Private Sub SelectItemAtIndexInList(list As ListViewEx, index As Integer, deselectAllOtherItems As Boolean)
        For i As Integer = 0 To list.Items.Count - 1
            If i = index Then
                list.Items(i).Selected = True
            ElseIf deselectAllOtherItems Then
                list.Items(i).Selected = False
            End If
        Next
    End Sub
    Private Sub LoadWarpsLists()
        ListViewEx_Warps.SuspendLayout()

        ListViewEx_Warps.Items.Clear()
        managedWarps.Clear()

        Dim allWarps As New List(Of LevelscriptCommand)
        Dim gameWarpsStart, gameWarpCount As Integer

        allWarps.AddRange(cArea.Warps)
        gameWarpsStart = allWarps.Count
        gameWarpCount = cArea.WarpsForGame.Count
        allWarps.AddRange(cArea.WarpsForGame)

        For Each warp As LevelscriptCommand In allWarps
            Dim warpNew As IManagedLevelscriptCommand = Nothing
            Dim lvi As New ListViewItem With {.Tag = warpNew}

            'Set the ListViewGroup for the ListViewItem
            Select Case warp.CommandType
                Case LevelscriptCommandTypes.ConnectedWarp
                    Dim warpIndex As Integer = allWarps.IndexOf(warp)
                    If warpIndex >= gameWarpsStart AndAlso warpIndex <= gameWarpsStart + gameWarpCount Then
                        lvi.Group = lvg_WarpsForGame
                    Else
                        lvi.Group = lvg_ConnectedWarps
                    End If
                    warpNew = New ManagedWarp(warp)
                Case LevelscriptCommandTypes.PaintingWarp
                    lvi.Group = lvg_PaintingWarps
                    warpNew = New ManagedWarp(warp)
                Case LevelscriptCommandTypes.InstantWarp
                    warpNew = New ManagedInstantWarp(warp)
            End Select

            'Set managed Warp as Tag
            lvi.Tag = warpNew

            'Add enought SubItems to ListviewItem
            For i As Integer = 2 To 4
                lvi.SubItems.Add(New ListViewItem.ListViewSubItem)
            Next

            'Set all Properties as Text to the SubItems
            SetWarpPropertiesToListViewItem(lvi, warpNew)

            managedWarps.Add(warpNew)
            ListViewEx_Warps.Items.Add(lvi)
        Next

        'Select first Item
        If ListViewEx_Warps.Items.Count > 0 Then
            With ListViewEx_Warps.Items(0)
                .Selected = True
            End With
        End If

        ListViewEx_Warps.ResumeLayout()
    End Sub
    Private Sub SetWarpPropertiesToListViewItem(ByRef lvi As ListViewItem, iwarp As IManagedLevelscriptCommand)
        If TypeOf iwarp Is ManagedWarp Then
            Dim warp As ManagedWarp = iwarp

            Dim destLevel = rommgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = warp.DestLevelID)
            lvi.SubItems(0).Text = WarpIDToString(warp.WarpID)
            lvi.SubItems(1).Text = $"{destLevel?.TypeString}-{destLevel?.Number}"
            lvi.SubItems(2).Text = TextFromValue(warp.DestAreaID)
            lvi.SubItems(3).Text = TextFromValue(warp.DestWarpID)

            Dim colorToUse As Color
            Try
                colorToUse = GetColorOfWarpDestinationValidationResult(warp)
            Catch ex As Exception
                colorToUse = Nothing
            End Try
            For Each subitem As ListViewItem.ListViewSubItem In lvi.SubItems
                subitem.ForeColor = colorToUse
            Next

        ElseIf TypeOf iwarp Is ManagedInstantWarp Then
            Dim warp As ManagedInstantWarp = iwarp

            lvi.SubItems(0).Text = ""
            lvi.SubItems(1).Text = ValueFromText(warp.CollisionType)
            lvi.SubItems(2).Text = ValueFromText(warp.DestAreaID)
            lvi.SubItems(3).Text = ""

        End If
    End Sub
    Private Sub SetObjectPropertiesToListViewItem(ByRef lvi As ListViewItem, obj As Managed3DObject, Optional objIndex As Integer = -1)
        If objIndex > -1 Then lvi.SubItems(0).Text = objIndex + 1
        lvi.SubItems(1).Text = myObjectCombos.GetObjectComboOfObject(obj).Name
    End Sub
    Private Function WarpIDToString(id As Byte) As String
        Select Case id
            Case 241
                Return "Failure"
            Case 240
                Return "Success"
            Case Else
                Return TextFromValue(id)
        End Select
    End Function

    Private Sub DeselectAllListViewItems(ListView As ListViewEx)
        ListView.SuspendLayout()
        For Each item As ListViewItem In ListView.Items
            item.Focused = False
            item.Selected = False
        Next
        ListView.ResumeLayout()
    End Sub

    Private Sub ListViewEx_Objects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_Objects.SelectedIndexChanged
        If Not loadingObj AndAlso SelectedObject IsNot Nothing Then
            SelectObjects(SelectedObjects)
            ShowObjectProperties()
        End If
        PanelDockContainer10.DockContainerItem.Selected = True
    End Sub

    Private Sub ListViewEx_Warps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_Warps.SelectedIndexChanged
        Dim selectedIndexes = ListViewEx_Warps.SelectedIndices
        If selectedIndexes.Count > 0 Then
            ShowWarpProterties()
            PanelDockContainer10.DockContainerItem.Selected = True
        End If
    End Sub

    Private ReadOnly Property SelectedObject As Managed3DObject
        Get
            If ListViewEx_Objects.SelectedIndices.Count = 0 Then Return Nothing
            Return ListViewEx_Objects.SelectedItems(0).Tag
        End Get
    End Property
    Private ReadOnly Property SelectedObjects As Managed3DObject()
        Get
            If ListViewEx_Objects.SelectedIndices.Count = 0 Then Return {}
            Dim objs As New List(Of Managed3DObject)
            For Each item As ListViewItem In ListViewEx_Objects.SelectedItems
                objs.Add(item.Tag)
            Next
            Return objs.ToArray
        End Get
    End Property

    Private Sub SelectObject(obj As Managed3DObject, Optional DeselectAllObjects As Boolean = True)
        SelectObjects({obj}, DeselectAllObjects)
    End Sub
    Private Sub SelectObjects(objs() As Managed3DObject, Optional DeselectAllObjects As Boolean = True)
        If DeselectAllObjects Then Me.DeselectAllObjects(False)

        For Each obj As Managed3DObject In objs
            If obj IsNot Nothing Then
                obj.IsSelected = True
            End If
        Next

        UpdateOrbitCamera()
        glControl1.Invalidate()
        glControl1.Update()
    End Sub
    Private Sub DeselectAllObjects(Optional UpdateGLAndCamera As Boolean = True)
        For Each obj As Managed3DObject In managedObjects
            obj.IsSelected = False
        Next

        If UpdateGLAndCamera Then
            UpdateOrbitCamera()
            glControl1.Invalidate()
            glControl1.Update()
        End If
    End Sub
    Private Sub ToogleObjectSelection(obj As Managed3DObject)
        obj.IsSelected = Not obj.IsSelected

        With ListViewEx_Objects.Items(managedObjects.IndexOf(obj))
            .Selected = Not .Selected
        End With

        UpdateOrbitCamera()
        glControl1.Invalidate()
        glControl1.Update()
    End Sub

    Private ReadOnly Property SelectedWarp As IManagedLevelscriptCommand
        Get
            If ListViewEx_Warps.SelectedIndices.Count = 0 Then Return Nothing
            Return ListViewEx_Warps.SelectedItems(0).Tag
        End Get
    End Property
    Private ReadOnly Property SelectedWarps As IManagedLevelscriptCommand()
        Get
            If ListViewEx_Warps.SelectedIndices.Count = 0 Then Return {}
            Dim objs As New List(Of IManagedLevelscriptCommand)
            For Each item As ListViewItem In ListViewEx_Warps.SelectedItems
                objs.Add(item.Tag)
            Next
            Return objs.ToArray
        End Get
    End Property

    Private Sub ListViewEx_Objects_Click(sender As Object, e As EventArgs) Handles ListViewEx_Warps.Click, ListViewEx_Objects.Click, ListViewEx_CollVertices.Click, ListViewEx_ColFaces.Click
        selectedList = sender
    End Sub

    Private ReadOnly Property EditCollision As Boolean
        Get
            Return EditCollisionVertices OrElse EditCollisionFaces
        End Get
    End Property
    Private ReadOnly Property EditCollisionVertices As Boolean
        Get
            Return selectedList Is ListViewEx_CollVertices
        End Get
    End Property
    Private ReadOnly Property EditCollisionFaces As Boolean
        Get
            Return selectedList Is ListViewEx_ColFaces
        End Get
    End Property
    Private ReadOnly Property EditObjects As Boolean
        Get
            Return selectedList Is ListViewEx_Objects
        End Get
    End Property
    Private ReadOnly Property EditWarps As Boolean
        Get
            Return selectedList Is ListViewEx_Warps
        End Get
    End Property
    Private ReadOnly Property EditWarpsDefault As Boolean
        Get
            Return ListViewEx_Warps.SelectedIndices().Count > 0 AndAlso IsGroupWarpDefault(ListViewEx_Warps.SelectedItems(0))
        End Get
    End Property
    Private Function IsGroupWarpDefault(item As ListViewItem) As Boolean
        Return item.Group Is lvg_ConnectedWarps
    End Function
    Private ReadOnly Property EditWarpsForGame As Boolean
        Get
            Return ListViewEx_Warps.SelectedIndices().Count > 0 AndAlso IsGroupWarpForGame(ListViewEx_Warps.SelectedItems(0))
        End Get
    End Property
    Private Function IsGroupWarpForGame(item As ListViewItem) As Boolean
        Return item.Group Is lvg_WarpsForGame
    End Function

    Private Sub ListViewEx_Objects_MouseClick(sender As Object, e As MouseEventArgs) Handles ListViewEx_Objects.MouseClick
        If e.Button = MouseButtons.Right Then
            ButtonItem_CM_Objects.Popup(Cursor.Position)
        End If
    End Sub
    Private Sub ListViewEx_Warps_MouseClick(sender As Object, e As MouseEventArgs) Handles ListViewEx_Warps.MouseClick
        If e.Button = MouseButtons.Right Then
            ButtonItem1_CM_Warps.Popup(Cursor.Position)
        End If
    End Sub

#End Region

#Region "Area"

    Private Async Function SwitchCurrentArea() As Task
        If Not isLoadingAreaIDs Then

            'If backupCurrentAreaIndex > -1 Then
            '    Dim hp As New HistoryPoint
            '    Dim os As New ObjectState
            '    os.Object = ComboBoxItem_Area
            '    os.ValueToPatch = backupCurrentAreaIndex
            '    os.MemberName = "SelectedIndex"
            '    os.MemberType = ObjectValueType.Property
            '    os.MemberFlags = BindingFlags.Public Or BindingFlags.Instance
            '    hp.States.Add(os)
            '    history.Store(hp)
            'End If
            If Not dicHistories.ContainsKey(cArea) Then
                Dim hs As New HistoryStack
                dicHistories.Add(cArea, hs)
                history = hs
            Else
                history = dicHistories(cArea)
            End If
            backupCurrentAreaIndex = ComboBoxItem_Area.SelectedIndex

            SaveAllObjectProperties()
            SaveAllWarpProperties()

            rndrCollisionMap?.ReleaseBuffers()
            rndrCollisionMap = Nothing
            rndrVisualMap?.ReleaseBuffers()
            rndrVisualMap = Nothing
            Await LoadAreaModel()

            LoadObjectLists()
            LoadWarpsLists()

            If Settings.AreaEditor.DefaultCameraMode = CameraMode.ORBIT Then
                ButtonItem_CamOrbit.RaiseClick()
            Else
                ButtonItem_CamFly.RaiseClick()
            End If

        End If
    End Function
    Private Async Sub ComboBoxEx_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItem_Area.SelectedIndexChanged
        Await SwitchCurrentArea()
    End Sub

    Private Sub ButtonItem47_Click(sender As Object, e As EventArgs) Handles ButtonItem47.Click
        ButtonItem_ImportModel.RaiseClick()
    End Sub
    Private Async Sub ButtonItem_ImportModel_Click(sender As Object, e As EventArgs) Handles ButtonItem_ImportModel.Click, ButtonItem_ImportCollision.Click, ButtonItem_ImportVisualMap.Click, ButtonItem85.Click
        Dim frm As New MainModelConverter
        frm.CheckBoxX_ConvertModel.Checked = sender Is ButtonItem_ImportModel OrElse sender Is ButtonItem_ImportVisualMap
        frm.CheckBoxX_ConvertCollision.Checked = sender Is ButtonItem_ImportModel OrElse sender Is ButtonItem_ImportCollision OrElse sender Is ButtonItem85

        With cArea

            If frm.ShowDialog() <> DialogResult.OK Then
                glControl1.MakeCurrent()
                Return
            End If

            glControl1.MakeCurrent()
            Me.SuspendLayout()

            Dim hp As HistoryPoint = Nothing
            Dim OldAreaModel As ObjectModel = .AreaModel

            If frm.CheckBoxX_ConvertCollision.Checked AndAlso frm.CheckBoxX_ConvertModel.Checked Then

                hp = HistoryPoint.FromObject(CObj(Me), ObjectValueType.Field, New MemberWhiteList({"rndrVisualMap", "cVisualMap", "rndrCollisionMap", "cCollisionMap"}), BindingFlags.Instance Or BindingFlags.NonPublic)
                Dim os As New ObjectState
                os.Object = cArea
                os.ValueToPatch = .AreaModel
                os.MemberFlags = BindingFlags.Instance Or BindingFlags.Public
                os.MemberType = ObjectValueType.Property
                os.MemberName = "AreaModel"
                hp.States.Add(os)

                .AreaModel = frm.ResModel
                .AreaModel.Collision.SpecialBoxes = OldAreaModel.Collision.SpecialBoxes
                rndrVisualMap?.ReleaseBuffers()
                rndrCollisionMap?.ReleaseBuffers()
                rndrVisualMap = Nothing
                rndrCollisionMap = Nothing
                cVisualMap = Nothing
                cCollisionMap = Nothing

            ElseIf frm.CheckBoxX_ConvertCollision.Checked Then

                hp = HistoryPoint.FromObject(CObj(Me), ObjectValueType.Field, New MemberWhiteList({"rndrCollisionMap", "cCollisionMap"}), BindingFlags.Instance Or BindingFlags.NonPublic)
                Dim os As New ObjectState
                os.Object = cArea.AreaModel
                os.ValueToPatch = .AreaModel.Collision
                os.MemberFlags = BindingFlags.Instance Or BindingFlags.Public
                os.MemberType = ObjectValueType.Property
                os.MemberName = "Collision"
                hp.States.Add(os)

                .AreaModel.Collision = frm.ResModel.Collision
                .AreaModel.Collision.SpecialBoxes = OldAreaModel.Collision.SpecialBoxes
                rndrCollisionMap?.ReleaseBuffers()
                rndrCollisionMap = Nothing
                cCollisionMap = Nothing

            ElseIf frm.CheckBoxX_ConvertModel.Checked Then

                hp = HistoryPoint.FromObject(CObj(Me), ObjectValueType.Field, New MemberWhiteList({"rndrVisualMap", "cVisualMap"}), BindingFlags.Instance Or BindingFlags.NonPublic)
                Dim os As New ObjectState
                os.Object = cArea.AreaModel
                os.ValueToPatch = .AreaModel.Fast3DBuffer
                os.MemberFlags = BindingFlags.Instance Or BindingFlags.Public
                os.MemberType = ObjectValueType.Property
                os.MemberName = "Fast3DBuffer"
                hp.States.Add(os)

                .AreaModel = frm.ResModel
                .AreaModel.Collision = OldAreaModel.Collision
                rndrVisualMap?.ReleaseBuffers()
                rndrVisualMap = Nothing
                cVisualMap = Nothing

            End If

            If frm.CheckBoxX_ConvertModel.Checked Then
                .ScrollingTextures.Clear()
                .ScrollingTextures.AddRange(.AreaModel.Fast3DBuffer.ConvertResult.ScrollingCommands.ToArray)
            End If

            If hp IsNot Nothing AndAlso (hp.States.Count > 0 OrElse hp.Actions.Count > 0) Then
                history.Store(hp)
            End If

        End With

        cArea.SetSegmentedBanks(rommgr)
        Await LoadAreaModel()

        Me.ResumeLayout()
    End Sub

    Private Sub ButtonItem_AddArea_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddArea.Click
        Dim ReamingIDs As New List(Of Byte)({&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H0})
        For Each a As LevelArea In cLevel.Areas
            ReamingIDs.Remove(a.AreaID)
        Next
        If ReamingIDs.Count = 0 Then
            MessageBoxEx.Show("The maximum count of Areas per Level is 8.", "Maximum reached", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ButtonItem_AddArea.Enabled = False
            Return
        End If

        Dim tArea As New LevelArea(ReamingIDs(0))
        Dim frm As New MainModelConverter
        frm.CheckBoxX_ConvertCollision.Enabled = False
        frm.CheckBoxX_ConvertModel.Enabled = False
        If frm.ShowDialog <> DialogResult.OK Then Return

        tArea.AreaModel = frm.ResModel

        'StoreHistoryPoint(New ObjectAction(Nothing, AreaEditorHistoryFunctions.Methodes("RemoveArea"), AreaEditorHistoryFunctions.Methodes("AddArea"), {cLevel, tArea}, {cLevel, tArea}),
        '                  New ObjectAction(Me, "LoadAreaIDs", "LoadAreaIDs", {}, {}, BindingFlags.NonPublic Or BindingFlags.Instance, BindingFlags.NonPublic Or BindingFlags.Instance))

        cLevel.Areas.Add(tArea)
        areaIdToLoad = tArea.AreaID
        LoadAreaIDs()
    End Sub

    Private Sub ButtonItem_RemoveArea_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveArea.Click
        Dim index = cLevel.Areas.IndexOf(cArea)
        If index < 0 Then Return

        cLevel.Areas.RemoveAt(index)

        ButtonItem_AddArea.Enabled = True
        If cLevel.Areas.Count = 0 Then
            Me.Close()
        Else
            areaIdToLoad = If(index < cLevel.Areas.Count, cLevel.Areas(index).AreaID, cLevel.Areas.Last.AreaID)
            LoadAreaIDs()
        End If
    End Sub

#End Region

#Region "Render Settings"
    Private Sub SomeButtonItems_Click(sender As Object, e As EventArgs) Handles ButtonItem_ViewColMap.Click, ButtonItem_ViewVisualMap.Click, ButtonItem_DrawOutline.Click, ButtonItem_DrawFill.Click, ButtonItem_DrawObjects.Click, ButtonItem_DrawBackfaces.Click
        Application.DoEvents()
        glControl1?.Invalidate()
    End Sub
    Private Sub ButtonItem_DrawBackfaces_CheckChanged(sender As Object, e As EventArgs) Handles ButtonItem_DrawBackfaces.CheckedChanged
        If sender.Checked Then GL.Disable(EnableCap.CullFace) Else GL.Enable(EnableCap.CullFace)
    End Sub
    Private Async Sub ViewModeButtonItems_CheckChanged(sender As Object, e As EventArgs) Handles ButtonItem_ViewVisualMap.CheckedChanged, ButtonItem_ViewColMap.CheckedChanged, ButtonItem_ViewColMap.CheckedChanged, ButtonItem_ViewVisualMap.CheckedChanged
        If sender.Checked Then
            For Each btn As CheckBoxItem In {ButtonItem_ViewVisualMap, ButtonItem_ViewColMap}
                If btn IsNot sender Then btn.Checked = False
            Next
            If sender Is ButtonItem_ViewColMap Then
                ButtonItem_DrawOutline.Checked = True
            End If
            If cLevel IsNot Nothing AndAlso cArea IsNot Nothing Then Await LoadAreaModel()
            glControl1?.Invalidate()
        End If
    End Sub
#End Region

#Region "Level"

#Region "Default Start Position"

    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem84.Click
        Dim selobj As Managed3DObject = SelectedObject
        SetDefaultPosition(selobj.Position, selobj.Rotation.Y)
    End Sub

    Private Sub SetDefaultPosition(pos As Numerics.Vector3, rotY As Single)
        Dim cmd2D As LevelscriptCommand = cLevel.GetDefaultPositionCmd
        clDefaultPosition.SetPosition(cmd2D, pos)
        clDefaultPosition.SetRotation(cmd2D, rotY)
        clDefaultPosition.SetAreaID(cmd2D, cArea.AreaID)
    End Sub

#End Region

#End Region

#Region "Objects"

    Private Sub DrawAllObjects(Optional drawPicking As Boolean = False, Optional DrawBoundingBox As Boolean = True)
        Dim index As Integer = 0
        For Each n As Managed3DObject In managedObjects
            n.Draw(FaceDrawMode, If(DrawObjectModels AndAlso objectModels.ContainsKey(n.ModelID), objectModels(n.ModelID), Nothing),
                       If(drawPicking, Color.FromArgb(&H10000000 Or index), CType(Nothing, Color?)), drawPicking, DrawBoundingBox)
            index += 1
        Next
    End Sub

    Private Sub ShowObjectProperties()
        AdvPropertyGrid1.SelectedObjects = SelectedObjects
        AdvPropertyGrid1.UpdateAmbientColors

        'If SelectedObject Is Nothing Then Return
        'loadingObj = True
        'Panel_ObjectSettings.SuspendLayout()

        ''Selected Object
        'Dim sObj = SelectedObject

        ''Acts
        'SetEnableStateOnStarSymbolBox(SymbolBox_Act1, sObj.Act1)
        'SetEnableStateOnStarSymbolBox(SymbolBox_Act2, sObj.Act2)
        'SetEnableStateOnStarSymbolBox(SymbolBox_Act3, sObj.Act3)
        'SetEnableStateOnStarSymbolBox(SymbolBox_Act4, sObj.Act4)
        'SetEnableStateOnStarSymbolBox(SymbolBox_Act5, sObj.Act5)
        'SetEnableStateOnStarSymbolBox(SymbolBox_Act6, sObj.Act6)
        'CheckAllActs()

        ''Position
        'IntegerInput_ObjPosX.Value = sObj.Position.X
        'IntegerInput_ObjPosY.Value = sObj.Position.Y
        'IntegerInput_ObjPosZ.Value = sObj.Position.Z

        ''Rotation
        'IntegerInput_ObjRotX.Value = sObj.Rotation.X
        'IntegerInput_ObjRotY.Value = sObj.Rotation.Y
        'IntegerInput_ObjRotZ.Value = sObj.Rotation.Z

        ''Model-ID
        'ComboBoxEx_ObjModelID.Text = TextFromValue(sObj.ModelID)

        ''Behavior-ID
        'ComboBoxEx_ObjBehavID.Text = TextFromValue(sObj.BehaviorID, If(Settings.General.IntegerValueMode >= 1, Settings.General.IntegerValueMode, 1))

        ''B. Params
        'ComboBoxEx_ObjBParam1.Text = TextFromValue(sObj.BParam1)
        'ComboBoxEx_ObjBParam2.Text = TextFromValue(sObj.BParam2)
        'ComboBoxEx_ObjBParam3.Text = TextFromValue(sObj.BParam3)
        'ComboBoxEx_ObjBParam4.Text = TextFromValue(sObj.BParam4)

        ''Object Combo
        'Dim objCombo As ObjectComboList.ObjectCombo = myObjectCombos.GetObjectComboOfObject(sObj)
        'ComboBoxEx_ObjCombo.SelectedIndex = myObjectCombos.IndexOf(objCombo)

        ''B. Param Infos
        'LoadBParamInfo(objCombo)

        ''B. Param ComboBox Lists
        'ReloadBParamComboBoxes()

        'Panel_ObjectSettings.ResumeLayout()
        'loadingObj = False
    End Sub

    Private Sub UpdateObjectListViewItems()
        If ListViewEx_Objects.Items.Count > 0 Then
            Dim cIndex As Integer = 0
            For Each item As ListViewItem In ListViewEx_Objects.Items
                SetObjectPropertiesToListViewItem(item, managedObjects(ListViewEx_Objects.Items.IndexOf(item)), cIndex)
                cIndex += 1
            Next
        End If
    End Sub

    Private Sub SaveAllObjectProperties()
        For Each obj As Managed3DObject In managedObjects
            obj.SaveProperties()
        Next
    End Sub
    Private Sub SaveSelectedObjectProperties()
        For Each obj As Managed3DObject In SelectedObjects
            obj.SaveProperties()
        Next
    End Sub

#Region "Object Position"

    Private Sub Slider_ObjMoveSpeed_ValueChanged(sender As Object, e As EventArgs) Handles Slider_ObjMoveSpeed.ValueChanged
        Slider_ObjMoveSpeed.Text = $"Object Move Speed: {Slider_ObjMoveSpeed.Value}%"
    End Sub

    Private Sub PictureBox_ObjCntr_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjCntrWheel.MouseDown, PictureBox_ObjCntrCross.MouseDown
        isObjMoving = True
    End Sub
    Private Sub PictureBox_ObjCntr_MouseUp(sender As Object, e As EventArgs) Handles PictureBox_ObjCntrCross.MouseUp, PictureBox_ObjCntrWheel.MouseUp
        isObjMoving = False
    End Sub

    Private Sub ChangeCamMode(sender As Object, e As EventArgs) Handles ButtonItem_CamTop.Click, ButtonItem_CamRight.Click, ButtonItem_CamOrbit.Click, ButtonItem_CamLeft.Click, ButtonItem_CamFront.Click, ButtonItem_CamFly.Click, ButtonItem_CamButtom.Click, ButtonItem_CamBack.Click
        Select Case True
            Case sender.Equals(ButtonItem_CamFly)
                SetCameraMode(CameraMode.FLY)
            Case sender.Equals(ButtonItem_CamOrbit)
                SetCameraMode(CameraMode.ORBIT)
            Case sender.Equals(ButtonItem_CamTop)
                SetCameraMode(CameraMode.LOOK_DIRECTION, LookDirection.TOP)
            Case sender.Equals(ButtonItem_CamButtom)
                SetCameraMode(CameraMode.LOOK_DIRECTION, LookDirection.BOTTOM)
            Case sender.Equals(ButtonItem_CamFront)
                SetCameraMode(CameraMode.LOOK_DIRECTION, LookDirection.FRONT)
            Case sender.Equals(ButtonItem_CamLeft)
                SetCameraMode(CameraMode.LOOK_DIRECTION, LookDirection.LEFT)
            Case sender.Equals(ButtonItem_CamRight)
                SetCameraMode(CameraMode.LOOK_DIRECTION, LookDirection.RIGHT)
            Case sender.Equals(ButtonItem_CamBack)
                SetCameraMode(CameraMode.LOOK_DIRECTION, LookDirection.BACK)
        End Select
        ButtonX_CamMode.Text = sender.Text
    End Sub
    Private Sub Slider_CamMoveSpeed_ValueChanged(sender As Object, e As EventArgs) Handles Slider_CamMoveSpeed.ValueChanged
        Slider_CamMoveSpeed.Text = $"Camera Move Speed: {Slider_CamMoveSpeed.Value}%"
    End Sub
    Private Sub ButtonX_SetObjMoveSpeed(sender As Object, e As EventArgs) Handles ButtonX4.Click, ButtonX3.Click, ButtonX2.Click, ButtonX1.Click
        Slider_ObjMoveSpeed.Value = sender.Text.Replace("%", "")
    End Sub
    Private Sub ButtonX_SetCamMoveSpeed(sender As Object, e As EventArgs) Handles ButtonX8.Click, ButtonX7.Click, ButtonX6.Click, ButtonX5.Click
        Slider_CamMoveSpeed.Value = sender.Text.Replace("%", "")
    End Sub

    Private Sub KeepObjectsOnGround()
        Select Case True
            Case KeepObjectsOnNearestGround
                DropObjectsToGround(0)
            Case KeepObjectsOnTop
                DropObjectsToGround(1)
            Case KeepObjectsOnButtom
                DropObjectsToGround(2)
        End Select
    End Sub

    Private Sub DropObjectsToGround(mode As Byte)
        If EditObjects Then
            For Each obj As Managed3DObject In SelectedObjects
                Dim oldPos As Numerics.Vector3 = obj.Position

                Dim newY As Single = oldPos.Y
                Select Case mode
                    Case 0
                        newY = cArea.AreaModel.Collision.DropToNearesGround(oldPos)
                    Case 1
                        newY = cArea.AreaModel.Collision.DropToTop(oldPos)
                    Case 2
                        newY = cArea.AreaModel.Collision.DropToButtom(oldPos)
                End Select

                Dim newPos As New Numerics.Vector3(oldPos.X, newY, oldPos.Z)
                obj.Position = newPos

                AdvPropertyGrid1.RefreshPropertyValues()
            Next

            UpdateOrbitCamera()
            glControl1.Invalidate()
        End If
    End Sub

    Private Sub IntegerInput_ObjRotX_Click(sender As Object, e As EventArgs)
        waitUntilLostFocus = False
    End Sub
    Private Sub IntegerInput_ObjRotX_KeyPress(sender As Object, e As Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            waitUntilLostFocus = False
        End If
    End Sub

#End Region

#Region "Object Rotation"
    Private Sub PictureBox_ObjRot_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotWheel.MouseDown, PictureBox_ObjRotCross.MouseDown
        isObjRotating = True
    End Sub
    Private Sub PictureBox_ObjRot_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox_ObjRotWheel.MouseUp, PictureBox_ObjRotCross.MouseUp
        isObjRotating = False
    End Sub
#End Region

#Region "Model-ID & Behavior-ID"

    Private Sub CheckObjCombo()
        Dim objcombo = myObjectCombos.FirstOrDefault(Function(n) n.ModelID = SelectedObject.ModelID AndAlso n.BehaviorID = SelectedObject.BehaviorID)
        If objcombo Is Nothing Then Return

        For Each index As Integer In ListViewEx_Objects.SelectedIndices
            ListViewEx_Objects.Items(index).SubItems(1).Text = objcombo.Name
        Next
    End Sub

#End Region

#Region "Add/Remove/Restore Objects"

    Private Sub ButtonX_ObjectsAdd_Click(sender As Object, e As EventArgs) Handles ButtonX_ObjectsAdd.Click, ButtonItem43.Click, ButtonItem42.Click, ButtonItem41.Click, ButtonItem40.Click, ButtonItem39.Click, ButtonItem38.Click
        Dim newobjects As New List(Of Managed3DObject)
        Dim newlvis As New List(Of ListViewItem)
        Dim objcount As Integer = 0
        If Not Integer.TryParse(sender.Text, objcount) Then objcount = 1

        For i As Integer = 1 To objcount

            Dim newObjCmd As New LevelscriptCommand(LevelArea.DefaultNormal3DObject)
            cArea.Objects.Add(newObjCmd)

            Dim newObj As New Managed3DObject(newObjCmd, myObjectCombos)
            managedObjects.Add(newObj)
            newobjects.Add(newObj)

            Dim lvi As New ListViewItem
            lvi.Tag = newObj
            lvi.SubItems.Add(New ListViewItem.ListViewSubItem)
            SetObjectPropertiesToListViewItem(lvi, newObj, ListViewEx_Objects.Items.Count)
            ListViewEx_Objects.Items.Add(lvi)
            newlvis.Add(lvi)

        Next

        'Store History Point
        StoreHistoryPoint(AreaEditorHistoryFunctions.Methodes("RemoveObjects"),
                              AreaEditorHistoryFunctions.Methodes("AddObjects"),
                              {cArea, managedObjects, newobjects, ListViewEx_Objects.Items, newlvis})

        glControl1.Invalidate()
    End Sub

    Private Sub RemoveObjects(sender As Object, e As EventArgs) Handles ButtonItem_ObjectsRemove.Click, ButtonItem65.Click
        If SelectedObject IsNot Nothing Then

            Dim removedObjs As New Dictionary(Of Integer, Managed3DObject)
            Dim removedlvis As New Dictionary(Of Integer, ListViewItem)
            Dim removedCmds As New Dictionary(Of Integer, LevelscriptCommand)

            Dim indices(ListViewEx_Objects.SelectedIndices.Count - 1) As Integer
            ListViewEx_Objects.SelectedIndices.CopyTo(indices, 0)

            For Each index As Integer In indices.OrderByDescending(Function(n) n)
                Dim mobj As Managed3DObject = managedObjects(index)
                Dim lvi As ListViewItem = ListViewEx_Objects.Items(index)

                managedObjects.Remove(mobj)
                ListViewEx_Objects.Items.Remove(lvi)
                cArea.Objects.RemoveAt(index)

                removedObjs.Add(index, mobj)
                removedCmds.Add(index, mobj.Command)
                removedlvis.Add(index, lvi)
            Next

            'Store History Point
            StoreHistoryPoint(AreaEditorHistoryFunctions.Methodes("InsertObjects"),
                              AreaEditorHistoryFunctions.Methodes("RemoveAtObjects"),
                              {cArea, managedObjects, ListViewEx_Objects.Items, removedObjs, removedlvis, removedCmds})

            UpdateObjectListViewItems()
        End If

        glControl1.Invalidate()
    End Sub

    Private Sub ResetObjToDefault(sender As Object, e As EventArgs) Handles ButtonItem_ResetObjToDefault.Click, ButtonItem64.Click
        Dim oldObjects As New List(Of Managed3DObject)
        Dim newObjects As New List(Of Managed3DObject)
        Dim indicies As New List(Of Integer)

        For Each index As Integer In ListViewEx_Objects.SelectedIndices

            Dim newObj As New LevelscriptCommand(LevelArea.DefaultNormal3DObject)
            Dim new3DObj As New Managed3DObject(newObj, myObjectCombos)

            cArea.Objects(index) = newObj
            managedObjects(index) = new3DObj

            oldObjects.Add(managedObjects(index))
            newObjects.Add(new3DObj)
            indicies.Add(index)

        Next

        'Store History Point
        StoreHistoryPoint(AreaEditorHistoryFunctions.Methodes("RevertObjects"),
                          AreaEditorHistoryFunctions.Methodes("RevertObjects"),
                          {cArea, managedObjects, indicies, oldObjects},
                          {cArea, managedObjects, indicies, newObjects})

        UpdateObjectListViewItems()
        ShowObjectProperties()
    End Sub

#End Region

#Region "Object Model"

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportObjectModel.Click, ButtonItem68.Click
        Dim modelID As Byte = SelectedObject.ModelID
        If objectModels.ContainsKey(modelID) Then
            Publics.Publics.ExportModel(objectModels(modelID).Model, LoaderModule.SimpleFileParser)
        Else
            MessageBoxEx.Show("The Model wasn't found.", "Export Object Model", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#End Region

#Region "Warps"

    Private Sub ShowWarpProterties()
        'If SelectedWarp Is Nothing Then Return

        AdvPropertyGrid1.SelectedObjects = SelectedWarps
        AdvPropertyGrid1.UpdateAmbientColors

        'loadingWarp = True
        'Panel_WarpSettings.SuspendLayout()

        ''My Warp-ID
        'TextBoxX_WarpMyID.Text = TextFromValue(SelectedWarp.WarpID)

        ''Destination Level
        'ComboBoxEx_WarpToLevel.SelectedIndex = rommgr.LevelInfoData.IndexOf(rommgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = SelectedWarp.DestLevelID))

        ''Destination Area
        'TextBoxX_WarpToArea.Text = TextFromValue(SelectedWarp.DestAreaID)

        ''Destination Warp-ID
        'TextBoxX_WarpToID.Text = TextFromValue(SelectedWarp.DestWarpID)

        'Panel_WarpSettings.ResumeLayout()
        'loadingWarp = False
    End Sub

    Private Sub UpdateWarpListViewItem()
        If ListViewEx_Warps.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In ListViewEx_Warps.SelectedItems
                If item.Selected Then
                    Dim cWarp As IManagedLevelscriptCommand = item.Tag
                    SetWarpPropertiesToListViewItem(item, cWarp)
                End If
            Next
        End If
    End Sub

    Private Sub SaveAllWarpProperties()
        For Each warp As IManagedLevelscriptCommand In managedWarps
            warp.SaveProperties()
        Next
    End Sub
    Private Sub SaveSelectedWarpProperties()
        For Each warp As IManagedLevelscriptCommand In SelectedWarps
            warp.SaveProperties()
        Next
    End Sub

#Region "Checking Destination Warp"

    Private Function IsWarpDestinationValid(warp As ManagedWarp) As WarpDestinationValidationResult
        Dim myWarpObjCombos As ObjectComboList.ObjectCombo() = myObjectCombos.Where(Function(n) n.Name.ToLower.Contains("warp")).ToArray
        Dim found As Byte = 0
        Dim foundLevel As Boolean = False

        'For Each obj As Managed3DObject In managedObjects
        '    If myWarpObjCombos.Where(Function(n) n.BehaviorID = obj.BehaviorID).Count > 0 _
        '        AndAlso obj.BParam2 = warp.DestWarpID Then
        '        found += 1
        '    End If
        '    If found = 0 Then
        '        Return WarpDestinationValidationResult.WarpSourceNotFound
        '    ElseIf found > 1 Then
        '        Return WarpDestinationValidationResult.WarpSourceUsedMultipleTimes
        '    Else
        '        foundLevel = True
        '        Exit For
        '    End If
        'Next

        'If found = 0 Then
        '    For Each level As Level In rommgr.Levels
        '        If Not foundLevel AndAlso level IsNot cLevel Then
        '            For Each area As LevelArea In level.Areas
        '                For Each obj As LevelscriptCommand In area.Objects
        '                    Dim behavID As Integer = clNormal3DObject.GetSegBehaviorAddr(obj)
        '                    If myWarpObjCombos.Where(Function(n) n.BehaviorID = behavID).Count > 0 _
        '                                    AndAlso clNormal3DObject.GetParams(obj).BParam2 = warp.DestWarpID Then
        '                        found += 1
        '                    End If
        '                Next
        '                If found = 0 Then
        '                    Return WarpDestinationValidationResult.WarpSourceNotFound
        '                ElseIf found > 1 Then
        '                    Return WarpDestinationValidationResult.WarpSourceUsedMultipleTimes
        '                Else
        '                    foundLevel = True
        '                    Exit For
        '                End If
        '            Next
        '        End If
        '    Next
        'End If

        Dim lvl As Level = rommgr.Levels.FirstOrDefault(Function(n) n.LevelID = warp.DestLevelID)
        If lvl IsNot Nothing Then
            For Each area As LevelArea In lvl.Areas
                If area.AreaID = warp.DestAreaID Then
                    found = 0
                    For Each cmd As LevelscriptCommand In area.Warps
                        If clWarp.GetWarpID(cmd) = warp.DestWarpID Then
                            found += 1
                        End If
                    Next
                    If found = 0 Then
                        Return WarpDestinationValidationResult.WarpDestNotFound
                    ElseIf found = 1 Then
                        found = 0
                        If lvl Is cLevel Then
                            For Each obj As Managed3DObject In managedObjects
                                If myWarpObjCombos.Where(Function(n) n.BehaviorID = obj.BehaviorID).Count > 0 _
                                    AndAlso obj.BParam2 = warp.DestWarpID Then
                                    found += 1
                                End If
                            Next
                        Else
                            For Each obj As LevelscriptCommand In area.Objects
                                Dim behavID As Integer = clNormal3DObject.GetSegBehaviorAddr(obj)
                                If myWarpObjCombos.Where(Function(n) n.BehaviorID = behavID).Count > 0 _
                                    AndAlso clNormal3DObject.GetParams(obj).BParam2 = warp.DestWarpID Then
                                    found += 1
                                End If
                            Next
                        End If
                        If found = 0 Then
                            Return WarpDestinationValidationResult.WarpDestNotUsed
                        ElseIf found = 1 Then
                            Return WarpDestinationValidationResult.WarpFoundInCustomLevel
                        Else
                            Return WarpDestinationValidationResult.WarpDestUsedMultipleTimes
                        End If
                    Else
                        Return WarpDestinationValidationResult.DuplicatedWarpIDsAtDestination
                    End If
                End If
            Next
            Return WarpDestinationValidationResult.AreaNotFound
        Else
            Return WarpDestinationValidationResult.LevelNotFound
        End If
    End Function

    Private Function GetColorOfWarpDestinationValidationResult(warp As IManagedLevelscriptCommand) As Color
        If ({LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.ConnectedWarp}).Contains(warp.Command.CommandType) Then
            Select Case IsWarpDestinationValid(warp)
                Case WarpDestinationValidationResult.DuplicatedWarpIDsAtDestination, WarpDestinationValidationResult.WarpDestUsedMultipleTimes, WarpDestinationValidationResult.WarpSourceUsedMultipleTimes
                    Return Color.FromArgb(-4754112)
                Case WarpDestinationValidationResult.WarpFoundInCustomLevel
                    Return Color.FromArgb(-9073592)
                Case WarpDestinationValidationResult.AreaNotFound, WarpDestinationValidationResult.WarpDestNotFound, WarpDestinationValidationResult.WarpDestNotUsed
                    Return Color.FromArgb(-7324615)
            End Select
        End If
        Return Nothing
    End Function

    Private Enum WarpDestinationValidationResult
        WarpFoundInCustomLevel
        DuplicatedWarpIDsAtDestination
        LevelNotFound
        AreaNotFound
        WarpDestNotFound
        WarpDestNotUsed
        WarpDestUsedMultipleTimes
        WarpSourceUsedMultipleTimes
        WarpSourceNotFound
    End Enum

#End Region

#Region "Add/Remove Warps"

    Private Sub ButtonX_WarpsAddConnectedWarp_Click(sender As Object, e As EventArgs) Handles ButtonX_WarpsAddConnectedWarp.Click, ButtonX_WarpsAdd.Click
        AddWarps(1, LevelscriptCommandTypes.ConnectedWarp)
    End Sub
    Private Sub ButtonX_WarpsAddPaintingWarp_Click(sender As Object, e As EventArgs) Handles ButtonX_WarpsAddPaintingWarp.Click
        AddWarps(1, LevelscriptCommandTypes.PaintingWarp)
    End Sub
    Private Sub ButtonItem_WarpsAddInstantWarp_Click(sender As Object, e As EventArgs) Handles ButtonItem_WarpsAddInstantWarp.Click
        AddWarps(1, LevelscriptCommandTypes.InstantWarp)
    End Sub

    Private Sub AddWarps(count As Integer, type As LevelscriptCommandTypes)
        If CalculateWarpCountInLevel() >= Byte.MaxValue Then
            MessageBoxEx.Show("Maximum of Warps per Level reached. It is not possible to add more Warps.", "Maximum reached", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim newWarp As LevelscriptCommand = Nothing
            Dim newManagedWarp As IManagedLevelscriptCommand = Nothing

            Dim lvi As New ListViewItem
            For i As Integer = 2 To 4
                lvi.SubItems.Add(New ListViewItem.ListViewSubItem)
            Next

            Select Case type
                Case LevelscriptCommandTypes.ConnectedWarp
                    newWarp = New LevelscriptCommand({&H26, &H8, GetNextUnusedWarpID(), levelID, cArea.AreaID, &H0, &H0, &H0})
                    newManagedWarp = New ManagedWarp(newWarp)
                    lvi.Group = lvg_ConnectedWarps
                Case LevelscriptCommandTypes.PaintingWarp
                    newWarp = New LevelscriptCommand({&H27, &H8, GetNextUnusedWarpID(), levelID, cArea.AreaID, &H0, &H0, &H0})
                    newManagedWarp = New ManagedWarp(newWarp)
                    lvi.Group = lvg_PaintingWarps
                Case LevelscriptCommandTypes.InstantWarp
                    newWarp = New LevelscriptCommand({&H28, &HC, &H1B, cArea.AreaID, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0})
                    newManagedWarp = New ManagedInstantWarp(newWarp)
                    lvi.Group = lvg_InstantWarps
                Case Else
                    Return
            End Select

            'Set managed warp as Tag of ListViewItem
            lvi.Tag = newManagedWarp

            cArea.Warps.Add(newWarp)
            managedWarps.Add(newManagedWarp)

            SetWarpPropertiesToListViewItem(lvi, newManagedWarp)
            ListViewEx_Warps.Items.Add(lvi)

            'Store History Point
            Dim dicGroups As New Dictionary(Of ListViewItem, ListViewGroup)
            dicGroups.Add(lvi, lvi.Group)
            StoreHistoryPoint(AreaEditorHistoryFunctions.Methodes("RemoveWarps"),
                              AreaEditorHistoryFunctions.Methodes("AddWarps"),
                              {cArea, managedWarps, ({newManagedWarp}), ListViewEx_Warps.Items, ({lvi}), dicGroups})
        End If
    End Sub

    Private Function CalculateWarpCountInLevel() As Integer
        Dim count As Integer = 0
        For Each a As LevelArea In cLevel.Areas
            count += a.Warps.Where(Function(n) ({LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.ConnectedWarp}).Contains(n.CommandType)).Count
            count += a.WarpsForGame.Concat(a.Warps).Count
        Next
        Return count
    End Function

    Private Function GetNextUnusedWarpID() As Byte
        Dim forbitten As New List(Of Byte)
        For Each cmd As LevelscriptCommand In cArea.WarpsForGame.Concat(cArea.Warps)
            forbitten.Add(clWarp.GetWarpID(cmd))
        Next

        For i As Integer = Byte.MinValue To Byte.MaxValue
            If Not forbitten.Contains(i) Then Return i
        Next

        Return Byte.MaxValue
    End Function

    Private Sub ButtonX_WarpsRemove_Click(sender As Object, e As EventArgs) Handles ButtonX_WarpsRemove.Click, ButtonItem23.Click
        If SelectedWarp IsNot Nothing Then

            Dim removedWarps As New Dictionary(Of Integer, IManagedLevelscriptCommand)
            Dim removedlvis As New Dictionary(Of Integer, ListViewItem)
            Dim removedCmds As New Dictionary(Of Integer, LevelscriptCommand)
            Dim dicGroups As New Dictionary(Of ListViewItem, ListViewGroup)

            Dim indices(ListViewEx_Warps.SelectedIndices.Count - 1) As Integer
            ListViewEx_Warps.SelectedIndices.CopyTo(indices, 0)
            indices = indices.OrderByDescending(Function(n) n).ToArray

            For Each index As Integer In indices
                Dim curItem As ListViewItem = ListViewEx_Warps.Items(index)

                If curItem.Group IsNot lvg_WarpsForGame Then

                    Dim mwarp As IManagedLevelscriptCommand = curItem.Tag
                    Dim cmd As LevelscriptCommand = mwarp.Command
                    Dim lvg As ListViewGroup = curItem.Group

                    Dim cmdIndex As Integer = cArea.Warps.IndexOf(cmd)
                    Dim mwarpIndex As Integer = managedWarps.IndexOf(mwarp)

                    removedWarps.Add(mwarpIndex, mwarp)
                    removedlvis.Add(index, curItem)
                    removedCmds.Add(cmdIndex, cmd)
                    dicGroups.Add(curItem, lvg)

                End If
            Next

            For Each kvp As KeyValuePair(Of Integer, IManagedLevelscriptCommand) In removedWarps.OrderByDescending(Function(n) n.Key)
                managedWarps.Remove(kvp.Value)
            Next
            For Each kvp As KeyValuePair(Of Integer, LevelscriptCommand) In removedCmds.OrderBy(Function(n) n.Key)
                cArea.Warps.Remove(kvp.Value)
            Next
            For Each kvp As KeyValuePair(Of Integer, ListViewItem) In removedlvis.OrderBy(Function(n) n.Key)
                ListViewEx_Warps.Items.Remove(kvp.Value)
            Next

            'Store History Point
            StoreHistoryPoint(AreaEditorHistoryFunctions.Methodes("InsertWarps"),
                              AreaEditorHistoryFunctions.Methodes("RemoveAtWarps"),
                              {cArea, managedWarps, ListViewEx_Warps.Items, removedWarps, removedlvis, removedCmds, dicGroups})

        End If
    End Sub

#End Region

#End Region

#Region "AdvPropertyGrid1"

    Private Sub AdvPropertyGrid1_PropertyValueChanged(sender As Object, e As PropertyChangedEventArgs) Handles AdvPropertyGrid1.PropertyValueChanged
        Select Case e.PropertyName
            Case "AllActs", "Act1", "Act2", "Act3", "Act4", "Act5", "Act6"
                AdvPropertyGrid1.RefreshPropertyValues()

            Case "Rotation", "Position"

                UpdateOrbitCamera()
                glControl1.Invalidate()

            Case "ObjectCombo", "ModelID", "BehaviorID"

                CheckObjCombo()
                UpdateOrbitCamera()
                glControl1.Invalidate()

        End Select

        UpdateObjectListViewItems()
        UpdateWarpListViewItem()
        UpdateOrbitCamera()
        glControl1.Invalidate()
    End Sub

    Private Sub AdvPropertyGrid1_PropertyValueChanging(sender As Object, e As PropertyValueChangingEventArgs) Handles AdvPropertyGrid1.PropertyValueChanging
        lastChangedPropertyName = e.PropertyName

        Select Case e.PropertyName
            Case "ObjectCombo", "ModelID", "BehaviorID"
                StoreObjectHistoryPoint(AdvPropertyGrid1.SelectedObjects, {"ModelID", "BehaviorID"})
            Case Else
                StoreObjectHistoryPoint(AdvPropertyGrid1.SelectedObjects, e.PropertyName)
        End Select
    End Sub

    Private Sub AdvPropertyGrid1_ConvertFromStringToPropertyValue(sender As Object, e As ConvertValueEventArgs) Handles AdvPropertyGrid1.ConvertFromStringToPropertyValue
        Select Case e.PropertyDescriptor.PropertyType
            Case GetType(System.Boolean)
                If e.StringValue = "Yes" Then
                    e.TypedValue = True
                Else
                    e.TypedValue = False
                End If
                e.IsConverted = True

            Case GetType(System.Byte)
                e.TypedValue = CByte(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(System.SByte)
                e.TypedValue = CSByte(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(Int16)
                e.TypedValue = CShort(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(UInt16)
                e.TypedValue = CUShort(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(Int32)
                e.TypedValue = CInt(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(UInt32)
                e.TypedValue = CUInt(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(System.Single)
                e.TypedValue = CSng(e.StringValue.Trim)
                e.IsConverted = True

            Case GetType(System.Double)
                e.TypedValue = CDbl(e.StringValue.Trim)
                e.IsConverted = True

            Case GetType(System.Decimal)
                e.TypedValue = CDec(e.StringValue.Trim)
                e.IsConverted = True

        End Select
    End Sub

    Private Sub AdvPropertyGrid1_ConvertPropertyValueToString(sender As Object, e As ConvertValueEventArgs) Handles AdvPropertyGrid1.ConvertPropertyValueToString
        Select Case e.PropertyDescriptor.PropertyType
            Case GetType(System.Boolean)
                If e.TypedValue = True Then
                    e.StringValue = "Yes"
                Else
                    e.StringValue = "No"
                End If
                e.IsConverted = True

            Case GetType(System.Byte), GetType(System.SByte), GetType(Int16), GetType(UInt16), GetType(Int32), GetType(UInt32)
                If e.PropertyName = "BehaviorID" Then
                    e.StringValue = TextFromValue(e.TypedValue, If(Settings.General.IntegerValueMode >= 1, Settings.General.IntegerValueMode, 1))
                    e.IsConverted = True
                Else
                    e.StringValue = TextFromValue(e.TypedValue)
                    e.IsConverted = True
                End If

        End Select
    End Sub

    Private Sub SavePropertyValue(value As Object, propertyName As String)
        For Each obj As Object In AdvPropertyGrid1.SelectedObjects
            obj.GetType.GetProperty(propertyName).SetValue(obj, value)
        Next
    End Sub

    Private Sub ButtonItem_CopyObjCmdAsHex_Click(sender As Object, e As EventArgs) Handles ButtonItem_CopyObjCmdAsHex.Click, ButtonItem_CopyWarpCmdAsHex.Click
        Dim bytes As New List(Of Byte)
        Dim txt As String = ""

        For Each obj As Object In AdvPropertyGrid1.SelectedObjects
            Dim prop As PropertyInfo = obj.GetType.GetProperty("Command")
            If prop IsNot Nothing Then
                bytes.AddRange(CType(prop.GetValue(obj), LevelscriptCommand).ToArray())
            End If
        Next

        For Each b As Byte In bytes
            txt &= " " & b.ToString("X2")
        Next

        Clipboard.SetText(txt.TrimStart(" "))
    End Sub

#End Region

End Class
