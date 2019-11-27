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
        Me.LabelX_Progress = New DevComponents.DotNetBar.LabelX()
        Me.ProgressBarX_Progress = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX_Progress)
        Me.Panel1.Controls.Add(Me.ProgressBarX_Progress)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LabelX_Progress
        '
        resources.ApplyResources(Me.LabelX_Progress, "LabelX_Progress")
        '
        '
        '
        Me.LabelX_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Progress.Name = "LabelX_Progress"
        '
        'ProgressBarX_Progress
        '
        resources.ApplyResources(Me.ProgressBarX_Progress, "ProgressBarX_Progress")
        '
        '
        '
        Me.ProgressBarX_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX_Progress.Name = "ProgressBarX_Progress"
        '
        'SimpleActionDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SimpleActionDialog"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelX_Progress As DevComponents.DotNetBar.LabelX
    Friend WithEvents ProgressBarX_Progress As DevComponents.DotNetBar.Controls.ProgressBarX
End Class
