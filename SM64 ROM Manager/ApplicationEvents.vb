﻿Imports DevComponents.DotNetBar

Namespace My

    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.

    Partial Friend Class MyApplication

        Private Sub OnAppStart(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler WantIntegerValueMode, Sub(ee) ee.IntegerValueMode = SettingsManager.Settings.General.IntegerValueMode
        End Sub

        Private Sub OnErrorMessage(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If Not Debugger.IsAttached Then
                Dim exception As Exception =
                e.Exception.Demystify

                Dim frm As New Form_ErrorDialog
                frm.ErrorText = exception.Message & vbNewLine & vbNewLine & exception.StackTrace

                frm.ShowDialog()

                e.ExitApplication = frm.ExitApplicaiton
            End If
        End Sub

    End Class

End Namespace
