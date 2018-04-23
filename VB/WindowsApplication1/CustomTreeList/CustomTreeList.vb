Imports Microsoft.VisualBasic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace WindowsApplication1
	<ToolboxItem(True)> _
	Friend Class CustomTreeList
		Inherits TreeList
		Public Sub New()
			SubscribeEvents()
			EnableShowIndentAsRowStyle()
			SetTreeViewStyleSelection()
		End Sub
		Private _TreeViewStyle As Boolean = True

		Public ReadOnly Property TreeViewStyle() As Boolean
			Get
				Return _TreeViewStyle
			End Get
		End Property
		Private Sub SetTreeViewStyleSelection()
			If TreeViewStyle Then
				OptionsBehavior.Editable = False
				OptionsView.ShowColumns = False
				OptionsView.ShowIndicator = False
				OptionsView.ShowHorzLines = False
				AddHandler CustomDrawNodeCell, AddressOf CustomTreeList_CustomDrawNodeCell
			Else
				OptionsBehavior.Editable = True
				OptionsView.ShowColumns = True
				OptionsView.ShowIndicator = True
				OptionsView.ShowHorzLines = True
				RemoveHandler CustomDrawNodeCell, AddressOf CustomTreeList_CustomDrawNodeCell
			End If
		End Sub
		Private Sub SubscribeEvents()
			AddHandler DoubleClick, AddressOf CustomTreeList_DoubleClick
		End Sub

		Private Function GetSolidBrush(ByVal systemColor As Color) As SolidBrush
			Dim color = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, systemColor)
			Dim brush = New SolidBrush(color)
			Return brush
		End Function
		Private Sub CustomTreeList_CustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs)
			Dim tl = Me
            If Object.Equals(e.Node, tl.FocusedNode) Then
                Dim brush = GetSolidBrush(SystemColors.Window)
                e.Graphics.FillRectangle(brush, e.Bounds)
                Dim highlightBrush = GetSolidBrush(SystemColors.Highlight)
                Dim R = New Rectangle(e.EditViewInfo.ContentRect.Left, e.EditViewInfo.ContentRect.Top, Convert.ToInt32(e.Graphics.MeasureString(e.CellText, e.Appearance.Font).Width + 1), e.EditViewInfo.ContentRect.Height)
                e.Graphics.FillRectangle(highlightBrush, R)
                Dim highlightForeBrush = GetSolidBrush(SystemColors.HighlightText)
                Dim format = New StringFormat()
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(e.CellText, e.Appearance.Font, highlightForeBrush, R, format)
                e.Handled = True
            End If
		End Sub
		Private Sub EnableShowIndentAsRowStyle()
			OptionsView.ShowIndentAsRowStyle = True
		End Sub
		Private Sub CustomTreeList_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim p = PointToClient(Control.MousePosition)
			Dim ht = CalcHitInfo(p)
			If ht IsNot Nothing AndAlso ht.Node IsNot Nothing AndAlso ht.HitInfoType = HitInfoType.RowIndent Then
				Dim node = ht.Node
				Dim ri = ViewInfo.RowsInfo(node)
				If ri IsNot Nothing AndAlso ri.IndentInfo.IndentItems.Count > 0 Then
					Dim levelByIndent = GetLevelByIndent(ri.IndentInfo, p, ViewInfo.RC.LevelWidth)
					DoCollapse(node, levelByIndent)
				End If
			End If
		End Sub
		Private Sub DoCollapse(ByVal node As TreeListNode, ByVal levelByIndent As Integer)
			Dim resultNode = FindNodeByLevel(node, levelByIndent)
			SetCollapsed(resultNode)
		End Sub
		Private Shared Sub SetCollapsed(ByVal node As TreeListNode)
			If node IsNot Nothing Then
				node.Expanded = False
			End If
		End Sub
		Private Function GetLevelByIndent(ByVal indentInfo As IndentInfo, ByVal point As Point, ByVal levelWidth As Integer) As Integer
			Dim currentRect = indentInfo.Bounds
			currentRect.Width = levelWidth
			For i = 0 To indentInfo.IndentItems.Count - 1
				currentRect.X = levelWidth * (i + 1)
				If currentRect.Contains(point) Then
					Return i + 1
				End If
			Next i
			Return 0
		End Function
		Friend Function FindNodeByLevel(ByVal node As TreeListNode, ByVal level As Integer) As TreeListNode
			Dim resultNode = GetParentByLevel(node, level)
			Return resultNode
		End Function
		Private Function GetParentByLevel(ByVal node As TreeListNode, ByVal level As Integer) As TreeListNode
			Dim parentNode = node.ParentNode
			Do While parentNode IsNot Nothing
				If parentNode.Level = level Then
					Return parentNode
				End If
				parentNode = parentNode.ParentNode
			Loop
			Return Nothing
		End Function
	End Class
End Namespace
