Imports System.ComponentModel
Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Imports SM64Lib.Text.Profiles
Imports SM64_ROM_Manager.My.Resources

Public Class TextProfileEditor

    'P R I V A T E   F I E L D S

    Private nTableGroups As New Node With {.Text = TextProfileEditorLangRes.nTableGroups}
    Private nArrayGroups As New Node With {.Text = TextProfileEditorLangRes.nArrayGroups}
    Private advPropGridMgr As MinimalAdvPropertyGridManager

    'A U T O M A T I C   P R O P E R T I E S

    Public Property ProfileInfo As TextProfileInfo

    'C O N S T R U C T O R S

    Public Sub New()
        InitializeComponent()
        advPropGridMgr = New MinimalAdvPropertyGridManager(AdvPropertyGrid1)
        AdvTree1.Nodes.AddRange({nTableGroups, nArrayGroups})
        UpdateAmbientColors
    End Sub

    'F E A T U R E S

    Private Sub LoadAllGroups()
        AdvTree1.SuspendLayout()

        nTableGroups.Nodes.Clear()
        nArrayGroups.Nodes.Clear()

        For Each tg As TextGroupInfo In ProfileInfo.AllGroups
            AddTextGroupInfoNode(tg)
        Next

        AdvTree1.ExpandAll()
        AdvTree1.ResumeLayout()
    End Sub

    Private Function AddTextGroupInfoNode(tg As TextGroupInfo) As Node
        Dim n As New Node With {
            .Text = tg.Name,
            .Tag = tg
        }

        If tg.IsTextTableGroupInfo Then
            nTableGroups.Nodes.Add(n)
        ElseIf tg.IsTextArrayGroupInfo Then
            nArrayGroups.Nodes.Add(n)
        End If

        Return n
    End Function

    Private Sub LoadGroup(group As TextGroupInfo)
        LoadPropertiesToEdit(group)
    End Sub

    Private Sub LoadArrayItem(item As TextArrayItemInfo)
        LoadPropertiesToEdit(item)
    End Sub

    Private Sub LoadPropertiesToEdit(obj As Object)
        AdvPropertyGrid1.SelectedObject = Nothing
        AdvPropertyGrid1.PropertySettings.Clear()

        If TypeOf obj Is TextGroupInfo Then

            Dim piEncodingString As New PropertySettings(NameOf(TextGroupInfo.EncodingString)) With {
                .DisplayName = "Encoding",
                .ValueEditor = New PropertyValueEditors.TextEncodingEditor({TextGroupInfo.ENCODING_STRING_M64, TextGroupInfo.ENCODING_STRING_ASCII})
            }
            AdvPropertyGrid1.PropertySettings.Add(piEncodingString)

            Dim piEncoding As New PropertySettings(NameOf(TextTableGroupInfo.Encoding)) With {
                    .Visible = False
                }
            AdvPropertyGrid1.PropertySettings.Add(piEncoding)

            If TypeOf obj Is TextTableGroupInfo Then

                Dim piData As New PropertySettings(NameOf(TextTableGroupInfo.Data)) With {
                    .TypeConverter = New ExpandableObjectConverter
                }
                AdvPropertyGrid1.PropertySettings.Add(piData)

                Dim piDialogData As New PropertySettings(NameOf(TextTableGroupInfo.DialogData)) With {
                    .TypeConverter = New ExpandableObjectConverter
                }
                AdvPropertyGrid1.PropertySettings.Add(piDialogData)

                Dim piSegmented As New PropertySettings(NameOf(TextTableGroupInfo.Segmented)) With {
                    .TypeConverter = New ExpandableObjectConverter
                }
                AdvPropertyGrid1.PropertySettings.Add(piSegmented)

                Dim piTableType As New PropertySettings(NameOf(TextTableGroupInfo.TableType)) With {
                    .Visible = False
                }
                AdvPropertyGrid1.PropertySettings.Add(piTableType)

            ElseIf TypeOf obj Is TextArrayGroupInfo Then

                Dim piTexts As New PropertySettings(NameOf(TextArrayGroupInfo.Texts)) With {
                    .Visible = False
                }
                AdvPropertyGrid1.PropertySettings.Add(piTexts)

            End If

            LoadTextArrayItems(obj)

        End If

        AdvPropertyGrid1.SelectedObject = obj
        AdvPropertyGrid1.ExpandAllGridItems()
    End Sub

    Private Sub LoadTextArrayItems(table As TextGroupInfo)
        ItemListBox1.SuspendLayout()
        ItemListBox1.Items.Clear()

        If TypeOf table Is TextArrayGroupInfo Then
            For Each item As TextArrayItemInfo In CType(table, TextArrayGroupInfo).Texts
                AddArrayItemListItem(item)
            Next
            AdvPropertyGrid1.Dock = DockStyle.Top
            Panel3.Visible = True
        Else
            Panel3.Visible = False
            AdvPropertyGrid1.Dock = DockStyle.Fill
        End If

        ItemListBox1.ResumeLayout()
        ItemListBox1.Refresh()
    End Sub

    Private Function AddArrayItemListItem(item As TextArrayItemInfo) As ButtonItem
        Dim btn As New ButtonItem With {
            .Text = item.RomAddress,
            .Tag = item
        }
        ItemListBox1.Items.Add(btn)
        Return btn
    End Function

    Private Function GetSelectedGroupInfo() As TextGroupInfo
        Return AdvTree1.SelectedNode?.Tag
    End Function

    Private Function GetSelectedArrayItemInfo() As TextArrayItemInfo
        If ItemListBox1.Visible Then
            Return ItemListBox1.SelectedItem?.Tag
        Else
            Return Nothing
        End If
    End Function

    Private Sub AddArrayGroupInfo()
        Dim tg As New TextArrayGroupInfo With {.Name = "New Array Group", .EncodingString = TextGroupInfo.ENCODING_STRING_M64}
        ProfileInfo.TextArrayGroups.Add(tg)
        AddGroupInfo(tg)
    End Sub

    Private Sub AddTableGroupInfo()
        Dim tg As New TextTableGroupInfo With {.Name = "New Table Group", .EncodingString = TextGroupInfo.ENCODING_STRING_M64}
        ProfileInfo.TextTableGroups.Add(tg)
        AddGroupInfo(tg)
    End Sub

    Private Sub AddGroupInfo(group As TextGroupInfo)
        Dim n As Node = AddTextGroupInfoNode(group)
        AdvTree1.SelectedNode = n
    End Sub

    Private Sub RemoveSelectedGroupInfo()
        Dim selNode As Node = AdvTree1.SelectedNode
        Dim group As TextGroupInfo = selNode?.Tag

        If group IsNot Nothing Then
            If TypeOf group Is TextTableGroupInfo Then
                nTableGroups.Nodes.Remove(selNode)
                ProfileInfo.TextTableGroups.Remove(group)
            ElseIf TypeOf group Is TextArrayGroupInfo Then
                nArrayGroups.Nodes.Remove(selNode)
                ProfileInfo.TextArrayGroups.Remove(group)
            End If
        End If
    End Sub

    Private Sub AddArrayItemInfo()
        Dim item As New TextArrayItemInfo
        Dim group As TextArrayGroupInfo = GetSelectedGroupInfo()
        group.Texts.Add(item)
        Dim btn As ButtonItem = AddArrayItemListItem(item)
        ItemListBox1.Items.Add(btn)
        ItemListBox1.Refresh()
    End Sub

    Private Sub RemoveSelectedArrayItemInfo()
        Dim item As BaseItem = ItemListBox1.SelectedItem

        If item?.Tag IsNot Nothing Then
            RemoveArrayItemInfo(item)
            ItemListBox1.Refresh()
        End If
    End Sub

    Private Sub RemoveAllArrayItemInfos()
        Dim items As BaseItem() = New BaseItem(ItemListBox1.Items.Count) {}
        ItemListBox1.Items.CopyTo(items, 0)

        ItemListBox1.SuspendLayout()

        For Each baseItem As BaseItem In items
            If baseItem?.Tag IsNot Nothing Then
                RemoveArrayItemInfo(baseItem)
            End If
        Next

        ItemListBox1.ResumeLayout()
        ItemListBox1.Refresh()
    End Sub

    Private Sub RemoveArrayItemInfoListItem(item As BaseItem)
        ItemListBox1.Items.Remove(item)
    End Sub

    Private Sub RemoveArrayItemInfo(item As BaseItem)
        Dim tarrinfo As TextArrayItemInfo = item.Tag
        Dim group As TextArrayGroupInfo = GetSelectedGroupInfo()

        If group IsNot Nothing Then
            ItemListBox1.Items.Remove(item)
            group.Texts.Remove(tarrinfo)
        End If
    End Sub

    Private Sub UpdateSelectedTextGroupInfoNode()
        Dim n As Node = AdvTree1.SelectedNode
        Dim gi As TextGroupInfo = n?.Tag

        If gi IsNot Nothing Then
            n.Text = gi.Name
        End If
    End Sub

    Private Sub UpdateSelectedArrayItemInfoListItem()
        Dim baseItem As BaseItem = ItemListBox1.SelectedItem
        Dim arrayItem As TextArrayItemInfo = baseItem?.Tag

        If arrayItem IsNot Nothing Then
            baseItem.Text = arrayItem.RomAddress
            ItemListBox1.Refresh()
        End If
    End Sub

    'G U I

    Private Sub TextProfileEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllGroups()
    End Sub

    Private Sub AdvTree1_AfterNodeSelect(sender As Object, e As AdvTreeNodeEventArgs) Handles AdvTree1.AfterNodeSelect
        If TypeOf e.Node?.Tag Is TextGroupInfo Then
            LoadGroup(e.Node.Tag)
        Else
            AdvPropertyGrid1.SelectedObject = Nothing
        End If
    End Sub

    Private Sub ItemListBox1_SelectedChanged(sender As Object, e As EventArgs) Handles ItemListBox1.SelectedItemChanged
        Dim item As ButtonItem = TryCast(ItemListBox1.SelectedItem, ButtonItem)
        If TypeOf item?.Tag Is TextArrayItemInfo Then
            LoadArrayItem(item.Tag)
        End If
    End Sub

    Private Sub ButtonItem_AddTableGroup_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddTableGroup.Click
        AddTableGroupInfo()
    End Sub

    Private Sub ButtonItem_AddArrayGroup_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddArrayGroup.Click
        AddArrayGroupInfo()
    End Sub

    Private Sub ButtonItem_RemoveGroup_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveGroup.Click
        RemoveSelectedGroupInfo()
    End Sub

    Private Sub ButtonItem_AddArrayItem_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddArrayItem.Click
        AddArrayItemInfo()
    End Sub

    Private Sub ButtonItem_ClearArrayItems_Click(sender As Object, e As EventArgs) Handles ButtonItem_ClearArrayItems.Click
        RemoveAllArrayItemInfos()
    End Sub

    Private Sub ButtonItem_RemoveArrayItem_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveArrayItem.Click
        RemoveSelectedArrayItemInfo()
    End Sub

    Private Sub AdvPropertyGrid1_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles AdvPropertyGrid1.PropertyValueChanged
        Select Case e.PropertyName
            Case NameOf(TextGroupInfo.Name)
                UpdateSelectedTextGroupInfoNode()
            Case NameOf(TextArrayItemInfo.RomAddress)
                UpdateSelectedArrayItemInfoListItem()
        End Select
    End Sub

End Class
