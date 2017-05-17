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
    [Register ("RecipeDetailCell")]
    partial class RecipeDetailCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeCookTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl RecipeDifficulty { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeServes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewFrame { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RecipeCookTime != null) {
                RecipeCookTime.Dispose ();
                RecipeCookTime = null;
            }

            if (RecipeDifficulty != null) {
                RecipeDifficulty.Dispose ();
                RecipeDifficulty = null;
            }

            if (RecipeServes != null) {
                RecipeServes.Dispose ();
                RecipeServes = null;
            }

            if (RecipeTitle != null) {
                RecipeTitle.Dispose ();
                RecipeTitle = null;
            }

            if (ViewFrame != null) {
                ViewFrame.Dispose ();
                ViewFrame = null;
            }
        }
    }
}