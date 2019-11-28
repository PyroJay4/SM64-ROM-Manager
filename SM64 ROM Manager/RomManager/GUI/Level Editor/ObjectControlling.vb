Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports OpenTK
Imports SM64Lib.TextValueConverter
Imports SM64Lib.Levels
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports OpenTK.Graphics.OpenGL
Imports SM64Lib.Geolayout.Script.Commands
Imports System.ComponentModel
Imports SM64Lib.Model.Fast3D.DisplayLists
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib.Geolayout
Imports SM64Lib.Model
Imports SM64_ROM_Manager.ModelConverterGUI
Imports SimpleHistory
Imports System.Reflection
Imports DevComponents.Editors
Imports SM64_ROM_Manager.PropertyValueEditors
Imports SM64_ROM_Manager.Publics
Imports DevComponents.AdvTree
Imports System.Timers
Imports Newtonsoft.Json.Linq
Imports SM64Lib.Data
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.CameraN

Namespace LevelEditor

    Public Class ObjectControlling

        Private WithEvents Main As Form_AreaEditor

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

        Public Property WasInOrbitMode As Boolean = False

        Public Sub New(main As Form_AreaEditor)
            Me.Main = main
            AddHandlers()
        End Sub

        Private Sub AddHandlers()
            AddHandler Main.PictureBox_ObjCntrWheel.MouseDown, AddressOf PictureBox_ObjCntrWheel_MouseDown
            AddHandler Main.PictureBox_ObjCntrWheel.MouseUp, AddressOf PictureBox_ObjCntrWheel_MouseUp
            AddHandler Main.PictureBox_ObjCntrWheel.MouseMove, AddressOf PictureBox_ObjCntrWheel_MouseMove
            AddHandler Main.PictureBox_ObjCntrCross.MouseDown, AddressOf PictureBox_ObjCntrCross_MouseDown
            AddHandler Main.PictureBox_ObjCntrCross.MouseUp, AddressOf PictureBox_ObjCntrCross_MouseUp
            AddHandler Main.PictureBox_ObjCntrCross.MouseMove, AddressOf PictureBox_ObjCntrCross_MouseMove
            AddHandler Main.PictureBox_ObjRotWheel.MouseDown, AddressOf PictureBox_ObjRotWheel_MouseDown
            AddHandler Main.PictureBox_ObjRotWheel.MouseUp, AddressOf PictureBox_ObjRotWheel_MouseUp
            AddHandler Main.PictureBox_ObjRotWheel.MouseMove, AddressOf PictureBox_ObjRotWheel_MouseMove
            AddHandler Main.PictureBox_ObjRotCross.MouseDown, AddressOf PictureBox_ObjRotCross_MouseDown
            AddHandler Main.PictureBox_ObjRotCross.MouseUp, AddressOf PictureBox_ObjRotCross_MouseUp
            AddHandler Main.PictureBox_ObjRotCross.MouseMove, AddressOf PictureBox_ObjRotCross_MouseMove
            AddHandler Main.PictureBox_CamCntrWheel.MouseDown, AddressOf PictureBox_CamCntrWheel_MouseDown
            AddHandler Main.PictureBox_CamCntrWheel.MouseUp, AddressOf PictureBox_CamCntrWheel_MouseUp
            AddHandler Main.PictureBox_CamCntrWheel.MouseMove, AddressOf PictureBox_CamCntrWheel_MouseMove
            AddHandler Main.PictureBox_CamMoveCross.MouseDown, AddressOf PictureBox_CamMoveCross_MouseDown
            AddHandler Main.PictureBox_CamMoveCross.MouseUp, AddressOf PictureBox_CamMoveCross_MouseUp
            AddHandler Main.PictureBox_CamMoveCross.MouseMove, AddressOf PictureBox_CamMoveCross_MouseMove
            AddHandler Main.Camera.NeedSelectedObject, AddressOf Camera_NeedSelectedObject
            AddHandler Main.CheckBoxItem_PerspectiveMode.CheckedChanged, AddressOf CheckBoxItem_PerspectiveMode_CheckedChanged
            AddHandler Main.CheckBoxItem_OrthoMode.CheckedChanged, AddressOf CheckBoxItem_OrthoMode_CheckedChanged
        End Sub

        Private Sub saveObjectPositionToList()
            moveObj_saved.Clear()
            For Each obj As Managed3DObject In Main.SelectedObjects
                moveObj_saved.Add(obj.Position)
            Next
        End Sub

        Private Sub saveObjectRotationToList()
            moveObj_saved.Clear()
            For Each obj As Managed3DObject In Main.SelectedObjects
                moveObj_saved.Add(obj.Rotation)
            Next
        End Sub

        Public Sub PictureBox_ObjCntrWheel_MouseDown(sender As Object, e As MouseEventArgs)
            moveObj_UpDown_lastMouseY = e.Y
            saveObjectPositionToList()
            Main.StoreObjectHistoryPoint(Main.SelectedObjects, NameOf(Managed3DObject.Position))
            moveObj_UpDown_mouseDown = True
        End Sub

        Public Sub PictureBox_ObjCntrWheel_MouseUp(sender As Object, e As MouseEventArgs)
            moveObj_UpDown_mouseDown = False
        End Sub

        Public Sub PictureBox_ObjCntrWheel_MouseMove(sender As Object, e As MouseEventArgs)
            If moveObj_UpDown_mouseDown Then
                For mo_s_incr As Integer = 0 To Main.SelectedObjects.Length - 1
                    Dim obj As Managed3DObject = Main.SelectedObjects(mo_s_incr)
                    moveObjectY(obj, e.Location, moveObj_saved(mo_s_incr), False)
                Next

                If Main.KeepObjectOnGround Then
                    Main.KeepObjectsOnGround()
                Else
                    Main.AdvPropertyGrid1_RefreshPropertyValues()
                End If

                Main.ogl.GLControl.Invalidate()
            End If
        End Sub

        Public Sub PictureBox_ObjCntrCross_MouseDown(sender As Object, e As MouseEventArgs)
            If Main.EditObjects AndAlso Main.SelectedObject IsNot Nothing Then
                Dim objs() As Managed3DObject = Main.SelectedObjects
                If objs.Length = 0 Then Return
                Main.StoreObjectHistoryPoint(objs, "Position")
                moveObj_mouseDown = True
                moveObj_lastMouseX = e.X
                moveObj_lastMouseY = e.Y
                saveObjectPositionToList()
            End If
        End Sub
        Public Sub PictureBox_ObjCntrCross_MouseUp(sender As Object, e As MouseEventArgs)
            moveObj_mouseDown = False
        End Sub
        Public Sub PictureBox_ObjCntrCross_MouseMove(sender As Object, e As MouseEventArgs)
            If moveObj_mouseDown Then
                If Main.EditObjects AndAlso Main.SelectedObject IsNot Nothing Then
                    Dim mo_s_incr As Integer = 0

                    For Each obj As Object In Main.SelectedObjects
                        moveObjectXZ(obj,
                                     CType(sender, Control).PointToClient(Cursor.Position),
                                     moveObj_saved(mo_s_incr),
                                     False)
                        mo_s_incr += 1
                    Next

                    If Main.KeepObjectOnGround Then
                        Main.KeepObjectsOnGround()
                    Else
                        Main.AdvPropertyGrid1_RefreshPropertyValues()
                    End If

                    Main.KeepObjectsOnGround()
                    Main.ogl.GLControl.Invalidate()
                End If
            End If
        End Sub

        Private Sub moveObjectY(obj As Managed3DObject, e As Drawing.Point, savedPos As Numerics.Vector3, forRotation As Boolean)
            If Not forRotation Then
                Dim newY As Short = -Math.Truncate(30 * (e.Y - moveObj_UpDown_lastMouseY) * Main.ObjectMoveSpeed)
                obj.Position = New Numerics.Vector3(obj.Position.X, savedPos.Y + newY, obj.Position.Z)
            Else
                Dim newY As Short = -(Math.Truncate((e.Y - rotObj_Yaw_lastMouseY) * Main.ObjectMoveSpeed))
                RotateObject(obj, New Numerics.Vector3(obj.Rotation.X, newY, obj.Rotation.Z))
            End If

            Main.ogl.UpdateOrbitCamera()
        End Sub

        Private Sub moveObjectXZ(obj As Managed3DObject, e As Drawing.Point, savedPos As Numerics.Vector3, forRotation As Boolean)
            Dim speedMult As Single = 30.0F
            Dim mx, my As Integer

            If Not forRotation Then
                mx = e.X - moveObj_lastMouseX
                my = -(e.Y - moveObj_lastMouseY)
            Else
                mx = e.X - rotObj_lastMouseX
                my = -(e.Y - rotObj_lastMouseY)
            End If

            Dim CX As Single = Math.Sin(Main.Camera.Yaw)
            Dim CZ As Single = -Math.Cos(Main.Camera.Yaw)
            Dim CX_2 As Single = Math.Sin(Main.Camera.Yaw + (Math.PI / 2))
            Dim CZ_2 As Single = -Math.Cos(Main.Camera.Yaw + (Math.PI / 2))

            Dim newX, newZ As Single
            newX = Math.Truncate(savedPos.X - CShort(Math.Truncate(CX * my * speedMult * Main.ObjectMoveSpeed)) - CShort(Math.Truncate(CX_2 * mx * speedMult * Main.ObjectMoveSpeed)))
            newZ = Math.Truncate(savedPos.Z - CShort(Math.Truncate(CZ * my * speedMult * Main.ObjectMoveSpeed)) - CShort(Math.Truncate(CZ_2 * mx * speedMult * Main.ObjectMoveSpeed)))

            If Not forRotation Then
                Dim oldPos As Numerics.Vector3 = obj.Position
                Dim newPos As New Numerics.Vector3(CShort(newX), oldPos.Y, CShort(newZ))
                SetObjectPosition(obj, newPos)
            Else
                speedMult = 0.5F
                Dim oldRot As Numerics.Vector3 = obj.Rotation
                Dim newRot As New Numerics.Vector3(newX, oldRot.Y, newZ)
                SetObjectRotation(obj, newRot)
            End If

            Main.ogl.UpdateOrbitCamera()
        End Sub

        Private Sub MoveObject(obj As Managed3DObject, val As Numerics.Vector3)
            obj.Position = New Numerics.Vector3(obj.Position.X + val.X,
                                                obj.Position.Y + val.Y,
                                                obj.Position.Z + val.Z)
        End Sub
        Private Sub SetObjectPosition(obj As Managed3DObject, pos As Numerics.Vector3)
            obj.Position = pos
        End Sub

        Private Sub RotateObject(obj As Managed3DObject, val As Numerics.Vector3)
            obj.Rotation = New Numerics.Vector3(KeepDegreesWithin360(obj.Rotation.X + val.X),
                                                KeepDegreesWithin360(obj.Rotation.Y + val.Y),
                                               KeepDegreesWithin360(obj.Rotation.Z + val.Z))
        End Sub
        Private Sub SetObjectRotation(obj As Managed3DObject, rot As Numerics.Vector3)
            obj.Rotation = New Numerics.Vector3(KeepDegreesWithin360(rot.X),
                                              KeepDegreesWithin360(rot.Y),
                                              KeepDegreesWithin360(rot.Z))
        End Sub

        Private Sub PictureBox_ObjRotWheel_MouseDown(sender As Object, e As MouseEventArgs)
            If Main.EditObjects AndAlso Main.SelectedObject IsNot Nothing Then
                rotObj_Yaw_lastMouseY = e.Y
                Main.StoreObjectHistoryPoint(Main.SelectedObjects, NameOf(Managed3DObject.Rotation))
                rotObj_Yaw_mouseDown = True
            End If
        End Sub
        Private Sub PictureBox_ObjRotWheel_MouseUp(sender As Object, e As MouseEventArgs)
            rotObj_Yaw_mouseDown = False
        End Sub
        Private Sub PictureBox_ObjRotWheel_MouseMove(sender As Object, e As MouseEventArgs)
            If rotObj_Yaw_mouseDown Then
                If Main.EditObjects AndAlso Main.SelectedObject IsNot Nothing Then

                    For mo_s_incr As Integer = 0 To Main.SelectedObjects.Length - 1
                        Dim obj As Managed3DObject = Main.SelectedObjects.ElementAtOrDefault(mo_s_incr)
                        If obj IsNot Nothing Then
                            moveObjectY(obj, e.Location, moveObj_saved(mo_s_incr), True)
                        End If
                    Next

                    Main.ogl.Invalidate()
                    rotObj_Yaw_lastMouseY = e.Y
                    Main.AdvPropertyGrid1_RefreshPropertyValues()
                End If
            End If
        End Sub

        Private Sub PictureBox_ObjRotCross_MouseDown(sender As Object, e As MouseEventArgs)
            If Main.EditObjects AndAlso Main.SelectedObject IsNot Nothing Then
                Main.StoreObjectHistoryPoint(Main.SelectedObjects, NameOf(Managed3DObject.Rotation))
                rotObj_mouseDown = True
                rotObj_lastMouseX = e.X
                rotObj_lastMouseY = e.Y
                saveObjectRotationToList()
            End If
        End Sub
        Private Sub PictureBox_ObjRotCross_MouseUp(sender As Object, e As MouseEventArgs)
            rotObj_mouseDown = False
        End Sub
        Private Sub PictureBox_ObjRotCross_MouseMove(sender As Object, e As MouseEventArgs)
            If rotObj_mouseDown Then
                If Main.EditObjects AndAlso Main.SelectedObject IsNot Nothing Then
                    For mo_s_incr = 0 To Main.SelectedObjects.Length - 1
                        Dim obj As Managed3DObject = Main.SelectedObjects.ElementAtOrDefault(mo_s_incr)
                        If obj IsNot Nothing Then
                            moveObjectXZ(obj,
                                         CType(sender, Control).PointToClient(Cursor.Position),
                                         moveObj_saved(mo_s_incr),
                                         True)
                            mo_s_incr += 1
                        End If
                    Next

                    Main.KeepObjectsOnGround()
                    Main.ogl.Invalidate()
                    Main.AdvPropertyGrid1_RefreshPropertyValues()
                End If
            End If
        End Sub

        Private Sub PictureBox_CamCntrWheel_MouseDown(sender As Object, e As MouseEventArgs)
            moveCam_InOut_mouseDown = True
            moveCam_InOut_lastPosY = e.Y
        End Sub
        Private Sub PictureBox_CamCntrWheel_MouseUp(sender As Object, e As MouseEventArgs)
            moveCam_InOut_mouseDown = False
        End Sub
        Private Sub PictureBox_CamCntrWheel_MouseMove(sender As Object, e As MouseEventArgs)
            If moveCam_InOut_mouseDown Then
                Main.Camera.ResetMouseStuff()
                Main.Camera.UpdateCameraMatrixWithScrollWheel((e.Y - moveCam_InOut_lastPosY) * -10, Main.ogl.camMtx)
                Main.ogl.savedCamPos = Main.Camera.Position
                moveCam_InOut_lastPosY = e.Y
                Main.ogl.Invalidate()
            End If
        End Sub

        Private Sub PictureBox_CamMoveCross_MouseDown(sender As Object, e As MouseEventArgs)
            Main.ogl.savedCamPos = Main.Camera.Position
            moveCam_strafe_mouseDown = True
        End Sub
        Private Sub PictureBox_CamMoveCross_MouseUp(sender As Object, e As MouseEventArgs)
            Main.Camera.ResetMouseStuff()
            moveCam_strafe_mouseDown = False
        End Sub
        Private Sub PictureBox_CamMoveCross_MouseMove(sender As Object, e As MouseEventArgs)
            If moveCam_strafe_mouseDown Then
                Main.Camera.UpdateCameraOffsetWithMouse(Main.ogl.savedCamPos, e.X, e.Y, Main.ogl.GLControl.Width, Main.ogl.GLControl.Height, Main.ogl.camMtx)
                Main.ogl.Invalidate()
            End If
        End Sub

        Private Sub Camera_NeedSelectedObject(sender As Object, e As Camera.NeedSelectedObjectEventArgs)
            Dim needSelectedObject As Boolean
            Main.Invoke(Sub() needSelectedObject = Main.SelectedObject IsNot Nothing)

            If needSelectedObject Then
                Main.Invoke(Sub() e.Points = Main.SelectedObjects)
            ElseIf Main.Camera.CamMode = CameraMode.ORBIT Then
                Main.ogl.SetCameraMode(CameraMode.FLY)
                _WasInOrbitMode = True
            End If
        End Sub

        Private Sub CheckBoxItem_PerspectiveMode_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs)
            If sender.Checked Then
                Main.ogl.ChangeViewMode(False)
            End If
        End Sub

        Private Sub CheckBoxItem_OrthoMode_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs)
            If sender.Checked Then
                Main.ogl.ChangeViewMode(True)
            End If
        End Sub

    End Class

End Namespace
