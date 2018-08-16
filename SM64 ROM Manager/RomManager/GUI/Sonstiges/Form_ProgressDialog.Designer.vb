<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_ProgressDialog
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'ProgressBarX1
        '
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.FocusCuesEnabled = False
        Me.ProgressBarX1.Location = New System.Drawing.Point(12, 38)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(260, 14)
        Me.ProgressBarX1.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(260, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX1.TabIndex = 1
        '
        'Form_ProgressDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 64)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.DoubleBuffered = True
        Me.Name = "Form_ProgressDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
