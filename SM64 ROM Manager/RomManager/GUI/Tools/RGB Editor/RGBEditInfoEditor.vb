Public Class RGBEditInfoEditor

    Public Property RGBEditInfo As RGBEditor.RGBEditInfo = Nothing

    Public Sub New()
        InitializeComponent()

        UpdateAmbientColors
        Panel1.BackColor = Color.Transparent

        SwitchButton_LightMult.Enabled = False
        SwitchButton_DarkMult.Enabled = False
        TextBoxX_Light.Enabled = False
        TextBoxX_Dark.Enabled = False
        TextBoxX_Alpha.Enabled = False
    End Sub

    Private Sub LoadRgbInfo()
        Dim e As RGBEditor.RGBEditInfo = RGBEditInfo

        TextBoxX_Name.Text = e.Name

        Dim enableLight As Boolean = e.LightAddress IsNot Nothing
        SwitchButton_Light.Value = enableLight
        If enableLight Then
            SwitchButton_LightMult.Value = e.DoubleLightRGB
            TextBoxX_Light.Text = TextFromValue(e.LightAddress)
        End If

        Dim enableDark As Boolean = e.DarkAddress IsNot Nothing
        SwitchButton_Dark.Value = enableDark
        If enableDark Then
            SwitchButton_DarkMult.Value = e.DoubleDarkRGB
            TextBoxX_Dark.Text = TextFromValue(e.DarkAddress)
        End If

        Dim enableAlpha As Boolean = e.AlphaAddress IsNot Nothing
        SwitchButton_Alpha.Value = enableAlpha
        If enableAlpha Then
            TextBoxX_Alpha.Text = TextFromValue(e.AlphaAddress)
        End If
    End Sub

    Private Sub SaveRgbInfo()
        Dim e As RGBEditor.RGBEditInfo = RGBEditInfo

        e.Name = TextBoxX_Name.Text

        If SwitchButton_Light.Value Then
            e.LightAddress = ValueFromText(TextBoxX_Light.Text)
            e.DoubleLightRGB = SwitchButton_LightMult.Value
        Else
            e.LightAddress = Nothing
        End If

        If SwitchButton_Dark.Value Then
            e.DarkAddress = ValueFromText(TextBoxX_Dark.Text)
            e.DoubleDarkRGB = SwitchButton_DarkMult.Value
        Else
            e.DarkAddress = Nothing
        End If

        If SwitchButton_Alpha.Value Then
            e.AlphaAddress = ValueFromText(TextBoxX_Alpha.Text)
        Else
            e.AlphaAddress = Nothing
        End If
    End Sub

    Private Sub SwitchButton_Light_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_Light.ValueChanged
        Dim checked As Boolean = SwitchButton_Light.Value
        TextBoxX_Light.Enabled = checked
        SwitchButton_LightMult.Enabled = checked
    End Sub

    Private Sub SwitchButton_Dark_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_Dark.ValueChanged
        Dim checked As Boolean = SwitchButton_Dark.Value
        TextBoxX_Dark.Enabled = checked
        SwitchButton_DarkMult.Enabled = checked
    End Sub

    Private Sub SwitchButton_Alpha_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_Alpha.ValueChanged
        Dim checked As Boolean = SwitchButton_Alpha.Value
        TextBoxX_Alpha.Enabled = checked
    End Sub

    Private Sub RGBEditInfoEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RGBEditInfo Is Nothing Then
            RGBEditInfo = New RGBEditor.RGBEditInfo With {.Name = "Unknown"}
        End If
        LoadRgbInfo()
    End Sub

    Private Sub RGBEditInfoEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveRgbInfo()
    End Sub

End Class
