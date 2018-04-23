Imports Microsoft.VisualBasic
Imports DevExpress.XtraTreeList.Design
Imports System
Imports System.Collections.Generic

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm
		Public Sub New()
			InitializeComponent()
			InitSkins()
			InitTreeList()
		End Sub
		Private Sub InitSkins()
			CustomSkinHelper.InitSkinGallery(skinGalleryBarItem)
		End Sub
		Private Sub InitTreeList()
			treeList1.BeginUpdate()
			Try
				InitData()
			Finally
				treeList1.EndUpdate()
			End Try
		End Sub
		Private Sub InitData()
			treeList1.ClearNodes()
			treeList1.Columns.Clear()
			Dim TempXViews As XViews = New XViews(treeList1)
		End Sub
		Private Sub btnExpandAll_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExpandAll.ItemClick
			ExpandAll(treeList1)
		End Sub
		Private Sub ExpandAll(ByVal tl As CustomTreeList)
			tl.ExpandAll()
		End Sub
		Private Sub CollapseAll(ByVal tl As CustomTreeList)
			tl.CollapseAll()
		End Sub
		Private Sub btnCollapseAll_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCollapseAll.ItemClick
			CollapseAll(treeList1)
		End Sub
	End Class
End Namespace
