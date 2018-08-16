<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ErrorDialog
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
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(355, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "<div align=""center""><b><font size=""14"">An Unknown Error happened!</font></b></div" &
    ">"
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
        Me.TextBoxX1.Location = New System.Drawing.Point(12, 41)
        Me.TextBoxX1.Multiline = True
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.ReadOnly = True
        Me.TextBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxX1.Size = New System.Drawing.Size(355, 232)
        Me.TextBoxX1.TabIndex = 10
        Me.TextBoxX1.WordWrap = False
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Location = New System.Drawing.Point(228, 279)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(76, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 4
        Me.ButtonX2.Text = "Continue"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.BackColor = System.Drawing.Color.White
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(310, 279)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(57, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = ""
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX1.SymbolSize = 12.0!
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "Exit"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Location = New System.Drawing.Point(12, 279)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(89, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.Symbol = "57677"
        Me.ButtonX3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX3.SymbolSize = 12.0!
        Me.ButtonX3.TabIndex = 5
        Me.ButtonX3.Text = "Copy Text"
        '
        'Form_ErrorDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(379, 314)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TextBoxX1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_ErrorDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Critical Error"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
End Class
