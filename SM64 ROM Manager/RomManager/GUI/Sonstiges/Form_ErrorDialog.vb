Imports DevComponents.DotNetBar

Public Class Form_ErrorDialog

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        _ExitApplicaiton = True
    End Sub

    Public ReadOnly Property ExitApplicaiton As Boolean = False

    Public Property ErrorText As String
        Get
            Return TextBoxX1.Text
        End Get
        Set(value As String)
            TextBoxX1.Text = value
        End Set
    End Property

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Clipboard.SetText(TextBoxX1.Text)
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors()
    End Sub
End Class