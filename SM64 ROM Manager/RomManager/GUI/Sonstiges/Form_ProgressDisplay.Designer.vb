<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ProgressDisplay
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
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line4 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.SuspendLayout()
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Line1.Location = New System.Drawing.Point(0, 0)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(300, 5)
        Me.Line1.TabIndex = 0
        Me.Line1.Text = "Line1"
        Me.Line1.Thickness = 5
        '
        'Line2
        '
        Me.Line2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Line2.Location = New System.Drawing.Point(0, 45)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(300, 5)
        Me.Line2.TabIndex = 1
        Me.Line2.Text = "Line2"
        Me.Line2.Thickness = 5
        '
        'Line3
        '
        Me.Line3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Line3.Location = New System.Drawing.Point(0, 5)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(5, 40)
        Me.Line3.TabIndex = 2
        Me.Line3.Text = "Line3"
        Me.Line3.Thickness = 5
        Me.Line3.VerticalLine = True
        '
        'Line4
        '
        Me.Line4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Line4.Location = New System.Drawing.Point(295, 5)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(5, 40)
        Me.Line4.TabIndex = 3
        Me.Line4.Text = "Line4"
        Me.Line4.Thickness = 5
        Me.Line4.VerticalLine = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(237, 26)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Saving Level ..."
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(262, 12)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.Size = New System.Drawing.Size(26, 26)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 5
        '
        'Form_ProgressDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(300, 50)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Line4)
        Me.Controls.Add(Me.Line3)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Line1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.HelpButton = True
        Me.Name = "Form_ProgressDisplay"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form_ProgressDisplay"
        Me.TopLeftCornerSize = 0
        Me.TopMost = True
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line4 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
End Class
