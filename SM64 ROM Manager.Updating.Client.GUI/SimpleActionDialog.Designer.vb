<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleActionDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimpleActionDialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBarX_Progress = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.LabelX_Progress = New DevComponents.DotNetBar.LabelX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX_Progress)
        Me.Panel1.Controls.Add(Me.ProgressBarX_Progress)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 53)
        Me.Panel1.TabIndex = 0
        '
        'ProgressBarX_Progress
        '
        Me.ProgressBarX_Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.ProgressBarX_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX_Progress.Location = New System.Drawing.Point(3, 34)
        Me.ProgressBarX_Progress.Name = "ProgressBarX_Progress"
        Me.ProgressBarX_Progress.Size = New System.Drawing.Size(380, 16)
        Me.ProgressBarX_Progress.TabIndex = 0
        Me.ProgressBarX_Progress.Text = "ProgressBarX1"
        '
        'LabelX_Progress
        '
        Me.LabelX_Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Progress.Location = New System.Drawing.Point(3, 5)
        Me.LabelX_Progress.Name = "LabelX_Progress"
        Me.LabelX_Progress.Size = New System.Drawing.Size(380, 23)
        Me.LabelX_Progress.TabIndex = 1
        '
        'SimpleActionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 53)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SimpleActionDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Updates"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelX_Progress As DevComponents.DotNetBar.LabelX
    Friend WithEvents ProgressBarX_Progress As DevComponents.DotNetBar.Controls.ProgressBarX
End Class
