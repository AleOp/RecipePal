using System;
using System.Linq;
using System.Text;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using RecipePal.Core.Helpers;
using RecipePal.Core.Models;
using RecipePal.Core.ViewModels;

namespace RecipePal.Droid.Views.Helpers
{
    public class RecipeDetailAdapter : MvxRecyclerAdapter
    {
        private RecipeDetailViewType _currRecipeDetailViewType;
        private readonly RecipeDetailViewModel _viewModel;

        public RecipeDetailAdapter(RecipeDetailViewModel viewModel, IMvxAndroidBindingContext context) : base(context)
        {
            _viewModel = viewModel;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Enum.TryParse(viewType.ToString(), out _currRecipeDetailViewType);
            return base.OnCreateViewHolder(parent, viewType);
        }

        protected override View InflateViewForHolder(ViewGroup parent, int viewType,
            IMvxAndroidBindingContext bindingContext)
        {
            var view = base.InflateViewForHolder(parent, viewType, bindingContext);

            switch (_currRecipeDetailViewType)
            {
                case RecipeDetailViewType.Main:
                    PopulateWithMainData(view);
                    break;
                case RecipeDetailViewType.Ingredients:
                    PopulateIngredients(view);
                    break;
                case RecipeDetailViewType.Description:
                    PopulateDescription(view);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return view;
        }

        private void PopulateDescription(View view)
        {
            var recipe = _viewModel.RecipeDictionary[(int) RecipeDictionaryKey.Recipe]
                .Cast<Recipe>()
                .FirstOrDefault();
            var description = view.FindViewById<TextView>(Resource.Id.recipeDescription);
            description.Text = recipe.Description;
        }

        private void PopulateIngredients(View view)
        {
            var ingredientsView = view.FindViewById<TextView>(Resource.Id.ingredients);
            var ingredientsStringBuilder = new StringBuilder();

            var ingredientsList =
                _viewModel.RecipeDictionary[(int) RecipeDictionaryKey.Ingredients].Cast<Ingredient>().ToArray();

            var ingredientsQuantityList =
                _viewModel.RecipeDictionary[(int) RecipeDictionaryKey.QuantityTypes].Cast<QuantityType>().ToArray();

            foreach (var ingredient in ingredientsList)
            {
                var quantityString = "";
                var quantityTypeString = "";

                if (ingredient.Quantity > 0)
                {
                    quantityString = ingredient.Quantity.ToString("F1");

                    if (ingredient.QuantityTag != -1)
                    {
                        quantityTypeString = ingredientsQuantityList.First(x => x.Tag == ingredient.QuantityTag)
                            .QuantityName;
                    }
                }

                ingredientsStringBuilder.AppendLine($" - {ingredient.Name},\t{quantityString} {quantityTypeString}");
            }
            ingredientsView.Text = ingredientsStringBuilder.ToString();
        }

        private void PopulateWithMainData(View view)
        {
            var recipe = _viewModel.RecipeDictionary[(int) RecipeDictionaryKey.Recipe]
                .Cast<Recipe>()
                .FirstOrDefault();

            var difficulty = view.FindViewById<TextView>(Resource.Id.difficulty);
            var cookTime = view.FindViewById<TextView>(Resource.Id.cookTime);
            var serves = view.FindViewById<TextView>(Resource.Id.serves);

            cookTime.Text = $"{recipe.CookTime} min";
            serves.Text = recipe.Serves.ToString();
            switch (recipe.Difficulty)
            {
                case 0:
                    difficulty.Text = "EASY";
                    difficulty.SetTextColor(Color.Green);
                    break;
                case 1:
                    difficulty.Text = "MEDIUM";
                    difficulty.SetTextColor(Color.Orange);
                    break;
                case 2:
                    difficulty.Text = "HARD";
                    difficulty.SetTextColor(Color.Red);
                    break;
            }
        }
    }
}