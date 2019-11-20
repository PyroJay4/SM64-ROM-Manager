<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolSelectionWindow
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolSelectionWindow))
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX_OpenUpdatePackageEditor = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_OpenUpdateInfoManager = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(42, Byte), Integer)))
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX_OpenUpdatePackageEditor, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX_OpenUpdateInfoManager, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(208, 143)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonX_OpenUpdatePackageEditor
        '
        Me.ButtonX_OpenUpdatePackageEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_OpenUpdatePackageEditor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_OpenUpdatePackageEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonX_OpenUpdatePackageEditor.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_open_box_32px
        Me.ButtonX_OpenUpdatePackageEditor.Location = New System.Drawing.Point(3, 74)
        Me.ButtonX_OpenUpdatePackageEditor.Name = "ButtonX_OpenUpdatePackageEditor"
        Me.ButtonX_OpenUpdatePackageEditor.Size = New System.Drawing.Size(202, 66)
        Me.ButtonX_OpenUpdatePackageEditor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_OpenUpdatePackageEditor.TabIndex = 1
        Me.ButtonX_OpenUpdatePackageEditor.Text = "Paket erstellen"
        Me.ButtonX_OpenUpdatePackageEditor.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'ButtonX_OpenUpdateInfoManager
        '
        Me.ButtonX_OpenUpdateInfoManager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_OpenUpdateInfoManager.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_OpenUpdateInfoManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonX_OpenUpdateInfoManager.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_administrative_tools_32px
        Me.ButtonX_OpenUpdateInfoManager.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX_OpenUpdateInfoManager.Name = "ButtonX_OpenUpdateInfoManager"
        Me.ButtonX_OpenUpdateInfoManager.Size = New System.Drawing.Size(202, 65)
        Me.ButtonX_OpenUpdateInfoManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_OpenUpdateInfoManager.TabIndex = 0
        Me.ButtonX_OpenUpdateInfoManager.Text = "Aktuallisierungsinfo erstellen"
        Me.ButtonX_OpenUpdateInfoManager.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'ToolSelectionWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(208, 143)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ToolSelectionWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Administration"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonX_OpenUpdatePackageEditor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_OpenUpdateInfoManager As DevComponents.DotNetBar.ButtonX
End Class
