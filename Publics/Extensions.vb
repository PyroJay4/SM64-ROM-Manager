Imports System.Runtime.CompilerServices
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

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

Namespace Global.DevComponents.DotNetBar

    Public Module CircularProgressExtensions

        ''' <summary>
        ''' Makes the CircularProgress visible and set IsRunning to True.
        ''' </summary>
        ''' <param name="prog"></param>
        <Extension>
        Public Sub Start(prog As CircularProgress)
            prog.Visible = True
            prog.IsRunning = True
        End Sub

        ''' <summary>
        ''' Makes the CircularProgress invisible and set IsRunning to False.
        ''' </summary>
        ''' <param name="prog"></param>
        <Extension>
        Public Sub [Stop](prog As CircularProgress)
            prog.IsRunning = False
            prog.Visible = False
        End Sub

    End Module

End Namespace
