Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports SharpDX.DirectInput

Public Class LevelEditorInputManager

    Private WithEvents Timer As New Timer With {.Interval = 1}
    Private DInput As New DirectInput
    Private allDevices As DeviceInstance() = {}
    Private curPad As Joystick = Nothing
    Private focuesTextBox As TextBoxX = Nothing
    Private curProfile As LevelEditorInputProfile = Nothing

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        StyleManager.UpdateAmbientColors(Me)

    End Sub

    Private Sub TextBoxX_LostFocus_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_DropToGround.LostFocus, TextBoxX_ObjMoveDown.LostFocus, TextBoxX_ObjMoveUp.LostFocus, TextBoxX_ObjMoveBackward.LostFocus, TextBoxX_ObjMoveFordward.LostFocus, TextBoxX_ObjMoveRight.LostFocus, TextBoxX_ObjMoveLeft.LostFocus, TextBoxX_NextObj.LostFocus, TextBoxX_NextArea.LostFocus, TextBoxX_LastObj.LostFocus, TextBoxX_LastArea.LostFocus, TextBoxX_CamMoveDown.LostFocus, TextBoxX_CamMoveUp.LostFocus, TextBoxX_CamMoveBackward.LostFocus, TextBoxX_CamMoveFordward.LostFocus, TextBoxX_CamMoveRight.LostFocus, TextBoxX_CamMoveLeft.LostFocus, TextBoxX_DropToGround.TextChanged, TextBoxX_ObjMoveDown.TextChanged, TextBoxX_ObjMoveUp.TextChanged, TextBoxX_ObjMoveBackward.TextChanged, TextBoxX_ObjMoveFordward.TextChanged, TextBoxX_ObjMoveRight.TextChanged, TextBoxX_ObjMoveLeft.TextChanged, TextBoxX_NextObj.TextChanged, TextBoxX_NextArea.TextChanged, TextBoxX_LastObj.TextChanged, TextBoxX_LastArea.TextChanged, TextBoxX_CamMoveDown.TextChanged, TextBoxX_CamMoveUp.TextChanged, TextBoxX_CamMoveBackward.TextChanged, TextBoxX_CamMoveFordward.TextChanged, TextBoxX_CamMoveRight.TextChanged, TextBoxX_CamMoveLeft.TextChanged
        Timer.Stop()
        focuesTextBox = Nothing
    End Sub
    Private Sub TextBoxX_Click(sender As Object, e As EventArgs) Handles TextBoxX_DropToGround.Click, TextBoxX_ObjMoveDown.Click, TextBoxX_ObjMoveUp.Click, TextBoxX_ObjMoveBackward.Click, TextBoxX_ObjMoveFordward.Click, TextBoxX_ObjMoveRight.Click, TextBoxX_ObjMoveLeft.Click, TextBoxX_NextObj.Click, TextBoxX_NextArea.Click, TextBoxX_LastObj.Click, TextBoxX_LastArea.Click, TextBoxX_CamMoveDown.Click, TextBoxX_CamMoveUp.Click, TextBoxX_CamMoveBackward.Click, TextBoxX_CamMoveFordward.Click, TextBoxX_CamMoveRight.Click, TextBoxX_CamMoveLeft.Click
        If curPad IsNot Nothing AndAlso curProfile IsNot Nothing Then
            focuesTextBox = sender
            Timer.Start()
        End If
    End Sub

    Private Sub Timer_Tick() Handles Timer.Tick
        If curPad IsNot Nothing Then
            Dim state As New JoystickState

            curPad.Poll()
            curPad.GetCurrentState(state)

            For i As Integer = 0 To state.Buttons.Length - 1
                If state.Buttons(i) AndAlso focuesTextBox IsNot Nothing Then
                    focuesTextBox.Text = "Button " & i
                End If
            Next

            For i As Integer = 0 To state.PointOfViewControllers.Length - 1
                If focuesTextBox IsNot Nothing Then
                    Dim val As Integer = state.PointOfViewControllers(i)
                    If val > -1 Then focuesTextBox.Text = "Point " & i & " " & val
                End If
            Next

            For i As Integer = 0 To state.Sliders.Length - 1
                If focuesTextBox IsNot Nothing Then
                    Dim val As Integer = state.Sliders(i)
                    If val > 0 Then focuesTextBox.Text = "Slider " & i & " +"
                    If val < 0 Then focuesTextBox.Text = "Slider " & i & " -"
                End If
            Next

            For i As Integer = 0 To state.AccelerationSliders.Length - 1
                If focuesTextBox IsNot Nothing Then
                    Dim val As Integer = state.AccelerationSliders(i)
                    If val > 0 Then focuesTextBox.Text = "ASlider " & i & " +"
                    If val < 0 Then focuesTextBox.Text = "ASlider " & i & " -"
                End If
            Next

            For i As Integer = 0 To state.ForceSliders.Length - 1
                If focuesTextBox IsNot Nothing Then
                    Dim val As Integer = state.ForceSliders(i)
                    If val > 0 Then focuesTextBox.Text = "FSlider " & i & " +"
                    If val < 0 Then focuesTextBox.Text = "FSlider " & i & " -"
                End If
            Next

            For i As Integer = 0 To state.VelocitySliders.Length - 1
                If focuesTextBox IsNot Nothing Then
                    Dim val As Integer = state.VelocitySliders(i)
                    If val > 0 Then focuesTextBox.Text = "VSlider " & i & " +"
                    If val < 0 Then focuesTextBox.Text = "VSlider " & i & " -"
                End If
            Next

            If focuesTextBox IsNot Nothing Then
                If state.X > 0 Then focuesTextBox.Text = "X +"
                If state.X < 0 Then focuesTextBox.Text = "X -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.Y > 0 Then focuesTextBox.Text = "Y +"
                If state.Y < 0 Then focuesTextBox.Text = "Y -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.Z > 0 Then focuesTextBox.Text = "Z +"
                If state.Z < 0 Then focuesTextBox.Text = "Z -"
            End If

            If focuesTextBox IsNot Nothing Then
                If state.AccelerationX > 0 Then focuesTextBox.Text = "AX +"
                If state.AccelerationX < 0 Then focuesTextBox.Text = "AX -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.AccelerationY > 0 Then focuesTextBox.Text = "AY +"
                If state.AccelerationY < 0 Then focuesTextBox.Text = "AY -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.AccelerationZ > 0 Then focuesTextBox.Text = "AZ +"
                If state.AccelerationZ < 0 Then focuesTextBox.Text = "AZ -"
            End If

            If focuesTextBox IsNot Nothing Then
                If state.AngularAccelerationX > 0 Then focuesTextBox.Text = "AAX +"
                If state.AngularAccelerationX < 0 Then focuesTextBox.Text = "AAX -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.AngularAccelerationY > 0 Then focuesTextBox.Text = "AAY +"
                If state.AngularAccelerationY < 0 Then focuesTextBox.Text = "AAY -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.AngularAccelerationZ > 0 Then focuesTextBox.Text = "AAZ +"
                If state.AngularAccelerationZ < 0 Then focuesTextBox.Text = "AAZ -"
            End If

            If focuesTextBox IsNot Nothing Then
                If state.ForceX > 0 Then focuesTextBox.Text = "FX +"
                If state.ForceX < 0 Then focuesTextBox.Text = "FX -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.ForceY > 0 Then focuesTextBox.Text = "FY +"
                If state.ForceY < 0 Then focuesTextBox.Text = "FY -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.ForceZ > 0 Then focuesTextBox.Text = "FZ +"
                If state.ForceZ < 0 Then focuesTextBox.Text = "FZ -"
            End If

            If focuesTextBox IsNot Nothing Then
                If state.RotationX > 0 Then focuesTextBox.Text = "RX +"
                If state.RotationX < 0 Then focuesTextBox.Text = "RX -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.RotationY > 0 Then focuesTextBox.Text = "RY +"
                If state.RotationY < 0 Then focuesTextBox.Text = "RY -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.RotationZ > 0 Then focuesTextBox.Text = "RZ +"
                If state.RotationZ < 0 Then focuesTextBox.Text = "RZ -"
            End If

            If focuesTextBox IsNot Nothing Then
                If state.TorqueX > 0 Then focuesTextBox.Text = "TX +"
                If state.TorqueX < 0 Then focuesTextBox.Text = "TX -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.TorqueY > 0 Then focuesTextBox.Text = "TY +"
                If state.TorqueY < 0 Then focuesTextBox.Text = "TY -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.TorqueZ > 0 Then focuesTextBox.Text = "TZ +"
                If state.TorqueZ < 0 Then focuesTextBox.Text = "TZ -"
            End If

            If focuesTextBox IsNot Nothing Then
                If state.VelocityX > 0 Then focuesTextBox.Text = "VX +"
                If state.VelocityX < 0 Then focuesTextBox.Text = "VX -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.VelocityY > 0 Then focuesTextBox.Text = "VY +"
                If state.VelocityY < 0 Then focuesTextBox.Text = "VY -"
            End If
            If focuesTextBox IsNot Nothing Then
                If state.VelocityZ > 0 Then focuesTextBox.Text = "VZ +"
                If state.VelocityZ < 0 Then focuesTextBox.Text = "VZ -"
            End If

        End If
    End Sub

    Private Sub LevelEditorInputManager_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Load Control Pads
        LoadPads()

        'Load Profile
        LoadProfile(Publics.MyDataPath & "\Area Editor\Controller Profile.json")
    End Sub

    Private Sub LoadPads()
        allDevices = DInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly).ToArray

        ComboBoxEx1.Items.Clear()
        For Each d As DeviceInstance In allDevices
            ComboBoxEx1.Items.Add(d.InstanceName)
        Next
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        Dim index = ComboBoxEx1.SelectedIndex
        If index < 0 Then Return
        curPad = New Joystick(DInput, allDevices(index).InstanceGuid)

        For Each doi As DeviceObjectInstance In curPad.GetObjects(DeviceObjectTypeFlags.Axis)
            curPad.GetObjectPropertiesById(doi.ObjectId).Range = New InputRange(-5000, 5000)
        Next

        curPad.Properties.AxisMode = DeviceAxisMode.Absolute
        curPad.SetCooperativeLevel(Me.Handle, CooperativeLevel.NonExclusive Or CooperativeLevel.Background)
        curPad.Acquire()

        If curProfile IsNot Nothing Then curProfile.ControllerInstanceGuid = allDevices(index).InstanceGuid
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        LoadPads()
    End Sub

    Public Shared Function LoadProfiles(path As String) As LevelEditorInputProfile()
        Dim profs As New List(Of LevelEditorInputProfile)

        For Each f As String In IO.Directory.GetFiles(path, "*.json")
            profs.Add(LevelEditorInputProfile.Load(f))
        Next

        Return profs.ToArray
    End Function

    Public Shared Function GetInputControlFromString(str As String) As InputControl
        Dim input As New InputControl

        Dim p() As String = str.Split(" ")

        Select Case p(0)
            Case "Button"
                input.InputKey = InputKeys.Buttons
                input.KeyIndex = p(1)

            Case "Point"
                input.InputKey = InputKeys.PointOfViewControllers
                input.KeyIndex = p(1)
                input.Value = p(2)

            Case "Slider"
                input.InputKey = InputKeys.Sliders
                input.KeyIndex = p(1)

            Case "ASlider"
                input.InputKey = InputKeys.AccelerationSliders
                input.KeyIndex = p(1)

            Case "FSlider"
                input.InputKey = InputKeys.ForceSliders
                input.KeyIndex = p(1)

            Case "VSlider"
                input.InputKey = InputKeys.VelocitySliders
                input.KeyIndex = p(1)

            Case "X"
                input.InputKey = InputKeys.X
                input.Value = p(1)
            Case "Y"
                input.InputKey = InputKeys.Y
                input.Value = p(1)
            Case "Z"
                input.InputKey = InputKeys.Z
                input.Value = p(1)

            Case "AX"
                input.InputKey = InputKeys.AccelerationX
                input.Value = p(1)
            Case "AY"
                input.InputKey = InputKeys.AccelerationY
                input.Value = p(1)
            Case "AZ"
                input.InputKey = InputKeys.AccelerationZ
                input.Value = p(1)

            Case "AAX"
                input.InputKey = InputKeys.AngularAccelerationX
                input.Value = p(1)
            Case "AAY"
                input.InputKey = InputKeys.AngularAccelerationY
                input.Value = p(1)
            Case "AAZ"
                input.InputKey = InputKeys.AngularAccelerationZ
                input.Value = p(1)

            Case "FX"
                input.InputKey = InputKeys.ForceX
                input.Value = p(1)
            Case "FY"
                input.InputKey = InputKeys.ForceY
                input.Value = p(1)
            Case "FZ"
                input.InputKey = InputKeys.ForceZ
                input.Value = p(1)

            Case "RX"
                input.InputKey = InputKeys.RotationX
                input.Value = p(1)
            Case "RY"
                input.InputKey = InputKeys.RotationY
                input.Value = p(1)
            Case "RZ"
                input.InputKey = InputKeys.RotationZ
                input.Value = p(1)

            Case "TX"
                input.InputKey = InputKeys.TorqueX
                input.Value = p(1)
            Case "TY"
                input.InputKey = InputKeys.TorqueY
                input.Value = p(1)
            Case "TZ"
                input.InputKey = InputKeys.TorqueZ
                input.Value = p(1)

            Case "VX"
                input.InputKey = InputKeys.VelocityX
                input.Value = p(1)
            Case "VY"
                input.InputKey = InputKeys.VelocityY
                input.Value = p(1)
            Case "VZ"
                input.InputKey = InputKeys.VelocityZ
                input.Value = p(1)
        End Select

        Return input
    End Function

    Public Shared Function GetStringFromInputControl(input As InputControl) As String
        Dim str As String = ""

        If input.InputKey Is Nothing AndAlso input.KeyIndex Is Nothing AndAlso input.Value Is Nothing Then Return ""

        Select Case input.InputKey
            Case InputKeys.Buttons
                Return $"Button {input.KeyIndex}"

            Case InputKeys.PointOfViewControllers
                Return $"Point {input.KeyIndex} {input.Value}"

            Case InputKeys.Sliders
                Return $"Slider {input.KeyIndex}"

            Case InputKeys.AccelerationSliders
                Return $"ASlider {input.KeyIndex}"

            Case InputKeys.ForceSliders
                Return $"FSlider {input.KeyIndex}"

            Case InputKeys.VelocitySliders
                Return $"VSlider {input.KeyIndex}"

            Case InputKeys.X
                Return $"X {input.Value}"
            Case InputKeys.Y
                Return $"Y {input.Value}"
            Case InputKeys.Z
                Return $"Z {input.Value}"

            Case InputKeys.AccelerationX
                Return $"AX {input.Value}"
            Case InputKeys.AccelerationY
                Return $"AY {input.Value}"
            Case InputKeys.AccelerationZ
                Return $"AZ {input.Value}"

            Case InputKeys.AngularAccelerationX
                Return $"AAX {input.Value}"
            Case InputKeys.AngularAccelerationY
                Return $"AAY {input.Value}"
            Case InputKeys.AngularAccelerationZ
                Return $"AAZ {input.Value}"

            Case InputKeys.ForceX
                Return $"FX {input.Value}"
            Case InputKeys.ForceY
                Return $"FY {input.Value}"
            Case InputKeys.ForceZ
                Return $"FZ {input.Value}"

            Case InputKeys.RotationX
                Return $"RX {input.Value}"
            Case InputKeys.RotationY
                Return $"RY {input.Value}"
            Case InputKeys.RotationZ
                Return $"RZ {input.Value}"

            Case InputKeys.TorqueX
                Return $"TX {input.Value}"
            Case InputKeys.TorqueY
                Return $"TY {input.Value}"
            Case InputKeys.TorqueZ
                Return $"TZ {input.Value}"

            Case InputKeys.VelocityX
                Return $"VX {input.Value}"
            Case InputKeys.VelocityY
                Return $"VY {input.Value}"
            Case InputKeys.VelocityZ
                Return $"VZ {input.Value}"

        End Select

        Return str
    End Function

    Private Sub TextBoxX_CamMoveLeft_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_CamMoveLeft.TextChanged
        If curProfile IsNot Nothing Then curProfile("CamMoveLeft") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_CamMoveRight_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_CamMoveRight.TextChanged
        If curProfile IsNot Nothing Then curProfile("CamMoveRight") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_CamMoveFordward_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_CamMoveFordward.TextChanged
        If curProfile IsNot Nothing Then curProfile("CamMoveFordward") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_CamMoveBackward_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_CamMoveBackward.TextChanged
        If curProfile IsNot Nothing Then curProfile("CamMoveBackward") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_CamMoveUp_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_CamMoveUp.TextChanged
        If curProfile IsNot Nothing Then curProfile("CamMoveUp") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_CamMoveDown_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_CamMoveDown.TextChanged
        If curProfile IsNot Nothing Then curProfile("CamMoveDown") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_ObjMoveLeft_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ObjMoveLeft.TextChanged
        If curProfile IsNot Nothing Then curProfile("ObjMoveLeft") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_ObjMoveRight_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ObjMoveRight.TextChanged
        If curProfile IsNot Nothing Then curProfile("ObjMoveRight") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_ObjMoveFordward_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ObjMoveFordward.TextChanged
        If curProfile IsNot Nothing Then curProfile("ObjMoveFordward") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_ObjMoveBackward_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ObjMoveBackward.TextChanged
        If curProfile IsNot Nothing Then curProfile("ObjMoveBackward") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_ObjMoveUp_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ObjMoveUp.TextChanged
        If curProfile IsNot Nothing Then curProfile("ObjMoveUp") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_ObjMoveDown_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ObjMoveDown.TextChanged
        If curProfile IsNot Nothing Then curProfile("ObjMoveDown") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_LastObj_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_LastObj.TextChanged
        If curProfile IsNot Nothing Then curProfile("LastObj") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_NextObj_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_NextObj.TextChanged
        If curProfile IsNot Nothing Then curProfile("NextObj") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_TopToGround_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_DropToGround.TextChanged
        If curProfile IsNot Nothing Then curProfile("DropToGround") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_LastArea_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_LastArea.TextChanged
        If curProfile IsNot Nothing Then curProfile("LastArea") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub TextBoxX_NextArea_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_NextArea.TextChanged
        If curProfile IsNot Nothing Then curProfile("NextArea") = GetInputControlFromString(sender.Text)
    End Sub

    Private Sub LoadProfile(fileName As String)
        Timer.Stop()
        curProfile = Nothing

        Dim p As LevelEditorInputProfile = If(fileName <> "" AndAlso IO.File.Exists(fileName), LevelEditorInputProfile.Load(fileName), New LevelEditorInputProfile)

        With p
            TextBoxX_CamMoveLeft.Text = GetStringFromInputControl(p("CamMoveLeft"))
            TextBoxX_CamMoveRight.Text = GetStringFromInputControl(p("CamMoveRight"))
            TextBoxX_CamMoveUp.Text = GetStringFromInputControl(p("CamMoveUp"))
            TextBoxX_CamMoveDown.Text = GetStringFromInputControl(p("CamMoveDown"))
            TextBoxX_CamMoveFordward.Text = GetStringFromInputControl(p("CamMoveFordward"))
            TextBoxX_CamMoveBackward.Text = GetStringFromInputControl(p("CamMoveBackward"))

            TextBoxX_ObjMoveLeft.Text = GetStringFromInputControl(p("ObjMoveLeft"))
            TextBoxX_ObjMoveRight.Text = GetStringFromInputControl(p("ObjMoveRight"))
            TextBoxX_ObjMoveUp.Text = GetStringFromInputControl(p("ObjMoveUp"))
            TextBoxX_ObjMoveDown.Text = GetStringFromInputControl(p("ObjMoveDown"))
            TextBoxX_ObjMoveFordward.Text = GetStringFromInputControl(p("ObjMoveFordward"))
            TextBoxX_ObjMoveBackward.Text = GetStringFromInputControl(p("ObjMoveBackward"))

            TextBoxX_LastObj.Text = GetStringFromInputControl(p("LastObj"))
            TextBoxX_NextObj.Text = GetStringFromInputControl(p("NextObj"))
            TextBoxX_DropToGround.Text = GetStringFromInputControl(p("DropToGround"))

            TextBoxX_LastArea.Text = GetStringFromInputControl(p("LastArea"))
            TextBoxX_NextArea.Text = GetStringFromInputControl(p("NextArea"))

            Try
                Dim tguid = allDevices.FirstOrDefault(Function(n) Publics.CompareTwoByteArrays(n.InstanceGuid.ToByteArray, p.ControllerInstanceGuid.ToByteArray))
                If tguid IsNot Nothing Then
                    ComboBoxEx1.SelectedIndex = Array.IndexOf(allDevices, tguid)
                End If
            Catch ex As Exception
            End Try
        End With

        Application.DoEvents()
        curProfile = p
    End Sub

    Private Sub LevelEditorInputManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Stop Timer
        Timer.Stop()

        'Save Profile
        curProfile.Save(Publics.MyDataPath & "\Area Editor\Controller Profile.json")
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        Dim sfd As New SaveFileDialog With {.Filter = "JSON Files (*.json)|*.json"}
        If sfd.ShowDialog = DialogResult.OK Then
            curProfile.Save(sfd.FileName)
        End If
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        Dim ofd As New OpenFileDialog With {.Filter = "JSON Files (*.json)|*.json"}
        If ofd.ShowDialog = DialogResult.OK Then
            LoadProfile(ofd.FileName)
        End If
    End Sub
End Class
