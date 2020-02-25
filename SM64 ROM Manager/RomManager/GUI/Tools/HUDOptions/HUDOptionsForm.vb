Imports System.IO
Imports SM64Lib
Imports SM64_ROM_Manager.Publics
Imports DevComponents.DotNetBar
Imports DevComponents.AdvTree
Imports Newtonsoft.Json.Linq
Imports SM64_ROM_Manager.My.Resources

Public Class HUDOptionsForm

    'C o n s t a n t s

    Private Const FILTER_HUDPOSITIONS As String = "HUD-Positions (*.json)|*.json"

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

        Invoke(
            Sub()
                AdvTree1.BeginUpdate()
                AdvTree1.Nodes.Clear()
            End Sub)

        LoadBlock(hud.Block, AdvTree1.Nodes)

        Invoke(
            Sub()
                AdvTree1.ExpandAll()
                AdvTree1.EndUpdate()
            End Sub)
    End Sub

    Private Sub LoadBlock(b As HUDOptionsBlock, parentCollection As NodeCollection)
        Dim n As New Node With {
            .Text = HUDOptionsLangRes.ResourceManager.GetString("HUDPos_" & b.Name),
            .Tag = b
        }
        Invoke(Sub() parentCollection.Add(n))

        If b.Childs IsNot Nothing Then
            For Each bb As HUDOptionsBlock In b.Childs
                LoadBlock(bb, n.Nodes)
            Next
        End If
    End Sub

    Private Function GetSelectedBlock() As HUDOptionsBlock
        Return AdvTree1.SelectedNode?.Tag
    End Function

    Private Sub LoadPosition(b As HUDOptionsBlock)
        If b IsNot Nothing Then
            hud.OpenRomRead()
            Dim pos As Point = hud.GetPosition(b)
            hud.CloseRom()

            Invoke(
                Sub()
                    IntegerInput_PosX.Value = pos.X
                    IntegerInput_PosY.Value = pos.Y
                End Sub)
        End If
    End Sub

    Private Sub SavePosition(b As HUDOptionsBlock)
        If b IsNot Nothing Then
            hud.OpenRomWrite()
            hud.SetPosition(b, New Point(IntegerInput_PosX.Value, IntegerInput_PosY.Value))
            hud.CloseRom()
        End If
    End Sub

    Private Sub ExportToFile(filePath As String)
        Dim dicValues As New Dictionary(Of String, Point)
        Dim addBlock As Action(Of HUDOptionsBlock)

        addBlock =
            Sub(block As HUDOptionsBlock)
                If block.Cords IsNot Nothing Then
                    dicValues.Add(block.Name, hud.GetPosition(block))
                End If

                If block.Childs IsNot Nothing Then
                    For Each b As HUDOptionsBlock In block.Childs
                        addBlock(b)
                    Next
                End If
            End Sub

        hud.OpenRomRead()
        addBlock(hud.Block)
        hud.CloseRom()

        File.WriteAllText(filePath, JObject.FromObject(dicValues).ToString)
    End Sub

    Private Sub ImportFromFile(filePath As String)
        Dim dicValues = JObject.Parse(File.ReadAllText(filePath)).ToObject(Of Dictionary(Of String, Point))
        Dim readBlock As Action(Of HUDOptionsBlock)

        readBlock =
            Sub(block As HUDOptionsBlock)
                If block.Cords IsNot Nothing AndAlso dicValues.ContainsKey(block.Name) Then
                    hud.SetPosition(block, dicValues(block.Name))
                End If

                If block.Childs IsNot Nothing Then
                    For Each b As HUDOptionsBlock In block.Childs
                        readBlock(b)
                    Next
                End If
            End Sub

        hud.OpenRomWrite()
        readBlock(hud.Block)
        hud.CloseRom()

        LoadPosition(GetSelectedBlock)
    End Sub

    'G U I

    Private Sub HUDOptionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Task.Run(Sub() LoadBlocks())
    End Sub

    Private Sub AdvTree1_AfterNodeSelect(sender As Object, e As AdvTreeNodeEventArgs) Handles AdvTree1.AfterNodeSelect
        Task.Run(Sub() LoadPosition(e.Node.Tag))
    End Sub

    Private Sub ButtonX_RestorePosition_Click(sender As Object, e As EventArgs) Handles ButtonX_RestorePosition.Click
        Task.Run(Sub() LoadPosition(GetSelectedBlock))
    End Sub

    Private Sub ButtonX_SavePosition_Click(sender As Object, e As EventArgs) Handles ButtonX_SavePosition.Click
        Task.Run(Sub() SavePosition(GetSelectedBlock))
    End Sub

    Private Sub ButtonItem_ExportPosToFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportPosToFile.Click
        Dim sfd_exporthudpos As New SaveFileDialog With {
            .Filter = FILTER_HUDPOSITIONS
        }

        If sfd_exporthudpos.ShowDialog = DialogResult.OK Then
            Task.Run(Sub() ExportToFile(sfd_exporthudpos.FileName))
        End If
    End Sub

    Private Sub ButtonItem_ImportPosFromFile_Click(sender As Object, e As EventArgs) Handles ButtonItem_ImportPosFromFile.Click
        Dim ofd_importhudpos As New OpenFileDialog With {
            .Filter = FILTER_HUDPOSITIONS
        }

        If ofd_importhudpos.ShowDialog = DialogResult.OK Then
            Task.Run(Sub() ImportFromFile(ofd_importhudpos.FileName))
        End If
    End Sub

End Class
