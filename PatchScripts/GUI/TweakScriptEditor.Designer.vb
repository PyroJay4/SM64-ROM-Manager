Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TweakScriptEditor
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TweakScriptEditor))
        Me.TextBoxX_ScriptDescription = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_ScriptName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_TweakScript = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxX_CSharpScript = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_VBScript = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX_ShowObjectCatalog = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_RunScript = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem_RunInTestMode = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonX_CheckForErros = New DevComponents.DotNetBar.ButtonX()
        Me.ItemListBox1 = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX_ReferenceName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxX_ScriptDescription
        '
        Me.TextBoxX_ScriptDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ScriptDescription.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ScriptDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ScriptDescription.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ScriptDescription.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_ScriptDescription, "TextBoxX_ScriptDescription")
        Me.TextBoxX_ScriptDescription.Name = "TextBoxX_ScriptDescription"
        Me.TextBoxX_ScriptDescription.PreventEnterBeep = True
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        Me.LabelX2.Name = "LabelX2"
        '
        'TextBoxX_ScriptName
        '
        Me.TextBoxX_ScriptName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ScriptName.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ScriptName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ScriptName.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ScriptName.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_ScriptName, "TextBoxX_ScriptName")
        Me.TextBoxX_ScriptName.Name = "TextBoxX_ScriptName"
        Me.TextBoxX_ScriptName.PreventEnterBeep = True
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
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        Me.LabelX3.Name = "LabelX3"
        '
        'CheckBoxX_TweakScript
        '
        '
        '
        '
        Me.CheckBoxX_TweakScript.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_TweakScript.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX_TweakScript.Checked = True
        Me.CheckBoxX_TweakScript.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX_TweakScript.CheckValue = "Y"
        Me.CheckBoxX_TweakScript.FocusCuesEnabled = False
        resources.ApplyResources(Me.CheckBoxX_TweakScript, "CheckBoxX_TweakScript")
        Me.CheckBoxX_TweakScript.Name = "CheckBoxX_TweakScript"
        Me.CheckBoxX_TweakScript.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CheckBoxX_CSharpScript)
        Me.Panel1.Controls.Add(Me.CheckBoxX_VBScript)
        Me.Panel1.Controls.Add(Me.CheckBoxX_TweakScript)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'CheckBoxX_CSharpScript
        '
        '
        '
        '
        Me.CheckBoxX_CSharpScript.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_CSharpScript.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX_CSharpScript.FocusCuesEnabled = False
        resources.ApplyResources(Me.CheckBoxX_CSharpScript, "CheckBoxX_CSharpScript")
        Me.CheckBoxX_CSharpScript.Name = "CheckBoxX_CSharpScript"
        Me.CheckBoxX_CSharpScript.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_VBScript
        '
        '
        '
        '
        Me.CheckBoxX_VBScript.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_VBScript.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX_VBScript.FocusCuesEnabled = False
        resources.ApplyResources(Me.CheckBoxX_VBScript, "CheckBoxX_VBScript")
        Me.CheckBoxX_VBScript.Name = "CheckBoxX_VBScript"
        Me.CheckBoxX_VBScript.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'LabelX4
        '
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Name = "LabelX4"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX_ShowObjectCatalog, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX_RunScript, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX_CheckForErros, 2, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'ButtonX_ShowObjectCatalog
        '
        Me.ButtonX_ShowObjectCatalog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_ShowObjectCatalog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ShowObjectCatalog.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_ShowObjectCatalog, "ButtonX_ShowObjectCatalog")
        Me.ButtonX_ShowObjectCatalog.Name = "ButtonX_ShowObjectCatalog"
        Me.ButtonX_ShowObjectCatalog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_RunScript
        '
        Me.ButtonX_RunScript.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_RunScript.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_RunScript.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_RunScript, "ButtonX_RunScript")
        Me.ButtonX_RunScript.Name = "ButtonX_RunScript"
        Me.ButtonX_RunScript.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_RunScript.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_RunInTestMode})
        Me.ButtonX_RunScript.Symbol = "57399"
        Me.ButtonX_RunScript.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_RunScript.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_RunScript.SymbolSize = 12.0!
        '
        'ButtonItem_RunInTestMode
        '
        Me.ButtonItem_RunInTestMode.AutoCheckOnClick = True
        Me.ButtonItem_RunInTestMode.Checked = True
        Me.ButtonItem_RunInTestMode.GlobalItem = False
        Me.ButtonItem_RunInTestMode.Name = "ButtonItem_RunInTestMode"
        resources.ApplyResources(Me.ButtonItem_RunInTestMode, "ButtonItem_RunInTestMode")
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.AutoExpandOnClick = True
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1, Me.ButtonItem2})
        '
        'ButtonItem1
        '
        Me.ButtonItem1.GlobalItem = False
        Me.ButtonItem1.Name = "ButtonItem1"
        resources.ApplyResources(Me.ButtonItem1, "ButtonItem1")
        '
        'ButtonItem2
        '
        Me.ButtonItem2.GlobalItem = False
        Me.ButtonItem2.Name = "ButtonItem2"
        resources.ApplyResources(Me.ButtonItem2, "ButtonItem2")
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.AutoExpandOnClick = True
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX2, "ButtonX2")
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3, Me.ButtonItem4})
        '
        'ButtonItem3
        '
        Me.ButtonItem3.GlobalItem = False
        Me.ButtonItem3.Name = "ButtonItem3"
        resources.ApplyResources(Me.ButtonItem3, "ButtonItem3")
        '
        'ButtonItem4
        '
        Me.ButtonItem4.GlobalItem = False
        Me.ButtonItem4.Name = "ButtonItem4"
        resources.ApplyResources(Me.ButtonItem4, "ButtonItem4")
        '
        'ButtonX_CheckForErros
        '
        Me.ButtonX_CheckForErros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_CheckForErros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_CheckForErros.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_CheckForErros, "ButtonX_CheckForErros")
        Me.ButtonX_CheckForErros.Name = "ButtonX_CheckForErros"
        Me.ButtonX_CheckForErros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ItemListBox1
        '
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        resources.ApplyResources(Me.ItemListBox1, "ItemListBox1")
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.Name = "LabelX5"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel3.Controls.Add(Me.LabelX5)
        Me.Panel3.Controls.Add(Me.ItemListBox1)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX4, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxX_ReferenceName, 0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX3, "ButtonX3")
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.Symbol = "57669"
        Me.ButtonX3.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX3.SymbolSize = 12.0!
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX4, "ButtonX4")
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.FocusCuesEnabled = False
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.Symbol = "57676"
        Me.ButtonX4.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX4.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX4.SymbolSize = 12.0!
        '
        'TextBoxX_ReferenceName
        '
        Me.TextBoxX_ReferenceName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ReferenceName.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ReferenceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ReferenceName.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ReferenceName.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_ReferenceName, "TextBoxX_ReferenceName")
        Me.TextBoxX_ReferenceName.Name = "TextBoxX_ReferenceName"
        Me.TextBoxX_ReferenceName.PreventEnterBeep = True
        '
        'TweakScriptEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBoxX_ScriptName)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.TextBoxX_ScriptDescription)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Name = "TweakScriptEditor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents TextBoxX_ScriptDescription As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Private WithEvents TextBoxX_ScriptName As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX_TweakScript As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckBoxX_CSharpScript As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_VBScript As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel2 As Panel
    Private WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemListBox1 As SM64_ROM_Manager.Publics.Controls.ItemListBox
    Private WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBoxX_ReferenceName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_CheckForErros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_RunScript As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem_RunInTestMode As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonX_ShowObjectCatalog As DevComponents.DotNetBar.ButtonX
End Class
