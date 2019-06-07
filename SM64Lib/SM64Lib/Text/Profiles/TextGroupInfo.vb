Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace Global.SM64Lib.Text.Profiles

    Public MustInherit Class TextGroupInfo

        <JsonProperty("Encoding")>
        Private myTextEncoding As String

        Public Property Name As String

        <JsonIgnore>
        Public ReadOnly Property Encoding As System.Text.Encoding
            Get
                Select Case myTextEncoding
                    Case "ascii"
                        Return System.Text.Encoding.ASCII
                    Case "m64"
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
                If {"m64", "ascii"}.Contains(value) Then
                    myTextEncoding = value
                End If
            End Set
        End Property

    End Class

End Namespace
