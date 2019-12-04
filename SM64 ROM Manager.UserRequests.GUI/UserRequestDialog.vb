Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Layout
Imports SM64_ROM_Manager.UserRequests.GUI.My.Resources

Public Class UserRequestDialog

    'F i e l d

    Private ReadOnly request As UserRequest
    Private circularProgress As CircularProgress = Nothing
    Private button_Send As ButtonX = Nothing

    'C o n s t r u c t o r

    Public Sub New(requestLayout As UserRequestLayout)
        InitializeComponent()
        request = New UserRequest(requestLayout)
        Text = request.RequestName
        CreateLayout()
        StyleManager.UpdateAmbientColors(Me)
    End Sub

    'I n i t i a l a t i o n

    Private Sub CreateLayout()
        Dim rootGroup As LayoutGroup = LayoutControl1.RootGroup

        LayoutControl1.SuspendLayout()

        For Each prop As UserRequestProperty In request.Properties
            'Titel
            AddLabel(rootGroup, prop.Name, True)

            'Description
            If Not String.IsNullOrEmpty(prop.Description) Then
                AddLabel(rootGroup, prop.Description, False)
            End If

            'Value Editor
            Select Case prop.Type
                Case UserRequestPropertyType.Text
                    AddValueText(rootGroup, prop, False)
                Case UserRequestPropertyType.LongText
                    AddValueText(rootGroup, prop, True)
                Case UserRequestPropertyType.Files
                    AddValueFiles(rootGroup, prop)
            End Select

            'Splitter
            AddSplitter(rootGroup, 100, 10)
        Next

        'Send Button
        AddSendButton(rootGroup)

        LayoutControl1.ResumeLayout()
    End Sub

    Private Sub AddControlToGroup(prop As UserRequestProperty, group As LayoutGroup, control As Control, Optional withType As eLayoutSizeType = eLayoutSizeType.Percent, Optional width As Integer = 100)
        control.Margin = New Windows.Forms.Padding(0, 0, 0, 0)

        Dim item As New LayoutControlItem With {
            .TextVisible = True,
            .WidthType = withType,
            .Width = width,
            .HeightType = eLayoutSizeType.Absolute,
            .Height = control.Height + 8,
            .Control = control
        }

        If TypeOf control Is TextBoxX Then
            item.MinSize = New Size(120, 0)
        End If

        LayoutControl1.Controls.Add(control)
        group.Items.Add(item)

        If TypeOf control Is TextBoxX Then
            'item.MinSize = New Size(120, 0)
            If Not prop.AllowEmptyState Then
                Dim validor As New Validator.RequiredFieldValidator("Requied field!") With {.HighlightColor = Validator.eHighlightColor.Red}
                SuperValidator1.SetValidator1(control, validor)
            End If
        End If
    End Sub

    Private Sub AddLabel(group As LayoutGroup, text As String, bold As Boolean)
        Dim control As New LabelX With {
            .Text = text,
            .FontBold = bold,
            .Size = New Size(LayoutControl1.Width - 6, 16)
        }
        control.Size = TextRenderer.MeasureText(text, New Font(control.Font, FontStyle.Bold), control.Size)
        AddControlToGroup(Nothing, group, control)
    End Sub

    Private Sub AddValueText(group As LayoutGroup, prop As UserRequestProperty, multiline As Boolean)
        Dim control As New TextBoxX With {
            .Text = prop.Value,
            .Tag = prop,
            .Multiline = multiline,
            .Size = New Size(75, If(multiline, 75, 20))
        }
        control.Border.Class = "TextBoxBorder"

        AddHandler control.TextChanged,
            Sub(sender As TextBoxX, e As EventArgs)
                CType(sender.Tag, UserRequestProperty).Value = sender.Text.Trim
            End Sub

        AddControlToGroup(prop, group, control)
    End Sub

    Private Sub AddValueFiles(group As LayoutGroup, prop As UserRequestProperty)
        Dim control As New UserRequestPropertyFilesEditor(prop) With {
            .Tag = prop,
            .BackColor = Color.Transparent,
            .Size = New Size(120, 120)
        }

        AddHandler control.TextChanged,
            Sub(sender As TextBoxX, e As EventArgs)
                CType(sender.Tag, UserRequestProperty).Value = sender.Text.Trim
            End Sub

        AddControlToGroup(prop, group, control)
    End Sub

    Private Sub AddSendButton(group As LayoutGroup)
        button_Send = New ButtonX With {
            .Text = "Send",
            .Size = New Size(90, 23),
            .Image = icons8_send_16px,
            .ColorTable = eButtonColor.OrangeWithBackground,
            .Style = eDotNetBarStyle.StyleManagerControlled
        }

        circularProgress = New CircularProgress With {
            .ProgressBarType = eCircularProgressType.Donut,
            .ProgressColor = ForeColor,
            .Size = New Size(23, 23)
        }

        AddHandler button_Send.Click, AddressOf Button_Send_Clicked

        AddSplitter(group, 99, button_Send.Height + 8)
        AddControlToGroup(Nothing, group, circularProgress, eLayoutSizeType.Absolute, circularProgress.Width + 8)
        AddControlToGroup(Nothing, group, button_Send, eLayoutSizeType.Absolute, button_Send.Width + 8)
    End Sub

    Private Sub AddSplitter(group As LayoutGroup, percent As Integer, height As Integer)
        Dim item As New LayoutSpacerItem With {
            .WidthType = eLayoutSizeType.Percent,
            .Width = percent,
            .HeightType = eLayoutSizeType.Absolute,
            .Height = height
        }
        group.Items.Add(item)
    End Sub

    'F e a t u r e s

    Private Async Function SendRequest() As Task(Of Boolean)
        Dim mgr As New UserRequestManager
        Return Await mgr.UploadRequest(request)
    End Function

    'G u i

    Private Async Sub Button_Send_Clicked(sender As Object, e As EventArgs)
        Dim success As Boolean = False

        If SuperValidator1.Validate() Then
            button_Send.Enabled = False
            circularProgress.Start()

#If Not DEBUG Then
        Try
#End If
            success = Await SendRequest()
#If Not DEBUG Then
        Catch ex As Exception
            MessageBoxEx.Show(UserRequestGuiLangRes.MsgBox_ErrorSendingRequest, UserRequestGuiLangRes.MsgBox_ErrorSendingRequest_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
#End If
            circularProgress.Stop()
            button_Send.Enabled = True
#If Not DEBUG Then
        End Try
#End If

            If success Then
                MessageBoxEx.Show(UserRequestGuiLangRes.MsgBox_SendingRequestSuccess, UserRequestGuiLangRes.MsgBox_SendingRequestSuccess_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            Else
                MessageBoxEx.Show(UserRequestGuiLangRes.MsgBox_ErrorSendingRequest, UserRequestGuiLangRes.MsgBox_ErrorSendingRequest_Titel, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

End Class
