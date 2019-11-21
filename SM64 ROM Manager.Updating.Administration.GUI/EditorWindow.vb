Public Class EditorWindow

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub InitVersionInfoEditor()
        RibbonTabItem_Packaging.Visible = False
        SuperTabItem_Pkg_Files.Visible = False
        SuperTabItem_Pkg_Extensions.Visible = False
        SuperTabItem_Pkg_Changelog.Visible = False
        RibbonControl1.SelectedRibbonTabItem = RibbonTabItem_UpdateInfo
    End Sub

    Public Sub InitPackageEditor()
        RibbonTabItem_UpdateInfo.Visible = False
        SuperTabItem_UpdateInfo.Visible = False
        RibbonControl1.SelectedRibbonTabItem = RibbonTabItem_Packaging
    End Sub

End Class
