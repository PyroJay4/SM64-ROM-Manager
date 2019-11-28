Imports Newtonsoft.Json

Namespace ObjectBanks.Data

    Public Class ObjectBankDataCommand

        Public Property Command As Byte()

        <JsonIgnore>
        Public ReadOnly Property CommandType As Byte
            Get
                If Command IsNot Nothing AndAlso Command.Length >= 1 Then
                    Return Command(0)
                Else
                    Return 0
                End If
            End Get
        End Property

        Public Sub New()
            Command = Nothing
        End Sub

        Public Sub New(cmd As Byte())
            Command = cmd
        End Sub

    End Class

End Namespace
