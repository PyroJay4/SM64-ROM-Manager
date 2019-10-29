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
        InitializeComponent()
        UpdateAmbientColors
    End Sub

    'F e a t u r e s

    Private Sub ListEverything()
        ObdTree.BeginUpdate()
        ObdTree.Nodes.Clear()

        For Each kvp As KeyValuePair(Of Byte, ObjectBankDataList) In ObdListCollection
            Dim nTop As New Node With {
                .Text = TextFromValue(kvp.Key),
                .Tag = kvp
            }

            'Data
            For Each obd As ObjectBankData In kvp.Value
                Dim nObd As New Node With {
                    .Text = obd.Name,
                    .Tag = obd
                }

                'Object Names
                Dim nObjs As New Node With {
                    .Text = "Objects",
                    .Name = "nObjs"
                }
                For i As Integer = 0 To obd.Objects.Count - 1
                    Dim name As String = obd.Objects(i)
                    Dim nObj As New Node With {
                        .Text = name,
                        .Tag = {obd.Objects, i}
                    }
                    nObjs.Nodes.Add(nObj)
                Next
                nObd.Nodes.Add(nObjs)

                'Commands
                Dim nCmds As New Node With {
                    .Text = "Commands",
                    .Name = "nCmds"
                }
                For Each cmd As ObjectBankDataCommand In obd.Commands
                    Dim nCmd As New Node With {
                        .Text = $"<font face=""Consolas"">{SM64Lib.CommandByteArrayToString(cmd.Command)}</font>",
                        .Tag = cmd
                    }
                    nCmds.Nodes.Add(nCmd)
                Next
                nObd.Nodes.Add(nCmds)

                nTop.Nodes.Add(nObd)
            Next

            ObdTree.Nodes.Add(nTop)
        Next

        ObdTree.EndUpdate()
    End Sub

    'G U I

    Private Sub ObjectBankDataEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListEverything()
    End Sub

    Private Sub ObdTree_BeforeCellEdit(sender As Object, e As CellEditEventArgs) Handles ObdTree.BeforeCellEdit
        Dim tag As Object = e.Cell.Tag

        If tag Is Nothing Then
            e.Cancel = True
        ElseIf TypeOf tag Is ObjectBankDataCommand Then
            e.Cancel = True
            Dim cmd As ObjectBankDataCommand = tag
            OpenHexEditor(cmd.Command)
            e.Cell.Text = $"<font face=""Consolas"">{SM64Lib.CommandByteArrayToString(cmd.Command)}</font>"
            ObdTree.Refresh()
        ElseIf TypeOf tag Is KeyValuePair(Of Byte, ObjectBankDataList) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ObdTree_AfterCellEdit(sender As Object, e As CellEditEventArgs) Handles ObdTree.AfterCellEdit
        Dim tag As Object = e.Cell.Tag

        If TypeOf tag Is Object() Then
            Dim arr As Object() = tag
            If arr.Length = 2 AndAlso TypeOf arr(0) Is List(Of String) AndAlso TypeOf arr(1) Is Integer Then
                Dim list As List(Of String) = arr(0)
                Dim index As Integer = arr(1)
                list(index) = e.NewText.Trim
            End If
        ElseIf TypeOf tag Is ObjectBankData Then
            Dim obd As ObjectBankData = tag
            obd.Name = e.NewText.Trim
        End If
    End Sub
End Class
