Public Class Form_ProgressDisplay

    Public Property ProgressText
        Get
            Return LabelX1.Text
        End Get
        Set(value)
            LabelX1.Text = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(Status As String, Parent As Form)
        InitializeComponent()
        ProgressText = Status
        SetLocation(Parent)
        Show()
    End Sub

    Public Sub SetLocation(Parent As Form)
        Me.Location = New Point((Parent.Size.Width - Me.Size.Width) / 2 + Parent.Location.X,
                                (Parent.Size.Height - Me.Size.Height) / 2 + Parent.Location.Y)
    End Sub

    Private Sub Form_ProgressDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CircularProgress1.IsRunning = True
    End Sub

    Private Sub Form_ProgressDisplay_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CircularProgress1.IsRunning = False
    End Sub
End Class
