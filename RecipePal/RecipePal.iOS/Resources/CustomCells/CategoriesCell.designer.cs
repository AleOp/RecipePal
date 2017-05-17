// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RecipePal.iOS.Resources.CustomCells
{
    [Register ("CategoriesCell")]
    partial class CategoriesCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView CategoryImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CategoryName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView frameView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CategoryImage != null) {
                CategoryImage.Dispose ();
                CategoryImage = null;
            }

            if (CategoryName != null) {
                CategoryName.Dispose ();
                CategoryName = null;
            }

            if (frameView != null) {
                frameView.Dispose ();
                frameView = null;
            }
        }
    }
}