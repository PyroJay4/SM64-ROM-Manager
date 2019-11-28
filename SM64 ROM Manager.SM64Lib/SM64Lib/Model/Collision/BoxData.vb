Namespace Model.Collision

    Public Class BoxData

        Public Property Type As BoxDataType = BoxDataType.Water
        Public Property X1 As Int16
        Public Property X2 As Int16
        Public Property Z1 As Int16
        Public Property Z2 As Int16
        Public Property Y As Int16
        Public Property Index As Int16

        Public Sub New()
            X1 = 8192
            X2 = -8192
            Z1 = 8192
            Z2 = -8192
            Y = 0
            Index = 0
        End Sub

        Public Sub New(SpecialBox As Levels.SpecialBox, Y As Int16)
            X1 = SpecialBox.X1
            X2 = SpecialBox.X2
            Z1 = SpecialBox.Z1
            Z2 = SpecialBox.Z2
            Me.Y = Y
        End Sub

        Public Sub New(WaterBox As BoxData)
            X1 = WaterBox.X1
            X2 = WaterBox.X2
            Z1 = WaterBox.Z1
            Z2 = WaterBox.Z2
            Y = WaterBox.Y
        End Sub
    End Class

End Namespace