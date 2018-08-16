<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScriptDumper(Of TCmd, eTypes)
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
        Me.PanelEx_PC = New DevComponents.DotNetBar.PanelEx()
        Me.SuspendLayout()
        '
        'PanelEx_PC
        '
        Me.PanelEx_PC.AutoScroll = True
        Me.PanelEx_PC.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx_PC.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx_PC.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx_PC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx_PC.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx_PC.Name = "PanelEx_PC"
        Me.PanelEx_PC.Size = New System.Drawing.Size(998, 679)
        Me.PanelEx_PC.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx_PC.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx_PC.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx_PC.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx_PC.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx_PC.Style.GradientAngle = 90
        Me.PanelEx_PC.TabIndex = 0
        '
        'ScriptDumper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(998, 679)
        Me.Controls.Add(Me.PanelEx_PC)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Name = "ScriptDumper"
        Me.Text = "ScriptDumper"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelEx_PC As DevComponents.DotNetBar.PanelEx
End Class
