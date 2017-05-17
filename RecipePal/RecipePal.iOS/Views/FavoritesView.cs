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
     MvxTabPresentation(MvxTabPresentationMode.Tab, "Favorites", "TabImages/Favorites", true)]
    public partial class FavoritesView : MvxTableViewController<FavoritesViewModel>
    {
        private readonly NSString _cellId = new NSString("FavoritesCell");
        private static UIView _loadingView;
        private static UIActivityIndicatorView _spinner;
        private static UILabel _loadingLabel;
        private UIView _emplyPlaceholderView;

        public FavoritesView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableAdditionalStyling.ChangeBackgroundColor(TableView);
            TableAdditionalStyling.SetLoadingView("Loading", TableView, NavigationController, out _loadingView,
                out _loadingLabel, out _spinner);

            var navBarHeight = NavigationController?.NavigationBar.Frame.Height ?? 0;
            TableAdditionalStyling.SetEmptyTablePlaceholder(
                "You have no favorites yet. Have not liked any of available recipes?", TableView, navBarHeight,
                out _emplyPlaceholderView);

            CreateBindings();

            NavigationItem.Title = "Favorites";
        }

        private void CreateBindings()
        {
            var source = new FavoritesDataSource(TableView, _cellId, ViewModel) {UseAnimations = true};

            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((FavoritesViewModel vm) => vm.FavoriteRecipes)
                .Apply();
            this.CreateBinding(_emplyPlaceholderView)
                .For(v => v.Hidden)
                .To((FavoritesViewModel vm) => vm.IsTableNotEmpty)
                .Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }

        public static void RemoveLoadingScreen()
        {
            _spinner?.StopAnimating();
            _loadingLabel.Hidden = true;
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            await ViewModel.RefreshDataSet();
        }
    }
}