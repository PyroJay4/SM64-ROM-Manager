Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib

Friend Module Extensions

    <Extension>
    Public Function GetValue(base As Object, name As String) As Object
        Dim type As Type = base.GetType

        Dim fi As FieldInfo = type.GetField(name, BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic)
        If fi IsNot Nothing Then
            Return fi.GetValue(base)
        End If

        Dim pi As PropertyInfo = type.GetProperty(name, BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic)
        If pi IsNot Nothing Then
            Return pi.GetValue(base)
        End If

        Return Nothing
    End Function

    <Extension>
    Public Function GetValue(Of T)(base As Object, name As String) As T
        Return GetValue(base, name)
    End Function

    <Extension>
    Public Sub SetValue(base As Object, name As String, value As Object)
        Dim type As Type = base.GetType

        Dim fi As FieldInfo = type.GetField(name, BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic)
        If fi IsNot Nothing Then
            fi.SetValue(base, value)
        End If

        Dim pi As PropertyInfo = type.GetProperty(name, BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic)
        If pi IsNot Nothing Then
            pi.SetValue(base, value)
        End If
    End Sub

End Module
