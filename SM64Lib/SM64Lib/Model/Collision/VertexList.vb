Namespace Global.SM64Lib.Model.Collision

    Public Class VertexList
        Inherits List(Of Vertex)

        Public Overloads Sub Add(item As Vertex)
            MyBase.Add(item)
            item.ParentList = Me
        End Sub

        Public Overloads Sub Insert(index As Integer, item As Vertex)
            MyBase.Insert(index, item)
            item.ParentList = Me
        End Sub

        Public Overloads Sub AddRange(collection As IEnumerable(Of Vertex))
            For Each v As Vertex In collection
                v.ParentList = Me
            Next
            MyBase.AddRange(collection)
        End Sub
    End Class

End Namespace