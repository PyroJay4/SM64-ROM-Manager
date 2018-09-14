Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.Editors

Namespace Global.System.Drawing

    Public Module Extensions

        <Extension> Public Function GetAspectRatio(bmp As Bitmap) As Single
            Return bmp.Height / bmp.Width
        End Function

    End Module

End Namespace

Namespace Global.System.Windows.Forms

    Public Module Extensions

        'Private ReadOnly ambientColorControlTypes() As Type = {GetType(Label), GetType(LabelX), GetType(TextBox), GetType(TextBoxX), GetType(NumericUpDown), GetType(DoubleInput), GetType(IntegerInput), GetType(ComboBox), GetType(ComboBoxEx), GetType(ListBoxAdv), GetType(ListView), GetType(ListViewEx), GetType(SwitchButton)}

        <Extension> Public Sub UpdateAmbientColors(c As Control)
            'If ambientColorControlTypes.Contains(c.GetType) Then
            StyleManager.UpdateAmbientColors(c)
            'End If
            For Each cc As Control In c.Controls
                UpdateAmbientColors(cc)
            Next
        End Sub

    End Module

End Namespace
