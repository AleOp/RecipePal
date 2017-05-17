using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using RecipePal.Core.Helpers;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class CategoriesViewModel : BaseCustomViewModel
    {
        private readonly IRepository _repository;
        private MvxObservableCollection<Category> _categoriesList;
        private IMvxCommand _showCategorizedRecipesCommand;

        public CategoriesViewModel(IRepository repository)
        {
            _repository = repository;
        }

        public MvxObservableCollection<Category> CategoriesList
        {
            get { return _categoriesList; }
            set { SetProperty(ref _categoriesList, value); }
        }

        public IMvxCommand ShowCategorizedRecipesCommand
        {
            get
            {
                _showCategorizedRecipesCommand = _showCategorizedRecipesCommand ??
                                                 new MvxCommand<Category>(ShowCategorizedRecipesCommandHandler);
                return _showCategorizedRecipesCommand;
            }
        }

        public override async void Start()
        {
            base.Start();
            await RefreshDataSet();
        }

        public async Task RefreshDataSet()
        {
            var categories = await _repository.GetAllItemsAsync("getallcategories", ModelTableNames.Category);
            CategoriesList = new MvxObservableCollection<Category>(categories.Cast<Category>());
        }

        private void ShowCategorizedRecipesCommandHandler(Category category)
        {
            ShowViewModel<CategorizedRecipesViewModel>(category);
        }
    }
}