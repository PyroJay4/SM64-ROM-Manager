<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PluginInstallerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PluginInstallerForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX_Remove = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Install = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem_SingleFile = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ZipFile = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Directory = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonX_Close = New DevComponents.DotNetBar.ButtonX()
        Me.ListViewEx_Plugins = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ButtonX_Remove)
        Me.Panel1.Controls.Add(Me.ButtonX_Install)
        Me.Panel1.Controls.Add(Me.ButtonX_Close)
        Me.Panel1.Controls.Add(Me.ListViewEx_Plugins)
        Me.Panel1.Name = "Panel1"
        '
        'ButtonX_Remove
        '
        resources.ApplyResources(Me.ButtonX_Remove, "ButtonX_Remove")
        Me.ButtonX_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Remove.Name = "ButtonX_Remove"
        Me.ButtonX_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_Install
        '
        resources.ApplyResources(Me.ButtonX_Install, "ButtonX_Install")
        Me.ButtonX_Install.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Install.AutoExpandOnClick = True
        Me.ButtonX_Install.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Install.Name = "ButtonX_Install"
        Me.ButtonX_Install.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Install.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_SingleFile, Me.ButtonItem_ZipFile, Me.ButtonItem_Directory})
        '
        'ButtonItem_SingleFile
        '
        resources.ApplyResources(Me.ButtonItem_SingleFile, "ButtonItem_SingleFile")
        Me.ButtonItem_SingleFile.GlobalItem = False
        Me.ButtonItem_SingleFile.Name = "ButtonItem_SingleFile"
        '
        'ButtonItem_ZipFile
        '
        resources.ApplyResources(Me.ButtonItem_ZipFile, "ButtonItem_ZipFile")
        Me.ButtonItem_ZipFile.GlobalItem = False
        Me.ButtonItem_ZipFile.Name = "ButtonItem_ZipFile"
        '
        'ButtonItem_Directory
        '
        resources.ApplyResources(Me.ButtonItem_Directory, "ButtonItem_Directory")
        Me.ButtonItem_Directory.GlobalItem = False
        Me.ButtonItem_Directory.Name = "ButtonItem_Directory"
        '
        'ButtonX_Close
        '
        resources.ApplyResources(Me.ButtonX_Close, "ButtonX_Close")
        Me.ButtonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX_Close.Name = "ButtonX_Close"
        Me.ButtonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ListViewEx_Plugins
        '
        resources.ApplyResources(Me.ListViewEx_Plugins, "ListViewEx_Plugins")
        Me.ListViewEx_Plugins.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx_Plugins.Border.Class = "ListViewBorder"
        Me.ListViewEx_Plugins.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx_Plugins.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewEx_Plugins.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx_Plugins.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx_Plugins.HideSelection = False
        Me.ListViewEx_Plugins.Name = "ListViewEx_Plugins"
        Me.ListViewEx_Plugins.UseCompatibleStateImageBehavior = False
        Me.ListViewEx_Plugins.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'PluginInstallerForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX_Close
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PluginInstallerForm"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListViewEx_Plugins As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ButtonX_Close As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Remove As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Install As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ButtonItem_SingleFile As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ZipFile As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Directory As DevComponents.DotNetBar.ButtonItem
End Class
