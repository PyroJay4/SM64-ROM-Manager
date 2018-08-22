Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports SM64Lib.Levels

Namespace PropertyValueEditors

    Friend Enum SelectedTypes
        SelectedItem
        SelectedIndex
    End Enum

    Friend Class ComboBoxPropertyEditor
        Inherits PropertyValueEditor

        Public Property DropDownWidth As Integer = 0
        Public Property SelectedType As SelectedTypes = SelectedTypes.SelectedItem
        Public Property Items As Object

        Public Sub New()
            Items = New Object() {}
        End Sub
        Public Sub New(items As Object())
            Me.Items = items
        End Sub

        Public Overrides Function CreateEditor(propertyDescriptor As PropertyDescriptor, targetObject As Object) As IPropertyValueEditor
            Dim editor As New ComboBoxEditor

            editor.Style = eDotNetBarStyle.StyleManagerControlled
            editor.DrawMode = DrawMode.OwnerDrawFixed
            editor.DropDownStyle = ComboBoxStyle.DropDownList
            editor.FormattingEnabled = True
            editor.IntegralHeight = True
            editor.Items.AddRange(Items)
            editor.DropDownWidth = DropDownWidth
            editor.SelectedType = SelectedType

            Return editor
        End Function

        Friend Class ComboBoxEditor
            Inherits ComboBoxEx
            Implements IPropertyValueEditor

            Public Property SelectedType As SelectedTypes = SelectedTypes.SelectedItem

            Public Property EditorFont As Font Implements IPropertyValueEditor.EditorFont
                Get
                    Return Me.Font
                End Get
                Set(value As Font)
                    Me.Font = value
                End Set
            End Property

            Public ReadOnly Property IsEditorFocused As Boolean Implements IPropertyValueEditor.IsEditorFocused
                Get
                    Return Me.Focused
                End Get
            End Property

            Public Property EditValue As Object Implements IPropertyValueEditor.EditValue
                Get
                    If Me.SelectedIndex >= 0 Then
                        Select Case SelectedType
                            Case SelectedTypes.SelectedIndex
                                Return Me.SelectedIndex.ToString
                            Case Else 'SelectedTypes.SelectedItem
                                Return Me.SelectedItem
                        End Select
                    Else
                        Return Nothing
                    End If
                End Get
                Set(value As Object)
                    Select Case SelectedType
                        Case SelectedTypes.SelectedIndex
                            Me.SelectedIndex = CInt(value)
                        Case SelectedTypes.SelectedItem
                            Me.SelectedItem = value
                    End Select
                End Set
            End Property

            Public Event EditValueChanged As EventHandler Implements IPropertyValueEditor.EditValueChanged

            Public Sub FocusEditor() Implements IPropertyValueEditor.FocusEditor
                Me.Focus()
            End Sub

            Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
                OnEditSelectedValueChanged(e)
                MyBase.OnSelectedIndexChanged(e)
            End Sub

            Protected Overrides Sub OnSelectedItemChanged(e As EventArgs)
                OnEditSelectedValueChanged(e)
                MyBase.OnSelectedItemChanged(e)
            End Sub

            Private Sub OnEditSelectedValueChanged(ByVal e As EventArgs)
                RaiseEvent EditValueChanged(Me, e)
            End Sub

        End Class

    End Class

    Friend Class LevelsEnumEditor
        Inherits PropertyValueEditor

        Public Property DropDownWidth As Integer = 0
        Public Property Items As Object
        Public Property Levels As List(Of Levels)

        Public Sub New()
            Items = New Object() {}
        End Sub
        Public Sub New(items As Object(), levels As List(Of Levels))
            Me.Items = items
            Me.Levels = levels
        End Sub

        Public Overrides Function CreateEditor(propertyDescriptor As PropertyDescriptor, targetObject As Object) As IPropertyValueEditor
            Dim editor As New ComboBoxEditor

            editor.Style = eDotNetBarStyle.StyleManagerControlled
            editor.DrawMode = DrawMode.OwnerDrawFixed
            editor.DropDownStyle = ComboBoxStyle.DropDownList
            editor.FormattingEnabled = True
            editor.IntegralHeight = True
            editor.Items.AddRange(Items)
            editor.DropDownWidth = DropDownWidth
            editor.Levels = Levels

            Return editor
        End Function

        Friend Class ComboBoxEditor
            Inherits ComboBoxEx
            Implements IPropertyValueEditor

            Public Property Levels As List(Of Levels) = Nothing

            Public Property EditorFont As Font Implements IPropertyValueEditor.EditorFont
                Get
                    Return Me.Font
                End Get
                Set(value As Font)
                    Me.Font = value
                End Set
            End Property

            Public ReadOnly Property IsEditorFocused As Boolean Implements IPropertyValueEditor.IsEditorFocused
                Get
                    Return Me.Focused
                End Get
            End Property

            Public Property EditValue As Object Implements IPropertyValueEditor.EditValue
                Get
                    If Me.SelectedIndex >= 0 Then
                        Return Levels(Me.SelectedIndex)
                    Else
                        Return Nothing
                    End If
                End Get
                Set(value As Object)
                    Me.SelectedIndex = Levels.IndexOf(value)
                End Set
            End Property

            Public Event EditValueChanged As EventHandler Implements IPropertyValueEditor.EditValueChanged

            Public Sub FocusEditor() Implements IPropertyValueEditor.FocusEditor
                Me.Focus()
            End Sub

            Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
                OnEditSelectedValueChanged(e)
                MyBase.OnSelectedIndexChanged(e)
            End Sub

            Protected Overrides Sub OnSelectedItemChanged(e As EventArgs)
                OnEditSelectedValueChanged(e)
                MyBase.OnSelectedItemChanged(e)
            End Sub

            Private Sub OnEditSelectedValueChanged(ByVal e As EventArgs)
                RaiseEvent EditValueChanged(Me, e)
            End Sub

        End Class

    End Class

End Namespace
