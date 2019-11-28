Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace Text.Profiles

    Public MustInherit Class TextGroupInfo

        Public Const ENCODING_STRING_M64 As String = "m64"
        Public Const ENCODING_STRING_ASCII As String = "ascii"

        <JsonProperty("Encoding")>
        Private myTextEncoding As String

        Public Property Name As String

        <JsonIgnore>
        Public ReadOnly Property Encoding As System.Text.Encoding
            Get
                Select Case myTextEncoding
                    Case ENCODING_STRING_ASCII
                        Return System.Text.Encoding.ASCII
                    Case ENCODING_STRING_M64
                        Return M64TextEncoding.M64Text
                    Case Else
                        Return Nothing
                End Select
            End Get
        End Property

        <JsonIgnore>
        Public Property EncodingString As String
            Get
                Return myTextEncoding
            End Get
            Set(value As String)
                If {ENCODING_STRING_M64, ENCODING_STRING_ASCII}.Contains(value) Then
                    myTextEncoding = value
                End If
            End Set
        End Property

    End Class

End Namespace
