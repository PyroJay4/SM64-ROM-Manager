Imports DevComponents.DotNetBar
Imports SM64Lib
Imports SM64Lib.ObjectBanks

Public Class CustomBankManager

    'E v e n t s

    Public Event ObjectAdded As EventHandler
    Public Event ObjectRemoved As EventHandler

    'P r i v a t e   M e m b e r s

    Private rommgr As RomManager
    Private objBank As CustomObjectBank
    Private curObj As CustomObject = Nothing

    'C o n s t r u c t o r s

    Public Sub New(rommgr As RomManager, objBank As CustomObjectBank)
        InitializeComponent()
        UpdateAmbientColors
        Panel2.Enabled = False
        Me.rommgr = rommgr
        Me.objBank = objBank
    End Sub

    'F e a t u r e s

    Private Sub LoadList()
        ItemListBox1.SuspendLayout()
        ItemListBox1.Items.Clear()

        For Each obj As CustomObject In objBank.Objects
            AddItemToList(obj)
        Next

        ItemListBox1.ResumeLayout()
        ItemListBox1.Refresh()
    End Sub

    Private Function TextForButtonItem(obj As CustomObject) As String
        Return $"Model-ID: {TextFromValue(obj.ModelID)} - Rom: {TextFromValue(obj.ModelBankOffset)}"
    End Function

    Private Function AddItemToList(obj As CustomObject) As ButtonItem
        Dim item As New ButtonItem With {
            .Text = TextForButtonItem(obj),
            .Tag = obj
        }

        AddHandler item.Click, Sub(sender As ButtonItem, e As EventArgs) If sender.Checked Then LoadCustomObject(sender.Tag)

        ItemListBox1.Items.Add(item)

        Return item
    End Function

    Private Sub LoadCustomObject(obj As CustomObject)
        curObj = obj
        Panel2.Enabled = True
        TextBoxX1.Text = TextFromValue(obj.ModelID)
    End Sub

    Private Sub CreateCustomObject()
        Dim obj As New CustomObject
        Dim item As ButtonItem

        If ImportNewModel(obj) Then
            objBank.Objects.Add(obj)
            item = AddItemToList(obj)
            item.RaiseClick()
            RaiseEvent ObjectAdded(Me, New EventArgs)
        End If
    End Sub

    Private Function ImportNewModel() As Boolean
        Return ImportNewModel(curObj)
    End Function

    Private Function ImportNewModel(obj As CustomObject) As Boolean
        If obj IsNot Nothing Then
            Dim resMdl = ModelConverterGUI.GetModelViaModelConverter(False, obj.Model IsNot Nothing)

            If resMdl IsNot Nothing Then
                If obj.Model Is Nothing OrElse (resMdl?.hasCollision AndAlso resMdl?.hasVisualMap) Then
                    obj.Model = resMdl?.mdl
                ElseIf resMdl?.hasCollision Then
                    obj.Model.Collision = obj.Model.Collision
                ElseIf resMdl?.hasVisualMap Then
                    obj.Model.Fast3DBuffer = obj.Model.Fast3DBuffer
                End If
                Return True
            End If
        End If

        Return False
    End Function

    Private Sub RemoveCollision()
        curObj.Model.Collision = Nothing
    End Sub

    Private Sub RemoveCurObject()
        objBank.Objects.Remove(curObj)

        Dim itr As New List(Of BaseItem)
        For Each item As ButtonItem In ItemListBox1.Items
            If item.Tag Is curObj Then
                itr.Add(item)
            End If
        Next
        For Each item In itr
            ItemListBox1.Items.Remove(item)
        Next

        Panel2.Enabled = False
        curObj = Nothing

        RaiseEvent ObjectRemoved(Me, New EventArgs)
    End Sub

    Private Sub UpdateButtonItems()
        Dim selItem As ButtonItem = ItemListBox1.SelectedItem
        Dim updateItem =
            Sub(btn As ButtonItem)
                If btn IsNot Nothing Then
                    btn.Text = TextForButtonItem(btn.Tag)
                End If
            End Sub

        If selItem IsNot Nothing Then
            updateItem(selItem)
        Else
            For Each btn As ButtonItem In ItemListBox1.Items
                updateItem(btn)
            Next
        End If

        ItemListBox1.Refresh()
    End Sub

    'G U I

    Private Sub CustomBankManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadList()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        ImportNewModel()
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX1.TextChanged
        Try
            curObj.ModelID = ValueFromText(TextBoxX1.Text)
            UpdateButtonItems()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        RemoveCollision()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If MessageBoxEx.Show("Do you realy want to remove this custom object? You will not be able to restore it.", "Remove Custom Object", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            RemoveCurObject()
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        CreateCustomObject()
    End Sub

End Class
