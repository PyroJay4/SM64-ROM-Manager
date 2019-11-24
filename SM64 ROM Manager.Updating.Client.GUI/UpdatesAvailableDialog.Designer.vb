Imports DevComponents.DotNetBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdatesAvailableDialog
    Inherits OfficeForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdatesAvailableDialog))
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.PictureBox_AppIcon = New System.Windows.Forms.PictureBox()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LabelX_NewVersion = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.RichTextBoxEx_Changelog = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.LabelX_NewChannel = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LabelX_NewBuild = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem5 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LabelX_CurrentVersion = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem6 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LabelX_CurrentChannel = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem7 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LabelX_CurrentBuild = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem8 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.ButtonX_Install = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.LayoutControlItem10 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PictureBox_AppIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControl1.Controls.Add(Me.PictureBox_AppIcon)
        Me.LayoutControl1.Controls.Add(Me.LabelX1)
        Me.LayoutControl1.Controls.Add(Me.LabelX_NewVersion)
        Me.LayoutControl1.Controls.Add(Me.LabelX_NewChannel)
        Me.LayoutControl1.Controls.Add(Me.LabelX_NewBuild)
        Me.LayoutControl1.Controls.Add(Me.LabelX_CurrentVersion)
        Me.LayoutControl1.Controls.Add(Me.LabelX_CurrentChannel)
        Me.LayoutControl1.Controls.Add(Me.LabelX_CurrentBuild)
        Me.LayoutControl1.Controls.Add(Me.RichTextBoxEx_Changelog)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_Install)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_Cancel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.ForeColor = System.Drawing.Color.Black
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutSpacerItem1, Me.LayoutControlItem10, Me.LayoutControlItem11})
        Me.LayoutControl1.Size = New System.Drawing.Size(484, 461)
        Me.LayoutControl1.TabIndex = 0
        '
        'PictureBox_AppIcon
        '
        Me.PictureBox_AppIcon.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox_AppIcon.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.PictureBox_AppIcon.Name = "PictureBox_AppIcon"
        Me.PictureBox_AppIcon.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox_AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_AppIcon.TabIndex = 0
        Me.PictureBox_AppIcon.TabStop = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PictureBox_AppIcon
        Me.LayoutControlItem1.Height = 58
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(50, 50)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "Label:"
        Me.LayoutControlItem1.TextVisible = False
        Me.LayoutControlItem1.Width = 58
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(62, 4)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(418, 50)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Update available"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LabelX1
        Me.LayoutControlItem2.Height = 31
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Text = "Label:"
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Width = 99
        Me.LayoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LabelX_NewVersion
        '
        '
        '
        '
        Me.LabelX_NewVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_NewVersion.Location = New System.Drawing.Point(102, 62)
        Me.LabelX_NewVersion.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.LabelX_NewVersion.Name = "LabelX_NewVersion"
        Me.LabelX_NewVersion.Size = New System.Drawing.Size(136, 23)
        Me.LabelX_NewVersion.TabIndex = 2
        Me.LabelX_NewVersion.Text = "LabelX2"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LabelX_NewVersion
        Me.LayoutControlItem3.Height = 31
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Text = "Available Version:"
        Me.LayoutControlItem3.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem3.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem3.Width = 50
        Me.LayoutControlItem3.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'RichTextBoxEx_Changelog
        '
        '
        '
        '
        Me.RichTextBoxEx_Changelog.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.RichTextBoxEx_Changelog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RichTextBoxEx_Changelog.Location = New System.Drawing.Point(4, 143)
        Me.RichTextBoxEx_Changelog.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.RichTextBoxEx_Changelog.Name = "RichTextBoxEx_Changelog"
        Me.RichTextBoxEx_Changelog.ReadOnly = True
        Me.RichTextBoxEx_Changelog.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1031{\fonttbl{\f0\fnil\fcharset0 Microsoft S" &
    "ans Serif;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs17\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.RichTextBoxEx_Changelog.Size = New System.Drawing.Size(476, 279)
        Me.RichTextBoxEx_Changelog.TabIndex = 8
        '
        'LabelX_NewChannel
        '
        '
        '
        '
        Me.LabelX_NewChannel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_NewChannel.Location = New System.Drawing.Point(299, 62)
        Me.LabelX_NewChannel.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX_NewChannel.Name = "LabelX_NewChannel"
        Me.LabelX_NewChannel.Size = New System.Drawing.Size(84, 23)
        Me.LabelX_NewChannel.TabIndex = 3
        Me.LabelX_NewChannel.Text = "LabelX3"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.LabelX_NewChannel
        Me.LayoutControlItem4.Height = 31
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.SharedTextSizeEnabled = False
        Me.LayoutControlItem4.Text = "Channel:"
        Me.LayoutControlItem4.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem4.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem4.Width = 30
        Me.LayoutControlItem4.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LabelX_NewBuild
        '
        '
        '
        '
        Me.LabelX_NewBuild.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_NewBuild.Location = New System.Drawing.Point(427, 62)
        Me.LabelX_NewBuild.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX_NewBuild.Name = "LabelX_NewBuild"
        Me.LabelX_NewBuild.Size = New System.Drawing.Size(53, 23)
        Me.LabelX_NewBuild.TabIndex = 4
        Me.LabelX_NewBuild.Text = "LabelX4"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LabelX_NewBuild
        Me.LayoutControlItem5.Height = 31
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.SharedTextSizeEnabled = False
        Me.LayoutControlItem5.Text = "Build:"
        Me.LayoutControlItem5.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem5.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem5.Width = 20
        Me.LayoutControlItem5.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LabelX_CurrentVersion
        '
        '
        '
        '
        Me.LabelX_CurrentVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_CurrentVersion.Location = New System.Drawing.Point(102, 93)
        Me.LabelX_CurrentVersion.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX_CurrentVersion.Name = "LabelX_CurrentVersion"
        Me.LabelX_CurrentVersion.Size = New System.Drawing.Size(136, 23)
        Me.LabelX_CurrentVersion.TabIndex = 5
        Me.LabelX_CurrentVersion.Text = "LabelX5"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LabelX_CurrentVersion
        Me.LayoutControlItem6.Height = 31
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Text = "Current Version:"
        Me.LayoutControlItem6.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem6.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem6.Width = 50
        Me.LayoutControlItem6.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LabelX_CurrentChannel
        '
        '
        '
        '
        Me.LabelX_CurrentChannel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_CurrentChannel.Location = New System.Drawing.Point(299, 93)
        Me.LabelX_CurrentChannel.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX_CurrentChannel.Name = "LabelX_CurrentChannel"
        Me.LabelX_CurrentChannel.Size = New System.Drawing.Size(84, 23)
        Me.LabelX_CurrentChannel.TabIndex = 6
        Me.LabelX_CurrentChannel.Text = "LabelX6"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LabelX_CurrentChannel
        Me.LayoutControlItem7.Height = 31
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.SharedTextSizeEnabled = False
        Me.LayoutControlItem7.Text = "Channel:"
        Me.LayoutControlItem7.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem7.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem7.Width = 30
        Me.LayoutControlItem7.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LabelX_CurrentBuild
        '
        '
        '
        '
        Me.LabelX_CurrentBuild.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_CurrentBuild.Location = New System.Drawing.Point(427, 93)
        Me.LabelX_CurrentBuild.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX_CurrentBuild.Name = "LabelX_CurrentBuild"
        Me.LabelX_CurrentBuild.Size = New System.Drawing.Size(53, 23)
        Me.LabelX_CurrentBuild.TabIndex = 7
        Me.LabelX_CurrentBuild.Text = "LabelX7"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.LabelX_CurrentBuild
        Me.LayoutControlItem8.Height = 31
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.SharedTextSizeEnabled = False
        Me.LayoutControlItem8.Text = "Build:"
        Me.LayoutControlItem8.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem8.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem8.Width = 20
        Me.LayoutControlItem8.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.RichTextBoxEx_Changelog
        Me.LayoutControlItem9.Height = 99
        Me.LayoutControlItem9.HeightType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Text = "Changelog:"
        Me.LayoutControlItem9.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem9.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem9.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutControlItem9.Width = 100
        Me.LayoutControlItem9.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'ButtonX_Install
        '
        Me.ButtonX_Install.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Install.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Install.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX_Install.Location = New System.Drawing.Point(288, 430)
        Me.ButtonX_Install.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.ButtonX_Install.Name = "ButtonX_Install"
        Me.ButtonX_Install.Size = New System.Drawing.Size(92, 23)
        Me.ButtonX_Install.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Install.TabIndex = 10
        Me.ButtonX_Install.Text = "Install"
        '
        'ButtonX_Cancel
        '
        Me.ButtonX_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX_Cancel.Location = New System.Drawing.Point(388, 430)
        Me.ButtonX_Cancel.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.ButtonX_Cancel.Name = "ButtonX_Cancel"
        Me.ButtonX_Cancel.Size = New System.Drawing.Size(92, 23)
        Me.ButtonX_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Cancel.TabIndex = 11
        Me.ButtonX_Cancel.Text = "Cacnel"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.ButtonX_Install
        Me.LayoutControlItem10.Height = 31
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Width = 100
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.ButtonX_Cancel
        Me.LayoutControlItem11.Height = 31
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Width = 100
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 31
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 99
        Me.LayoutSpacerItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'UpdatesAvailableDialog
        '
        Me.AcceptButton = Me.ButtonX_Install
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX_Cancel
        Me.ClientSize = New System.Drawing.Size(484, 461)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdatesAvailableDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Updates"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PictureBox_AppIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As Layout.LayoutControl
    Friend WithEvents PictureBox_AppIcon As PictureBox
    Friend WithEvents LayoutControlItem1 As Layout.LayoutControlItem
    Friend WithEvents LabelX1 As LabelX
    Friend WithEvents LayoutControlItem2 As Layout.LayoutControlItem
    Friend WithEvents LabelX_NewVersion As LabelX
    Friend WithEvents LayoutControlItem3 As Layout.LayoutControlItem
    Friend WithEvents RichTextBoxEx_Changelog As Controls.RichTextBoxEx
    Friend WithEvents LabelX_NewChannel As LabelX
    Friend WithEvents LabelX_NewBuild As LabelX
    Friend WithEvents LabelX_CurrentVersion As LabelX
    Friend WithEvents LabelX_CurrentChannel As LabelX
    Friend WithEvents LabelX_CurrentBuild As LabelX
    Friend WithEvents LayoutControlItem4 As Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As Layout.LayoutControlItem
    Friend WithEvents ButtonX_Install As ButtonX
    Friend WithEvents ButtonX_Cancel As ButtonX
    Friend WithEvents LayoutSpacerItem1 As Layout.LayoutSpacerItem
    Friend WithEvents LayoutControlItem10 As Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As Layout.LayoutControlItem
End Class
