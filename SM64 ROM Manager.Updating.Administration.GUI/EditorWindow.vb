Imports System.IO
Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.UpdatingAdministrationLangRes

Public Class EditorWindow

#Region "General"

    'C o n s t a n t s

    Private Const FILTER_PACKAGE_TEMPLATE As String = "Update-Paket-Vorlagen (*.udpt)|*.udpt"
    Private Const FILTER_PACKAGE_ZIP_PACKAGE As String = "ZIP-Paket (*.zip)|*.zip"
    Private Const FILTER_PACKAGE_ADDON As String = "Anwendungserweiterung (*.dll)|*.dll"
    Private Const FILTER_UPDATEINFO_CONFIGURATION As String = "Update-Info-Konfiguration (*.udic)|*.udic"

    'C o n s t r u c t o r s

    Public Sub New()
        InitializeComponent()
    End Sub

    'G e n e r a l   F e a t u r e s

    Public Sub InitVersionInfoEditor()
        RibbonTabItem_Packaging.Visible = False
        SuperTabItem_Pkg_Files.Visible = False
        SuperTabItem_Pkg_Extensions.Visible = False
        RibbonControl_Main.SelectedRibbonTabItem = RibbonTabItem_UpdateInfo
    End Sub

    Public Sub InitPackageEditor()
        RibbonTabItem_UpdateInfo.Visible = False
        SuperTabItem_UI_General.Visible = False
        SuperTabItem_UI_PackageInfo.Visible = False
        SuperTabItem_UI_Changelog.Visible = False
        RibbonControl_Main.SelectedRibbonTabItem = RibbonTabItem_Packaging
    End Sub

    Private Sub UpdateView()
        Dim curRibbonTab As RibbonTabItem = RibbonControl_Main.SelectedRibbonTabItem
        If curRibbonTab Is RibbonTabItem_UpdateInfo Then
            Dim curTab As SuperTabItem = SuperTabControl1.SelectedTab
            If curTab Is SuperTabItem_UI_General Then
                RibbonBar_UI_Allgemein.Visible = True
                RibbonBar_UI_PackageInfo.Visible = False
            ElseIf curTab Is SuperTabItem_UI_PackageInfo Then
                RibbonBar_UI_Allgemein.Visible = False
                RibbonBar_UI_PackageInfo.Visible = True
            Else
                RibbonBar_UI_Allgemein.Visible = False
                RibbonBar_UI_PackageInfo.Visible = False
            End If
        ElseIf curRibbonTab Is RibbonTabItem_Packaging Then
            Dim curTab As SuperTabItem = SuperTabControl1.SelectedTab
            If curTab Is SuperTabItem_Pkg_Files Then
                RibbonBar_Pkg_Dateien.Visible = True
                RibbonBar_Pkg_Erweiterungen.Visible = False
            ElseIf curTab Is SuperTabItem_Pkg_Extensions Then
                RibbonBar_Pkg_Erweiterungen.Visible = True
                RibbonBar_Pkg_Dateien.Visible = False
            End If
            RibbonControl_Main.RecalcLayout()
        End If
    End Sub

    'G e n e r a l   G u i

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        UpdateView()
    End Sub

    Private Sub EditorWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UpdateView()
    End Sub

#End Region

#Region "Update-Info"

    'F i e l d s

    Private ReadOnly updateInfoManager As New UpdateInfoManager
    Private curUpdateInfoPath As String = String.Empty

    'F e a t u r e s

    Private Sub NewUpdateInfo()
        updateInfoManager.NewInfo()
        curUpdateInfoPath = String.Empty
        ShowAllUpdateInfoConfig()
    End Sub

    Private Sub OpenUpdateInfo()
        Dim ofd_UpdateAdmin_LoadUpdateInfo As New OpenFileDialog With {
            .Filter = FILTER_UPDATEINFO_CONFIGURATION
        }
        If ofd_UpdateAdmin_LoadUpdateInfo.ShowDialog = DialogResult.OK Then
            updateInfoManager.Load(ofd_UpdateAdmin_LoadUpdateInfo.FileName)
            curUpdateInfoPath = ofd_UpdateAdmin_LoadUpdateInfo.FileName
            ShowAllUpdateInfoConfig()
        End If
    End Sub

    Private Sub SaveUpdateInfo()
        If String.IsNullOrEmpty(curUpdateInfoPath) Then
            SaveUpdateInfoAs()
        Else
            updateInfoManager.Save(curUpdateInfoPath)
        End If
    End Sub

    Private Sub SaveUpdateInfoAs()
        Dim sfd_UpdateAdmin_SaveUpdateInfo As New SaveFileDialog With {
            .Filter = FILTER_UPDATEINFO_CONFIGURATION
        }
        If sfd_UpdateAdmin_SaveUpdateInfo.ShowDialog = DialogResult.OK Then
            updateInfoManager.Save(sfd_UpdateAdmin_SaveUpdateInfo.FileName)
            curUpdateInfoPath = sfd_UpdateAdmin_SaveUpdateInfo.FileName
        End If
    End Sub

    Private Sub EditUpdateInfoConfiguration()

    End Sub

    Private Sub ShowAllUpdateInfoConfig()
        LoadPackageInfoList()
    End Sub

    Private Sub LoadPackageInfoList()

    End Sub

    'G u i

    Private Sub ButtonItem_UI_NewPackage_Click(sender As Object, e As EventArgs) Handles ButtonItem_UI_NewPackage.Click
        NewUpdateInfo()
    End Sub

    Private Sub ButtonItem_UI_Open_Click(sender As Object, e As EventArgs) Handles ButtonItem_UI_Open.Click
        OpenUpdateInfo()
    End Sub

    Private Sub ButtonItem_UI_Save_Click(sender As Object, e As EventArgs) Handles ButtonItem_UI_Save.Click
        SaveUpdateInfo()
    End Sub

    Private Sub ButtonItem_UI_SaveAs_Click(sender As Object, e As EventArgs) Handles ButtonItem_UI_SaveAs.Click
        SaveUpdateInfoAs()
    End Sub

    Private Sub ButtonItem_UI_EditConfiguration_Click(sender As Object, e As EventArgs) Handles ButtonItem_UI_EditConfiguration.Click
        EditUpdateInfoConfiguration()
    End Sub

#End Region

#Region "Packager"

    'F i e l d s

    Private ReadOnly packageManager As New UpdatePackageManager
    Private curPackageTemplatePath As String = String.Empty

    'F e a t u r e s

    Private Sub ShowAllPackageTemplateConfig()
        ShowPackageFiles()
        ShowPackageExtensions()
    End Sub

    Private Sub ShowPackageFiles()
        AdvTree1.BeginUpdate()
        AdvTree1.Nodes.Clear()

        If Not String.IsNullOrEmpty(packageManager.FilesToCopyPath) Then
            Dim nodeCreation As Action(Of NodeCollection, String)
            nodeCreation =
                Sub(parentCollection As NodeCollection, p As String)
                    Dim isDir As Boolean = (File.GetAttributes(p) And FileAttributes.Directory) = FileAttributes.Directory
                    Dim n As New Node With {
                        .Tag = p,
                        .Text = If(AdvTree1.Nodes Is parentCollection, p, Path.GetFileName(p)),
                        .ImageIndex = If(isDir, 0, 1)
                    }
                    parentCollection.Add(n)
                    If isDir Then
                        Dim dirInfo As New DirectoryInfo(p)
                        dirInfo.EnumerateDirectories.ForEach(Sub(di) nodeCreation(n.Nodes, di.FullName))
                        dirInfo.EnumerateFiles.ForEach(Sub(fi) nodeCreation(n.Nodes, fi.FullName))
                    End If
                End Sub
            nodeCreation(AdvTree1.Nodes, packageManager.FilesToCopyPath)
        End If

        AdvTree1.EndUpdate()
    End Sub

    Private Sub ShowPackageExtensions()
        ListViewEx_Files.BeginUpdate()
        ListViewEx_Files.Items.Clear()

        For Each fAddOn As String In packageManager.GetAllUpdateInstallerÁddOn
            Dim item As New ListViewItem({Path.GetFileName(fAddOn), Path.GetDirectoryName(fAddOn)}) With {
                .Tag = fAddOn
            }
            ListViewEx_Files.Items.Add(item)
        Next

        ListViewEx_Files.EndUpdate()
    End Sub

    Private Function GetSelectedUpdateInstallAddOns() As IEnumerable(Of String)
        Dim list As New List(Of String)

        For Each item As ListViewItem In ListViewEx_Files.SelectedItems
            list.Add(item.Tag)
        Next

        Return list
    End Function

    Private Sub NewPackageTemplate()
        packageManager.NewTemplate()
        curPackageTemplatePath = String.Empty
        ShowAllPackageTemplateConfig()
    End Sub

    Private Sub OpenPackageTemplate()
        Dim ofd_UpdateAdmin_LoadTemplate As New OpenFileDialog With {
            .Filter = FILTER_PACKAGE_TEMPLATE
        }
        If ofd_UpdateAdmin_LoadTemplate.ShowDialog = DialogResult.OK Then
            packageManager.LoadTemplate(ofd_UpdateAdmin_LoadTemplate.FileName)
            curPackageTemplatePath = ofd_UpdateAdmin_LoadTemplate.FileName
            ShowAllPackageTemplateConfig()
        End If
    End Sub

    Private Sub SavePackageTemplate()
        If String.IsNullOrEmpty(curPackageTemplatePath) Then
            SavePackageTemplateAs()
        Else
            packageManager.SaveTemplate(curPackageTemplatePath)
        End If
    End Sub

    Private Sub SavePackageTemplateAs()
        Dim sfd_UpdateAdmin_SaveTemplate As New SaveFileDialog With {
            .Filter = FILTER_PACKAGE_TEMPLATE
        }
        If sfd_UpdateAdmin_SaveTemplate.ShowDialog = DialogResult.OK Then
            packageManager.SaveTemplate(sfd_UpdateAdmin_SaveTemplate.FileName)
            curPackageTemplatePath = sfd_UpdateAdmin_SaveTemplate.FileName
        End If
    End Sub

    Private Sub SelectPackageFileFolder()
        Dim ofd_UpdateAdmin_PkgFileFolder As New CommonOpenFileDialog With {
            .IsFolderPicker = True
        }
        If ofd_UpdateAdmin_PkgFileFolder.ShowDialog = CommonFileDialogResult.Ok Then
            packageManager.FilesToCopyPath = ofd_UpdateAdmin_PkgFileFolder.FileName
            ShowPackageFiles()
        End If
    End Sub

    Private Sub RemovePackageFileFolder()
        packageManager.FilesToCopyPath = String.Empty
        ShowPackageFiles()
    End Sub

    Private Sub ExportUpdatePackage()
        Dim sfd_UpdateAdmin_ExportPkg As New SaveFileDialog With {
            .Filter = FILTER_PACKAGE_ZIP_PACKAGE
        }
        If sfd_UpdateAdmin_ExportPkg.ShowDialog = DialogResult.OK Then
            packageManager.ExportPackage(sfd_UpdateAdmin_ExportPkg.FileName)
        End If
    End Sub

    Private Sub AddUpdateInstallerExtension()
        Dim ofd_UpdateAdmin_AddExtension As New OpenFileDialog With {
            .Multiselect = True,
            .Filter = FILTER_PACKAGE_ADDON
        }
        If ofd_UpdateAdmin_AddExtension.ShowDialog = DialogResult.OK Then
            For Each f As String In ofd_UpdateAdmin_AddExtension.FileNames
                If Not packageManager.AddUpdateInstallerAddOn(f) Then
                    MessageBoxEx.Show(MsgBox_ErrorAddingInstallerAddOn, MsgBox_Error_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
        End If
    End Sub

    Private Sub RemoveUpdateInstallerExtension()
        For Each fAddOn As String In GetSelectedUpdateInstallAddOns()
            packageManager.RemoveUpdateInstallerAddOn(fAddOn)
        Next
    End Sub

    'G u i

    Private Sub ButtonItem_Pkg_NewTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_NewTemplate.Click
        NewPackageTemplate()
    End Sub

    Private Sub ButtonItem_Pkg_OpenTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_OpenTemplate.Click
        OpenPackageTemplate()
    End Sub

    Private Sub ButtonItem_Pkg_SaveTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_SaveTemplate.Click
        SavePackageTemplate()
    End Sub

    Private Sub ButtonItem_Pkg_SaveTemplateAs_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_SaveTemplateAs.Click
        SavePackageTemplateAs()
    End Sub

    Private Sub ButtonItem_Pkg_SelectFileFolder_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_SelectFileFolder.Click
        SelectPackageFileFolder()
    End Sub

    Private Sub ButtonItem_Pkg_RemoveFileFolder_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_RemoveFileFolder.Click
        RemovePackageFileFolder()
    End Sub

    Private Sub ButtonItem_ButtonItem_Pkg_Export_Click(sender As Object, e As EventArgs) Handles ButtonItem_ButtonItem_Pkg_Export.Click
        ExportUpdatePackage()
    End Sub

    Private Sub ButtonItem_Pkg_AddExtension_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_AddExtension.Click
        AddUpdateInstallerExtension()
    End Sub

    Private Sub ButtonItem_Pkg_RemoveExtension_Click(sender As Object, e As EventArgs) Handles ButtonItem_Pkg_RemoveExtension.Click
        RemoveUpdateInstallerExtension()
    End Sub

#End Region

End Class
