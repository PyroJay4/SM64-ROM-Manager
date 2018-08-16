Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Level.Script, SM64Lib.Level.Script.Commands
Imports N64Graphics
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Windows.Forms
Imports SM64Lib.Level.ScrolTex

Namespace Global.SM64Lib.Level

    Public Class LevelArea

        Public Shared ReadOnly DefaultNormal3DObject() As Byte = {&H24, &H18, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H13, &H0, &H0, &H0}
        Public Property Levelscript As New LevelscriptCommandCollection
        Public Property Geolayout As New Geolayout.Geolayout(False)
        Public Property TerrainType As Geolayout.TerrainTypes = SM64Lib.Geolayout.TerrainTypes.NoramlA
        Public Property BGMusic As Byte = 0
        Public Property AreaID As Byte = 0
        Public Property GeolayoutOffset As UInteger = 0
        Public Property ImportModel As Boolean = False
        Public Property ShouldImportModel As Boolean = False
        Public Property AreaModel As New AreaModel
        Public ReadOnly Property SpecialBoxes As New SpecialBoxList
        Public ReadOnly Property ScrollingTextures As New List(Of ManagedScrollingTexture)
        Public ReadOnly Property Objects As New List(Of LevelscriptCommand)
        Public ReadOnly Property MacroObjects As New List(Of LevelscriptCommand)
        Public ReadOnly Property Warps As New List(Of LevelscriptCommand)
        Public ReadOnly Property WarpsForGame As New List(Of LevelscriptCommand)
        Public ReadOnly Property ShowMessage As New ShowMessage
        Public ReadOnly Property Background As New AreaBG
        Public Property Enable2DCamera As Boolean = False
        Private _GettingAreaCollision As Boolean = False
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
        Public Property Bank0x0EOffset As UInteger = 0
        Public ReadOnly Property Bank0xELength As UInteger
            Get
                Return HexRoundUp1(AreaModel.Fast3DBuffer.Length + AreaModel.Collision.Length)
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

        Public Sub SetSegmentedBanks(rommgr As RomManager)
            Dim bank0xE As SegmentedBank = rommgr.SetSegBank(&HE, Bank0x0EOffset, Bank0x0EOffset + Bank0xELength, AreaID)
            bank0xE.Data = AreaModel.Fast3DBuffer
        End Sub

        Friend Sub UpdateScrollingTextureVertexPointer(offset As Integer)
            For Each scrollText As ManagedScrollingTexture In ScrollingTextures
                scrollText.VertexPointer += offset
            Next
        End Sub

        Public Sub New(AreaID As Byte, Optional LevelID As Byte = &H9)
            Geolayout = New Geolayout.Geolayout(True)
            Me.AreaID = AreaID
            ShouldImportModel = True
            With Levelscript
                .Add(New LevelscriptCommand({&H1F, &H8, AreaID, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H2E, &H8, &H0, &H0, &H0, &H0, &H0, &H0}))
                '.Add(New LevelscriptCommand({&H30, &H4, &H0, &H0}))
                .Add(New LevelscriptCommand({&H36, &H8, &H0, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H31, &H4, &H0, &H2}))
                .Add(New LevelscriptCommand({&H20, &H4, &H0, &H0}))
            End With
            Objects.Add(New LevelscriptCommand({&H24, &H18, &H1F, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &HA, &H0, &H0, &H13, &H0, &H2F, &H74}))
            Warps.Add(New LevelscriptCommand({&H26, &H8, &HA, LevelID, AreaID, &H0, &H0, &H0}))
            WarpsForGame.Add(New LevelscriptCommand({&H26, &H8, &HF0, &H6, &H1, &H32, &H0, &H0}))
            WarpsForGame.Add(New LevelscriptCommand({&H26, &H8, &HF1, &H6, &H1, &H64, &H0, &H0}))

            For i As Integer = 1 To 15
                Dim newObj As New LevelscriptCommand(DefaultNormal3DObject)
                Objects.Add(newObj)
            Next
        End Sub

        Public Sub New()
            Geolayout = New Geolayout.Geolayout(True)
        End Sub

        Public Sub Close()
            Levelscript.Close()
            Geolayout.Close()
        End Sub

    End Class

End Namespace