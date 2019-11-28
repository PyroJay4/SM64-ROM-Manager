Namespace Model.Collision

    Public Class Triangle
        Public Property CollisionType As Byte = 0
        Public ColParams() As Byte = {0, 0}
        Public Vertices(2) As Vertex
        Public Property ParentList As TriangleList = Nothing
        Public ReadOnly Property Index As Integer
            Get
                Return ParentList.IndexOf(Me)
            End Get
        End Property
    End Class

End Namespace