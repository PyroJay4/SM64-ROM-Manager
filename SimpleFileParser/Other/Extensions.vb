Imports System.IO
Imports System.Runtime.CompilerServices

Friend Module Extensions

    <Extension>
    Public Function GetPropertyValue(base As Object, propertyName As String) As Object
        Return base?.GetType.GetProperty(propertyName, Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Static)?.GetValue(base)
    End Function

End Module
