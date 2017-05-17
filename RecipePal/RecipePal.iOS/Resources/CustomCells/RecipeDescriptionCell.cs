using System;
using UIKit;

namespace RecipePal.iOS.Resources.CustomCells
{
    public partial class RecipeDescriptionCell : UITableViewCell
    {
        public RecipeDescriptionCell(IntPtr handle) : base(handle)
        {
        }

        public void FillCellWithData(string description)
        {
            RecipeDescriptionLabel.Text = description;
        }
    }
}