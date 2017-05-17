using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Messages;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class MatchRecipeViewModel : BaseCustomViewModel
    {
        private readonly IMatchRecipeService _matchRecipeService;

        private readonly Dictionary<string, List<int>> _recipiesIdList =
            new Dictionary<string, List<int>>();
        private MvxObservableCollection<string> _foodStuff =
            new MvxObservableCollection<string>();

        private MvxSubscriptionToken _addFoodToken;
        private MvxSubscriptionToken _deleteFoodToken;
        
        private bool _isEnoughFood;
        private bool _isTableNotEmpty;
        private IMvxAsyncCommand _matchRecipiesAsyncCommand;

        public MatchRecipeViewModel(IMvxMessenger messenger, IMatchRecipeService matchRecipeService)
        {
            _matchRecipeService = matchRecipeService;
            _addFoodToken = messenger.Subscribe<AddFoodMessage>(AddFoodMessageHandler);
            _deleteFoodToken = messenger.Subscribe<DeleteFoodMessage>(DeleteFoodMessageHandler);
        }


        public IMvxAsyncCommand MatchRecipiesAsyncCommand
        {
            get
            {
                _matchRecipiesAsyncCommand = _matchRecipiesAsyncCommand ??
                                             new MvxAsyncCommand(MatchRecipiesAsyncCommandHandler);
                return _matchRecipiesAsyncCommand;
            }
        }

        public MvxObservableCollection<string> FoodStuff
        {
            get { return _foodStuff; }
            set { SetProperty(ref _foodStuff, value); }
        }

        public bool IsEnoughFood
        {
            get { return _isEnoughFood; }
            set { SetProperty(ref _isEnoughFood, value); }
        }

        public bool IsTableNotEmpty
        {
            get { return _isTableNotEmpty; }
            set { SetProperty(ref _isTableNotEmpty, value); }
        }

        private void AddFoodMessageHandler(AddFoodMessage obj)
        {
            if (!FoodStuff.Contains(obj.IngredientName))
            {
                if (!_recipiesIdList.ContainsKey(obj.IngredientName))
                    _recipiesIdList.Add(obj.IngredientName, new List<int>());

                FoodStuff.Add(obj.IngredientName);

                foreach (var recipeTag in obj.RecipesTagList)
                    _recipiesIdList[obj.IngredientName].Add(recipeTag);
            }
            CheckIfEnoughFood();
            IsTableNotEmpty = true;
        }

        private void DeleteFoodMessageHandler(DeleteFoodMessage obj)
        {
            _recipiesIdList.Remove(obj.FoodItem);
            FoodStuff.Remove(obj.FoodItem);
            CheckIfEnoughFood();
        }

        private void CheckIfEnoughFood()
        {
            var foodCount = FoodStuff?.Count;
            IsTableNotEmpty = foodCount > 0;
            IsEnoughFood = foodCount >= 3;
        }


        private async Task MatchRecipiesAsyncCommandHandler()
        {
            var matchedRecipiesTuple = await _matchRecipeService.MatchRecipes(_recipiesIdList);

            var matchedRecipiesDictionary = new Dictionary<int, MvxObservableCollection<Recipe>>
            {
                [0] = new MvxObservableCollection<Recipe>(matchedRecipiesTuple.Item1),
                [1] = new MvxObservableCollection<Recipe>(matchedRecipiesTuple.Item2)
            };

            ShowViewModel<RecipeSuggestionsViewModel>(matchedRecipiesDictionary);
        }
    }
}