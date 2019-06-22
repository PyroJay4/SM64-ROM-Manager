Imports System.ComponentModel
Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib

Public Class Tab_TextManager

    Private TM_LoadingItem As Boolean = False
    Private TM_BytesLeft As Integer = 0

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property RomMgr As RomManager
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DialogNamesFilePath As String
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property MainForm As MainForm = Nothing

    Public Sub New()
        InitializeComponent()

        If Not Publics.IsDesigneTime Then
            DialogNamesFilePath = Path.Combine(Publics.MyDataPath, "Text Manager\dialogs.txt")
        End If
    End Sub

    Public ReadOnly Property OverLimit As Boolean
        Get
            If RomMgr IsNot Nothing Then
                For Each tbl As Text.TextGroup In RomMgr.TextGroups
                    If TypeOf tbl Is Text.TextTableGroup Then
                        If CalcTableBytes(tbl, Nothing).percent > 1 Then
                            Return True
                        End If
                    ElseIf TypeOf tbl Is Text.TextArrayGroup Then
                        For Each item As Text.TextArrayItem In CType(tbl, Text.TextArrayGroup)
                            If CalcTableBytes(Nothing, item).percent > 1 Then
                                Return True
                            End If
                        Next
                    End If
                Next
            End If
            Return False
        End Get
    End Property

    Public Property LineColorGreen As Color
        Get
            Return Line_TM_Green.ForeColor
        End Get
        Set(value As Color)
            Line_TM_Green.ForeColor = value
        End Set
    End Property

    Public Property LineColorWarning1 As Color
        Get
            Return Line_TM_Warning1.ForeColor
        End Get
        Set(value As Color)
            Line_TM_Warning1.ForeColor = value
        End Set
    End Property

    Public Property LineColorWarning2 As Color
        Get
            Return Line_TM_Warning2.ForeColor
        End Get
        Set(value As Color)
            Line_TM_Warning2.ForeColor = value
        End Set
    End Property

    Private Property StatusText As String
        Get
            Return MainForm?.StatusText
        End Get
        Set(value As String)
            If MainForm IsNot Nothing Then
                MainForm.StatusText = value
            End If
        End Set
    End Property

    Private Sub TabStrip1_SelectedTabChanged(sender As Object, e As TabStripTabChangedEventArgs) Handles TabStrip_TextTable.SelectedTabChanged
        Dim curTable As Text.TextGroup = RomMgr.LoadTextGroup(TabStrip_TextTable.SelectedTab.Tag)
        Dim isDialogs As Boolean = False
        Dim isUpperCase As Boolean = {"Acts", "Levels", "File Menu"}.Contains(curTable?.TextGroupInfo.Name)

        If TypeOf curTable Is Text.TextTableGroup Then
            isDialogs = CType(curTable, Text.TextTableGroup).TextGroupInfo.TableType = SM64Lib.Text.Profiles.TextTableType.Dialogs
        End If

        Line_TM_Green.Visible = isDialogs
        Line_TM_Warning1.Visible = isDialogs
        Line_TM_Warning2.Visible = isDialogs
        GroupPanel_TM_DialogProps.Visible = isDialogs
        TextBoxX_TM_TextEditor.CharacterCasing = If(isUpperCase, CharacterCasing.Upper, CharacterCasing.Normal)

        Dim elementHight As Integer = ListViewEx_TM_TableEntries.Height + TabStrip_TextTable.Height
        If isDialogs Then
            elementHight -= GroupPanel_TM_DialogProps.Height + 4
        End If
        TextBoxX_TM_TextEditor.Height = elementHight
        Line_TM_Green.Height = elementHight - 5
        Line_TM_Warning1.Height = elementHight - 5
        Line_TM_Warning2.Height = elementHight - 5

        If IsAnyTextItemSelected() Then
            TM_ReloadTable()
        End If
    End Sub

    Friend Sub TM_ReloadTableList()
        Dim oldSelected As String = TabStrip_TextTable.SelectedTab?.Tag
        Dim tabToSelect As TabItem = Nothing
        Dim firstTab As TabItem = Nothing

        'Clear old ones
        TabStrip_TextTable.SuspendLayout()
        TabStrip_TextTable.SelectedTabIndex = -1
        TabStrip_TextTable.Tabs.Clear()

        'Create & Add new Tabs
        For Each info As Text.Profiles.TextGroupInfo In RomMgr.GetTextGroupInfos
            Dim tab As New TabItem With {
                .Text = info.Name,
                .Tag = info.Name
            }

            TabStrip_TextTable.Tabs.Add(tab)

            If firstTab Is Nothing Then
                firstTab = tab
            End If

            If tabToSelect IsNot Nothing AndAlso info.Name = oldSelected Then
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

    Public Sub TM_ReloadTable()
        Dim tableName As String
        Dim textTable As Text.TextGroup
        Dim nameList() As String = {}
        Dim col1 As ColumnHeader = ListViewEx_TM_TableEntries.Columns(1)
        Dim col2 As ColumnHeader = ListViewEx_TM_TableEntries.Columns(2)

        If TabStrip_TextTable.Tabs.Count = 0 Then
            TM_ReloadTableList()
        End If
        tableName = TabStrip_TextTable.SelectedTab?.Tag

        StatusText = Form_Main_Resources.Status_LoadingTexts
        textTable = RomMgr.LoadTextGroup(tableName)

        StatusText = Form_Main_Resources.Status_CreatingTextList
        ListViewEx_TM_TableEntries.SuspendLayout()
        ListViewEx_TM_TableEntries.Items.Clear()

        Select Case TabStrip_TextTable.SelectedTab.Tag
            Case "Dialogs"
                nameList = TM_CreateDialogNameList()
            Case "Levels"
                nameList = TM_CreateLevelNameList()
            Case "Acts"
                nameList = TM_CreateActNameList()
        End Select

        For i As Integer = 0 To textTable.Count - 1
            Dim textItem As Text.TextItem = textTable(i)
            Dim nameEntry As String = ""

            If nameList.Count > i Then
                nameEntry = nameList(i)
            End If

            Dim newItem As New ListViewItem({
                                            ListViewEx_TM_TableEntries.Items.Count,
                                            nameEntry,
                                            textItem.Text.Split({ControlChars.Cr, ControlChars.Lf}).FirstOrDefault
                                            })
            ListViewEx_TM_TableEntries.Items.Add(newItem)
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

        StatusText = Form_Main_Resources.Status_CalculatingTextSpace
        ShowCurTableBytes()

        StatusText = ""
    End Sub

    Private Sub TM_CheckComboBoxText(sender As Object, Optional e As EventArgs = Nothing) Handles ComboBoxEx_TM_DialogPosX.TextChanged, ComboBoxEx_TM_DialogPosY.TextChanged
        Dim t As Type = If(sender Is ComboBoxEx_TM_DialogPosX, GetType(Text.DialogVerticalPosition), GetType(Text.DialogHorizontalPosition))
        Dim values() As Int16 = [Enum].GetValues(t)
        Dim names() As String = [Enum].GetNames(t)

        Dim selTextTrim As String = sender.Text.Trim
        Dim selVal As Int16 = TM_GetValueFromComboBox(selTextTrim, t)

        If Not TM_LoadingItem Then
            Dim titem As Text.TextTableDialogItem = TryCast(TM_GetSelectedTextItem(), Text.TextTableDialogItem)
            If titem IsNot Nothing Then
                If selVal > 0 Then
                    Select Case t
                        Case GetType(Text.DialogVerticalPosition) : titem.VerticalPosition = selVal
                        Case GetType(Text.DialogHorizontalPosition) : titem.HorizontalPosition = selVal
                    End Select
                    GetCurrentTextTable.NeedToSave = True
                End If
            End If
        End If

        Dim index As Integer = Array.IndexOf(values, selVal)
        If index > -1 Then
            Dim wasloading As Boolean = TM_LoadingItem
            TM_LoadingItem = True
            sender.Text = names(index)
            TM_LoadingItem = wasloading
        End If
    End Sub
    Private Function TM_GetValueFromComboBox(selText As String, posType As Type) As Int16
        Dim names() As String = [Enum].GetNames(posType)
        For Each n As String In names
            If n.ToLower.Equals(selText.ToLower) Then
                Return [Enum].GetValues(posType)(Array.IndexOf(names, n))
            End If
        Next
        Return ValueFromText(selText, Int16.MinValue)
    End Function

    Private Function GetCurrentTextTable() As Text.TextGroup
        Return RomMgr.TextGroups?.FirstOrDefault(Function(n) n.TextGroupInfo.Name = TabStrip_TextTable.SelectedTab.Tag)
    End Function

    Private Function GetCurrentTextItem() As Text.TextItem
        Return GetCurrentTextItem(GetCurrentTextTable)
    End Function

    Private Function GetCurrentTextItem(table As Text.TextGroup) As Text.TextItem
        If IsAnyTextItemSelected() Then
            Return table(ListViewEx_TM_TableEntries.SelectedIndices(0))
        Else
            Return Nothing
        End If
    End Function

    Private Function IsAnyTextItemSelected() As Boolean
        Return ListViewEx_TM_TableEntries.SelectedIndices.Count > 0
    End Function

    Private Sub ListViewEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_TM_TableEntries.SelectedIndexChanged
        If IsAnyTextItemSelected() Then
            TM_LoadingItem = True

            Dim curTable As Text.TextGroup = GetCurrentTextTable()
            Dim curItem As Text.TextItem = GetCurrentTextItem(curTable)
            Dim curTableItem As Text.TextTableItem = TryCast(curItem, Text.TextTableItem)
            Dim isDialogs As Boolean = False

            If curTableItem IsNot Nothing Then
                isDialogs = curTableItem.TextGroupInfo.TableType = SM64Lib.Text.Profiles.TextTableType.Dialogs
            End If

            TextBoxX_TM_TextEditor.Text = curItem.Text

            If isDialogs Then
                Dim curTableDialogItem As Text.TextTableDialogItem = curTableItem

                IntegerInput_TM_DialogSize.Value = curTableDialogItem.LinesPerSite

                Dim vIndex As Integer = Array.IndexOf([Enum].GetValues(GetType(Text.DialogVerticalPosition)), curTableDialogItem.VerticalPosition)
                If vIndex >= 0 Then
                    ComboBoxEx_TM_DialogPosX.SelectedIndex = vIndex
                Else
                    ComboBoxEx_TM_DialogPosX.Text = TextFromValue(curTableDialogItem.VerticalPosition)
                End If

                Dim hIndex As Integer = Array.IndexOf([Enum].GetValues(GetType(Text.DialogHorizontalPosition)), curTableDialogItem.HorizontalPosition)
                If hIndex >= 0 Then
                    ComboBoxEx_TM_DialogPosY.SelectedIndex = hIndex
                Else
                    ComboBoxEx_TM_DialogPosY.Text = TextFromValue(curTableDialogItem.HorizontalPosition)
                End If
            End If

            TM_LoadingItem = False
        End If
    End Sub

    Private Sub TM_EditSelectedListViewItem(item As String)
        Dim lvi As ListViewItem = TM_GetSelectedListViewItemItem()
        lvi.SubItems(2).Text = item
        If lvi.ListView IsNot Nothing Then lvi.ListView.Refresh()
    End Sub

    Private Sub TM_EditSelectedListViewItem(item As Text.TextItem)
        Dim lvi As ListViewItem = TM_GetSelectedListViewItemItem()
        lvi.SubItems(2).Text = item.Text
        If lvi.ListView IsNot Nothing Then lvi.ListView.Refresh()
    End Sub

    Private Function TM_GetSelectedTextItem() As Text.TextItem
        If ListViewEx_TM_TableEntries.SelectedIndices.Count > 0 Then
            Dim index As Integer = ListViewEx_TM_TableEntries.SelectedIndices(0)
            Dim item As Text.TextItem = GetCurrentTextTable()?(index)
            Return item
        Else
            Return Nothing
        End If
    End Function

    Private Function TM_GetSelectedListViewItemItem() As ListViewItem
        If ListViewEx_TM_TableEntries.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListViewEx_TM_TableEntries.SelectedItems(0)
            Return item
        Else
            Return Nothing
        End If
    End Function

    Private Sub TextBoxX_TM_TextEditor_TextChanged(sender As TextBox, e As EventArgs) Handles TextBoxX_TM_TextEditor.TextChanged
        If Not TM_LoadingItem Then
            Dim titem As Text.TextItem = TM_GetSelectedTextItem()
            titem.Text = sender.Text.TrimEnd
            TM_EditSelectedListViewItem(titem)
            GetCurrentTextTable.NeedToSave = True
        End If

        ShowCurTableBytes()
    End Sub

    Private Sub IntegerInput_TM_DialogSize_ValueChanged(sender As IntegerInput, e As EventArgs) Handles IntegerInput_TM_DialogSize.ValueChanged
        If Not TM_LoadingItem Then
            Dim titem As Text.TextTableDialogItem = TryCast(TM_GetSelectedTextItem(), Text.TextTableDialogItem)
            If titem IsNot Nothing Then
                titem.LinesPerSite = sender.Value
                TM_EditSelectedListViewItem(titem)
                GetCurrentTextTable.NeedToSave = True
            End If
        End If
    End Sub

    Private Function TM_CreateLevelNameList() As String()
        Dim list As New List(Of String)

        For lvlnumber As Integer = 1 To 26
            Dim item As String = ""

            Select Case lvlnumber
                Case Is <= 15
                    Dim lvltxt As String = lvlnumber
                    Dim name As String = RomMgr.LevelInfoData.FirstOrDefault(Function(n) n.Number = lvltxt)?.Name
                    item = String.Format("Level {0}{1}", lvlnumber.ToString("00"), If(name IsNot Nothing, ": " & lvltxt, ""))
                Case 16
                    item = String.Format("Bowser 1")
                Case 17 : item = String.Format("Bowser 2")
                Case 18 : item = String.Format("Bowser 3")
                Case 19
                    item = String.Format("Princess's Secret Slide")
                Case 20 : item = String.Format("Metal Cap")
                Case 21 : item = String.Format("Wing Cap")
                Case 22 : item = String.Format("Vanish Cap")
                Case 23 : item = String.Format("Rainbow Secret Level")
                Case 24 : item = String.Format("Secret Aquarium")
                Case 25
                    item = String.Format("Unkown")
                Case 26 : item = String.Format("Secret Stars")
            End Select

            list.Add(item)
        Next

        Return list.ToArray
    End Function

    Private Function TM_CreateActNameList() As String()
        Dim list As New List(Of String)

        For level As Integer = 1 To 17
            For act As Integer = 1 To 6
                Dim item As String = ""

                Select Case level
                    Case 16
                        item = String.Format(Form_Main_Resources.Text_SecretStar)
                        act = 6
                    Case 17
                        item = String.Format(Form_Main_Resources.Text_Unknown)
                    Case Else
                        item = String.Format(Form_Main_Resources.Text_LevelStar, level.ToString("00"), act)
                End Select

                list.Add(item)
            Next
        Next

        Return list.ToArray
    End Function

    Private Function TM_CreateDialogNameList() As String()
        Dim list() As String = {}

        Dim file_dialogs As String = DialogNamesFilePath
        If File.Exists(file_dialogs) Then
            list = File.ReadAllLines(file_dialogs)
        End If

        For i As Integer = 0 To list.Length - 1
            list(i) = list(i).Substring(6)
        Next

        Return list
    End Function

    Private Sub ShowCurTableBytes()
        Dim curGroup As Text.TextGroup = GetCurrentTextTable()
        Dim curTextITem As Text.TextItem = GetCurrentTextItem()

        If curGroup IsNot Nothing Then
            Dim res = CalcTableBytes(curGroup, curTextITem)

            TM_BytesLeft = res.left

            MainForm.OtherInfoLabel.Text = String.Format(Form_Main_Resources.Text_UsedOfMaxLeft, res.used, res.max, res.left)
            If res.percent > 1 Then
                MainForm.OtherInfoLabel.ForeColor = Color.Red
            Else
                MainForm.OtherInfoLabel.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Function CalcTableBytes(curTable As Text.TextGroup, curTextItem As Text.TextItem) As (used As Integer, max As Integer, left As Integer, percent As Single)
        If curTable IsNot Nothing Then
            Dim max As Integer = 0
            Dim used As Integer = 0
            Dim percent As Single
            Dim left As Integer

            If TypeOf curTable Is Text.TextTableGroup Then
                Dim curGroupCast As Text.TextTableGroup = curTable
                max = curGroupCast.TextGroupInfo.Data.DataMaxSize
                used = curGroupCast.DataLength
            ElseIf TypeOf curTable Is Text.TextArrayGroup Then
                Dim curTextItemCast As Text.TextArrayItem = curTextItem
                max = curTextItemCast.ItemInfo.MaxLength
                used = curTextItemCast.Data.Length
            End If

            If max > 0 Then
                percent = used / max
                left = max - used
            Else
                percent = 0
                left = max
            End If

            Return (used, max, left, percent)
        End If
    End Function
End Class
