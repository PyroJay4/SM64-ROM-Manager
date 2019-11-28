Namespace Model.Collision

    Public Class Vertex
        Public Property X As Int16 = 0
        Public Property Y As Int16 = 0
        Public Property Z As Int16 = 0
        Public Property ParentList As VertexList = Nothing
        Public ReadOnly Property Index As Integer
            Get
                Return ParentList.IndexOf(Me)
            End Get
        End Property
    End Class

End Namespace