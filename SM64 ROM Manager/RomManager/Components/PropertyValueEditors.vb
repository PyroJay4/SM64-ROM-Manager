Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.Editors
Imports SM64Lib.Levels
Imports SM64Lib.TextValueConverter

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

    Friend Class ContentSelectorEditor
        Inherits PropertyValueEditor

        Public Delegate Sub EditorCreateEventHandler(sender As Object, e As EditorCreateEventArgs)
        Public Event EditorCreated As EditorCreateEventHandler
        Public Event EditorCreating As EditorCreateEventHandler

        Public Sub New()
        End Sub

        Public Overrides Function CreateEditor(propertyDescriptor As PropertyDescriptor, targetObject As Object) As IPropertyValueEditor
            Dim args As New EditorCreateEventArgs(propertyDescriptor)
            Dim editor As ComboBoxEditor

            RaiseEvent EditorCreating(Me, args)

            If args.Editor Is Nothing Then
                editor = New ComboBoxEditor
                editor.Style = eDotNetBarStyle.StyleManagerControlled
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownWidth = 250
            Else
                editor = args.Editor
            End If

            RaiseEvent EditorCreated(Me, New EditorCreateEventArgs(propertyDescriptor, editor))

            Return editor
        End Function

        Public Class EditorCreateEventArgs

            Public ReadOnly Property PropertyDescriptor As PropertyDescriptor
            Public Property Editor As ComboBoxEditor

            Public Sub New(propertyDescriptor As PropertyDescriptor)
                _PropertyDescriptor = propertyDescriptor
            End Sub

            Public Sub New(propertyDescriptor As PropertyDescriptor, editor As ComboBoxEditor)
                _PropertyDescriptor = propertyDescriptor
                _Editor = editor
            End Sub

        End Class

        Friend Class ComboBoxEditor
            Inherits ComboBoxEx
            Implements IPropertyValueEditor

            Public Event EditValueChanged As EventHandler Implements IPropertyValueEditor.EditValueChanged
            Public Event NeedValues As EventHandler '(sender As Object, values As Dictionary(Of String, Byte))

            Private settingValue As Boolean = False
            Private firstFocused As Boolean = False

            Public Property IntegerValueMode As Integer = -1
            Public Property ValueType As TypeCode = TypeCode.Int32

            Public Property EditorFont As Font Implements IPropertyValueEditor.EditorFont
                Get
                    Return Font
                End Get
                Set(value As Font)
                    Font = value
                End Set
            End Property

            Public ReadOnly Property IsEditorFocused As Boolean Implements IPropertyValueEditor.IsEditorFocused
                Get
                    Return Focused
                End Get
            End Property

            Public Property EditValue As Object Implements IPropertyValueEditor.EditValue
                Get
                    Dim val As Object

                    val = SelectedValue
                    If val Is Nothing Then
                        If Text <> "" Then
                            If DataSource Is Nothing AndAlso SelectedIndex > -1 Then
                                val = CType(Items(SelectedIndex), ComboItem).Tag
                            Else
                                val = ValueFromText(Text)
                            End If
                        Else
                            val = 0
                        End If
                    End If

                    Select Case ValueType
                        Case TypeCode.Int32
                            Return CInt(val)
                        Case TypeCode.UInt32
                            Return CUInt(val)
                        Case TypeCode.Byte
                            Return CByte(val)
                        Case TypeCode.SByte
                            Return CSByte(val)
                        Case TypeCode.Int16
                            Return CShort(val)
                        Case TypeCode.UInt16
                            Return CUShort(val)
                        Case TypeCode.Int64
                            Return CLng(val)
                        Case TypeCode.UInt64
                            Return CULng(val)
                    End Select

                    Return 0

                End Get
                Set(value As Object)
                    Dim found As Boolean = False

                    settingValue = True

                    OnNeedValues()

                    If DataSource Is Nothing Then
                        For i As Integer = 0 To Items.Count - 1
                            If Not found Then
                                Dim ci As ComboItem = DirectCast(Items(i), ComboItem)
                                If ci.Tag = value Then
                                    found = True
                                    SelectedItem = ci
                                End If
                            End If
                        Next
                    Else
                        Try
                            If value = 0 Then
                                Text = TextFromValue(value, IntegerValueMode)
                                found = True
                            Else
                                SelectedValue = value
                                SelectedValue = value
                                If SelectedValue Is Nothing Then
                                    Text = TextFromValue(value, IntegerValueMode)
                                End If
                                found = Not String.IsNullOrEmpty(Text)
                            End If
                        Catch ex As Exception
                        End Try
                    End If

                    If Not found Then
                        Text = TextFromValue(value, IntegerValueMode)
                    End If

                    settingValue = False
                End Set
            End Property

            Public Sub FocusEditor() Implements IPropertyValueEditor.FocusEditor
                Focus()
            End Sub

            Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
                MyBase.OnSelectedIndexChanged(e)
                OnEditSelectedValueChanged(e)
            End Sub

            Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
                MyBase.OnKeyDown(e)
                If e.KeyCode = Keys.Enter Then
                    OnEditSelectedValueChanged(e)
                End If
            End Sub

            Protected Overrides Sub OnLostFocus(e As EventArgs)
                MyBase.OnLostFocus(e)
                OnEditSelectedValueChanged(e)
            End Sub

            Private Sub OnEditSelectedValueChanged(ByVal e As EventArgs)
                If Not settingValue Then
                    RaiseEvent EditValueChanged(Me, e)
                End If
            End Sub

            Private Sub OnNeedValues()
                RaiseEvent NeedValues(Me, New EventArgs)
            End Sub

            Protected Overrides Sub Dispose(disposing As Boolean)
                'MyBase.Dispose(disposing)
            End Sub

        End Class

    End Class

    'Friend Class PropertyIntegerEditorX
    '    Inherits PropertyIntegerEditor

    '    Public Overrides Function CreateEditor(propertyDescriptor As PropertyDescriptor, targetObject As Object) As IPropertyValueEditor
    '        Dim editor As IPropertyValueEditor = MyBase.CreateEditor(propertyDescriptor, targetObject)

    '        'Set Horizontal Text Alignment
    '        editor.SetValue("InputHorizontalAlignment", eHorizontalAlignment.Left)

    '        Return editor
    '    End Function
    'End Class

    Friend Class PropertyIntegerEditorX
        Inherits PropertyValueEditor

        Public Property MaxValue As Integer = Integer.MaxValue
        Public Property MinValue As Integer = Integer.MinValue
        Public Property ShowUpDownButton As Boolean = False

        Public Overrides Function CreateEditor(propertyDescriptor As PropertyDescriptor, targetObject As Object) As IPropertyValueEditor
            Dim editor As New IntegerEditorX With {.MaxValue = MaxValue, .MinValue = MinValue, .ShowUpDown = ShowUpDownButton}

            editor.InputHorizontalAlignment = eHorizontalAlignment.Left
            editor.SetValue("AutoBorderSize", 1)
            editor.Height = 14
            editor.BackgroundStyle.Class = ""
            editor.BackColor = Color.Transparent
            editor.AllowEmptyState = False
            editor.FreeTextEntryToggleKey = Keys.E

            Return editor
        End Function

        Private Class IntegerEditorX
            Inherits IntegerInput
            Implements IPropertyValueEditor

            Public Event EditValueChanged As EventHandler Implements IPropertyValueEditor.EditValueChanged

            Private isSettingValue As Boolean = False

            Public Property EditorFont As Font Implements IPropertyValueEditor.EditorFont
                Get
                    Return Font
                End Get
                Set(value As Font)
                    Font = value
                End Set
            End Property

            Public ReadOnly Property IsEditorFocused As Boolean Implements IPropertyValueEditor.IsEditorFocused
                Get
                    Return Focused
                End Get
            End Property

            Public Property EditValue As Object Implements IPropertyValueEditor.EditValue
                Get
                    Return CShort(Value)
                End Get
                Set(value As Object)
                    isSettingValue = True
                    Me.Value = value
                    isSettingValue = False
                End Set
            End Property

            Public Sub FocusEditor() Implements IPropertyValueEditor.FocusEditor
                Focus()
            End Sub

            Protected Overrides Sub OnValueChanged(e As EventArgs)
                MyBase.OnValueChanged(e)
                If Not isSettingValue Then RaiseEvent EditValueChanged(Me, e)
            End Sub
        End Class
    End Class

    Friend Class TextEncodingEditor
        Inherits PropertyValueEditor

        Public Property DropDownWidth As Integer = 30
        Public Property AllowedContent As String()

        Public Sub New(allowedContent As String())
            Me.AllowedContent = allowedContent
        End Sub

        Public Overrides Function CreateEditor(propertyDescriptor As PropertyDescriptor, targetObject As Object) As IPropertyValueEditor
            Dim editor As New ComboBoxEditor

            editor.Style = eDotNetBarStyle.StyleManagerControlled
            editor.DrawMode = DrawMode.OwnerDrawFixed
            editor.DropDownStyle = ComboBoxStyle.DropDownList
            editor.FormattingEnabled = True
            editor.IntegralHeight = True
            editor.Items.AddRange(AllowedContent)
            editor.DropDownWidth = DropDownWidth

            Return editor
        End Function

        Friend Class ComboBoxEditor
            Inherits ComboBoxEx
            Implements IPropertyValueEditor

            Public Property EditorFont As Font Implements IPropertyValueEditor.EditorFont
                Get
                    Return Font
                End Get
                Set(value As Font)
                    Font = value
                End Set
            End Property

            Public ReadOnly Property IsEditorFocused As Boolean Implements IPropertyValueEditor.IsEditorFocused
                Get
                    Return Focused
                End Get
            End Property

            Public Property EditValue As Object Implements IPropertyValueEditor.EditValue
                Get
                    If SelectedIndex > -1 Then
                        Return SelectedItem
                    Else
                        Return Nothing
                    End If
                End Get
                Set(value As Object)
                    SelectedItem = value
                End Set
            End Property

            Public Event EditValueChanged As EventHandler Implements IPropertyValueEditor.EditValueChanged

            Public Sub FocusEditor() Implements IPropertyValueEditor.FocusEditor
                Focus()
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
