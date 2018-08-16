<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SM64TextConverter
    Inherits DevComponents.DotNetBar.OfficeForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SM64TextConverter))
        Me.TextBoxX_Input = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_Output = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX_CopyOutput = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX_Convert = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBoxEx_Mode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Copy = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_cut = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Paste = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_SelectAll = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Remove = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxX_Input
        '
        Me.TextBoxX_Input.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_Input.AutoSelectAll = True
        Me.TextBoxX_Input.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Input.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Input.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Input.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Input.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Input.Location = New System.Drawing.Point(12, 41)
        Me.TextBoxX_Input.Multiline = True
        Me.TextBoxX_Input.Name = "TextBoxX_Input"
        Me.TextBoxX_Input.PreventEnterBeep = True
        Me.TextBoxX_Input.Size = New System.Drawing.Size(200, 300)
        Me.TextBoxX_Input.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(34, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Input:"
        '
        'TextBoxX_Output
        '
        Me.TextBoxX_Output.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_Output.AutoSelectAll = True
        Me.TextBoxX_Output.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Output.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Output.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Output.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Output.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Output.Location = New System.Drawing.Point(299, 41)
        Me.TextBoxX_Output.Multiline = True
        Me.TextBoxX_Output.Name = "TextBoxX_Output"
        Me.TextBoxX_Output.PreventEnterBeep = True
        Me.TextBoxX_Output.ReadOnly = True
        Me.TextBoxX_Output.Size = New System.Drawing.Size(200, 300)
        Me.TextBoxX_Output.TabIndex = 3
        '
        'ButtonX_CopyOutput
        '
        Me.ButtonX_CopyOutput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_CopyOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_CopyOutput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_CopyOutput.FocusCuesEnabled = False
        Me.ButtonX_CopyOutput.Location = New System.Drawing.Point(437, 12)
        Me.ButtonX_CopyOutput.Name = "ButtonX_CopyOutput"
        Me.ButtonX_CopyOutput.Size = New System.Drawing.Size(62, 23)
        Me.ButtonX_CopyOutput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_CopyOutput.Symbol = ""
        Me.ButtonX_CopyOutput.SymbolColor = System.Drawing.Color.Gray
        Me.ButtonX_CopyOutput.SymbolSize = 12.0!
        Me.ButtonX_CopyOutput.TabIndex = 5
        Me.ButtonX_CopyOutput.Text = "Copy"
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(299, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(41, 23)
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Output:"
        '
        'ButtonX_Convert
        '
        Me.ButtonX_Convert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Convert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Convert.FocusCuesEnabled = False
        Me.ButtonX_Convert.Location = New System.Drawing.Point(218, 139)
        Me.ButtonX_Convert.Name = "ButtonX_Convert"
        Me.ButtonX_Convert.Size = New System.Drawing.Size(75, 75)
        Me.ButtonX_Convert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Convert.Symbol = ""
        Me.ButtonX_Convert.SymbolColor = System.Drawing.Color.Gray
        Me.ButtonX_Convert.SymbolSize = 30.0!
        Me.ButtonX_Convert.TabIndex = 7
        '
        'ComboBoxEx_Mode
        '
        Me.ComboBoxEx_Mode.DisplayMember = "Text"
        Me.ComboBoxEx_Mode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_Mode.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_Mode.FormattingEnabled = True
        Me.ComboBoxEx_Mode.ItemHeight = 15
        Me.ComboBoxEx_Mode.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.ComboBoxEx_Mode.Location = New System.Drawing.Point(124, 14)
        Me.ComboBoxEx_Mode.Name = "ComboBoxEx_Mode"
        Me.ComboBoxEx_Mode.Size = New System.Drawing.Size(88, 21)
        Me.ComboBoxEx_Mode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx_Mode.TabIndex = 10
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Text --> Hex"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Hex --> Text"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(218, 57)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(75, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 11
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_Copy, Me.ButtonItem_cut, Me.ButtonItem_Paste, Me.ButtonItem_SelectAll, Me.ButtonItem_Remove})
        Me.ButtonItem1.Text = "ButtonItem1"
        '
        'ButtonItem_Copy
        '
        Me.ButtonItem_Copy.Name = "ButtonItem_Copy"
        Me.ButtonItem_Copy.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.ButtonItem_Copy.Symbol = "57677"
        Me.ButtonItem_Copy.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_Copy.SymbolSize = 12.0!
        Me.ButtonItem_Copy.Text = "Copy"
        '
        'ButtonItem_cut
        '
        Me.ButtonItem_cut.Name = "ButtonItem_cut"
        Me.ButtonItem_cut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.ButtonItem_cut.Symbol = "57678"
        Me.ButtonItem_cut.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_cut.SymbolSize = 12.0!
        Me.ButtonItem_cut.Text = "Cut"
        '
        'ButtonItem_Paste
        '
        Me.ButtonItem_Paste.Name = "ButtonItem_Paste"
        Me.ButtonItem_Paste.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.ButtonItem_Paste.Symbol = "57679"
        Me.ButtonItem_Paste.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_Paste.SymbolSize = 12.0!
        Me.ButtonItem_Paste.Text = "Past"
        '
        'ButtonItem_SelectAll
        '
        Me.ButtonItem_SelectAll.BeginGroup = True
        Me.ButtonItem_SelectAll.Name = "ButtonItem_SelectAll"
        Me.ButtonItem_SelectAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.ButtonItem_SelectAll.SymbolSize = 12.0!
        Me.ButtonItem_SelectAll.Text = "Select All"
        '
        'ButtonItem_Remove
        '
        Me.ButtonItem_Remove.BeginGroup = True
        Me.ButtonItem_Remove.Name = "ButtonItem_Remove"
        Me.ButtonItem_Remove.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.ButtonItem_Remove.Symbol = ""
        Me.ButtonItem_Remove.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem_Remove.SymbolSize = 12.0!
        Me.ButtonItem_Remove.Text = "Remove"
        '
        'Form_SM64TextConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 353)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.ComboBoxEx_Mode)
        Me.Controls.Add(Me.ButtonX_Convert)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.ButtonX_CopyOutput)
        Me.Controls.Add(Me.TextBoxX_Output)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TextBoxX_Input)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_SM64TextConverter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SM64 Text Converter"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxX_Input As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_Output As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX_CopyOutput As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX_Convert As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBoxEx_Mode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Copy As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_cut As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Paste As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_SelectAll As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Remove As DevComponents.DotNetBar.ButtonItem
End Class
