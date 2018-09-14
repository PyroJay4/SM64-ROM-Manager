Imports System.Drawing
Imports System.Numerics
Imports OpenGLRenderer
Imports SM64Lib.General
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands
Imports System.ComponentModel
Imports System.Globalization
Imports SM64_ROM_Manager.TypeConverters

<DefaultProperty("AllActs")>
Public Class Managed3DObject
    Implements ICameraPoint
    Implements IManagedLevelscriptCommand

    <Browsable(False)>
    Public ReadOnly Property Command As LevelscriptCommand = Nothing Implements IManagedLevelscriptCommand.Command

    <Browsable(False)>
    Private myObjectCombos As ObjectComboList

    <[ReadOnly](True)>
    <Category("Address")>
    <DisplayName("Rom Address")>
    Public ReadOnly Property RomAddress As Integer
        Get
            Return Command.RomAddress
        End Get
    End Property

    <[ReadOnly](True)>
    <Category("Address")>
    <DisplayName("Bank Address")>
    Public ReadOnly Property BankAddress As Integer
        Get
            Return Command.BankAddress
        End Get
    End Property

    <DisplayName("Object Combo")>
    <Category("Object Combo")>
    <Description("Indicated the Combo of Model ID and Behvior ID.")>
    Public Property ObjectCombo As String
        Get
            Return myObjectCombos.GetObjectComboOfObject(Me).Name
        End Get
        Set(value As String)
            Dim oc As ObjectComboList.ObjectCombo = myObjectCombos.FirstOrDefault(Function(n) n.Name = value)
            ModelID = oc.ModelID
            BehaviorID = oc.BehaviorID
        End Set
    End Property

    <DisplayName("Act 1")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 1.")>
    Public Property Act1 As Boolean

    <DisplayName("Act 2")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 2.")>
    Public Property Act2 As Boolean

    <DisplayName("Act 3")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 3.")>
    Public Property Act3 As Boolean

    <DisplayName("Act 4")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 4.")>
    Public Property Act4 As Boolean

    <DisplayName("Act 5")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 5.")>
    Public Property Act5 As Boolean

    <DisplayName("Act 6")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 6.")>
    Public Property Act6 As Boolean

    <DisplayName("All Acts")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible always.")>
    Public Property AllActs As Boolean
        Get
            Return Act1 AndAlso Act2 AndAlso Act3 AndAlso Act4 AndAlso Act5 AndAlso Not Act6
        End Get
        Set(value As Boolean)
            Act1 = value
            Act2 = value
            Act3 = value
            Act4 = value
            Act5 = value
            Act6 = False
        End Set
    End Property

    <DisplayName("Model ID")>
    <Category("Model")>
    <Description("Indicates what Model the Object have.")>
    Public Property ModelID As Byte

    <DisplayName("Behavior Address")>
    <Category("Behavior")>
    <Description("Indicates the Behavior of the Object.")>
    Public Property BehaviorID As UInteger

    <DisplayName("Behavior Param 1")>
    <Category("Behavior")>
    <Description("The first parameter for the Behavior.")>
    Public Property BParam1 As Byte

    <DisplayName("Behavior Param 2")>
    <Category("Behavior")>
    <Description("The second parameter for the Behavior.")>
    Public Property BParam2 As Byte

    <DisplayName("Behavior Param 3")>
    <Category("Behavior")>
    <Description("The third parameter for the Behavior.")>
    Public Property BParam3 As Byte

    <DisplayName("Behavior Param 4")>
    <Category("Behavior")>
    <Description("The fourth parameter for the Behavior.")>
    Public Property BParam4 As Byte

    <Browsable(False)>
    Public Property IsSelected As Boolean = False

    '<DisplayName("Position")>
    '<Category("Position & Rotation")>
    '<Description("The position of the Object.")>
    '<TypeConverter(GetType(Vector3Converter))>
    <Browsable(False)>
    Public Property Position As Vector3 Implements ICameraPoint.Position

    '<DisplayName("Rotation")>
    '<Category("Position & Rotation")>
    '<Description("The rotation of the Object.")>
    '<TypeConverter(GetType(Vector3Converter))>
    <Browsable(False)>
    Public Property Rotation As Vector3 Implements ICameraPoint.Rotation

    <DisplayName("X Position")>
    <Category("Position")>
    <Description("The position on the X axis.")>
    Public Property PositionX As Int16
        Get
            Return Position.X
        End Get
        Set(value As Int16)
            Position = New Vector3(value, Position.Y, Position.Z)
        End Set
    End Property

    <DisplayName("Y Position")>
    <Category("Position")>
    <Description("The position on the Y axis.")>
    Public Property PositionY As Int16
        Get
            Return Position.Y
        End Get
        Set(value As Int16)
            Position = New Vector3(Position.X, value, Position.Z)
        End Set
    End Property

    <DisplayName("Z Position")>
    <Category("Position")>
    <Description("The position on the Z axis.")>
    Public Property PositionZ As Int16
        Get
            Return Position.Z
        End Get
        Set(value As Int16)
            Position = New Vector3(Position.X, Position.Y, value)
        End Set
    End Property

    <DisplayName("X Rotation")>
    <Category("Rotation")>
    <Description("The rotation on the X axis.")>
    Public Property RotationX As Int16
        Get
            Return Rotation.X
        End Get
        Set(value As Int16)
            Rotation = New Vector3(value, Rotation.Y, Rotation.Z)
        End Set
    End Property

    <DisplayName("Y Rotation")>
    <Category("Rotation")>
    <Description("The rotation on the Y axis.")>
    Public Property RotationY As Int16
        Get
            Return Rotation.Y
        End Get
        Set(value As Int16)
            Rotation = New Vector3(Rotation.X, value, Rotation.Z)
        End Set
    End Property

    <DisplayName("Z Rotation")>
    <Category("Rotation")>
    <Description("The rotation on the Z axis.")>
    Public Property RotationZ As Int16
        Get
            Return Rotation.Z
        End Get
        Set(value As Int16)
            Rotation = New Vector3(Rotation.X, Rotation.Y, value)
        End Set
    End Property

    Public Sub New(cmd As LevelscriptCommand, objComboList As ObjectComboList)
        Me._Command = cmd
        Me.myObjectCombos = objComboList
        LoadProperties()
    End Sub

    Public Sub LoadProperties() Implements IManagedLevelscriptCommand.LoadpProperties
        'Acts
        Dim acts() As Boolean = Bits.ByteToBoolArray(clNormal3DObject.GetActs(Command))
        Act1 = acts(7)
        Act2 = acts(6)
        Act3 = acts(5)
        Act4 = acts(4)
        Act5 = acts(3)
        Act6 = acts(2)

        'Position
        Position = clNormal3DObject.GetPosition(Command)

        'Rotation
        Rotation = clNormal3DObject.GetRotation(Command)

        'Model-ID
        ModelID = clNormal3DObject.GetModelID(Command)

        'Behavior-ID
        BehaviorID = clNormal3DObject.GetSegBehaviorAddr(Command)

        'B. Params
        Dim bParams As ObjBParams = clNormal3DObject.GetParams(Command)
        BParam1 = bParams.BParam1
        BParam2 = bParams.BParam2
        BParam3 = bParams.BParam3
        BParam4 = bParams.BParam4
    End Sub

    Public Sub SaveProperties() Implements IManagedLevelscriptCommand.SaveProperties
        SaveProperties(Command)
    End Sub

    Public Sub SaveProperties(Command As LevelscriptCommand) Implements IManagedLevelscriptCommand.SaveProperties
        'Acts
        Dim acts() As Boolean = {False, False, False, False, False, False, False, False}
        acts(7) = Act1
        acts(6) = Act2
        acts(5) = Act3
        acts(4) = Act4
        acts(3) = Act5
        acts(2) = Act6
        clNormal3DObject.SetActs(Command, Bits.ArrayToByte(acts))

        'Position
        clNormal3DObject.SetPosition(Command, Position)

        'Rotation
        clNormal3DObject.SetRotation(Command, Rotation)

        'Model-ID
        clNormal3DObject.SetModelID(Command, ModelID)

        'Behavior-ID
        clNormal3DObject.SetSegBehaviorAddr(Command, BehaviorID)

        'B. Params
        Dim bParams As New ObjBParams
        bParams.BParam1 = BParam1
        bParams.BParam2 = BParam2
        bParams.BParam3 = BParam3
        bParams.BParam4 = BParam4
        clNormal3DObject.SetParams(Command, bParams)
    End Sub

    Public Sub Draw(mode As RenderMode, Optional ModelRenderer As Renderer = Nothing, Optional col As Color? = Nothing, Optional DrawSolid As Boolean = False, Optional DrawBoundingBox As Boolean = True)
        Dim scale As Numerics.Vector3 = Numerics.Vector3.One
        If IsSelected Then scale = New Numerics.Vector3(1.001F, 1.001F, 1.001F)
        Dim rotation As New Numerics.Quaternion With {.X = Me.Rotation.X, .Y = Me.Rotation.Y, .Z = Me.Rotation.Z, .W = 1.0F}
        Dim position As New Numerics.Vector3(Me.Position.X, Me.Position.Y, Me.Position.Z)
        Dim boundOff As New Numerics.Vector3(25.0F, 25.0F, 25.0F)
        Dim colorToUse As Color = If(col IsNot Nothing, col, If(IsSelected, Color.Yellow, Color.Red))

        If ModelRenderer IsNot Nothing Then
            Dim md As S3DFileParser.ModelBoundaries = ModelRenderer.Model.GetBoundaries
            ModelRenderer.DrawModel(mode,
                                    New OpenTK.Vector3(Me.Position.X, Me.Position.Y, Me.Position.Z),
                                    New OpenTK.Quaternion(-Me.Rotation.X, Me.Rotation.Y, -Me.Rotation.Z),
                                    OpenTK.Vector3.One)

            If DrawBoundingBox Then
                If DrawSolid Then
                    BoundingBox.DrawSolid(scale, rotation, position,
                                 colorToUse,
                                 md.Upper + boundOff, md.Lower - boundOff)
                Else
                    BoundingBox.Draw(scale, rotation, position,
                             colorToUse,
                             md.Upper + boundOff, md.Lower - boundOff)
                End If
            End If

        ElseIf DrawBoundingBox Then
            If DrawSolid Then
                BoundingBox.DrawSolid(scale, rotation, position,
                    colorToUse,
                    New Numerics.Vector3(150.0F, 150.0F, 150.0F),
                    New Numerics.Vector3(-150.0F, -150.0F, -150.0F))
            Else
                BoundingBox.Draw(scale, rotation, position,
                    colorToUse,
                    New Numerics.Vector3(150.0F, 150.0F, 150.0F),
                    New Numerics.Vector3(-150.0F, -150.0F, -150.0F))
            End If
        End If
    End Sub

End Class
