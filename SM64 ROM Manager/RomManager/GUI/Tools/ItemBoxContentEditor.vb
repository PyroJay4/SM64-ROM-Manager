Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64_ROM_Manager.PropertyValueEditors
Imports SM64_ROM_Manager.SettingsManager
Imports TextValueConverter
Imports SM64Lib, SM64Lib.Objects
Imports DevComponents.AdvTree
Imports System.ComponentModel

Public Class ItemBoxContentEditor

    Private WithEvents PropertyTree As AdvTree
    Private ReadOnly bpMgr As AdvPropGrid_ObjectPropertiesHelper
    Private tblMgr As New ItemBoxContentManager
    Private ReadOnly romMgr As RomManager

    Public Sub New(rommgr As RomManager)
        InitializeComponent()
        Me.romMgr = rommgr
        PropertyTree = AdvPropertyGrid1.PropertyTree
        bpMgr = New AdvPropGrid_ObjectPropertiesHelper(AdvPropertyGrid1, ObjectCombos, NameOf(ItemBoxContentEntry.BehavAddress), "BParam")
    End Sub

    Private ReadOnly Property SelectedEntry As ItemBoxContentEntry
        Get
            If ListViewEx1.SelectedIndices.Count > 0 Then
                Return ListViewEx1.SelectedItems(0).Tag
            End If
            Return Nothing
        End Get
    End Property

    Private Sub AdvPropertyGrid1_PropertyTree_Paint(sender As Object, e As PaintEventArgs) Handles PropertyTree.Paint
        Dim obj As ItemBoxContentEntry = SelectedEntry
        If obj IsNot Nothing Then
            For i As Byte = 1 To 2
                Dim n As Node = AdvPropertyGrid1.GetPropertyNode($"BParam{i}")
                If n IsNot Nothing Then
                    If n.TagString = "" Then
                        Dim info As BehaviorInfoList.BehaviorInfo = BehaviorInfos.GetByBehaviorAddress(obj.BehavAddress)
                        Dim param As BehaviorInfoList.BParam = info?.GetValue($"BParam{i}")
                        If param IsNot Nothing Then
                            If param.Name <> "" Then
                                n.Text = param.Name
                                n.TagString = param.Name
                            End If
                        End If
                    ElseIf n.Tag <> n.Text Then
                        n.Text = n.Tag
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ItemBoxContentEditor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ButtonItem6.RaiseClick()
    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        tblMgr.Read(romMgr)
        LoadList()
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        tblMgr.ResetToOriginal(romMgr)
        LoadList()
    End Sub

    Private Sub ButtonItem_SaveRom_Click(sender As Object, e As EventArgs) Handles ButtonItem_SaveRom.Click
        tblMgr.Write(romMgr)
    End Sub

    Private Sub ListViewEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx1.SelectedIndexChanged
        Dim list As New List(Of ItemBoxContentEntry)
        For Each lvi As ListViewItem In ListViewEx1.SelectedItems
            If TypeOf lvi.Tag Is ItemBoxContentEntry Then
                list.Add(lvi.Tag)
            End If
        Next
        AdvPropertyGrid1.SuspendLayout()
        AdvPropertyGrid1.SelectedObjects = list.ToArray
        AdvPropertyGrid1.RefreshPropertyValues()
        AdvPropertyGrid1.ResumeLayout()
    End Sub

    Private Sub AdvPropertyGrid1_PropertyValueChanged(sender As Object, e As PropertyChangedEventArgs) Handles AdvPropertyGrid1.PropertyValueChanged
        For Each lvi As ListViewItem In ListViewEx1.SelectedItems
            UpdateLvi(lvi)
        Next
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        AddContent()
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        RemoveContent()
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        ImportContent()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        ExportContent()
    End Sub

#Region "Functions"

    Private Sub LoadList()
        ListViewEx1.SuspendLayout()
        ListViewEx1.Items.Clear()

        For Each content As ItemBoxContentEntry In tblMgr.ContentTable
            AddLviFromContent(content)
        Next

        ListViewEx1.ResumeLayout()
    End Sub

    Private Function AddLviFromContent(content As ItemBoxContentEntry) As ListViewItem
        Dim item As New ListViewItem With {.Tag = content}

        For i As Integer = item.SubItems.Count To 4
            item.SubItems.Add(New ListViewItem.ListViewSubItem)
        Next

        UpdateLvi(item)

        ListViewEx1.Items.Add(item)

        Return item
    End Function

    Public Sub UpdateLvi(lvi As ListViewItem)
        If TypeOf lvi.Tag Is ItemBoxContentEntry Then
            Dim content As ItemBoxContentEntry = lvi.Tag
            lvi.SubItems(0).Text = content.ID
            lvi.SubItems(1).Text = content.ModelID
            lvi.SubItems(2).Text = content.BehavAddress
            lvi.SubItems(3).Text = content.BParam1
            lvi.SubItems(4).Text = content.BParam2
        End If
    End Sub

    Private Sub SelectLvis(items As ListViewItem())
        ListViewEx1.SuspendLayout()
        For Each item As ListViewItem In ListViewEx1.Items
            item.Selected = items.Contains(item)
        Next
        ListViewEx1.ResumeLayout()
    End Sub

    Private Sub AddContent()
        Dim content As New ItemBoxContentEntry With {.ID = tblMgr.ContentTable.Count}
        tblMgr.ContentTable.Add(content)
        Dim lvi As ListViewItem = AddLviFromContent(content)
        SelectLvis({lvi})
    End Sub

    Private Sub RemoveContent()
        Dim items = ListViewEx1.SelectedItems
        For Each lvi As ListViewItem In items
            If TypeOf lvi.Tag Is ItemBoxContentEntry Then
                tblMgr.ContentTable.Remove(lvi.Tag)
            End If
            ListViewEx1.Items.Remove(lvi)
        Next
    End Sub

    Private Sub ImportContent()
        Dim ofd As New OpenFileDialog With {.Filter = GetOpenFileDialogFilter()}
        If ofd.ShowDialog Then
            tblMgr.Read(ofd.FileName)
            LoadList()
        End If
    End Sub

    Private Sub ExportContent()
        Dim sfd As New SaveFileDialog With {.Filter = GetSaveFileDialogFilter()}
        If sfd.ShowDialog = DialogResult.OK Then
            tblMgr.Write(sfd.FileName)
        End If
    End Sub

    Private Function GetOpenFileDialogFilter() As String
        Return "Itembox Content Files (*.ibc, *.txt)|*.ibc;*.txt|SM64 ROM Manager Format (*.ibc)|*.ibc|SM64 Editor Format (*.txt)|*.txt|All files (*)|*"
    End Function

    Private Function GetSaveFileDialogFilter() As String
        Return "Itembox Content File (SM64 ROM Manager Format) (*.ibc)|*.ibc|Itembox Content File (SM64 Editor Format) (*.txt)|*.txt|All files (*)|*"
    End Function

#End Region

End Class
