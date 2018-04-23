Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.treeList1 = New WindowsApplication1.CustomTreeList()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.menuSkins = New DevExpress.XtraBars.BarSubItem()
			Me.btnExpandAll = New DevExpress.XtraBars.BarButtonItem()
			Me.btnCollapseAll = New DevExpress.XtraBars.BarButtonItem()
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.skinGalleryBarItem = New DevExpress.XtraBars.RibbonGalleryBarItem()
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 148)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(806, 341)
			Me.treeList1.TabIndex = 0
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Lilian"
			' 
			' menuSkins
			' 
			Me.menuSkins.Caption = "Skins"
			Me.menuSkins.Id = 4
			Me.menuSkins.Name = "menuSkins"
			' 
			' btnExpandAll
			' 
			Me.btnExpandAll.Caption = "Expand All"
			Me.btnExpandAll.Id = 0
			Me.btnExpandAll.Name = "btnExpandAll"
'			Me.btnExpandAll.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.btnExpandAll_ItemClick);
			' 
			' btnCollapseAll
			' 
			Me.btnCollapseAll.Caption = "Collaspe All"
			Me.btnCollapseAll.Id = 1
			Me.btnCollapseAll.Name = "btnCollapseAll"
'			Me.btnCollapseAll.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.btnCollapseAll_ItemClick);
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.btnExpandAll, Me.btnCollapseAll, Me.menuSkins, Me.skinGalleryBarItem})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 2
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(806, 148)
			Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
			' 
			' skinGalleryBarItem
			' 
			Me.skinGalleryBarItem.Caption = "ribbonGalleryBarItem1"
			Me.skinGalleryBarItem.Id = 1
			Me.skinGalleryBarItem.Name = "skinGalleryBarItem"
			' 
			' ribbonPage1
			' 
			Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup2, Me.ribbonPageGroup1})
			Me.ribbonPage1.Name = "ribbonPage1"
			Me.ribbonPage1.Text = "Main menu"
			' 
			' ribbonPageGroup2
			' 
			Me.ribbonPageGroup2.ItemLinks.Add(Me.btnExpandAll)
			Me.ribbonPageGroup2.ItemLinks.Add(Me.btnCollapseAll)
			Me.ribbonPageGroup2.Name = "ribbonPageGroup2"
			Me.ribbonPageGroup2.ShowCaptionButton = False
			Me.ribbonPageGroup2.Text = "Menu"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.AllowTextClipping = False
			Me.ribbonPageGroup1.ItemLinks.Add(Me.skinGalleryBarItem)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.ShowCaptionButton = False
			Me.ribbonPageGroup1.Text = "Skin Gallery"
			' 
			' ribbonStatusBar1
			' 
			Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 489)
			Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
			Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
			Me.ribbonStatusBar1.Size = New System.Drawing.Size(806, 23)
			' 
			' Form1
			' 
			Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(806, 512)
			Me.Controls.Add(Me.treeList1)
			Me.Controls.Add(Me.ribbonStatusBar1)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "Form1"
			Me.Ribbon = Me.ribbonControl1
			Me.StatusBar = Me.ribbonStatusBar1
			Me.Text = "Form1"
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private treeList1 As WindowsApplication1.CustomTreeList
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private WithEvents btnExpandAll As DevExpress.XtraBars.BarButtonItem
		Private WithEvents btnCollapseAll As DevExpress.XtraBars.BarButtonItem
		Private menuSkins As DevExpress.XtraBars.BarSubItem
		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private skinGalleryBarItem As DevExpress.XtraBars.RibbonGalleryBarItem
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
	End Class
End Namespace

