using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Views;
using RecipePal.Core.Converters;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using RecipePal.iOS.Views.Sources;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main"),
     MvxTabPresentation(MvxTabPresentationMode.Child, "Results", null)]
    public partial class RecipeSuggestionsView : MvxTableViewController<RecipeSuggestionsViewModel>
    {
        private readonly NSString _cellId = new NSString("SuggestedRecipeCell");

        public RecipeSuggestionsView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableAdditionalStyling.ChangeBackgroundColor(TableView);

            CreateBindings();

            NavigationItem.Title = "Results";
        }

        private void CreateBindings()
        {
            var source = new RecipeSuggestionsViewDataSource(TableView, _cellId, ViewModel) {UseAnimations = true};

            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((RecipeSuggestionsViewModel vm) => vm.MatchedRecipesList)
                .WithConversion(new MatchedRecipesSourceListValueConverter(), null)
                .Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}