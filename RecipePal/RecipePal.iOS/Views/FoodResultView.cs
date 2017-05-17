using System;
using System.Threading.Tasks;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Sources;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class FoodResultView : MvxTableViewController<FoodResultsViewModel>
    {
        private readonly NSString _cellId = new NSString("IngredientResultsCell");

        public FoodResultView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            if(ViewModel == null)
                Request = new MvxViewModelRequest(typeof(FoodResultsViewModel),null,null,null);

            base.ViewDidLoad();

            CreateBindings();
        }

        private void CreateBindings()
        {
            var source = new FoodResultsViewSource(TableView, _cellId, ViewModel) {UseAnimations = true};
            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((FoodResultsViewModel vm) => vm.FoodList)
                .Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }

        public async Task PerformSearch(string ingredientName)
        {
            var executeAsync = ViewModel?.SearchForFoodAsyncCommand.ExecuteAsync(ingredientName);

            if (executeAsync != null)
                await executeAsync;
        }
    }
}