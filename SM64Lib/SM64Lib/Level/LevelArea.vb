﻿Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Windows.Forms
Imports SM64Lib.Levels.ScrolTex
Imports SM64Lib.ObjectBanks
Imports SM64Lib.SegmentedBanking

Namespace Levels

    Public MustInherit Class LevelArea

        'S h a r e d   M e m b e r s

        Public Shared ReadOnly DefaultNormal3DObject() As Byte = {&H24, &H18, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H13, &H0, &H0, &H0}

        'F i e l d s

        Protected _GettingAreaCollision As Boolean = False

        'A u t o   P r o p e r t i e s

        Public ReadOnly Property SpecialBoxes As New SpecialBoxList
        Public ReadOnly Property ScrollingTextures As New List(Of ManagedScrollingTexture)
        Public ReadOnly Property Objects As New List(Of LevelscriptCommand)
        Public ReadOnly Property MacroObjects As New List(Of LevelscriptCommand)
        Public ReadOnly Property Warps As New List(Of LevelscriptCommand)
        Public ReadOnly Property WarpsForGame As New List(Of LevelscriptCommand)
        Public ReadOnly Property ShowMessage As New ShowMessage
        Public ReadOnly Property Background As New AreaBG
        Public Property Levelscript As New LevelscriptCommandCollection
        Public Property Geolayout As New Geolayout.Geolayout(SM64Lib.Geolayout.Geolayout.NewScriptCreationMode.None)
        Public Property TerrainType As Geolayout.TerrainTypes = SM64Lib.Geolayout.TerrainTypes.NoramlA
        Public Property BGMusic As Byte = 0
        Public Property AreaID As Byte = 0
        Public Property GeolayoutOffset As UInteger = 0
        Public Property AreaModel As New ObjectModel
        Public Property Enable2DCamera As Boolean = False
        Public ReadOnly Property CustomObjects As New CustomObjectBank
        Public Property CustomObjectsStartOffset As Integer = 0
        Public Property Bank0x0EOffset As UInteger = 0
        Public Property Bank0xELength As Integer

        'O t h e r   P r o p e r t i e s

        Public ReadOnly Property HasCustomObjects As Boolean
            Get
                Return CustomObjects.Objects.Any
            End Get
        End Property

        Public ReadOnly Property Fast3DBankRomStart As Integer
            Get
                Return Bank0x0EOffset
            End Get
        End Property

        Public ReadOnly Property Fast3DLength As Integer
            Get
                Return CollisionPointer - &HE000000
            End Get
        End Property

        Public ReadOnly Property IsCamera2D As Boolean
            Get
                Return Enable2DCamera AndAlso Geolayout.CameraPreset = SM64Lib.Geolayout.CameraPresets.PlattfromLevels
            End Get
        End Property

        Public Property CollisionPointer As Integer
            Get
                _GettingAreaCollision = True
                For Each cmd In Levelscript
                    If cmd.CommandType = LevelscriptCommandTypes.AreaCollision Then
                        CollisionPointer = clAreaCollision.GetAreaCollision(cmd)
                    End If
                Next
                _GettingAreaCollision = False
                Return CollisionPointer
            End Get
            Set(value As Integer)
                If _GettingAreaCollision Then Return
                For Each cmd In Levelscript
                    If cmd.CommandType = LevelscriptCommandTypes.AreaCollision Then
                        clAreaCollision.SetAreaCollision(cmd, value)
                    End If
                Next
            End Set
        End Property

        'M e t h o d s

        Public Sub SetSegmentedBanks(rommgr As RomManager)
            Dim bank0xE As SegmentedBank = rommgr.SetSegBank(&HE, Bank0x0EOffset, Bank0x0EOffset + Bank0xELength, AreaID)
            bank0xE.Data = AreaModel.Fast3DBuffer
        End Sub

        Friend Sub UpdateScrollingTextureVertexPointer(offset As Integer)
            For Each scrollText As ManagedScrollingTexture In ScrollingTextures
                scrollText.VertexPointer += offset
            Next
        End Sub

        Public Sub Close()
            Levelscript.Close()
            Geolayout.Close()
        End Sub

        'C o n s t r u c t o r s

        Protected Sub New(AreaID As Byte)
            Me.New(AreaID, 9)
        End Sub

        Protected Sub New(AreaID As Byte, LevelID As Byte)
            Me.New(AreaID, LevelID, True, True)
        End Sub

        Protected Sub New(AreaID As Byte, LevelID As Byte, AddWarps As Boolean, AddObjects As Boolean)
            Geolayout = New Geolayout.Geolayout(SM64Lib.Geolayout.Geolayout.NewScriptCreationMode.Level)
            Me.AreaID = AreaID

            With Levelscript
                .Add(New LevelscriptCommand({&H1F, &H8, AreaID, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H2E, &H8, &H0, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H36, &H8, &H0, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H31, &H4, &H0, &H2}))
                .Add(New LevelscriptCommand({&H20, &H4, &H0, &H0}))
            End With

            If AddWarps Then
                Objects.Add(New LevelscriptCommand({&H24, &H18, &H1F, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &HA, &H0, &H0, &H13, &H0, &H2F, &H74}))
                Warps.Add(New LevelscriptCommand({&H26, &H8, &HA, LevelID, AreaID, &H0, &H0, &H0}))
                WarpsForGame.Add(New LevelscriptCommand({&H26, &H8, &HF0, &H6, &H1, &H32, &H0, &H0}))
                WarpsForGame.Add(New LevelscriptCommand({&H26, &H8, &HF1, &H6, &H1, &H64, &H0, &H0}))
            End If

            If AddObjects Then
                For i As Integer = 1 To 15
                    Dim newObj As New LevelscriptCommand(DefaultNormal3DObject)
                    Objects.Add(newObj)
                Next
            End If
        End Sub

        Protected Sub New()
            Geolayout = New Geolayout.Geolayout(SM64Lib.Geolayout.Geolayout.NewScriptCreationMode.Level)
        End Sub

    End Class

End Namespace