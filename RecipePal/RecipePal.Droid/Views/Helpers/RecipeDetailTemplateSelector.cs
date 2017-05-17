using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace RecipePal.Droid.Views.Helpers
{
    public class RecipeDetailTemplateSelector : IMvxTemplateSelector
    {
        public int GetItemViewType(object forItemObject)
        {
            var value = forItemObject as int?;
            return value ?? -1;
        }

        public int GetItemLayoutId(int fromViewType)
        {
            RecipeDetailViewType recipeViewType;
            System.Enum.TryParse(fromViewType.ToString(), out recipeViewType);

            switch (recipeViewType)
            {
                case RecipeDetailViewType.Main:
                    return Resource.Layout.recipe_detail_main_item;
                case RecipeDetailViewType.Ingredients:
                    return Resource.Layout.recipe_detail_ingredients;
                case RecipeDetailViewType.Description:
                    return Resource.Layout.recipe_detail_description;
                default:
                    return 0;
            }
        }
    }
}