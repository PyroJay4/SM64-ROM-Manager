Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TweakViewer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TweakViewer))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX_Description = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_PatchName = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBoxEx_Scripts = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Flyout1 = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        Me.ItemListBox1 = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.ButtonX9 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.WarningBox_TweakUpdates = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_AddNew = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.LabelX_Description)
        Me.Panel1.Controls.Add(Me.LabelX_PatchName)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.ComboBoxEx_Scripts)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Name = "Panel1"
        Me.SuperTooltip1.SetSuperTooltip(Me.Panel1, CType(resources.GetObject("Panel1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
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
        Me.SuperTooltip1.SetSuperTooltip(Me.LabelX2, CType(resources.GetObject("LabelX2.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'Panel3
        '
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.ButtonX8)
        Me.Panel3.Name = "Panel3"
        Me.SuperTooltip1.SetSuperTooltip(Me.Panel3, CType(resources.GetObject("Panel3.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'ButtonX8
        '
        resources.ApplyResources(Me.ButtonX8, "ButtonX8")
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX8.FocusCuesEnabled = False
        Me.ButtonX8.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_triggering_16px
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX8, CType(resources.GetObject("ButtonX8.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX5, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX2, 0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.SuperTooltip1.SetSuperTooltip(Me.TableLayoutPanel2, CType(resources.GetObject("TableLayoutPanel2.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'ButtonX5
        '
        resources.ApplyResources(Me.ButtonX5, "ButtonX5")
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX5.FocusCuesEnabled = False
        Me.ButtonX5.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_delete_sign_16px_1
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX5, CType(resources.GetObject("ButtonX5.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX5.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'ButtonX3
        '
        resources.ApplyResources(Me.ButtonX3, "ButtonX3")
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_cancel_16px
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX3, CType(resources.GetObject("ButtonX3.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'ButtonX2
        '
        resources.ApplyResources(Me.ButtonX2, "ButtonX2")
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_edit_16px
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX2, CType(resources.GetObject("ButtonX2.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'LabelX_Description
        '
        resources.ApplyResources(Me.LabelX_Description, "LabelX_Description")
        Me.LabelX_Description.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Description.Name = "LabelX_Description"
        Me.SuperTooltip1.SetSuperTooltip(Me.LabelX_Description, CType(resources.GetObject("LabelX_Description.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.LabelX_Description.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX_Description.WordWrap = True
        '
        'LabelX_PatchName
        '
        resources.ApplyResources(Me.LabelX_PatchName, "LabelX_PatchName")
        Me.LabelX_PatchName.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_PatchName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_PatchName.Name = "LabelX_PatchName"
        Me.SuperTooltip1.SetSuperTooltip(Me.LabelX_PatchName, CType(resources.GetObject("LabelX_PatchName.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX4, 2, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.SuperTooltip1.SetSuperTooltip(Me.TableLayoutPanel1, CType(resources.GetObject("TableLayoutPanel1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'ButtonX1
        '
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_plus_math_16px
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX1, CType(resources.GetObject("ButtonX1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'ButtonX6
        '
        resources.ApplyResources(Me.ButtonX6, "ButtonX6")
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX6.FocusCuesEnabled = False
        Me.ButtonX6.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_edit_16px
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX6, CType(resources.GetObject("ButtonX6.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'ButtonX4
        '
        resources.ApplyResources(Me.ButtonX4, "ButtonX4")
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX4.FocusCuesEnabled = False
        Me.ButtonX4.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_delete_sign_16px_1
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX4, CType(resources.GetObject("ButtonX4.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX4.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'ComboBoxEx_Scripts
        '
        resources.ApplyResources(Me.ComboBoxEx_Scripts, "ComboBoxEx_Scripts")
        Me.ComboBoxEx_Scripts.DisplayMember = "Text"
        Me.ComboBoxEx_Scripts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_Scripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_Scripts.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_Scripts.FormattingEnabled = True
        Me.ComboBoxEx_Scripts.Name = "ComboBoxEx_Scripts"
        Me.ComboBoxEx_Scripts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ComboBoxEx_Scripts, CType(resources.GetObject("ComboBoxEx_Scripts.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
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
        Me.SuperTooltip1.SetSuperTooltip(Me.LabelX1, CType(resources.GetObject("LabelX1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'Flyout1
        '
        Me.Flyout1.Content = Me.Panel1
        Me.Flyout1.DisplayMode = DevComponents.DotNetBar.Controls.eFlyoutDisplayMode.Manual
        Me.Flyout1.DropShadow = False
        Me.Flyout1.Parent = Me
        '
        'ItemListBox1
        '
        resources.ApplyResources(Me.ItemListBox1, "ItemListBox1")
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ItemListBox1, CType(resources.GetObject("ItemListBox1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'SuperTooltip1
        '
        resources.ApplyResources(Me.SuperTooltip1, "SuperTooltip1")
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'TextBoxX1
        '
        resources.ApplyResources(Me.TextBoxX1, "TextBoxX1")
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.ButtonCustom.DisplayPosition = CType(resources.GetObject("TextBoxX1.ButtonCustom.DisplayPosition"), Integer)
        Me.TextBoxX1.ButtonCustom.Image = CType(resources.GetObject("TextBoxX1.ButtonCustom.Image"), System.Drawing.Image)
        Me.TextBoxX1.ButtonCustom.Text = resources.GetString("TextBoxX1.ButtonCustom.Text")
        Me.TextBoxX1.ButtonCustom.Tooltip = resources.GetString("TextBoxX1.ButtonCustom.Tooltip")
        Me.TextBoxX1.ButtonCustom2.DisplayPosition = CType(resources.GetObject("TextBoxX1.ButtonCustom2.DisplayPosition"), Integer)
        Me.TextBoxX1.ButtonCustom2.Image = CType(resources.GetObject("TextBoxX1.ButtonCustom2.Image"), System.Drawing.Image)
        Me.TextBoxX1.ButtonCustom2.Text = resources.GetString("TextBoxX1.ButtonCustom2.Text")
        Me.TextBoxX1.ButtonCustom2.Tooltip = resources.GetString("TextBoxX1.ButtonCustom2.Tooltip")
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.SuperTooltip1.SetSuperTooltip(Me.TextBoxX1, CType(resources.GetObject("TextBoxX1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.TextBoxX1.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        '
        'CircularProgress1
        '
        resources.ApplyResources(Me.CircularProgress1, "CircularProgress1")
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.SetVisibleStateOnStart = True
        Me.CircularProgress1.SetVisibleStateOnStop = True
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.SuperTooltip1.SetSuperTooltip(Me.CircularProgress1, CType(resources.GetObject("CircularProgress1.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'ButtonX9
        '
        resources.ApplyResources(Me.ButtonX9, "ButtonX9")
        Me.ButtonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX9.FocusCuesEnabled = False
        Me.ButtonX9.Name = "ButtonX9"
        Me.ButtonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX9, CType(resources.GetObject("ButtonX9.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX9.Symbol = "57676"
        Me.ButtonX9.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX9.SymbolSize = 12.0!
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.ItemListBox1)
        Me.Panel2.Controls.Add(Me.WarningBox_TweakUpdates)
        Me.Panel2.Name = "Panel2"
        Me.SuperTooltip1.SetSuperTooltip(Me.Panel2, CType(resources.GetObject("Panel2.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'WarningBox_TweakUpdates
        '
        resources.ApplyResources(Me.WarningBox_TweakUpdates, "WarningBox_TweakUpdates")
        Me.WarningBox_TweakUpdates.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WarningBox_TweakUpdates.CloseButtonVisible = False
        Me.WarningBox_TweakUpdates.ForeColor = System.Drawing.Color.Black
        Me.WarningBox_TweakUpdates.Name = "WarningBox_TweakUpdates"
        Me.SuperTooltip1.SetSuperTooltip(Me.WarningBox_TweakUpdates, CType(resources.GetObject("WarningBox_TweakUpdates.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        '
        'ButtonX7
        '
        resources.ApplyResources(Me.ButtonX7, "ButtonX7")
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.FocusCuesEnabled = False
        Me.ButtonX7.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_search_16px
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX7, CType(resources.GetObject("ButtonX7.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX7.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX7.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX7.SymbolSize = 12.0!
        '
        'ButtonX_AddNew
        '
        resources.ApplyResources(Me.ButtonX_AddNew, "ButtonX_AddNew")
        Me.ButtonX_AddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_AddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_AddNew.FocusCuesEnabled = False
        Me.ButtonX_AddNew.Image = Global.SM64_ROM_Manager.PatchScripts.MyIcons.icons8_plus_math_16px
        Me.ButtonX_AddNew.Name = "ButtonX_AddNew"
        Me.ButtonX_AddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX_AddNew, CType(resources.GetObject("ButtonX_AddNew.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.ButtonX_AddNew.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        '
        'TweakViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonX9)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.ButtonX_AddNew)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "TweakViewer"
        Me.SuperTooltip1.SetSuperTooltip(Me, CType(resources.GetObject("$this.SuperTooltip"), DevComponents.DotNetBar.SuperTooltipInfo))
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_AddNew As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBoxEx_Scripts As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Flyout1 As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents ItemListBox1 As SM64_ROM_Manager.Publics.Controls.ItemListBox
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents LabelX_PatchName As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Description As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents ButtonX9 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel2 As Panel
    Friend WithEvents WarningBox_TweakUpdates As DevComponents.DotNetBar.Controls.WarningBox
End Class
