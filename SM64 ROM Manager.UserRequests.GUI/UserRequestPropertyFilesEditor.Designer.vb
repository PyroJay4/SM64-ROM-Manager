<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRequestPropertyFilesEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItemPanel1
        '
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel1.Location = New System.Drawing.Point(0, 27)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.ReserveLeftSpace = False
        Me.ItemPanel1.Size = New System.Drawing.Size(521, 407)
        Me.ItemPanel1.TabIndex = 0
        Me.ItemPanel1.Text = "ItemPanel1"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.SM64_ROM_Manager.UserRequests.GUI.My.Resources.Resources.icons8_plus_math_16px
        Me.ButtonX1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(125, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "Add files"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ButtonX2)
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(521, 27)
        Me.Panel1.TabIndex = 2
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Enabled = False
        Me.ButtonX2.Image = Global.SM64_ROM_Manager.UserRequests.GUI.My.Resources.Resources.icons8_delete_16px
        Me.ButtonX2.Location = New System.Drawing.Point(396, 0)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(125, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Remove"
        '
        'UserRequestPropertyFilesEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ItemPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UserRequestPropertyFilesEditor"
        Me.Size = New System.Drawing.Size(521, 434)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
End Class
