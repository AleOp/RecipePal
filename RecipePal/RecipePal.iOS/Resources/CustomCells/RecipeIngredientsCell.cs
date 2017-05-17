using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecipePal.Core.Helpers;
using RecipePal.Core.Models;
using UIKit;

namespace RecipePal.iOS.Resources.CustomCells
{
    public partial class RecipeIngredientsCell : UITableViewCell
    {
        public RecipeIngredientsCell(IntPtr handle) : base(handle)
        {
        }

        public void FillCellWithData(Dictionary<int, ICollection<IDataEntity>> recipeDictionary)
        {
            StringBuilder ingredientsStringBuilder = SeparateDataFromRecipieDictionary(recipeDictionary);
            RecipeIngredientsLabel.Text = ingredientsStringBuilder.ToString();
        }

        private StringBuilder SeparateDataFromRecipieDictionary(Dictionary<int, ICollection<IDataEntity>> recipeDictionary)
        {
            var ingredientsStringBuilder = new StringBuilder();

            var ingredientsList =
                recipeDictionary[(int) RecipeDictionaryKey.Ingredients].Cast<Ingredient>().ToArray();

            var ingredientsQuantityList =
                recipeDictionary[(int) RecipeDictionaryKey.QuantityTypes].Cast<QuantityType>().ToArray();

            foreach (var ingredient in ingredientsList)
            {
                var quantityString = "";
                var quantityTypeString = "";

                if (ingredient.Quantity > 0)
                {
                    quantityString = ingredient.Quantity.ToString("F1");

                    if (ingredient.QuantityTag != -1)
                    {
                        quantityTypeString = ingredientsQuantityList.First(x=>x.Tag == ingredient.QuantityTag).QuantityName;
                    }
                }

                ingredientsStringBuilder.AppendLine($" - {ingredient.Name},\t{quantityString} {quantityTypeString}");
            }

            return ingredientsStringBuilder;
        }
    }
}