using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Helpers;
using RecipePal.Core.Messages;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class FoodResultsViewModel : BaseCustomViewModel
    {
        private readonly IFoodSearchService _foodSearchService;
        private IMvxCommand _addFoodCommand;
        private IList<Ingredient> _backupIngredientsList;
        private IList<Ingredient> _food;
        private IMvxAsyncCommand _searchFoodAsyncCommand;


        public FoodResultsViewModel(IFoodSearchService foodSearchService)
        {
            _foodSearchService = foodSearchService;
        }

        public IList<Ingredient> FoodList
        {
            get { return _food; }
            set { SetProperty(ref _food, value); }
        }

        public IMvxAsyncCommand SearchForFoodAsyncCommand
        {
            get
            {
                _searchFoodAsyncCommand = _searchFoodAsyncCommand ??
                                          new MvxAsyncCommand<string>(SearchFoodAsyncCommandHandler);
                return _searchFoodAsyncCommand;
            }
        }

        public IMvxCommand AddFoodCommand
        {
            get
            {
                _addFoodCommand = _addFoodCommand ?? new MvxCommand<Ingredient>(AddIngredientCommandHandler);
                return _addFoodCommand;
            }
        }


        private async Task SearchFoodAsyncCommandHandler(string name)
        {
            _backupIngredientsList = await _foodSearchService.SearchFood(name);

            FoodList = new List<Ingredient>(_backupIngredientsList.Distinct(new FoodComparer()));
        }


        private void AddIngredientCommandHandler(Ingredient ingredient)
        {
            var recipesTags = GetRecipieIdsFromPickedIngredients(ingredient.Name);
            Mvx.Resolve<IMvxMessenger>().Publish(new AddFoodMessage(this, ingredient.Name, recipesTags));
        }

        private IList<int> GetRecipieIdsFromPickedIngredients(string name)
        {
            var recipiesTags = new List<int>();

            foreach (var ingredient in _backupIngredientsList)
                if (string.Equals(name, ingredient.Name, StringComparison.InvariantCultureIgnoreCase))
                    recipiesTags.Add(ingredient.RecipeTag);

            return recipiesTags;
        }
    }
}