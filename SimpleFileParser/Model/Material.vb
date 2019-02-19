Imports System.Numerics

Public Class Material
    Implements IComparable

    Public Property Image As Image = Nothing
    Public Property Color As Color? = Nothing
    Public Property Opacity As Single? = Nothing
    Public Property Wrap As New Vector2(10497, 10497)
    Public Property Scale As New Vector2(1.0F, 1.0F)
    Public Property Tag As Object = Nothing

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj IsNot Nothing Then
            If obj Is Me Then
                Return 0
            Else
                Return -1
            End If
        Else
            Return 1
        End If
    End Function

End Class
