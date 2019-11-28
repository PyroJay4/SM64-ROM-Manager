Namespace Model.Collision

    Public Class TriangleList
        Inherits List(Of Triangle)

        Public Overloads Sub Add(item As Triangle)
            MyBase.Add(item)
            item.ParentList = Me
        End Sub

        Public Overloads Sub Insert(index As Integer, item As Triangle)
            MyBase.Insert(index, item)
            item.ParentList = Me
        End Sub

        Public Overloads Sub AddRange(collection As IEnumerable(Of Triangle))
            For Each v As Triangle In collection
                v.ParentList = Me
            Next
            MyBase.AddRange(collection)
        End Sub
    End Class

End Namespace