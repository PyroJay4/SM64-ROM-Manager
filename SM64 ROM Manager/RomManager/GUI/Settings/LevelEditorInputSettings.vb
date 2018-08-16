Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SharpDX.DirectInput

Partial Class LevelEditorInputManager

    <Serializable>
    Public Class LevelEditorInputProfile

        'Public Property ProfileName As String
        Public ReadOnly Property Controls As New Dictionary(Of String, InputControl)

        Private _ControllerInstanceGuid As Byte() = {}
        Public Property ControllerInstanceGuid As Guid
            Get
                If _ControllerInstanceGuid.Count = 0 Then Return Nothing
                Return New Guid(_ControllerInstanceGuid)
            End Get
            Set(value As Guid)
                _ControllerInstanceGuid = value.ToByteArray
            End Set
        End Property

        Default Public Property Control(name As String) As InputControl
            Get
                If Not Controls.ContainsKey(name) Then
                    Controls.Add(name, New InputControl)
                End If
                Return Controls(name)
            End Get
            Set(value As InputControl)
                If Not Controls.ContainsKey(name) Then
                    Controls.Add(name, value)
                Else
                    Controls(name) = value
                End If
            End Set
        End Property

        Public Sub ClearProfile()
            Controls.Clear()
        End Sub

        Public Sub Save(fileName As String)
            IO.File.WriteAllText(fileName, JsonConvert.SerializeObject(Me))
        End Sub
        Shared Function Load(fileName As String) As LevelEditorInputProfile
            Return JsonConvert.DeserializeObject(Of LevelEditorInputProfile)(IO.File.ReadAllText(fileName))
        End Function
    End Class

    <Serializable>
    Public Class InputControl
        Public Property InputKey As InputKeys? = Nothing
        Public Property KeyIndex As Integer? = Nothing
        Public Property Value As Object = Nothing
    End Class

    <Serializable>
    Public Enum ControllerTypes As Byte
        Keyboard
        DirectInput
    End Enum

    <Serializable>
    Public Enum InputKeys As Byte
        'Uses Index

        Buttons                 'Button index       'Default: False
        AccelerationSliders     'ASlider index      'Default: 0
        ForceSliders            'FSlider index      'Default: 0
        PointOfViewControllers  'Point index        'Default: -1
        Sliders                 'Slider index       'Default: 0
        VelocitySliders         'VSlider index      'Default: 0

        'Don't uses Index

        AccelerationX           'AX                 'Default: 0
        AccelerationY           'AY                 'Default: 0
        AccelerationZ           'AZ                 'Default: 0

        AngularAccelerationX    'AAX                'Default: 0
        AngularAccelerationY    'AAY                'Default: 0
        AngularAccelerationZ    'AAZ                'Default: 0

        ForceX                  'FX                 'Default: 0
        ForceY                  'FY                 'Default: 0
        ForceZ                  'FZ                 'Default: 0

        RotationX               'RX                 'Default: 0
        RotationY               'RY                 'Default: 0
        RotationZ               'RZ                 'Default: 0

        TorqueX                 'TX                 'Default: 0
        TorqueY                 'TY                 'Default: 0
        TorqueZ                 'TZ                 'Default: 0

        VelocityX               'VX                 'Default: 0
        VelocityY               'VY                 'Default: 0
        VelocityZ               'VZ                 'Default: 0

        X                       'X                  'Default: 0
        Y                       'Y                  'Default: 0
        Z                       'Z                  'Default: 0
    End Enum
End Class
