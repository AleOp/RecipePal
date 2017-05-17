using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class FavoritesViewModel : BaseCustomViewModel
    {
        private readonly IAzureClientService _azureClientService;
        private readonly IRepository _repository;
        private MvxObservableCollection<Recipe> _favoriteRecipes;
        private bool _isTableNotEmpty = true;
        private IMvxCommand _showRecipeDetailCommand;

        public FavoritesViewModel(IRepository repository, IAzureClientService azureClientService)
        {
            _repository = repository;
            _azureClientService = azureClientService;
        }

        public bool IsTableNotEmpty
        {
            get { return _isTableNotEmpty; }
            set { SetProperty(ref _isTableNotEmpty, value); }
        }

        public MvxObservableCollection<Recipe> FavoriteRecipes
        {
            get { return _favoriteRecipes; }
            set { SetProperty(ref _favoriteRecipes, value); }
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

        public async Task RefreshDataSet()
        {
            var favoriteRecipesIds =
                await _repository.GetFavoritesRecipesTagsAsync(
                    _azureClientService.CurrentClient.CurrentUser.UserId.Replace("sid:", ""));

            var favoriteRecipes = await _repository.GetRecipesThatMatchAsync(favoriteRecipesIds);

            FavoriteRecipes = new MvxObservableCollection<Recipe>(favoriteRecipes);
            IsTableNotEmpty = FavoriteRecipes.Count > 0;
        }

        public override async void Start()
        {
            base.Start();
            await RefreshDataSet();
        }

        private void ShowRecipeDetailCommandHandler(Recipe recipe)
        {
            ShowViewModel<RecipeDetailViewModel>(recipe);
        }
    }
}