Imports System.Drawing
Imports DevComponents.DotNetBar
Imports SM64Lib.Model.Conversion.Fast3DWriting

Public Class CustomDisplaylistEditor

    'F i e l d s

    Private ReadOnly propsList As IList(Of DisplaylistProps)

    'C o n s t r c u t o r s

    Public Sub New(propsList As IList(Of DisplaylistProps))
        Me.propsList = propsList
        InitializeComponent()
    End Sub

    'F e a t u r e s

    Private Function GetItem(props As DisplaylistProps) As BaseItem
        Dim editorControl As New CustomDisplaylistEntryEditor(props) With {
            .BackColor = Color.Transparent
        }
        AddHandler editorControl.RemoveButtonClicked, AddressOf RemoveProps

        Dim containerItem As New ControlContainerItem With {
            .Control = editorControl,
            .Stretch = True
        }

        Return containerItem
    End Function

    Private Sub LoadAllProps()
        ItemPanel1.BeginUpdate()

        'Clear list
        ItemPanel1.Items.Clear()

        'Add Props
        For Each props As DisplaylistProps In propsList
            ItemPanel1.Items.Add(GetItem(props))
        Next

        'Add 'New' Button
        Dim btnNew As New ButtonItem With {
            .Text = "New",
            .Image = My.Resources.Add_16px,
            .ButtonStyle = eButtonStyle.ImageAndText
        }
        AddHandler btnNew.Click, AddressOf AddNewProps
        ItemPanel1.Items.Add(btnNew)

        ItemPanel1.EndUpdate()
    End Sub

    Private Sub AddNewProps()
        ItemPanel1.BeginUpdate()

        'Find new ID
        Dim id As Integer = 0
        Dim ende As Boolean = False
        Do Until ende
            ende = True
            For Each props2 As DisplaylistProps In propsList.OrderBy(Function(n) n.ID)
                If props2.ID = id Then
                    id = props2.ID + 1
                    ende = False
                End If
            Next
        Loop

        'Create Props & Items
        Dim props As New DisplaylistProps(id)
        Dim item As BaseItem = GetItem(props)

        propsList.Add(props)
        ItemPanel1.Items.Insert(ItemPanel1.Items.Count - 1, item)

        ItemPanel1.EndUpdate()
    End Sub

    Private Sub RemoveProps(editor As CustomDisplaylistEntryEditor)
        ItemPanel1.BeginUpdate()

        'Remove Item
        Dim itemToRemove As BaseItem = Nothing
        For Each item As BaseItem In ItemPanel1.Items
            If itemToRemove Is Nothing AndAlso TypeOf item Is ControlContainerItem AndAlso CType(item, ControlContainerItem).Control Is editor Then
                itemToRemove = item
            End If
        Next
        ItemPanel1.Items.Remove(itemToRemove)

        'Remove Props
        propsList.Remove(editor.Props)

        ItemPanel1.EndUpdate()
    End Sub

    'G U I

    Private Sub CustomDisplaylistEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadAllProps()
    End Sub

End Class
