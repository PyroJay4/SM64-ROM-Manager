Public Class ListViewItemSpecial
    Inherits ListViewItem

    Private _Box As SM64Lib.Levels.SpecialBox
    Public ReadOnly Property Box As SM64Lib.Levels.SpecialBox
        Get
            Return _Box
        End Get
    End Property

    Public Sub New(BoxData As SM64Lib.Levels.SpecialBox, WaterData As SM64Lib.Model.Collision.BoxData, ItemNumber As Integer)
        For i As Integer = 0 To 7
            Me.SubItems.Add(New ListViewSubItem)
        Next
        AktuallisiereDaten(BoxData, WaterData, ItemNumber)
    End Sub

    Public Sub AktuallisiereDaten(SpecialData As SM64Lib.Levels.SpecialBox, BoxData As SM64Lib.Model.Collision.BoxData, Optional ItemNumber As Integer = 0)
        _Box = SpecialData

        If ItemNumber > 0 Then Me.Text = ItemNumber
        SubItems(1).Text = SpecialData.Type.ToString
        SubItems(2).Text = BoxData.X1
        SubItems(3).Text = BoxData.Z1
        SubItems(4).Text = BoxData.X2
        SubItems(5).Text = BoxData.Z2
        SubItems(6).Text = BoxData.Y
        SubItems(7).Text = If(_Box.Type = SM64Lib.Levels.SpecialBoxType.Water, If(_Box.InvisibleWater, "Invisible", _Box.WaterType.ToString), "-")
    End Sub
End Class
