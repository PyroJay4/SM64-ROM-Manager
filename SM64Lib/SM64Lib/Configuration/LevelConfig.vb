Namespace Configuration

    Public Class LevelConfig

        Public Property LevelName As String
        Public ReadOnly Property AreaConfigs As New Dictionary(Of Byte, LevelAreaConfig)

        Public Function GetLevelAreaConfig(areaID As Byte) As LevelAreaConfig
            If AreaConfigs.ContainsKey(areaID) Then
                Return AreaConfigs(areaID)
            Else
                Dim conf As New LevelAreaConfig
                AreaConfigs.Add(areaID, conf)
                Return conf
            End If
        End Function

    End Class

End Namespace
