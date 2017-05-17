using System;
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
     MvxTabPresentation(MvxTabPresentationMode.Tab, "Categories", "TabImages/Category", true)]
    public partial class CategoriesView : MvxTableViewController<CategoriesViewModel>
    {
        private readonly NSString _cellId = new NSString("CategoriesCell");
        private static UIView _loadingView;
        private static UIActivityIndicatorView _spinner;
        private static UILabel _loadingLabel;

        public CategoriesView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableAdditionalStyling.ChangeBackgroundColor(TableView);
            TableAdditionalStyling.SetLoadingView("Loading", TableView, NavigationController, out _loadingView,
                out _loadingLabel, out _spinner);

            CreateBindings();
        }

        private void CreateBindings()
        {
            var source = new CategoriesDataSource(TableView, _cellId, ViewModel) {UseAnimations = true};

            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((CategoriesViewModel vm) => vm.CategoriesList)
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