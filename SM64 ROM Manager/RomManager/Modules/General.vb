Imports System.IO
Imports DevComponents.DotNetBar
Imports Pilz.S3DFileParser
Imports SM64_ROM_Manager.SettingsManager
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Geolayout
Imports SM64Lib.Levels
Imports SM64Lib.Model.Fast3D.DisplayLists
Imports SM64Lib.Patching
Imports SM64Lib.Text
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports SM64_ROM_Manager.LevelEditor
Imports SM64Lib.Script
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports SM64_ROM_Manager.Publics
Imports SM64Lib.Data

Friend Module General

    Private hasLoadedObjectCombos As Boolean = False
    Private hasLoadedBehaviorInfos As Boolean = False
    Private Const p_ObjectCombos As String = "Area Editor\Object Combos.json"
    Private Const p_ObjectCombosCustom As String = "Area Editor\Object Combos Custom.json"
    Private Const p_BehaviorInfos As String = "Area Editor\Behavior IDs.json"
    Private Const p_BehaviorInfosCustom As String = "Area Editor\Behavior IDs Custom.json"

    Public WithEvents RomWatcher As FileSystemWatcher = Nothing
    Public lastRomChangedDate As Date = Date.Now

    Public ReadOnly Property ObjectCombos As New ObjectComboList
    Public ReadOnly Property BehaviorInfos As New BehaviorInfoList
    Public ReadOnly Property ObjectCombosCustom As New ObjectComboList
    Public ReadOnly Property BehaviorInfosCustom As New BehaviorInfoList
    Public ReadOnly Property PatchClass As New PatchClass
    Public Property HasToolkitInit As Boolean = False

    Public Sub UpdateChecksum(Romfile As String)
        DisableRomWatcher()
        PatchClass.UpdateChecksum(Romfile)
        EnableRomWatcher()
    End Sub

    Public Sub EnableRomWatcher()
        If RomWatcher IsNot Nothing Then
            RomWatcher.EnableRaisingEvents = True
        End If
    End Sub

    Public Sub DisableRomWatcher()
        If RomWatcher IsNot Nothing Then
            RomWatcher.EnableRaisingEvents = False
        End If
    End Sub

    Public Function IsRomWatcherEnabled() As Boolean
        Return RomWatcher?.EnableRaisingEvents
    End Function

    Public Function OpenHexEditorAsync(cmd As SM64Lib.Script.ICommand) As Task
        Dim t As New Task(Sub() OpenHexEditor(cmd))
        t.Start()
        Return t
    End Function

    Public Sub OpenHexEditor(cmd As SM64Lib.Script.ICommand)
        Dim data As BinaryData = cmd

        'Copy content of command to a buffer
        Dim buffer As Byte() = New Byte(data.Length - 1) {}
        data.Position = 0
        data.Read(buffer)

        'Let edit the buffer
        OpenHexEditor(buffer)

        'Copy content of buffer back to command
        data.SetLength(buffer.Length)
        data.Position = 0
        data.Write(buffer)
    End Sub

    Public Sub OpenHexEditor(ByRef buffer As Byte())
        Dim mode As HexEditModes = Settings.General.HexEditMode.Mode
        Dim exeFile As String = Settings.General.HexEditMode.CustomPath

        If mode = HexEditModes.CustomHexEditor AndAlso Not File.Exists(exeFile) Then
            mode = HexEditModes.BuildInHexEditor
        End If

        Select Case mode
            Case HexEditModes.BuildInHexEditor
                Dim editor As New HexEditor(buffer)
                editor.ShowDialog()
                buffer = editor.GetData

            Case HexEditModes.CustomHexEditor
                'Create temp file
                Dim tempFile As String = Path.GetTempFileName

                'Write content of command to temp file
                Dim fs As New FileStream(tempFile, FileMode.Open, FileAccess.ReadWrite)
                fs.Write(buffer, 0, buffer.Length)
                fs.Flush()
                fs.Close()

                'Start Hex Editor and wait while running
                Dim p As New Process
                p.StartInfo.FileName = exeFile
                p.StartInfo.Arguments = $"""{tempFile}"""
                p.Start()
                p.WaitForExit()

                'Read content of temp file to command
                fs = New FileStream(tempFile, FileMode.Open, FileAccess.Read)
                buffer = New Byte(fs.Length - 1) {}
                fs.Read(buffer, 0, buffer.Length)
                fs.Close()

                'Remove temp file
                File.Delete(tempFile)
        End Select
    End Sub

    Public Function GetKeyForConvertAreaModel(romGameName As String, curLevelID As Short, curAreaID As Byte) As String
        Return $"{romGameName} l{curLevelID.ToString("X2")} a{curAreaID.ToString("X")}"
    End Function

    Public Sub LoadBehaviorInfosIfEmpty()
        If Not hasLoadedBehaviorInfos Then
            LoadBehaviorInfos()
        End If
    End Sub
    Public Sub LoadBehaviorInfos()
        If Not hasLoadedBehaviorInfos Then
            Dim p_Default As String = Path.Combine(MyDataPath, p_BehaviorInfos)
            Dim p_Custom As String = Path.Combine(MyDataPath, p_BehaviorInfosCustom)

            If File.Exists(p_Default) Then
                BehaviorInfos.ReadFromFile(p_Default)
            End If

            If File.Exists(p_Custom) Then
                BehaviorInfosCustom.ReadFromFile(p_Custom)
            End If

            hasLoadedBehaviorInfos = True
        End If
    End Sub
    Public Sub LoadObjectCombosIfEmpty()
        If Not hasLoadedObjectCombos Then
            LoadObjectCombos()
        End If
    End Sub
    Public Sub LoadObjectCombos()
        Dim p_Default As String = Path.Combine(MyDataPath, p_ObjectCombos)
        Dim p_Custom As String = Path.Combine(MyDataPath, p_ObjectCombosCustom)

        If File.Exists(p_Default) Then
            ObjectCombos.ReadFromFile(p_Default)
        End If

        If File.Exists(p_Custom) Then
            ObjectCombosCustom.ReadFromFile(p_Custom)
        End If

        hasLoadedObjectCombos = True
    End Sub

    Public Sub SaveBehaviorInfos()
        Dim p_Default As String = Path.Combine(MyDataPath, p_BehaviorInfos)
        Dim p_Custom As String = Path.Combine(MyDataPath, p_BehaviorInfosCustom)
        BehaviorInfos.WriteToFile(p_Default)
        BehaviorInfosCustom.WriteToFile(p_Custom)
    End Sub
    Public Sub SaveObjectCombos()
        Dim p_Default As String = Path.Combine(MyDataPath, p_ObjectCombos)
        Dim p_Custom As String = Path.Combine(MyDataPath, p_ObjectCombosCustom)
        ObjectCombos.WriteToFile(p_Default)
        ObjectCombosCustom.WriteToFile(p_Custom)
    End Sub

    Public Function GetFiltersFromFilter(filter As String, ParamArray splitters As Char())
        Dim filters As New List(Of String)

        For Each f As String In filter.ToLower.Split(splitters)
            f = f.Trim
            If Not String.IsNullOrEmpty(f) Then
                filters.Add(f)
            End If
        Next

        Return filters.ToArray
    End Function

    Public Function GetMidiExportDialogControls() As CommonFileDialogControl
        Dim cb As New CommonFileDialogComboBox With {
            .Name = "MidiChunksSelector",
            .IsProminent = True
        }
        cb.Items.Add(New CommonFileDialogComboBoxItem("1 Chunk"))
        cb.Items.Add(New CommonFileDialogComboBoxItem("2 Chunks"))
        cb.SelectedIndex = 1

        Return cb
    End Function

    Friend Sub LaunchRom(rommgr As RomManager)
        If rommgr?.RomFile <> "" Then
            Try
                If Not String.IsNullOrEmpty(Settings.General.EmulatorPath) Then
                    Process.Start(Settings.General.EmulatorPath, rommgr.RomFile)
                Else
                    Process.Start(rommgr.RomFile)
                End If
            Catch ex As Exception
                MessageBoxEx.Show(Form_Main_Resources.MsgBox_RomCanNotBestarted, Form_Main_Resources.MsgBox_RomCanNotBestarted_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Friend Sub SaveRom(rommgr As RomManager)
        If rommgr IsNot Nothing Then
            Dim dontpatchupdates As Boolean

            RomWatcher.EnableRaisingEvents = False

            If rommgr.AreRomUpdatesAvaiable Then
                Select Case Settings.General.ActionIfUpdatePatches
                    Case DialogResult.Yes
                        dontpatchupdates = False
                    Case DialogResult.No
                        dontpatchupdates = True
                    Case Else
                        Dim tdi As New TaskDialogInfo(Form_Main_Resources.MsgBox_UpdatePatchesAvaiable_Title, eTaskDialogIcon.ShieldHelp, Form_Main_Resources.MsgBox_UpdatePatchesAvaiable_Title, Form_Main_Resources.MsgBox_UpdatePatchesAvaiable, eTaskDialogButton.Yes Or eTaskDialogButton.No Or eTaskDialogButton.Cancel)
                        tdi.CheckBoxCommand = New Command With {.Text = "Don't show this message again."}
                        Select Case TaskDialog.Show(tdi) 'MessageBoxEx.Show(Form_Main_Resources.MsgBox_UpdatePatchesAvaiable, Form_Main_Resources.MsgBox_UpdatePatchesAvaiable_Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                            Case eTaskDialogResult.Yes
                                dontpatchupdates = False
                                If tdi.CheckBoxCommand.Checked Then
                                    Settings.General.ActionIfUpdatePatches = DialogResult.Yes
                                End If
                            Case eTaskDialogResult.No
                                dontpatchupdates = True
                                If tdi.CheckBoxCommand.Checked Then
                                    Settings.General.ActionIfUpdatePatches = DialogResult.No
                                End If
                            Case Else
                                Return
                        End Select
                        If Not tdi.CheckBoxCommand.Checked Then
                            Settings.General.ActionIfUpdatePatches = DialogResult.None
                        End If
                End Select
            Else
                dontpatchupdates = False
            End If

            rommgr.SaveRom(, dontpatchupdates)

            RomWatcher.EnableRaisingEvents = True
        End If
    End Sub

    Friend Function LoadAreaVisualMapAsObject3DAsync(rommgr As RomManager, area As LevelArea) As Task(Of Object3D)
        Dim t As New Task(Of Object3D)(Function() LoadAreaVisualMapAsObject3D(rommgr, area))
        t.Start()
        Return t
    End Function

    Friend Function LoadAreaVisualMapAsObject3D(rommgr As RomManager, area As LevelArea) As Object3D
        Dim obj As New Object3D

        For Each geop As Geopointer In area.AreaModel.Fast3DBuffer.DLPointers
            Dim dl As New DisplayList
            dl.FromStream(geop, rommgr, area.AreaID)
            dl.ToObject3D(obj, rommgr, area.AreaID)
        Next

        Return obj
    End Function

    Friend Function LoadVisualMapAsObject3D(rommgr As RomManager, mdl As Model.Fast3D.Fast3DBuffer) As Object3D
        Dim obj As New Object3D

        For Each geop As Geopointer In mdl.DLPointers
            Dim dl As New DisplayList
            dl.FromStream(geop, rommgr, Nothing)
            dl.ToObject3D(obj, rommgr, Nothing)
        Next

        Return obj
    End Function

    Public Sub ReorderBoxDataPositions(SpecialBox As SpecialBox)
        Dim x1, x2, z1, z2 As Int16

        x1 = Math.Min(SpecialBox.X1, SpecialBox.X2)
        x2 = Math.Max(SpecialBox.X1, SpecialBox.X2)
        z1 = Math.Min(SpecialBox.Z1, SpecialBox.Z2)
        z2 = Math.Max(SpecialBox.Z1, SpecialBox.Z2)

        SpecialBox.X1 = x1
        SpecialBox.X2 = x2
        SpecialBox.Z1 = z1
        SpecialBox.Z2 = z2
    End Sub

    Public Function IsFormOpen(Of FormType)() As Boolean
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FormType Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function GetFirstOpenForm(Of FormType)() As Form
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FormType Then
                Return frm
            End If
        Next
        Return Nothing
    End Function

    Public Sub AwaitOnUI(Of T As Task)(task As T)
        Do While task.Status = TaskStatus.Running
            Application.DoEvents()
        Loop
    End Sub
    Public Function AwaitOnUI(Of T)(task As Task(Of T)) As Object
        Do While task.Status = TaskStatus.Running
            Application.DoEvents()
        Loop
        Return task.Result
    End Function

#Region "Level Background/Environment/Camera/etc."
    Public Function GetBackgroundAddressOfID(ID As BackgroundIDs, EndAddr As Boolean) As BackgroundPointers
        Select Case ID
            Case BackgroundIDs.AboveClouds
                If EndAddr Then Return BackgroundPointers.AboveCloudsEnd
                Return BackgroundPointers.AboveCloudsStart

            Case BackgroundIDs.BelowClouds
                If EndAddr Then Return BackgroundPointers.BelowCloudsEnd
                Return BackgroundPointers.BelowCloudsStart

            Case BackgroundIDs.Cavern
                If EndAddr Then Return BackgroundPointers.CavernEnd
                Return BackgroundPointers.CavernStart

            Case BackgroundIDs.Desert
                If EndAddr Then Return BackgroundPointers.DesertEnd
                Return BackgroundPointers.DesertStart

            Case BackgroundIDs.FlamingSky
                If EndAddr Then Return BackgroundPointers.FlamingSkyEnd
                Return BackgroundPointers.FlamingSkyStart

            Case BackgroundIDs.HauntedForest
                If EndAddr Then Return BackgroundPointers.HauntedForestEnd
                Return BackgroundPointers.HauntedForestStart

            Case BackgroundIDs.Ocean
                If EndAddr Then Return BackgroundPointers.OceanEnd
                Return BackgroundPointers.OceanStart

            Case BackgroundIDs.PurpleClouds
                If EndAddr Then Return BackgroundPointers.PurpleCloudsEnd
                Return BackgroundPointers.PurpleCloudsStart

            Case BackgroundIDs.SnowyMountains
                If EndAddr Then Return BackgroundPointers.SnowyMountainsEnd
                Return BackgroundPointers.SnowyMountainsStart

            Case BackgroundIDs.UnderwaterCity
                If EndAddr Then Return BackgroundPointers.UnderwaterCityEnd
                Return BackgroundPointers.UnderwaterCityStart

        End Select

        Return If(EndAddr, BackgroundPointers.OceanEnd, BackgroundPointers.OceanStart)
    End Function
    Public Function GetBackgroundIDOfAddress(StartAddr As Integer) As BackgroundIDs
        Select Case StartAddr
            Case BackgroundPointers.AboveCloudsStart : Return BackgroundIDs.AboveClouds
            Case BackgroundPointers.BelowCloudsStart : Return BackgroundIDs.BelowClouds
            Case BackgroundPointers.CavernStart : Return BackgroundIDs.Cavern
            Case BackgroundPointers.DesertStart : Return BackgroundIDs.Desert
            Case BackgroundPointers.FlamingSkyStart : Return BackgroundIDs.FlamingSky
            Case BackgroundPointers.HauntedForestStart : Return BackgroundIDs.HauntedForest
            Case BackgroundPointers.OceanStart : Return BackgroundIDs.Ocean
            Case BackgroundPointers.PurpleCloudsStart : Return BackgroundIDs.PurpleClouds
            Case BackgroundPointers.SnowyMountainsStart : Return BackgroundIDs.SnowyMountains
            Case BackgroundPointers.UnderwaterCityStart : Return BackgroundIDs.UnderwaterCity
            Case Else : Return BackgroundIDs.Custom
        End Select
    End Function
    Public Function GetBackgroundIDOfIndex(Index As Integer) As BackgroundIDs
        Select Case Index
            Case 0 : Return BackgroundIDs.HauntedForest
            Case 1 : Return BackgroundIDs.SnowyMountains
            Case 2 : Return BackgroundIDs.Desert
            Case 3 : Return BackgroundIDs.Ocean
            Case 4 : Return BackgroundIDs.UnderwaterCity
            Case 5 : Return BackgroundIDs.BelowClouds
            Case 6 : Return BackgroundIDs.AboveClouds
            Case 7 : Return BackgroundIDs.Cavern
            Case 8 : Return BackgroundIDs.FlamingSky
            Case 9 : Return BackgroundIDs.PurpleClouds
            Case 10 : Return BackgroundIDs.Custom
            Case Else : Return BackgroundIDs.Ocean
        End Select
    End Function
    Public Function GetBackgroundIndexOfID(ID As BackgroundIDs) As Integer
        Select Case ID
            Case BackgroundIDs.HauntedForest : Return 0
            Case BackgroundIDs.SnowyMountains : Return 1
            Case BackgroundIDs.Desert : Return 2
            Case BackgroundIDs.Ocean : Return 3
            Case BackgroundIDs.UnderwaterCity : Return 4
            Case BackgroundIDs.BelowClouds : Return 5
            Case BackgroundIDs.AboveClouds : Return 6
            Case BackgroundIDs.Cavern : Return 7
            Case BackgroundIDs.FlamingSky : Return 8
            Case BackgroundIDs.PurpleClouds : Return 9
            Case BackgroundIDs.Custom : Return 10
            Case Else : Return BackgroundIDs.Ocean : Return 0
        End Select
    End Function
    Public Function GetEnvironmentTypeOfIndex(Index As Integer) As EnvironmentEffects
        Select Case Index
            Case 0 : Return EnvironmentEffects.NoEffect
            Case 1 : Return EnvironmentEffects.Snow
            Case 2 : Return EnvironmentEffects.Bllizard
            Case 3 : Return EnvironmentEffects.BetaFlower
            Case 4 : Return EnvironmentEffects.Lava
            Case 5 : Return EnvironmentEffects.WaterRelated1
            Case 6 : Return EnvironmentEffects.WaterRelated2
            Case Else : Return EnvironmentEffects.NoEffect
        End Select
    End Function
    Public Function GetEnvironmentIndexOfType(Type As EnvironmentEffects) As Integer
        Select Case Type
            Case EnvironmentEffects.NoEffect : Return 0
            Case EnvironmentEffects.Snow : Return 1
            Case EnvironmentEffects.Bllizard : Return 2
            Case EnvironmentEffects.BetaFlower : Return 3
            Case EnvironmentEffects.Lava : Return 4
            Case EnvironmentEffects.WaterRelated1 : Return 5
            Case EnvironmentEffects.WaterRelated2 : Return 6
            Case Else : Return 0
        End Select
    End Function
    Public Function GetCameraPresetTypeOfIndex(Index As Integer) As CameraPresets
        Return CType(Index + 1, CameraPresets)
    End Function
    Public Function GetCameraPresetIndexOfType(Type As CameraPresets) As Integer
        Return CInt(Type) - 1
    End Function
    Public Function GetAreaBGIndexOfID(ID As AreaBGs) As Integer
        Return CInt(ID)
    End Function
    Public Function GetAreaBGIDOfIndex(Index As Integer) As AreaBGs
        Return CType(Index, AreaBGs)
    End Function
#End Region

End Module
