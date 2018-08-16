Imports DevComponents.DotNetBar

Public Class Form_SetUpPoint

    Public Sub New(Title As String, ShowX As Boolean, ShowY As Boolean, ShowZ As Boolean, XValue As Integer, YValue As Integer, ZValue As Integer)
        InitializeComponent()
        StyleManager.UpdateAmbientColors(Me)
        Me.Text = Title

        Dim CurrentYPosition As Integer = 12
        Dim CurrentWith As Integer = 164

        If ShowX Then
            LabelX_X.Visible = True
            LabelX_X.Location = New Point(LabelX_X.Location.X, CurrentYPosition)
            IntegerInput_X.Visible = True
            IntegerInput_X.Location = New Point(IntegerInput_X.Location.X, CurrentYPosition)
            IntegerInput_X.Value = XValue
            CurrentYPosition += 26
        Else : CurrentWith -= 26
        End If

        If ShowY Then
            LabelX_Y.Visible = True
            LabelX_Y.Location = New Point(LabelX_Y.Location.X, CurrentYPosition)
            IntegerInput_Y.Visible = True
            IntegerInput_Y.Location = New Point(IntegerInput_Y.Location.X, CurrentYPosition)
            IntegerInput_Y.Value = YValue
            CurrentYPosition += 26
        Else : CurrentWith -= 26
        End If

        If ShowX Then
            LabelX_Z.Visible = True
            LabelX_Z.Location = New Point(LabelX_Z.Location.X, CurrentYPosition)
            IntegerInput_Z.Visible = True
            IntegerInput_Z.Location = New Point(IntegerInput_Z.Location.X, CurrentYPosition)
            IntegerInput_Z.Value = ZValue
            CurrentYPosition += 26
        Else : CurrentWith -= 26
        End If

        CurrentYPosition += 3

        Button_Okay.Location = New Point(Button_Okay.Location.X, CurrentYPosition)
        Button_Cancle.Location = New Point(Button_Cancle.Location.X, CurrentYPosition)

        Me.Size = New Size(Me.Size.Width, CurrentWith)
    End Sub
End Class