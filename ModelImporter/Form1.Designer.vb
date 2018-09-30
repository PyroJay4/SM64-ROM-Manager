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
        Me.components = New System.ComponentModel.Container()
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
        Me.ComboBoxEx2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX_Description = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_PatchName = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.Flyout1 = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelX50
        '
        Me.LabelX50.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Location = New System.Drawing.Point(12, 168)
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
        Me.LabelX51.Location = New System.Drawing.Point(12, 220)
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
        Me.LabelX54.Location = New System.Drawing.Point(12, 194)
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
        Me.TextBoxX_RomAddr.Location = New System.Drawing.Point(162, 168)
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
        Me.TextBoxX_MaxLength.Location = New System.Drawing.Point(162, 220)
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
        Me.TextBoxX_BankAddr.Location = New System.Drawing.Point(162, 194)
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
        Me.ButtonX_OpenRom.Location = New System.Drawing.Point(187, 12)
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
        Me.LabelX1.Size = New System.Drawing.Size(119, 23)
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
        Me.Line2.Size = New System.Drawing.Size(250, 23)
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
        Me.Line1.Size = New System.Drawing.Size(250, 23)
        Me.Line1.TabIndex = 101
        Me.Line1.Text = "Line1"
        '
        'Line3
        '
        Me.Line3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line3.BackColor = System.Drawing.Color.Transparent
        Me.Line3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Line3.Location = New System.Drawing.Point(12, 324)
        Me.Line3.Margin = New System.Windows.Forms.Padding(0)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(250, 23)
        Me.Line3.TabIndex = 103
        Me.Line3.Text = "Line3"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 350)
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
        Me.TextBoxX_Output.Location = New System.Drawing.Point(12, 379)
        Me.TextBoxX_Output.Multiline = True
        Me.TextBoxX_Output.Name = "TextBoxX_Output"
        Me.TextBoxX_Output.PreventEnterBeep = True
        Me.TextBoxX_Output.ReadOnly = True
        Me.TextBoxX_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxX_Output.Size = New System.Drawing.Size(250, 96)
        Me.TextBoxX_Output.TabIndex = 105
        '
        'ButtonX_ImportMdl
        '
        Me.ButtonX_ImportMdl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_ImportMdl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtonX_ImportMdl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ImportMdl.Enabled = False
        Me.ButtonX_ImportMdl.FocusCuesEnabled = False
        Me.ButtonX_ImportMdl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX_ImportMdl.Location = New System.Drawing.Point(78, 298)
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
        Me.ButtonX_ConvertMdl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtonX_ConvertMdl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ConvertMdl.FocusCuesEnabled = False
        Me.ButtonX_ConvertMdl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX_ConvertMdl.Location = New System.Drawing.Point(78, 90)
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
        Me.ComboBoxEx1.Size = New System.Drawing.Size(154, 21)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 109
        '
        'ComboBoxEx2
        '
        Me.ComboBoxEx2.DisplayMember = "Text"
        Me.ComboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx2.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx2.FormattingEnabled = True
        Me.ComboBoxEx2.ItemHeight = 15
        Me.ComboBoxEx2.Location = New System.Drawing.Point(12, 142)
        Me.ComboBoxEx2.Name = "ComboBoxEx2"
        Me.ComboBoxEx2.Size = New System.Drawing.Size(224, 21)
        Me.ComboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx2.TabIndex = 111
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(12, 272)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(90, 20)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX6.TabIndex = 112
        Me.LabelX6.Text = "Geopointer:"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(12, 246)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(90, 20)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX7.TabIndex = 113
        Me.LabelX7.Text = "Collisionpointer:"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(108, 272)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(154, 20)
        Me.SuperTooltip1.SetSuperTooltip(Me.TextBoxX1, New DevComponents.DotNetBar.SuperTooltipInfo("", "", "The Geopointers will be written to this addresses." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seperate them with comma." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Example:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0x1250000, 0x18E0000", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, False, False, New System.Drawing.Size(0, 0)))
        Me.TextBoxX1.TabIndex = 114
        '
        'TextBoxX2
        '
        Me.TextBoxX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX2.Location = New System.Drawing.Point(108, 246)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.PreventEnterBeep = True
        Me.TextBoxX2.Size = New System.Drawing.Size(154, 20)
        Me.SuperTooltip1.SetSuperTooltip(Me.TextBoxX2, New DevComponents.DotNetBar.SuperTooltipInfo("", "", "The Collision Pointer will be written to this addresses." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seperate them with comm" &
            "a." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Example:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0x1250000, 0x18E0000", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, False, False, New System.Drawing.Size(0, 0)))
        Me.TextBoxX2.TabIndex = 115
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX3.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX3, New DevComponents.DotNetBar.SuperTooltipInfo("", "", "Close Popup", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, False, False, New System.Drawing.Size(0, 0)))
        Me.ButtonX3.Symbol = "57676"
        Me.ButtonX3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX3.SymbolSize = 12.0!
        Me.ButtonX3.TabIndex = 39
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Location = New System.Drawing.Point(112, 3)
        Me.ButtonX2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(115, 20)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX2, New DevComponents.DotNetBar.SuperTooltipInfo("", "", "Edit Name & Description", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, False, False, New System.Drawing.Size(0, 0)))
        Me.ButtonX2.Symbol = "57680"
        Me.ButtonX2.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
        Me.ButtonX2.TabIndex = 45
        Me.ButtonX2.Text = "Edit Preset Info"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(112, 29)
        Me.ButtonX1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(95, 20)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX1, New DevComponents.DotNetBar.SuperTooltipInfo("", "", "Edit Name & Description", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, False, False, New System.Drawing.Size(0, 0)))
        Me.ButtonX1.Symbol = "57697"
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        Me.ButtonX1.TabIndex = 46
        Me.ButtonX1.Text = "Save Preset"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.LabelX_Description)
        Me.Panel1.Controls.Add(Me.LabelX_PatchName)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(17, 294)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(298, 191)
        Me.Panel1.TabIndex = 117
        Me.Panel1.Visible = False
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(3, 87)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(230, 23)
        Me.LabelX5.TabIndex = 52
        Me.LabelX5.Text = "Description:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX3, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(272, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(26, 26)
        Me.TableLayoutPanel2.TabIndex = 48
        '
        'LabelX_Description
        '
        Me.LabelX_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX_Description.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Description.Location = New System.Drawing.Point(3, 116)
        Me.LabelX_Description.Name = "LabelX_Description"
        Me.LabelX_Description.Size = New System.Drawing.Size(292, 72)
        Me.LabelX_Description.TabIndex = 50
        Me.LabelX_Description.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX_Description.WordWrap = True
        '
        'LabelX_PatchName
        '
        Me.LabelX_PatchName.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_PatchName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_PatchName.Location = New System.Drawing.Point(3, 58)
        Me.LabelX_PatchName.Name = "LabelX_PatchName"
        Me.LabelX_PatchName.Size = New System.Drawing.Size(381, 23)
        Me.LabelX_PatchName.TabIndex = 49
        Me.LabelX_PatchName.Text = "Name:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX7, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(236, 52)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX6.FocusCuesEnabled = False
        Me.ButtonX6.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(92, 20)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = "57680"
        Me.ButtonX6.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonX6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX6.SymbolSize = 12.0!
        Me.ButtonX6.TabIndex = 44
        Me.ButtonX6.Text = "Edit Script"
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX7.FocusCuesEnabled = False
        Me.ButtonX7.Location = New System.Drawing.Point(3, 29)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(103, 20)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.Symbol = "57676"
        Me.ButtonX7.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX7.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX7.SymbolSize = 12.0!
        Me.ButtonX7.TabIndex = 45
        Me.ButtonX7.Text = "Delete Preset"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX4.FocusCuesEnabled = False
        Me.ButtonX4.Location = New System.Drawing.Point(242, 142)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.Symbol = "57669"
        Me.ButtonX4.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX4.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX4.SymbolSize = 12.0!
        Me.ButtonX4.TabIndex = 42
        '
        'Flyout1
        '
        Me.Flyout1.Content = Me.Panel1
        Me.Flyout1.DisplayMode = DevComponents.DotNetBar.Controls.eFlyoutDisplayMode.MouseHover
        Me.Flyout1.DropShadow = False
        Me.Flyout1.TargetControl = Me.ComboBoxEx2
        '
        'ModelImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 489)
        Me.Controls.Add(Me.ButtonX4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.TextBoxX2)
        Me.Controls.Add(Me.ComboBoxEx2)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
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
    Friend WithEvents ComboBoxEx2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX_Description As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_PatchName As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Flyout1 As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
End Class
