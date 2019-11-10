Imports System.IO
Imports SM64_ROM_Manager.EventArguments
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Text
Imports SM64Lib.Text.Profiles
Imports SM64_ROM_Manager.Publics
Imports System.ComponentModel

Public Class TextManagerController

    'C o n t r ol l e r   E v e n t s

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Event RequestStatusText(e As RequestValueEventArgs(Of String))
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Event SettingStatusText(newText As String)
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Event SettingOtherStatusInfo(text As String, foreColor As Color)
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Event RequestIsChangingTab(e As RequestValueEventArgs(Of Boolean))
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Event RequestRomManager(e As RequestRomManagerEventArgs)

    'P u b l i c   E v e n t s

    Public Event RequestReloadTextManagerLists()
    Public Event RequestReloadTextManagerLineColors()
    Public Event TextItemChanged(e As TextItemEventArgs)
    Public Event TextItemAdded(e As TextItemEventArgs)
    Public Event TextItemRemoved(e As TextItemEventArgs)

    'P r o p e r t i e s

    Public ReadOnly Property MyTextProfiles As New TextProfileInfoManager

    Public ReadOnly Property RomManager As RomManager
        Get
            Dim e As New RequestRomManagerEventArgs
            RaiseEvent RequestRomManager(e)
            Return e.RomManager
        End Get
    End Property

    Private ReadOnly Property DialogNamesFilePath As String
        Get
            Static p As String = Path.Combine(MyDataPath, "Text Manager\dialogs.txt")
            Return p
        End Get
    End Property

    Public Property StatusText As String
        Get
            Dim e As New RequestValueEventArgs(Of String)
            RaiseEvent RequestStatusText(e)
            Return e.Value
        End Get
        Set(value As String)
            RaiseEvent SettingStatusText(value)
        End Set
    End Property

    'G e n e r a l   F e a t u r e s

    Public Sub OpenTextProfileEditor()
        MyTextProfiles.LoadAllTextProfilesIfNotLoaded()

        Dim editor As New TextProfilesManagerDialog With {
            .MyTextProfiles = MyTextProfiles
        }

        editor.ShowDialog()

        If RomManager IsNot Nothing Then
            RomManager.ClearTextGroups()
            SendRequestReloadTextManagerLists()
        End If
    End Sub

    Public Function IsChangingTab() As Boolean
        Dim e As New RequestValueEventArgs(Of Boolean)(False)
        RaiseEvent RequestIsChangingTab(e)
        Return e.Value
    End Function

    Public Sub SetOtherStatusInfos(text As String, foreColor As Color)
        RaiseEvent SettingOtherStatusInfo(text, foreColor)
    End Sub

    'T e x t   M a n a g e r   F e a t u r e s

    Private Function GetTextGroup(name As String) As TextGroup
        Return RomManager?.TextGroups?.FirstOrDefault(Function(n) n.TextGroupInfo.Name = name)
    End Function

    Public Sub SendRequestReloadTextManagerLists()
        RaiseEvent RequestReloadTextManagerLists()
    End Sub

    Public Sub SendRequestReloadTextManagerLineColors()
        RaiseEvent RequestReloadTextManagerLineColors()
    End Sub

    Public Function IsTextOverLimit() As Boolean
        If RomManager IsNot Nothing Then
            For itbl As Integer = 0 To RomManager.TextGroups.Length - 1
                Dim tbl As TextGroup = RomManager.TextGroups(itbl)

                If TypeOf tbl Is TextTableGroup Then
                    If CalcTextSpaceBytesCount(tbl.TextGroupInfo.Name, Nothing).percent > 1 Then
                        Return True
                    End If
                ElseIf TypeOf tbl Is TextArrayGroup Then
                    For iItem = 0 To CType(tbl, TextArrayGroup).Count - 1
                        If CalcTextSpaceBytesCount(tbl.TextGroupInfo.Name, iItem).percent > 1 Then
                            Return True
                        End If
                    Next
                End If
            Next
        End If

        Return False
    End Function

    Public Function CalcTextSpaceBytesCount(tableName As String, itemIndex As Integer) As (used As Integer, max As Integer, left As Integer, percent As Single)
        If Not String.IsNullOrEmpty(tableName) Then
            Dim curTable As TextGroup = RomManager.LoadTextGroup(tableName)
            Dim curTextItem As TextItem = curTable.ElementAtOrDefault(itemIndex)

            Dim max As Integer = 0
            Dim used As Integer = 0
            Dim percent As Single
            Dim left As Integer

            If TypeOf curTable Is TextTableGroup Then
                Dim curGroupCast As TextTableGroup = curTable
                max = curGroupCast.TextGroupInfo.Data.DataMaxSize
                used = curGroupCast.DataLength
            ElseIf TypeOf curTable Is TextArrayGroup Then
                Dim curTextItemCast As TextArrayItem = curTextItem
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

    Public Function GetTextGroupInfosCount() As Integer
        Return RomManager.GetTextGroupInfos.Length
    End Function

    Public Function GetTextGroupInfoNames() As String()
        Return RomManager.GetTextGroupInfos.Select(Function(n) n.Name).ToArray
    End Function

    Public Function GetTextGroupInfos(tableName As String) As (name As String, encoding As String, isDialogGroup As Boolean, isTableGroup As Boolean, isArrayGroup As Boolean)
        Dim info As TextGroupInfo = RomManager.GetTextGroupInfos.FirstOrDefault(Function(n) n.Name = tableName)
        If info IsNot Nothing Then
            Dim isTable As Boolean = TypeOf info Is TextTableGroupInfo
            Dim isArray As Boolean = TypeOf info Is TextArrayGroupInfo
            Dim isDialog As Boolean = isTable AndAlso CType(info, TextTableGroupInfo).TableType = TextTableType.Dialogs
            Return (info.Name, info.EncodingString, isDialog, isTable, isArray)
        Else
            Return Nothing
        End If
    End Function

    Public Sub LoadTextGroup(tableName As String)
        RomManager.LoadTextGroup(tableName)
    End Sub

    Public Function GetTextGroupEntriesCount(tableName As String) As Integer
        Return RomManager.LoadTextGroup(tableName)?.Count
    End Function

    Public Function GetTextItemInfos(tableName As String, itemIndex As Integer) As (text As String, horizontalPosition As DialogHorizontalPosition, verticalPosition As DialogVerticalPosition, linesPerSite As Integer)
        Dim item As TextItem = RomManager.LoadTextGroup(tableName)?.ElementAtOrDefault(itemIndex)
        Dim hPos As DialogHorizontalPosition = Nothing
        Dim vPos As DialogVerticalPosition = Nothing
        Dim lines As Integer = Nothing

        If TypeOf item Is TextTableDialogItem Then
            Dim dialogItem As TextTableDialogItem = item
            hPos = dialogItem.HorizontalPosition
            vPos = dialogItem.VerticalPosition
            lines = dialogItem.LinesPerSite
        ElseIf TypeOf item Is TextTableItem Then
        ElseIf TypeOf item Is TextArrayItem Then
        End If

        Return (item.Text, hPos, vPos, lines)
    End Function

    Public Function GetTextNameList(tableName As String) As String()
        Dim nameList() As String = {}

        Select Case tableName
            Case "Dialogs"
                nameList = CreateDialogNameList()
            Case "Levels"
                nameList = CreateLevelNameList()
            Case "Acts"
                nameList = CreateActNameList()
        End Select

        Return nameList
    End Function

    Private Function CreateLevelNameList() As String()
        Dim list As New List(Of String)

        For lvlnumber As Integer = 1 To 26
            Dim item As String = ""

            Select Case lvlnumber
                Case Is <= 15
                    Dim lvltxt As String = lvlnumber
                    Dim name As String = RomManager.LevelInfoData.FirstOrDefault(Function(n) n.Number = lvltxt)?.Name
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

    Private Function CreateActNameList() As String()
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

    Private Function CreateDialogNameList() As String()
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

    Public Sub SetTextItemText(tableName As String, tableIndex As Integer, text As String)
        Dim group As TextGroup = GetTextGroup(tableName)
        Dim item As TextItem = group(tableIndex)

        item.Text = text.TrimEnd

        group.NeedToSave = True

        RaiseEvent TextItemChanged(New TextItemEventArgs(tableName, tableIndex))
    End Sub

    Public Sub SetTextItemDialogData(tableName As String, tableIndex As Integer, vPos As DialogVerticalPosition, hPos As DialogHorizontalPosition, linesPerSite As Integer)
        Dim group As TextGroup = GetTextGroup(tableName)
        Dim item As TextTableDialogItem = group(tableIndex)

        item.VerticalPosition = vPos
        item.HorizontalPosition = hPos
        item.LinesPerSite = linesPerSite

        group.NeedToSave = True

        RaiseEvent TextItemChanged(New TextItemEventArgs(tableIndex, tableIndex))
    End Sub

    Public Sub AddNewTextTableItem(tableName As String)
        Dim group As TextGroup = GetTextGroup(tableName)

        If TypeOf group Is TextTableGroup Then
            Dim item As TextItem = Nothing

            If CType(group, TextTableGroup).TextGroupInfo.TableType = TextTableType.Dialogs Then
                item = New TextTableDialogItem({}, group.TextGroupInfo)
            Else
                item = New TextTableItem({}, group.TextGroupInfo)
            End If

            group.Add(item)

            RaiseEvent TextItemAdded(New TextItemEventArgs(tableName, group.Count - 1))
        End If
    End Sub

    Public Sub RemoveTextTableItem(tableName As String, tableIndex As Integer)
        Dim group As TextGroup = GetTextGroup(tableName)

        group.RemoveAt(tableIndex)

        RaiseEvent TextItemRemoved(New TextItemEventArgs(tableName, tableIndex))
    End Sub

End Class
