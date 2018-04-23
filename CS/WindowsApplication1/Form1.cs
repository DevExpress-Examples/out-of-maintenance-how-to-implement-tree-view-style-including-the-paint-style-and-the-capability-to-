using DevExpress.XtraTreeList.Design;
using System;
using System.Collections.Generic;

namespace WindowsApplication1 {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            InitSkins();
            InitTreeList();
        }
        private void InitSkins() {
            CustomSkinHelper.InitSkinGallery(skinGalleryBarItem);
        }
        private void InitTreeList() {
            treeList1.BeginUpdate();
            try {
                InitData();                
            } finally {
                treeList1.EndUpdate();
            }
        }        
        private void InitData() {
            treeList1.ClearNodes();
            treeList1.Columns.Clear();
            new XViews(treeList1);
        }
        private void btnExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExpandAll(treeList1);
        }
        private void ExpandAll(CustomTreeList tl) {
            tl.ExpandAll();
        }
        private void CollapseAll(CustomTreeList tl) {
            tl.CollapseAll();
        }
        private void btnCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            CollapseAll(treeList1);
        }
    }
}
