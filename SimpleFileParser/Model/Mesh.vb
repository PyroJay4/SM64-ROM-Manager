Imports System.Numerics

Public Class Mesh

    Public ReadOnly Property Vertices As New List(Of Vertex)
    Public ReadOnly Property Normals As New List(Of Normal)
    Public ReadOnly Property UVs As New List(Of UV)
    Public ReadOnly Property VertexColors As New List(Of VertexColor)
    Public ReadOnly Property Faces As New List(Of Face)

    Friend Function GetCenterModelAvg() As Vector3
        Dim avgX As Integer = 0
        Dim avgY As Integer = 0
        Dim avgZ As Integer = 0

        For Each v As Vertex In Vertices
            avgX += v.X
            avgY += v.Y
            avgZ += v.Z
        Next

        Return New Vector3(avgX, avgY, avgZ)
    End Function

    Public Sub CenterModel()
        Dim avg As Vector3 = GetCenterModelAvg()

        avg /= New Vector3(Vertices.Count)

        CenterModel(avg)
    End Sub

    Public Sub CenterModel(avg As Vector3)
        For Each v As Vertex In Vertices
            v.X -= avg.X
            v.Y -= avg.Y
            v.Z -= avg.Z
        Next
    End Sub

End Class