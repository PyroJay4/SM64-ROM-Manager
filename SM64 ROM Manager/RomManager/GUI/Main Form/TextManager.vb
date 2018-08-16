Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib

Partial Class Form_Main

    Private TM_LoadingItem As Boolean = False
    Private TM_BytesLeft As Integer = 0

    Private Property TM_IsDialogs As Boolean
        Get
            Return TabStrip_TM_TableSelection.SelectedTab Is TabItem_TM_Dialogs
        End Get
        Set(value As Boolean)
            TabStrip_TM_TableSelection.SelectedTab = TabItem_TM_Dialogs
        End Set
    End Property

    Private Sub TabStrip1_SelectedTabChanged(sender As Object, e As TabStripTabChangedEventArgs) Handles TabStrip_TM_TableSelection.SelectedTabChanged
        Application.DoEvents()

        Dim isDialogs As Boolean = TabStrip_TM_TableSelection.SelectedTab Is TabItem_TM_Dialogs

        Line_TM_Green.Visible = isDialogs
        Line_TM_Warning1.Visible = isDialogs
        Line_TM_Warning2.Visible = isDialogs
        GroupPanel_TM_DialogProps.Visible = isDialogs
        TextBoxX_TM_TextEditor.CharacterCasing = If(isDialogs, CharacterCasing.Normal, CharacterCasing.Upper)

        TextBoxX_TM_TextEditor.Size = If(isDialogs, New Size(264, 456), New Size(264, 538))

        If TabStrip_TM_TableSelection.SelectedTabIndex > -1 Then TM_ReloadTable()
    End Sub

    Private Sub TM_ReloadTable()
        Dim index As Integer = TabStrip_TM_TableSelection.SelectedTabIndex
        StatusText = Form_Main_Resources.Status_LoadingTexts
        rommgr.LoadTextTable(index)
        StatusText = Form_Main_Resources.Status_CreatingTextList
        ListViewEx_TM_TableEntries.Items.Clear()

        Dim nameList() As String = {}
        Select Case TabStrip_TM_TableSelection.SelectedTabIndex
            Case 0
                nameList = TM_CreateDialogNameList()
            Case 1
                nameList = TM_CreateLevelNameList()
            Case 2
                nameList = TM_CreateActNameList()
        End Select

        For Each textItem As Text.TextItem In rommgr.TextTables(index)
            Dim nameEntry As String = ""
            Dim curIndex As Integer = rommgr.TextTables(index).IndexOf(textItem)

            If nameList.Count > curIndex Then _
                nameEntry = nameList(curIndex)

            Dim newItem As New ListViewItem({ListViewEx_TM_TableEntries.Items.Count, nameEntry, textItem.Text})
            ListViewEx_TM_TableEntries.Items.Add(newItem)
        Next

        If ListViewEx_TM_TableEntries.Items.Count > 0 Then
            ListViewEx_TM_TableEntries.Items(0).Selected = True
        End If

        StatusText = Form_Main_Resources.Status_CalculatingTextSpace
        TM_CalcTableBytes()

        StatusText = ""
    End Sub

    Private Sub TM_CheckComboBoxText(sender As Object, Optional e As EventArgs = Nothing) Handles ComboBoxEx_TM_DialogPosX.TextChanged, ComboBoxEx_TM_DialogPosY.TextChanged
        Dim t As Type = If(sender Is ComboBoxEx_TM_DialogPosX, GetType(Text.TextItem.VPos), GetType(Text.TextItem.HPos))
        Dim values() As Int16 = [Enum].GetValues(t)
        Dim names() As String = [Enum].GetNames(t)

        Dim selTextTrim As String = sender.Text.Trim
        Dim selVal As Int16 = TM_GetValueFromComboBox(selTextTrim, t)

        If Not TM_LoadingItem Then
            Dim titem As Text.TextItem = TM_GetSelectedTextItem()
            If titem IsNot Nothing Then
                If selVal > 0 Then
                    Select Case t
                        Case GetType(Text.TextItem.VPos) : titem.VerticalPosition = selVal
                        Case GetType(Text.TextItem.HPos) : titem.HorizontalPosition = selVal
                    End Select
                    TM_GetCurrentTextTable.NeedToSave = True
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

    Private Function TM_GetCurrentTextTable() As Text.TextTable
        If ListViewEx_TM_TableEntries.SelectedIndices.Count > 0 Then
            Return rommgr.TextTables(TabStrip_TM_TableSelection.SelectedTabIndex)
        Else
            Return Nothing
        End If
    End Function

    Private Sub ListViewEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_TM_TableEntries.SelectedIndexChanged
        If ListViewEx_TM_TableEntries.SelectedIndices.Count > 0 Then
            TM_LoadingItem = True

            With TM_GetCurrentTextTable(ListViewEx_TM_TableEntries.SelectedIndices(0))
                TextBoxX_TM_TextEditor.Text = .Text

                Dim isDialogs As Boolean = TabStrip_TM_TableSelection.SelectedTab Is TabItem_TM_Dialogs
                If isDialogs Then
                    IntegerInput_TM_DialogSize.Value = .LinesPerSite

                    Dim vIndex As Integer = Array.IndexOf([Enum].GetValues(GetType(Text.TextItem.VPos)), .VerticalPosition)
                    If vIndex >= 0 Then
                        ComboBoxEx_TM_DialogPosX.SelectedIndex = vIndex
                    Else
                        ComboBoxEx_TM_DialogPosX.Text = TextFromValue(.VerticalPosition)
                    End If

                    Dim hIndex As Integer = Array.IndexOf([Enum].GetValues(GetType(Text.TextItem.HPos)), .HorizontalPosition)
                    If hIndex >= 0 Then
                        ComboBoxEx_TM_DialogPosY.SelectedIndex = hIndex
                    Else
                        ComboBoxEx_TM_DialogPosY.Text = TextFromValue(.HorizontalPosition)
                    End If
                End If
            End With

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

    Private Function TM_GetSelectedTextItem() As SM64Lib.Text.TextItem
        If ListViewEx_TM_TableEntries.SelectedIndices.Count > 0 Then
            Dim index As Integer = ListViewEx_TM_TableEntries.SelectedIndices(0)
            Dim item As Text.TextItem = rommgr.TextTables(TabStrip_TM_TableSelection.SelectedTabIndex)(index)
            Return item
        Else Return Nothing
        End If
    End Function

    Private Function TM_GetSelectedListViewItemItem() As ListViewItem
        If ListViewEx_TM_TableEntries.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListViewEx_TM_TableEntries.SelectedItems(0)
            Return item
        Else Return Nothing
        End If
    End Function

    Private Sub TextBoxX_TM_TextEditor_TextChanged(sender As TextBox, e As EventArgs) Handles TextBoxX_TM_TextEditor.TextChanged
        If Not TM_LoadingItem Then
            Dim titem As Text.TextItem = TM_GetSelectedTextItem()
            titem.Text = sender.Text.TrimEnd
            TM_EditSelectedListViewItem(titem)
            TM_GetCurrentTextTable.NeedToSave = True
        End If

        TM_CalcTableBytes()
    End Sub

    Private Sub IntegerInput_TM_DialogSize_ValueChanged(sender As IntegerInput, e As EventArgs) Handles IntegerInput_TM_DialogSize.ValueChanged
        If Not TM_LoadingItem Then
            Dim titem As Text.TextItem = TM_GetSelectedTextItem()
            titem.LinesPerSite = sender.Value
            TM_EditSelectedListViewItem(titem)
            TM_GetCurrentTextTable.NeedToSave = True
        End If
    End Sub

    Private Function TM_CreateLevelNameList() As String()
        Dim list As New List(Of String)

        For lvlnumber As Integer = 1 To 26
            Dim item As String = ""

            Select Case lvlnumber
                Case Is <= 15
                    Dim lvltxt As String = lvlnumber
                    Dim name As String = rommgr.LevelInfoData.FirstOrDefault(Function(n) n.Number = lvltxt)?.Name
                    item = String.Format("Level {0}{1}", lvlnumber.ToString("00"), If(name IsNot Nothing, ": " & lvltxt, ""))
                Case 16
                    item = String.Format("Bowser 1")
                    'item.BeginGroup = True
                Case 17 : item = String.Format("Bowser 2")
                Case 18 : item = String.Format("Bowser 3")
                Case 19
                    item = String.Format("Princess's Secret Slide")
                    'item.BeginGroup = True
                Case 20 : item = String.Format("Metal Cap")
                Case 21 : item = String.Format("Wing Cap")
                Case 22 : item = String.Format("Vanish Cap")
                Case 23 : item = String.Format("Rainbow Secret Level")
                Case 24 : item = String.Format("Secret Aquarium")
                Case 25
                    item = String.Format("Unkown")
                    'item.BeginGroup = True
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
                        'item.BeginGroup = True
                        act = 6
                    Case 17
                        item = String.Format(Form_Main_Resources.Text_Unknown)
                        'If act = 1 Then item.BeginGroup = True
                    Case Else
                        item = String.Format(Form_Main_Resources.Text_LevelStar, level.ToString("00"), act)
                        'If act = 1 Then item.BeginGroup = True
                End Select

                list.Add(item)
            Next
        Next

        Return list.ToArray
    End Function

    Private Function TM_CreateDialogNameList() As String()
        Dim list() As String = {}

        Dim file_dialogs As String = Path.Combine(MyDataPath, "Text Manager\dialogs.txt")
        If File.Exists(file_dialogs) Then
            list = File.ReadAllLines(file_dialogs)
        End If

        For i As Integer = 0 To list.Length - 1
            list(i) = list(i).Substring(6)
        Next

        Return list
    End Function

    Private Sub TM_CalcTableBytes()
        Dim curTable = TM_GetCurrentTextTable()

        If curTable IsNot Nothing Then
            Dim max As Integer = curTable.MaxTextDataSize
            Dim used As Integer = curTable.BytesCount

            Dim percent As Single = used / max
            Dim left As Integer = max - used

            TM_BytesLeft = left

            LabelX_TM_BytesLeft.Text = String.Format(Form_Main_Resources.Text_UsedOfMaxLeft, used, max, left) '$"{used} of {max} used / {left} left"
            If percent > 1 Then
                LabelX_TM_BytesLeft.ForeColor = Color.Red
            Else
                LabelX_TM_BytesLeft.ForeColor = Color.Green
            End If
        End If
    End Sub

End Class
