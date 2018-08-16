<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateDialog))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_OldVersion = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_NewVersion = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.ButtonX_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Install = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.FontBold = True
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(92, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Newest Version:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 41)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(92, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Current Version:"
        '
        'LabelX_OldVersion
        '
        '
        '
        '
        Me.LabelX_OldVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_OldVersion.Location = New System.Drawing.Point(110, 41)
        Me.LabelX_OldVersion.Name = "LabelX_OldVersion"
        Me.LabelX_OldVersion.Size = New System.Drawing.Size(162, 23)
        Me.LabelX_OldVersion.TabIndex = 3
        '
        'LabelX_NewVersion
        '
        '
        '
        '
        Me.LabelX_NewVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_NewVersion.FontBold = True
        Me.LabelX_NewVersion.Location = New System.Drawing.Point(110, 12)
        Me.LabelX_NewVersion.Name = "LabelX_NewVersion"
        Me.LabelX_NewVersion.Size = New System.Drawing.Size(162, 23)
        Me.LabelX_NewVersion.TabIndex = 2
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(12, 99)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(92, 23)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Changelog:"
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
        Me.TextBoxX1.Location = New System.Drawing.Point(12, 128)
        Me.TextBoxX1.Multiline = True
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxX1.Size = New System.Drawing.Size(260, 176)
        Me.TextBoxX1.TabIndex = 5
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.Color.DarkGray
        Me.Line1.Location = New System.Drawing.Point(12, 70)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(260, 23)
        Me.Line1.TabIndex = 6
        Me.Line1.Text = "Line1"
        '
        'ButtonX_Cancel
        '
        Me.ButtonX_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX_Cancel.FocusCuesEnabled = False
        Me.ButtonX_Cancel.Location = New System.Drawing.Point(197, 310)
        Me.ButtonX_Cancel.Name = "ButtonX_Cancel"
        Me.ButtonX_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Cancel.TabIndex = 7
        Me.ButtonX_Cancel.Text = "Cancel"
        '
        'ButtonX_Install
        '
        Me.ButtonX_Install.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Install.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Install.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX_Install.FocusCuesEnabled = False
        Me.ButtonX_Install.Location = New System.Drawing.Point(116, 310)
        Me.ButtonX_Install.Name = "ButtonX_Install"
        Me.ButtonX_Install.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_Install.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Install.TabIndex = 8
        Me.ButtonX_Install.Text = "Install"
        '
        'UpdateDialog
        '
        Me.AcceptButton = Me.ButtonX_Install
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX_Cancel
        Me.ClientSize = New System.Drawing.Size(284, 345)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonX_Install)
        Me.Controls.Add(Me.ButtonX_Cancel)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX_OldVersion)
        Me.Controls.Add(Me.LabelX_NewVersion)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UpdateDialog"
        Me.Text = "UpdateDialog"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_OldVersion As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_NewVersion As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents ButtonX_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Install As DevComponents.DotNetBar.ButtonX
End Class
