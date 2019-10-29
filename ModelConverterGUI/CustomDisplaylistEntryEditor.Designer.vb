<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomDisplaylistEntryEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.IntegerInput_ID = New DevComponents.Editors.IntegerInput()
        Me.ComboBoxEx_Layer = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ButtonX_Remove = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.IntegerInput_ID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IntegerInput_ID
        '
        '
        '
        '
        Me.IntegerInput_ID.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_ID.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_ID.Location = New System.Drawing.Point(34, 5)
        Me.IntegerInput_ID.MinValue = 0
        Me.IntegerInput_ID.Name = "IntegerInput_ID"
        Me.IntegerInput_ID.ShowUpDown = True
        Me.IntegerInput_ID.Size = New System.Drawing.Size(53, 20)
        Me.IntegerInput_ID.TabIndex = 0
        '
        'ComboBoxEx_Layer
        '
        Me.ComboBoxEx_Layer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx_Layer.DisplayMember = "Text"
        Me.ComboBoxEx_Layer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_Layer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_Layer.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_Layer.FormattingEnabled = True
        Me.ComboBoxEx_Layer.ItemHeight = 15
        Me.ComboBoxEx_Layer.Location = New System.Drawing.Point(140, 4)
        Me.ComboBoxEx_Layer.Name = "ComboBoxEx_Layer"
        Me.ComboBoxEx_Layer.Size = New System.Drawing.Size(148, 21)
        Me.ComboBoxEx_Layer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx_Layer.TabIndex = 0
        '
        'ButtonX_Remove
        '
        Me.ButtonX_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Remove.Image = Global.SM64_ROM_Manager.ModelConverterGUI.My.Resources.Resources.icons8_delete_sign_16px
        Me.ButtonX_Remove.Location = New System.Drawing.Point(294, 3)
        Me.ButtonX_Remove.Name = "ButtonX_Remove"
        Me.ButtonX_Remove.Size = New System.Drawing.Size(23, 23)
        Me.ButtonX_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Remove.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(25, 23)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "ID:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(93, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(41, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Layer:"
        '
        'CustomDisplaylistEntryEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ButtonX_Remove)
        Me.Controls.Add(Me.IntegerInput_ID)
        Me.Controls.Add(Me.ComboBoxEx_Layer)
        Me.Name = "CustomDisplaylistEntryEditor"
        Me.Size = New System.Drawing.Size(320, 29)
        CType(Me.IntegerInput_ID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IntegerInput_ID As DevComponents.Editors.IntegerInput
    Friend WithEvents ComboBoxEx_Layer As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ButtonX_Remove As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
