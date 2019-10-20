<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InputDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InputDialog))
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(218, 32)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "Okay"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(290, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Input a value here:"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(3, 34)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(209, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.ComboBoxEx1)
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 58)
        Me.Panel1.TabIndex = 4
        '
        'InputDialog
        '
        Me.AcceptButton = Me.ButtonX1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 58)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InputDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Panel1 As Windows.Forms.Panel
End Class
