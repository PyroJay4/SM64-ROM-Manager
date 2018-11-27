Imports System.IO
Imports HexEdit

Public Class HexEditor

    Private input As Byte()
    Private WithEvents HexEditor As HexEditBox

    Public Sub New(buffer As Byte())
        InitializeComponent()

        HexEditor = New HexEditBox
        HexEditor.InitializeComponent()
        HexEditor.Dock = DockStyle.Fill
        HexEditor.Font = New Font(HexEditor.Font.FontFamily, 12.0!)
        Controls.Add(HexEditor)

        input = buffer
    End Sub

    Private Sub HexEditor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        HexEditor.LoadData(input)
    End Sub

    Public Function GetData() As Byte()
        Return HexEditor.ArrayData
    End Function

End Class
