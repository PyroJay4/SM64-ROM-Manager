Imports System.Reflection
Imports SM64Lib.Levels
Imports SM64Lib.Levels.Script
Imports SM64Lib.Model
Imports SM64Lib.Model.Collision
Imports SM64Lib.Model.Fast3D

Namespace LevelEditor

    Public Class AreaEditorHistoryFunctions

        Private Shared _Methodes As Dictionary(Of String, MethodInfo) = Nothing
        Public Shared ReadOnly Property Methodes As Dictionary(Of String, MethodInfo)
            Get
                If _Methodes Is Nothing Then
                    _Methodes = New Dictionary(Of String, MethodInfo)

                    For Each mi As MethodInfo In GetType(AreaEditorHistoryFunctions).GetMethods
                        _Methodes.Add(mi.Name, mi)
                    Next
                End If

                Return _Methodes
            End Get
        End Property

        Public Shared Sub AddObjects(area As LevelArea, objList As List(Of Managed3DObject), objs As IEnumerable(Of Managed3DObject), lvic As ListView.ListViewItemCollection, lvis As IEnumerable(Of ListViewItem))
            For i As Integer = 0 To objs.Count - 1
                area.Objects.Add(objs(i).Command)
                objList.Add(objs(i))
                lvic.Add(lvis(i))
            Next
        End Sub
        Public Shared Sub RemoveObjects(area As LevelArea, objList As List(Of Managed3DObject), objs As IEnumerable(Of Managed3DObject), lvic As ListView.ListViewItemCollection, lvis As IEnumerable(Of ListViewItem))
            For i As Integer = 0 To objs.Count - 1
                area.Objects.Remove(objs(i).Command)
                objList.Remove(objs(i))
                lvic.Remove(lvis(i))
            Next
        End Sub
        Public Shared Sub InsertObjects(area As LevelArea, objList As List(Of Managed3DObject), lvic As ListView.ListViewItemCollection, removedObjs As Dictionary(Of Integer, Managed3DObject), removedlvis As Dictionary(Of Integer, ListViewItem), removedCmds As Dictionary(Of Integer, LevelscriptCommand))
            For Each kvp As KeyValuePair(Of Integer, Managed3DObject) In removedObjs.OrderBy(Function(n) n.Key)
                objList.Insert(kvp.Key, kvp.Value)
            Next
            For Each kvp As KeyValuePair(Of Integer, LevelscriptCommand) In removedCmds.OrderBy(Function(n) n.Key)
                area.Objects.Insert(kvp.Key, kvp.Value)
            Next
            For Each kvp As KeyValuePair(Of Integer, ListViewItem) In removedlvis.OrderBy(Function(n) n.Key)
                lvic.Insert(kvp.Key, kvp.Value)
            Next
        End Sub
        Public Shared Sub RemoveAtObjects(area As LevelArea, objList As List(Of Managed3DObject), lvic As ListView.ListViewItemCollection, removedObjs As Dictionary(Of Integer, Managed3DObject), removedlvis As Dictionary(Of Integer, ListViewItem), removedCmds As Dictionary(Of Integer, LevelscriptCommand))
            For Each kvp As KeyValuePair(Of Integer, ListViewItem) In removedlvis.OrderByDescending(Function(n) n.Key)
                lvic.RemoveAt(kvp.Key)
            Next
            For Each kvp As KeyValuePair(Of Integer, Managed3DObject) In removedObjs.OrderByDescending(Function(n) n.Key)
                objList.RemoveAt(kvp.Key)
            Next
            For Each kvp As KeyValuePair(Of Integer, LevelscriptCommand) In removedCmds.OrderByDescending(Function(n) n.Key)
                area.Objects.RemoveAt(kvp.Key)
            Next
        End Sub

        Public Shared Sub AddWarps(area As LevelArea, objList As List(Of IManagedLevelscriptCommand), objs As IEnumerable(Of IManagedLevelscriptCommand), lvic As ListView.ListViewItemCollection, lvis As IEnumerable(Of ListViewItem), lviGroups As Dictionary(Of ListViewItem, ListViewGroup))
            For i As Integer = 0 To objs.Count - 1
                area.Objects.Add(objs(i).Command)
                objList.Add(objs(i))

                Dim lvi As ListViewItem = lvis(i)
                lvi.Group = lviGroups(lvi)
                lvic.Add(lvi)
            Next
        End Sub
        Public Shared Sub RemoveWarps(area As LevelArea, objList As List(Of IManagedLevelscriptCommand), objs As IEnumerable(Of IManagedLevelscriptCommand), lvic As ListView.ListViewItemCollection, lvis As IEnumerable(Of ListViewItem), lviGroups As Dictionary(Of ListViewItem, ListViewGroup))
            For i As Integer = 0 To objs.Count - 1
                area.Objects.Remove(objs(i).Command)
                objList.Remove(objs(i))
                lvic.Remove(lvis(i))
            Next
        End Sub

        Public Shared Sub InsertWarps(area As LevelArea, objList As List(Of IManagedLevelscriptCommand), lvic As ListView.ListViewItemCollection, removedObjs As Dictionary(Of Integer, IManagedLevelscriptCommand), removedlvis As Dictionary(Of Integer, ListViewItem), removedCmds As Dictionary(Of Integer, LevelscriptCommand), lviGroups As Dictionary(Of ListViewItem, ListViewGroup))
            For Each kvp As KeyValuePair(Of Integer, IManagedLevelscriptCommand) In removedObjs.OrderBy(Function(n) n.Key)
                objList.Insert(kvp.Key, kvp.Value)
            Next
            For Each kvp As KeyValuePair(Of Integer, LevelscriptCommand) In removedCmds.OrderBy(Function(n) n.Key)
                area.Warps.Insert(kvp.Key, kvp.Value)
            Next
            For Each kvp As KeyValuePair(Of Integer, ListViewItem) In removedlvis.OrderBy(Function(n) n.Key)
                kvp.Value.Group = lviGroups(kvp.Value)
                lvic.Insert(kvp.Key, kvp.Value)
            Next
        End Sub
        Public Shared Sub RemoveAtWarps(area As LevelArea, objList As List(Of IManagedLevelscriptCommand), lvic As ListView.ListViewItemCollection, removedObjs As Dictionary(Of Integer, IManagedLevelscriptCommand), removedlvis As Dictionary(Of Integer, ListViewItem), removedCmds As Dictionary(Of Integer, LevelscriptCommand), lviGroups As Dictionary(Of ListViewItem, ListViewGroup))
            For Each kvp As KeyValuePair(Of Integer, ListViewItem) In removedlvis.OrderByDescending(Function(n) n.Key)
                lvic.RemoveAt(kvp.Key)
            Next
            For Each kvp As KeyValuePair(Of Integer, IManagedLevelscriptCommand) In removedObjs.OrderByDescending(Function(n) n.Key)
                objList.RemoveAt(kvp.Key)
            Next
            For Each kvp As KeyValuePair(Of Integer, LevelscriptCommand) In removedCmds.OrderByDescending(Function(n) n.Key)
                area.Warps.RemoveAt(kvp.Key)
            Next
        End Sub

        Public Shared Sub RevertObjects(area As LevelArea, objList As List(Of Managed3DObject), indicies As IEnumerable(Of Integer), objs As IEnumerable(Of Managed3DObject))
            For i As Integer = 0 To objs.Count - 1
                Dim index As Integer = indicies(i)
                Dim newobj As Managed3DObject = objs(i)
                objList(index) = newobj
                area.Objects(index) = newobj.Command
            Next
        End Sub

        Public Shared Sub RemoveFromCollision(base As Form_AreaEditor, vlist As VertexList, vs As Vertex(), tlist As TriangleList, ts As Triangle())
            For Each t As Triangle In ts
                tlist.Remove(t)
            Next
            For Each v As Vertex In vs
                vlist.Remove(v)
            Next
            base.maps.ReloadCollisionInOpenGL()
        End Sub

        Public Shared Sub AddToCollision(base As Form_AreaEditor, vlist As VertexList, vs As Vertex(), tlist As TriangleList, ts As Triangle())
            For Each v As Vertex In vs
                vlist.Add(v)
            Next
            For Each t As Triangle In ts
                tlist.Add(t)
            Next
            base.maps.ReloadCollisionInOpenGL()
        End Sub

    End Class

End Namespace
