Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Friend Module BaseFeatures

    <DllImport("user32")>
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As UInt32, ByVal wParam As UInt32, ByVal lParam As UInt32) As UInt32
    End Function

    Private Const BCM_FIRST As Integer = &H1600 'Normal button
    Private Const BCM_SETSHIELD As Integer = (BCM_FIRST + &HC) 'Elevated button

    Public Sub AddShieldToButton(ByVal b As Button)
        b.FlatStyle = FlatStyle.System
        SendMessage(b.Handle, BCM_SETSHIELD, 0, &HFFFFFFFFUI)
    End Sub

    ' Return a bitmap containing the UAC shield.
    Private shield_bm As Bitmap = Nothing
    Public Function GetUacShieldImage() As Bitmap
        If shield_bm IsNot Nothing Then
            Return shield_bm
        End If

        Const WID As Integer = 50
        Const HGT As Integer = 50
        Const MARGIN As Integer = 4

        ' Make the button. For some reason, it must
        ' have text or the UAC shield won't appear.
        Dim btn As New Button()
        btn.Text = " "
        btn.Size = New Size(WID, HGT)
        AddShieldToButton(btn)

        ' Draw the button onto a bitmap.
        Dim bm As New Bitmap(WID, HGT)
        btn.Refresh()
        btn.DrawToBitmap(bm, New Rectangle(0, 0, WID, HGT))

        ' Find the part containing the shield.
        Dim min_x As Integer = WID, max_x As Integer = 0, min_y As Integer = HGT, max_y As Integer = 0

        ' Fill on the left.
        Dim y As Integer = MARGIN
        Do While y < HGT - MARGIN
            ' Get the leftmost pixel's color.
            Dim target_color As Color = bm.GetPixel(MARGIN, y)

            ' Fill in with this color as long as we see the target.
            Dim x As Integer = MARGIN
            Do While x < WID - MARGIN
                ' See if this pixel is part of the shield.
                If bm.GetPixel(x, y).Equals(target_color) Then
                    ' It's not part of the shield.
                    ' Clear the pixel.
                    bm.SetPixel(x, y, Color.Transparent)
                Else
                    ' It's part of the shield.
                    If min_y > y Then
                        min_y = y
                    End If
                    If min_x > x Then
                        min_x = x
                    End If
                    If max_y < y Then
                        max_y = y
                    End If
                    If max_x < x Then
                        max_x = x
                    End If
                End If
                x += 1
            Loop
            y += 1
        Loop

        ' Clip out the shield part.
        Dim shield_wid As Integer = max_x - min_x + 1
        Dim shield_hgt As Integer = max_y - min_y + 1
        shield_bm = New Bitmap(shield_wid, shield_hgt)
        Dim shield_gr As Graphics = Graphics.FromImage(shield_bm)
        shield_gr.DrawImage(bm, 0, 0, New Rectangle(min_x, min_y, shield_wid, shield_hgt), GraphicsUnit.Pixel)

        ' Return the shield.
        Return shield_bm
    End Function


End Module
