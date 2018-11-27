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
        resources.ApplyResources(Me.ListViewEx1, "ListViewEx1")
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
        Me.ListViewEx1.MultiSelect = False
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        Me.ListViewEx1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'ComboBoxEx1
        '
        resources.ApplyResources(Me.ComboBoxEx1, "ComboBoxEx1")
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.DropDownWidth = 250
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'IntegerInput1
        '
        resources.ApplyResources(Me.IntegerInput1, "IntegerInput1")
        '
        '
        '
        Me.IntegerInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput1.MaxValue = 65535
        Me.IntegerInput1.MinValue = -65535
        Me.IntegerInput1.Name = "IntegerInput1"
        Me.IntegerInput1.ShowUpDown = True
        '
        'IntegerInput2
        '
        resources.ApplyResources(Me.IntegerInput2, "IntegerInput2")
        '
        '
        '
        Me.IntegerInput2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput2.MaxValue = 65535
        Me.IntegerInput2.MinValue = -65535
        Me.IntegerInput2.Name = "IntegerInput2"
        Me.IntegerInput2.ShowUpDown = True
        '
        'IntegerInput3
        '
        resources.ApplyResources(Me.IntegerInput3, "IntegerInput3")
        '
        '
        '
        Me.IntegerInput3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput3.MaxValue = 65535
        Me.IntegerInput3.MinValue = -65535
        Me.IntegerInput3.Name = "IntegerInput3"
        Me.IntegerInput3.ShowUpDown = True
        '
        'LabelX1
        '
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX2
        '
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX3
        '
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = "57669"
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX2, "ButtonX2")
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.Symbol = "57676"
        Me.ButtonX2.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX3, "ButtonX3")
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX4, "ButtonX4")
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.FocusCuesEnabled = False
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX4
        '
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Name = "LabelX4"
        '
        'LabelX5
        '
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Name = "LabelX5"
        '
        'LabelX6
        '
        resources.ApplyResources(Me.LabelX6, "LabelX6")
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Name = "LabelX6"
        '
        'LabelX7
        '
        resources.ApplyResources(Me.LabelX7, "LabelX7")
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Name = "LabelX7"
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX5, "ButtonX5")
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX6, "ButtonX6")
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.FocusCuesEnabled = False
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = "58134"
        Me.ButtonX6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX6.SymbolSize = 12.0!
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX7, "ButtonX7")
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.FocusCuesEnabled = False
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.Symbol = "58131"
        Me.ButtonX7.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX7.SymbolSize = 12.0!
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX8, "ButtonX8")
        Me.ButtonX8.AutoExpandOnClick = True
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX8.FocusCuesEnabled = False
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX8.Symbol = "57669"
        Me.ButtonX8.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX8.SymbolSize = 12.0!
        '
        'TrajectoryEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.MaximizeBox = False
        Me.Name = "TrajectoryEditor"
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
