Imports DevExpress.XtraBars.Helpers
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace WindowsApplication1
    Public Class CustomSkinHelper
        Public Shared Sub InitSkinGallery(ByVal galleryItem As DevExpress.XtraBars.RibbonGalleryBarItem)
            SkinHelper.InitSkinGallery(galleryItem)
            RemoveSkinGroups(galleryItem)
        End Sub
        Private Shared Sub RemoveSkinGroups(ByVal galleryItem As DevExpress.XtraBars.RibbonGalleryBarItem)
            Dim groupIndex = 0
            galleryItem.Gallery.Groups.RemoveAt(groupIndex)
            'hide skins where connection line is not painted
            Dim skinsToHide = New String() { "Blueprint", "Whiteprint", "Darkroom", "Foggy", "Metropolis", "Metropolis Dark", "Seven", "Sharp", "Sharp Plus" }
            HideSkins(galleryItem, skinsToHide)
        End Sub
        Private Shared Sub HideSkins(ByVal galleryItem As DevExpress.XtraBars.RibbonGalleryBarItem, ByVal skinsToHide() As String)
            For i = 0 To galleryItem.Gallery.Groups.Count - 1
                Dim group = galleryItem.Gallery.Groups(i)
                If group Is Nothing Then
                    Continue For
                End If
                For j = 0 To group.Items.Count - 1
                    Dim item = group.Items(j)
                    If item Is Nothing Then
                        Continue For
                    End If
                    For Each skin In skinsToHide
                        If String.Equals(item.Caption, skin) Then
                            item.Visible = False
                        End If
                    Next skin
                Next j
            Next i
        End Sub
    End Class
End Namespace
