Imports System.IO
Imports SM64_ROM_Manager.SettingsManager

Public Module JobToDoManager

    Friend Sub ExecuteStartupJobsToDo()
        ExecuteJobsToDo(JobToDoUrgency.OnNextStartup)
    End Sub

    Friend Sub ExecuteExitJobsToDo()
        ExecuteJobsToDo(JobToDoUrgency.OnNextExit)
    End Sub

    Private Sub ExecuteJobsToDo(urgency As JobToDoUrgency)
        For Each job As JobToDo In Settings.JobsToDo.ToArray
            If (job.Urgency And urgency) = urgency Then
                Select Case job.Type
                    Case JobToDoType.DeleteDirectory
                        Job_RemoveDirectory(job)
                    Case JobToDoType.DeleteFile
                        Job_RemoveFile(job)
                End Select
                Settings.JobsToDo.Remove(job)
            End If
        Next
    End Sub

    Private Sub Job_RemoveFile(job As JobToDo)
        Try
            File.Delete(job.Params(0))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Job_RemoveDirectory(job As JobToDo)
        Try
            Directory.Delete(job.Params(0), job.Params(1))
        Catch ex As Exception
        End Try
    End Sub

End Module
