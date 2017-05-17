using System.Runtime.Remoting.Channels;
using MvvmCross.Core.ViewModels;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class CategorizedRecipesViewModel : BaseCustomViewModel<Category>
    {
        private readonly IRepository _repository;
        private MvxObservableCollection<Recipe> _categorizedRecipesList;
        private string _categoryTitle;
        private bool _isTableNotEmpty;
        private IMvxCommand _showDetailRecipesCommand;

        public CategorizedRecipesViewModel(IRepository repository)
        {
            _repository = repository;
        }

        public bool IsTableNotEmpty
        {
            get { return _isTableNotEmpty; }
            set { SetProperty(ref _isTableNotEmpty, value); }
        }

        public MvxObservableCollection<Recipe> CategorizedRecipesList
        {
            get { return _categorizedRecipesList; }
            set { SetProperty(ref _categorizedRecipesList, value); }
        }

        public string CategoryTitle
        {
            get { return _categoryTitle; }
            set { SetProperty(ref _categoryTitle, value); }
        }

        public IMvxCommand ShowRecipeDetailCommand
        {
            get
            {
                _showDetailRecipesCommand = _showDetailRecipesCommand ??
                                            new MvxCommand<Recipe>(ShowRecipeDetailCommandHandler);
                return _showDetailRecipesCommand;
            }
        }

        protected override async void InitWithReceivedData(Category @object)
        {
            var recipesByCategory = await _repository.GetRecipesByCategoryAsync(@object.Tag);
           
            CategorizedRecipesList = new MvxObservableCollection<Recipe>(recipesByCategory);
            IsTableNotEmpty = CategorizedRecipesList.Count > 0;
            CategoryTitle = @object.Name;
        }

        private void ShowRecipeDetailCommandHandler(Recipe recipe)
        {
            ShowViewModel<RecipeDetailViewModel>(recipe);
        }
    }
}