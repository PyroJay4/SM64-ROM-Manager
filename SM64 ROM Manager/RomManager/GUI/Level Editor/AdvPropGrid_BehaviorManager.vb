Imports DevComponents.Editors
Imports SM64_ROM_Manager.PropertyValueEditors
Imports SM64_ROM_Manager.SettingsManager
Imports TextValueConverter
Imports SM64Lib.Objects
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Namespace LevelEditor

    Friend Class AdvPropGrid_ObjectPropertiesHelper

        Private behaviorPropName, bParamPropName As String
        Private hasFirstFocued As Boolean = False
        Private ReadOnly registredHandlers As New Dictionary(Of String, EventHandler)
        Private ReadOnly myObjectCombos As ObjectComboList
        Private WithEvents AdvPropertyGrid1 As AdvPropertyGrid
        Friend WithEvents CbEditorBParam1 As ContentSelectorEditor.ComboBoxEditor = Nothing
        Friend WithEvents CbEditorBParam2 As ContentSelectorEditor.ComboBoxEditor = Nothing
        Friend WithEvents CbEditorBehavAddr As ContentSelectorEditor.ComboBoxEditor = Nothing
        Private bp1Values, bp2Values As Dictionary(Of String, Byte)

        Private ReadOnly Property CurBehavAddr As UInteger
            Get
                If CbEditorBehavAddr IsNot Nothing Then
                    Return CbEditorBehavAddr.EditValue
                End If
                Return 0
            End Get
        End Property

        Public Sub New(advPropGrid As AdvPropertyGrid, objComboList As ObjectComboList, behaviorPropName As String, bParamPropName As String)
            AdvPropertyGrid1 = advPropGrid
            myObjectCombos = objComboList
            Me.behaviorPropName = behaviorPropName
            Me.bParamPropName = bParamPropName

            LoadBehaviorInfosIfEmpty()
            LoadObjectCombosIfEmpty()
            LoadComboBoxObjComboEntries(objComboList)

            'Add B. Param Editors to Property Grid
            Dim bpeditor As New ContentSelectorEditor
            AddHandler bpeditor.EditorCreated, AddressOf ContentSelectorEditor_EditorCreated
            AddHandler bpeditor.EditorCreating, AddressOf ContentSelectorEditor_EditorCreating
            Dim bp1PropSet As New PropertySettings(bParamPropName & 1)
            Dim bp2PropSet As New PropertySettings(bParamPropName & 2)
            bp1PropSet.ValueEditor = bpeditor
            bp2PropSet.ValueEditor = bpeditor
            AdvPropertyGrid1.PropertySettings.Add(bp1PropSet)
            AdvPropertyGrid1.PropertySettings.Add(bp2PropSet)

            'Add Behavior Address Editor to Property Grid
            Dim behavaddreditor As New ContentSelectorEditor
            AddHandler behavaddreditor.EditorCreating, AddressOf ContentSelectorEditor_EditorCreating
            AddHandler behavaddreditor.EditorCreated, AddressOf ContentSelectorEditor_EditorCreated
            Dim behavaddrPropSet As New PropertySettings(behaviorPropName)
            behavaddrPropSet.ValueEditor = behavaddreditor
            AdvPropertyGrid1.PropertySettings.Add(behavaddrPropSet)
        End Sub

        Public Sub LoadComboBoxObjComboEntries(objComboList As ObjectComboList)
            Dim myObjectCombosString As New List(Of String)

            For Each c As ObjectCombo In objComboList
                myObjectCombosString.Add(c.Name)
            Next

            'Set Property Settings on AdvPropertyGrid1
            Dim propSet As New PropertySettings("ObjectCombo")
            Dim editor As New ComboBoxPropertyEditor(myObjectCombosString.ToArray)
            editor.DropDownWidth = 300
            propSet.ValueEditor = editor
            AdvPropertyGrid1.PropertySettings.Add(propSet)
        End Sub

        Public Sub RegisterEditorHandler(cbe As String, handler As EventHandler)
            registredHandlers.Add(cbe, handler)
        End Sub

        Private Sub FlushEditorHandlers()
            Dim canBeRemoved As New List(Of String)

            For Each kvp As KeyValuePair(Of String, EventHandler) In registredHandlers
                Dim editor As ContentSelectorEditor.ComboBoxEditor

                Select Case kvp.Key
                    Case NameOf(CbEditorBParam1)
                        editor = CbEditorBParam1
                    Case NameOf(CbEditorBParam2)
                        editor = CbEditorBParam2
                    Case Else
                        editor = Nothing
                End Select

                If editor IsNot Nothing Then
                    AddHandler editor.NeedValues, kvp.Value
                End If
            Next

            For Each k As String In canBeRemoved
                registredHandlers.Remove(k)
            Next
        End Sub

        Private Sub ContentSelectorEditor_EditorCreated(sender As Object, e As ContentSelectorEditor.EditorCreateEventArgs)
            Select Case e.PropertyDescriptor.Name.ToString
                Case bParamPropName & 1
                    If CbEditorBParam1 IsNot e.Editor Then
                        CbEditorBParam1 = e.Editor
                        CbEditorBParam1.ValueType = TypeCode.Byte
                        CbEditorBParam1.DisplayMember = NameOf(BehaviorInfo.BParamValue.ValueText)
                        CbEditorBParam1.ValueMember = NameOf(BehaviorInfo.BParamValue.Value)
                        CbEditorBParam1.DropDownColumns = NameOf(BehaviorInfo.BParamValue.ValueText) & "," & NameOf(BehaviorInfo.BParamValue.Name)
                        CbEditorBParam1.DropDownColumnsHeaders = $"Value{vbNewLine}Name"
                        CbEditorBParam1.DropDownHeight = 300
                        CbEditorBParam1.DropDownWidth = 200
                    End If
                Case bParamPropName & 2
                    If CbEditorBParam2 IsNot e.Editor Then
                        CbEditorBParam2 = e.Editor
                        CbEditorBParam2.ValueType = TypeCode.Byte
                        CbEditorBParam2.DisplayMember = NameOf(BehaviorInfo.BParamValue.ValueText)
                        CbEditorBParam2.ValueMember = NameOf(BehaviorInfo.BParamValue.Value)
                        CbEditorBParam2.DropDownColumns = NameOf(BehaviorInfo.BParamValue.ValueText) & "," & NameOf(BehaviorInfo.BParamValue.Name)
                        CbEditorBParam2.DropDownColumnsHeaders = $"Value{vbNewLine}Name"
                        CbEditorBParam2.DropDownHeight = 300
                        CbEditorBParam2.DropDownWidth = 200
                    End If
                Case behaviorPropName
                    If CbEditorBehavAddr IsNot e.Editor Then
                        CbEditorBehavAddr = e.Editor
                        CbEditorBehavAddr.ValueType = TypeCode.UInt32
                        CbEditorBehavAddr.IntegerValueMode = Math.Max(Settings.General.IntegerValueMode, 1)
                        CbEditorBehavAddr.DisplayMember = NameOf(BehaviorInfo.BehaviorAddressText)
                        CbEditorBehavAddr.ValueMember = NameOf(BehaviorInfo.BehaviorAddress)
                        CbEditorBehavAddr.DropDownColumns = NameOf(BehaviorInfo.BehaviorAddressText) & "," & NameOf(BehaviorInfo.Name)
                        CbEditorBehavAddr.DropDownColumnsHeaders = $"Address{vbNewLine}Name"
                        CbEditorBehavAddr.DropDownHeight = 400
                        CbEditorBehavAddr.DropDownWidth = 300
                        CbEditorBehavAddr.DataSource = BehaviorInfos
                        'CbEditorBehavAddr.MultiColumnDisplayControl.Columns(0).AutoSize()
                        'LoadBehaviorAddressesList()
                    End If
            End Select
            FlushEditorHandlers()
        End Sub

        Private Sub ContentSelectorEditor_EditorCreating(sender As Object, e As ContentSelectorEditor.EditorCreateEventArgs)
            Select Case e.PropertyDescriptor.Name
                Case bParamPropName & 1
                    If CbEditorBParam1 IsNot Nothing Then
                        e.Editor = CbEditorBParam1
                    End If
                Case bParamPropName & 2
                    If CbEditorBParam2 IsNot Nothing Then
                        e.Editor = CbEditorBParam2
                    End If
                Case behaviorPropName
                    If CbEditorBehavAddr IsNot Nothing Then
                        e.Editor = CbEditorBehavAddr
                    End If
            End Select
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
            If e.IsConverted Then Return

            If e.PropertyName.StartsWith(bParamPropName) Then
                Return
            End If

            Select Case e.PropertyDescriptor.PropertyType
                Case GetType(System.Boolean)
                    If e.TypedValue = True Then
                        e.StringValue = "Yes"
                    Else
                        e.StringValue = "No"
                    End If
                    e.IsConverted = True

                Case GetType(System.Byte), GetType(SByte), GetType(Int16), GetType(UInt16), GetType(Int32), GetType(UInt32)
                    If e.PropertyName = behaviorPropName Then
                        'e.StringValue = TextFromValue(e.TypedValue, If(Settings.General.IntegerValueMode >= 1, Settings.General.IntegerValueMode, 1))
                        'e.IsConverted = True
                    Else
                        e.StringValue = TextFromValue(e.TypedValue)
                        e.IsConverted = True
                    End If

            End Select
        End Sub

        Private Sub AdvPropertyGrid1_PropertiesLoaded(sender As Object, e As EventArgs) Handles AdvPropertyGrid1.PropertiesLoaded
            If Not hasFirstFocued Then
                If CbEditorBParam1 IsNot Nothing AndAlso CbEditorBParam2 IsNot Nothing Then
                    'CbEditorBParam1.Focus()
                    'CbEditorBParam2.Focus()
                    hasFirstFocued = True
                End If
            End If
        End Sub

        Private Sub CbEditorBehavAddr_DataColumnCreated(sender As Object, e As DataColumnEventArgs) Handles CbEditorBehavAddr.DataColumnCreated, CbEditorBParam1.DataColumnCreated, CbEditorBParam2.DataColumnCreated
            e.ColumnHeader.Width.AutoSize = True
        End Sub

        Private Sub ProvideBParamContentList(sender As ContentSelectorEditor.ComboBoxEditor, e As EventArgs) Handles CbEditorBParam1.NeedValues, CbEditorBParam2.NeedValues
            Dim addr As UInteger = CurBehavAddr
            Dim bpname As String = ""

            If sender.Tag <> addr Then
                If sender Is CbEditorBParam1 Then
                    bpname = bParamPropName & 1
                ElseIf sender Is CbEditorBParam2 Then
                    bpname = bParamPropName & 2
                End If

                If Not String.IsNullOrEmpty(bpname) Then
                    Dim info As BehaviorInfo = BehaviorInfos.GetByBehaviorAddress(addr)
                    If info IsNot Nothing Then
                        Dim param As BehaviorInfo.BParam = info.GetValue(bpname)

                        If param IsNot Nothing Then
                            'sender.DataSource = Nothing
                            sender.DataSource = param.Values
                        End If
                    End If
                End If

                sender.Tag = addr
            End If
        End Sub

    End Class

End Namespace
