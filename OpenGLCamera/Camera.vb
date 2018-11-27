Imports System.Windows.Forms
Imports OpenTK
Imports S3DFileParser
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands

Public Enum CameraMode
    FLY = 0
    ORBIT = 1
    LOOK_DIRECTION = 2
End Enum

Public Enum LookDirection
    TOP
    BOTTOM
    LEFT
    RIGHT
    FRONT
    BACK
End Enum

Public Class Camera

    Private ReadOnly TAU As Single = CSng(Math.PI * 2)

    ' Camera mode
    Private camMode_Renamed As CameraMode = CameraMode.FLY
    Private pos As New Vector3(-5000.0F, 3000.0F, 4000.0F)
    Private lookat_Renamed As New Vector3(0F, 0F, 0F)
    Private farPoint_Renamed As New Vector3(0F, 0F, 0F)
    Private nearPoint_Renamed As New Vector3(0F, 0F, 0F)
    Private lastMouseX As Integer = -1, lastMouseY As Integer = -1
    Private CamAngleX As Single = 0F, CamAngleY As Single = -CSng(Math.PI / 2)
    Private resetMouse As Boolean = True
    'private Matrix4 matrix = Matrix4.Identity;
    Public Property camSpeedMultiplier As Single = 1

    Public ReadOnly Property CamMode() As CameraMode
        Get
            Return camMode_Renamed
        End Get
    End Property
    Public ReadOnly Property Yaw() As Single
        Get
            Return CamAngleX
        End Get
    End Property
    Public ReadOnly Property Pitch() As Single
        Get
            Return CamAngleY
        End Get
    End Property
    Public ReadOnly Property Yaw_Degrees() As Single
        Get
            Return CamAngleX * (180.0F / 3.14159274F)
        End Get
    End Property
    Public ReadOnly Property Pitch_Degrees() As Single
        Get
            Return CamAngleY * (180.0F / 3.14159274F)
        End Get
    End Property

    Public Property Position() As Vector3
        Get
            Return pos
        End Get
        Set(value As Vector3)
            pos = value
        End Set
    End Property
    Public Property LookAt() As Vector3
        Get
            Return lookat_Renamed
        End Get
        Set(value As Vector3)
            lookat_Renamed = value
        End Set
    End Property
    Public Property NearPoint() As Vector3
        Get
            Return nearPoint_Renamed
        End Get
        Set(value As Vector3)
            nearPoint_Renamed = value
        End Set
    End Property
    Public Property FarPoint() As Vector3
        Get
            Return farPoint_Renamed
        End Get
        Set(value As Vector3)
            farPoint_Renamed = value
        End Set
    End Property
    'public Matrix4 CameraMatrix { get { return matrix; } set { matrix = value; } }

    Private orbitDistance As Single = 500.0F
    Private orbitTheta As Single = 0.0F, orbitPhi As Single = 0.0F

    Private currentLookDirection As LookDirection
    Private lookPositions() As Vector3 = {
            New Vector3(0, 12500, 0),
            New Vector3(0, -12500, 0),
            New Vector3(-12500, 0, 0),
            New Vector3(12500, 0, 0),
            New Vector3(0, 0, 12500),
            New Vector3(0, 0, -12500)
        }

    Public Sub New()
        setRotationFromLookAt()
    End Sub

    Private Function clampf(value As Single, min As Single, max As Single) As Single
        Return (If(value > max, max, (If(value < min, min, value))))
    End Function

    Private Sub orientateCam(ang As Single, ang2 As Single)
        Dim CamLX As Single = CSng(Math.Sin(ang)) * CSng(Math.Sin(-ang2))
        Dim CamLY As Single = CSng(Math.Cos(ang2))
        Dim CamLZ As Single = CSng(-Math.Cos(ang)) * CSng(Math.Sin(-ang2))

        lookat_Renamed.X = pos.X + (-CamLX) * 100.0F
        lookat_Renamed.Y = pos.Y + (-CamLY) * 100.0F
        lookat_Renamed.Z = pos.Z + (-CamLZ) * 100.0F
    End Sub

    Private Sub offsetCam(xAmt As Integer, yAmt As Integer, zAmt As Integer)
        'INSTANT VB NOTE: The variable pitch was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim pitch_Renamed As Double = CamAngleY - (Math.PI / 2)
        'Console.WriteLine("Math.Sin(pitch) = " + Math.Sin(pitch));
        Dim CamLX As Single = CSng(Math.Sin(CamAngleX)) * CSng(Math.Cos(-pitch_Renamed))
        Dim CamLY As Single = CSng(Math.Sin(pitch_Renamed))
        Dim CamLZ As Single = CSng(-Math.Cos(CamAngleX)) * CSng(Math.Cos(-pitch_Renamed))
        pos.X = pos.X + xAmt * (CamLX) * camSpeedMultiplier
        pos.Y = pos.Y + yAmt * (CamLY) * camSpeedMultiplier
        pos.Z = pos.Z + zAmt * (CamLZ) * camSpeedMultiplier
    End Sub

    Public Sub Move(y As Single, ByRef camMtx As Matrix4)
        offsetCam(0, y, 0)
        orientateCam(CamAngleX, CamAngleY)
        updateMatrix(camMtx)
    End Sub
    Public Sub Move(x As Single, z As Single, ByRef camMtx As Matrix4)
        updateCameraOffsetDirectly(x, z, camMtx)
        orientateCam(CamAngleX, CamAngleY)
        updateMatrix(camMtx)
    End Sub

    Public Sub setRotationFromLookAt()
        Dim x_diff As Single = lookat_Renamed.X - pos.X
        Dim y_diff As Single = lookat_Renamed.Y - pos.Y
        Dim z_diff As Single = lookat_Renamed.Z - pos.Z
        Dim dist As Single = CSng(Math.Sqrt(x_diff * x_diff + y_diff * y_diff + z_diff * z_diff))
        If z_diff = 0 Then
            z_diff = 0.001F
        End If
        Dim nxz_ratio As Single = -x_diff / z_diff
        If z_diff < 0 Then
            CamAngleX = CSng(Math.Atan(nxz_ratio) + Math.PI)
        Else
            CamAngleX = CSng(Math.Atan(nxz_ratio))
        End If
        CamAngleY = -3.1459F - (CSng(Math.Asin(y_diff / dist)) - 1.57F)
    End Sub

    Public Sub resetOrbitToSelectedObject()
        Dim objs As RenderingN.ICameraPoint() = getSelectedObject()
        If objs?.Length > 0 Then
            orbitTheta = -(CalculateCenterYRotationOfObjects(objs) * (CSng(Math.PI) / 180.0F))
            orbitPhi = -0.3F
            orbitDistance = 1200.0F
        End If
    End Sub

    Public Sub updateOrbitCamera(ByRef cameraMatrix As Matrix4)
        If camMode_Renamed = CameraMode.ORBIT Then
            Dim objs As OpenGLFactory.RenderingN.ICameraPoint() = getSelectedObject()
            If objs?.Length > 0 Then
                Dim centerPos As Numerics.Vector3 = CalculateCenterPositionOfObjects(objs)
                pos.X = centerPos.X + CSng(Math.Cos(orbitPhi) * -Math.Sin(orbitTheta) * orbitDistance)
                pos.Y = centerPos.Y + CSng(-Math.Sin(orbitPhi) * orbitDistance)
                pos.Z = centerPos.Z + CSng(Math.Cos(orbitPhi) * Math.Cos(orbitTheta) * orbitDistance)
                lookat_Renamed.X = centerPos.X
                lookat_Renamed.Y = centerPos.Y
                lookat_Renamed.Z = centerPos.Z
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
            End If
        End If
    End Sub

    Public Function IsOrbitCamera() As Boolean
        Return camMode_Renamed = CameraMode.ORBIT
    End Function

    Public Sub SetCameraMode(mode As CameraMode, ByRef cameraMatrix As Matrix4)
        camMode_Renamed = mode
        If IsOrbitCamera() Then
            resetOrbitToSelectedObject()
            updateOrbitCamera(cameraMatrix)
        End If
    End Sub

    Public Sub setCameraMode_LookDirection(dir As LookDirection, ByRef cameraMatrix As Matrix4)
        camMode_Renamed = CameraMode.LOOK_DIRECTION
        currentLookDirection = dir
        Select Case currentLookDirection
            Case LookDirection.TOP
                pos = lookPositions(CInt(LookDirection.TOP))
                lookat_Renamed = New Vector3(pos.X, -25000, pos.Z - 1)
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
            Case LookDirection.BOTTOM
                pos = lookPositions(CInt(LookDirection.BOTTOM))
                lookat_Renamed = New Vector3(pos.X, 25000, pos.Z + 1)
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
            Case LookDirection.LEFT
                pos = lookPositions(CInt(LookDirection.LEFT))
                lookat_Renamed = New Vector3(25000, pos.Y, pos.Z)
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
            Case LookDirection.RIGHT
                pos = lookPositions(CInt(LookDirection.RIGHT))
                lookat_Renamed = New Vector3(-25000, pos.Y, pos.Z)
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
            Case LookDirection.FRONT
                pos = lookPositions(CInt(LookDirection.FRONT))
                lookat_Renamed = New Vector3(pos.X, pos.Y, -25000)
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
            Case LookDirection.BACK
                pos = lookPositions(CInt(LookDirection.BACK))
                lookat_Renamed = New Vector3(pos.X, pos.Y, 25000)
                updateMatrix(cameraMatrix)
                setRotationFromLookAt()
        End Select
    End Sub

    Public Sub updateCameraMatrixWithMouse(mouseX As Integer, mouseY As Integer, ByRef cameraMatrix As Matrix4)
        If camMode_Renamed = CameraMode.ORBIT AndAlso getSelectedObject() IsNot Nothing Then
            updateCameraMatrixWithMouse_ORBIT(mouseX, mouseY, cameraMatrix)
        ElseIf camMode_Renamed = CameraMode.LOOK_DIRECTION Then
            updateCameraMatrixWithMouse_LOOK(pos, mouseX, mouseY, cameraMatrix)
        Else
            updateCameraMatrixWithMouse_FLY(mouseX, mouseY, cameraMatrix)
        End If
    End Sub

    Public Sub updateCameraOffsetWithMouse(orgPos As Vector3, mouseX As Integer, mouseY As Integer, w As Integer, h As Integer, ByRef cameraMatrix As Matrix4)
        If camMode_Renamed = CameraMode.ORBIT AndAlso getSelectedObject() IsNot Nothing Then
            updateCameraOffsetWithMouse_ORBIT(mouseX, mouseY, cameraMatrix)
        ElseIf camMode_Renamed = CameraMode.LOOK_DIRECTION Then
            updateCameraMatrixWithMouse_LOOK(pos, mouseX, mouseY, cameraMatrix)
        Else
            updateCameraOffsetWithMouse_FLY(orgPos, mouseX, mouseY, w, h, cameraMatrix)
        End If
    End Sub

    Public Sub updateCameraMatrixWithScrollWheel(amt As Integer, ByRef cameraMatrix As Matrix4)
        If camMode_Renamed = CameraMode.ORBIT AndAlso getSelectedObject() IsNot Nothing Then
            updateCameraMatrixWithScrollWheel_ORBIT(amt, cameraMatrix)
        ElseIf camMode_Renamed = CameraMode.LOOK_DIRECTION Then
            updateCameraMatrixWithScrollWheel_LOOK(amt, cameraMatrix)
        Else
            updateCameraMatrixWithScrollWheel_FLY(amt, cameraMatrix)
        End If
    End Sub

    Private Sub updateCameraMatrixWithScrollWheel_FLY(amt As Integer, ByRef cameraMatrix As Matrix4)
        offsetCam(amt, amt, amt)
        orientateCam(CamAngleX, CamAngleY)
        updateMatrix(cameraMatrix)
    End Sub

    Public Sub updateMatrix(ByRef cameraMatrix As Matrix4)
        cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, lookat_Renamed.X, lookat_Renamed.Y, lookat_Renamed.Z, 0, 1, 0)
    End Sub

    Private Sub updateCameraMatrixWithScrollWheel_LOOK(amt As Integer, ByRef cameraMatrix As Matrix4)
        offsetCam(amt, amt, amt)
        orientateCam(CamAngleX, CamAngleY)
        Select Case currentLookDirection
            Case LookDirection.TOP
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, lookat_Renamed.X, lookat_Renamed.Y, lookat_Renamed.Z - 1, 0, 1, 0)
            Case LookDirection.BOTTOM
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, lookat_Renamed.X, lookat_Renamed.Y, lookat_Renamed.Z + 1, 0, 1, 0)
            Case Else
                updateMatrix(cameraMatrix)
        End Select
    End Sub

    Private Sub updateCameraMatrixWithMouse_LOOK(orgPos As Vector3, mouseX As Integer, mouseY As Integer, ByRef cameraMatrix As Matrix4)
        If resetMouse Then
            lastMouseX = mouseX
            lastMouseY = mouseY
            resetMouse = False
        End If
        Dim MousePosX As Integer = mouseX - lastMouseX
        Dim MousePosY As Integer = mouseY - lastMouseY

        Dim pitch_Renamed As Double = CamAngleY - (Math.PI / 2)
        Dim yaw_Renamed As Double = CamAngleX - (Math.PI / 2)
        Dim CamLX As Single = CSng(Math.Sin(yaw_Renamed))
        Dim CamLY As Single = CSng(Math.Cos(pitch_Renamed))
        Dim CamLZ As Single = CSng(-Math.Cos(yaw_Renamed))

        Dim m As Single = 8.0F

        Select Case currentLookDirection
            Case LookDirection.TOP
                pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * m) - ((MousePosY * camSpeedMultiplier) * (CamLZ) * m)
                pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * m) - ((MousePosY * camSpeedMultiplier) * (CamLX) * m)
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, pos.X, pos.Y - 1000, pos.Z - 1, 0, 1, 0)
                lookPositions(CInt(currentLookDirection)) = pos
            Case LookDirection.BOTTOM
                pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * m) + ((MousePosY * camSpeedMultiplier) * (CamLZ) * m)
                pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * m) + ((MousePosY * camSpeedMultiplier) * (CamLX) * m)
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, pos.X, pos.Y + 1000, pos.Z + 1, 0, 1, 0)
                lookPositions(CInt(currentLookDirection)) = pos
            Case LookDirection.LEFT
                pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * m)
                pos.Y = orgPos.Y - ((MousePosY * camSpeedMultiplier) * (-1.0F) * m)
                pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * m)
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, pos.X + 12500, pos.Y, pos.Z, 0, 1, 0)
                lookPositions(CInt(currentLookDirection)) = pos
            Case LookDirection.RIGHT
                pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * m)
                pos.Y = orgPos.Y - ((MousePosY * camSpeedMultiplier) * (-1.0F) * m)
                pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * m)
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, pos.X - 12500, pos.Y, pos.Z, 0, 1, 0)
                lookPositions(CInt(currentLookDirection)) = pos
            Case LookDirection.FRONT
                pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * m)
                pos.Y = orgPos.Y - ((MousePosY * camSpeedMultiplier) * (-1.0F) * m)
                pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * m)
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, pos.X, pos.Y, pos.Z - 12500, 0, 1, 0)
                lookPositions(CInt(currentLookDirection)) = pos
            Case LookDirection.BACK
                pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * m)
                pos.Y = orgPos.Y - ((MousePosY * camSpeedMultiplier) * (-1.0F) * m)
                pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * m)
                cameraMatrix = Matrix4.LookAt(pos.X, pos.Y, pos.Z, pos.X, pos.Y, pos.Z + 12500, 0, 1, 0)
                lookPositions(CInt(currentLookDirection)) = pos
        End Select

        lastMouseX = mouseX
        lastMouseY = mouseY
        'Console.WriteLine("CamAngleX = " + CamAngleX + ", CamAngleY = " + CamAngleY);
        'setRotationFromLookAt();
    End Sub

    Private Sub updateCameraMatrixWithMouse_FLY(mouseX As Integer, mouseY As Integer, ByRef cameraMatrix As Matrix4)
        If resetMouse Then
            lastMouseX = mouseX
            lastMouseY = mouseY
            resetMouse = False
        End If
        Dim MousePosX As Integer = mouseX - lastMouseX
        Dim MousePosY As Integer = mouseY - lastMouseY
        CamAngleX = CamAngleX + (0.01F * MousePosX)
        ' This next part isn't neccessary, but it keeps the Yaw rotation value within [0, 2*pi] which makes debugging simpler.
        If CamAngleX > TAU Then
            CamAngleX -= TAU
        ElseIf CamAngleX < 0 Then
            CamAngleX += TAU
        End If

        '             Lock pitch rotation within the bounds of [-3.1399.0, -0.0001], otherwise the LookAt function will snap to the 
        '               opposite side and reverse mouse looking controls.
        CamAngleY = clampf((CamAngleY + (0.01F * MousePosY)), -3.1399F, -0.0001F)

        lastMouseX = mouseX
        lastMouseY = mouseY
        orientateCam(CamAngleX, CamAngleY)
        updateMatrix(cameraMatrix)
        'Console.WriteLine("CamAngleX = " + CamAngleX + ", CamAngleY = " + CamAngleY);
        'setRotationFromLookAt();
    End Sub

    Private Sub updateCameraOffsetWithMouse_FLY(orgPos As Vector3, mouseX As Integer, mouseY As Integer, w As Integer, h As Integer, ByRef cameraMatrix As Matrix4)
        If resetMouse Then
            lastMouseX = mouseX
            lastMouseY = mouseY
            resetMouse = False
        End If
        Dim MousePosX As Integer = (-mouseX) + lastMouseX
        Dim MousePosY As Integer = (-mouseY) + lastMouseY
        'Console.WriteLine(MousePosX+","+ MousePosY);
        'INSTANT VB NOTE: The variable pitch was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim pitch_Renamed As Double = CamAngleY - (Math.PI / 2)
        'INSTANT VB NOTE: The variable yaw was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim yaw_Renamed As Double = CamAngleX - (Math.PI / 2)
        Dim CamLX As Single = CSng(Math.Sin(yaw_Renamed))
        ' float CamLY = (float)Math.Cos(pitch);
        Dim CamLZ As Single = CSng(-Math.Cos(yaw_Renamed))
        pos.X = orgPos.X - ((MousePosX * camSpeedMultiplier) * (CamLX) * 6.0F)
        pos.Y = orgPos.Y - ((MousePosY * camSpeedMultiplier) * (-1.0F) * 6.0F)
        pos.Z = orgPos.Z - ((MousePosX * camSpeedMultiplier) * (CamLZ) * 6.0F)

        orientateCam(CamAngleX, CamAngleY)
        updateMatrix(cameraMatrix)
    End Sub

    Public Sub updateCameraOffsetDirectly(horz_amount As Integer, vert_amount As Integer, ByRef cameraMatrix As Matrix4)
        If camMode_Renamed = CameraMode.ORBIT Then
            updateCameraOffsetDirectly_ORBIT(horz_amount / 5, vert_amount / 5, cameraMatrix)
        Else
            'Console.WriteLine(MousePosX+","+ MousePosY);
            Dim pitch_Renamed As Double = CamAngleY - (Math.PI / 2)
            Dim yaw_Renamed As Double = CamAngleX - (Math.PI / 2)
            Dim CamLX As Single = CSng(Math.Sin(yaw_Renamed))
            ' float CamLY = (float)Math.Cos(pitch);
            Dim CamLZ As Single = CSng(-Math.Cos(yaw_Renamed))
            pos.X += ((horz_amount * camSpeedMultiplier) * (CamLX))
            pos.Y += ((vert_amount * camSpeedMultiplier) * (-1.0F))
            pos.Z += ((horz_amount * camSpeedMultiplier) * (CamLZ))

            orientateCam(CamAngleX, CamAngleY)
            updateMatrix(cameraMatrix)
        End If
    End Sub

    Private Sub updateCameraOffsetDirectly_ORBIT(moveSpeedX As Integer, moveSpeedY As Integer, ByRef cameraMatrix As Matrix4)
        Dim MousePosX As Integer = moveSpeedX
        Dim MousePosY As Integer = moveSpeedY
        orbitTheta += MousePosX * 0.01F * camSpeedMultiplier
        orbitPhi -= MousePosY * 0.01F * camSpeedMultiplier
        orbitPhi = clampf(orbitPhi, -1.57F, 1.57F)
        updateOrbitCamera(cameraMatrix)
    End Sub

    Private Sub updateCameraMatrixWithMouse_ORBIT(mouseX As Integer, mouseY As Integer, ByRef cameraMatrix As Matrix4)
        updateCameraOffsetWithMouse_ORBIT(mouseX, mouseY, cameraMatrix)
    End Sub

    Private Sub updateCameraOffsetWithMouse_ORBIT(mouseX As Integer, mouseY As Integer, ByRef cameraMatrix As Matrix4)
        If resetMouse Then
            lastMouseX = mouseX
            lastMouseY = mouseY
            resetMouse = False
        End If
        Dim MousePosX As Integer = (-mouseX) + lastMouseX
        Dim MousePosY As Integer = (-mouseY) + lastMouseY
        orbitTheta += MousePosX * 0.01F * camSpeedMultiplier
        orbitPhi -= MousePosY * 0.01F * camSpeedMultiplier
        orbitPhi = clampf(orbitPhi, -1.57F, 1.57F)
        updateOrbitCamera(cameraMatrix)
        lastMouseX = mouseX
        lastMouseY = mouseY
        'Console.WriteLine("ORBIT_THETA: " + orbitTheta + ", ORBIT_PHI: " + orbitPhi);
    End Sub

    Private Sub updateCameraMatrixWithScrollWheel_ORBIT(amt As Integer, ByRef cameraMatrix As Matrix4)
        orbitDistance -= amt
        If orbitDistance < 300.0F Then
            orbitDistance = 300.0F
        End If
        updateOrbitCamera(cameraMatrix)
    End Sub

    Public Sub resetMouseStuff()
        resetMouse = True
    End Sub

    Private Function CalculateCenterPositionOfObjects(objs As RenderingN.ICameraPoint()) As Numerics.Vector3
        If objs.Length <= 1 Then
            Dim obj As RenderingN.ICameraPoint = objs.FirstOrDefault
            If obj Is Nothing Then
                Return Numerics.Vector3.Zero
            Else
                Return New Numerics.Vector3(obj.Position.X,
                                            obj.Position.Y,
                                            obj.Position.Z)
            End If
        End If

        Dim maxX As Single? = Nothing
        Dim maxY As Single? = Nothing
        Dim maxZ As Single? = Nothing
        Dim minX As Single? = Nothing
        Dim minY As Single? = Nothing
        Dim minZ As Single? = Nothing

        For Each obj As RenderingN.ICameraPoint In objs
            Dim pos As Numerics.Vector3 = obj.Position
            If maxX Is Nothing OrElse pos.X > maxX Then maxX = pos.X
            If maxY Is Nothing OrElse pos.Y > maxY Then maxY = pos.Y
            If maxZ Is Nothing OrElse pos.Z > maxZ Then maxZ = pos.Z
            If minX Is Nothing OrElse pos.X < minX Then minX = pos.X
            If minY Is Nothing OrElse pos.Y < minY Then minY = pos.Y
            If minZ Is Nothing OrElse pos.Z < minZ Then minZ = pos.Z
        Next

        If maxX Is Nothing Then maxX = 0
        If maxY Is Nothing Then maxY = 0
        If maxZ Is Nothing Then maxZ = 0
        If minX Is Nothing Then minX = 0
        If minY Is Nothing Then minY = 0
        If minZ Is Nothing Then minZ = 0

        Dim upper As New Numerics.Vector3(maxX, maxY, maxZ)
        Dim lower As New Numerics.Vector3(minX, minY, minZ)

        Dim middle As Numerics.Vector3 = (upper + lower) / 2

        Return middle
    End Function

    Private Function CalculateCenterYRotationOfObjects(objs As RenderingN.ICameraPoint()) As Single
        If objs.Length <= 1 Then
            Dim obj As RenderingN.ICameraPoint = objs.FirstOrDefault
            If obj Is Nothing Then
                Return 0
            Else
                Return obj.Rotation.Y
            End If
        End If

        Dim yRot As New List(Of Single)

        For Each obj As RenderingN.ICameraPoint In objs
            yRot.Add(obj.Rotation.Y)
        Next

        Return yRot.Average
    End Function

    Private Function getSelectedObject() As RenderingN.ICameraPoint()
        Dim e As New NeedSelectedObjectEventArgs
        RaiseEvent NeedSelectedObject(e)

        Dim stopw As New Stopwatch
        stopw.Start()

        Do Until e.HasObjectSetted OrElse stopw.ElapsedMilliseconds > 1000
            Application.DoEvents()
        Loop

        stopw.Stop()

        Return e.Points
    End Function

    Public Event NeedSelectedObject(e As NeedSelectedObjectEventArgs)
    Public Class NeedSelectedObjectEventArgs
        Inherits EventArgs

        Private _HasObjectSetted As Boolean = False
        Public ReadOnly Property HasObjectSetted As Boolean
            Get
                Return _HasObjectSetted
            End Get
        End Property

        Private _Points As RenderingN.ICameraPoint() = Nothing
        Public Property Points As RenderingN.ICameraPoint()
            Get
                Return _Points
            End Get
            Set(value As RenderingN.ICameraPoint())
                _Points = value
                _HasObjectSetted = True
            End Set
        End Property

    End Class

End Class
