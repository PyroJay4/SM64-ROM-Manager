<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObjectBankSelectorBox
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
        Me.ComboBox_ObjectBankSelector = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ListBoxAdv_Content = New DevComponents.DotNetBar.ItemPanel()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'ComboBox_ObjectBankSelector
        '
        Me.ComboBox_ObjectBankSelector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_ObjectBankSelector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_ObjectBankSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_ObjectBankSelector.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_ObjectBankSelector.FormattingEnabled = True
        Me.ComboBox_ObjectBankSelector.ItemHeight = 15
        Me.ComboBox_ObjectBankSelector.Items.AddRange(New Object() {"Disabled", "Haunted Objects", "Snow Objects", "Assorted Enemies (1)", "Desert Objects", "Big Bob-Omb Boss", "Assorted Enemies (2)", "Water Objects", "Assorted Enemies (3)", "Peach & Yoshi", "Switches", "Lava Objects"})
        Me.ComboBox_ObjectBankSelector.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox_ObjectBankSelector.Name = "ComboBox_ObjectBankSelector"
        Me.ComboBox_ObjectBankSelector.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox_ObjectBankSelector.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_ObjectBankSelector.TabIndex = 42
        '
        'ListBoxAdv_LM_ContentOfOB0x0C
        '
        Me.ListBoxAdv_Content.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxAdv_Content.AutoScroll = True
        '
        '
        '
        Me.ListBoxAdv_Content.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_Content.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_Content.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_Content.DragDropSupport = True
        Me.ListBoxAdv_Content.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_Content.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_Content.Location = New System.Drawing.Point(3, 57)
        Me.ListBoxAdv_Content.Name = "ListBoxAdv_LM_ContentOfOB0x0C"
        Me.ListBoxAdv_Content.ReserveLeftSpace = False
        Me.ListBoxAdv_Content.Size = New System.Drawing.Size(150, 85)
        Me.ListBoxAdv_Content.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ListBoxAdv_Content.TabIndex = 41
        '
        'LabelX29
        '
        Me.LabelX29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX29.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Location = New System.Drawing.Point(3, 30)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(150, 21)
        Me.LabelX29.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX29.TabIndex = 43
        Me.LabelX29.Text = "Content of Bank 0x0C:"
        Me.LabelX29.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ObjectBankSelectorBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ComboBox_ObjectBankSelector)
        Me.Controls.Add(Me.ListBoxAdv_Content)
        Me.Controls.Add(Me.LabelX29)
        Me.Name = "ObjectBankSelectorBox"
        Me.Size = New System.Drawing.Size(156, 145)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox_ObjectBankSelector As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ListBoxAdv_Content As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
End Class
