Public Class EditorWindow

    Public Sub InitVersionInfoEditor()
        RibbonTabItem_Packaging.Visible = False
        SuperTabItem_Pkg_General.Visible = False
        SuperTabItem_Pkg_Files.Visible = False
        SuperTabItem_Pkg_Extensions.Visible = False
        SuperTabItem_Pkg_Changelog.Visible = False
    End Sub

    Public Sub InitPackageEditor()
        RibbonTabItem_UpdateInfo.Visible = False
        SuperTabItem_UpdateInfo.Visible = False
    End Sub

End Class
