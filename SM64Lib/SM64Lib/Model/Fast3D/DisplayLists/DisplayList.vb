Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports Pilz.S3DFileParser
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Fast3D.DisplayLists.Script
Imports SM64Lib.Model.Fast3D.DisplayLists.Script.Commands
Imports SM64Lib.Script

Namespace Model.Fast3D.DisplayLists

    Public Class DisplayList

        Public ReadOnly Property Script As New Script.DisplayListScript
        Public Property GeoPointer As Geopointer = Nothing
        'Public Property Data As Stream = Nothing

        Public Sub New()
        End Sub

        Public Sub New(gp As Geopointer)
            Me._GeoPointer = gp
        End Sub

        Public Sub TryFromStream(gp As Geopointer, rommgr As RomManager, AreaID As Byte?)
            Try
                FromStream(gp, rommgr, AreaID)
            Catch ex As Exception
            End Try
        End Sub
        Public Function TryFromStreamAsync(gp As Geopointer, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() TryFromStream(gp, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub FromStream(gp As Geopointer, rommgr As RomManager, AreaID As Byte?)
            _GeoPointer = gp
            Script.FromStream(rommgr, gp.SegPointer, AreaID)
        End Sub
        Public Function FromStreamAsync(gp As Geopointer, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() FromStream(gp, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub TryToObject3D(obj As Object3D, rommgr As RomManager, AreaID As Byte?)
            Try
                ToObject3D(obj, rommgr, AreaID)
            Catch ex As Exception
            End Try
        End Sub
        Public Function TryToObject3DAsync(obj As Object3D, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() TryToObject3D(obj, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub ToObject3D(obj As Object3D, rommgr As RomManager, AreaID As Byte?)
            Conversion.Fast3DParsing.Fast3DParser.Convert(obj, Me, rommgr, AreaID)
        End Sub
        Public Function ToObject3DAsync(obj As Object3D, rommgr As RomManager, AreaID As Byte?) As Task
            Dim t As New Task(Sub() ToObject3D(obj, rommgr, AreaID))
            t.Start()
            Return t
        End Function

        Public Sub Close()
            Script.Close()
        End Sub

    End Class

End Namespace
