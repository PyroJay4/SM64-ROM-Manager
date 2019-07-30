Imports System.ComponentModel
Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64_ROM_Manager.EventArguments
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib

Public Class Tab_TextManager

    'F i e l d s

    Public WithEvents Controller As MainController
    Private TM_LoadingItem As Boolean = False
    Private TM_BytesLeft As Integer = 0

    'C o n s t r u c t o r

    Public Sub New()
        InitializeComponent()
        BackColor = Color.White
        Bar_AddRemoveItems.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub

    'C o n t r o l l e r   E v e n t s

    Private Sub Controller_RequestReloadTextManager() Handles Controller.RequestReloadTextManagerLists
        LoadTableEntries()
    End Sub

    Private Sub Controller_TextItemChanged(e As TextItemEventArgs) Handles Controller.TextItemChanged
        UpdateListViewItem(e.ItemIndex)
        ShowCurTableBytes()
    End Sub

    Private Sub Controller_RequestReloadTextManagerLineColors() Handles Controller.RequestReloadTextManagerLineColors
        Line_TM_Green.ForeColor = Color.YellowGreen
        Line_TM_Warning1.ForeColor = Color.Orange
        Line_TM_Warning2.ForeColor = Color.Red
    End Sub

    Private Sub Controller_TextItemAdded(e As TextItemEventArgs) Handles Controller.TextItemAdded
        AddTextListViewItem(e.TableName, e.ItemIndex, {})
    End Sub

    Public Sub Controller_TextItemRemoved(e As TextItemEventArgs) Handles Controller.TextItemRemoved
        RemoveTextItem(e.ItemIndex)
    End Sub

    'G u i

    Private Sub RemoveTextItem(tableIndex As Integer)
        ListViewEx_TM_TableEntries.Items.RemoveAt(tableIndex)
    End Sub

    Private Sub LoadTabStripItems()
        Dim oldSelected As String = TabStrip_TextTable.SelectedTab?.Tag
        Dim tabToSelect As TabItem = Nothing
        Dim firstTab As TabItem = Nothing
        Dim groupNames As String() = Controller.GetTextGroupInfoNames

        'Clear old ones
        TabStrip_TextTable.SuspendLayout()
        TabStrip_TextTable.SelectedTabIndex = -1
        TabStrip_TextTable.Tabs.Clear()

        'Create & Add new Tabs
        For i As Integer = 0 To Controller.GetTextGroupInfosCount - 1
            Dim info = Controller.GetTextGroupInfos(groupNames(i))
            Dim tab As New TabItem With {
                .Text = info.name,
                .Tag = info.name
            }

            TabStrip_TextTable.Tabs.Add(tab)

            If firstTab Is Nothing Then
                firstTab = tab
            End If

            If tabToSelect IsNot Nothing AndAlso info.name = oldSelected Then
                tabToSelect = tab
            End If
        Next

        'Select tab
        If tabToSelect Is Nothing AndAlso firstTab IsNot Nothing Then
            tabToSelect = firstTab
        End If

        TabStrip_TextTable.ResumeLayout()
        TabStrip_TextTable.SelectedTab = Nothing
        TabStrip_TextTable.SelectedTab = tabToSelect
    End Sub

    Public Sub LoadTableEntries()
        Dim tableName As String
        Dim nameList() As String = {}
        Dim col1 As ColumnHeader = ListViewEx_TM_TableEntries.Columns(1)
        Dim col2 As ColumnHeader = ListViewEx_TM_TableEntries.Columns(2)

        If TabStrip_TextTable.Tabs.Count = 0 Then
            LoadTabStripItems()
        End If
        tableName = TabStrip_TextTable.SelectedTab?.Tag

        Controller.StatusText = Form_Main_Resources.Status_LoadingTexts
        Controller.LoadTextGroup(tableName)

        Controller.StatusText = Form_Main_Resources.Status_CreatingTextList
        ListViewEx_TM_TableEntries.SuspendLayout()
        ListViewEx_TM_TableEntries.Items.Clear()

        Dim infos = Controller.GetTextGroupInfos(tableName).name
        nameList = Controller.GetTextNameList(tableName)

        For i As Integer = 0 To Controller.GetTextGroupEntriesCount(tableName) - 1
            AddTextListViewItem(tableName, i, nameList)
        Next

        If nameList.Any Then
            If col1.Tag IsNot Nothing Then
                col2.Width -= col1.Tag
                col1.Width = col1.Tag
                col1.Tag = Nothing
            End If
        ElseIf col1.Width > 0 Then
            col1.Tag = col1.Width
            col1.Width = 0
            col2.Width += col1.Tag
        End If

        ListViewEx_TM_TableEntries.ResumeLayout()

        If ListViewEx_TM_TableEntries.Items.Count > 0 Then
            Dim item As ListViewItem = ListViewEx_TM_TableEntries.Items(0)
            item.Selected = True
            item.EnsureVisible()
        End If

        Controller.StatusText = Form_Main_Resources.Status_CalculatingTextSpace
        ShowCurTableBytes()

        Controller.StatusText = String.Empty
    End Sub

    Private Sub AddTextListViewItem(tableName As String, tableIndex As Integer, nameList As String())
        Dim itemInfos = Controller.GetTextItemInfos(tableName, tableIndex)
        Dim nameEntry As String = String.Empty

        If nameList.Count > tableIndex Then
            nameEntry = nameList(tableIndex)
        End If

        Dim newItem As New ListViewItem({
                                        tableIndex + 1,
                                        nameEntry,
                                        itemInfos.text.Split({ControlChars.Cr, ControlChars.Lf}).FirstOrDefault
                                        })
        ListViewEx_TM_TableEntries.Items.Add(newItem)
    End Sub

    Private Sub UpdateListViewItem(index As Integer, Optional refresh As Boolean = True)
        Dim lvi As ListViewItem = ListViewEx_TM_TableEntries.Items(index)
        Dim infos = Controller.GetTextItemInfos(GetSelectedIndicies.tableName, index)

        lvi.SubItems(2).Text = infos.text

        If refresh Then ListViewEx_TM_TableEntries.Refresh()
    End Sub

    Private Sub UpdateAllListViewItems()
        For i As Integer = 0 To ListViewEx_TM_TableEntries.Items.Count - 1
            UpdateListViewItem(False)
        Next

        ListViewEx_TM_TableEntries.Refresh()
    End Sub

    Private Sub SetGuiForTextTable(tableName As String)
        Dim groupInfo = Controller.GetTextGroupInfos(tableName)
        Dim isUpperCase As Boolean = {"Acts", "Levels", "File Menu"}.Contains(groupInfo.name)
        Dim isPreDefined As Boolean = {"Acts", "Levels", "File Menu", "Dialogs", "Ending", "Credits"}.Contains(groupInfo.name)

        Line_TM_Green.Visible = groupInfo.isDialogGroup
        Line_TM_Warning1.Visible = groupInfo.isDialogGroup
        Line_TM_Warning2.Visible = groupInfo.isDialogGroup
        GroupPanel_TM_DialogProps.Visible = groupInfo.isDialogGroup
        TextBoxX_TM_TextEditor.CharacterCasing = If(isUpperCase, CharacterCasing.Upper, CharacterCasing.Normal)

        Dim elementHight As Integer = ListViewEx_TM_TableEntries.Height + TabStrip_TextTable.Height
        If groupInfo.isDialogGroup Then
            elementHight -= GroupPanel_TM_DialogProps.Height + 4
        End If
        TextBoxX_TM_TextEditor.Height = elementHight
        Line_TM_Green.Height = elementHight - 5
        Line_TM_Warning1.Height = elementHight - 5
        Line_TM_Warning2.Height = elementHight - 5

        Bar_AddRemoveItems.Visible = Not isPreDefined
        If isPreDefined OrElse Not groupInfo.isTableGroup Then
            TabStrip_TextTable.Width = TextBoxX_TM_TextEditor.Location.X - 6
        Else
            TabStrip_TextTable.Width = Bar_AddRemoveItems.Location.X - 6
        End If

        If IsAnyTextItemSelected() Then
            LoadTableEntries()
        End If
    End Sub

    Private Function GetSelectedIndicies() As (tableName As String, tableIndex As Integer)
        Dim tableName As String = TabStrip_TextTable.SelectedTab?.Tag
        Dim tableIndex As Integer = 0

        If ListViewEx_TM_TableEntries.SelectedIndices.Count > 0 Then
            tableIndex = ListViewEx_TM_TableEntries.SelectedIndices(0)
        End If

        Return (tableName, tableIndex)
    End Function

    Private Sub SaveItemText()
        If Not TM_LoadingItem AndAlso Not Controller.IsChangingTab Then
            Dim selIndicies = GetSelectedIndicies()
            Dim text As String = TextBoxX_TM_TextEditor.Text

            Controller.SetTextItemText(selIndicies.tableName, selIndicies.tableIndex, text)
        End If
    End Sub

    Private Sub SaveItemDialogData()
        If Not TM_LoadingItem AndAlso Not Controller.IsChangingTab Then
            Dim selIndicies = GetSelectedIndicies()
            Dim vPos As Text.DialogVerticalPosition = GetValueFromComboBox(ComboBoxEx_TM_DialogPosX.Text.Trim, GetType(Text.DialogVerticalPosition))
            Dim hPos As Text.DialogHorizontalPosition = GetValueFromComboBox(ComboBoxEx_TM_DialogPosY.Text.Trim, GetType(Text.DialogHorizontalPosition))
            Dim linesPerSite = IntegerInput_TM_DialogSize.Value

            Controller.SetTextItemDialogData(selIndicies.tableName, selIndicies.tableIndex, vPos, hPos, linesPerSite)
        End If
    End Sub

    Private Function GetValueFromComboBox(selText As String, posType As Type) As Int16
        Dim names() As String = [Enum].GetNames(posType)
        For Each n As String In names
            If n.ToLower.Equals(selText.ToLower) Then
                Return [Enum].GetValues(posType)(Array.IndexOf(names, n))
            End If
        Next
        Return ValueFromText(selText, Int16.MinValue)
    End Function

    Private Sub ShowCurTableBytes()
        Dim selIndicies = GetSelectedIndicies()

        If Not String.IsNullOrEmpty(selIndicies.tableName) Then
            Dim res = Controller.CalcTextSpaceBytesCount(selIndicies.tableName, selIndicies.tableIndex)

            TM_BytesLeft = res.left

            Dim newText As String = String.Format(Form_Main_Resources.Text_UsedOfMaxLeft, res.used, res.max, res.left)
            Dim newColor As Color
            If res.percent > 1 Then
                newColor = Color.Red
            Else
                newColor = Color.Green
            End If

            Controller.SetOtherStatusInfos(newText, newColor)
        End If
    End Sub

    Private Function IsAnyTextItemSelected() As Boolean
        Return ListViewEx_TM_TableEntries.SelectedIndices.Count > 0
    End Function

    Private Sub ShowTextItemData()
        Dim selectedIndicies = GetSelectedIndicies()
        If Not String.IsNullOrEmpty(selectedIndicies.tableName) AndAlso selectedIndicies.tableIndex > -1 Then
            TM_LoadingItem = True

            Dim groupInfo = Controller.GetTextGroupInfos(selectedIndicies.tableName)
            Dim itemInfo = Controller.GetTextItemInfos(selectedIndicies.tableName, selectedIndicies.tableIndex)

            TextBoxX_TM_TextEditor.Text = itemInfo.text

            If groupInfo.isDialogGroup Then
                IntegerInput_TM_DialogSize.Value = itemInfo.linesPerSite

                Dim vIndex As Integer = Array.IndexOf([Enum].GetValues(GetType(Text.DialogVerticalPosition)), itemInfo.verticalPosition)
                If vIndex >= 0 Then
                    ComboBoxEx_TM_DialogPosX.SelectedIndex = vIndex
                Else
                    ComboBoxEx_TM_DialogPosX.Text = TextFromValue(itemInfo.verticalPosition)
                End If

                Dim hIndex As Integer = Array.IndexOf([Enum].GetValues(GetType(Text.DialogHorizontalPosition)), itemInfo.horizontalPosition)
                If hIndex >= 0 Then
                    ComboBoxEx_TM_DialogPosY.SelectedIndex = hIndex
                Else
                    ComboBoxEx_TM_DialogPosY.Text = TextFromValue(itemInfo.horizontalPosition)
                End If
            End If

            TM_LoadingItem = False
        End If
    End Sub

    Private Sub TabStrip1_SelectedTabChanged(sender As Object, e As TabStripTabChangedEventArgs) Handles TabStrip_TextTable.SelectedTabChanged
        SetGuiForTextTable(GetSelectedIndicies.tableName)
    End Sub

    Private Sub TM_CheckComboBoxText(sender As Object, Optional e As EventArgs = Nothing) Handles ComboBoxEx_TM_DialogPosX.TextChanged, ComboBoxEx_TM_DialogPosY.TextChanged
        SaveItemDialogData()
    End Sub

    Private Sub IntegerInput_TM_DialogSize_ValueChanged(sender As IntegerInput, e As EventArgs) Handles IntegerInput_TM_DialogSize.ValueChanged
        SaveItemDialogData()
    End Sub

    Private Sub TextBoxX_TM_TextEditor_TextChanged(sender As TextBox, e As EventArgs) Handles TextBoxX_TM_TextEditor.TextChanged
        SaveItemText()
    End Sub

    Private Sub ListViewEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_TM_TableEntries.SelectedIndexChanged
        If IsAnyTextItemSelected() Then
            ShowTextItemData()
        End If
    End Sub

    Private Sub ButtonItem_AddTextItem_Click(sender As Object, e As EventArgs) Handles ButtonItem_AddTextItem.Click
        Controller.AddNewTextTableItem(GetSelectedIndicies.tableName)
    End Sub

    Private Sub ButtonItem_RemoveTextItem_Click(sender As Object, e As EventArgs) Handles ButtonItem_RemoveTextItem.Click
        Dim index = GetSelectedIndicies()
        Controller.RemoveTextTableItem(index.tableName, index.tableIndex)
    End Sub

End Class
