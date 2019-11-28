Imports System.Runtime.CompilerServices

Public Module Int16Extensions

    <Extension>
    Public Function IsInRange(value As Int16, min As Int16, max As Int16) As Boolean
        Return value >= min AndAlso value <= max
    End Function

End Module
