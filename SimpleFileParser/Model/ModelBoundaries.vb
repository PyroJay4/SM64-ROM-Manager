Imports System.Numerics

Public Class ModelBoundaries
    Public ReadOnly Upper As Vector3
    Public ReadOnly Lower As Vector3

    Public Sub New(upper As Vector3, lower As Vector3)
        Me.Upper = upper
        Me.Lower = lower
    End Sub
End Class
