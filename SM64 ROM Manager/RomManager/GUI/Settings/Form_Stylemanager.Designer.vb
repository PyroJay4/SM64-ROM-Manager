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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Stylemanager))
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CheckBoxX_KeepEditorControlBarBlue = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.SuspendLayout()
        '
        'ComboBoxEx1
        '
        resources.ApplyResources(Me.ComboBoxEx1, "ComboBoxEx1")
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownHeight = 150
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_KeepEditorControlBarBlue
        '
        resources.ApplyResources(Me.CheckBoxX_KeepEditorControlBarBlue, "CheckBoxX_KeepEditorControlBarBlue")
        '
        '
        '
        Me.CheckBoxX_KeepEditorControlBarBlue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_KeepEditorControlBarBlue.FocusCuesEnabled = False
        Me.CheckBoxX_KeepEditorControlBarBlue.Name = "CheckBoxX_KeepEditorControlBarBlue"
        Me.CheckBoxX_KeepEditorControlBarBlue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Form_Stylemanager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BottomLeftCornerSize = 0
        Me.BottomRightCornerSize = 0
        Me.Controls.Add(Me.CheckBoxX_KeepEditorControlBarBlue)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Stylemanager"
        Me.ShowInTaskbar = False
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CheckBoxX_KeepEditorControlBarBlue As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
