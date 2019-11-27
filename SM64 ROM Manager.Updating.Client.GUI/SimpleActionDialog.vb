Imports SM64_ROM_Manager.Updating.Client.GUI.My.Resources

Public Class SimpleActionDialog

    Public Sub New()
        InitializeComponent()
        SetCurrentState(UpdateStatus.Waiting)
    End Sub

    Public Sub SetCurrentState(curAction As UpdateStatus)
        SetCurrentStateInternal(curAction, -1)
    End Sub

    Public Sub SetCurrentState(curAction As UpdateStatus, progress As Integer)
        SetCurrentStateInternal(curAction, progress)
    End Sub

    Private Sub SetCurrentStateInternal(curAction As UpdateStatus, progress As Integer)
        Select Case curAction
            Case UpdateStatus.Waiting
                LabelX_Progress.Text = UpdatingClientGuiLangRes.SimpleActions_Waiting
            Case UpdateStatus.Searching
                LabelX_Progress.Text = UpdatingClientGuiLangRes.SimpleActions_Searching
            Case UpdateStatus.Downloading
                LabelX_Progress.Text = UpdatingClientGuiLangRes.SimpleActions_Downloading
            Case UpdateStatus.PreConfigure
                LabelX_Progress.Text = UpdatingClientGuiLangRes.SimpleActions_PreConfigure
        End Select

        If progress = -1 Then
            ProgressBarX_Progress.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Else
            ProgressBarX_Progress.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard
            ProgressBarX_Progress.Value = progress
        End If
    End Sub

End Class
