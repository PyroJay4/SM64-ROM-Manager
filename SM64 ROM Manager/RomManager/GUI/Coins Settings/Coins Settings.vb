Imports System.IO
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.NPCs

Public Class Form_CoinsSettings

    Private coinMgr As CoinsManager

    Public Sub New(rommgr As RomManager)
        InitializeComponent()
        UpdateAmbientColors
        coinMgr = New CoinsManager(rommgr)
    End Sub

    Private Sub LoadSettingsToGUI()
        IntegerInput_CoinsForRedCoinsStar.Value = coinMgr.CoinsForRedCoinsStar
        IntegerInput_CoinsForBowserRedCoinsStar.Value = coinMgr.CoinsForBowserRedCoinsStar
        IntegerInput_CoinsFor100CoinsStar.Value = coinMgr.CoinsFor100CoinsStar
        SwitchButton_Enable100Coins.Value = coinMgr.Enable100CoinsStar
        SwitchButton_ShowCoinsHudOnHubs.Value = coinMgr.EnableCoinCounterInHubs
        SwitchButton_CoinsRestoreHealth.Value = coinMgr.CoinsRestoreHealth
        SwitchButton_EnableNewRedCoinsCounter.Value = coinMgr.EnableNewRedCoinsCounter
        TextBoxX_NewRedCoinsCounterTextForCoin.Text = coinMgr.NewRedCoinsCounterTextForCoin
        TextBoxX_NewRedCoinsCounterTextForCoins.Text = coinMgr.NewRedCoinsCounterTextForCoins
    End Sub

    Private Sub ApplySettingsToCoinManager()
        coinMgr.CoinsForRedCoinsStar = IntegerInput_CoinsForRedCoinsStar.Value
        coinMgr.CoinsForBowserRedCoinsStar = IntegerInput_CoinsForBowserRedCoinsStar.Value
        coinMgr.CoinsFor100CoinsStar = IntegerInput_CoinsFor100CoinsStar.Value
        coinMgr.Enable100CoinsStar = SwitchButton_Enable100Coins.Value
        coinMgr.EnableCoinCounterInHubs = SwitchButton_ShowCoinsHudOnHubs.Value
        coinMgr.CoinsRestoreHealth = SwitchButton_CoinsRestoreHealth.Value
        coinMgr.EnableNewRedCoinsCounter = SwitchButton_EnableNewRedCoinsCounter.Value
        coinMgr.NewRedCoinsCounterTextForCoin = TextBoxX_NewRedCoinsCounterTextForCoin.Text
        coinMgr.NewRedCoinsCounterTextForCoins = TextBoxX_NewRedCoinsCounterTextForCoins.Text
    End Sub

    Private Sub Edit3DCoins()
        Throw New NotImplementedException
    End Sub

    Private Sub Coins_Settings_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        coinMgr.LoadCoinSettings()
        LoadSettingsToGUI()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX_SaveSettings.Click
        ApplySettingsToCoinManager()
        coinMgr.SaveCoinSettings()
    End Sub

    Private Sub ButtonX_ImportKaze3DCoins_Click(sender As Object, e As EventArgs) Handles ButtonX_ImportKaze3DCoins.Click
        coinMgr.ImportKazesCoins()
        Publics.ShowToadnotifiaction(Panel1, LangResCoinsManager.Notify_3DCoinsPatchesSuccess, DevComponents.DotNetBar.eToastGlowColor.Green)
    End Sub

    Private Sub ButtonX_Edit3DCoins_Click(sender As Object, e As EventArgs) Handles ButtonX_Edit3DCoins.Click
        Edit3DCoins()
    End Sub

    Private Sub ButtonX_Remove3DCoins_Click(sender As Object, e As EventArgs) Handles ButtonX_Remove3DCoins.Click
        If MessageBoxEx.Show(LangResCoinsManager.MsgBox_Experimental3DCoinsRemove, LangResCoinsManager.MsgBox_Experimental3DCoinsRemove_Titel, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            coinMgr.Remove3DCoins()
            Publics.ShowToadnotifiaction(Panel1, LangResCoinsManager.Notify_3DCoinsRemovedSuccess, DevComponents.DotNetBar.eToastGlowColor.Green)
        End If
    End Sub

End Class
