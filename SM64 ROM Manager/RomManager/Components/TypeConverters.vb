Imports System.ComponentModel
Imports System.Globalization
Imports System.Numerics
Imports SM64Lib.Levels

Namespace TypeConverters

    Friend Class Vector3Converter
        Inherits TypeConverter 'ExpandableObjectConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destType As Type) As Boolean
            If destType = GetType(Vector3) Then
                Return True
            Else
                Return MyBase.CanConvertTo(context, destType)
            End If
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If destinationType Is GetType(System.String) AndAlso TypeOf value Is Vector3 Then
                Dim seperator As String = CultureInfo.CurrentCulture.TextInfo.ListSeparator
                Dim v3 As Vector3 = value
                Return $"{v3.X}{seperator} {v3.Y}{seperator} {v3.Z}"
            Else
                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End If
        End Function

        Public Overrides Function CanConvertFrom(context As ITypeDescriptorContext, sourceType As Type) As Boolean
            If (sourceType Is GetType(String)) Then
                Return True
            Else
                Return MyBase.CanConvertFrom(context, sourceType)
            End If
        End Function

        Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo, value As Object) As Object
            If (TypeOf value Is String) Then
                Dim seperator As String = CultureInfo.CurrentCulture.TextInfo.ListSeparator
                Dim split As String() = CStr(value).Split(seperator)
                Dim v3 As New Vector3
                v3.X = Math.Truncate(CSng(split(0)))
                v3.Y = Math.Truncate(CSng(split(1)))
                v3.Z = Math.Truncate(CSng(split(2)))
                Return v3
            Else
                Return MyBase.ConvertFrom(context, culture, value)
            End If
        End Function

        Public Overrides Function GetCreateInstanceSupported(context As ITypeDescriptorContext) As Boolean
            Return True
        End Function

        Public Overrides Function CreateInstance(context As ITypeDescriptorContext, propertyValues As IDictionary) As Object
            'Return MyBase.CreateInstance(context, propertyValues)

            If propertyValues Is Nothing Then
                Throw New ArgumentNullException("propertyValues")
            End If

            Dim objX As Object = propertyValues("X")
            Dim objY As Object = propertyValues("Y")
            Dim objZ As Object = propertyValues("Z")

            Return New Vector3(objX, objY, objZ)

            Throw New ArgumentException
        End Function

        Public Overrides Function GetProperties(context As ITypeDescriptorContext, value As Object, attributes() As Attribute) As PropertyDescriptorCollection
            Dim props As PropertyDescriptorCollection = TypeDescriptor.GetProperties(value.GetType, attributes)
            Return props.Sort(New String() {"X", "Y", "Z"})
        End Function

        Public Overrides Function GetPropertiesSupported(context As ITypeDescriptorContext) As Boolean
            Return True
        End Function

    End Class

    Friend Class LevelsTypeConverter
        Inherits TypeConverter 'ExpandableObjectConverter

        Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destType As Type) As Boolean
            If destType = GetType(Levels) Then
                Return True
            Else
                Return MyBase.CanConvertTo(context, destType)
            End If
        End Function

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            If TypeOf value Is Levels Then
                Dim values As Array = [Enum].GetValues(value.GetType)
                Return Array.IndexOf(values, value).ToString
            Else
                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End If
        End Function

        Public Overrides Function CanConvertFrom(context As ITypeDescriptorContext, sourceType As Type) As Boolean
            If (sourceType = GetType(String)) Then
                Return True
            Else
                Return MyBase.CanConvertFrom(context, sourceType)
            End If
        End Function

        Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo, value As Object) As Object
            Try
                Dim values As Array = [Enum].GetValues(GetType(Levels))
                Return values(CInt(value))
            Catch ex As Exception
                Return MyBase.ConvertFrom(context, culture, value)
            End Try
        End Function

    End Class


End Namespace
