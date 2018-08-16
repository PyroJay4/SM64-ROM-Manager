Imports DevComponents.DotNetBar

Namespace My

    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.

    Partial Friend Class MyApplication
        Private Sub OnErrorMessage(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If Debugger.IsAttached Then Return

            'Dim dialogInfo As New TaskDialogInfo With {
            '    .DialogButtons = eTaskDialogButton.Ok Or eTaskDialogButton.Close,
            '    .Header = "Unknown Error happend",
            '    .Title = "Unknown Error",
            '    .Text = "Sorry, but an unknown error has been detected.<br/>Please tell this error the developer. Explain how this message happend.<br/><br/>Click to <u>Ok</u> to continue with the application <i>(not recommed</i> or click to <u>Close</u> to close the application <i>(recommed)</i>.",
            '    .TaskDialogIcon = eTaskDialogIcon.Exclamation}

            'If TaskDialog.Show(dialogInfo) = eTaskDialogResult.Close Then End

            Dim frm As New Form_ErrorDialog
            frm.ErrorText = e.Exception.Message & vbNewLine & vbNewLine & e.Exception.StackTrace

            frm.ShowDialog()

            e.ExitApplication = frm.ExitApplicaiton
        End Sub
    End Class
End Namespace
