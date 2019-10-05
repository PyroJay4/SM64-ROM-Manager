Imports DevComponents.DotNetBar

Public Class ObjectBankSelectorBox

    Public Event SelectedComboIndexChanged As EventHandler

    Public Property SelectedComboIndex As Integer
        Get
            Return ComboBox_ObjectBankSelector.SelectedIndex
        End Get
        Set(value As Integer)
            ComboBox_ObjectBankSelector.SelectedIndex = value
        End Set
    End Property

    Public Property SelectedComboItem As Object
        Get
            Return ComboBox_ObjectBankSelector.SelectedItem
        End Get
        Set(value As Object)
            ComboBox_ObjectBankSelector.SelectedItem = value
        End Set
    End Property

    Public ReadOnly Property ComboItems As ComboBox.ObjectCollection
        Get
            Return ComboBox_ObjectBankSelector.Items
        End Get
    End Property

    Public ReadOnly Property ContentItems As SubItemsCollection
        Get
            Return ListBoxAdv_Content.Items
        End Get
    End Property

    Private Sub ComboBox_ObjectBankSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ObjectBankSelector.SelectedIndexChanged
        RaiseEvent SelectedComboIndexChanged(Me, e)
    End Sub

End Class
