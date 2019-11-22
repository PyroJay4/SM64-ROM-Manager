<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApplicationVersionInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApplicationVersionInput))
        Me.TextBoxX_VersionName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_Version = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ComboBoxEx_Channel = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.IntegerInput_Build = New DevComponents.Editors.IntegerInput()
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.ButtonX_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Okay = New DevComponents.DotNetBar.ButtonX()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutControlItem5 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        CType(Me.IntegerInput_Build, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxX_VersionName
        '
        Me.TextBoxX_VersionName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_VersionName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_VersionName.Border.Class = "TextBoxBorder"
        Me.TextBoxX_VersionName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_VersionName.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_VersionName.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_VersionName.Location = New System.Drawing.Point(53, 4)
        Me.TextBoxX_VersionName.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxX_VersionName.Name = "TextBoxX_VersionName"
        Me.TextBoxX_VersionName.PreventEnterBeep = True
        Me.TextBoxX_VersionName.Size = New System.Drawing.Size(275, 20)
        Me.TextBoxX_VersionName.TabIndex = 0
        Me.TextBoxX_VersionName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_VersionName.WatermarkText = "Bspw.: Version 1.2.5.0 - Dark Mode und vieles mehr!"
        '
        'TextBoxX_Version
        '
        Me.TextBoxX_Version.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_Version.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Version.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Version.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Version.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Version.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Version.Location = New System.Drawing.Point(53, 32)
        Me.TextBoxX_Version.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxX_Version.Name = "TextBoxX_Version"
        Me.TextBoxX_Version.PreventEnterBeep = True
        Me.TextBoxX_Version.Size = New System.Drawing.Size(275, 20)
        Me.TextBoxX_Version.TabIndex = 1
        Me.TextBoxX_Version.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_Version.WatermarkText = "Bspw.: 1.2.5.0"
        '
        'ComboBoxEx_Channel
        '
        Me.ComboBoxEx_Channel.DisplayMember = "Text"
        Me.ComboBoxEx_Channel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_Channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_Channel.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_Channel.FormattingEnabled = True
        Me.ComboBoxEx_Channel.ItemHeight = 15
        Me.ComboBoxEx_Channel.Location = New System.Drawing.Point(53, 60)
        Me.ComboBoxEx_Channel.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxEx_Channel.Name = "ComboBoxEx_Channel"
        Me.ComboBoxEx_Channel.Size = New System.Drawing.Size(275, 21)
        Me.ComboBoxEx_Channel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx_Channel.TabIndex = 2
        '
        'IntegerInput_Build
        '
        Me.IntegerInput_Build.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.IntegerInput_Build.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_Build.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_Build.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_Build.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.IntegerInput_Build.Location = New System.Drawing.Point(53, 89)
        Me.IntegerInput_Build.Margin = New System.Windows.Forms.Padding(0)
        Me.IntegerInput_Build.MinValue = 0
        Me.IntegerInput_Build.Name = "IntegerInput_Build"
        Me.IntegerInput_Build.ShowUpDown = True
        Me.IntegerInput_Build.Size = New System.Drawing.Size(275, 20)
        Me.IntegerInput_Build.TabIndex = 3
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LayoutControl1.Controls.Add(Me.TextBoxX_VersionName)
        Me.LayoutControl1.Controls.Add(Me.TextBoxX_Version)
        Me.LayoutControl1.Controls.Add(Me.ComboBoxEx_Channel)
        Me.LayoutControl1.Controls.Add(Me.IntegerInput_Build)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_Cancel)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_Okay)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.ForeColor = System.Drawing.Color.Black
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutSpacerItem1, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControl1.Size = New System.Drawing.Size(332, 144)
        Me.LayoutControl1.TabIndex = 5
        '
        'ButtonX_Cancel
        '
        Me.ButtonX_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX_Cancel.Location = New System.Drawing.Point(170, 117)
        Me.ButtonX_Cancel.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonX_Cancel.Name = "ButtonX_Cancel"
        Me.ButtonX_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Cancel.TabIndex = 5
        Me.ButtonX_Cancel.Text = "Abbrechen"
        '
        'ButtonX_Okay
        '
        Me.ButtonX_Okay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Okay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX_Okay.Location = New System.Drawing.Point(253, 117)
        Me.ButtonX_Okay.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonX_Okay.Name = "ButtonX_Okay"
        Me.ButtonX_Okay.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_Okay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Okay.TabIndex = 6
        Me.ButtonX_Okay.Text = "Okay"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextBoxX_VersionName
        Me.LayoutControlItem1.Height = 28
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "Name:"
        Me.LayoutControlItem1.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem1.Width = 100
        Me.LayoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextBoxX_Version
        Me.LayoutControlItem2.Height = 28
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Text = "Version:"
        Me.LayoutControlItem2.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem2.Width = 100
        Me.LayoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ComboBoxEx_Channel
        Me.LayoutControlItem3.Height = 29
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Text = "Kanal:"
        Me.LayoutControlItem3.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem3.Width = 100
        Me.LayoutControlItem3.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.IntegerInput_Build
        Me.LayoutControlItem4.Height = 28
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Text = "Build:"
        Me.LayoutControlItem4.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem4.Width = 100
        Me.LayoutControlItem4.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 31
        Me.LayoutSpacerItem1.HeightType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 99
        Me.LayoutSpacerItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ButtonX_Cancel
        Me.LayoutControlItem5.Height = 31
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Width = 83
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.ButtonX_Okay
        Me.LayoutControlItem6.Height = 31
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Width = 83
        '
        'ApplicationVersionInput
        '
        Me.AcceptButton = Me.ButtonX_Okay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX_Cancel
        Me.ClientSize = New System.Drawing.Size(332, 144)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ApplicationVersionInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Version"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.IntegerInput_Build, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxX_VersionName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_Version As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ComboBoxEx_Channel As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents IntegerInput_Build As DevComponents.Editors.IntegerInput
    Friend WithEvents LayoutControl1 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents ButtonX_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Okay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutControlItem5 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevComponents.DotNetBar.Layout.LayoutControlItem
End Class
