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
     MvxTabPresentation(MvxTabPresentationMode.Tab, "Match", "TabImages/Dice", true)]
    public partial class MatchRecipeView : MvxTableViewController<MatchRecipeViewModel>
    {
        private readonly NSString _cellId = new NSString("FoodStuffCell");
        private static UISearchController _searchController;
        private FoodResultView _resultsTableController;
        private bool _searchControllerWasActive;
        private bool _searchControllerSearchFieldWasFirstResponder;
        private UIView _emptyPlaceholderView;

        public MatchRecipeView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableAdditionalStyling.ChangeBackgroundColor(TableView);

            var navBarHeight = NavigationController?.NavigationBar.Frame.Height ?? 0;
            TableAdditionalStyling.SetEmptyTablePlaceholder(
                "Have anything edible? Type it to find out what you can make from it!",
                TableView, navBarHeight, out _emptyPlaceholderView);

            SetSearchViewController();

            var matchButton = new UIBarButtonItem {Title = "Match"};
            NavigationItem.RightBarButtonItem = matchButton;

            CreateBindings(matchButton);
        }

        private void SetSearchViewController()
        {
            _resultsTableController =
                (FoodResultView) Storyboard.InstantiateViewController("FoodResultView");

            _searchController = new UISearchController(_resultsTableController)
            {
                WeakDelegate = this,
                DimsBackgroundDuringPresentation = true,
                WeakSearchResultsUpdater = this
            };

            _searchController.SearchBar.SizeToFit();
            _searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
            _searchController.SearchBar.Placeholder = "Enter what you have";

            _searchController.HidesNavigationBarDuringPresentation = false;
            _searchController.SearchBar.WeakDelegate = this;

            DefinesPresentationContext = true;


            NavigationItem.TitleView = _searchController.SearchBar;


            if (_searchControllerWasActive)
            {
                _searchController.Active = _searchControllerWasActive;
                _searchControllerWasActive = false;

                if (_searchControllerSearchFieldWasFirstResponder)
                {
                    _searchController.SearchBar.BecomeFirstResponder();
                    _searchControllerSearchFieldWasFirstResponder = false;
                }
            }
        }

        private void CreateBindings(UIBarButtonItem matchButton)
        {
            var source = new MatchRecipeViewDataSource(TableView, _cellId) {UseAnimations = true};
            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((MatchRecipeViewModel vm) => vm.FoodStuff)
                .Apply();

            TableView.Source = source;
            TableView.ReloadData();

            this.CreateBinding(matchButton)
                .For(v => v.Enabled)
                .To((MatchRecipeViewModel vm) => vm.IsEnoughFood)
                .Apply();
            this.CreateBinding(matchButton)
                .For("Clicked")
                .To((MatchRecipeViewModel vm) => vm.MatchRecipiesAsyncCommand)
                .Apply();
            this.CreateBinding(_emptyPlaceholderView)
                .For(v => v.Hidden)
                .To((MatchRecipeViewModel vm) => vm.IsTableNotEmpty)
                .Apply();
        }


        [Export("searchBarSearchButtonClicked:")]
        public virtual void SearchButtonClicked(UISearchBar searchBar)
        {
            searchBar.ResignFirstResponder();
        }


        [Export("updateSearchResultsForSearchController:")]
        public virtual async void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            var tableController = (FoodResultView) searchController.SearchResultsController;
            await tableController.PerformSearch(searchController.SearchBar.Text);
        }

        public static void DismissSearchOnAddFood()
        {
            if (_searchController != null)
                _searchController.Active = !_searchController.Active;
        }
    }
}