Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.RenderingN
Imports Pilz.S3DFileParser
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.CameraN
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib.Levels
Imports Color = System.Drawing.Color

Namespace LevelEditor

    Public Class OpenGLManager

        Private WithEvents Main As Form_AreaEditor
        Private WithEvents TargetControl As Control
        Private WithEvents GLControl1 As New GLControl
        Private WithEvents CameraPrivate As New Camera
#If Not RelMono Then
        Private WithEvents RenderTimer As New Timers.Timer(10)
#End If

        Friend ProjMatrix As Matrix4 = Nothing
        Friend Ortho As Boolean = False
        Friend FOV As Single = 1.048F
        Friend camMtx As Matrix4 = Matrix4.Identity
        Friend savedCamPos As New OpenTK.Vector3
        Friend isMouseDown As Boolean = False
        Friend curScale As Single = 1.0F

        Public Sub New(targetForm As Form)
            Me.New(targetForm, targetForm)
        End Sub

        Public Sub New(targetForm As Form, targetControl As Control)
            Me.Main = targetForm
            Me.TargetControl = targetControl

            AddHandler Main.KeyUp, AddressOf ModelPreview_KeyUp

            InitializeGLControl()

#If Not RelMono Then
            RenderTimer.SynchronizingObject = Nothing
            RenderTimer.Start()
#End If
        End Sub

        Private ReadOnly Property Maps As MapManagement
            Get
                Return Main.maps
            End Get
        End Property

        Public ReadOnly Property Camera As Camera
            Get
                Return CameraPrivate
            End Get
        End Property

        Public ReadOnly Property CurrentModelDrawMod As ModelDrawMod
            Get
                Select Case True
                    Case Main.ButtonItem_ViewColMap.Checked
                        Return ModelDrawMod.Collision
                    Case Main.ButtonItem_ViewVisualMap.Checked
                        Return ModelDrawMod.VisualMap
                    Case Else
                        Return Nothing
                End Select
            End Get
        End Property

        Public ReadOnly Property GLControl As GLControl
            Get
                Return GLControl1
            End Get
        End Property

        Friend Property FaceDrawMode As RenderMode
            Get
                Dim val As RenderMode = RenderMode.None
                If Main.ButtonItem_DrawOutline.Checked Then val = val Or RenderMode.Outline
                If Main.ButtonItem_DrawFill.Checked Then val = val Or RenderMode.Fill
                Return val
            End Get
            Set(value As RenderMode)
                Main.ButtonItem_DrawOutline.Checked = (value And RenderMode.Outline) = RenderMode.Outline
                Main.ButtonItem_DrawFill.Checked = (value And RenderMode.Fill) = RenderMode.Fill
            End Set
        End Property

        Private Sub InitializeGLControl()
            GLControl1.BackColor = Color.Black
            GLControl1.Location = New Drawing.Point(0, 0)
            GLControl1.MinimumSize = New Size(600, 120)
            GLControl1.Name = "glControl1"
            GLControl1.Size = New Size(880, 538)
            GLControl1.TabIndex = 0
            GLControl1.TabStop = False
            GLControl1.VSync = True
            GLControl1.Dock = DockStyle.Fill

            TargetControl.Controls.Add(GLControl1)

            GLControl1.CreateControl()
            GLControl1.Enabled = False

            UpdateProjMatrix()
            Camera.UpdateMatrix(camMtx)
        End Sub

        Public Sub Invalidate()
            GLControl1.Invalidate()
        End Sub

        Public Sub Update()
            GLControl1.Update()
        End Sub

        Public Sub MakeCurrent()
            GLControl1.MakeCurrent()
        End Sub

        Public Sub ChangeViewMode(ortho As Boolean)
            If GLControl1 IsNot Nothing Then
                Me.Ortho = ortho
                UpdateProjMatrix()
                GLControl1?.Update()
            End If
        End Sub

        Public Sub UpdateOrbitCamera()
            If Camera.IsOrbitCamera() Then
                Camera.UpdateOrbitCamera(camMtx)
            End If
        End Sub

        Public Sub SetCameraMode(mode As CameraMode, look As LookDirection)
            Camera.SetCameraMode(mode, camMtx)
            Camera.SetCameraMode_LookDirection(look, camMtx)
            'camera.updateMatrix(camMtx)
            Main.objectControlling.WasInOrbitMode = False
            Invalidate()
        End Sub

        Public Sub SetCameraMode(mode As CameraMode)
            Camera.SetCameraMode(mode, camMtx)
            Main.objectControlling.WasInOrbitMode = False
            Invalidate()
        End Sub

        Private Sub glControl1_Load(sender As Object, e As EventArgs) Handles GLControl1.Load
            GL.Enable(EnableCap.Blend)
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha)

            GL.Enable(EnableCap.DepthTest)
            GL.DepthFunc(DepthFunction.Lequal)

            GL.Enable(EnableCap.Texture2D)
            GL.Enable(EnableCap.AlphaTest)
            GL.AlphaFunc(AlphaFunction.Gequal, 0.5F)

            GL.Enable(EnableCap.CullFace)
        End Sub

        Private Sub GlControl1_Paint(sender As Object, e As PaintEventArgs) Handles GLControl1.Paint
            GL.ClearColor(If(Settings.StyleManager.AlwaysKeepBlueColors, Color.CornflowerBlue, Main.BackColor))

            GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
            GL.MatrixMode(MatrixMode.Projection)
            GL.LoadMatrix(ProjMatrix)
            GL.MatrixMode(MatrixMode.Modelview)
            GL.LoadMatrix(camMtx)

            'DrawSpecialBoxes()

            Select Case CurrentModelDrawMod
                Case ModelDrawMod.Collision
                    If Maps.rndrCollisionMap IsNot Nothing Then
                        Maps.rndrCollisionMap?.DrawModel(FaceDrawMode)
                    End If
                Case ModelDrawMod.VisualMap
                    If Maps.rndrVisualMap IsNot Nothing Then
                        Maps.rndrVisualMap?.DrawModel(FaceDrawMode)
                    End If
            End Select

            DrawAllObjects()

            GLControl1.SwapBuffers()
        End Sub

        Public Sub SaveScreenshot(fileName As String)
            GL.ClearColor(Color.CornflowerBlue)
            GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
            GL.MatrixMode(MatrixMode.Projection)
            GL.LoadMatrix(ProjMatrix)
            GL.MatrixMode(MatrixMode.Modelview)
            GL.LoadMatrix(camMtx)

            DrawAllObjects(, False)

            If Maps.rndrVisualMap IsNot Nothing Then
                Maps.rndrVisualMap?.DrawModel(RenderMode.Fill)
            End If

            Dim img As Image = TakeScreenshotOfGL()
            img.Save(fileName)
        End Sub

        Friend Function TakeScreenshotOfGL() As Image
            'Create new Bitmap
            Dim bmp As New Bitmap(GLControl1.Width, GLControl1.Height)

            'Lock Bits & Get Bitmap Data
            Dim bmpdata As Imaging.BitmapData = bmp.LockBits(New Rectangle(0, 0, GLControl1.Size.Width, GLControl1.Size.Height), Imaging.ImageLockMode.WriteOnly, Imaging.PixelFormat.Format24bppRgb)

            'Get Screenshot
            GL.ReadPixels(0, 0, GLControl1.Size.Width, GLControl1.Size.Height, PixelFormat.Bgr, PixelType.UnsignedByte, bmpdata.Scan0)

            'Unlook Bits
            bmp.UnlockBits(bmpdata)

            'Rotate at Y
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Return bmp
        End Function

        Private Sub glControl1_Resize(sender As Object, e As EventArgs) Handles GLControl1.Resize
            GLControl1.Context.Update(GLControl1.WindowInfo)
            GL.Viewport(0, 0, GLControl1.Width, GLControl1.Height)
            UpdateProjMatrix()
            GLControl1.Invalidate()
        End Sub

        Public Sub UpdateProjMatrix()
            If Ortho Then
                ProjMatrix = Matrix4.CreateOrthographic(GLControl1.Width * 4, GLControl1.Height * 4, 100.0F, 100000.0F)
            Else
                ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(FOV, GLControl1.Width / GLControl1.Height, 100.0F, 100000.0F)
            End If
        End Sub

        Private Sub glControl1_Wheel(sender As Object, e As MouseEventArgs) Handles GLControl1.MouseWheel
            Camera.ResetMouseStuff()
            Camera.UpdateCameraMatrixWithScrollWheel(e.Delta * (If(Main.IsShiftPressed, 3.5F, 1.5F)), camMtx)
            savedCamPos = Camera.Position
            GLControl1.Invalidate()
        End Sub

        Private Sub glControl1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GLControl1.MouseDown
            isMouseDown = True
            savedCamPos = Camera.Position

            If e.Button = MouseButtons.Right Then
                SelectViaGLControl(e.X, e.Y)
                GLControl1.Invalidate()
            End If
        End Sub

        Private Sub glControl1_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles GLControl1.MouseUp, GLControl1.MouseLeave
            Camera.ResetMouseStuff()
            isMouseDown = False
        End Sub

        Private Sub glControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GLControl1.MouseMove
            If isMouseDown AndAlso e.Button = MouseButtons.Left Then
                If Main.IsShiftPressed Then
                    Camera.UpdateCameraOffsetWithMouse(savedCamPos, e.X, e.Y, GLControl1.Width, GLControl1.Height, camMtx)
                Else
                    Camera.UpdateCameraMatrixWithMouse(e.X, e.Y, camMtx)
                End If
                GLControl1.Invalidate()
            End If
        End Sub

        Private Sub ModelPreview_KeyDown(sender As Object, e As KeyEventArgs) Handles GLControl1.KeyDown
            If Not Main.PressedKeys.Contains(e.KeyCode) Then Main.PressedKeys.Add(e.KeyCode)
        End Sub

        Private Sub ModelPreview_KeyUp(sender As Object, e As KeyEventArgs)
            Main.LastKeyLeaveTimer = Date.Now
            If Main.PressedKeys.Contains(e.KeyCode) Then Main.PressedKeys.Remove(e.KeyCode)
        End Sub

#If Not RelMono Then
        Private Sub CompositionTarget_Rendering(sender As Object, e As Timers.ElapsedEventArgs) Handles RenderTimer.Elapsed
            'If Not Main.isDeactivated Then
            '    GLControl1.Invalidate()
            'End If
            'Application.DoEvents()
            MoveCameraViaWASDQE()
        End Sub
#End If

        Private Sub MoveCameraViaWASDQE()
            Dim moveSpeed As Integer = Convert.ToInt32(Math.Round(If(Main.IsShiftPressed, 60, 30) * Camera.CamSpeedMultiplier, 0))
            Dim allowCamMove As Boolean = Not (isMouseDown AndAlso Main.IsShiftPressed)

            For Each k As Keys In Main.PressedKeys.ToArray
                If allowCamMove Then
                    'camera.resetMouseStuff()

                    Select Case k
                        Case Keys.W
                            'camera.Move(moveSpeed, moveSpeed, camMtx)
                            Camera.UpdateCameraMatrixWithScrollWheel(moveSpeed, camMtx)
                            savedCamPos = Camera.Position
                        Case Keys.S
                            'camera.Move(-moveSpeed, -moveSpeed, camMtx)
                            Camera.UpdateCameraMatrixWithScrollWheel(-moveSpeed, camMtx)
                            savedCamPos = Camera.Position
                        Case Keys.A
                            'camera.Move(-moveSpeed, 0, camMtx)
                            Camera.UpdateCameraOffsetDirectly(-moveSpeed, 0, camMtx)
                        Case Keys.D
                            'camera.Move(moveSpeed, 0, camMtx)
                            Camera.UpdateCameraOffsetDirectly(moveSpeed, 0, camMtx)
                        Case Keys.E
                            'camera.Move(0, -moveSpeed, camMtx)
                            Camera.UpdateCameraOffsetDirectly(0, -moveSpeed, camMtx)
                        Case Keys.Q
                            'camera.Move(0, moveSpeed, camMtx)
                            Camera.UpdateCameraOffsetDirectly(0, moveSpeed, camMtx)
                    End Select

                    'savedCamPos = camera.Position
                End If
            Next
        End Sub

        Public Sub SelectViaGLControl(mx As Integer, my As Integer)
            Dim h As Integer = GLControl1.Height

            GL.ClearColor(1.0F, 1.0F, 1.0F, 1.0F)
            GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
            GL.MatrixMode(MatrixMode.Projection)
            GL.LoadMatrix(ProjMatrix)
            GL.MatrixMode(MatrixMode.Modelview)
            GL.LoadMatrix(camMtx)

            'Draw everything
            DrawAllObjects(True)
            If CurrentModelDrawMod = ModelDrawMod.Collision Then
                'Maps.rndrCollisionMap?.DrawFacePicking()
            End If

            Dim pixels() = New Byte(3) {}
            GL.ReadPixels(mx, h - my, 1, 1, PixelFormat.Rgba, PixelType.UnsignedByte, pixels)
            pixels = New Byte() {pixels(3), pixels(0), pixels(1), pixels(2)}
            Dim pixel As Integer = (CInt(pixels(0)) << 24) Or (CInt(pixels(1)) << 16) Or (CInt(pixels(2)) << 8) Or pixels(3)
            Dim pixid As Integer = pixel >> 28
            Dim pixval As Integer = pixel And &HFFFFFFF

            Select Case pixid 'pixels(0) >> 4
                Case 1 'Object

                    Dim newIndex As Integer = pixval '(CInt(pixels(2)) << 8) Or pixels(3)

                    If Main.IsStrgPressed Then
                        Main.ToogleObjectSelection(Main.ManagedObjects(newIndex))
                    Else
                        Main.SelectItemAtIndexInList(Main.ListViewEx_Objects, newIndex, True)
                    End If

                Case 2 'Collision Face

                    Dim iMesh As Integer = pixval >> 16
                    Dim iFace As Integer = pixval And &HFFFF
                    Dim face As Face = Maps.cCollisionMap.Meshes(iMesh).Faces(iFace)

                    If Main.IsStrgPressed Then
                        Main.ToogleColFaceSelection(face)
                    Else
                        Main.SelectItemAtIndexInList(Main.ListViewEx_ColFaces, iFace, True)
                    End If

            End Select
        End Sub

        Friend Sub DrawAllObjects(Optional drawPicking As Boolean = False, Optional DrawBoundingBox As Boolean = True)
            Dim index As Integer = 0

            For Each n As Managed3DObject In Main.ManagedObjects
                Dim objModel As Renderer
                Dim col As Color?

                If Main.DrawObjectModels AndAlso Main.ObjectModels.ContainsKey(n.ModelID) Then
                    objModel = Main.ObjectModels(n.ModelID)
                Else
                    objModel = Nothing
                End If

                If objModel IsNot Nothing AndAlso Not objModel.HasRendered Then
                    objModel.RenderModel()
                End If

                If drawPicking Then
                    col = Color.FromArgb(&H10000000 Or index)
                Else
                    col = Nothing
                End If

                n.Draw(FaceDrawMode, objModel, col, drawPicking, DrawBoundingBox)

                index += 1
            Next
        End Sub

        Friend Sub DrawSpecialBoxes()
            For Each sp As ManagedSpecialBox In Main.ManagedSpecialBoxes
                Dim rndr As Renderer = Nothing

                If Main.SpecialBoxRenderers.ContainsKey(sp) Then
                    rndr = Main.SpecialBoxRenderers(sp)
                Else
                    Dim spm As New Object3D
                    GetModelFromSpecialBox(sp.SpecialBox, spm)
                    rndr = New Renderer(spm)
                    Main.SpecialBoxRenderers.Add(sp, rndr)
                    rndr.RenderModel()
                End If

                rndr?.DrawModel(FaceDrawMode)
            Next
        End Sub

        Private Sub GetModelFromSpecialBox(sp As SpecialBox, obj As Object3D)
            Dim mat As New Material With {.Color = Color.Blue, .Opacity = 0.25!}
            Dim m As New Mesh
            Dim uv As New UV
            Dim p1 As New Point With {.Vertex = New Vertex With {.X = sp.X1, .Z = sp.Z1, .Y = sp.Y}}
            Dim p2 As New Point With {.Vertex = New Vertex With {.X = sp.X1, .Z = sp.Z2, .Y = sp.Y}}
            Dim p3 As New Point With {.Vertex = New Vertex With {.X = sp.X2, .Z = sp.Z2, .Y = sp.Y}}
            Dim p4 As New Point With {.Vertex = New Vertex With {.X = sp.X2, .Z = sp.Z1, .Y = sp.Y}}
            Dim f1 As New Face With {.Material = mat}
            Dim f2 As New Face With {.Material = mat}

            f1.Points.AddRange({p1, p2, p3})
            f2.Points.AddRange({p1, p3, p4})

            obj.Materials.Add(String.Empty, mat)
            m.Vertices.AddRange({p1.Vertex, p2.Vertex, p3.Vertex, p4.Vertex})
            m.UVs.Add(uv)
            m.Faces.AddRange({f1, f2})

            obj.Meshes.Add(m)
        End Sub

        Private Sub CameraPrivate_PerspectiveChanged(sender As Object, e As EventArgs) Handles CameraPrivate.PerspectiveChanged
            GLControl1.Invoke(Sub() GLControl1.Invalidate())
        End Sub
    End Class

    Public Enum ModelDrawMod
        VisualMap
        Collision
    End Enum

End Namespace
