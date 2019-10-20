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
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
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
        Me.ButtonX_Convert = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_CopyOutput = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxX_Input
        '
        resources.ApplyResources(Me.TextBoxX_Input, "TextBoxX_Input")
        Me.TextBoxX_Input.AutoSelectAll = True
        Me.TextBoxX_Input.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Input.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Input.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Input.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Input.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Input.Name = "TextBoxX_Input"
        Me.TextBoxX_Input.PreventEnterBeep = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.Name = "LabelX1"
        '
        'TextBoxX_Output
        '
        resources.ApplyResources(Me.TextBoxX_Output, "TextBoxX_Output")
        Me.TextBoxX_Output.AutoSelectAll = True
        Me.TextBoxX_Output.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Output.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Output.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Output.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Output.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Output.Name = "TextBoxX_Output"
        Me.TextBoxX_Output.PreventEnterBeep = True
        Me.TextBoxX_Output.ReadOnly = True
        '
        'LabelX2
        '
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Name = "LabelX2"
        '
        'ComboBoxEx_Mode
        '
        Me.ComboBoxEx_Mode.DisplayMember = "Text"
        Me.ComboBoxEx_Mode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_Mode.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_Mode.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx_Mode, "ComboBoxEx_Mode")
        Me.ComboBoxEx_Mode.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.ComboBoxEx_Mode.Name = "ComboBoxEx_Mode"
        Me.ComboBoxEx_Mode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboItem1
        '
        resources.ApplyResources(Me.ComboItem1, "ComboItem1")
        '
        'ComboItem2
        '
        resources.ApplyResources(Me.ComboItem2, "ComboItem2")
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        resources.ApplyResources(Me.ContextMenuBar1, "ContextMenuBar1")
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabStop = False
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_Copy, Me.ButtonItem_cut, Me.ButtonItem_Paste, Me.ButtonItem_SelectAll, Me.ButtonItem_Remove})
        '
        'ButtonItem_Copy
        '
        Me.ButtonItem_Copy.Name = "ButtonItem_Copy"
        Me.ButtonItem_Copy.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.ButtonItem_Copy.Symbol = "57677"
        Me.ButtonItem_Copy.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_Copy.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_Copy, "ButtonItem_Copy")
        '
        'ButtonItem_cut
        '
        Me.ButtonItem_cut.Name = "ButtonItem_cut"
        Me.ButtonItem_cut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.ButtonItem_cut.Symbol = "57678"
        Me.ButtonItem_cut.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_cut.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_cut, "ButtonItem_cut")
        '
        'ButtonItem_Paste
        '
        Me.ButtonItem_Paste.Name = "ButtonItem_Paste"
        Me.ButtonItem_Paste.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.ButtonItem_Paste.Symbol = "57679"
        Me.ButtonItem_Paste.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_Paste.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_Paste, "ButtonItem_Paste")
        '
        'ButtonItem_SelectAll
        '
        Me.ButtonItem_SelectAll.BeginGroup = True
        Me.ButtonItem_SelectAll.Name = "ButtonItem_SelectAll"
        Me.ButtonItem_SelectAll.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.ButtonItem_SelectAll.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_SelectAll, "ButtonItem_SelectAll")
        '
        'ButtonItem_Remove
        '
        Me.ButtonItem_Remove.BeginGroup = True
        Me.ButtonItem_Remove.Name = "ButtonItem_Remove"
        Me.ButtonItem_Remove.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.ButtonItem_Remove.Symbol = "57676"
        Me.ButtonItem_Remove.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem_Remove.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_Remove.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_Remove, "ButtonItem_Remove")
        '
        'ButtonX_Convert
        '
        Me.ButtonX_Convert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Convert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Convert.FocusCuesEnabled = False
        Me.ButtonX_Convert.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_arrow_40px
        resources.ApplyResources(Me.ButtonX_Convert, "ButtonX_Convert")
        Me.ButtonX_Convert.Name = "ButtonX_Convert"
        Me.ButtonX_Convert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Convert.SymbolColor = System.Drawing.Color.Gray
        Me.ButtonX_Convert.SymbolSize = 30.0!
        '
        'ButtonX_CopyOutput
        '
        Me.ButtonX_CopyOutput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX_CopyOutput, "ButtonX_CopyOutput")
        Me.ButtonX_CopyOutput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_CopyOutput.FocusCuesEnabled = False
        Me.ButtonX_CopyOutput.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
        Me.ButtonX_CopyOutput.Name = "ButtonX_CopyOutput"
        Me.ButtonX_CopyOutput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_CopyOutput.SymbolColor = System.Drawing.Color.Gray
        Me.ButtonX_CopyOutput.SymbolSize = 12.0!
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ContextMenuBar1)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.ComboBoxEx_Mode)
        Me.Panel1.Controls.Add(Me.TextBoxX_Input)
        Me.Panel1.Controls.Add(Me.ButtonX_Convert)
        Me.Panel1.Controls.Add(Me.TextBoxX_Output)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.ButtonX_CopyOutput)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Form_SM64TextConverter
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_SM64TextConverter"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Panel1 As Panel
End Class
