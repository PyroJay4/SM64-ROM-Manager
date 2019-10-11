Public Enum JobToDoUrgency
    OnNextExit = 1
    OnNextStartup = 2
    AsSoonAsPossible = OnNextExit Or OnNextStartup
End Enum
