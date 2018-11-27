Imports System.IO
Imports System.Runtime.CompilerServices

Friend Module Extensions

    <Extension>
    Public Function GetPropertyValue(base As Object, propertyName As String) As Object
        Return base?.GetType.GetProperty(propertyName, Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Static)?.GetValue(base)
    End Function

    <Extension>
    Public Function IsTheSameAs(base As Bitmap, image As Bitmap) As Boolean
        If base.Size <> image.Size Then Return False

        For y As Integer = 0 To base.Height - 1
            For x As Integer = 0 To base.Width - 1
                Dim p1 As Color = base.GetPixel(x, y)
                Dim p2 As Color = image.GetPixel(x, y)
                If p1 <> p2 Then Return False
            Next
        Next

        Return True
    End Function

End Module
