Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Conversion.Fast3DWriting

Public Class CustomDisplaylistEntryEditor

    'E v e n t s

    Public Event RemoveButtonClicked(sender As CustomDisplaylistEntryEditor)

    'F i e l d s   &   A u t o m a t i c   P r o p e r t i e s

    Private isLoading As Boolean = True
    Public ReadOnly Property Props As DisplaylistProps

    'P r o p e r t i e s

    Private Property SelectedID As Integer
        Get
            Return IntegerInput_ID.Value
        End Get
        Set(value As Integer)
            IntegerInput_ID.Value = value
        End Set
    End Property

    Private Property SelectedLayer As DefaultGeolayers
        Get
            Return CType(ComboBoxEx_Layer.SelectedItem, ComboItem).Tag
        End Get
        Set(value As DefaultGeolayers)
            For Each item As ComboItem In ComboBoxEx_Layer.Items
                If item.Tag = value Then
                    ComboBoxEx_Layer.SelectedItem = item
                End If
            Next
        End Set
    End Property

    'C o n s t r u c t o r

    Public Sub New(props As DisplaylistProps)
        Me.Props = props
        InitializeComponent()
        StyleManager.UpdateAmbientColors(Me)
        ComboBoxEx_Layer.Items.AddRange(GetDefaultGeolayerComboItems)
        LoadProps()
        isLoading = False
    End Sub

    'F e a t u r e s

    Private Sub LoadProps()
        SelectedLayer = Props.Layer
        SelectedID = Props.ID
    End Sub

    'G U I

    Private Sub ComboBoxEx_Layer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx_Layer.SelectedIndexChanged
        If Not isLoading Then
            Props.Layer = SelectedLayer
        End If
    End Sub

    Private Sub IntegerInput_ID_ValueChanged(sender As Object, e As EventArgs) Handles IntegerInput_ID.ValueChanged
        If Not isLoading Then
            Props.ID = SelectedID
        End If
    End Sub

    Private Sub ButtonX_Remove_Click(sender As Object, e As EventArgs) Handles ButtonX_Remove.Click
        RaiseEvent RemoveButtonClicked(Me)
    End Sub

End Class
