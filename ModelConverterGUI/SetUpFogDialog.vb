Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports SM64Lib
Imports SM64Lib.Model

Public Class SetUpFogDialog

    Public Property FogData As New Fog

    Public Sub New(Fog As Fog)
        InitializeComponent()
        Me.UpdateAmbientColors

        FogData = Fog

        ComboBox_FogTyp.SelectedIndex = Fog.Type
        NumericUpDown_FogRed.Value = Fog.Color.R
        NumericUpDown_FogGreen.Value = Fog.Color.G
        NumericUpDown_FogBlue.Value = Fog.Color.B
    End Sub

    Private Sub ComboBox_FogTyp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_FogTyp.SelectedIndexChanged
        FogData.Type = ComboBox_FogTyp.SelectedIndex
    End Sub

    Private Sub NumericUpDown_FogRed_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_FogRed.ValueChanged, NumericUpDown_FogGreen.ValueChanged, NumericUpDown_FogBlue.ValueChanged
        FogData.Color = Drawing.Color.FromArgb(NumericUpDown_FogRed.Value, NumericUpDown_FogGreen.Value, NumericUpDown_FogBlue.Value)
    End Sub

End Class