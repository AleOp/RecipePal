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
    [Register ("RecipeDescriptionCell")]
    partial class RecipeDescriptionCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RecipeDescriptionLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RecipeDescriptionLabel != null) {
                RecipeDescriptionLabel.Dispose ();
                RecipeDescriptionLabel = null;
            }
        }
    }
}