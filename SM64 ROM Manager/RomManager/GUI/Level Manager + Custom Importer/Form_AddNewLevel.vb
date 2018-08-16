Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports SM64Lib

Public Class Form_AddNewLevel

    Public rommgr As RomManager = Nothing
    Private FinishedLoading As Boolean = False
    Private lidtable As New LevelInfoDataTabelList

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors()

    End Sub

    Public ReadOnly Property SelectedLevel As LevelInfoDataTabelList.Level
        Get
            Return lidtable(ComboBox_Level.SelectedIndex)
        End Get
    End Property

    Private Sub AddNewLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FinishedLoading Then Return

        LoadAddLevel()
        ComboBox_Level.SelectedIndex = 0

        FinishedLoading = True
    End Sub

    Private Sub LoadAddLevel()
        For Each e In rommgr.LevelInfoData
            If rommgr.Levels.Where(Function(n) n.LevelID = e.ID).Count = 0 Then
                lidtable.Add(e)
            End If
        Next

        With ComboBox_Level.Items
            .Clear()
            For Each lid In lidtable
                .Add(If(lid.Type = LevelInfoDataTabelList.LevelTypes.Level, CInt(lid.Number).ToString("00") & " - ", "") & lid.Name)
            Next
        End With
    End Sub
End Class
