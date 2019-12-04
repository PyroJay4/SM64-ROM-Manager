<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonX_Upload = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_WebDavUploadPwd = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_ProxPwd = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_WebDavUploadUri = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_ProxUsr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.TextBoxX_WebDavUploadUsr = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX_Version = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 508)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(200, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(494, 508)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonX_Upload)
        Me.Panel2.Controls.Add(Me.LabelX5)
        Me.Panel2.Controls.Add(Me.LabelX2)
        Me.Panel2.Controls.Add(Me.TextBoxX_WebDavUploadPwd)
        Me.Panel2.Controls.Add(Me.TextBoxX_ProxPwd)
        Me.Panel2.Controls.Add(Me.LabelX3)
        Me.Panel2.Controls.Add(Me.TextBoxX_WebDavUploadUri)
        Me.Panel2.Controls.Add(Me.LabelX4)
        Me.Panel2.Controls.Add(Me.TextBoxX_WebDavUploadUsr)
        Me.Panel2.Controls.Add(Me.LabelX6)
        Me.Panel2.Controls.Add(Me.TextBoxX_Version)
        Me.Panel2.Controls.Add(Me.LabelX1)
        Me.Panel2.Controls.Add(Me.TextBoxX_ProxUsr)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 508)
        Me.Panel2.TabIndex = 1
        '
        'ButtonX_Upload
        '
        Me.ButtonX_Upload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Upload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_Upload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Upload.Location = New System.Drawing.Point(3, 465)
        Me.ButtonX_Upload.Name = "ButtonX_Upload"
        Me.ButtonX_Upload.Size = New System.Drawing.Size(194, 40)
        Me.ButtonX_Upload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Upload.TabIndex = 2
        Me.ButtonX_Upload.Text = "Upload"
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(3, 113)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(194, 23)
        Me.LabelX5.TabIndex = 1
        Me.LabelX5.Text = "WebDav Password:"
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 223)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(194, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Proxy Password:"
        '
        'TextBoxX_WebDavUploadPwd
        '
        Me.TextBoxX_WebDavUploadPwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_WebDavUploadPwd.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_WebDavUploadPwd.Border.Class = "TextBoxBorder"
        Me.TextBoxX_WebDavUploadPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_WebDavUploadPwd.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_WebDavUploadPwd.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_WebDavUploadPwd.Location = New System.Drawing.Point(3, 142)
        Me.TextBoxX_WebDavUploadPwd.Name = "TextBoxX_WebDavUploadPwd"
        Me.TextBoxX_WebDavUploadPwd.PreventEnterBeep = True
        Me.TextBoxX_WebDavUploadPwd.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxX_WebDavUploadPwd.TabIndex = 0
        Me.TextBoxX_WebDavUploadPwd.UseSystemPasswordChar = True
        '
        'TextBoxX_ProxPwd
        '
        Me.TextBoxX_ProxPwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_ProxPwd.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ProxPwd.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ProxPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ProxPwd.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ProxPwd.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ProxPwd.Location = New System.Drawing.Point(3, 252)
        Me.TextBoxX_ProxPwd.Name = "TextBoxX_ProxPwd"
        Me.TextBoxX_ProxPwd.PreventEnterBeep = True
        Me.TextBoxX_ProxPwd.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxX_ProxPwd.TabIndex = 0
        Me.TextBoxX_ProxPwd.UseSystemPasswordChar = True
        '
        'LabelX3
        '
        Me.LabelX3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(194, 23)
        Me.LabelX3.TabIndex = 1
        Me.LabelX3.Text = "WebDav Directory Address:"
        '
        'TextBoxX_WebDavUploadUri
        '
        Me.TextBoxX_WebDavUploadUri.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_WebDavUploadUri.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_WebDavUploadUri.Border.Class = "TextBoxBorder"
        Me.TextBoxX_WebDavUploadUri.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_WebDavUploadUri.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_WebDavUploadUri.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_WebDavUploadUri.Location = New System.Drawing.Point(3, 32)
        Me.TextBoxX_WebDavUploadUri.Name = "TextBoxX_WebDavUploadUri"
        Me.TextBoxX_WebDavUploadUri.PreventEnterBeep = True
        Me.TextBoxX_WebDavUploadUri.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxX_WebDavUploadUri.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 168)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(194, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Proxy Username:"
        '
        'TextBoxX_ProxUsr
        '
        Me.TextBoxX_ProxUsr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_ProxUsr.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ProxUsr.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ProxUsr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ProxUsr.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ProxUsr.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ProxUsr.Location = New System.Drawing.Point(3, 197)
        Me.TextBoxX_ProxUsr.Name = "TextBoxX_ProxUsr"
        Me.TextBoxX_ProxUsr.PreventEnterBeep = True
        Me.TextBoxX_ProxUsr.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxX_ProxUsr.TabIndex = 0
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(123, Byte), Integer)))
        '
        'TextBoxX_WebDavUploadUsr
        '
        Me.TextBoxX_WebDavUploadUsr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_WebDavUploadUsr.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_WebDavUploadUsr.Border.Class = "TextBoxBorder"
        Me.TextBoxX_WebDavUploadUsr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_WebDavUploadUsr.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_WebDavUploadUsr.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_WebDavUploadUsr.Location = New System.Drawing.Point(3, 87)
        Me.TextBoxX_WebDavUploadUsr.Name = "TextBoxX_WebDavUploadUsr"
        Me.TextBoxX_WebDavUploadUsr.PreventEnterBeep = True
        Me.TextBoxX_WebDavUploadUsr.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxX_WebDavUploadUsr.TabIndex = 0
        '
        'LabelX4
        '
        Me.LabelX4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(3, 58)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(194, 23)
        Me.LabelX4.TabIndex = 1
        Me.LabelX4.Text = "WebDav Username:"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(562, 3)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(129, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 2
        Me.ButtonX1.Text = "Paste from Clipboard"
        '
        'TextBoxX_Version
        '
        Me.TextBoxX_Version.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_Version.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Version.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Version.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Version.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Version.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Version.Location = New System.Drawing.Point(3, 307)
        Me.TextBoxX_Version.Name = "TextBoxX_Version"
        Me.TextBoxX_Version.PreventEnterBeep = True
        Me.TextBoxX_Version.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxX_Version.TabIndex = 0
        Me.TextBoxX_Version.WatermarkText = "e.g. 1.2.0.0"
        '
        'LabelX6
        '
        Me.LabelX6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(3, 278)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(194, 23)
        Me.LabelX6.TabIndex = 1
        Me.LabelX6.Text = "Version:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 508)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SM64RM Progress Updater"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ButtonX_Upload As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_ProxUsr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_ProxPwd As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_WebDavUploadPwd As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_WebDavUploadUri As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_WebDavUploadUsr As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBoxX_Version As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class
