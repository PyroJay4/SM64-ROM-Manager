<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CoinsSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_CoinsSettings))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX_SaveSettings = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButtonX_Remove3DCoins = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_ImportKaze3DCoins = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_EnableNewRedCoinsCounter = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_NewRedCoinsCounterTextForCoins = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_NewRedCoinsCounterTextForCoin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SwitchButton_CoinsRestoreHealth = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_ShowCoinsHudOnHubs = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_Enable100Coins = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_CoinsForRedCoinsStar = New DevComponents.Editors.IntegerInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_CoinsForBowserRedCoinsStar = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_CoinsFor100CoinsStar = New DevComponents.Editors.IntegerInput()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.IntegerInput_CoinsForRedCoinsStar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_CoinsForBowserRedCoinsStar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_CoinsFor100CoinsStar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ButtonX_SaveSettings)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'ButtonX_SaveSettings
        '
        Me.ButtonX_SaveSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_SaveSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_SaveSettings.FocusCuesEnabled = False
        Me.ButtonX_SaveSettings.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_save_16px
        resources.ApplyResources(Me.ButtonX_SaveSettings, "ButtonX_SaveSettings")
        Me.ButtonX_SaveSettings.Name = "ButtonX_SaveSettings"
        Me.ButtonX_SaveSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButtonX_Remove3DCoins)
        Me.GroupBox4.Controls.Add(Me.ButtonX_ImportKaze3DCoins)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'ButtonX_Remove3DCoins
        '
        Me.ButtonX_Remove3DCoins.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Remove3DCoins.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Remove3DCoins.FocusCuesEnabled = False
        Me.ButtonX_Remove3DCoins.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        resources.ApplyResources(Me.ButtonX_Remove3DCoins, "ButtonX_Remove3DCoins")
        Me.ButtonX_Remove3DCoins.Name = "ButtonX_Remove3DCoins"
        Me.ButtonX_Remove3DCoins.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_ImportKaze3DCoins
        '
        Me.ButtonX_ImportKaze3DCoins.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_ImportKaze3DCoins.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ImportKaze3DCoins.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_ImportKaze3DCoins, "ButtonX_ImportKaze3DCoins")
        Me.ButtonX_ImportKaze3DCoins.Name = "ButtonX_ImportKaze3DCoins"
        Me.ButtonX_ImportKaze3DCoins.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LabelX10)
        Me.GroupBox3.Controls.Add(Me.SwitchButton_EnableNewRedCoinsCounter)
        Me.GroupBox3.Controls.Add(Me.LabelX6)
        Me.GroupBox3.Controls.Add(Me.TextBoxX_NewRedCoinsCounterTextForCoins)
        Me.GroupBox3.Controls.Add(Me.TextBoxX_NewRedCoinsCounterTextForCoin)
        Me.GroupBox3.Controls.Add(Me.LabelX5)
        Me.GroupBox3.Controls.Add(Me.LabelX1)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX10, "LabelX10")
        Me.LabelX10.Name = "LabelX10"
        '
        'SwitchButton_EnableNewRedCoinsCounter
        '
        '
        '
        '
        Me.SwitchButton_EnableNewRedCoinsCounter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_EnableNewRedCoinsCounter.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_EnableNewRedCoinsCounter, "SwitchButton_EnableNewRedCoinsCounter")
        Me.SwitchButton_EnableNewRedCoinsCounter.Name = "SwitchButton_EnableNewRedCoinsCounter"
        Me.SwitchButton_EnableNewRedCoinsCounter.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_EnableNewRedCoinsCounter.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_EnableNewRedCoinsCounter.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_EnableNewRedCoinsCounter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_EnableNewRedCoinsCounter.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_EnableNewRedCoinsCounter.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_EnableNewRedCoinsCounter.SwitchWidth = 15
        Me.SwitchButton_EnableNewRedCoinsCounter.Value = True
        Me.SwitchButton_EnableNewRedCoinsCounter.ValueObject = "Y"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX6, "LabelX6")
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'TextBoxX_NewRedCoinsCounterTextForCoins
        '
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.Border.Class = "TextBoxBorder"
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_NewRedCoinsCounterTextForCoins, "TextBoxX_NewRedCoinsCounterTextForCoins")
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.Name = "TextBoxX_NewRedCoinsCounterTextForCoins"
        Me.TextBoxX_NewRedCoinsCounterTextForCoins.PreventEnterBeep = True
        '
        'TextBoxX_NewRedCoinsCounterTextForCoin
        '
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.Border.Class = "TextBoxBorder"
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_NewRedCoinsCounterTextForCoin, "TextBoxX_NewRedCoinsCounterTextForCoin")
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.Name = "TextBoxX_NewRedCoinsCounterTextForCoin"
        Me.TextBoxX_NewRedCoinsCounterTextForCoin.PreventEnterBeep = True
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.Name = "LabelX5"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.Name = "LabelX1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SwitchButton_CoinsRestoreHealth)
        Me.GroupBox1.Controls.Add(Me.LabelX9)
        Me.GroupBox1.Controls.Add(Me.SwitchButton_ShowCoinsHudOnHubs)
        Me.GroupBox1.Controls.Add(Me.LabelX8)
        Me.GroupBox1.Controls.Add(Me.SwitchButton_Enable100Coins)
        Me.GroupBox1.Controls.Add(Me.LabelX7)
        Me.GroupBox1.Controls.Add(Me.LabelX2)
        Me.GroupBox1.Controls.Add(Me.IntegerInput_CoinsForRedCoinsStar)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.IntegerInput_CoinsForBowserRedCoinsStar)
        Me.GroupBox1.Controls.Add(Me.LabelX3)
        Me.GroupBox1.Controls.Add(Me.IntegerInput_CoinsFor100CoinsStar)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'SwitchButton_CoinsRestoreHealth
        '
        '
        '
        '
        Me.SwitchButton_CoinsRestoreHealth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_CoinsRestoreHealth.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_CoinsRestoreHealth, "SwitchButton_CoinsRestoreHealth")
        Me.SwitchButton_CoinsRestoreHealth.Name = "SwitchButton_CoinsRestoreHealth"
        Me.SwitchButton_CoinsRestoreHealth.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_CoinsRestoreHealth.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_CoinsRestoreHealth.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_CoinsRestoreHealth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_CoinsRestoreHealth.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_CoinsRestoreHealth.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_CoinsRestoreHealth.SwitchWidth = 15
        Me.SwitchButton_CoinsRestoreHealth.Value = True
        Me.SwitchButton_CoinsRestoreHealth.ValueObject = "Y"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX9, "LabelX9")
        Me.LabelX9.Name = "LabelX9"
        '
        'SwitchButton_ShowCoinsHudOnHubs
        '
        '
        '
        '
        Me.SwitchButton_ShowCoinsHudOnHubs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_ShowCoinsHudOnHubs.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_ShowCoinsHudOnHubs, "SwitchButton_ShowCoinsHudOnHubs")
        Me.SwitchButton_ShowCoinsHudOnHubs.Name = "SwitchButton_ShowCoinsHudOnHubs"
        Me.SwitchButton_ShowCoinsHudOnHubs.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_ShowCoinsHudOnHubs.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_ShowCoinsHudOnHubs.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_ShowCoinsHudOnHubs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_ShowCoinsHudOnHubs.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_ShowCoinsHudOnHubs.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_ShowCoinsHudOnHubs.SwitchWidth = 15
        Me.SwitchButton_ShowCoinsHudOnHubs.Value = True
        Me.SwitchButton_ShowCoinsHudOnHubs.ValueObject = "Y"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX8, "LabelX8")
        Me.LabelX8.Name = "LabelX8"
        '
        'SwitchButton_Enable100Coins
        '
        '
        '
        '
        Me.SwitchButton_Enable100Coins.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_Enable100Coins.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_Enable100Coins, "SwitchButton_Enable100Coins")
        Me.SwitchButton_Enable100Coins.Name = "SwitchButton_Enable100Coins"
        Me.SwitchButton_Enable100Coins.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_Enable100Coins.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_Enable100Coins.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_Enable100Coins.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_Enable100Coins.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_Enable100Coins.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_Enable100Coins.SwitchWidth = 15
        Me.SwitchButton_Enable100Coins.Value = True
        Me.SwitchButton_Enable100Coins.ValueObject = "Y"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX7, "LabelX7")
        Me.LabelX7.Name = "LabelX7"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        Me.LabelX2.Name = "LabelX2"
        '
        'IntegerInput_CoinsForRedCoinsStar
        '
        '
        '
        '
        Me.IntegerInput_CoinsForRedCoinsStar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_CoinsForRedCoinsStar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_CoinsForRedCoinsStar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_CoinsForRedCoinsStar, "IntegerInput_CoinsForRedCoinsStar")
        Me.IntegerInput_CoinsForRedCoinsStar.Name = "IntegerInput_CoinsForRedCoinsStar"
        Me.IntegerInput_CoinsForRedCoinsStar.ShowUpDown = True
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        Me.LabelX4.Name = "LabelX4"
        '
        'IntegerInput_CoinsForBowserRedCoinsStar
        '
        '
        '
        '
        Me.IntegerInput_CoinsForBowserRedCoinsStar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_CoinsForBowserRedCoinsStar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_CoinsForBowserRedCoinsStar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_CoinsForBowserRedCoinsStar, "IntegerInput_CoinsForBowserRedCoinsStar")
        Me.IntegerInput_CoinsForBowserRedCoinsStar.Name = "IntegerInput_CoinsForBowserRedCoinsStar"
        Me.IntegerInput_CoinsForBowserRedCoinsStar.ShowUpDown = True
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        Me.LabelX3.Name = "LabelX3"
        '
        'IntegerInput_CoinsFor100CoinsStar
        '
        '
        '
        '
        Me.IntegerInput_CoinsFor100CoinsStar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_CoinsFor100CoinsStar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_CoinsFor100CoinsStar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_CoinsFor100CoinsStar, "IntegerInput_CoinsFor100CoinsStar")
        Me.IntegerInput_CoinsFor100CoinsStar.Name = "IntegerInput_CoinsFor100CoinsStar"
        Me.IntegerInput_CoinsFor100CoinsStar.ShowUpDown = True
        '
        'Form_CoinsSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_CoinsSettings"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.IntegerInput_CoinsForRedCoinsStar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_CoinsForBowserRedCoinsStar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_CoinsFor100CoinsStar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents IntegerInput_CoinsFor100CoinsStar As DevComponents.Editors.IntegerInput
    Friend WithEvents IntegerInput_CoinsForBowserRedCoinsStar As DevComponents.Editors.IntegerInput
    Friend WithEvents IntegerInput_CoinsForRedCoinsStar As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_NewRedCoinsCounterTextForCoins As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_NewRedCoinsCounterTextForCoin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButtonX_Remove3DCoins As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_ImportKaze3DCoins As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_Enable100Coins As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton_ShowCoinsHudOnHubs As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_CoinsRestoreHealth As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_EnableNewRedCoinsCounter As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ButtonX_SaveSettings As DevComponents.DotNetBar.ButtonX
End Class
