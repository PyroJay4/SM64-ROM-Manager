Imports System.Windows.Forms
Imports DevComponents.Editors

Public Class FilesFilterDialog

    Private _Filter As String = ""

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors
    End Sub

    Public Property Filter As String
        Get
            Return _Filter
        End Get
        Set(value As String)
            If _Filter <> value Then
                _Filter = value
                ParseFilter()
            End If
        End Set
    End Property

    Public Property FilterIndex As Integer
        Get
            Return ComboBoxEx1.SelectedIndex + 1
        End Get
        Set(value As Integer)
            ComboBoxEx1.SelectedIndex = value - 1
        End Set
    End Property

    Public ReadOnly Property FileExtension As String
        Get
            Dim ci As ComboItem = ComboBoxEx1.SelectedItem
            Return ci.Tag
        End Get
    End Property

    Private Sub ParseFilter()
        Dim splitted As String() = _Filter.Split("|")

        ComboBoxEx1.Items.Clear()

        For i As Integer = 0 To splitted.Length - 1 Step 2
            Dim ci As New ComboItem With {
                .Text = splitted(i),
                .Tag = splitted(i + 1)
            }
            ComboBoxEx1.Items.Add(ci)
        Next

        If ComboBoxEx1.Items.Count > 0 Then
            FilterIndex = 1
        End If
    End Sub

End Class