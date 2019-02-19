Imports System.Drawing
Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Public Module Controls

    <Obsolete>
    Public Function GetNewOfficeForm() As Form
        Dim frm As New OfficeForm

        frm.EnableGlass = False

        Return frm
    End Function

    <Obsolete>
    Public Function GetNewOfficeForm(basePanel As Control) As Form
        Dim frm As Form = Controls.GetNewOfficeForm

        basePanel.Dock = DockStyle.Fill
        basePanel.BackColor = Color.Transparent

        frm.Controls.Add(basePanel)

        Return frm
    End Function

    <Obsolete>
    Public Function GetNewOfficeButton(Optional withBorder As Boolean = True, Optional image As Image = Nothing, Optional imageFixedSize As Size? = Nothing) As Control
        Dim btn As New ButtonX

        btn.ColorTable = If(withBorder, eButtonColor.OrangeWithBackground, eButtonColor.Orange)
        btn.Image = image
        If imageFixedSize IsNot Nothing Then btn.ImageFixedSize = imageFixedSize

        Return btn
    End Function

    <Obsolete>
    Public Function GetNewOfficeLabel() As Control
        Return New LabelX
    End Function

End Module
