using System;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Models;
using UIKit;

namespace RecipePal.iOS.Resources.CustomCells
{
    public partial class RecipeDetailCell : MvxTableViewCell
    {
        public RecipeDetailCell(IntPtr handle) : base(handle)
        {
        }

        public void FillCellWithData(Recipe recipe)
        {         
            RecipeDifficulty.SelectedSegment = PrepareDifficultySegment(recipe?.Difficulty);
            RecipeCookTime.Text = $"{recipe?.CookTime} min";
            RecipeServes.Text = recipe?.Serves.ToString();       
        }

        private int PrepareDifficultySegment(int? recipeDifficulty)
        {
            var tintColor = UIColor.Gray;

            switch (recipeDifficulty)
            {
                case null:
                    break;
                case 0:
                    tintColor = UIColor.Blue;
                    break;
                case 1:
                    tintColor = UIColor.Orange;
                    break;
                case 2:
                    tintColor = UIColor.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            RecipeDifficulty.TintColor = tintColor;

            if (recipeDifficulty == null)
                RecipeDifficulty.Momentary = true;

            return recipeDifficulty ?? 0;
        }
    }
}