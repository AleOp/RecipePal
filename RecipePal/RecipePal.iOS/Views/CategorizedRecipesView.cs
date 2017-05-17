using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Views;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using RecipePal.iOS.Views.Sources;
using UIKit;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main"),
        MvxTabPresentation(MvxTabPresentationMode.Child)]
    public partial class CategorizedRecipesView : MvxTableViewController<CategorizedRecipesViewModel>
    {
        private readonly NSString _cellId = new NSString("CategorizedRecipesCell");
        private UIView _emptyPlaceholderView;
        private UILabel _emptyTableLabel;

        public CategorizedRecipesView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var navBarHeight = NavigationController?.NavigationBar.Frame.Height ?? 0;

            TableAdditionalStyling.ChangeBackgroundColor(TableView);          
            TableAdditionalStyling.SetEmptyTablePlaceholder("There are no recipies in this category yet!",TableView, navBarHeight, out _emptyPlaceholderView);

            CreateBindings();
        }

        private void CreateBindings()
        {
            var source = new CategorizedRecipesDataSource(TableView, _cellId, ViewModel) {UseAnimations = true};
            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((CategorizedRecipesViewModel vm) => vm.CategorizedRecipesList)
                .Apply();
            this.CreateBinding(NavigationItem)
                .For(v => v.Title)
                .To((CategorizedRecipesViewModel vm) => vm.CategoryTitle)
                .Apply();
            this.CreateBinding(_emptyPlaceholderView)
                .For(v => v.Hidden)
                .To((CategorizedRecipesViewModel vm) => vm.IsTableNotEmpty)
                .Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}