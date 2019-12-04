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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserRequestPropertyFilesEditor))
        Me.ItemPanel_Files = New DevComponents.DotNetBar.ItemPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX_Remove = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Add = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItemPanel_Files
        '
        resources.ApplyResources(Me.ItemPanel_Files, "ItemPanel_Files")
        '
        '
        '
        Me.ItemPanel_Files.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel_Files.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel_Files.ContainerControlProcessDialogKey = True
        Me.ItemPanel_Files.DragDropSupport = True
        Me.ItemPanel_Files.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel_Files.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel_Files.Name = "ItemPanel_Files"
        Me.ItemPanel_Files.ReserveLeftSpace = False
        Me.ItemPanel_Files.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ButtonX_Remove)
        Me.Panel1.Controls.Add(Me.ButtonX_Add)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'ButtonX_Remove
        '
        Me.ButtonX_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX_Remove, "ButtonX_Remove")
        Me.ButtonX_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Remove.Image = Global.SM64_ROM_Manager.UserRequests.GUI.My.Resources.Resources.icons8_delete_16px
        Me.ButtonX_Remove.Name = "ButtonX_Remove"
        Me.ButtonX_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_Add
        '
        Me.ButtonX_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Add.Image = Global.SM64_ROM_Manager.UserRequests.GUI.My.Resources.Resources.icons8_plus_math_16px
        resources.ApplyResources(Me.ButtonX_Add, "ButtonX_Add")
        Me.ButtonX_Add.Name = "ButtonX_Add"
        Me.ButtonX_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'UserRequestPropertyFilesEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ItemPanel_Files)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UserRequestPropertyFilesEditor"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ItemPanel_Files As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents ButtonX_Add As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonX_Remove As DevComponents.DotNetBar.ButtonX
End Class
