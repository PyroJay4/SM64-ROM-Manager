<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Stylemanager
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
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CheckBoxX_KeepEditorControlBarBlue = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SuspendLayout()
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownHeight = 150
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.IntegralHeight = False
        Me.ComboBoxEx1.ItemHeight = 15
        Me.ComboBoxEx1.Location = New System.Drawing.Point(12, 12)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(168, 21)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 0
        '
        'CheckBoxX_KeepEditorControlBarBlue
        '
        '
        '
        '
        Me.CheckBoxX_KeepEditorControlBarBlue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_KeepEditorControlBarBlue.FocusCuesEnabled = False
        Me.CheckBoxX_KeepEditorControlBarBlue.Location = New System.Drawing.Point(12, 39)
        Me.CheckBoxX_KeepEditorControlBarBlue.Name = "CheckBoxX_KeepEditorControlBarBlue"
        Me.CheckBoxX_KeepEditorControlBarBlue.Size = New System.Drawing.Size(168, 36)
        Me.CheckBoxX_KeepEditorControlBarBlue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_KeepEditorControlBarBlue.TabIndex = 1
        Me.CheckBoxX_KeepEditorControlBarBlue.Text = "Always keep blue Colors in Model Viewer and Level Editor"
        '
        'Form_Stylemanager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.ClientSize = New System.Drawing.Size(192, 87)
        Me.Controls.Add(Me.CheckBoxX_KeepEditorControlBarBlue)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Stylemanager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Style Manager"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CheckBoxX_KeepEditorControlBarBlue As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
