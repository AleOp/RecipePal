using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecipePal.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace RecipePal.Droid.Views.Activities
{
    [Activity(Theme = "@style/AppTheme.Base")]
    public class FoodSearchActivity : MvxAppCompatActivity<FoodResultsViewModel>
    {
        private MvxRecyclerView _searchResultsList;
        private MvxRecyclerAdapter _searchResultsAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_food_search);                   
           
            SetupResultsList();
            SetupSearchView();
            SetupToolbar();

            CreateBindings();
        }

        private void SetupResultsList()
        {
            _searchResultsList = FindViewById<MvxRecyclerView>(Resource.Id.search_results_list);
            _searchResultsAdapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext)BindingContext);
            _searchResultsAdapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.food_item);
            _searchResultsList.SetAdapter(_searchResultsAdapter);
            _searchResultsList.SetLayoutManager(new LinearLayoutManager(this));
        }      

        private void SetupSearchView()
        {
            var searchView = FindViewById<SearchView>(Resource.Id.food_search_view);
            searchView.Activated = true;
            searchView.OnActionViewExpanded();
            searchView.Iconified = false;
            searchView.ClearFocus();
            searchView.QueryHint = "Enter your food here";

            searchView.QueryTextChange += async (sender, args) =>
            {
                await ViewModel.SearchForFoodAsyncCommand.ExecuteAsync(args.NewText);
            };
        }

        private void SetupToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.search__activity_toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolbar.NavigationClick += (sender, args) => { ViewModel.AndroidCloseHandler(); };
            SupportActionBar.Title = "Food search";
        }

        private void CreateBindings()
        {
            this.CreateBinding(_searchResultsAdapter)
                .For(v => v.ItemsSource)
                .To((FoodResultsViewModel vm) => vm.FoodList)
                .Apply();
            this.CreateBinding(_searchResultsList)
                .For(v => v.ItemClick)
                .To((FoodResultsViewModel vm) => vm.AddFoodCommand)
                .Apply();
        }
    }
}