using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsApplication1 {
    [ToolboxItem(true)]
    internal class CustomTreeList : TreeList {
        public CustomTreeList() {
            SubscribeEvents();
            EnableShowIndentAsRowStyle();
            SetTreeViewStyleSelection();
        }
        private bool _TreeViewStyle = true;

        public bool TreeViewStyle {
            get {
                return _TreeViewStyle;
            }
        }
        private void SetTreeViewStyleSelection() {
            if (TreeViewStyle) {
                OptionsBehavior.Editable = false;
                OptionsView.ShowColumns = false;
                OptionsView.ShowIndicator = false;
                OptionsView.ShowHorzLines = false;
                CustomDrawNodeCell += CustomTreeList_CustomDrawNodeCell;
            } else {
                OptionsBehavior.Editable = true;
                OptionsView.ShowColumns = true;
                OptionsView.ShowIndicator = true;
                OptionsView.ShowHorzLines = true;
                CustomDrawNodeCell -= CustomTreeList_CustomDrawNodeCell;
            }
        }
        private void SubscribeEvents() {
            DoubleClick += CustomTreeList_DoubleClick;
        }

        private SolidBrush GetSolidBrush(Color systemColor) {
            var color = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, systemColor);
            var brush = new SolidBrush(color);
            return brush;
        }
        private void CustomTreeList_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e) {
            var tl = this;
            if (e.Node == tl.FocusedNode) {
                var brush = GetSolidBrush(SystemColors.Window);
                e.Cache.FillRectangle(brush, e.Bounds);                
                var highlightBrush = GetSolidBrush(SystemColors.Highlight);
                var R = new Rectangle(e.EditViewInfo.ContentRect.Left, e.EditViewInfo.ContentRect.Top,
                    Convert.ToInt32(e.Graphics.MeasureString(e.CellText, e.Appearance.Font).Width + 1), e.EditViewInfo.ContentRect.Height);
                e.Cache.FillRectangle(highlightBrush, R);                                
                var highlightForeBrush = GetSolidBrush(SystemColors.HighlightText);
                var format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;                                
                e.Cache.DrawString(e.CellText, e.Appearance.GetFont(), highlightForeBrush, R, format);
                e.Handled = true;
            }
        }
        private void EnableShowIndentAsRowStyle() {
            OptionsView.ShowIndentAsRowStyle = true;
        }
        private void CustomTreeList_DoubleClick(object sender, EventArgs e) {
            var p = PointToClient(Control.MousePosition);
            var ht = CalcHitInfo(p);
            if (ht != null && ht.Node != null && ht.HitInfoType == HitInfoType.RowIndent) {
                var node = ht.Node;
                var ri = ViewInfo.RowsInfo[node];
                if (ri != null && ri.IndentItems.Count > 0) {
                    var levelByIndent = GetLevelByIndent(ri, p, ViewInfo.RC.LevelWidth);
                    DoCollapse(node, levelByIndent);
                }
            }
        }
        private void DoCollapse(TreeListNode node, int levelByIndent) {
            var resultNode = FindNodeByLevel(node, levelByIndent);
            SetCollapsed(resultNode);
        }
        private static void SetCollapsed(TreeListNode node) {
            if (node != null) {
                node.Expanded = false; 
            }
        }
        private int GetLevelByIndent(RowInfo ri, Point point, int levelWidth) {
            var currentRect = ri.IndentBounds;
            currentRect.Width = levelWidth;
            for (var i = 0; i < ri.IndentItems.Count; i++) {
                currentRect.X = levelWidth * (i + 1);
                if (currentRect.Contains(point)) {
                    return i + 1;
                }
            }
            return 0;
        }
        internal TreeListNode FindNodeByLevel(TreeListNode node, int level) {
            var resultNode = GetParentByLevel(node, level);
            return resultNode;
        }
        private TreeListNode GetParentByLevel(TreeListNode node, int level) {
            var parentNode = node.ParentNode;
            while (parentNode != null) {
                if (parentNode.Level == level) {
                    return parentNode;
                }
                parentNode = parentNode.ParentNode;
            }
            return null;
        }
    }
}
