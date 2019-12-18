Imports DevComponents.DotNetBar
Imports SM64Lib.Levels
Imports SM64Lib.TextValueConverter
Imports System.ComponentModel
Imports SM64Lib.Levels.ScrolTex
Imports SM64_ROM_Manager.PropertyValueEditors
Imports SM64Lib.Configuration

Public Class ScrollTexEditor

    Public Event ScrollTexAdded As EventHandler
    Public Event ScrollTexRemoved As EventHandler
    Public Event ScrollTexChanged As EventHandler

    Private ReadOnly cArea As LevelArea
    Private ReadOnly areaConfig As LevelAreaConfig

    Public Sub New(area As LevelArea, areaConfig As LevelAreaConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        UpdateAmbientColors

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        cArea = area
        Me.areaConfig = areaConfig
    End Sub

    Private Sub ScrollTexEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadScrollTexts()
    End Sub

    Private Sub AdvPropertyGrid1_ConvertFromStringToPropertyValue(sender As Object, e As ConvertValueEventArgs) Handles AdvPropertyGrid1.ConvertFromStringToPropertyValue
        Select Case e.PropertyDescriptor.PropertyType
            Case GetType(System.Boolean)
                If e.StringValue = "Yes" Then
                    e.TypedValue = True
                Else
                    e.TypedValue = False
                End If
                e.IsConverted = True

            Case GetType(System.Byte)
                e.TypedValue = CByte(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(System.SByte)
                e.TypedValue = CSByte(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(Int16)
                e.TypedValue = CShort(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(UInt16)
                e.TypedValue = CUShort(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(Int32)
                e.TypedValue = CInt(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(UInt32)
                e.TypedValue = CUInt(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(System.Single)
                e.TypedValue = CSng(e.StringValue.Trim)
                e.IsConverted = True

            Case GetType(System.Double)
                e.TypedValue = CDbl(e.StringValue.Trim)
                e.IsConverted = True

            Case GetType(System.Decimal)
                e.TypedValue = CDec(e.StringValue.Trim)
                e.IsConverted = True

        End Select
    End Sub
    Private Sub AdvPropertyGrid1_ConvertPropertyValueToString(sender As Object, e As ConvertValueEventArgs) Handles AdvPropertyGrid1.ConvertPropertyValueToString
        Select Case e.PropertyDescriptor.PropertyType
            Case GetType(System.Boolean)
                If e.TypedValue = True Then
                    e.StringValue = "Yes"
                Else
                    e.StringValue = "No"
                End If
                e.IsConverted = True

            Case GetType(System.Byte), GetType(System.SByte), GetType(Int16), GetType(UInt16), GetType(Int32), GetType(UInt32)
                e.StringValue = TextFromValue(e.TypedValue)
                e.IsConverted = True

        End Select
    End Sub

    Private Sub AdvPropertyGrid1_PropertyValueChanged(sender As Object, e As PropertyChangedEventArgs) Handles AdvPropertyGrid1.PropertyValueChanged
        UpdateAllListViewItems()
        AdvPropertyGrid1.RefreshPropertyValues()
        RaiseEvent ScrollTexChanged(Me, New EventArgs)
    End Sub

    Private Sub LoadScrollTexts()
        For Each scrollTex As ManagedScrollingTexture In cArea.ScrollingTextures
            AddListViewItem(scrollTex)
        Next
        UpdateAllListViewItems()

        If ListViewEx_LM_ScrollTexList.Items.Count > 0 Then
            ListViewEx_LM_ScrollTexList.Items(0).Selected = True
        End If
    End Sub

    Private Sub AddListViewItem(scrollTex As ManagedScrollingTexture)
        Dim lvi As New ListViewItem
        lvi.Tag = New ScrollTexPropertyClass(scrollTex)

        For i As Integer = 1 To 6
            Dim lvisub As New ListViewItem.ListViewSubItem
            lvi.SubItems.Add(lvisub)
        Next

        ListViewEx_LM_ScrollTexList.Items.Add(lvi)
    End Sub

    Private Sub UpdateAllListViewItems()
        Dim counter As Integer = 1

        For Each item As ListViewItem In ListViewEx_LM_ScrollTexList.Items
            Dim scrollTex As ScrollTexPropertyClass = item.Tag

            SetLvGroup(item, scrollTex.GroupID)

            item.SubItems(0).Text = counter
            item.SubItems(1).Text = scrollTex.Behavior.ToString
            item.SubItems(2).Text = scrollTex.Type.ToString
            item.SubItems(3).Text = scrollTex.CycleDuration
            item.SubItems(4).Text = scrollTex.ScrollingSpeed
            item.SubItems(5).Text = ValueFromText(scrollTex.VertexPointer)
            item.SubItems(6).Text = scrollTex.FacesCount

            counter += 1
        Next
    End Sub

    Private Sub SetLvGroup(item As ListViewItem, groupID As Short)
        Dim lvg As ListViewGroup = Nothing

        For Each lvgg As ListViewGroup In ListViewEx_LM_ScrollTexList.Groups
            If lvg Is Nothing AndAlso lvgg.Tag = groupID Then
                lvg = lvgg
            End If
        Next

        If lvg Is Nothing Then
            Dim texName As String = "Unknown Material Name"
            areaConfig.ScrollingNames.TryGetValue(groupID, texName)

            lvg = New ListViewGroup With {
                .Tag = groupID,
                .Header = $"Group {groupID} - {texName}"
            }
            ListViewEx_LM_ScrollTexList.Groups.Add(lvg)
        End If

        item.Group = lvg
    End Sub

    Private Sub ListViewEx_LM_ScrollTexList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_LM_ScrollTexList.SelectedIndexChanged
        Dim objs As New List(Of ScrollTexPropertyClass)

        For Each item As ListViewItem In ListViewEx_LM_ScrollTexList.SelectedItems
            objs.Add(item.Tag)
        Next

        AdvPropertyGrid1.SelectedObjects = objs.ToArray
    End Sub

    Private Sub ButtonItem43_Click(sender As Object, e As EventArgs) Handles ButtonItem43.Click
        Dim itemsToRemove As New List(Of ListViewItem)

        For Each item As ListViewItem In ListViewEx_LM_ScrollTexList.SelectedItems
            Dim scrollTex As ScrollTexPropertyClass = item.Tag
            cArea.ScrollingTextures.Remove(scrollTex.ScrollingTexture)
            itemsToRemove.Add(item)
        Next

        For Each item As ListViewItem In itemsToRemove
            ListViewEx_LM_ScrollTexList.Items.Remove(item)
        Next

        RaiseEvent ScrollTexRemoved(Me, New EventArgs)
    End Sub

    Private Sub ButtonItem44_Click(sender As Object, e As EventArgs) Handles ButtonItem44.Click
        Dim scrollTex As New ManagedScrollingTexture
        cArea.ScrollingTextures.Add(scrollTex)
        AddListViewItem(scrollTex)
        UpdateAllListViewItems()
        RaiseEvent ScrollTexAdded(Me, New EventArgs)
    End Sub

    Private Sub ListViewEx_LM_ScrollTexList_MouseClick(sender As Object, e As MouseEventArgs) Handles ListViewEx_LM_ScrollTexList.MouseUp
        If e.Button = MouseButtons.Right Then
            ButtonItem_CM.Popup(Cursor.Position)
        End If
    End Sub

End Class
