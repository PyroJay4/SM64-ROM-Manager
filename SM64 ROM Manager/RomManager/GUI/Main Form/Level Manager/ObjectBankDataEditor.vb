Imports DevComponents.AdvTree
Imports SM64Lib.ObjectBanks.Data
Imports SM64Lib.Script

Public Class ObjectBankDataEditor

    'F i e l d s

    'A u t o m a t i c   P r o p e r t i e s

    Public ReadOnly Property ObdListCollection As ObjectBankDataListCollection

    'C o n s t r u c t o r

    Public Sub New(obdListCollection As ObjectBankDataListCollection)
        Me.ObdListCollection = obdListCollection

        'Create GUI
        InitializeComponent()
        UpdateAmbientColors
    End Sub

    'F e a t u r e s

    Private Sub BeginTreeUpdate()
        ObdTree.BeginUpdate()
    End Sub

    Private Sub EndTreeUpdate()
        ObdTree.EndUpdate()
    End Sub

    Private Function GetSelectedNode() As Node
        Return ObdTree.SelectedNode
    End Function

    Private Sub ListEverything()
        BeginTreeUpdate()
        ObdTree.Nodes.Clear()

        Dim nRoot As New Node With {
            .Text = "Object Bank Data Collection",
            .Name = "nRoot",
            .Tag = ObdListCollection
        }
        nRoot.Expand()

        For Each kvp As KeyValuePair(Of Byte, ObjectBankDataList) In ObdListCollection
            Dim nObdList As New Node With {
                .Text = TextFromValue(kvp.Key),
                .Tag = kvp,
                .ContextMenu = ButtonItem_CM_ObdList
            }

            'Data
            For Each obd As ObjectBankData In kvp.Value
                Dim nObd As Node = GetNodeFromObd(obd)
                nObdList.Nodes.Add(nObd)
            Next

            nObdList.Expand()
            nRoot.Nodes.Add(nObdList)
        Next

        ObdTree.Nodes.Add(nRoot)
        EndTreeUpdate()
    End Sub

    Private Sub AddObjsToNode(nObjs As Node, obd As ObjectBankData)
        For i As Integer = 0 To obd.Objects.Count - 1
            Dim name As String = obd.Objects(i)
            Dim nObj As Node = GetNodeFromObj(name, i, obd)
            nObjs.Nodes.Add(nObj)
        Next
    End Sub

    Private Sub AddCmdsToNode(nCmds As Node, obd As ObjectBankData)
        For Each cmd As ObjectBankDataCommand In obd.Commands
            Dim nCmd As Node = GetNodeFromCmd(cmd)
            nCmds.Nodes.Add(nCmd)
        Next
    End Sub

    Private Function GetNodeFromObd(obd As ObjectBankData) As Node
        Dim nObd As New Node With {
            .Text = obd.Name,
            .Tag = obd,
            .ContextMenu = ButtonItem_CM_Obd
        }

        'Object Names
        Dim nObjs As New Node With {
            .Text = "Objects",
            .Name = "nObjs",
            .ContextMenu = ButtonItem_CM_Objs,
            .Tag = obd
        }
        AddObjsToNode(nObjs, obd)
        nObd.Nodes.Add(nObjs)

        'Commands
        Dim nCmds As New Node With {
            .Text = "Commands",
            .Name = "nCmds",
            .ContextMenu = ButtonItem_CM_Cmds,
            .Tag = obd
        }
        AddCmdsToNode(nCmds, obd)
        nObd.Nodes.Add(nCmds)

        Return nObd
    End Function

    Private Function GetNodeFromObj(name As String, index As Integer, obd As ObjectBankData) As Node
        Dim nObj As New Node With {
            .Text = name,
            .Tag = {obd, index},
            .ContextMenu = ButtonItem_CM_Obj
        }
        Return nObj
    End Function

    Private Function GetNodeFromCmd(cmd As ObjectBankDataCommand) As Node
        Dim nCmd As New Node With {
            .Text = $"<font face=""Consolas"">{SM64Lib.CommandByteArrayToString(cmd.Command)}</font>",
            .Tag = cmd,
            .ContextMenu = ButtonItem_CM_Cmd
        }
        AddHandler nCmd.NodeDoubleClick, AddressOf CmdNodeDoubleClick
        Return nCmd
    End Function

    Private Sub RemoveObdList(nObdList As Node)
        Dim nRoot As Node = nObdList.Parent
        Dim kvp As KeyValuePair(Of Byte, ObjectBankDataList) = nObdList.Tag
        Dim obdListCollection As ObjectBankDataListCollection = nRoot.Tag

        'Remove list
        obdListCollection.Remove(kvp.Key)

        'Remove node
        BeginTreeUpdate()
        nRoot.Nodes.Remove(nObdList)
        EndTreeUpdate()
    End Sub

    Private Sub AddObd(nObdList As Node)
        Dim input As New ValueInputDialog
        input.ValueTextBox.Text = "New Object Bank Data"

        If input.ShowDialog = DialogResult.OK Then
            Dim obdList As ObjectBankDataList = nObdList.Tag.Value
            Dim name As String = input.ValueTextBox.Text.Trim
            Dim obd As New ObjectBankData(name)
            Dim nObd As Node = GetNodeFromObd(obd)

            'Add object
            obdList.Add(obd)

            'Add node
            BeginTreeUpdate()
            nObdList.Nodes.Add(nObd)
            nObdList.Expand()
            EndTreeUpdate()
        End If
    End Sub

    Private Sub RemoveObd(nObd As Node)
        Dim nObdList As Node = nObd.Parent
        Dim kvp As KeyValuePair(Of Byte, ObjectBankDataList) = nObdList.Tag
        Dim obd As ObjectBankData = nObd.Tag

        'Remove list
        kvp.Value.Remove(obd)

        'Remove node
        BeginTreeUpdate()
        nObdList.Nodes.Remove(nObd)
        EndTreeUpdate()
    End Sub

    Private Sub AddObj(nObjs As Node)
        Dim input As New ValueInputDialog
        input.ValueTextBox.Text = "New Object"

        If input.ShowDialog = DialogResult.OK Then
            Dim obd As ObjectBankData = nObjs.Tag
            Dim name As String = input.ValueTextBox.Text.Trim
            Dim index As Integer = obd.Objects.Count
            Dim nObj As Node = GetNodeFromObj(name, index, obd)

            'Add object
            obd.Objects.Add(name)

            'Add node
            BeginTreeUpdate()
            nObjs.Nodes.Add(nObj)
            nObjs.Expand()
            EndTreeUpdate()
        End If
    End Sub

    Private Sub RemoveObj(nObj As Node)
        Dim nObjs As Node = nObj.Parent
        Dim arr As Object() = TryCast(nObj.Tag, Object())
        Dim obd As ObjectBankData = arr(0)
        Dim list As List(Of String) = obd.Objects
        Dim index As Integer = arr(1)

        'Remove from list
        list.RemoveAt(index)

        'Re-add object nodes
        BeginTreeUpdate()
        nObjs.Nodes.Clear()
        AddObjsToNode(nObjs, obd)
        EndTreeUpdate()
    End Sub

    Private Sub AddCmd(nCmds As Node)
        Dim cmdBuf As Byte() = New Byte() {}

        'Create new
        OpenHexEditor(cmdBuf)

        If cmdBuf?.Any Then
            Dim obd As ObjectBankData = nCmds.Tag
            Dim cmd As New ObjectBankDataCommand(cmdBuf)
            Dim nCmd As Node = GetNodeFromCmd(cmd)

            'Add cmd
            obd.Commands.Add(cmd)

            'Add node
            BeginTreeUpdate()
            nCmds.Nodes.Add(nCmd)
            nCmds.Expand()
            EndTreeUpdate()
        End If
    End Sub

    Private Sub EditCmd(n As Node)
        Dim cmd As ObjectBankDataCommand = n.Tag
        OpenHexEditor(cmd.Command)
        n.Text = $"<font face=""Consolas"">{SM64Lib.CommandByteArrayToString(cmd.Command)}</font>"
        ObdTree.Refresh()
    End Sub

    Private Sub RemoveCmd(nCmd As Node)
        Dim nCmds As Node = nCmd.Parent
        Dim obd As ObjectBankData = nCmds.Tag
        Dim cmd As ObjectBankDataCommand = nCmd.Tag

        'Remove Cmd
        obd.Commands.Remove(cmd)

        'Remove Node
        BeginTreeUpdate()
        nCmds.Nodes.Remove(nCmd)
        EndTreeUpdate()
    End Sub

    'G U I

    Private Sub ObjectBankDataEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListEverything()
    End Sub

    Private Sub ObdTree_BeforeCellEdit(sender As Object, e As CellEditEventArgs) Handles ObdTree.BeforeCellEdit
        Dim tag As Object = e.Cell.Tag

        If tag Is Nothing OrElse
            TypeOf tag Is ObjectBankDataCommand OrElse
            TypeOf tag Is KeyValuePair(Of Byte, ObjectBankDataList) OrElse
            {"nObjs", "nCmds"}.Contains(e.Cell.Name) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ObdTree_AfterCellEdit(sender As Object, e As CellEditEventArgs) Handles ObdTree.AfterCellEdit
        Dim tag As Object = e.Cell.Tag

        If TypeOf tag Is Object() Then
            Dim arr As Object() = tag
            If arr.Length = 2 AndAlso TypeOf arr(0) Is ObjectBankData AndAlso TypeOf arr(1) Is Integer Then
                Dim obd As ObjectBankData = arr(0)
                Dim index As Integer = arr(1)
                obd.Objects(index) = e.NewText.Trim
            End If
        ElseIf TypeOf tag Is ObjectBankData Then
            Dim obd As ObjectBankData = tag
            obd.Name = e.NewText.Trim
        End If
    End Sub

    Private Sub CmdNodeDoubleClick(sender As Node, e As EventArgs)
        EditCmd(sender)
    End Sub

    Private Sub ButtonItem_RemoveObj_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveObj.Click
        RemoveObj(GetSelectedNode)
    End Sub

    Private Sub ButtonItem_RemoveCmd_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveCmd.Click
        RemoveCmd(GetSelectedNode)
    End Sub

    Private Sub ButtonItem_RemoveObd_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveObd.Click
        RemoveObd(GetSelectedNode)
    End Sub

    Private Sub ButtonItem_RemoveObdList_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveObdList.Click
        RemoveObdList(GetSelectedNode)
    End Sub

    Private Sub ButtonItem_AddObj_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddObj.Click
        AddObj(GetSelectedNode)
    End Sub

    Private Sub ButtonItem_AddCmd_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddCmd.Click
        AddCmd(GetSelectedNode)
    End Sub

    Private Sub ButtonItem_AddObd_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddObd.Click
        AddObd(GetSelectedNode)
    End Sub

End Class
