using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsApplication1 {
    public class CustomSkinHelper {
        public static void InitSkinGallery(DevExpress.XtraBars.RibbonGalleryBarItem galleryItem) {
            SkinHelper.InitSkinGallery(galleryItem);
            RemoveSkinGroups(galleryItem);
        }
        private static void RemoveSkinGroups(DevExpress.XtraBars.RibbonGalleryBarItem galleryItem) {
            var groupIndex = 0;
            galleryItem.Gallery.Groups.RemoveAt(groupIndex);
            //hide skins where connection line is not painted
            var skinsToHide = new string[] { "Blueprint", "Whiteprint", "Darkroom", "Foggy", "Metropolis", "Metropolis Dark", "Seven", "Sharp", "Sharp Plus" };
            HideSkins(galleryItem, skinsToHide);
        }
        private static void HideSkins(DevExpress.XtraBars.RibbonGalleryBarItem galleryItem, string[] skinsToHide) {
            for (var i = 0; i < galleryItem.Gallery.Groups.Count; i++) {
                var group = galleryItem.Gallery.Groups[i];
                if (group == null) {
                    continue;
                }
                for (var j = 0; j < group.Items.Count; j++) {
                    var item = group.Items[j];
                    if (item == null) {
                        continue;
                    }
                    foreach (var skin in skinsToHide) {
                        if (String.Equals(item.Caption, skin)) {
                            item.Visible = false;
                        }
                    }
                }
            }
        }
    }
}
