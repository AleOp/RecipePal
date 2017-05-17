using MvvmCross.Core.ViewModels;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IAzureClientService _clientService;
        private readonly IRepository _repository;

        public MainViewModel(IRepository repository, IAzureClientService clientService)
        {
            _repository = repository;
            _clientService = clientService;
            ShowInitialViewModelsCommand = new MvxCommand(ShowInitialViewModels);
        }

        public IMvxCommand ShowInitialViewModelsCommand { get; }

        private void ShowInitialViewModels()
        {
            ShowViewModel<MatchRecipeViewModel>();
            ShowViewModel<CategoriesViewModel>();
            ShowViewModel<FavoritesViewModel>();
            ShowViewModel<SettingsViewModel>();
        }

        public override async void Start()
        {
            base.Start();
            await _repository.SyncRequiredTablesAtStartup();
            //foreach (var item in MockStaticData.Quantities.QuantityTypes)
            //{
            //    await _repository.SaveItemsAsync(item, ModelTableNames.QuantityType);
            //}

            //foreach (var item in MockStaticData.Categories.CategoriesList)
            //{
            //    await _repository.SaveItemsAsync(item, ModelTableNames.Category);
            //}

            //foreach (var item in MockStaticData.Recipies.RecipiesList)
            //{
            //    await _repository.SaveItemsAsync(item, ModelTableNames.Recipe);
            //}

            //foreach (var item in MockStaticData.Ingredients.IngredientsList)
            //{
            //    await _repository.SaveItemsAsync(item, ModelTableNames.Ingredient);
            //}

            //foreach (var item in MockStaticData.Fav.FavoritesList)
            //{
            //    item.UserId = _clientService.CurrentClient.CurrentUser.UserId.Replace("sid:", "");
            //    await _repository.SaveItemsAsync(item, ModelTableNames.Favorites);
            //}
        }
    }
}