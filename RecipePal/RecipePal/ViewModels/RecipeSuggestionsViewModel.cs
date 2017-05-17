using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using RecipePal.Core.Models;

namespace RecipePal.Core.ViewModels
{
    public class RecipeSuggestionsViewModel : BaseCustomViewModel<Dictionary<int, MvxObservableCollection<Recipe>>>
    {
        private Dictionary<int, MvxObservableCollection<Recipe>> _matchedRecipesList;
        private IMvxCommand _showRecipeDetailCommand;

        public Dictionary<int, MvxObservableCollection<Recipe>> MatchedRecipesList
        {
            get { return _matchedRecipesList; }
            set { SetProperty(ref _matchedRecipesList, value); }
        }

        public IMvxCommand ShowRecipeDetailCommand
        {
            get
            {
                _showRecipeDetailCommand = _showRecipeDetailCommand ??
                                           new MvxCommand<Recipe>(ShowRecipeDetailCommandHandler);
                return _showRecipeDetailCommand;
            }
        }

        protected override void InitWithReceivedData(Dictionary<int, MvxObservableCollection<Recipe>> @object)
        {
            MatchedRecipesList = new Dictionary<int, MvxObservableCollection<Recipe>>(@object);
        }

        private void ShowRecipeDetailCommandHandler(Recipe recipe)
        {
            ShowViewModel<RecipeDetailViewModel>(recipe);
        }
    }
}