Imports DevComponents.DotNetBar
Imports SM64Lib
Imports SM64Lib.ObjectBanks

Public Class CustomBankManager

    Private rommgr As RomManager
    Private objBank As CustomObjectBank
    Private curObj As CustomObject = Nothing

    Public Sub New(rommgr As RomManager, objBank As CustomObjectBank)
        InitializeComponent()
        UpdateAmbientColors
        Me.rommgr = rommgr
        Me.objBank = objBank
    End Sub

    Private Sub LoadList()
        ItemListBox1.Items.Clear()

        For Each obj As CustomObject In objBank.Objects
            AddItemToList(obj)
        Next
    End Sub

    Private Function AddItemToList(obj As CustomObject) As ButtonItem
        Dim item As New ButtonItem With {
            .Text = obj.ModelBankOffset,
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
            item = AddItemToList(obj)
            item.RaiseClick()
        End If
    End Sub

    Private Function ImportNewModel() As Boolean
        Return ImportNewModel(curObj)
    End Function

    Private Function ImportNewModel(obj As CustomObject) As Boolean
        Dim mdl As New ModelConverterGUI.MainModelConverter
        mdl.CheckBoxX_ConvertModel.Enabled = False

        If mdl.ShowDialog = DialogResult.OK Then
            obj.Model = mdl.ResModel
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub RemoveCollision()
        curObj.Model.Collision = Nothing
    End Sub

    Private Sub CustomBankManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadList()
    End Sub

    Private Sub RemoveCurObject()
        objBank.Objects.Remove(curObj)

        For Each item As ButtonItem In ItemListBox1.Items.AsParallel
            If item.Tag Is curObj Then
                ItemListBox1.Items.Remove(item)
            End If
        Next

        Panel2.Enabled = False
        curObj = Nothing
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        ImportNewModel()
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX1.TextChanged
        Try
            curObj.ModelID = ValueFromText(TextBoxX1.Text)
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

End Class
