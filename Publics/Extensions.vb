Imports System.Runtime.CompilerServices
Imports DevComponents.DotNetBar

Namespace Global.System.Drawing

    Public Module Extensions

        <Extension> Public Function GetAspectRatio(bmp As Bitmap) As Single
            Return bmp.Height / bmp.Width
        End Function

    End Module

End Namespace

Namespace Global.System.Windows.Forms

    Public Module Extensions

        Private ReadOnly ambientColorControlTypesBlackList() As Type = {GetType(Panel)}

        <Extension> Public Sub UpdateAmbientColors(c As Control)
            If Not ambientColorControlTypesBlackList.Contains(c.GetType) Then
                StyleManager.UpdateAmbientColors(c)
            End If
            For Each cc As Control In c.Controls
                UpdateAmbientColors(cc)
            Next
        End Sub

    End Module

End Namespace
