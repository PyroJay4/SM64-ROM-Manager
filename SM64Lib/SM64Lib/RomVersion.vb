Imports Newtonsoft.Json

Public Structure RomVersion

    <JsonProperty("Filename")>
    Private _Filename As String

    Public Property Version As Version
    Public Property DevelopmentStage As Integer
    Public Property DevelopmentBuild As Integer

    <JsonIgnore>
    Friend ReadOnly Property Filename As String
        Get
            Return _FileName
        End Get
    End Property

    Public Shared Operator <>(left As RomVersion, right As RomVersion) As Boolean
        Return left.Version <> right.Version AndAlso left.DevelopmentBuild <> right.DevelopmentBuild AndAlso left.DevelopmentStage <> right.DevelopmentStage
    End Operator

    Public Shared Operator =(left As RomVersion, right As RomVersion) As Boolean
        Return left.Version = right.Version AndAlso left.DevelopmentBuild = right.DevelopmentBuild AndAlso left.DevelopmentStage = right.DevelopmentStage
    End Operator

    Public Shared Operator >(left As RomVersion, right As RomVersion) As Boolean
        Dim flag As Boolean =
                left.Version > right.Version OrElse
                (left.Version = right.Version AndAlso left.DevelopmentStage < right.DevelopmentStage) OrElse
                (left.Version = right.Version AndAlso left.DevelopmentStage = right.DevelopmentStage AndAlso left.DevelopmentBuild > right.DevelopmentBuild)

        Return flag
    End Operator

    Public Shared Operator <(left As RomVersion, right As RomVersion) As Boolean
        Return Not left >= right
    End Operator

    Public Shared Operator >=(left As RomVersion, right As RomVersion) As Boolean
        Return left = right OrElse left > right
    End Operator

    Public Shared Operator <=(left As RomVersion, right As RomVersion) As Boolean
        Return left = right OrElse left < right
    End Operator

End Structure
