<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModelImporter
    Inherits DevComponents.DotNetBar.OfficeForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModelImporter))
        Me.LabelX50 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX51 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_RomAddr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_MaxLength = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_BankAddr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX_OpenRom = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_Output = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX_ImportMdl = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_ConvertMdl = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SuspendLayout()
        '
        'LabelX50
        '
        Me.LabelX50.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Location = New System.Drawing.Point(12, 142)
        Me.LabelX50.Name = "LabelX50"
        Me.LabelX50.Size = New System.Drawing.Size(90, 20)
        Me.LabelX50.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX50.TabIndex = 92
        Me.LabelX50.Text = "Rom Address:"
        '
        'LabelX51
        '
        Me.LabelX51.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX51.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX51.Location = New System.Drawing.Point(12, 194)
        Me.LabelX51.Name = "LabelX51"
        Me.LabelX51.Size = New System.Drawing.Size(90, 20)
        Me.LabelX51.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX51.TabIndex = 93
        Me.LabelX51.Text = "Max Length:"
        '
        'LabelX54
        '
        Me.LabelX54.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Location = New System.Drawing.Point(12, 168)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(90, 20)
        Me.LabelX54.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX54.TabIndex = 94
        Me.LabelX54.Text = "Bank Address:"
        '
        'TextBoxX_RomAddr
        '
        Me.TextBoxX_RomAddr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_RomAddr.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_RomAddr.Border.Class = "TextBoxBorder"
        Me.TextBoxX_RomAddr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_RomAddr.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_RomAddr.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_RomAddr.Location = New System.Drawing.Point(156, 142)
        Me.TextBoxX_RomAddr.Name = "TextBoxX_RomAddr"
        Me.TextBoxX_RomAddr.PreventEnterBeep = True
        Me.TextBoxX_RomAddr.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX_RomAddr.TabIndex = 95
        Me.TextBoxX_RomAddr.Text = "0x0"
        '
        'TextBoxX_MaxLength
        '
        Me.TextBoxX_MaxLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_MaxLength.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_MaxLength.Border.Class = "TextBoxBorder"
        Me.TextBoxX_MaxLength.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_MaxLength.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_MaxLength.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_MaxLength.Location = New System.Drawing.Point(156, 194)
        Me.TextBoxX_MaxLength.Name = "TextBoxX_MaxLength"
        Me.TextBoxX_MaxLength.PreventEnterBeep = True
        Me.TextBoxX_MaxLength.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX_MaxLength.TabIndex = 96
        Me.TextBoxX_MaxLength.Text = "0x0"
        '
        'TextBoxX_BankAddr
        '
        Me.TextBoxX_BankAddr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_BankAddr.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_BankAddr.Border.Class = "TextBoxBorder"
        Me.TextBoxX_BankAddr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_BankAddr.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_BankAddr.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_BankAddr.Location = New System.Drawing.Point(156, 168)
        Me.TextBoxX_BankAddr.Name = "TextBoxX_BankAddr"
        Me.TextBoxX_BankAddr.PreventEnterBeep = True
        Me.TextBoxX_BankAddr.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX_BankAddr.TabIndex = 97
        Me.TextBoxX_BankAddr.Text = "0x0"
        '
        'ButtonX_OpenRom
        '
        Me.ButtonX_OpenRom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_OpenRom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_OpenRom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_OpenRom.FocusCuesEnabled = False
        Me.ButtonX_OpenRom.Location = New System.Drawing.Point(181, 12)
        Me.ButtonX_OpenRom.Name = "ButtonX_OpenRom"
        Me.ButtonX_OpenRom.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_OpenRom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_OpenRom.Symbol = "58055"
        Me.ButtonX_OpenRom.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ButtonX_OpenRom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_OpenRom.SymbolSize = 12.0!
        Me.ButtonX_OpenRom.TabIndex = 98
        Me.ButtonX_OpenRom.Text = "Load ..."
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(62, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(113, 23)
        Me.LabelX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelX1.SymbolSize = 12.0!
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "No file loaded!"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(44, 23)
        Me.LabelX2.TabIndex = 99
        Me.LabelX2.Text = "Romfile:"
        '
        'Line2
        '
        Me.Line2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        Me.Line2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Line2.Location = New System.Drawing.Point(12, 38)
        Me.Line2.Margin = New System.Windows.Forms.Padding(0)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(244, 23)
        Me.Line2.TabIndex = 100
        Me.Line2.Text = "Line2"
        '
        'Line1
        '
        Me.Line1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Line1.Location = New System.Drawing.Point(12, 116)
        Me.Line1.Margin = New System.Windows.Forms.Padding(0)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(244, 23)
        Me.Line1.TabIndex = 101
        Me.Line1.Text = "Line1"
        '
        'Line3
        '
        Me.Line3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line3.BackColor = System.Drawing.Color.Transparent
        Me.Line3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Line3.Location = New System.Drawing.Point(12, 246)
        Me.Line3.Margin = New System.Windows.Forms.Padding(0)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(244, 23)
        Me.Line3.TabIndex = 103
        Me.Line3.Text = "Line3"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 272)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 104
        Me.LabelX3.Text = "Result:"
        '
        'TextBoxX_Output
        '
        Me.TextBoxX_Output.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_Output.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Output.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Output.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Output.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Output.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Output.Location = New System.Drawing.Point(12, 301)
        Me.TextBoxX_Output.Multiline = True
        Me.TextBoxX_Output.Name = "TextBoxX_Output"
        Me.TextBoxX_Output.PreventEnterBeep = True
        Me.TextBoxX_Output.ReadOnly = True
        Me.TextBoxX_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxX_Output.Size = New System.Drawing.Size(244, 96)
        Me.TextBoxX_Output.TabIndex = 105
        '
        'ButtonX_ImportMdl
        '
        Me.ButtonX_ImportMdl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_ImportMdl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_ImportMdl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ImportMdl.Enabled = False
        Me.ButtonX_ImportMdl.FocusCuesEnabled = False
        Me.ButtonX_ImportMdl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX_ImportMdl.Location = New System.Drawing.Point(75, 220)
        Me.ButtonX_ImportMdl.Name = "ButtonX_ImportMdl"
        Me.ButtonX_ImportMdl.Size = New System.Drawing.Size(119, 23)
        Me.ButtonX_ImportMdl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_ImportMdl.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_ImportMdl.SymbolSize = 12.0!
        Me.ButtonX_ImportMdl.TabIndex = 106
        Me.ButtonX_ImportMdl.Text = "Import Model"
        '
        'ButtonX_ConvertMdl
        '
        Me.ButtonX_ConvertMdl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_ConvertMdl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ConvertMdl.FocusCuesEnabled = False
        Me.ButtonX_ConvertMdl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX_ConvertMdl.Location = New System.Drawing.Point(75, 90)
        Me.ButtonX_ConvertMdl.Name = "ButtonX_ConvertMdl"
        Me.ButtonX_ConvertMdl.Size = New System.Drawing.Size(119, 23)
        Me.ButtonX_ConvertMdl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_ConvertMdl.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_ConvertMdl.SymbolSize = 12.0!
        Me.ButtonX_ConvertMdl.TabIndex = 107
        Me.ButtonX_ConvertMdl.Text = "Convert Model"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 64)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(90, 20)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX4.TabIndex = 108
        Me.LabelX4.Text = "Force Displaylist:"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 15
        Me.ComboBoxEx1.Location = New System.Drawing.Point(108, 63)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(148, 21)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 109
        '
        'ModelImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 409)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.ButtonX_ConvertMdl)
        Me.Controls.Add(Me.ButtonX_ImportMdl)
        Me.Controls.Add(Me.TextBoxX_Output)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Line3)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ButtonX_OpenRom)
        Me.Controls.Add(Me.LabelX50)
        Me.Controls.Add(Me.LabelX51)
        Me.Controls.Add(Me.LabelX54)
        Me.Controls.Add(Me.TextBoxX_RomAddr)
        Me.Controls.Add(Me.TextBoxX_MaxLength)
        Me.Controls.Add(Me.TextBoxX_BankAddr)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ModelImporter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Model Importer"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX50 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX51 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_RomAddr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_MaxLength As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_BankAddr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX_OpenRom As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_Output As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX_ImportMdl As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_ConvertMdl As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
