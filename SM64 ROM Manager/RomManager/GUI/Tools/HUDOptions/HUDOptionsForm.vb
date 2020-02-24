Imports System.IO
Imports SM64Lib
Imports SM64_ROM_Manager.Publics
Imports DevComponents.DotNetBar
Imports DevComponents.AdvTree

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

        AdvTree1.BeginUpdate()
        AdvTree1.Nodes.Clear()

        LoadBlock(hud.Block, AdvTree1.Nodes)

        AdvTree1.ExpandAll()
        AdvTree1.EndUpdate()
    End Sub

    Private Sub LoadBlock(b As HUDOptionsBlock, parentCollection As NodeCollection)
        Dim n As New Node With {
            .Text = b.Name,
            .Tag = b
        }
        parentCollection.Add(n)

        If b.Childs IsNot Nothing Then
            For Each bb As HUDOptionsBlock In b.Childs
                LoadBlock(bb, n.Nodes)
            Next
        End If
    End Sub

    Private Sub LoadPosition(b As HUDOptionsBlock)
        hud.OpenRomRead()
        Dim pos As Point = hud.GetPosition(b)
        hud.CloseRom()

        IntegerInput1.Value = pos.X
        IntegerInput2.Value = pos.Y
    End Sub

    'G U I

    Private Sub HUDOptionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBlocks()
    End Sub

    Private Sub AdvTree1_AfterNodeSelect(sender As Object, e As AdvTreeNodeEventArgs) Handles AdvTree1.AfterNodeSelect
        LoadPosition(e.Node.Tag)
    End Sub

End Class
