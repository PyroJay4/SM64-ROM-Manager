Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports SM64Lib.Text

Public Class Form_SM64TextConverter

    Private Property RaisedClick As Boolean = False
    Private activeTextBox As TextBoxX = Nothing

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        StyleManager.UpdateAmbientColors(Me)

    End Sub

    Private Sub Form_SM64TextConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxEx_Mode.SelectedIndex = 0
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX_Convert.Click
        Select Case ComboBoxEx_Mode.SelectedIndex
            Case 0
                TextBoxX_Output.Text = ""

                If Not String.IsNullOrEmpty(TextBoxX_Input.Text) Then
                    Try
                        For Each b As Byte In M64TextEncoding.M64Text.GetBytes(TextBoxX_Input.Text.Trim)
                            If Not String.IsNullOrEmpty(TextBoxX_Output.Text) Then
                                TextBoxX_Output.Text &= " "
                            End If

                            Dim hexstring As String = Hex(b)

                            If hexstring.Count = 1 Then
                                hexstring = "0" & hexstring
                            End If

                            TextBoxX_Output.Text &= hexstring
                        Next
                    Catch ex As Exception
                        If Not RaisedClick Then
                            MessageBoxEx.Show("Eror error at converting from Text to Hexadecimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Try
                End If
            Case 1
                Dim byteList As New List(Of Byte)

                For Each b As String In TextBoxX_Input.Text.Trim.Split(" ")
                    If b = "" Then Continue For
                    Try
                        byteList.Add(CInt("&H" & b))
                    Catch ex As Exception
                    End Try
                Next

                Try
                    TextBoxX_Output.Text = M64TextEncoding.M64Text.GetString(byteList.ToArray)
                Catch ex As Exception
                    If Not RaisedClick Then
                        MessageBoxEx.Show("Eror error at converting from Hexadecimal to Text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Try
        End Select

        RaisedClick = False
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_Input.TextChanged
        ButtonX_Convert.PerformClick()
        RaisedClick = True
    End Sub

    Private Sub ButtonX_CopyOutput_Click(sender As Object, e As EventArgs) Handles ButtonX_CopyOutput.Click
        Clipboard.SetText(TextBoxX_Output.Text)
    End Sub

    Private Sub TextBoxX_Input_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBoxX_Input.MouseDown, TextBoxX_Output.MouseDown
        activeTextBox = sender
        activeTextBox.ShortcutsEnabled = False

        Dim isEnabled As Boolean = Not activeTextBox.ReadOnly
        ButtonItem_Remove.Enabled = isEnabled
        ButtonItem_cut.Enabled = isEnabled
        ButtonItem_Paste.Enabled = isEnabled

        If e.Button = MouseButtons.Right Then ButtonItem1.Popup(Cursor.Position)
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem_Copy.Click
        activeTextBox.Copy()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem_cut.Click
        activeTextBox.Cut()
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem_Paste.Click
        activeTextBox.Paste(Clipboard.GetText)
    End Sub

    Private Sub ButtonItem5_Click_1(sender As Object, e As EventArgs) Handles ButtonItem_Remove.Click
        Dim str As String = activeTextBox.SelectedText
        If Not String.IsNullOrEmpty(str) Then
            activeTextBox.Text = activeTextBox.Text.Replace(str, String.Empty)
        End If
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem_SelectAll.Click
        activeTextBox.SelectAll()
    End Sub
End Class