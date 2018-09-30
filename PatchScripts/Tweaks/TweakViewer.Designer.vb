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
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_AddNew = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.ItemListBox1 = New Publics.Controls.ItemListBox()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX5.FocusCuesEnabled = False
        Me.ButtonX5.Location = New System.Drawing.Point(29, 3)
        Me.ButtonX5.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.Symbol = "59471"
        Me.ButtonX5.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX5.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX5.SymbolSize = 12.0!
        Me.ButtonX5.TabIndex = 10
        '
        'ButtonX_AddNew
        '
        Me.ButtonX_AddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_AddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_AddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_AddNew.FocusCuesEnabled = False
        Me.ButtonX_AddNew.Location = New System.Drawing.Point(407, 12)
        Me.ButtonX_AddNew.Name = "ButtonX_AddNew"
        Me.ButtonX_AddNew.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_AddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_AddNew.Symbol = "57669"
        Me.ButtonX_AddNew.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_AddNew.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_AddNew.SymbolSize = 12.0!
        Me.ButtonX_AddNew.TabIndex = 6
        Me.ButtonX_AddNew.Text = "New"
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX8.FocusCuesEnabled = False
        Me.ButtonX8.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Size = New System.Drawing.Size(86, 20)
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX8.Symbol = "58343"
        Me.ButtonX8.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX8.SymbolSize = 12.0!
        Me.ButtonX8.TabIndex = 36
        Me.ButtonX8.Text = "Apply"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.LabelX_Description)
        Me.Panel1.Controls.Add(Me.LabelX_PatchName)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.ComboBoxEx_Scripts)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Location = New System.Drawing.Point(118, 102)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(298, 191)
        Me.Panel1.TabIndex = 37
        Me.Panel1.Visible = False
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(230, 23)
        Me.LabelX2.TabIndex = 52
        Me.LabelX2.Text = "Description:"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoSize = True
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.ButtonX8)
        Me.Panel3.Location = New System.Drawing.Point(203, 162)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(92, 26)
        Me.Panel3.TabIndex = 51
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX5, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonX2, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(220, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(78, 26)
        Me.TableLayoutPanel2.TabIndex = 48
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Location = New System.Drawing.Point(55, 3)
        Me.ButtonX3.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        Me.ButtonX2.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.Symbol = "57680"
        Me.ButtonX2.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
        Me.ButtonX2.TabIndex = 45
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
        Me.LabelX_Description.Location = New System.Drawing.Point(3, 61)
        Me.LabelX_Description.Name = "LabelX_Description"
        Me.LabelX_Description.Size = New System.Drawing.Size(292, 66)
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
        Me.LabelX_PatchName.Location = New System.Drawing.Point(3, 3)
        Me.LabelX_PatchName.Name = "LabelX_PatchName"
        Me.LabelX_PatchName.Size = New System.Drawing.Size(230, 23)
        Me.LabelX_PatchName.TabIndex = 49
        Me.LabelX_PatchName.Text = "Name:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX4, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(51, 162)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(78, 26)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = "57669"
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        Me.ButtonX1.TabIndex = 42
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX6.FocusCuesEnabled = False
        Me.ButtonX6.Location = New System.Drawing.Point(29, 3)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = "57680"
        Me.ButtonX6.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonX6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX6.SymbolSize = 12.0!
        Me.ButtonX6.TabIndex = 44
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX4.FocusCuesEnabled = False
        Me.ButtonX4.Location = New System.Drawing.Point(55, 3)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(20, 20)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.Symbol = "57676"
        Me.ButtonX4.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX4.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX4.SymbolSize = 12.0!
        Me.ButtonX4.TabIndex = 45
        '
        'ComboBoxEx_Scripts
        '
        Me.ComboBoxEx_Scripts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx_Scripts.DisplayMember = "Text"
        Me.ComboBoxEx_Scripts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_Scripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_Scripts.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_Scripts.FormattingEnabled = True
        Me.ComboBoxEx_Scripts.ItemHeight = 15
        Me.ComboBoxEx_Scripts.Location = New System.Drawing.Point(51, 134)
        Me.ComboBoxEx_Scripts.Name = "ComboBoxEx_Scripts"
        Me.ComboBoxEx_Scripts.Size = New System.Drawing.Size(244, 21)
        Me.ComboBoxEx_Scripts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx_Scripts.TabIndex = 38
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 133)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(42, 23)
        Me.LabelX1.TabIndex = 37
        Me.LabelX1.Text = "Script:"
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
        Me.ItemListBox1.AutoScroll = True
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        Me.ItemListBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemListBox1.Location = New System.Drawing.Point(0, 41)
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Size = New System.Drawing.Size(482, 568)
        Me.ItemListBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ItemListBox1.TabIndex = 39
        Me.ItemListBox1.Text = "ItemListBox1"
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(0, 13)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(320, 20)
        Me.TextBoxX1.TabIndex = 43
        Me.TextBoxX1.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX1.WatermarkText = "Search ..."
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.FocusCuesEnabled = False
        Me.ButtonX7.Location = New System.Drawing.Point(326, 12)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX7.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX7.SymbolSize = 12.0!
        Me.ButtonX7.TabIndex = 44
        Me.ButtonX7.Text = "Search"
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(204, 267)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.Size = New System.Drawing.Size(75, 75)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 45
        Me.CircularProgress1.Visible = False
        '
        'TweakViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 609)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.ButtonX_AddNew)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ItemListBox1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TweakViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tweaks"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
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
    Friend WithEvents ItemListBox1 As Publics.Controls.ItemListBox
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
End Class
