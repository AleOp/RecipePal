// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace RecipePal.iOS.Resources.CustomCells
{
    [Register ("CategorizedRecipesCell")]
    partial class CategorizedRecipesCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView frameView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeCookTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView RecipeImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (frameView != null) {
                frameView.Dispose ();
                frameView = null;
            }

            if (RecipeCookTime != null) {
                RecipeCookTime.Dispose ();
                RecipeCookTime = null;
            }

            if (RecipeImage != null) {
                RecipeImage.Dispose ();
                RecipeImage = null;
            }

            if (RecipeName != null) {
                RecipeName.Dispose ();
                RecipeName = null;
            }
        }
    }
}