Imports DevComponents.DotNetBar
Imports SM64Lib.Levels
Imports SM64Lib.Model

Public Class Form_AddSpecialItem

    Public Modelfile As String = ""
    Public TextureName As String = ""
    Public WType As WindowType = Nothing
    Public SpecialData As New SpecialBox
    Public WaterData As Collision.BoxData = Nothing

    Public Enum WindowType
        SpecialBox = 0
        ScrollingTexture
    End Enum

    Public Sub New(Type As WindowType)
        InitializeComponent()
        UpdateAmbientColors()

        WType = Type
        CheckBoxX_Water.Checked = True
    End Sub
    Public Sub New(ByRef SpecialBox As SpecialBox, ByRef WaterBox As Collision.BoxData)
        InitializeComponent()
        StyleManager.UpdateAmbientColors(Me)

        WType = WindowType.SpecialBox

        SpecialData = SpecialBox
        WaterData = WaterBox

        With SpecialData
            IntegerInput_Alpha.Value = Math.Round(.Alpha / 255 * 100)
            IntegerInput_Scale.Value = .Scale
            LabelX_Height.Text = String.Format("Height: {0}", WaterData.Y)
            LabelX_Pos1.Text = String.Format("Edge 1: {0}, {1}", .X1, .Z1)
            LabelX_Pos2.Text = String.Format("Edge 2: {0}, {1}", .X2, .Z2)
        End With

        Select Case SpecialBox.WaterType
            Case WaterType.Default : ComboBox_WaterType.SelectedIndex = If(SpecialBox.InvisibleWater, 1, 0)
            Case WaterType.JRBWater : ComboBox_WaterType.SelectedIndex = 2
            Case WaterType.GreenWater : ComboBox_WaterType.SelectedIndex = 3
            Case WaterType.LavaWater : ComboBox_WaterType.SelectedIndex = 4
        End Select

        Select Case SpecialBox.Type
            Case SpecialBoxType.Water : CheckBoxX_Water.Checked = True
            Case SpecialBoxType.ToxicHaze : CheckBoxX_ToxicHaze.Checked = True
            Case SpecialBoxType.Mist : CheckBoxX_Mist.Checked = True
        End Select
    End Sub

    Private Sub Form_AddSpecialItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox_WaterType.SelectedIndex = 0
        IntegerInput_Scale.Value = 16
    End Sub

    Private Sub CheckBoxX_SpecialBoxType_CheckedChanged(sender As Object, e As Controls.CheckBoxXChangeEventArgs) Handles CheckBoxX_Water.CheckedChangedEx, CheckBoxX_Mist.CheckedChangedEx, CheckBoxX_ToxicHaze.CheckedChangedEx
        If Not sender.Checked Then Return

        Select Case True
            Case CheckBoxX_Water.Checked : SpecialData.Type = SpecialBoxType.Water
            Case CheckBoxX_Mist.Checked : SpecialData.Type = SpecialBoxType.Mist
            Case CheckBoxX_ToxicHaze.Checked : SpecialData.Type = SpecialBoxType.ToxicHaze
        End Select

        GroupBox_Box.Visible = (CheckBoxX_Water.Checked OrElse CheckBoxX_Mist.Checked OrElse CheckBoxX_ToxicHaze.Checked)
    End Sub

    Private Sub Button_SelectTexture_Click(sender As Object, e As EventArgs)
        'Dim frm As New Form_CollisionEditor(Modelfile, Form_CollisionEditor_WindowType.SelectTexture, STData.MaterialName)
        'If frm.ShowDialog <> DialogResult.OK Then Return

        'STData.MaterialName = CType(frm.ListBoxAdv_Textures.Items(frm.cItemIndex), MtlTextureItem).Text
        'LabelX_Texture.Text = "Texture: " & STData.MaterialName
    End Sub

    Private Sub Button_SetUpPos1_Click(sender As Object, e As EventArgs) Handles Button_SetUpPos1.Click, Button_SetUpPos2.Click
        Dim xpos As Integer = 0
        Dim zpos As Integer = 0
        Dim pointnumber As Integer = 1

        Select Case sender.GetHashCode
            Case Button_SetUpPos1.GetHashCode
                xpos = SpecialData.X1 : zpos = SpecialData.Z1
                pointnumber = 1
            Case Button_SetUpPos2.GetHashCode
                xpos = SpecialData.X2 : zpos = SpecialData.Z2
                pointnumber = 2
        End Select

        Dim frm As New Form_SetUpPoint("Box Edge " & pointnumber, True, False, True, xpos, 0, zpos)
        If frm.ShowDialog <> DialogResult.OK Then Return

        Select Case sender.GetHashCode
            Case Button_SetUpPos1.GetHashCode
                SpecialData.X1 = frm.IntegerInput_X.Value
                WaterData.X1 = frm.IntegerInput_X.Value
                SpecialData.Z1 = frm.IntegerInput_Z.Value
                WaterData.Z1 = frm.IntegerInput_Z.Value
                LabelX_Pos1.Text = String.Format("Edge 1: {0}, {1}", SpecialData.X1, SpecialData.Z1)
            Case Button_SetUpPos2.GetHashCode
                SpecialData.X2 = frm.IntegerInput_X.Value
                WaterData.X2 = frm.IntegerInput_X.Value
                SpecialData.Z2 = frm.IntegerInput_Z.Value
                WaterData.Z2 = frm.IntegerInput_Z.Value
                LabelX_Pos2.Text = String.Format("Edge 2: {0}, {1}", SpecialData.X2, SpecialData.Z2)
        End Select
    End Sub

    Private Sub Button_SetUpHeight_Click(sender As Object, e As EventArgs) Handles Button_SetUpHeight.Click
        Dim frm As New Form_SetUpPoint("Box Height", False, True, False, 0, WaterData.Y, 0)
        If frm.ShowDialog <> DialogResult.OK Then Return
        WaterData.Y = frm.IntegerInput_Y.Value
        LabelX_Height.Text = String.Format("Height: {0}", WaterData.Y)
    End Sub

    Private Sub IntegerInput_Scale_ValueChanged(sender As Object, e As EventArgs) Handles IntegerInput_Scale.ValueChanged
        SpecialData.Scale = IntegerInput_Scale.Value
    End Sub

    Private Sub ComboBox_WaterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_WaterType.SelectedIndexChanged
        If SpecialData Is Nothing Then Return
        SpecialData.InvisibleWater = (ComboBox_WaterType.SelectedIndex = 1)
        Select Case ComboBox_WaterType.SelectedIndex
            Case 0, 1 : SpecialData.WaterType = WaterType.Default
            Case 2 : SpecialData.WaterType = WaterType.JRBWater : SpecialData.InvisibleWater = False
            Case 3 : SpecialData.WaterType = WaterType.GreenWater : SpecialData.InvisibleWater = False
            Case 4 : SpecialData.WaterType = WaterType.LavaWater : SpecialData.InvisibleWater = False
        End Select
    End Sub

    Private Sub CheckBoxX_Water_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX_Water.CheckedChanged
        ComboBox_WaterType.Enabled = CheckBoxX_Water.Checked
        LabelX1.Enabled = CheckBoxX_Water.Checked
    End Sub

    Private Sub IntegerInput1_ValueChanged(sender As Object, e As EventArgs) Handles IntegerInput_Alpha.ValueChanged
        SpecialData.Alpha = Math.Round(255 / 100 * IntegerInput_Alpha.Value)
    End Sub
End Class
