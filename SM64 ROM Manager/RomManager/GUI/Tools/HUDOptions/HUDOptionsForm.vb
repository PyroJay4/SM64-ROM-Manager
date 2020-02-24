Imports System.IO
Imports SM64Lib
Imports SM64_ROM_Manager.Publics

Public Class HUDOptionsForm

    'F i e l d s

    Private ReadOnly hud As HUDOptions
    Private ReadOnly positionBlocks As New List(Of HUDOptionsBlock)

    'C o n s t r u c t o r

    Public Sub New(rommgr As RomManager)
        hud = New HUDOptions(rommgr)
        InitializeComponent()
        UpdateAmbientColors
    End Sub

    'F e a t u r e s

    Private Sub LoadBlocks()
        hud.LoadBlock(Path.Combine(MyDataPath, "Other\HUD Positions.json"))

        For Each b As HUDOptionsBlock In hud.Block.Childs
            LoadBlock(hud.Block, TabControlPanel_Positions)
        Next
    End Sub

    Private Sub LoadBlock(b As HUDOptionsBlock, targetControl As Control)
        Dim newControl As Control

        Select Case b.Type
            Case 0

            Case 1

            Case 2

            Case 3

            Case Else
                newControl = targetControl
        End Select

        For Each bb As HUDOptionsBlock In b.Childs
            LoadBlock(bb, newControl)
        Next
    End Sub

    'G U I

    Private Sub HUDOptionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBlocks()
    End Sub

    Private Sub HUDOptionsForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

End Class
