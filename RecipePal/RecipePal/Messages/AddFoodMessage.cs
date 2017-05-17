using System.Collections.Generic;
using MvvmCross.Plugins.Messenger;

namespace RecipePal.Core.Messages
{
    public class AddFoodMessage : MvxMessage
    {
        public string IngredientName { get; }
        public IList<int> RecipesTagList { get; }

        public AddFoodMessage(object sender, string ingredientName, IList<int> recipesTagList) : base(sender)
        {
            IngredientName = ingredientName;
            RecipesTagList = recipesTagList;
        }
    }
}