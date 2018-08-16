<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValueInputDialog
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
        Me.ValueTextBox = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.InfoLabel = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX_Okay = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'ValueTextBox
        '
        Me.ValueTextBox.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ValueTextBox.Border.Class = "TextBoxBorder"
        Me.ValueTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ValueTextBox.DisabledBackColor = System.Drawing.Color.White
        Me.ValueTextBox.ForeColor = System.Drawing.Color.Black
        Me.ValueTextBox.Location = New System.Drawing.Point(12, 41)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.PreventEnterBeep = True
        Me.ValueTextBox.Size = New System.Drawing.Size(128, 20)
        Me.ValueTextBox.TabIndex = 0
        '
        'InfoLabel
        '
        '
        '
        '
        Me.InfoLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.InfoLabel.Location = New System.Drawing.Point(12, 12)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(128, 23)
        Me.InfoLabel.TabIndex = 1
        Me.InfoLabel.Text = "Value:"
        '
        'ButtonX_Okay
        '
        Me.ButtonX_Okay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Okay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX_Okay.FocusCuesEnabled = False
        Me.ButtonX_Okay.Location = New System.Drawing.Point(12, 67)
        Me.ButtonX_Okay.Name = "ButtonX_Okay"
        Me.ButtonX_Okay.Size = New System.Drawing.Size(61, 23)
        Me.ButtonX_Okay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Okay.TabIndex = 2
        Me.ButtonX_Okay.Text = "Okay"
        '
        'ButtonX_Cancel
        '
        Me.ButtonX_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX_Cancel.FocusCuesEnabled = False
        Me.ButtonX_Cancel.Location = New System.Drawing.Point(79, 67)
        Me.ButtonX_Cancel.Name = "ButtonX_Cancel"
        Me.ButtonX_Cancel.Size = New System.Drawing.Size(61, 23)
        Me.ButtonX_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Cancel.TabIndex = 3
        Me.ButtonX_Cancel.Text = "Cancel"
        '
        'ValueInputDialog
        '
        Me.AcceptButton = Me.ButtonX_Okay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX_Cancel
        Me.ClientSize = New System.Drawing.Size(151, 101)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonX_Cancel)
        Me.Controls.Add(Me.ButtonX_Okay)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.ValueTextBox)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ValueInputDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ValueTextBox As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents InfoLabel As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX_Okay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Cancel As DevComponents.DotNetBar.ButtonX
End Class
