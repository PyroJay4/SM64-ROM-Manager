﻿Imports System.Globalization
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.Publics
Imports SM64Lib
Imports SM64Lib.Music

Friend Class InputDialog

    Private rommgr As RomManager

    Public Property ReturnValue As Object = Nothing
    Public Property ValueType As InputValueType = InputValueType.Byte

    Public Sub New(valType As InputValueType, rommgr As RomManager, Optional defaultValue As Object = Nothing)
        InitializeComponent()

        ValueType = valType
        Me.rommgr = rommgr

        Select Case valType
            Case InputValueType.Byte, InputValueType.UInt16, InputValueType.UInt32
                ComboBoxEx1.Text = If(defaultValue Is Nothing, "0", TextFromValue(defaultValue))

            Case InputValueType.Single
                ComboBoxEx1.Text = $"0{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}00"

            Case InputValueType.String
                ComboBoxEx1.Text = If(defaultValue Is Nothing, "Text", defaultValue)

            Case InputValueType.Sequence
                If rommgr IsNot Nothing Then
                    Dim id As Byte = 0
                    For Each ms As MusicSequence In rommgr.MusicList
                        ComboBoxEx1.Items.Add($"{id.ToString("X2")} - {ms.Name}")
                        id += 1
                    Next
                    ComboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList
                    ComboBoxEx1.SelectedIndex = 0
                End If

            Case InputValueType.LevelID
                If rommgr IsNot Nothing Then
                    For Each lvi As Levels.LevelInfoDataTabelList.Level In rommgr.LevelInfoData
                        ComboBoxEx1.Items.Add($"{lvi.ID.ToString("X2")} - {lvi.Name}")
                    Next
                    ComboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList
                    ComboBoxEx1.SelectedIndex = 0
                End If

        End Select

        UpdateAmbientColors
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Select Case ValueType
            Case InputValueType.Byte
                Dim val As Byte
                If Byte.TryParse(ValueFromText(ComboBoxEx1.Text.Trim), val) Then
                    ReturnValue = val
                Else
                    ReturnValue = Nothing
                End If

            Case InputValueType.UInt16
                Dim val As UInt16
                If UInt16.TryParse(ValueFromText(ComboBoxEx1.Text.Trim), val) Then
                    ReturnValue = val
                Else
                    ReturnValue = Nothing
                End If

            Case InputValueType.UInt32
                Dim val As UInt32
                If UInt32.TryParse(ValueFromText(ComboBoxEx1.Text.Trim), val) Then
                    ReturnValue = val
                Else
                    ReturnValue = Nothing
                End If

            Case InputValueType.Single
                Dim val As Single
                If Single.TryParse(ComboBoxEx1.Text.Trim, val) Then
                    ReturnValue = Math.Round(val, 2)
                Else
                    ReturnValue = Nothing
                End If

            Case InputValueType.String
                ReturnValue = ComboBoxEx1.Text

            Case InputValueType.Sequence
                ReturnValue = CByte(ComboBoxEx1.SelectedIndex)

            Case InputValueType.LevelID
                ReturnValue = rommgr.LevelInfoData(ComboBoxEx1.SelectedIndex).ID

        End Select

        If ReturnValue IsNot Nothing Then
            DialogResult = DialogResult.OK
        Else
            MessageBoxEx.Show("The value you entered is invalid!", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Enum InputValueType
        [Byte]
        UInt16
        UInt32
        [Single]
        [String]
        Sequence
        LevelID
    End Enum

End Class
