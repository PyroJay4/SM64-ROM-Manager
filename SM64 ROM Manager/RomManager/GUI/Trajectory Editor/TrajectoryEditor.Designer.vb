<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TrajectoryEditor
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrajectoryEditor))
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.IntegerInput1 = New DevComponents.Editors.IntegerInput()
        Me.IntegerInput2 = New DevComponents.Editors.IntegerInput()
        Me.IntegerInput3 = New DevComponents.Editors.IntegerInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
        CType(Me.IntegerInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewEx1
        '
        Me.ListViewEx1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewEx1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.FocusCuesEnabled = False
        Me.ListViewEx1.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx1.FullRowSelect = True
        Me.ListViewEx1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEx1.HideSelection = False
        Me.ListViewEx1.Location = New System.Drawing.Point(12, 13)
        Me.ListViewEx1.MultiSelect = False
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(280, 409)
        Me.ListViewEx1.TabIndex = 0
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        Me.ListViewEx1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "X"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Y"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Z"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 80
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.DropDownWidth = 250
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 15
        Me.ComboBoxEx1.Location = New System.Drawing.Point(298, 41)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(194, 21)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 1
        '
        'IntegerInput1
        '
        Me.IntegerInput1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.IntegerInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput1.Location = New System.Drawing.Point(320, 280)
        Me.IntegerInput1.MaxValue = 65535
        Me.IntegerInput1.MinValue = -65535
        Me.IntegerInput1.Name = "IntegerInput1"
        Me.IntegerInput1.ShowUpDown = True
        Me.IntegerInput1.Size = New System.Drawing.Size(120, 20)
        Me.IntegerInput1.TabIndex = 2
        '
        'IntegerInput2
        '
        Me.IntegerInput2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.IntegerInput2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput2.Location = New System.Drawing.Point(320, 309)
        Me.IntegerInput2.MaxValue = 65535
        Me.IntegerInput2.MinValue = -65535
        Me.IntegerInput2.Name = "IntegerInput2"
        Me.IntegerInput2.ShowUpDown = True
        Me.IntegerInput2.Size = New System.Drawing.Size(120, 20)
        Me.IntegerInput2.TabIndex = 3
        '
        'IntegerInput3
        '
        Me.IntegerInput3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.IntegerInput3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput3.Location = New System.Drawing.Point(320, 338)
        Me.IntegerInput3.MaxValue = 65535
        Me.IntegerInput3.MinValue = -65535
        Me.IntegerInput3.Name = "IntegerInput3"
        Me.IntegerInput3.ShowUpDown = True
        Me.IntegerInput3.Size = New System.Drawing.Size(120, 20)
        Me.IntegerInput3.TabIndex = 4
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(298, 279)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(16, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "X:"
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(298, 308)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(16, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Y:"
        '
        'LabelX3
        '
        Me.LabelX3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(298, 337)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(16, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX3.TabIndex = 7
        Me.LabelX3.Text = "Z:"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(298, 97)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(83, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = "57669"
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        Me.ButtonX1.TabIndex = 9
        Me.ButtonX1.Text = "Add Node"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Location = New System.Drawing.Point(387, 97)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(105, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.Symbol = "57676"
        Me.ButtonX2.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
        Me.ButtonX2.TabIndex = 10
        Me.ButtonX2.Text = "Remove Node"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Location = New System.Drawing.Point(298, 192)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(194, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 12
        Me.ButtonX3.Text = "Export trajectory to file"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.FocusCuesEnabled = False
        Me.ButtonX4.Location = New System.Drawing.Point(298, 221)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(194, 23)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 13
        Me.ButtonX4.Text = "Import trajectory from file"
        '
        'LabelX4
        '
        Me.LabelX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(298, 12)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(108, 23)
        Me.LabelX4.TabIndex = 15
        Me.LabelX4.Text = "Current Trajectory:"
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(298, 68)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(108, 23)
        Me.LabelX5.TabIndex = 16
        Me.LabelX5.Text = "Tools:"
        '
        'LabelX6
        '
        Me.LabelX6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(298, 163)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(108, 23)
        Me.LabelX6.TabIndex = 17
        Me.LabelX6.Text = "Import/Export:"
        '
        'LabelX7
        '
        Me.LabelX7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(298, 250)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(108, 23)
        Me.LabelX7.TabIndex = 18
        Me.LabelX7.Text = "Edit Selected Node:"
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.FocusCuesEnabled = False
        Me.ButtonX5.Location = New System.Drawing.Point(426, 399)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(66, 23)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.TabIndex = 19
        Me.ButtonX5.Text = "Save"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.FocusCuesEnabled = False
        Me.ButtonX6.Location = New System.Drawing.Point(298, 126)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(83, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = "58134"
        Me.ButtonX6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX6.SymbolSize = 12.0!
        Me.ButtonX6.TabIndex = 20
        Me.ButtonX6.Text = "Move up"
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.FocusCuesEnabled = False
        Me.ButtonX7.Location = New System.Drawing.Point(387, 126)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(105, 23)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.Symbol = "58131"
        Me.ButtonX7.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX7.SymbolSize = 12.0!
        Me.ButtonX7.TabIndex = 21
        Me.ButtonX7.Text = "Move down"
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX8.AutoExpandOnClick = True
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX8.Enabled = False
        Me.ButtonX8.FocusCuesEnabled = False
        Me.ButtonX8.Location = New System.Drawing.Point(457, 12)
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Size = New System.Drawing.Size(35, 23)
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX8.Symbol = "57669"
        Me.ButtonX8.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX8.SymbolSize = 12.0!
        Me.ButtonX8.TabIndex = 22
        Me.ButtonX8.Text = "<span padding=""1,1,1,1""><expand/></span>"
        '
        'TrajectoryEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 432)
        Me.Controls.Add(Me.ButtonX8)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.ButtonX5)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.IntegerInput3)
        Me.Controls.Add(Me.IntegerInput2)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.IntegerInput1)
        Me.Controls.Add(Me.ButtonX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.ListViewEx1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TrajectoryEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trajectory Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.IntegerInput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents IntegerInput1 As DevComponents.Editors.IntegerInput
    Friend WithEvents IntegerInput2 As DevComponents.Editors.IntegerInput
    Friend WithEvents IntegerInput3 As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
