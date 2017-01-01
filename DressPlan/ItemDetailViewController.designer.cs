// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DressPlan
{
    [Register ("ItemDetailViewController")]
    partial class ItemDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ItemNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ItemPhoto { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ItemNameText != null) {
                ItemNameText.Dispose ();
                ItemNameText = null;
            }

            if (ItemPhoto != null) {
                ItemPhoto.Dispose ();
                ItemPhoto = null;
            }
        }
    }
}