Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports Pilz.S3DFileParser
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Fast3D.DisplayLists.Script
Imports SM64Lib.Model.Fast3D.DisplayLists.Script.Commands
Imports SM64Lib.Script

Namespace Global.SM64Lib.Model.Fast3D.DisplayLists

    Public Class DisplayListCollection
        Inherits List(Of DisplayList)

        Public Function ToObject3D(rommgr As RomManager, AreaID As Byte?) As Object3D
            Dim obj As New Object3D

            For Each dl As DisplayList In Me
                dl.ToObject3D(obj, rommgr, AreaID)
            Next

            Return obj
        End Function

        Public Overloads Sub Clear()
            Me.Close()
            MyBase.Clear()
        End Sub

        Public Sub Close()
            For Each dl In Me
                dl.Close()
            Next
        End Sub
    End Class

End Namespace
