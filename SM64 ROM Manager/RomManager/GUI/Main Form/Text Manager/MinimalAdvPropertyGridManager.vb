Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class MinimalAdvPropertyGridManager

    Private WithEvents AdvPropertyGrid1 As AdvPropertyGrid

    Public Sub New(advPropGrid As AdvPropertyGrid)
        AdvPropertyGrid1 = advPropGrid
    End Sub

    Private Sub AdvPropertyGrid1_ConvertFromStringToPropertyValue(sender As Object, e As ConvertValueEventArgs) Handles AdvPropertyGrid1.ConvertFromStringToPropertyValue
        Select Case e.PropertyDescriptor.PropertyType
            Case GetType(System.Boolean)
                If e.StringValue = "Yes" Then
                    e.TypedValue = True
                Else
                    e.TypedValue = False
                End If
                e.IsConverted = True

            Case GetType(System.Byte)
                e.TypedValue = CByte(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(System.SByte)
                e.TypedValue = CSByte(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(Int16)
                e.TypedValue = CShort(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(UInt16)
                e.TypedValue = CUShort(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(Int32)
                e.TypedValue = CInt(ValueFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(UInt32)
                e.TypedValue = CUInt(LongFromText(e.StringValue.Trim))
                e.IsConverted = True

            Case GetType(System.Single)
                e.TypedValue = CSng(e.StringValue.Trim)
                e.IsConverted = True

            Case GetType(System.Double)
                e.TypedValue = CDbl(e.StringValue.Trim)
                e.IsConverted = True

            Case GetType(System.Decimal)
                e.TypedValue = CDec(e.StringValue.Trim)
                e.IsConverted = True

        End Select
    End Sub

    Private Sub AdvPropertyGrid1_ConvertPropertyValueToString(sender As Object, e As ConvertValueEventArgs) Handles AdvPropertyGrid1.ConvertPropertyValueToString
        Select Case e.PropertyDescriptor.PropertyType
            Case GetType(System.Boolean)
                If e.TypedValue = True Then
                    e.StringValue = "Yes"
                Else
                    e.StringValue = "No"
                End If
                e.IsConverted = True

            Case GetType(System.Byte), GetType(System.SByte), GetType(Int16), GetType(UInt16), GetType(Int32), GetType(UInt32)
                e.StringValue = TextFromValue(e.TypedValue)
                e.IsConverted = True

        End Select
    End Sub

    Private Sub AdvPropertyGrid1_PropertyValueChanged(sender As Object, e As PropertyChangedEventArgs) Handles AdvPropertyGrid1.PropertyValueChanged
        AdvPropertyGrid1.RefreshPropertyValues()
    End Sub

End Class
