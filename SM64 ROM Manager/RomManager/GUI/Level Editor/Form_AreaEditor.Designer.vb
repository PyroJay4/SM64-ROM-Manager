Namespace LevelEditor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Form_AreaEditor
        Inherits DevComponents.DotNetBar.RibbonForm

        'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Wird vom Windows Form-Designer benötigt.
        Private components As System.ComponentModel.IContainer

        'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AreaEditor))
            Me.ListViewEx_Warps = New DevComponents.DotNetBar.Controls.ListViewEx()
            Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ListViewEx_Objects = New DevComponents.DotNetBar.Controls.ListViewEx()
            Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Panel_GLControl = New DevComponents.DotNetBar.PanelEx()
            Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
            Me.ComboItem1 = New DevComponents.Editors.ComboItem()
            Me.ComboItem2 = New DevComponents.Editors.ComboItem()
            Me.DotNetBarManager1 = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
            Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
            Me.Bar_Controls = New DevComponents.DotNetBar.Bar()
            Me.PanelDockContainer2 = New DevComponents.DotNetBar.PanelDockContainer()
            Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
            Me.PanelEx5 = New DevComponents.DotNetBar.PanelEx()
            Me.Slider_CamMoveSpeed = New DevComponents.DotNetBar.Controls.Slider()
            Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
            Me.PanelEx4 = New DevComponents.DotNetBar.PanelEx()
            Me.ButtonX_CamMode = New DevComponents.DotNetBar.ButtonX()
            Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
            Me.ButtonItem_CamOrbit = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CamFly = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
            Me.ButtonItem_CamTop = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CamButtom = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CamLeft = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CamRight = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CamFront = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CamBack = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
            Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
            Me.ButtonX_KeepOnButtom = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX_KeepOnTop = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX_KeepOnGround = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX_DropToBottom = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX_DropToTop = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX_DropToGround = New DevComponents.DotNetBar.ButtonX()
            Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
            Me.Slider_ObjMoveSpeed = New DevComponents.DotNetBar.Controls.Slider()
            Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
            Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
            Me.PictureBox_CamCntrWheel = New System.Windows.Forms.PictureBox()
            Me.PictureBox_CamMoveCross = New System.Windows.Forms.PictureBox()
            Me.PictureBox_ObjRotWheel = New System.Windows.Forms.PictureBox()
            Me.PictureBox_ObjRotCross = New System.Windows.Forms.PictureBox()
            Me.PictureBox_ObjCntrWheel = New System.Windows.Forms.PictureBox()
            Me.PictureBox_ObjCntrCross = New System.Windows.Forms.PictureBox()
            Me.DockContainerItem2 = New DevComponents.DotNetBar.DockContainerItem()
            Me.DockSite9 = New DevComponents.DotNetBar.DockSite()
            Me.Bar_AreaViewer = New DevComponents.DotNetBar.Bar()
            Me.PanelDockContainer3 = New DevComponents.DotNetBar.PanelDockContainer()
            Me.DockContainerItem3 = New DevComponents.DotNetBar.DockContainerItem()
            Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
            Me.Bar1 = New DevComponents.DotNetBar.Bar()
            Me.PanelDockContainer10 = New DevComponents.DotNetBar.PanelDockContainer()
            Me.AdvPropertyGrid1 = New DevComponents.DotNetBar.AdvPropertyGrid()
            Me.DockContainerItem7 = New DevComponents.DotNetBar.DockContainerItem()
            Me.Bar2 = New DevComponents.DotNetBar.Bar()
            Me.PanelDockContainer7 = New DevComponents.DotNetBar.PanelDockContainer()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PanelDockContainer1 = New DevComponents.DotNetBar.PanelDockContainer()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.PanelDockContainer8 = New DevComponents.DotNetBar.PanelDockContainer()
            Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.ListViewEx_CollVertices = New DevComponents.DotNetBar.Controls.ListViewEx()
            Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.ListViewEx_ColFaces = New DevComponents.DotNetBar.Controls.ListViewEx()
            Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.DockContainerItem4 = New DevComponents.DotNetBar.DockContainerItem()
            Me.DockContainerItem1 = New DevComponents.DotNetBar.DockContainerItem()
            Me.DockContainerItem5 = New DevComponents.DotNetBar.DockContainerItem()
            Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
            Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
            Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
            Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
            Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
            Me.DockContainerItem6 = New DevComponents.DotNetBar.DockContainerItem()
            Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
            Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem_PasteObjDefault = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer7 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_ObjectsCopy = New DevComponents.DotNetBar.ButtonItem()
            Me.buttonItem55 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjCombo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjModelID = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjBehavID = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjBParams = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjActs = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjPos = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteObjRot = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem44 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar11 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonX_PasteWarpDefault = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer12 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonX_WarpsCopy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem73 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteWarpDestLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteWarpDestArea = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_PasteWarpDestWarp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem81 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem37 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CopyObjCmdAsHex = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_CopyWarpCmdAsHex = New DevComponents.DotNetBar.ButtonItem()
            Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
            Me.ButtonItem_CM_Objects = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem63 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ChangeObjectCombo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem30 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem33 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem64 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem65 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem68 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem1_CM_Warps = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem23 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem22 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem24 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem25 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem26 = New DevComponents.DotNetBar.ButtonItem()
            Me.GalleryContainer2 = New DevComponents.DotNetBar.GalleryContainer()
            Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonControl1 = New DevComponents.DotNetBar.RibbonControl()
            Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar29 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem35 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar9 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer11 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_ObjectsEditorCmd = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ResetObjToDefault = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar18 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer14 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_DropToGround = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_DropToTop = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_DropToBottom = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer15 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_KeepOnGround = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_KeepOnTop = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_KeepOnButtom = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar7 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem_ExportObjectModel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar8 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem_ObjectsRemove = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer21 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem27 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem28 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar27 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem31 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem32 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonX_ObjectsAdd = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem38 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem39 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem40 = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer6 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem41 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem42 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem43 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonPanel6 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar23 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
            Me.CheckBoxItem_PerspectiveMode = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItem_OrthoMode = New DevComponents.DotNetBar.CheckBoxItem()
            Me.RibbonBar22 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar21 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar20 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_DrawBackfaces = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ButtonItem_DrawObjects = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_DrawFill = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ButtonItem_DrawOutline = New DevComponents.DotNetBar.CheckBoxItem()
            Me.RibbonBar19 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem_ViewVisualMap = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ButtonItem_ViewColMap = New DevComponents.DotNetBar.CheckBoxItem()
            Me.RibbonPanel3 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar4 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer13 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem83 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem84 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar16 = New DevComponents.DotNetBar.RibbonBar()
            Me.RibbonPanel7 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar28 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem34 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonPanel4 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar14 = New DevComponents.DotNetBar.RibbonBar()
            Me.RibbonBar25 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer16 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar24 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer17 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem10 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem11 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem12 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar15 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem21 = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainer19 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar13 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer18 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer20 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem20 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem14 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem15 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem16 = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBar17 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem85 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem86 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonPanel2 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer10 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonX_WarpsEditCmd = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem69 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar26 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer22 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItem29 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar10 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonX_WarpsRemove = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar12 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonX_WarpsAdd = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonX_WarpsAddConnectedWarp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonX_WarpsAddPaintingWarp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_WarpsAddInstantWarp = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonPanel5 = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBar30 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem36 = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar6 = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItem47 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ImportModel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ImportVisualMap = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ImportCollision = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem53 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ExportVisualMap = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ExportCollision = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBar5 = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainer8 = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainer9 = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItem_Area = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItem_AddArea = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_RemoveArea = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonTabItem3 = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonTabItem5 = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonTabItem_Objects = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonTabItem_Warps = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonTabItem_Collision = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonTabItem6 = New DevComponents.DotNetBar.RibbonTabItem()
            Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
            Me.ButtonItem95 = New DevComponents.DotNetBar.ButtonItem()
            Me.ApplicationButton1 = New DevComponents.DotNetBar.ApplicationButton()
            Me.ButtonItem_SaveRom = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_LaunchROM = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_Undo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_Redo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem()
            Me.Panel_GLControl.SuspendLayout()
            Me.DockSite4.SuspendLayout()
            CType(Me.Bar_Controls, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Bar_Controls.SuspendLayout()
            Me.PanelDockContainer2.SuspendLayout()
            Me.PanelEx1.SuspendLayout()
            Me.PanelEx5.SuspendLayout()
            Me.PanelEx4.SuspendLayout()
            Me.PanelEx3.SuspendLayout()
            Me.PanelEx2.SuspendLayout()
            CType(Me.PictureBox_CamCntrWheel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_CamMoveCross, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_ObjRotWheel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_ObjRotCross, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_ObjCntrWheel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_ObjCntrCross, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.DockSite9.SuspendLayout()
            CType(Me.Bar_AreaViewer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Bar_AreaViewer.SuspendLayout()
            Me.PanelDockContainer3.SuspendLayout()
            Me.DockSite1.SuspendLayout()
            CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Bar1.SuspendLayout()
            Me.PanelDockContainer10.SuspendLayout()
            CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Bar2.SuspendLayout()
            Me.PanelDockContainer7.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.PanelDockContainer1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.PanelDockContainer8.SuspendLayout()
            CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonControl1.SuspendLayout()
            Me.RibbonPanel1.SuspendLayout()
            Me.RibbonPanel6.SuspendLayout()
            Me.RibbonPanel3.SuspendLayout()
            Me.RibbonPanel7.SuspendLayout()
            Me.RibbonPanel4.SuspendLayout()
            Me.RibbonPanel2.SuspendLayout()
            Me.RibbonPanel5.SuspendLayout()
            Me.SuspendLayout()
            '
            'ListViewEx_Warps
            '
            resources.ApplyResources(Me.ListViewEx_Warps, "ListViewEx_Warps")
            Me.ListViewEx_Warps.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.ListViewEx_Warps.Border.Class = "ListViewBorder"
            Me.ListViewEx_Warps.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ListViewEx_Warps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
            Me.ListViewEx_Warps.DisabledBackColor = System.Drawing.Color.Empty
            Me.ListViewEx_Warps.FocusCuesEnabled = False
            Me.ListViewEx_Warps.ForeColor = System.Drawing.Color.Black
            Me.ListViewEx_Warps.FullRowSelect = True
            Me.ListViewEx_Warps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.ListViewEx_Warps.HideSelection = False
            Me.ListViewEx_Warps.MultiSelect = False
            Me.ListViewEx_Warps.Name = "ListViewEx_Warps"
            Me.ListViewEx_Warps.UseCompatibleStateImageBehavior = False
            Me.ListViewEx_Warps.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader2
            '
            resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
            '
            'ColumnHeader4
            '
            resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
            '
            'ColumnHeader5
            '
            resources.ApplyResources(Me.ColumnHeader5, "ColumnHeader5")
            '
            'ColumnHeader6
            '
            resources.ApplyResources(Me.ColumnHeader6, "ColumnHeader6")
            '
            'ListViewEx_Objects
            '
            resources.ApplyResources(Me.ListViewEx_Objects, "ListViewEx_Objects")
            Me.ListViewEx_Objects.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.ListViewEx_Objects.Border.Class = "ListViewBorder"
            Me.ListViewEx_Objects.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ListViewEx_Objects.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3})
            Me.ListViewEx_Objects.DisabledBackColor = System.Drawing.Color.Empty
            Me.ListViewEx_Objects.FocusCuesEnabled = False
            Me.ListViewEx_Objects.ForeColor = System.Drawing.Color.Black
            Me.ListViewEx_Objects.FullRowSelect = True
            Me.ListViewEx_Objects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.ListViewEx_Objects.HideSelection = False
            Me.ListViewEx_Objects.Name = "ListViewEx_Objects"
            Me.ListViewEx_Objects.UseCompatibleStateImageBehavior = False
            Me.ListViewEx_Objects.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
            '
            'ColumnHeader3
            '
            resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
            '
            'Panel_GLControl
            '
            Me.Panel_GLControl.Controls.Add(Me.CircularProgress1)
            Me.Panel_GLControl.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.Panel_GLControl, "Panel_GLControl")
            Me.Panel_GLControl.Name = "Panel_GLControl"
            '
            'CircularProgress1
            '
            resources.ApplyResources(Me.CircularProgress1, "CircularProgress1")
            '
            '
            '
            Me.CircularProgress1.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground
            Me.CircularProgress1.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial
            Me.CircularProgress1.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBarBackground
            Me.CircularProgress1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CircularProgress1.BackgroundStyle.BorderBottomWidth = 2
            Me.CircularProgress1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.CircularProgress1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CircularProgress1.BackgroundStyle.BorderLeftWidth = 2
            Me.CircularProgress1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CircularProgress1.BackgroundStyle.BorderRightWidth = 2
            Me.CircularProgress1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CircularProgress1.BackgroundStyle.BorderTopWidth = 2
            Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CircularProgress1.Name = "CircularProgress1"
            Me.CircularProgress1.SetVisibleStateOnStart = True
            Me.CircularProgress1.SetVisibleStateOnStop = True
            Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
            '
            'ComboItem1
            '
            resources.ApplyResources(Me.ComboItem1, "ComboItem1")
            '
            'ComboItem2
            '
            resources.ApplyResources(Me.ComboItem2, "ComboItem2")
            '
            'DotNetBarManager1
            '
            Me.DotNetBarManager1.AlwaysShowFullMenus = True
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
            Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins)
            Me.DotNetBarManager1.BottomDockSite = Me.DockSite4
            Me.DotNetBarManager1.EnableFullSizeDock = False
            Me.DotNetBarManager1.FillDockSite = Me.DockSite9
            Me.DotNetBarManager1.LeftDockSite = Me.DockSite1
            Me.DotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.DotNetBarManager1.ParentForm = Me
            Me.DotNetBarManager1.RightDockSite = Me.DockSite2
            Me.DotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DotNetBarManager1.ToolbarBottomDockSite = Me.DockSite8
            Me.DotNetBarManager1.ToolbarLeftDockSite = Me.DockSite5
            Me.DotNetBarManager1.ToolbarRightDockSite = Me.DockSite6
            Me.DotNetBarManager1.TopDockSite = Me.DockSite3
            '
            'DockSite4
            '
            Me.DockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            Me.DockSite4.Controls.Add(Me.Bar_Controls)
            resources.ApplyResources(Me.DockSite4, "DockSite4")
            Me.DockSite4.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar_Controls, 967, 132), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Vertical)
            Me.DockSite4.Name = "DockSite4"
            Me.DockSite4.TabStop = False
            '
            'Bar_Controls
            '
            resources.ApplyResources(Me.Bar_Controls, "Bar_Controls")
            Me.Bar_Controls.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
            Me.Bar_Controls.AutoSyncBarCaption = True
            Me.Bar_Controls.CanCustomize = False
            Me.Bar_Controls.CloseSingleTab = True
            Me.Bar_Controls.Controls.Add(Me.PanelDockContainer2)
            Me.Bar_Controls.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
            Me.Bar_Controls.HideFloatingInactive = False
            Me.Bar_Controls.IsMaximized = False
            Me.Bar_Controls.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem2})
            Me.Bar_Controls.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
            Me.Bar_Controls.Name = "Bar_Controls"
            Me.Bar_Controls.Stretch = True
            Me.Bar_Controls.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Bar_Controls.TabStop = False
            '
            'PanelDockContainer2
            '
            Me.PanelDockContainer2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelDockContainer2.Controls.Add(Me.PanelEx1)
            Me.PanelDockContainer2.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelDockContainer2, "PanelDockContainer2")
            Me.PanelDockContainer2.Name = "PanelDockContainer2"
            Me.PanelDockContainer2.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelDockContainer2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.PanelDockContainer2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelDockContainer2.Style.GradientAngle = 90
            '
            'PanelEx1
            '
            Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.ActiveBorder
            Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelEx1.Controls.Add(Me.PanelEx5)
            Me.PanelEx1.Controls.Add(Me.PanelEx4)
            Me.PanelEx1.Controls.Add(Me.PanelEx3)
            Me.PanelEx1.Controls.Add(Me.PanelEx2)
            Me.PanelEx1.Controls.Add(Me.PictureBox_CamCntrWheel)
            Me.PanelEx1.Controls.Add(Me.PictureBox_CamMoveCross)
            Me.PanelEx1.Controls.Add(Me.PictureBox_ObjRotWheel)
            Me.PanelEx1.Controls.Add(Me.PictureBox_ObjRotCross)
            Me.PanelEx1.Controls.Add(Me.PictureBox_ObjCntrWheel)
            Me.PanelEx1.Controls.Add(Me.PictureBox_ObjCntrCross)
            Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelEx1, "PanelEx1")
            Me.PanelEx1.Name = "PanelEx1"
            Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelEx1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Center
            Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.PanelEx1.Style.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.PanelEx1.Style.BorderWidth = 2
            Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
            Me.PanelEx1.Style.GradientAngle = 90
            '
            'PanelEx5
            '
            resources.ApplyResources(Me.PanelEx5, "PanelEx5")
            Me.PanelEx5.CanvasColor = System.Drawing.Color.Transparent
            Me.PanelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelEx5.Controls.Add(Me.Slider_CamMoveSpeed)
            Me.PanelEx5.Controls.Add(Me.ButtonX5)
            Me.PanelEx5.Controls.Add(Me.ButtonX6)
            Me.PanelEx5.Controls.Add(Me.ButtonX7)
            Me.PanelEx5.Controls.Add(Me.ButtonX8)
            Me.PanelEx5.DisabledBackColor = System.Drawing.Color.Empty
            Me.PanelEx5.Name = "PanelEx5"
            Me.PanelEx5.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelEx5.Style.BackColor1.Color = System.Drawing.Color.Transparent
            Me.PanelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.PanelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.PanelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
            Me.PanelEx5.Style.GradientAngle = 90
            '
            'Slider_CamMoveSpeed
            '
            '
            '
            '
            Me.Slider_CamMoveSpeed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Slider_CamMoveSpeed.FocusCuesEnabled = False
            Me.Slider_CamMoveSpeed.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top
            resources.ApplyResources(Me.Slider_CamMoveSpeed, "Slider_CamMoveSpeed")
            Me.Slider_CamMoveSpeed.Maximum = 500
            Me.Slider_CamMoveSpeed.Minimum = 1
            Me.Slider_CamMoveSpeed.Name = "Slider_CamMoveSpeed"
            Me.Slider_CamMoveSpeed.Step = 5
            Me.Slider_CamMoveSpeed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Slider_CamMoveSpeed.TrackMarker = False
            Me.Slider_CamMoveSpeed.Value = 100
            '
            'ButtonX5
            '
            Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX5.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX5, "ButtonX5")
            Me.ButtonX5.Name = "ButtonX5"
            Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX6
            '
            Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX6.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX6, "ButtonX6")
            Me.ButtonX6.Name = "ButtonX6"
            Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX7
            '
            Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX7.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX7, "ButtonX7")
            Me.ButtonX7.Name = "ButtonX7"
            Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX8
            '
            Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX8.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX8, "ButtonX8")
            Me.ButtonX8.Name = "ButtonX8"
            Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'PanelEx4
            '
            resources.ApplyResources(Me.PanelEx4, "PanelEx4")
            Me.PanelEx4.CanvasColor = System.Drawing.Color.Transparent
            Me.PanelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelEx4.Controls.Add(Me.ButtonX_CamMode)
            Me.PanelEx4.Controls.Add(Me.LabelX14)
            Me.PanelEx4.DisabledBackColor = System.Drawing.Color.Empty
            Me.PanelEx4.Name = "PanelEx4"
            Me.PanelEx4.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelEx4.Style.BackColor1.Color = System.Drawing.Color.Transparent
            Me.PanelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.PanelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.PanelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
            Me.PanelEx4.Style.GradientAngle = 90
            '
            'ButtonX_CamMode
            '
            Me.ButtonX_CamMode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_CamMode.AutoExpandOnClick = True
            Me.ButtonX_CamMode.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX_CamMode.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX_CamMode, "ButtonX_CamMode")
            Me.ButtonX_CamMode.Name = "ButtonX_CamMode"
            Me.ButtonX_CamMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonX_CamMode.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ButtonItem_CamOrbit, Me.ButtonItem_CamFly, Me.LabelItem2, Me.ButtonItem_CamTop, Me.ButtonItem_CamButtom, Me.ButtonItem_CamLeft, Me.ButtonItem_CamRight, Me.ButtonItem_CamFront, Me.ButtonItem_CamBack})
            '
            'LabelItem1
            '
            Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
            Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.LabelItem1.Name = "LabelItem1"
            Me.LabelItem1.PaddingBottom = 1
            Me.LabelItem1.PaddingLeft = 10
            Me.LabelItem1.PaddingTop = 1
            Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
            resources.ApplyResources(Me.LabelItem1, "LabelItem1")
            '
            'ButtonItem_CamOrbit
            '
            Me.ButtonItem_CamOrbit.Name = "ButtonItem_CamOrbit"
            resources.ApplyResources(Me.ButtonItem_CamOrbit, "ButtonItem_CamOrbit")
            '
            'ButtonItem_CamFly
            '
            Me.ButtonItem_CamFly.Name = "ButtonItem_CamFly"
            resources.ApplyResources(Me.ButtonItem_CamFly, "ButtonItem_CamFly")
            '
            'LabelItem2
            '
            Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
            Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.LabelItem2.Name = "LabelItem2"
            Me.LabelItem2.PaddingBottom = 1
            Me.LabelItem2.PaddingLeft = 10
            Me.LabelItem2.PaddingTop = 1
            Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
            resources.ApplyResources(Me.LabelItem2, "LabelItem2")
            '
            'ButtonItem_CamTop
            '
            Me.ButtonItem_CamTop.Name = "ButtonItem_CamTop"
            resources.ApplyResources(Me.ButtonItem_CamTop, "ButtonItem_CamTop")
            '
            'ButtonItem_CamButtom
            '
            Me.ButtonItem_CamButtom.Name = "ButtonItem_CamButtom"
            resources.ApplyResources(Me.ButtonItem_CamButtom, "ButtonItem_CamButtom")
            '
            'ButtonItem_CamLeft
            '
            Me.ButtonItem_CamLeft.Name = "ButtonItem_CamLeft"
            resources.ApplyResources(Me.ButtonItem_CamLeft, "ButtonItem_CamLeft")
            '
            'ButtonItem_CamRight
            '
            Me.ButtonItem_CamRight.Name = "ButtonItem_CamRight"
            resources.ApplyResources(Me.ButtonItem_CamRight, "ButtonItem_CamRight")
            '
            'ButtonItem_CamFront
            '
            Me.ButtonItem_CamFront.Name = "ButtonItem_CamFront"
            resources.ApplyResources(Me.ButtonItem_CamFront, "ButtonItem_CamFront")
            '
            'ButtonItem_CamBack
            '
            Me.ButtonItem_CamBack.Name = "ButtonItem_CamBack"
            resources.ApplyResources(Me.ButtonItem_CamBack, "ButtonItem_CamBack")
            '
            'LabelX14
            '
            '
            '
            '
            Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            resources.ApplyResources(Me.LabelX14, "LabelX14")
            Me.LabelX14.Name = "LabelX14"
            '
            'PanelEx3
            '
            Me.PanelEx3.CanvasColor = System.Drawing.Color.Transparent
            Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelEx3.Controls.Add(Me.ButtonX_KeepOnButtom)
            Me.PanelEx3.Controls.Add(Me.ButtonX_KeepOnTop)
            Me.PanelEx3.Controls.Add(Me.ButtonX_KeepOnGround)
            Me.PanelEx3.Controls.Add(Me.ButtonX_DropToBottom)
            Me.PanelEx3.Controls.Add(Me.ButtonX_DropToTop)
            Me.PanelEx3.Controls.Add(Me.ButtonX_DropToGround)
            Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelEx3, "PanelEx3")
            Me.PanelEx3.Name = "PanelEx3"
            Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.Transparent
            Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
            Me.PanelEx3.Style.GradientAngle = 90
            '
            'ButtonX_KeepOnButtom
            '
            Me.ButtonX_KeepOnButtom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_KeepOnButtom.AutoCheckOnClick = True
            Me.ButtonX_KeepOnButtom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonX_KeepOnButtom.FocusCuesEnabled = False
            Me.ButtonX_KeepOnButtom.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_chevron_down_16px
            resources.ApplyResources(Me.ButtonX_KeepOnButtom, "ButtonX_KeepOnButtom")
            Me.ButtonX_KeepOnButtom.Name = "ButtonX_KeepOnButtom"
            Me.ButtonX_KeepOnButtom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonX_KeepOnButtom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonX_KeepOnButtom.SymbolSize = 12.0!
            '
            'ButtonX_KeepOnTop
            '
            Me.ButtonX_KeepOnTop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_KeepOnTop.AutoCheckOnClick = True
            Me.ButtonX_KeepOnTop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonX_KeepOnTop.FocusCuesEnabled = False
            Me.ButtonX_KeepOnTop.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_chevron_up_16px
            resources.ApplyResources(Me.ButtonX_KeepOnTop, "ButtonX_KeepOnTop")
            Me.ButtonX_KeepOnTop.Name = "ButtonX_KeepOnTop"
            Me.ButtonX_KeepOnTop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonX_KeepOnTop.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonX_KeepOnTop.SymbolSize = 12.0!
            '
            'ButtonX_KeepOnGround
            '
            Me.ButtonX_KeepOnGround.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_KeepOnGround.AutoCheckOnClick = True
            Me.ButtonX_KeepOnGround.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonX_KeepOnGround.FocusCuesEnabled = False
            Me.ButtonX_KeepOnGround.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_merge_horizontal_16px
            resources.ApplyResources(Me.ButtonX_KeepOnGround, "ButtonX_KeepOnGround")
            Me.ButtonX_KeepOnGround.Name = "ButtonX_KeepOnGround"
            Me.ButtonX_KeepOnGround.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonX_KeepOnGround.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonX_KeepOnGround.SymbolSize = 12.0!
            '
            'ButtonX_DropToBottom
            '
            Me.ButtonX_DropToBottom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_DropToBottom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonX_DropToBottom.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX_DropToBottom, "ButtonX_DropToBottom")
            Me.ButtonX_DropToBottom.Name = "ButtonX_DropToBottom"
            Me.ButtonX_DropToBottom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX_DropToTop
            '
            Me.ButtonX_DropToTop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_DropToTop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonX_DropToTop.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX_DropToTop, "ButtonX_DropToTop")
            Me.ButtonX_DropToTop.Name = "ButtonX_DropToTop"
            Me.ButtonX_DropToTop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX_DropToGround
            '
            Me.ButtonX_DropToGround.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX_DropToGround.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonX_DropToGround.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX_DropToGround, "ButtonX_DropToGround")
            Me.ButtonX_DropToGround.Name = "ButtonX_DropToGround"
            Me.ButtonX_DropToGround.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'PanelEx2
            '
            Me.PanelEx2.CanvasColor = System.Drawing.Color.Transparent
            Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelEx2.Controls.Add(Me.Slider_ObjMoveSpeed)
            Me.PanelEx2.Controls.Add(Me.ButtonX1)
            Me.PanelEx2.Controls.Add(Me.ButtonX2)
            Me.PanelEx2.Controls.Add(Me.ButtonX4)
            Me.PanelEx2.Controls.Add(Me.ButtonX3)
            Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelEx2, "PanelEx2")
            Me.PanelEx2.Name = "PanelEx2"
            Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.Transparent
            Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
            Me.PanelEx2.Style.GradientAngle = 90
            '
            'Slider_ObjMoveSpeed
            '
            '
            '
            '
            Me.Slider_ObjMoveSpeed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Slider_ObjMoveSpeed.FocusCuesEnabled = False
            Me.Slider_ObjMoveSpeed.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top
            resources.ApplyResources(Me.Slider_ObjMoveSpeed, "Slider_ObjMoveSpeed")
            Me.Slider_ObjMoveSpeed.Maximum = 500
            Me.Slider_ObjMoveSpeed.Minimum = 1
            Me.Slider_ObjMoveSpeed.Name = "Slider_ObjMoveSpeed"
            Me.Slider_ObjMoveSpeed.Step = 5
            Me.Slider_ObjMoveSpeed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Slider_ObjMoveSpeed.TrackMarker = False
            Me.Slider_ObjMoveSpeed.Value = 100
            '
            'ButtonX1
            '
            Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX1.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX1, "ButtonX1")
            Me.ButtonX1.Name = "ButtonX1"
            Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX2
            '
            Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX2.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX2, "ButtonX2")
            Me.ButtonX2.Name = "ButtonX2"
            Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX4
            '
            Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX4.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX4, "ButtonX4")
            Me.ButtonX4.Name = "ButtonX4"
            Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'ButtonX3
            '
            Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
            Me.ButtonX3.FocusCuesEnabled = False
            resources.ApplyResources(Me.ButtonX3, "ButtonX3")
            Me.ButtonX3.Name = "ButtonX3"
            Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            'PictureBox_CamCntrWheel
            '
            resources.ApplyResources(Me.PictureBox_CamCntrWheel, "PictureBox_CamCntrWheel")
            Me.PictureBox_CamCntrWheel.Image = Global.SM64_ROM_Manager.My.Resources.Resources.MoveCameraWheel
            Me.PictureBox_CamCntrWheel.Name = "PictureBox_CamCntrWheel"
            Me.PictureBox_CamCntrWheel.TabStop = False
            '
            'PictureBox_CamMoveCross
            '
            resources.ApplyResources(Me.PictureBox_CamMoveCross, "PictureBox_CamMoveCross")
            Me.PictureBox_CamMoveCross.Image = Global.SM64_ROM_Manager.My.Resources.Resources.MoveCameraCross
            Me.PictureBox_CamMoveCross.Name = "PictureBox_CamMoveCross"
            Me.PictureBox_CamMoveCross.TabStop = False
            '
            'PictureBox_ObjRotWheel
            '
            Me.PictureBox_ObjRotWheel.Image = Global.SM64_ROM_Manager.My.Resources.Resources.RotateObjectWheel
            resources.ApplyResources(Me.PictureBox_ObjRotWheel, "PictureBox_ObjRotWheel")
            Me.PictureBox_ObjRotWheel.Name = "PictureBox_ObjRotWheel"
            Me.PictureBox_ObjRotWheel.TabStop = False
            '
            'PictureBox_ObjRotCross
            '
            Me.PictureBox_ObjRotCross.Image = Global.SM64_ROM_Manager.My.Resources.Resources.RotateObjectCross
            resources.ApplyResources(Me.PictureBox_ObjRotCross, "PictureBox_ObjRotCross")
            Me.PictureBox_ObjRotCross.Name = "PictureBox_ObjRotCross"
            Me.PictureBox_ObjRotCross.TabStop = False
            '
            'PictureBox_ObjCntrWheel
            '
            Me.PictureBox_ObjCntrWheel.Image = Global.SM64_ROM_Manager.My.Resources.Resources.MoveObjectWheel
            resources.ApplyResources(Me.PictureBox_ObjCntrWheel, "PictureBox_ObjCntrWheel")
            Me.PictureBox_ObjCntrWheel.Name = "PictureBox_ObjCntrWheel"
            Me.PictureBox_ObjCntrWheel.TabStop = False
            '
            'PictureBox_ObjCntrCross
            '
            Me.PictureBox_ObjCntrCross.Image = Global.SM64_ROM_Manager.My.Resources.Resources.MoveObjectCross
            resources.ApplyResources(Me.PictureBox_ObjCntrCross, "PictureBox_ObjCntrCross")
            Me.PictureBox_ObjCntrCross.Name = "PictureBox_ObjCntrCross"
            Me.PictureBox_ObjCntrCross.TabStop = False
            '
            'DockContainerItem2
            '
            Me.DockContainerItem2.Control = Me.PanelDockContainer2
            Me.DockContainerItem2.DefaultFloatingSize = New System.Drawing.Size(976, 132)
            Me.DockContainerItem2.Name = "DockContainerItem2"
            resources.ApplyResources(Me.DockContainerItem2, "DockContainerItem2")
            '
            'DockSite9
            '
            Me.DockSite9.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            Me.DockSite9.Controls.Add(Me.Bar_AreaViewer)
            resources.ApplyResources(Me.DockSite9, "DockSite9")
            Me.DockSite9.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar_AreaViewer, 967, 685), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Horizontal)
            Me.DockSite9.Name = "DockSite9"
            Me.DockSite9.TabStop = False
            '
            'Bar_AreaViewer
            '
            resources.ApplyResources(Me.Bar_AreaViewer, "Bar_AreaViewer")
            Me.Bar_AreaViewer.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
            Me.Bar_AreaViewer.AutoCreateCaptionMenu = False
            Me.Bar_AreaViewer.CanAutoHide = False
            Me.Bar_AreaViewer.CanCustomize = False
            Me.Bar_AreaViewer.CanDockBottom = False
            Me.Bar_AreaViewer.CanDockDocument = True
            Me.Bar_AreaViewer.CanDockLeft = False
            Me.Bar_AreaViewer.CanDockRight = False
            Me.Bar_AreaViewer.CanDockTab = False
            Me.Bar_AreaViewer.CanDockTop = False
            Me.Bar_AreaViewer.CanMaximizeFloating = False
            Me.Bar_AreaViewer.CanMove = False
            Me.Bar_AreaViewer.CanReorderTabs = False
            Me.Bar_AreaViewer.CanUndock = False
            Me.Bar_AreaViewer.Controls.Add(Me.PanelDockContainer3)
            Me.Bar_AreaViewer.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
            Me.Bar_AreaViewer.HideFloatingInactive = False
            Me.Bar_AreaViewer.IsMaximized = False
            Me.Bar_AreaViewer.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem3})
            Me.Bar_AreaViewer.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
            Me.Bar_AreaViewer.Name = "Bar_AreaViewer"
            Me.Bar_AreaViewer.Stretch = True
            Me.Bar_AreaViewer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Bar_AreaViewer.TabNavigation = True
            Me.Bar_AreaViewer.TabStop = False
            '
            'PanelDockContainer3
            '
            Me.PanelDockContainer3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelDockContainer3.Controls.Add(Me.Panel_GLControl)
            Me.PanelDockContainer3.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelDockContainer3, "PanelDockContainer3")
            Me.PanelDockContainer3.Name = "PanelDockContainer3"
            Me.PanelDockContainer3.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelDockContainer3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.PanelDockContainer3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelDockContainer3.Style.GradientAngle = 90
            '
            'DockContainerItem3
            '
            Me.DockContainerItem3.Control = Me.PanelDockContainer3
            Me.DockContainerItem3.Name = "DockContainerItem3"
            resources.ApplyResources(Me.DockContainerItem3, "DockContainerItem3")
            '
            'DockSite1
            '
            Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            Me.DockSite1.Controls.Add(Me.Bar1)
            Me.DockSite1.Controls.Add(Me.Bar2)
            resources.ApplyResources(Me.DockSite1, "DockSite1")
            Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar2, 271, 275), DevComponents.DotNetBar.DocumentBaseContainer), CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar1, 271, 542), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Vertical)
            Me.DockSite1.Name = "DockSite1"
            Me.DockSite1.TabStop = False
            '
            'Bar1
            '
            resources.ApplyResources(Me.Bar1, "Bar1")
            Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
            Me.Bar1.AutoSyncBarCaption = True
            Me.Bar1.CloseSingleTab = True
            Me.Bar1.Controls.Add(Me.PanelDockContainer10)
            Me.Bar1.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
            Me.Bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
            Me.Bar1.HideFloatingInactive = False
            Me.Bar1.IsMaximized = False
            Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem7})
            Me.Bar1.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
            Me.Bar1.Name = "Bar1"
            Me.Bar1.Stretch = True
            Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Bar1.TabStop = False
            '
            'PanelDockContainer10
            '
            Me.PanelDockContainer10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelDockContainer10.Controls.Add(Me.AdvPropertyGrid1)
            Me.PanelDockContainer10.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelDockContainer10, "PanelDockContainer10")
            Me.PanelDockContainer10.Name = "PanelDockContainer10"
            Me.PanelDockContainer10.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelDockContainer10.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.PanelDockContainer10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelDockContainer10.Style.GradientAngle = 90
            '
            'AdvPropertyGrid1
            '
            resources.ApplyResources(Me.AdvPropertyGrid1, "AdvPropertyGrid1")
            Me.AdvPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke
            Me.AdvPropertyGrid1.Name = "AdvPropertyGrid1"
            '
            'DockContainerItem7
            '
            Me.DockContainerItem7.Control = Me.PanelDockContainer10
            Me.DockContainerItem7.Name = "DockContainerItem7"
            resources.ApplyResources(Me.DockContainerItem7, "DockContainerItem7")
            '
            'Bar2
            '
            resources.ApplyResources(Me.Bar2, "Bar2")
            Me.Bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
            Me.Bar2.AutoSyncBarCaption = True
            Me.Bar2.CloseSingleTab = True
            Me.Bar2.Controls.Add(Me.PanelDockContainer7)
            Me.Bar2.Controls.Add(Me.PanelDockContainer1)
            Me.Bar2.Controls.Add(Me.PanelDockContainer8)
            Me.Bar2.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
            Me.Bar2.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
            Me.Bar2.HideFloatingInactive = False
            Me.Bar2.IsMaximized = False
            Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem4, Me.DockContainerItem1, Me.DockContainerItem5})
            Me.Bar2.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
            Me.Bar2.Name = "Bar2"
            Me.Bar2.SelectedDockTab = 0
            Me.Bar2.Stretch = True
            Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Bar2.TabStop = False
            '
            'PanelDockContainer7
            '
            Me.PanelDockContainer7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelDockContainer7.Controls.Add(Me.Panel1)
            Me.PanelDockContainer7.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelDockContainer7, "PanelDockContainer7")
            Me.PanelDockContainer7.Name = "PanelDockContainer7"
            Me.PanelDockContainer7.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelDockContainer7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.PanelDockContainer7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelDockContainer7.Style.GradientAngle = 90
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Transparent
            Me.Panel1.Controls.Add(Me.ListViewEx_Objects)
            resources.ApplyResources(Me.Panel1, "Panel1")
            Me.Panel1.Name = "Panel1"
            '
            'PanelDockContainer1
            '
            Me.PanelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelDockContainer1.Controls.Add(Me.Panel2)
            Me.PanelDockContainer1.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelDockContainer1, "PanelDockContainer1")
            Me.PanelDockContainer1.Name = "PanelDockContainer1"
            Me.PanelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.PanelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelDockContainer1.Style.GradientAngle = 90
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Transparent
            Me.Panel2.Controls.Add(Me.ListViewEx_Warps)
            resources.ApplyResources(Me.Panel2, "Panel2")
            Me.Panel2.Name = "Panel2"
            '
            'PanelDockContainer8
            '
            Me.PanelDockContainer8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.PanelDockContainer8.Controls.Add(Me.TabControl1)
            Me.PanelDockContainer8.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.PanelDockContainer8, "PanelDockContainer8")
            Me.PanelDockContainer8.Name = "PanelDockContainer8"
            Me.PanelDockContainer8.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.PanelDockContainer8.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.PanelDockContainer8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.PanelDockContainer8.Style.GradientAngle = 90
            '
            'TabControl1
            '
            Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControl1.CanReorderTabs = True
            Me.TabControl1.Controls.Add(Me.TabControlPanel1)
            Me.TabControl1.Controls.Add(Me.TabControlPanel3)
            Me.TabControl1.Controls.Add(Me.TabControlPanel2)
            resources.ApplyResources(Me.TabControl1, "TabControl1")
            Me.TabControl1.ForeColor = System.Drawing.Color.Black
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControl1.SelectedTabIndex = 0
            Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControl1.Tabs.Add(Me.TabItem1)
            Me.TabControl1.Tabs.Add(Me.TabItem2)
            Me.TabControl1.Tabs.Add(Me.TabItem3)
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.ListViewEx_CollVertices)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.TabControlPanel1, "TabControlPanel1")
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabItem = Me.TabItem1
            '
            'ListViewEx_CollVertices
            '
            resources.ApplyResources(Me.ListViewEx_CollVertices, "ListViewEx_CollVertices")
            Me.ListViewEx_CollVertices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.ListViewEx_CollVertices.Border.Class = "ListViewBorder"
            Me.ListViewEx_CollVertices.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ListViewEx_CollVertices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader11, Me.ColumnHeader12})
            Me.ListViewEx_CollVertices.DisabledBackColor = System.Drawing.Color.Empty
            Me.ListViewEx_CollVertices.FocusCuesEnabled = False
            Me.ListViewEx_CollVertices.ForeColor = System.Drawing.Color.Black
            Me.ListViewEx_CollVertices.FullRowSelect = True
            Me.ListViewEx_CollVertices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.ListViewEx_CollVertices.HideSelection = False
            Me.ListViewEx_CollVertices.Name = "ListViewEx_CollVertices"
            Me.ListViewEx_CollVertices.UseCompatibleStateImageBehavior = False
            Me.ListViewEx_CollVertices.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader7
            '
            resources.ApplyResources(Me.ColumnHeader7, "ColumnHeader7")
            '
            'ColumnHeader8
            '
            resources.ApplyResources(Me.ColumnHeader8, "ColumnHeader8")
            '
            'ColumnHeader11
            '
            resources.ApplyResources(Me.ColumnHeader11, "ColumnHeader11")
            '
            'ColumnHeader12
            '
            resources.ApplyResources(Me.ColumnHeader12, "ColumnHeader12")
            '
            'TabItem1
            '
            Me.TabItem1.AttachedControl = Me.TabControlPanel1
            Me.TabItem1.Name = "TabItem1"
            resources.ApplyResources(Me.TabItem1, "TabItem1")
            '
            'TabControlPanel3
            '
            Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.TabControlPanel3, "TabControlPanel3")
            Me.TabControlPanel3.Name = "TabControlPanel3"
            Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel3.Style.GradientAngle = 90
            Me.TabControlPanel3.TabItem = Me.TabItem3
            '
            'TabItem3
            '
            Me.TabItem3.AttachedControl = Me.TabControlPanel3
            Me.TabItem3.Name = "TabItem3"
            resources.ApplyResources(Me.TabItem3, "TabItem3")
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.ListViewEx_ColFaces)
            Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.TabControlPanel2, "TabControlPanel2")
            Me.TabControlPanel2.Name = "TabControlPanel2"
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabItem = Me.TabItem2
            '
            'ListViewEx_ColFaces
            '
            resources.ApplyResources(Me.ListViewEx_ColFaces, "ListViewEx_ColFaces")
            Me.ListViewEx_ColFaces.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.ListViewEx_ColFaces.Border.Class = "ListViewBorder"
            Me.ListViewEx_ColFaces.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ListViewEx_ColFaces.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15})
            Me.ListViewEx_ColFaces.DisabledBackColor = System.Drawing.Color.Empty
            Me.ListViewEx_ColFaces.FocusCuesEnabled = False
            Me.ListViewEx_ColFaces.ForeColor = System.Drawing.Color.Black
            Me.ListViewEx_ColFaces.FullRowSelect = True
            Me.ListViewEx_ColFaces.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.ListViewEx_ColFaces.HideSelection = False
            Me.ListViewEx_ColFaces.Name = "ListViewEx_ColFaces"
            Me.ListViewEx_ColFaces.UseCompatibleStateImageBehavior = False
            Me.ListViewEx_ColFaces.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader9
            '
            resources.ApplyResources(Me.ColumnHeader9, "ColumnHeader9")
            '
            'ColumnHeader10
            '
            resources.ApplyResources(Me.ColumnHeader10, "ColumnHeader10")
            '
            'ColumnHeader13
            '
            resources.ApplyResources(Me.ColumnHeader13, "ColumnHeader13")
            '
            'ColumnHeader14
            '
            resources.ApplyResources(Me.ColumnHeader14, "ColumnHeader14")
            '
            'ColumnHeader15
            '
            resources.ApplyResources(Me.ColumnHeader15, "ColumnHeader15")
            '
            'TabItem2
            '
            Me.TabItem2.AttachedControl = Me.TabControlPanel2
            Me.TabItem2.Name = "TabItem2"
            resources.ApplyResources(Me.TabItem2, "TabItem2")
            '
            'DockContainerItem4
            '
            Me.DockContainerItem4.Control = Me.PanelDockContainer7
            Me.DockContainerItem4.DefaultFloatingSize = New System.Drawing.Size(275, 250)
            Me.DockContainerItem4.Name = "DockContainerItem4"
            resources.ApplyResources(Me.DockContainerItem4, "DockContainerItem4")
            '
            'DockContainerItem1
            '
            Me.DockContainerItem1.Control = Me.PanelDockContainer1
            Me.DockContainerItem1.DefaultFloatingSize = New System.Drawing.Size(275, 250)
            Me.DockContainerItem1.Name = "DockContainerItem1"
            resources.ApplyResources(Me.DockContainerItem1, "DockContainerItem1")
            '
            'DockContainerItem5
            '
            Me.DockContainerItem5.Control = Me.PanelDockContainer8
            Me.DockContainerItem5.Name = "DockContainerItem5"
            resources.ApplyResources(Me.DockContainerItem5, "DockContainerItem5")
            '
            'DockSite2
            '
            Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            resources.ApplyResources(Me.DockSite2, "DockSite2")
            Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
            Me.DockSite2.Name = "DockSite2"
            Me.DockSite2.TabStop = False
            '
            'DockSite8
            '
            Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            resources.ApplyResources(Me.DockSite8, "DockSite8")
            Me.DockSite8.Name = "DockSite8"
            Me.DockSite8.TabStop = False
            '
            'DockSite5
            '
            Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            resources.ApplyResources(Me.DockSite5, "DockSite5")
            Me.DockSite5.Name = "DockSite5"
            Me.DockSite5.TabStop = False
            '
            'DockSite6
            '
            Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            resources.ApplyResources(Me.DockSite6, "DockSite6")
            Me.DockSite6.Name = "DockSite6"
            Me.DockSite6.TabStop = False
            '
            'DockSite3
            '
            Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
            resources.ApplyResources(Me.DockSite3, "DockSite3")
            Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
            Me.DockSite3.Name = "DockSite3"
            Me.DockSite3.TabStop = False
            '
            'DockContainerItem6
            '
            Me.DockContainerItem6.DefaultFloatingSize = New System.Drawing.Size(285, 205)
            Me.DockContainerItem6.Name = "DockContainerItem6"
            resources.ApplyResources(Me.DockContainerItem6, "DockContainerItem6")
            '
            'SuperTooltip1
            '
            resources.ApplyResources(Me.SuperTooltip1, "SuperTooltip1")
            Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.SuperTooltip1.MinimumTooltipSize = New System.Drawing.Size(250, 24)
            '
            'RibbonBar3
            '
            Me.RibbonBar3.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar3.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar3, "RibbonBar3")
            Me.RibbonBar3.DragDropSupport = True
            Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_PasteObjDefault, Me.ItemContainer7})
            Me.RibbonBar3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar3.Name = "RibbonBar3"
            Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.SuperTooltip1.SetSuperTooltip(Me.RibbonBar3, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("RibbonBar3.SuperTooltip"), resources.GetString("RibbonBar3.SuperTooltip1"), resources.GetString("RibbonBar3.SuperTooltip2"), CType(resources.GetObject("RibbonBar3.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("RibbonBar3.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("RibbonBar3.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            '
            '
            '
            Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_PasteObjDefault
            '
            Me.ButtonItem_PasteObjDefault.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_paste_32px
            Me.ButtonItem_PasteObjDefault.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItem_PasteObjDefault.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem_PasteObjDefault.Name = "ButtonItem_PasteObjDefault"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem_PasteObjDefault, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem_PasteObjDefault.SuperTooltip"), resources.GetString("ButtonItem_PasteObjDefault.SuperTooltip1"), resources.GetString("ButtonItem_PasteObjDefault.SuperTooltip2"), CType(resources.GetObject("ButtonItem_PasteObjDefault.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_PasteObjDefault.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_PasteObjDefault.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            Me.ButtonItem_PasteObjDefault.SymbolSize = 32.0!
            resources.ApplyResources(Me.ButtonItem_PasteObjDefault, "ButtonItem_PasteObjDefault")
            '
            'ItemContainer7
            '
            '
            '
            '
            Me.ItemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer7.ItemSpacing = 0
            Me.ItemContainer7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer7.Name = "ItemContainer7"
            Me.ItemContainer7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ObjectsCopy, Me.buttonItem55, Me.ButtonItem44})
            '
            '
            '
            Me.ItemContainer7.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_ObjectsCopy
            '
            Me.ButtonItem_ObjectsCopy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_ObjectsCopy.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
            Me.ButtonItem_ObjectsCopy.Name = "ButtonItem_ObjectsCopy"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem_ObjectsCopy, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem_ObjectsCopy.SuperTooltip"), resources.GetString("ButtonItem_ObjectsCopy.SuperTooltip1"), resources.GetString("ButtonItem_ObjectsCopy.SuperTooltip2"), CType(resources.GetObject("ButtonItem_ObjectsCopy.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_ObjectsCopy.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_ObjectsCopy.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            resources.ApplyResources(Me.ButtonItem_ObjectsCopy, "ButtonItem_ObjectsCopy")
            '
            'buttonItem55
            '
            Me.buttonItem55.AutoExpandOnClick = True
            Me.buttonItem55.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.buttonItem55.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_paste_special_16px
            Me.buttonItem55.Name = "buttonItem55"
            Me.buttonItem55.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_PasteObjCombo, Me.ButtonItem_PasteObjModelID, Me.ButtonItem_PasteObjBehavID, Me.ButtonItem_PasteObjBParams, Me.ButtonItem_PasteObjActs, Me.ButtonItem_PasteObjPos, Me.ButtonItem_PasteObjRot})
            Me.SuperTooltip1.SetSuperTooltip(Me.buttonItem55, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("buttonItem55.SuperTooltip"), resources.GetString("buttonItem55.SuperTooltip1"), resources.GetString("buttonItem55.SuperTooltip2"), CType(resources.GetObject("buttonItem55.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("buttonItem55.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("buttonItem55.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            resources.ApplyResources(Me.buttonItem55, "buttonItem55")
            '
            'ButtonItem_PasteObjCombo
            '
            Me.ButtonItem_PasteObjCombo.Name = "ButtonItem_PasteObjCombo"
            resources.ApplyResources(Me.ButtonItem_PasteObjCombo, "ButtonItem_PasteObjCombo")
            '
            'ButtonItem_PasteObjModelID
            '
            Me.ButtonItem_PasteObjModelID.Name = "ButtonItem_PasteObjModelID"
            resources.ApplyResources(Me.ButtonItem_PasteObjModelID, "ButtonItem_PasteObjModelID")
            '
            'ButtonItem_PasteObjBehavID
            '
            Me.ButtonItem_PasteObjBehavID.Name = "ButtonItem_PasteObjBehavID"
            resources.ApplyResources(Me.ButtonItem_PasteObjBehavID, "ButtonItem_PasteObjBehavID")
            '
            'ButtonItem_PasteObjBParams
            '
            Me.ButtonItem_PasteObjBParams.Name = "ButtonItem_PasteObjBParams"
            resources.ApplyResources(Me.ButtonItem_PasteObjBParams, "ButtonItem_PasteObjBParams")
            '
            'ButtonItem_PasteObjActs
            '
            Me.ButtonItem_PasteObjActs.Name = "ButtonItem_PasteObjActs"
            resources.ApplyResources(Me.ButtonItem_PasteObjActs, "ButtonItem_PasteObjActs")
            '
            'ButtonItem_PasteObjPos
            '
            Me.ButtonItem_PasteObjPos.Name = "ButtonItem_PasteObjPos"
            resources.ApplyResources(Me.ButtonItem_PasteObjPos, "ButtonItem_PasteObjPos")
            '
            'ButtonItem_PasteObjRot
            '
            Me.ButtonItem_PasteObjRot.Name = "ButtonItem_PasteObjRot"
            resources.ApplyResources(Me.ButtonItem_PasteObjRot, "ButtonItem_PasteObjRot")
            '
            'ButtonItem44
            '
            Me.ButtonItem44.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem44.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_2_16px
            Me.ButtonItem44.Name = "ButtonItem44"
            Me.ButtonItem44.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem44.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem44, "ButtonItem44")
            '
            'RibbonBar11
            '
            Me.RibbonBar11.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar11.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar11.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar11, "RibbonBar11")
            Me.RibbonBar11.DragDropSupport = True
            Me.RibbonBar11.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonX_PasteWarpDefault, Me.ItemContainer12})
            Me.RibbonBar11.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar11.Name = "RibbonBar11"
            Me.RibbonBar11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.SuperTooltip1.SetSuperTooltip(Me.RibbonBar11, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("RibbonBar11.SuperTooltip"), resources.GetString("RibbonBar11.SuperTooltip1"), resources.GetString("RibbonBar11.SuperTooltip2"), CType(resources.GetObject("RibbonBar11.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("RibbonBar11.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("RibbonBar11.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            '
            '
            '
            Me.RibbonBar11.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar11.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonX_PasteWarpDefault
            '
            Me.ButtonX_PasteWarpDefault.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_paste_32px
            Me.ButtonX_PasteWarpDefault.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonX_PasteWarpDefault.Name = "ButtonX_PasteWarpDefault"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX_PasteWarpDefault, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonX_PasteWarpDefault.SuperTooltip"), resources.GetString("ButtonX_PasteWarpDefault.SuperTooltip1"), resources.GetString("ButtonX_PasteWarpDefault.SuperTooltip2"), CType(resources.GetObject("ButtonX_PasteWarpDefault.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonX_PasteWarpDefault.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonX_PasteWarpDefault.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            Me.ButtonX_PasteWarpDefault.SymbolSize = 32.0!
            resources.ApplyResources(Me.ButtonX_PasteWarpDefault, "ButtonX_PasteWarpDefault")
            '
            'ItemContainer12
            '
            '
            '
            '
            Me.ItemContainer12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer12.ItemSpacing = 0
            Me.ItemContainer12.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer12.Name = "ItemContainer12"
            Me.ItemContainer12.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonX_WarpsCopy, Me.ButtonItem73, Me.ButtonItem81})
            '
            '
            '
            Me.ItemContainer12.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer12.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonX_WarpsCopy
            '
            Me.ButtonX_WarpsCopy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonX_WarpsCopy.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
            Me.ButtonX_WarpsCopy.Name = "ButtonX_WarpsCopy"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX_WarpsCopy, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonX_WarpsCopy.SuperTooltip"), resources.GetString("ButtonX_WarpsCopy.SuperTooltip1"), resources.GetString("ButtonX_WarpsCopy.SuperTooltip2"), CType(resources.GetObject("ButtonX_WarpsCopy.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonX_WarpsCopy.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonX_WarpsCopy.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            resources.ApplyResources(Me.ButtonX_WarpsCopy, "ButtonX_WarpsCopy")
            '
            'ButtonItem73
            '
            Me.ButtonItem73.AutoExpandOnClick = True
            Me.ButtonItem73.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem73.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_paste_special_16px
            Me.ButtonItem73.Name = "ButtonItem73"
            Me.ButtonItem73.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_PasteWarpDestLevel, Me.ButtonItem_PasteWarpDestArea, Me.ButtonItem_PasteWarpDestWarp})
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem73, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem73.SuperTooltip"), resources.GetString("ButtonItem73.SuperTooltip1"), resources.GetString("ButtonItem73.SuperTooltip2"), CType(resources.GetObject("ButtonItem73.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem73.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem73.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            resources.ApplyResources(Me.ButtonItem73, "ButtonItem73")
            '
            'ButtonItem_PasteWarpDestLevel
            '
            Me.ButtonItem_PasteWarpDestLevel.Name = "ButtonItem_PasteWarpDestLevel"
            resources.ApplyResources(Me.ButtonItem_PasteWarpDestLevel, "ButtonItem_PasteWarpDestLevel")
            '
            'ButtonItem_PasteWarpDestArea
            '
            Me.ButtonItem_PasteWarpDestArea.Name = "ButtonItem_PasteWarpDestArea"
            resources.ApplyResources(Me.ButtonItem_PasteWarpDestArea, "ButtonItem_PasteWarpDestArea")
            '
            'ButtonItem_PasteWarpDestWarp
            '
            Me.ButtonItem_PasteWarpDestWarp.Name = "ButtonItem_PasteWarpDestWarp"
            resources.ApplyResources(Me.ButtonItem_PasteWarpDestWarp, "ButtonItem_PasteWarpDestWarp")
            '
            'ButtonItem81
            '
            Me.ButtonItem81.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem81.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_2_16px
            Me.ButtonItem81.Name = "ButtonItem81"
            Me.ButtonItem81.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem81.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem81, "ButtonItem81")
            '
            'ButtonItem5
            '
            Me.ButtonItem5.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_paste_16px
            Me.ButtonItem5.Name = "ButtonItem5"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem5, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem5.SuperTooltip"), resources.GetString("ButtonItem5.SuperTooltip1"), resources.GetString("ButtonItem5.SuperTooltip2"), CType(resources.GetObject("ButtonItem5.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem5.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem5.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("ButtonItem5.SuperTooltip6"), Boolean), CType(resources.GetObject("ButtonItem5.SuperTooltip7"), Boolean), CType(resources.GetObject("ButtonItem5.SuperTooltip8"), System.Drawing.Size)))
            Me.ButtonItem5.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem5.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem5, "ButtonItem5")
            '
            'ButtonItem37
            '
            Me.ButtonItem37.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_paste_16px
            Me.ButtonItem37.Name = "ButtonItem37"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem37, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem37.SuperTooltip"), resources.GetString("ButtonItem37.SuperTooltip1"), resources.GetString("ButtonItem37.SuperTooltip2"), CType(resources.GetObject("ButtonItem37.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem37.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem37.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("ButtonItem37.SuperTooltip6"), Boolean), CType(resources.GetObject("ButtonItem37.SuperTooltip7"), Boolean), CType(resources.GetObject("ButtonItem37.SuperTooltip8"), System.Drawing.Size)))
            Me.ButtonItem37.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem37.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem37, "ButtonItem37")
            '
            'ButtonItem_CopyObjCmdAsHex
            '
            Me.ButtonItem_CopyObjCmdAsHex.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_CopyObjCmdAsHex.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
            Me.ButtonItem_CopyObjCmdAsHex.Name = "ButtonItem_CopyObjCmdAsHex"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem_CopyObjCmdAsHex, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem_CopyObjCmdAsHex.SuperTooltip"), resources.GetString("ButtonItem_CopyObjCmdAsHex.SuperTooltip1"), resources.GetString("ButtonItem_CopyObjCmdAsHex.SuperTooltip2"), CType(resources.GetObject("ButtonItem_CopyObjCmdAsHex.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_CopyObjCmdAsHex.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_CopyObjCmdAsHex.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            resources.ApplyResources(Me.ButtonItem_CopyObjCmdAsHex, "ButtonItem_CopyObjCmdAsHex")
            '
            'ButtonItem_CopyWarpCmdAsHex
            '
            Me.ButtonItem_CopyWarpCmdAsHex.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_CopyWarpCmdAsHex.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
            Me.ButtonItem_CopyWarpCmdAsHex.Name = "ButtonItem_CopyWarpCmdAsHex"
            Me.SuperTooltip1.SetSuperTooltip(Me.ButtonItem_CopyWarpCmdAsHex, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ButtonItem_CopyWarpCmdAsHex.SuperTooltip"), resources.GetString("ButtonItem_CopyWarpCmdAsHex.SuperTooltip1"), resources.GetString("ButtonItem_CopyWarpCmdAsHex.SuperTooltip2"), CType(resources.GetObject("ButtonItem_CopyWarpCmdAsHex.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_CopyWarpCmdAsHex.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ButtonItem_CopyWarpCmdAsHex.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor)))
            resources.ApplyResources(Me.ButtonItem_CopyWarpCmdAsHex, "ButtonItem_CopyWarpCmdAsHex")
            '
            'ContextMenuBar1
            '
            Me.ContextMenuBar1.AntiAlias = True
            resources.ApplyResources(Me.ContextMenuBar1, "ContextMenuBar1")
            Me.ContextMenuBar1.IsMaximized = False
            Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_CM_Objects, Me.ButtonItem1_CM_Warps, Me.ButtonItem22})
            Me.ContextMenuBar1.Name = "ContextMenuBar1"
            Me.ContextMenuBar1.Stretch = True
            Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ContextMenuBar1.TabStop = False
            '
            'ButtonItem_CM_Objects
            '
            Me.ButtonItem_CM_Objects.AutoExpandOnClick = True
            Me.ButtonItem_CM_Objects.Name = "ButtonItem_CM_Objects"
            Me.ButtonItem_CM_Objects.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem9, Me.ButtonItem37, Me.ButtonItem63, Me.ButtonItem_ChangeObjectCombo, Me.ButtonItem30, Me.ButtonItem33, Me.ButtonItem64, Me.ButtonItem65, Me.ButtonItem68})
            resources.ApplyResources(Me.ButtonItem_CM_Objects, "ButtonItem_CM_Objects")
            '
            'ButtonItem9
            '
            Me.ButtonItem9.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
            Me.ButtonItem9.Name = "ButtonItem9"
            Me.ButtonItem9.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem9.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem9, "ButtonItem9")
            '
            'ButtonItem63
            '
            Me.ButtonItem63.BeginGroup = True
            Me.ButtonItem63.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
            Me.ButtonItem63.Name = "ButtonItem63"
            Me.ButtonItem63.SymbolColor = System.Drawing.Color.Goldenrod
            Me.ButtonItem63.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem63, "ButtonItem63")
            Me.ButtonItem63.Visible = False
            '
            'ButtonItem_ChangeObjectCombo
            '
            Me.ButtonItem_ChangeObjectCombo.BeginGroup = True
            Me.ButtonItem_ChangeObjectCombo.Image = Global.SM64_ROM_Manager.My.Resources.MyOldIcons.Shrink_16px1
            Me.ButtonItem_ChangeObjectCombo.Name = "ButtonItem_ChangeObjectCombo"
            resources.ApplyResources(Me.ButtonItem_ChangeObjectCombo, "ButtonItem_ChangeObjectCombo")
            '
            'ButtonItem30
            '
            Me.ButtonItem30.Image = Global.SM64_ROM_Manager.My.Resources.MyOldIcons.Psychology_16px
            Me.ButtonItem30.Name = "ButtonItem30"
            resources.ApplyResources(Me.ButtonItem30, "ButtonItem30")
            '
            'ButtonItem33
            '
            Me.ButtonItem33.Name = "ButtonItem33"
            resources.ApplyResources(Me.ButtonItem33, "ButtonItem33")
            '
            'ButtonItem64
            '
            Me.ButtonItem64.BeginGroup = True
            Me.ButtonItem64.GlobalItem = False
            Me.ButtonItem64.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_undo_16px
            Me.ButtonItem64.Name = "ButtonItem64"
            Me.ButtonItem64.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem64, "ButtonItem64")
            '
            'ButtonItem65
            '
            Me.ButtonItem65.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
            Me.ButtonItem65.Name = "ButtonItem65"
            Me.ButtonItem65.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem65.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem65, "ButtonItem65")
            '
            'ButtonItem68
            '
            Me.ButtonItem68.BeginGroup = True
            Me.ButtonItem68.GlobalItem = False
            Me.ButtonItem68.Name = "ButtonItem68"
            Me.ButtonItem68.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem68, "ButtonItem68")
            '
            'ButtonItem1_CM_Warps
            '
            Me.ButtonItem1_CM_Warps.AutoExpandOnClick = True
            Me.ButtonItem1_CM_Warps.Name = "ButtonItem1_CM_Warps"
            Me.ButtonItem1_CM_Warps.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem6, Me.ButtonItem5, Me.ButtonItem7, Me.ButtonItem23})
            resources.ApplyResources(Me.ButtonItem1_CM_Warps, "ButtonItem1_CM_Warps")
            '
            'ButtonItem6
            '
            Me.ButtonItem6.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
            Me.ButtonItem6.Name = "ButtonItem6"
            Me.ButtonItem6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem6.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem6, "ButtonItem6")
            '
            'ButtonItem7
            '
            Me.ButtonItem7.BeginGroup = True
            Me.ButtonItem7.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
            Me.ButtonItem7.Name = "ButtonItem7"
            Me.ButtonItem7.SymbolColor = System.Drawing.Color.Goldenrod
            Me.ButtonItem7.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem7, "ButtonItem7")
            Me.ButtonItem7.Visible = False
            '
            'ButtonItem23
            '
            Me.ButtonItem23.BeginGroup = True
            Me.ButtonItem23.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
            Me.ButtonItem23.Name = "ButtonItem23"
            Me.ButtonItem23.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem23.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem23, "ButtonItem23")
            '
            'ButtonItem22
            '
            Me.ButtonItem22.AutoExpandOnClick = True
            Me.ButtonItem22.Name = "ButtonItem22"
            Me.ButtonItem22.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem24, Me.ButtonItem25, Me.ButtonItem26})
            resources.ApplyResources(Me.ButtonItem22, "ButtonItem22")
            '
            'ButtonItem24
            '
            Me.ButtonItem24.Name = "ButtonItem24"
            resources.ApplyResources(Me.ButtonItem24, "ButtonItem24")
            '
            'ButtonItem25
            '
            Me.ButtonItem25.Name = "ButtonItem25"
            resources.ApplyResources(Me.ButtonItem25, "ButtonItem25")
            '
            'ButtonItem26
            '
            Me.ButtonItem26.Name = "ButtonItem26"
            resources.ApplyResources(Me.ButtonItem26, "ButtonItem26")
            '
            'GalleryContainer2
            '
            '
            '
            '
            Me.GalleryContainer2.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer"
            Me.GalleryContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.GalleryContainer2.EnableGalleryPopup = False
            Me.GalleryContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.GalleryContainer2.MinimumSize = New System.Drawing.Size(180, 240)
            Me.GalleryContainer2.MultiLine = False
            Me.GalleryContainer2.Name = "GalleryContainer2"
            Me.GalleryContainer2.PopupUsesStandardScrollbars = False
            '
            '
            '
            Me.GalleryContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.GalleryContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItem3
            '
            Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
            Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.Etched
            Me.LabelItem3.CanCustomize = False
            Me.LabelItem3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.LabelItem3.Name = "LabelItem3"
            '
            'RibbonControl1
            '
            Me.RibbonControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            '
            '
            '
            Me.RibbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControl1.CanCustomize = False
            Me.RibbonControl1.CaptionVisible = True
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel1)
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel2)
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel6)
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel3)
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel7)
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel4)
            Me.RibbonControl1.Controls.Add(Me.RibbonPanel5)
            resources.ApplyResources(Me.RibbonControl1, "RibbonControl1")
            Me.RibbonControl1.ForeColor = System.Drawing.Color.Black
            Me.RibbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem3, Me.RibbonTabItem5, Me.RibbonTabItem_Objects, Me.RibbonTabItem_Warps, Me.RibbonTabItem_Collision, Me.RibbonTabItem6, Me.RibbonTabItem1, Me.ButtonItem95})
            Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
            Me.RibbonControl1.MdiSystemItemVisible = False
            Me.RibbonControl1.Name = "RibbonControl1"
            Me.RibbonControl1.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ApplicationButton1, Me.ButtonItem_Undo, Me.ButtonItem_Redo})
            Me.RibbonControl1.RibbonStripFont = New System.Drawing.Font("Segoe UI", 9.25!)
            Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonControl1.SystemText.MaximizeRibbonText = resources.GetString("RibbonControl1.SystemText.MaximizeRibbonText")
            Me.RibbonControl1.SystemText.MinimizeRibbonText = resources.GetString("RibbonControl1.SystemText.MinimizeRibbonText")
            Me.RibbonControl1.SystemText.QatAddItemText = resources.GetString("RibbonControl1.SystemText.QatAddItemText")
            Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = resources.GetString("RibbonControl1.SystemText.QatCustomizeMenuLabel")
            Me.RibbonControl1.SystemText.QatCustomizeText = resources.GetString("RibbonControl1.SystemText.QatCustomizeText")
            Me.RibbonControl1.SystemText.QatDialogAddButton = resources.GetString("RibbonControl1.SystemText.QatDialogAddButton")
            Me.RibbonControl1.SystemText.QatDialogCancelButton = resources.GetString("RibbonControl1.SystemText.QatDialogCancelButton")
            Me.RibbonControl1.SystemText.QatDialogCaption = resources.GetString("RibbonControl1.SystemText.QatDialogCaption")
            Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = resources.GetString("RibbonControl1.SystemText.QatDialogCategoriesLabel")
            Me.RibbonControl1.SystemText.QatDialogOkButton = resources.GetString("RibbonControl1.SystemText.QatDialogOkButton")
            Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = resources.GetString("RibbonControl1.SystemText.QatDialogPlacementCheckbox")
            Me.RibbonControl1.SystemText.QatDialogRemoveButton = resources.GetString("RibbonControl1.SystemText.QatDialogRemoveButton")
            Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = resources.GetString("RibbonControl1.SystemText.QatPlaceAboveRibbonText")
            Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = resources.GetString("RibbonControl1.SystemText.QatPlaceBelowRibbonText")
            Me.RibbonControl1.SystemText.QatRemoveItemText = resources.GetString("RibbonControl1.SystemText.QatRemoveItemText")
            Me.RibbonControl1.TabGroupHeight = 14
            '
            'RibbonPanel1
            '
            Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar29)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar9)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar18)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar7)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar8)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar27)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar3)
            Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
            resources.ApplyResources(Me.RibbonPanel1, "RibbonPanel1")
            Me.RibbonPanel1.Name = "RibbonPanel1"
            '
            '
            '
            Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar29
            '
            Me.RibbonBar29.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar29.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar29.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar29, "RibbonBar29")
            Me.RibbonBar29.DragDropSupport = True
            Me.RibbonBar29.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem35})
            Me.RibbonBar29.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar29.Name = "RibbonBar29"
            Me.RibbonBar29.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar29.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar29.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem35
            '
            Me.ButtonItem35.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem35.Image = Global.SM64_ROM_Manager.My.Resources.MyOldIcons.EditPicture_32px
            Me.ButtonItem35.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem35.Name = "ButtonItem35"
            Me.ButtonItem35.SubItemsExpandWidth = 14
            resources.ApplyResources(Me.ButtonItem35, "ButtonItem35")
            '
            'RibbonBar9
            '
            Me.RibbonBar9.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar9.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar9.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar9, "RibbonBar9")
            Me.RibbonBar9.DragDropSupport = True
            Me.RibbonBar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer11})
            Me.RibbonBar9.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar9.Name = "RibbonBar9"
            Me.RibbonBar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar9.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar9.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer11
            '
            '
            '
            '
            Me.ItemContainer11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer11.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer11.Name = "ItemContainer11"
            Me.ItemContainer11.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_CopyObjCmdAsHex, Me.ButtonItem_ObjectsEditorCmd, Me.ButtonItem_ResetObjToDefault})
            '
            '
            '
            Me.ItemContainer11.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer11.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_ObjectsEditorCmd
            '
            Me.ButtonItem_ObjectsEditorCmd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_ObjectsEditorCmd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
            Me.ButtonItem_ObjectsEditorCmd.Name = "ButtonItem_ObjectsEditorCmd"
            Me.ButtonItem_ObjectsEditorCmd.SymbolColor = System.Drawing.Color.Goldenrod
            Me.ButtonItem_ObjectsEditorCmd.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem_ObjectsEditorCmd, "ButtonItem_ObjectsEditorCmd")
            '
            'ButtonItem_ResetObjToDefault
            '
            Me.ButtonItem_ResetObjToDefault.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_ResetObjToDefault.GlobalItem = False
            Me.ButtonItem_ResetObjToDefault.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_undo_16px
            Me.ButtonItem_ResetObjToDefault.Name = "ButtonItem_ResetObjToDefault"
            Me.ButtonItem_ResetObjToDefault.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem_ResetObjToDefault, "ButtonItem_ResetObjToDefault")
            '
            'RibbonBar18
            '
            Me.RibbonBar18.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar18.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar18.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar18, "RibbonBar18")
            Me.RibbonBar18.DragDropSupport = True
            Me.RibbonBar18.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer14, Me.ItemContainer15})
            Me.RibbonBar18.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar18.Name = "RibbonBar18"
            Me.RibbonBar18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar18.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar18.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer14
            '
            '
            '
            '
            Me.ItemContainer14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer14.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer14.Name = "ItemContainer14"
            Me.ItemContainer14.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_DropToGround, Me.ButtonItem_DropToTop, Me.ButtonItem_DropToBottom})
            '
            '
            '
            Me.ItemContainer14.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer14.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_DropToGround
            '
            Me.ButtonItem_DropToGround.Name = "ButtonItem_DropToGround"
            resources.ApplyResources(Me.ButtonItem_DropToGround, "ButtonItem_DropToGround")
            '
            'ButtonItem_DropToTop
            '
            Me.ButtonItem_DropToTop.Name = "ButtonItem_DropToTop"
            resources.ApplyResources(Me.ButtonItem_DropToTop, "ButtonItem_DropToTop")
            '
            'ButtonItem_DropToBottom
            '
            Me.ButtonItem_DropToBottom.Name = "ButtonItem_DropToBottom"
            resources.ApplyResources(Me.ButtonItem_DropToBottom, "ButtonItem_DropToBottom")
            '
            'ItemContainer15
            '
            '
            '
            '
            Me.ItemContainer15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer15.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer15.Name = "ItemContainer15"
            Me.ItemContainer15.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_KeepOnGround, Me.ButtonItem_KeepOnTop, Me.ButtonItem_KeepOnButtom})
            '
            '
            '
            Me.ItemContainer15.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer15.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_KeepOnGround
            '
            Me.ButtonItem_KeepOnGround.AutoCheckOnClick = True
            Me.ButtonItem_KeepOnGround.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_merge_horizontal_16px
            Me.ButtonItem_KeepOnGround.Name = "ButtonItem_KeepOnGround"
            Me.ButtonItem_KeepOnGround.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_KeepOnGround.SymbolSize = 12.0!
            '
            'ButtonItem_KeepOnTop
            '
            Me.ButtonItem_KeepOnTop.AutoCheckOnClick = True
            Me.ButtonItem_KeepOnTop.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_chevron_up_16px
            Me.ButtonItem_KeepOnTop.Name = "ButtonItem_KeepOnTop"
            Me.ButtonItem_KeepOnTop.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_KeepOnTop.SymbolSize = 12.0!
            '
            'ButtonItem_KeepOnButtom
            '
            Me.ButtonItem_KeepOnButtom.AutoCheckOnClick = True
            Me.ButtonItem_KeepOnButtom.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_chevron_down_16px
            Me.ButtonItem_KeepOnButtom.Name = "ButtonItem_KeepOnButtom"
            Me.ButtonItem_KeepOnButtom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_KeepOnButtom.SymbolSize = 12.0!
            '
            'RibbonBar7
            '
            Me.RibbonBar7.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar7.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar7, "RibbonBar7")
            Me.RibbonBar7.DragDropSupport = True
            Me.RibbonBar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ExportObjectModel})
            Me.RibbonBar7.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar7.Name = "RibbonBar7"
            Me.RibbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_ExportObjectModel
            '
            Me.ButtonItem_ExportObjectModel.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_export_32px
            Me.ButtonItem_ExportObjectModel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem_ExportObjectModel.Name = "ButtonItem_ExportObjectModel"
            Me.ButtonItem_ExportObjectModel.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_ExportObjectModel.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem_ExportObjectModel, "ButtonItem_ExportObjectModel")
            '
            'RibbonBar8
            '
            Me.RibbonBar8.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar8.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar8, "RibbonBar8")
            Me.RibbonBar8.DragDropSupport = True
            Me.RibbonBar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ObjectsRemove, Me.ItemContainer21})
            Me.RibbonBar8.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar8.Name = "RibbonBar8"
            Me.RibbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem_ObjectsRemove
            '
            Me.ButtonItem_ObjectsRemove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_ObjectsRemove.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_32px
            Me.ButtonItem_ObjectsRemove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem_ObjectsRemove.Name = "ButtonItem_ObjectsRemove"
            Me.ButtonItem_ObjectsRemove.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem_ObjectsRemove.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_ObjectsRemove.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem_ObjectsRemove, "ButtonItem_ObjectsRemove")
            '
            'ItemContainer21
            '
            '
            '
            '
            Me.ItemContainer21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer21.BeginGroup = True
            Me.ItemContainer21.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer21.Name = "ItemContainer21"
            Me.ItemContainer21.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem27, Me.ButtonItem28})
            '
            '
            '
            Me.ItemContainer21.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer21.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem27
            '
            Me.ButtonItem27.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem27.Name = "ButtonItem27"
            Me.ButtonItem27.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem27.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem27, "ButtonItem27")
            '
            'ButtonItem28
            '
            Me.ButtonItem28.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem28.Name = "ButtonItem28"
            Me.ButtonItem28.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem28.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem28, "ButtonItem28")
            '
            'RibbonBar27
            '
            Me.RibbonBar27.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar27.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar27.ContainerControlProcessDialogKey = True
            Me.RibbonBar27.DialogLauncherVisible = True
            resources.ApplyResources(Me.RibbonBar27, "RibbonBar27")
            Me.RibbonBar27.DragDropSupport = True
            Me.RibbonBar27.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem31, Me.ButtonItem32})
            Me.RibbonBar27.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar27.Name = "RibbonBar27"
            Me.RibbonBar27.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar27.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar27.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem31
            '
            Me.ButtonItem31.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem31.Image = Global.SM64_ROM_Manager.My.Resources.MyOldIcons.Shrink_32px
            Me.ButtonItem31.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem31.Name = "ButtonItem31"
            Me.ButtonItem31.SubItemsExpandWidth = 14
            resources.ApplyResources(Me.ButtonItem31, "ButtonItem31")
            '
            'ButtonItem32
            '
            Me.ButtonItem32.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem32.Image = Global.SM64_ROM_Manager.My.Resources.Resources.Psychology_32px
            Me.ButtonItem32.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem32.Name = "ButtonItem32"
            Me.ButtonItem32.SubItemsExpandWidth = 14
            resources.ApplyResources(Me.ButtonItem32, "ButtonItem32")
            '
            'RibbonBar1
            '
            Me.RibbonBar1.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar1.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar1, "RibbonBar1")
            Me.RibbonBar1.DragDropSupport = True
            Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonX_ObjectsAdd, Me.ItemContainer5, Me.ItemContainer6})
            Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar1.Name = "RibbonBar1"
            Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonX_ObjectsAdd
            '
            Me.ButtonX_ObjectsAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonX_ObjectsAdd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_32px
            Me.ButtonX_ObjectsAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonX_ObjectsAdd.Name = "ButtonX_ObjectsAdd"
            Me.ButtonX_ObjectsAdd.SubItemsExpandWidth = 14
            Me.ButtonX_ObjectsAdd.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonX_ObjectsAdd.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonX_ObjectsAdd.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonX_ObjectsAdd, "ButtonX_ObjectsAdd")
            '
            'ItemContainer5
            '
            '
            '
            '
            Me.ItemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer5.Name = "ItemContainer5"
            Me.ItemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem38, Me.ButtonItem39, Me.ButtonItem40})
            '
            '
            '
            Me.ItemContainer5.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem38
            '
            Me.ButtonItem38.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem38.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem38.Name = "ButtonItem38"
            Me.ButtonItem38.SubItemsExpandWidth = 14
            Me.ButtonItem38.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem38.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem38.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem38, "ButtonItem38")
            '
            'ButtonItem39
            '
            Me.ButtonItem39.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem39.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem39.Name = "ButtonItem39"
            Me.ButtonItem39.SubItemsExpandWidth = 14
            Me.ButtonItem39.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem39.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem39.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem39, "ButtonItem39")
            '
            'ButtonItem40
            '
            Me.ButtonItem40.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem40.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem40.Name = "ButtonItem40"
            Me.ButtonItem40.SubItemsExpandWidth = 14
            Me.ButtonItem40.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem40.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem40.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem40, "ButtonItem40")
            '
            'ItemContainer6
            '
            '
            '
            '
            Me.ItemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer6.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer6.Name = "ItemContainer6"
            Me.ItemContainer6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem41, Me.ButtonItem42, Me.ButtonItem43})
            '
            '
            '
            Me.ItemContainer6.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem41
            '
            Me.ButtonItem41.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem41.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem41.Name = "ButtonItem41"
            Me.ButtonItem41.SubItemsExpandWidth = 14
            Me.ButtonItem41.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem41.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem41.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem41, "ButtonItem41")
            '
            'ButtonItem42
            '
            Me.ButtonItem42.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem42.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem42.Name = "ButtonItem42"
            Me.ButtonItem42.SubItemsExpandWidth = 14
            Me.ButtonItem42.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem42.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem42.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem42, "ButtonItem42")
            '
            'ButtonItem43
            '
            Me.ButtonItem43.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem43.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem43.Name = "ButtonItem43"
            Me.ButtonItem43.SubItemsExpandWidth = 14
            Me.ButtonItem43.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem43.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem43.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem43, "ButtonItem43")
            '
            'RibbonPanel6
            '
            Me.RibbonPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel6.Controls.Add(Me.RibbonBar23)
            Me.RibbonPanel6.Controls.Add(Me.RibbonBar22)
            Me.RibbonPanel6.Controls.Add(Me.RibbonBar21)
            Me.RibbonPanel6.Controls.Add(Me.RibbonBar20)
            Me.RibbonPanel6.Controls.Add(Me.RibbonBar19)
            resources.ApplyResources(Me.RibbonPanel6, "RibbonPanel6")
            Me.RibbonPanel6.Name = "RibbonPanel6"
            '
            '
            '
            Me.RibbonPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar23
            '
            Me.RibbonBar23.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar23.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar23.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar23, "RibbonBar23")
            Me.RibbonBar23.DragDropSupport = True
            Me.RibbonBar23.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer4})
            Me.RibbonBar23.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar23.Name = "RibbonBar23"
            Me.RibbonBar23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar23.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar23.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar23.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainer4
            '
            '
            '
            '
            Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer4.Name = "ItemContainer4"
            Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItem_PerspectiveMode, Me.CheckBoxItem_OrthoMode})
            '
            '
            '
            Me.ItemContainer4.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer4.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'CheckBoxItem_PerspectiveMode
            '
            Me.CheckBoxItem_PerspectiveMode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.CheckBoxItem_PerspectiveMode.Checked = True
            Me.CheckBoxItem_PerspectiveMode.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxItem_PerspectiveMode.Name = "CheckBoxItem_PerspectiveMode"
            resources.ApplyResources(Me.CheckBoxItem_PerspectiveMode, "CheckBoxItem_PerspectiveMode")
            '
            'CheckBoxItem_OrthoMode
            '
            Me.CheckBoxItem_OrthoMode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.CheckBoxItem_OrthoMode.Name = "CheckBoxItem_OrthoMode"
            resources.ApplyResources(Me.CheckBoxItem_OrthoMode, "CheckBoxItem_OrthoMode")
            '
            'RibbonBar22
            '
            Me.RibbonBar22.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar22.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar22.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar22, "RibbonBar22")
            Me.RibbonBar22.DragDropSupport = True
            Me.RibbonBar22.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2})
            Me.RibbonBar22.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar22.Name = "RibbonBar22"
            Me.RibbonBar22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar22.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar22.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem2
            '
            Me.ButtonItem2.AutoCheckOnClick = True
            Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem2.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_fit_to_width_32px
            Me.ButtonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem2.Name = "ButtonItem2"
            Me.ButtonItem2.SubItemsExpandWidth = 14
            Me.ButtonItem2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem2.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem2, "ButtonItem2")
            '
            'RibbonBar21
            '
            Me.RibbonBar21.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar21.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar21.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar21, "RibbonBar21")
            Me.RibbonBar21.DragDropSupport = True
            Me.RibbonBar21.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
            Me.RibbonBar21.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar21.Name = "RibbonBar21"
            Me.RibbonBar21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar21.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar21.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem1
            '
            Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem1.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_screenshot_32px
            Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem1.Name = "ButtonItem1"
            Me.ButtonItem1.SubItemsExpandWidth = 14
            Me.ButtonItem1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem1.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem1, "ButtonItem1")
            '
            'RibbonBar20
            '
            Me.RibbonBar20.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar20.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar20.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar20, "RibbonBar20")
            Me.RibbonBar20.DragDropSupport = True
            Me.RibbonBar20.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer2, Me.ItemContainer3})
            Me.RibbonBar20.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar20.Name = "RibbonBar20"
            Me.RibbonBar20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar20.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar20.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar20.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainer2
            '
            '
            '
            '
            Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer2.Name = "ItemContainer2"
            Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_DrawBackfaces, Me.ButtonItem_DrawObjects})
            '
            '
            '
            Me.ItemContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer2.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItem_DrawBackfaces
            '
            Me.ButtonItem_DrawBackfaces.Name = "ButtonItem_DrawBackfaces"
            resources.ApplyResources(Me.ButtonItem_DrawBackfaces, "ButtonItem_DrawBackfaces")
            '
            'ButtonItem_DrawObjects
            '
            Me.ButtonItem_DrawObjects.Checked = True
            Me.ButtonItem_DrawObjects.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ButtonItem_DrawObjects.Name = "ButtonItem_DrawObjects"
            resources.ApplyResources(Me.ButtonItem_DrawObjects, "ButtonItem_DrawObjects")
            '
            'ItemContainer3
            '
            '
            '
            '
            Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer3.BeginGroup = True
            Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer3.Name = "ItemContainer3"
            Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_DrawFill, Me.ButtonItem_DrawOutline})
            '
            '
            '
            Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer3.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItem_DrawFill
            '
            Me.ButtonItem_DrawFill.Checked = True
            Me.ButtonItem_DrawFill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ButtonItem_DrawFill.Name = "ButtonItem_DrawFill"
            resources.ApplyResources(Me.ButtonItem_DrawFill, "ButtonItem_DrawFill")
            '
            'ButtonItem_DrawOutline
            '
            Me.ButtonItem_DrawOutline.Name = "ButtonItem_DrawOutline"
            resources.ApplyResources(Me.ButtonItem_DrawOutline, "ButtonItem_DrawOutline")
            '
            'RibbonBar19
            '
            Me.RibbonBar19.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar19.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar19.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar19, "RibbonBar19")
            Me.RibbonBar19.DragDropSupport = True
            Me.RibbonBar19.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
            Me.RibbonBar19.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar19.Name = "RibbonBar19"
            Me.RibbonBar19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar19.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar19.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar19.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ViewVisualMap, Me.ButtonItem_ViewColMap})
            '
            '
            '
            Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItem_ViewVisualMap
            '
            Me.ButtonItem_ViewVisualMap.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.ButtonItem_ViewVisualMap.Checked = True
            Me.ButtonItem_ViewVisualMap.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ButtonItem_ViewVisualMap.Name = "ButtonItem_ViewVisualMap"
            resources.ApplyResources(Me.ButtonItem_ViewVisualMap, "ButtonItem_ViewVisualMap")
            '
            'ButtonItem_ViewColMap
            '
            Me.ButtonItem_ViewColMap.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.ButtonItem_ViewColMap.Name = "ButtonItem_ViewColMap"
            resources.ApplyResources(Me.ButtonItem_ViewColMap, "ButtonItem_ViewColMap")
            '
            'RibbonPanel3
            '
            Me.RibbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel3.Controls.Add(Me.RibbonBar4)
            Me.RibbonPanel3.Controls.Add(Me.RibbonBar16)
            resources.ApplyResources(Me.RibbonPanel3, "RibbonPanel3")
            Me.RibbonPanel3.Name = "RibbonPanel3"
            '
            '
            '
            Me.RibbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar4
            '
            Me.RibbonBar4.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar4.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar4, "RibbonBar4")
            Me.RibbonBar4.DragDropSupport = True
            Me.RibbonBar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer13})
            Me.RibbonBar4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar4.Name = "RibbonBar4"
            Me.RibbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer13
            '
            '
            '
            '
            Me.ItemContainer13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer13.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer13.Name = "ItemContainer13"
            Me.ItemContainer13.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem83, Me.ButtonItem84})
            '
            '
            '
            Me.ItemContainer13.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer13.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem83
            '
            Me.ButtonItem83.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem83.Enabled = False
            Me.ButtonItem83.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
            Me.ButtonItem83.Name = "ButtonItem83"
            Me.ButtonItem83.SymbolColor = System.Drawing.Color.Goldenrod
            Me.ButtonItem83.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem83, "ButtonItem83")
            '
            'ButtonItem84
            '
            Me.ButtonItem84.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem84.Name = "ButtonItem84"
            Me.ButtonItem84.Symbol = "57686"
            Me.ButtonItem84.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem84.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem84, "ButtonItem84")
            '
            'RibbonBar16
            '
            Me.RibbonBar16.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar16.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar16.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar16, "RibbonBar16")
            Me.RibbonBar16.DragDropSupport = True
            Me.RibbonBar16.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar16.Name = "RibbonBar16"
            Me.RibbonBar16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar16.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar16.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonPanel7
            '
            Me.RibbonPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel7.Controls.Add(Me.RibbonBar28)
            resources.ApplyResources(Me.RibbonPanel7, "RibbonPanel7")
            Me.RibbonPanel7.Name = "RibbonPanel7"
            '
            '
            '
            Me.RibbonPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar28
            '
            Me.RibbonBar28.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar28.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar28.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar28, "RibbonBar28")
            Me.RibbonBar28.DragDropSupport = True
            Me.RibbonBar28.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem34})
            Me.RibbonBar28.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar28.Name = "RibbonBar28"
            Me.RibbonBar28.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar28.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar28.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem34
            '
            Me.ButtonItem34.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem34.Image = Global.SM64_ROM_Manager.My.Resources.MyOldIcons.EditPicture_32px
            Me.ButtonItem34.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem34.Name = "ButtonItem34"
            Me.ButtonItem34.SubItemsExpandWidth = 14
            resources.ApplyResources(Me.ButtonItem34, "ButtonItem34")
            '
            'RibbonPanel4
            '
            Me.RibbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel4.Controls.Add(Me.RibbonBar14)
            Me.RibbonPanel4.Controls.Add(Me.RibbonBar25)
            Me.RibbonPanel4.Controls.Add(Me.RibbonBar24)
            Me.RibbonPanel4.Controls.Add(Me.RibbonBar15)
            Me.RibbonPanel4.Controls.Add(Me.RibbonBar13)
            Me.RibbonPanel4.Controls.Add(Me.RibbonBar17)
            resources.ApplyResources(Me.RibbonPanel4, "RibbonPanel4")
            Me.RibbonPanel4.Name = "RibbonPanel4"
            '
            '
            '
            Me.RibbonPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar14
            '
            Me.RibbonBar14.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar14.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar14.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar14, "RibbonBar14")
            Me.RibbonBar14.DragDropSupport = True
            Me.RibbonBar14.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar14.Name = "RibbonBar14"
            Me.RibbonBar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar14.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar14.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar25
            '
            Me.RibbonBar25.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar25.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar25.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar25, "RibbonBar25")
            Me.RibbonBar25.DragDropSupport = True
            Me.RibbonBar25.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer16})
            Me.RibbonBar25.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar25.Name = "RibbonBar25"
            Me.RibbonBar25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar25.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar25.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer16
            '
            '
            '
            '
            Me.ItemContainer16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer16.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer16.Name = "ItemContainer16"
            Me.ItemContainer16.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem8, Me.ButtonItem4})
            '
            '
            '
            Me.ItemContainer16.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer16.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem8
            '
            Me.ButtonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem8.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem8.Name = "ButtonItem8"
            Me.ButtonItem8.SubItemsExpandWidth = 14
            Me.ButtonItem8.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem8.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem8.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem8, "ButtonItem8")
            '
            'ButtonItem4
            '
            Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem4.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_2_16px
            Me.ButtonItem4.Name = "ButtonItem4"
            Me.ButtonItem4.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem4.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem4, "ButtonItem4")
            '
            'RibbonBar24
            '
            Me.RibbonBar24.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar24.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar24.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar24, "RibbonBar24")
            Me.RibbonBar24.DragDropSupport = True
            Me.RibbonBar24.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer17})
            Me.RibbonBar24.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar24.Name = "RibbonBar24"
            Me.RibbonBar24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar24.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar24.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer17
            '
            '
            '
            '
            Me.ItemContainer17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer17.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer17.Name = "ItemContainer17"
            Me.ItemContainer17.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem10, Me.ButtonItem11, Me.ButtonItem12})
            '
            '
            '
            Me.ItemContainer17.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer17.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem10
            '
            Me.ButtonItem10.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem10.Enabled = False
            Me.ButtonItem10.Name = "ButtonItem10"
            Me.ButtonItem10.SubItemsExpandWidth = 14
            Me.ButtonItem10.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem10.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem10.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem10, "ButtonItem10")
            '
            'ButtonItem11
            '
            Me.ButtonItem11.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem11.Name = "ButtonItem11"
            Me.ButtonItem11.SubItemsExpandWidth = 14
            Me.ButtonItem11.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem11.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem11.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem11, "ButtonItem11")
            '
            'ButtonItem12
            '
            Me.ButtonItem12.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem12.Enabled = False
            Me.ButtonItem12.Name = "ButtonItem12"
            Me.ButtonItem12.SubItemsExpandWidth = 14
            Me.ButtonItem12.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem12.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem12.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem12, "ButtonItem12")
            '
            'RibbonBar15
            '
            Me.RibbonBar15.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar15.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar15.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar15, "RibbonBar15")
            Me.RibbonBar15.DragDropSupport = True
            Me.RibbonBar15.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem21, Me.ItemContainer19})
            Me.RibbonBar15.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar15.Name = "RibbonBar15"
            Me.RibbonBar15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar15.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar15.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem21
            '
            Me.ButtonItem21.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem21.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_32px
            Me.ButtonItem21.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem21.Name = "ButtonItem21"
            Me.ButtonItem21.SubItemsExpandWidth = 14
            Me.ButtonItem21.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem21.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem21.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem21, "ButtonItem21")
            '
            'ItemContainer19
            '
            '
            '
            '
            Me.ItemContainer19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer19.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer19.Name = "ItemContainer19"
            Me.ItemContainer19.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem18, Me.ButtonItem17, Me.ButtonItem19})
            '
            '
            '
            Me.ItemContainer19.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer19.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem18
            '
            Me.ButtonItem18.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem18.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem18.Name = "ButtonItem18"
            Me.ButtonItem18.SubItemsExpandWidth = 14
            Me.ButtonItem18.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem18.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem18.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem18, "ButtonItem18")
            '
            'ButtonItem17
            '
            Me.ButtonItem17.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem17.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem17.Name = "ButtonItem17"
            Me.ButtonItem17.SubItemsExpandWidth = 14
            Me.ButtonItem17.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem17.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem17.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem17, "ButtonItem17")
            '
            'ButtonItem19
            '
            Me.ButtonItem19.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem19.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
            Me.ButtonItem19.Name = "ButtonItem19"
            Me.ButtonItem19.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem19.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem19.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem19, "ButtonItem19")
            '
            'RibbonBar13
            '
            Me.RibbonBar13.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar13.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar13.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar13, "RibbonBar13")
            Me.RibbonBar13.DragDropSupport = True
            Me.RibbonBar13.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer18, Me.LabelItem4})
            Me.RibbonBar13.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar13.Name = "RibbonBar13"
            Me.RibbonBar13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar13.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar13.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer18
            '
            '
            '
            '
            Me.ItemContainer18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer18.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer18.Name = "ItemContainer18"
            Me.ItemContainer18.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer20, Me.ButtonItem15, Me.ButtonItem16})
            '
            '
            '
            Me.ItemContainer18.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer18.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer20
            '
            '
            '
            '
            Me.ItemContainer20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer20.Name = "ItemContainer20"
            Me.ItemContainer20.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem20, Me.ButtonItem14})
            '
            '
            '
            Me.ItemContainer20.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer20.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem20
            '
            Me.ButtonItem20.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem20.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem20.Name = "ButtonItem20"
            Me.ButtonItem20.SubItemsExpandWidth = 14
            Me.ButtonItem20.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem20.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem20.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem20, "ButtonItem20")
            '
            'ButtonItem14
            '
            Me.ButtonItem14.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem14.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem14.Name = "ButtonItem14"
            Me.ButtonItem14.SubItemsExpandWidth = 14
            Me.ButtonItem14.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem14.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem14.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem14, "ButtonItem14")
            '
            'ButtonItem15
            '
            Me.ButtonItem15.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem15.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem15.Name = "ButtonItem15"
            Me.ButtonItem15.SubItemsExpandWidth = 14
            Me.ButtonItem15.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem15.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem15.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem15, "ButtonItem15")
            '
            'ButtonItem16
            '
            Me.ButtonItem16.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem16.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
            Me.ButtonItem16.Name = "ButtonItem16"
            Me.ButtonItem16.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem16.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem16.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem16, "ButtonItem16")
            '
            'LabelItem4
            '
            Me.LabelItem4.Name = "LabelItem4"
            resources.ApplyResources(Me.LabelItem4, "LabelItem4")
            Me.LabelItem4.Visible = False
            '
            'RibbonBar17
            '
            Me.RibbonBar17.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar17.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar17.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar17, "RibbonBar17")
            Me.RibbonBar17.DragDropSupport = True
            Me.RibbonBar17.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem85, Me.ButtonItem86})
            Me.RibbonBar17.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar17.Name = "RibbonBar17"
            Me.RibbonBar17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar17.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar17.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem85
            '
            Me.ButtonItem85.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_import_32px
            Me.ButtonItem85.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem85.Name = "ButtonItem85"
            Me.ButtonItem85.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem85.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem85, "ButtonItem85")
            '
            'ButtonItem86
            '
            Me.ButtonItem86.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_export_32px
            Me.ButtonItem86.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem86.Name = "ButtonItem86"
            Me.ButtonItem86.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem86.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem86, "ButtonItem86")
            '
            'RibbonPanel2
            '
            Me.RibbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel2.Controls.Add(Me.RibbonBar2)
            Me.RibbonPanel2.Controls.Add(Me.RibbonBar26)
            Me.RibbonPanel2.Controls.Add(Me.RibbonBar10)
            Me.RibbonPanel2.Controls.Add(Me.RibbonBar11)
            Me.RibbonPanel2.Controls.Add(Me.RibbonBar12)
            resources.ApplyResources(Me.RibbonPanel2, "RibbonPanel2")
            Me.RibbonPanel2.Name = "RibbonPanel2"
            '
            '
            '
            Me.RibbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar2
            '
            Me.RibbonBar2.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar2.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar2, "RibbonBar2")
            Me.RibbonBar2.DragDropSupport = True
            Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer10})
            Me.RibbonBar2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar2.Name = "RibbonBar2"
            Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer10
            '
            '
            '
            '
            Me.ItemContainer10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer10.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer10.Name = "ItemContainer10"
            Me.ItemContainer10.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_CopyWarpCmdAsHex, Me.ButtonX_WarpsEditCmd, Me.ButtonItem69})
            '
            '
            '
            Me.ItemContainer10.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer10.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonX_WarpsEditCmd
            '
            Me.ButtonX_WarpsEditCmd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonX_WarpsEditCmd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
            Me.ButtonX_WarpsEditCmd.Name = "ButtonX_WarpsEditCmd"
            Me.ButtonX_WarpsEditCmd.SymbolColor = System.Drawing.Color.Goldenrod
            Me.ButtonX_WarpsEditCmd.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonX_WarpsEditCmd, "ButtonX_WarpsEditCmd")
            '
            'ButtonItem69
            '
            Me.ButtonItem69.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem69.GlobalItem = False
            Me.ButtonItem69.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_undo_16px
            Me.ButtonItem69.Name = "ButtonItem69"
            Me.ButtonItem69.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem69, "ButtonItem69")
            '
            'RibbonBar26
            '
            Me.RibbonBar26.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar26.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar26.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar26, "RibbonBar26")
            Me.RibbonBar26.DragDropSupport = True
            Me.RibbonBar26.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer22})
            Me.RibbonBar26.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar26.Name = "RibbonBar26"
            Me.RibbonBar26.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar26.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar26.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer22
            '
            '
            '
            '
            Me.ItemContainer22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer22.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer22.Name = "ItemContainer22"
            Me.ItemContainer22.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem29})
            '
            '
            '
            Me.ItemContainer22.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer22.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem29
            '
            Me.ButtonItem29.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem29.Name = "ButtonItem29"
            resources.ApplyResources(Me.ButtonItem29, "ButtonItem29")
            '
            'RibbonBar10
            '
            Me.RibbonBar10.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar10.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar10.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar10, "RibbonBar10")
            Me.RibbonBar10.DragDropSupport = True
            Me.RibbonBar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonX_WarpsRemove})
            Me.RibbonBar10.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar10.Name = "RibbonBar10"
            Me.RibbonBar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar10.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar10.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonX_WarpsRemove
            '
            Me.ButtonX_WarpsRemove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonX_WarpsRemove.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_32px
            Me.ButtonX_WarpsRemove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonX_WarpsRemove.Name = "ButtonX_WarpsRemove"
            Me.ButtonX_WarpsRemove.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonX_WarpsRemove.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonX_WarpsRemove.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonX_WarpsRemove, "ButtonX_WarpsRemove")
            '
            'RibbonBar12
            '
            Me.RibbonBar12.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar12.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar12.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar12, "RibbonBar12")
            Me.RibbonBar12.DragDropSupport = True
            Me.RibbonBar12.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonX_WarpsAdd})
            Me.RibbonBar12.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar12.Name = "RibbonBar12"
            Me.RibbonBar12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar12.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar12.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonX_WarpsAdd
            '
            Me.ButtonX_WarpsAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonX_WarpsAdd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_32px
            Me.ButtonX_WarpsAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonX_WarpsAdd.Name = "ButtonX_WarpsAdd"
            Me.ButtonX_WarpsAdd.SplitButton = True
            Me.ButtonX_WarpsAdd.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonX_WarpsAddConnectedWarp, Me.ButtonX_WarpsAddPaintingWarp, Me.ButtonItem_WarpsAddInstantWarp})
            Me.ButtonX_WarpsAdd.SubItemsExpandWidth = 14
            Me.ButtonX_WarpsAdd.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonX_WarpsAdd.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonX_WarpsAdd.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonX_WarpsAdd, "ButtonX_WarpsAdd")
            '
            'ButtonX_WarpsAddConnectedWarp
            '
            Me.ButtonX_WarpsAddConnectedWarp.Name = "ButtonX_WarpsAddConnectedWarp"
            resources.ApplyResources(Me.ButtonX_WarpsAddConnectedWarp, "ButtonX_WarpsAddConnectedWarp")
            '
            'ButtonX_WarpsAddPaintingWarp
            '
            Me.ButtonX_WarpsAddPaintingWarp.Name = "ButtonX_WarpsAddPaintingWarp"
            resources.ApplyResources(Me.ButtonX_WarpsAddPaintingWarp, "ButtonX_WarpsAddPaintingWarp")
            '
            'ButtonItem_WarpsAddInstantWarp
            '
            Me.ButtonItem_WarpsAddInstantWarp.Name = "ButtonItem_WarpsAddInstantWarp"
            resources.ApplyResources(Me.ButtonItem_WarpsAddInstantWarp, "ButtonItem_WarpsAddInstantWarp")
            '
            'RibbonPanel5
            '
            Me.RibbonPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanel5.Controls.Add(Me.RibbonBar30)
            Me.RibbonPanel5.Controls.Add(Me.RibbonBar6)
            Me.RibbonPanel5.Controls.Add(Me.RibbonBar5)
            resources.ApplyResources(Me.RibbonPanel5, "RibbonPanel5")
            Me.RibbonPanel5.Name = "RibbonPanel5"
            '
            '
            '
            Me.RibbonPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBar30
            '
            Me.RibbonBar30.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar30.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar30.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar30, "RibbonBar30")
            Me.RibbonBar30.DragDropSupport = True
            Me.RibbonBar30.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem36})
            Me.RibbonBar30.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar30.Name = "RibbonBar30"
            Me.RibbonBar30.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar30.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar30.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem36
            '
            Me.ButtonItem36.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem36.Image = Global.SM64_ROM_Manager.My.Resources.MyOldIcons.EditPicture_32px
            Me.ButtonItem36.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem36.Name = "ButtonItem36"
            Me.ButtonItem36.SubItemsExpandWidth = 14
            resources.ApplyResources(Me.ButtonItem36, "ButtonItem36")
            '
            'RibbonBar6
            '
            Me.RibbonBar6.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar6.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar6, "RibbonBar6")
            Me.RibbonBar6.DragDropSupport = True
            Me.RibbonBar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem47, Me.ButtonItem53})
            Me.RibbonBar6.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar6.Name = "RibbonBar6"
            Me.RibbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItem47
            '
            Me.ButtonItem47.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_import_32px
            Me.ButtonItem47.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem47.Name = "ButtonItem47"
            Me.ButtonItem47.SplitButton = True
            Me.ButtonItem47.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ImportModel, Me.ButtonItem_ImportVisualMap, Me.ButtonItem_ImportCollision})
            Me.ButtonItem47.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem47.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem47, "ButtonItem47")
            '
            'ButtonItem_ImportModel
            '
            Me.ButtonItem_ImportModel.Name = "ButtonItem_ImportModel"
            resources.ApplyResources(Me.ButtonItem_ImportModel, "ButtonItem_ImportModel")
            '
            'ButtonItem_ImportVisualMap
            '
            Me.ButtonItem_ImportVisualMap.BeginGroup = True
            Me.ButtonItem_ImportVisualMap.Name = "ButtonItem_ImportVisualMap"
            resources.ApplyResources(Me.ButtonItem_ImportVisualMap, "ButtonItem_ImportVisualMap")
            '
            'ButtonItem_ImportCollision
            '
            Me.ButtonItem_ImportCollision.Name = "ButtonItem_ImportCollision"
            resources.ApplyResources(Me.ButtonItem_ImportCollision, "ButtonItem_ImportCollision")
            '
            'ButtonItem53
            '
            Me.ButtonItem53.AutoExpandOnClick = True
            Me.ButtonItem53.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_export_32px
            Me.ButtonItem53.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem53.Name = "ButtonItem53"
            Me.ButtonItem53.SplitButton = True
            Me.ButtonItem53.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ExportVisualMap, Me.ButtonItem_ExportCollision})
            Me.ButtonItem53.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem53.SymbolSize = 24.0!
            resources.ApplyResources(Me.ButtonItem53, "ButtonItem53")
            '
            'ButtonItem_ExportVisualMap
            '
            Me.ButtonItem_ExportVisualMap.BeginGroup = True
            Me.ButtonItem_ExportVisualMap.Name = "ButtonItem_ExportVisualMap"
            resources.ApplyResources(Me.ButtonItem_ExportVisualMap, "ButtonItem_ExportVisualMap")
            '
            'ButtonItem_ExportCollision
            '
            Me.ButtonItem_ExportCollision.Name = "ButtonItem_ExportCollision"
            resources.ApplyResources(Me.ButtonItem_ExportCollision, "ButtonItem_ExportCollision")
            '
            'RibbonBar5
            '
            Me.RibbonBar5.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBar5.ContainerControlProcessDialogKey = True
            resources.ApplyResources(Me.RibbonBar5, "RibbonBar5")
            Me.RibbonBar5.DragDropSupport = True
            Me.RibbonBar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer8})
            Me.RibbonBar5.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBar5.Name = "RibbonBar5"
            Me.RibbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '
            '
            '
            Me.RibbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer8
            '
            '
            '
            '
            Me.ItemContainer8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer8.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer8.Name = "ItemContainer8"
            Me.ItemContainer8.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer9, Me.ButtonItem_AddArea, Me.ButtonItem_RemoveArea})
            '
            '
            '
            Me.ItemContainer8.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainer9
            '
            '
            '
            '
            Me.ItemContainer9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer9.Name = "ItemContainer9"
            Me.ItemContainer9.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItem_Area})
            '
            '
            '
            Me.ItemContainer9.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer9.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItem_Area
            '
            Me.ComboBoxItem_Area.DropDownHeight = 106
            Me.ComboBoxItem_Area.Name = "ComboBoxItem_Area"
            '
            'ButtonItem_AddArea
            '
            Me.ButtonItem_AddArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_AddArea.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
            Me.ButtonItem_AddArea.Name = "ButtonItem_AddArea"
            Me.ButtonItem_AddArea.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem_AddArea.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_AddArea.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem_AddArea, "ButtonItem_AddArea")
            '
            'ButtonItem_RemoveArea
            '
            Me.ButtonItem_RemoveArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem_RemoveArea.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
            Me.ButtonItem_RemoveArea.Name = "ButtonItem_RemoveArea"
            Me.ButtonItem_RemoveArea.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem_RemoveArea.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_RemoveArea.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem_RemoveArea, "ButtonItem_RemoveArea")
            '
            'RibbonTabItem3
            '
            Me.RibbonTabItem3.Name = "RibbonTabItem3"
            Me.RibbonTabItem3.Panel = Me.RibbonPanel3
            resources.ApplyResources(Me.RibbonTabItem3, "RibbonTabItem3")
            '
            'RibbonTabItem5
            '
            Me.RibbonTabItem5.Name = "RibbonTabItem5"
            Me.RibbonTabItem5.Panel = Me.RibbonPanel5
            resources.ApplyResources(Me.RibbonTabItem5, "RibbonTabItem5")
            '
            'RibbonTabItem_Objects
            '
            Me.RibbonTabItem_Objects.Checked = True
            Me.RibbonTabItem_Objects.Name = "RibbonTabItem_Objects"
            Me.RibbonTabItem_Objects.Panel = Me.RibbonPanel1
            resources.ApplyResources(Me.RibbonTabItem_Objects, "RibbonTabItem_Objects")
            '
            'RibbonTabItem_Warps
            '
            Me.RibbonTabItem_Warps.Name = "RibbonTabItem_Warps"
            Me.RibbonTabItem_Warps.Panel = Me.RibbonPanel2
            resources.ApplyResources(Me.RibbonTabItem_Warps, "RibbonTabItem_Warps")
            '
            'RibbonTabItem_Collision
            '
            Me.RibbonTabItem_Collision.Name = "RibbonTabItem_Collision"
            Me.RibbonTabItem_Collision.Panel = Me.RibbonPanel4
            resources.ApplyResources(Me.RibbonTabItem_Collision, "RibbonTabItem_Collision")
            '
            'RibbonTabItem6
            '
            Me.RibbonTabItem6.Name = "RibbonTabItem6"
            Me.RibbonTabItem6.Panel = Me.RibbonPanel6
            resources.ApplyResources(Me.RibbonTabItem6, "RibbonTabItem6")
            '
            'RibbonTabItem1
            '
            Me.RibbonTabItem1.Name = "RibbonTabItem1"
            Me.RibbonTabItem1.Panel = Me.RibbonPanel7
            resources.ApplyResources(Me.RibbonTabItem1, "RibbonTabItem1")
            '
            'ButtonItem95
            '
            Me.ButtonItem95.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
            Me.ButtonItem95.Name = "ButtonItem95"
            Me.ButtonItem95.Symbol = "58830"
            Me.ButtonItem95.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem95.SymbolSize = 12.0!
            '
            'ApplicationButton1
            '
            Me.ApplicationButton1.AutoExpandOnClick = True
            Me.ApplicationButton1.CanCustomize = False
            Me.ApplicationButton1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
            Me.ApplicationButton1.ImagePaddingHorizontal = 2
            Me.ApplicationButton1.ImagePaddingVertical = 2
            Me.ApplicationButton1.Name = "ApplicationButton1"
            Me.ApplicationButton1.ShowSubItems = False
            Me.ApplicationButton1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_SaveRom, Me.ButtonItem_LaunchROM, Me.ButtonItem3})
            resources.ApplyResources(Me.ApplicationButton1, "ApplicationButton1")
            '
            'ButtonItem_SaveRom
            '
            Me.ButtonItem_SaveRom.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_save_16px
            Me.ButtonItem_SaveRom.Name = "ButtonItem_SaveRom"
            Me.ButtonItem_SaveRom.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS)
            Me.ButtonItem_SaveRom.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem_SaveRom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_SaveRom.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem_SaveRom, "ButtonItem_SaveRom")
            '
            'ButtonItem_LaunchROM
            '
            Me.ButtonItem_LaunchROM.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_controller_16px
            Me.ButtonItem_LaunchROM.Name = "ButtonItem_LaunchROM"
            Me.ButtonItem_LaunchROM.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
            Me.ButtonItem_LaunchROM.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem_LaunchROM.SymbolSize = 12.0!
            resources.ApplyResources(Me.ButtonItem_LaunchROM, "ButtonItem_LaunchROM")
            '
            'ButtonItem3
            '
            resources.ApplyResources(Me.ButtonItem3, "ButtonItem3")
            Me.ButtonItem3.BeginGroup = True
            Me.ButtonItem3.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_cancel_16px
            Me.ButtonItem3.Name = "ButtonItem3"
            Me.ButtonItem3.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ButtonItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem3.SymbolSize = 12.0!
            '
            'ButtonItem_Undo
            '
            Me.ButtonItem_Undo.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_undo_16px
            Me.ButtonItem_Undo.Name = "ButtonItem_Undo"
            Me.ButtonItem_Undo.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
            Me.ButtonItem_Undo.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(122, Byte), Integer))
            Me.ButtonItem_Undo.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_Undo.SymbolSize = 12.0!
            '
            'ButtonItem_Redo
            '
            Me.ButtonItem_Redo.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_redo_16px
            Me.ButtonItem_Redo.Name = "ButtonItem_Redo"
            Me.ButtonItem_Redo.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY)
            Me.ButtonItem_Redo.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(122, Byte), Integer))
            Me.ButtonItem_Redo.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem_Redo.SymbolSize = 12.0!
            '
            'ButtonItem13
            '
            Me.ButtonItem13.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItem13.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem13.Name = "ButtonItem13"
            Me.ButtonItem13.SubItemsExpandWidth = 14
            Me.ButtonItem13.Symbol = "57669"
            Me.ButtonItem13.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ButtonItem13.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
            Me.ButtonItem13.SymbolSize = 32.0!
            resources.ApplyResources(Me.ButtonItem13, "ButtonItem13")
            '
            'Form_AreaEditor
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BottomLeftCornerSize = 0
            Me.BottomRightCornerSize = 0
            Me.Controls.Add(Me.ContextMenuBar1)
            Me.Controls.Add(Me.DockSite3)
            Me.Controls.Add(Me.DockSite9)
            Me.Controls.Add(Me.DockSite4)
            Me.Controls.Add(Me.DockSite2)
            Me.Controls.Add(Me.DockSite1)
            Me.Controls.Add(Me.DockSite5)
            Me.Controls.Add(Me.DockSite6)
            Me.Controls.Add(Me.DockSite8)
            Me.Controls.Add(Me.RibbonControl1)
            Me.KeyPreview = True
            Me.Name = "Form_AreaEditor"
            Me.TopLeftCornerSize = 0
            Me.TopRightCornerSize = 0
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.Panel_GLControl.ResumeLayout(False)
            Me.DockSite4.ResumeLayout(False)
            CType(Me.Bar_Controls, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Bar_Controls.ResumeLayout(False)
            Me.PanelDockContainer2.ResumeLayout(False)
            Me.PanelEx1.ResumeLayout(False)
            Me.PanelEx5.ResumeLayout(False)
            Me.PanelEx4.ResumeLayout(False)
            Me.PanelEx3.ResumeLayout(False)
            Me.PanelEx2.ResumeLayout(False)
            CType(Me.PictureBox_CamCntrWheel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_CamMoveCross, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_ObjRotWheel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_ObjRotCross, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_ObjCntrWheel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_ObjCntrCross, System.ComponentModel.ISupportInitialize).EndInit()
            Me.DockSite9.ResumeLayout(False)
            CType(Me.Bar_AreaViewer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Bar_AreaViewer.ResumeLayout(False)
            Me.PanelDockContainer3.ResumeLayout(False)
            Me.DockSite1.ResumeLayout(False)
            CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Bar1.ResumeLayout(False)
            Me.PanelDockContainer10.ResumeLayout(False)
            CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Bar2.ResumeLayout(False)
            Me.PanelDockContainer7.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.PanelDockContainer1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.PanelDockContainer8.ResumeLayout(False)
            CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonControl1.ResumeLayout(False)
            Me.RibbonControl1.PerformLayout()
            Me.RibbonPanel1.ResumeLayout(False)
            Me.RibbonPanel6.ResumeLayout(False)
            Me.RibbonPanel3.ResumeLayout(False)
            Me.RibbonPanel7.ResumeLayout(False)
            Me.RibbonPanel4.ResumeLayout(False)
            Me.RibbonPanel2.ResumeLayout(False)
            Me.RibbonPanel5.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel_GLControl As DevComponents.DotNetBar.PanelEx
        Friend WithEvents ListViewEx_Warps As DevComponents.DotNetBar.Controls.ListViewEx
        Friend WithEvents ColumnHeader2 As ColumnHeader
        Friend WithEvents ListViewEx_Objects As DevComponents.DotNetBar.Controls.ListViewEx
        Friend WithEvents ColumnHeader3 As ColumnHeader
        Friend WithEvents ColumnHeader1 As ColumnHeader
        Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
        Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
        Friend WithEvents DotNetBarManager1 As DevComponents.DotNetBar.DotNetBarManager
        Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
        Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
        Friend WithEvents PanelDockContainer1 As DevComponents.DotNetBar.PanelDockContainer
        Friend WithEvents DockContainerItem1 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
        Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
        Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
        Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
        Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
        Friend WithEvents Bar_Controls As DevComponents.DotNetBar.Bar
        Friend WithEvents PanelDockContainer2 As DevComponents.DotNetBar.PanelDockContainer
        Friend WithEvents DockContainerItem2 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents DockSite9 As DevComponents.DotNetBar.DockSite
        Friend WithEvents Bar_AreaViewer As DevComponents.DotNetBar.Bar
        Friend WithEvents PanelDockContainer3 As DevComponents.DotNetBar.PanelDockContainer
        Friend WithEvents DockContainerItem3 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
        Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
        Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
        Friend WithEvents PictureBox_CamCntrWheel As PictureBox
        Friend WithEvents PictureBox_CamMoveCross As PictureBox
        Friend WithEvents PictureBox_ObjRotWheel As PictureBox
        Friend WithEvents PictureBox_ObjRotCross As PictureBox
        Friend WithEvents PictureBox_ObjCntrWheel As PictureBox
        Friend WithEvents PictureBox_ObjCntrCross As PictureBox
        Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
        Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
        Friend WithEvents Slider_ObjMoveSpeed As DevComponents.DotNetBar.Controls.Slider
        Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents PanelEx4 As DevComponents.DotNetBar.PanelEx
        Friend WithEvents PanelEx5 As DevComponents.DotNetBar.PanelEx
        Friend WithEvents Slider_CamMoveSpeed As DevComponents.DotNetBar.Controls.Slider
        Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
        Friend WithEvents DockContainerItem6 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
        Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
        Friend WithEvents ColumnHeader4 As ColumnHeader
        Friend WithEvents ColumnHeader5 As ColumnHeader
        Friend WithEvents ColumnHeader6 As ColumnHeader
        Friend WithEvents ButtonItem_PasteWarpDefault As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonX_CamMode As DevComponents.DotNetBar.ButtonX
        Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItem_CamFly As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CamOrbit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItem_CamTop As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CamButtom As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CamLeft As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CamRight As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CamFront As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CamBack As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
        Friend WithEvents PanelDockContainer7 As DevComponents.DotNetBar.PanelDockContainer
        Friend WithEvents DockContainerItem4 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents PanelDockContainer8 As DevComponents.DotNetBar.PanelDockContainer
        Friend WithEvents DockContainerItem5 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents ListViewEx_CollVertices As DevComponents.DotNetBar.Controls.ListViewEx
        Friend WithEvents ColumnHeader7 As ColumnHeader
        Friend WithEvents ColumnHeader8 As ColumnHeader
        Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ListViewEx_ColFaces As DevComponents.DotNetBar.Controls.ListViewEx
        Friend WithEvents ColumnHeader9 As ColumnHeader
        Friend WithEvents ColumnHeader10 As ColumnHeader
        Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
        Friend WithEvents ColumnHeader11 As ColumnHeader
        Friend WithEvents ColumnHeader12 As ColumnHeader
        Friend WithEvents ColumnHeader13 As ColumnHeader
        Friend WithEvents ColumnHeader14 As ColumnHeader
        Friend WithEvents ButtonX_KeepOnButtom As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX_KeepOnTop As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX_KeepOnGround As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX_DropToBottom As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX_DropToTop As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ButtonX_DropToGround As DevComponents.DotNetBar.ButtonX
        Friend WithEvents ColumnHeader15 As ColumnHeader
        Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
        Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
        Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonPanel2 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents ApplicationButton1 As DevComponents.DotNetBar.ApplicationButton
        Friend WithEvents RibbonTabItem_Objects As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonTabItem_Warps As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents ButtonItem_Redo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents GalleryContainer2 As DevComponents.DotNetBar.GalleryContainer
        Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonX_ObjectsAdd As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
        Private WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ButtonItem_ObjectsCopy As DevComponents.DotNetBar.ButtonItem
        Private WithEvents buttonItem55 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem38 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem39 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem40 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem41 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem42 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem43 As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItem_PasteObjDefault As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjModelID As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjCombo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjBehavID As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjActs As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjBParams As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjPos As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteObjRot As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem44 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonPanel3 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonTabItem3 As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonPanel4 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonTabItem_Collision As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonBar7 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem_ExportObjectModel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar8 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem_ObjectsRemove As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonPanel5 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonBar6 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem47 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ImportModel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ImportVisualMap As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ImportCollision As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem53 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ExportVisualMap As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ExportCollision As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar5 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer8 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainer9 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItem_Area As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItem_AddArea As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_RemoveArea As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonTabItem5 As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonBar9 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer11 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem_ObjectsEditorCmd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ResetObjToDefault As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItem_CopyObjCmdAsHex As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer10 As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ButtonItem_CopyWarpCmdAsHex As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonX_WarpsEditCmd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem69 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar10 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonX_WarpsRemove As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBar11 As DevComponents.DotNetBar.RibbonBar
        Private WithEvents ButtonX_PasteWarpDefault As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ItemContainer12 As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ButtonX_WarpsCopy As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItem73 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem81 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar12 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonX_WarpsAdd As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar14 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBar15 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBar13 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer13 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem83 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem84 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar16 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBar17 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem85 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem86 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar18 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer14 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem_DropToGround As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_DropToTop As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_DropToBottom As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer15 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem_KeepOnGround As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_KeepOnTop As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_KeepOnButtom As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonX_WarpsAddConnectedWarp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonX_WarpsAddPaintingWarp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem95 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_Undo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_CM_Objects As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem23 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteWarpDestLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteWarpDestArea As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_PasteWarpDestWarp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem1_CM_Warps As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem37 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem63 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem64 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem65 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem68 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonPanel6 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonTabItem6 As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents ButtonItem_SaveRom As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_LaunchROM As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar21 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBar20 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBar19 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem_DrawBackfaces As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ButtonItem_DrawObjects As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem_DrawFill As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ButtonItem_DrawOutline As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem_ViewVisualMap As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ButtonItem_ViewColMap As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar23 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents CheckBoxItem_PerspectiveMode As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItem_OrthoMode As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents RibbonBar22 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar24 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer17 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar25 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer16 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer18 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem14 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem15 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItem16 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer19 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem21 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer20 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem20 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem22 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem24 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem25 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem26 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelDockContainer10 As DevComponents.DotNetBar.PanelDockContainer
        Friend WithEvents AdvPropertyGrid1 As DevComponents.DotNetBar.AdvPropertyGrid
        Friend WithEvents DockContainerItem7 As DevComponents.DotNetBar.DockContainerItem
        Friend WithEvents Panel1 As Panel
        Friend WithEvents Panel2 As Panel
        Friend WithEvents ButtonItem_WarpsAddInstantWarp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer21 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem27 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem28 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar26 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ItemContainer22 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItem29 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ChangeObjectCombo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem30 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar27 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem31 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem32 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem33 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonPanel7 As DevComponents.DotNetBar.RibbonPanel
        Friend WithEvents RibbonBar28 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem34 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
        Friend WithEvents RibbonBar30 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem36 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBar29 As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItem35 As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
