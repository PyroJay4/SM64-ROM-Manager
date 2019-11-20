Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.Updating.UpdateInstaller
Imports SM64_ROM_Manager.Updating.UpdateInstaller.My.Resources.UpdateInstallerGuiLangRes

Public Class Main

    'F i e l d s

    Private allowClose As Boolean = False
    Private WithEvents Installer As UpdateInstaller

    'C o n s t r u c t o r s

    Public Sub New()
        'Get arguments
        Dim args As String() = My.Application.CommandLineArgs.ToArray
        If args.Any Then
            'Load config
            Installer = New UpdateInstaller(UpdateInstallerConfig.Parse(args(0)))

            'Init Form
            InitializeComponent()

            'Init Style
            StyleManager.Style = eStyle.Office2016
            StyleManager.MetroColorGeneratorParameters = New Metro.ColorTables.MetroColorGeneratorParameters(
                Installer.Configuration.UpdateWindowCanvasColor,
                Installer.Configuration.UpdateWindowBaseColor)
            StyleManager.UpdateAmbientColors(Me)

            'Init Application Header Text
            Dim header As String
            If Not String.IsNullOrEmpty(Installer.Configuration.ApplicationName) Then
                header = String.Format(String_UpdatingApplicationX, Installer.Configuration.ApplicationName)
            Else
                header = String_UpdateIsRunning
            End If
            LabelX_Header.Text = $"<div align=""center"" valign=""center""><font color=""#B7472A"" size=""20""><b>{header}</b></font></div>"
        End If

        If Installer Is Nothing Then End
    End Sub

    'F e a t u r e s

    Private Sub SetStatus(newStatus As UpdateInstallerStatus)
        Dim newStatusText As String = String.Empty

        Select Case newStatus
            Case UpdateInstallerStatus.CopyingFiles
                newStatusText = Status_CopyingFiles
            Case UpdateInstallerStatus.Done
                newStatusText = Status_Done
            Case UpdateInstallerStatus.Extracting
                newStatusText = Status_Extracting
            Case UpdateInstallerStatus.RunningAddons
                newStatusText = Status_RunningAddOns
            Case UpdateInstallerStatus.Waiting
                newStatusText = Status_Waiting
        End Select

        LabelX_Status.Text = newStatus

        If newStatus = UpdateInstallerStatus.Done Then
            allowClose = True
            Close()
        End If
    End Sub

    Private Async Function WaitforHostApp() As Task
        Await Task.Run(Sub() Installer.WaitForHostApplication())
    End Function

    Private Sub ExecuteUpdate()
        Task.Run(Sub() Installer.InstallUpdate())
    End Sub

    'G u i

    Private Async Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Await WaitforHostApp()
        ExecuteUpdate()
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Installer.StartHostApplication()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not allowClose
    End Sub

    Private Sub Installer_StatusChanges(sender As Object, e As UpdateInstallerStatusChangedEventArgs) Handles Installer.StatusChanges
        Invoke(Sub() SetStatus(e.NewStatus))
    End Sub

End Class
