﻿// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace RecipePal.iOS.Resources.CustomCells
{
    [Register ("RecipeIngredientsCell")]
    partial class RecipeIngredientsCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeIngredientsLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RecipeIngredientsLabel != null) {
                RecipeIngredientsLabel.Dispose ();
                RecipeIngredientsLabel = null;
            }
        }
    }
}