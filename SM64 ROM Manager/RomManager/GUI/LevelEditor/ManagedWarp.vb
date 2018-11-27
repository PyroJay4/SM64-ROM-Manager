Imports SM64Lib.Levels
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands
Imports System.ComponentModel

<DefaultProperty("WarpID")>
Public Class ManagedWarp
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

    <DisplayName("Warp ID")>
    <Category("Source")>
    <Description("The ID of this Warp.")>
    Public Property WarpID As Byte

    <DisplayName("Dest. Level")>
    <Category("Destination")>
    <Description("The Level where the player should came out.")>
    Public Property DestLevelID As Levels

    <DisplayName("Dest. Area ID")>
    <Category("Destination")>
    <Description("The Area where the player should came out.")>
    Public Property DestAreaID As Byte

    <DisplayName("Dest. Warp ID")>
    <Category("Destination")>
    <Description("The Warp where the player should came out.")>
    Public Property DestWarpID As Byte

    <DisplayName("Create Checkpoint")>
    <Category("Destination")>
    <Description("The game will create a checkpoint when entering this warp. When the player re-enter this level after he died he will start on this warp.")>
    Public Property CreateCheckpoint As Boolean

    Public Sub New(cmd As LevelscriptCommand)
        Me._Command = cmd
        LoadProperties()
    End Sub

    Public Sub LoadProperties() Implements IManagedLevelscriptCommand.LoadProperties
        'Warp-ID
        WarpID = clWarp.GetWarpID(Command)

        'Destination Level-ID
        DestLevelID = clWarp.GetDestinationLevelID(Command)

        'Destination Area-ID
        DestAreaID = clWarp.GetDestinationAreaID(Command)

        'Destination Warp-ID
        DestWarpID = clWarp.GetDestinationWarpID(Command)

        'Create Checkpoint
        CreateCheckpoint = clWarp.GetCreateCheckpoint(Command)
    End Sub

    Public Sub SaveProperties() Implements IManagedLevelscriptCommand.SaveProperties
        SaveProperties(Command)
    End Sub

    Public Sub SaveProperties(Command As LevelscriptCommand) Implements IManagedLevelscriptCommand.SaveProperties
        'Warp-ID
        clWarp.SetWarpID(Command, WarpID)

        'Destination Level-ID
        clWarp.SetDestinationLevelID(Command, DestLevelID)

        'Destination Area-ID
        clWarp.SetDestinationAreaID(Command, DestAreaID)

        'Destination Warp-ID
        clWarp.SetDestinationWarpID(Command, DestWarpID)

        'Create Checkpoint
        clWarp.SetCreateCheckpoint(Command, CreateCheckpoint)
    End Sub

End Class
