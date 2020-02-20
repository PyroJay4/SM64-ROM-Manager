Imports DevComponents.DotNetBar

Public Class AddressListEditor

    'P r o p e r t i e s

    Public Property AddressList As IList(Of Integer)

    Private WriteOnly Property EnableAddressItemControls As Boolean
        Set
            ButtonX_Entfernen.Enabled = Value
        End Set
    End Property

    'C o n s t r u c t o r

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors
        EnableAddressItemControls = False
    End Sub

    'F e a t u r e s

    Private Sub LoadAddressList()
        ItemPanel_Values.BeginUpdate()
        ItemPanel_Values.Items.Clear()

        For Each addr As Integer In AddressList
            ItemPanel_Values.Items.Add(GetAddressItem(addr))
        Next

        ItemPanel_Values.EndUpdate()
        ItemPanel_Values.Refresh()
    End Sub

    Private Function GetAddressItem(addr As Integer) As BaseItem
        Dim item As New ButtonItem With {
                .Text = TextFromValue(addr)
            }

        AddHandler item.Click,
            Sub(sender, e)
                ItemPanel_Values.SelectedItem = sender
            End Sub

        Return item
    End Function

    Private Function GetSelectedIndex() As Integer
        Return ItemPanel_Values.SelectedIndex
    End Function

    Private Function GetSelectedAddress() As Integer
        Return AddressList.ElementAtOrDefault(GetSelectedIndex)
    End Function

    Private Sub SetSelectedAddress(addr As Integer)
        Dim index As Integer = GetSelectedIndex()

        If index > -1 Then
            AddressList(index) = addr
            UpdateButtonText(index, addr)
            ItemPanel_Values.Refresh()
        End If
    End Sub

    Private Sub UpdateButtonText(index As Integer, addr As Integer)
        ItemPanel_Values.Items(index).Text = TextFromValue(addr)
    End Sub

    Private Sub AddAddress(addr As Integer)
        'Add to addresslist
        AddressList.Add(addr)

        'Add list item
        Dim item As BaseItem = GetAddressItem(addr)
        ItemPanel_Values.Items.Add(item)
        ItemPanel_Values.SelectedItem = item
        ItemPanel_Values.Refresh()
    End Sub

    Private Sub RemoveSelectedAddress()
        Dim index As Integer = GetSelectedIndex()

        If index > -1 Then
            'Remove from addresslist
            AddressList.RemoveAt(index)

            'Remove item
            ItemPanel_Values.Items.RemoveAt(index)
            ItemPanel_Values.SelectedIndex = -1
            ItemPanel_Values.Refresh()
        End If
    End Sub

    'G u i

    Private Sub ButtonX_Hinzufügen_Click(sender As Object, e As EventArgs) Handles ButtonX_Hinzufügen.Click
        AddAddress(ValueFromText(TextBoxX_Value.Text))
    End Sub

    Private Sub ButtonX_Entfernen_Click(sender As Object, e As EventArgs) Handles ButtonX_Entfernen.Click
        RemoveSelectedAddress()
    End Sub

    Private Sub TextBoxX_Value_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_Value.TextChanged
        SetSelectedAddress(ValueFromText(TextBoxX_Value.Text))
    End Sub

    Private Sub ItemPanel_Values_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemPanel_Values.SelectedIndexChanged
        TextBoxX_Value.Text = TextFromValue(GetSelectedAddress)
        EnableAddressItemControls = ItemPanel_Values.SelectedItem IsNot Nothing
    End Sub

    Private Sub AddressListEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadAddressList()
    End Sub

End Class
