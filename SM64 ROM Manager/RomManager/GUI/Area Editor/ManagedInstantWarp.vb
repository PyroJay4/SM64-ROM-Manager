Imports System.ComponentModel
Imports System.Numerics
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands

<DefaultProperty("CollisionType")>
Public Class ManagedInstantWarp
    Implements IManagedLevelscriptCommand

    <Browsable(False)>
    Public ReadOnly Property Command As LevelscriptCommand = Nothing Implements IManagedLevelscriptCommand.Command

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

    <DisplayName("Collision Type")>
    <Description("The Collision Type to use." & vbNewLine & "Basicly only collision types from 0x1B to 0x1E area allowed.")>
    <Category("Collision")>
    Public Property CollisionType As Byte = &H1B

    <DisplayName("Dest. Area ID")>
    <Description("The Area where the player should came out.")>
    <Category("Destination")>
    Public Property DestAreaID As Byte = 0

    <DisplayName("Amount on X Axis")>
    <Description("Teleports Mario by this amount on the X axis.")>
    <Category("Location")>
    Public Property AmountOnXAxis As Int16 = 0

    <DisplayName("Amount on Y Axis")>
    <Description("Teleports Mario by this amount on the y axis.")>
    <Category("Location")>
    Public Property AmountOnYAxis As Int16 = 0

    <DisplayName("Amount on Z Axis")>
    <Description("Teleports Mario by this amount on the z axis.")>
    <Category("Location")>
    Public Property AmountOnZAxis As Int16 = 0

    Public Sub New(cmd As LevelscriptCommand)
        Me._Command = cmd
        LoadpProperties()
    End Sub

    Public Sub LoadpProperties() Implements IManagedLevelscriptCommand.LoadpProperties
        'Collision Type
        CollisionType = clInstantWarp.GetCollisionType(Command)

        'Destination Area ID
        DestAreaID = clInstantWarp.GetAreaID(Command)

        'Position
        Dim loc As Vector3 = clInstantWarp.GetLocation(Command)
        AmountOnXAxis = loc.X
        AmountOnYAxis = loc.Y
        AmountOnZAxis = loc.Z
    End Sub

    Public Sub SaveProperties() Implements IManagedLevelscriptCommand.SaveProperties
        SaveProperties(Command)
    End Sub

    Public Sub SaveProperties(Command As LevelscriptCommand) Implements IManagedLevelscriptCommand.SaveProperties
        'Collision Type
        clInstantWarp.SetCollisionType(Command, CollisionType)

        'Destination Area ID
        clInstantWarp.SetAreaID(Command, DestAreaID)

        'Position
        Dim loc As New Vector3(AmountOnXAxis, AmountOnYAxis, AmountOnZAxis)
        clInstantWarp.SetLocation(Command, loc)
    End Sub

End Class

