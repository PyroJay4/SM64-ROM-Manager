Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports OpenGLFactory.CameraN
Imports OpenGLFactory.RenderingN
Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports PaintingControls
Imports S3DFileParser
Imports SM64_ROM_Manager.SettingsManager

Public Class ModelPreview

    Private ProjMatrix As Matrix4 = Nothing
    Private FOV As Single = 1.048F
    Private obj3d As Object3D
    Private rndr As Renderer = Nothing
    Private camMtx As Matrix4 = Matrix4.Identity
    Private WithEvents Camera As New Camera
    Private savedCamPos As New Vector3
    Private _isMouseDown As Boolean = False
    Private pressedKeys As New List(Of Keys)
    Private WithEvents glControl1 As GLControl
    Private curScale As Single = 500.0F

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

    Public Property IsMouseDown As Boolean
        Get
            Return _isMouseDown
        End Get
        Set(value As Boolean)
            _isMouseDown = value
            glControl1.Refresh()
        End Set
    End Property

    Public Sub New(obj As Object3D, scale As Single)
        Me.SuspendLayout()

        InitializeComponent()

        'glControl1
        Me.glControl1 = New GLControl
        Me.glControl1.BackColor = Color.Black
        Me.glControl1.Location = New Drawing.Point(0, 0)
        Me.glControl1.MinimumSize = New Size(600, 120)
        Me.glControl1.Name = "glControl1"
        Me.glControl1.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
        Me.glControl1.Location = New Drawing.Point(0, 0)
        Me.glControl1.Size = Me.PanelEx1.Size
        Me.glControl1.TabIndex = 0
        Me.glControl1.TabStop = False
        Me.glControl1.VSync = False
        Me.PanelEx1.Controls.Add(Me.glControl1)
        Me.ResumeLayout(False)

        obj3d = obj
        curScale = scale

        'Toolkit.Init()

        glControl1.CreateControl()
        AddHandler glControl1.MouseWheel, AddressOf glControl1_Wheel
        ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(FOV, glControl1.Width / glControl1.Height, 100.0F, 100000.0F)
        glControl1.Enabled = False
        Camera.SetCameraMode(CameraMode.FLY, camMtx)
        Camera.updateMatrix(camMtx)

        Me.ResumeLayout()
    End Sub

    Private Sub ModelPreview_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        glControl1.Enabled = True
        rndr = New Renderer(obj3d)
        rndr.ModelScaling = curScale
        rndr.RenderModel()
        glControl1.Invalidate()
    End Sub

    Private Sub glControl1_Load(sender As Object, e As EventArgs) Handles glControl1.Load
        GL.Enable(EnableCap.Blend)
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha)

        GL.Enable(EnableCap.DepthTest)
        GL.DepthFunc(DepthFunction.Lequal)

        GL.Enable(EnableCap.Texture2D)
        GL.Enable(EnableCap.AlphaTest)
        GL.AlphaFunc(AlphaFunction.Gequal, 0.5F)

        GL.Enable(EnableCap.CullFace)
    End Sub

    Private Sub glControl1_Paint(sender As Object, e As PaintEventArgs) Handles glControl1.Paint
        MoveCameraViaWASDQE()

        GL.ClearColor(If(Settings.StyleManager.AlwaysKeepBlueColors, Color.CornflowerBlue, Me.BackColor))

        If rndr IsNot Nothing Then
            GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)

            GL.MatrixMode(MatrixMode.Projection)
            GL.LoadMatrix(ProjMatrix)
            GL.MatrixMode(MatrixMode.Modelview)
            GL.LoadMatrix(camMtx)

            rndr.DrawModel(RenderingN.RenderMode.FillOutline)

            glControl1.SwapBuffers()
        End If

        'If Not IsMouseDown AndAlso obj3d IsNot Nothing Then
        '    e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        '    e.Graphics.DrawString(GetModelInfoAsString, New Font(FontFamily.GenericSerif, 10), New SolidBrush(Panel1.ForeColor), New Drawing.Point(10, 10))
        'End If
    End Sub

    Private Function GetModelInfoAsString() As String
        Dim matsCount As Long = obj3d.Materials.Count
        Dim facesCount As Long = 0
        Dim vertsCount As Long = 0
        Dim vcCount As Long = 0
        Dim uvCount As Long = 0

        For Each m As Mesh In obj3d.Meshes
            vertsCount += m.Vertices.Count
            facesCount += m.Faces.Count
            vcCount += m.VertexColors.Count
            uvCount += m.UVs.Count
        Next

        Return String.Format("Materials:{0}{1}
Faces:{0}{0}{2}
Vertices:{0}{3}
Vertex Colors{0}{4}
UVs:{0}{0}{5}",
vbTab, matsCount, facesCount, vertsCount, vcCount, uvCount)
    End Function

    Private Sub glControl1_Resize(sender As Object, e As EventArgs) Handles glControl1.Resize
        glControl1.Context.Update(glControl1.WindowInfo)
        GL.Viewport(0, 0, glControl1.Width, glControl1.Height)
        ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(FOV, glControl1.Width / glControl1.Height, 100.0F, 100000.0F)
        glControl1.Invalidate()
    End Sub

    Private Sub glControl1_Wheel(sender As Object, e As MouseEventArgs)
        Camera.resetMouseStuff()
        Camera.updateCameraMatrixWithScrollWheel(CInt(Math.Truncate(e.Delta * (If(IsShiftPressed, 3.5F, 1.5F)))), camMtx)
        savedCamPos = Camera.Position
        glControl1.Invalidate()
    End Sub

    Private Sub glControl1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles glControl1.MouseDown
        isMouseDown = True
        savedCamPos = Camera.Position
    End Sub

    Private Sub glControl1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles glControl1.MouseLeave, glControl1.MouseUp
        Camera.resetMouseStuff()
        IsMouseDown = False
    End Sub

    Private Sub glControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles glControl1.MouseMove
        If isMouseDown AndAlso e.Button = MouseButtons.Left Then
            If IsShiftPressed Then
                Camera.updateCameraOffsetWithMouse(savedCamPos, e.X, e.Y, glControl1.Width, glControl1.Height, camMtx)
            Else
                Camera.updateCameraMatrixWithMouse(e.X, e.Y, camMtx)
            End If
            glControl1.Invalidate()
        End If
    End Sub

    Private Sub ModelPreview_KeyDown(sender As Object, e As KeyEventArgs) Handles glControl1.KeyDown
        If Not pressedKeys.Contains(e.KeyCode) Then pressedKeys.Add(e.KeyCode)
    End Sub

    Private Sub ModelPreview_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If pressedKeys.Contains(e.KeyCode) Then pressedKeys.Remove(e.KeyCode)
    End Sub

    Public Sub MoveCameraViaWASDQE()
        Dim moveSpeed As Integer = Convert.ToInt32(Math.Round((If(IsShiftPressed, 60, 30)) * (Camera.camSpeedMultiplier), 0))
        Dim allowCamMove As Boolean = Not (isMouseDown AndAlso IsShiftPressed)

        For Each k As Keys In pressedKeys
            If allowCamMove Then
                'camera.resetMouseStuff()

                Select Case k
                    Case Keys.W
                        'camera.Move(moveSpeed, moveSpeed, camMtx)
                        Camera.updateCameraMatrixWithScrollWheel(moveSpeed, camMtx)
                        savedCamPos = Camera.Position
                    Case Keys.S
                        'camera.Move(-moveSpeed, -moveSpeed, camMtx)
                        Camera.updateCameraMatrixWithScrollWheel(-moveSpeed, camMtx)
                        savedCamPos = Camera.Position
                    Case Keys.A
                        'camera.Move(-moveSpeed, 0, camMtx)
                        Camera.updateCameraOffsetDirectly(-moveSpeed, 0, camMtx)
                    Case Keys.D
                        'camera.Move(moveSpeed, 0, camMtx)
                        Camera.updateCameraOffsetDirectly(moveSpeed, 0, camMtx)
                    Case Keys.E
                        'camera.Move(0, -moveSpeed, camMtx)
                        Camera.updateCameraOffsetDirectly(0, -moveSpeed, camMtx)
                    Case Keys.Q
                        'camera.Move(0, moveSpeed, camMtx)
                        Camera.updateCameraOffsetDirectly(0, moveSpeed, camMtx)
                End Select
            End If
        Next
    End Sub

    Private Sub camera_NeedSelectedObject(e As CameraN.Camera.NeedSelectedObjectEventArgs) Handles Camera.NeedSelectedObject
        e.Points = Nothing
    End Sub

    Private Sub ModelPreview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        rndr?.ReleaseBuffers()
    End Sub

End Class