Namespace Levels

    Public Class LevelList
        Inherits List(Of Level)
        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return Me.Where(Function(n) n.NeedToSaveLevelscript OrElse n.NeedToSaveBanks0E).Count > 0
            End Get
        End Property
    End Class

End Namespace