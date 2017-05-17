using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecipePal.Core.Converters;
using RecipePal.Core.ViewModels;

namespace RecipePal.Droid.Views.Activities
{
    [Activity(Theme = "@style/AppTheme.Base")]
    public class SuggestedRecipesActivity : MvxAppCompatActivity<RecipeSuggestionsViewModel>
    {
        private MvxRecyclerView _suggestedRecipesList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_recipe_list);
          
            SetupRecipesList();
            SetupToolbar();
            CreateBindings();
        }

        private void SetupToolbar()
        {
            var toolBar = FindViewById<Toolbar>(Resource.Id.recipe_activity_toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolBar.NavigationClick += (sender, args) => { ViewModel.AndroidCloseHandler(); };
            SupportActionBar.Title = "Suggested recipes";
        }

        private void SetupRecipesList()
        {
            _suggestedRecipesList = FindViewById<MvxRecyclerView>(Resource.Id.recipes_list);
            var adapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.recipe_item);
            _suggestedRecipesList.SetAdapter(adapter);
        }

        private void CreateBindings()
        {
            this.CreateBinding(_suggestedRecipesList)
                .For(v => v.ItemsSource)
                .To((RecipeSuggestionsViewModel vm) => vm.MatchedRecipesList)
                .WithConversion(new MatchedRecipesSourceListValueConverter(), null)
                .Apply();
            this.CreateBinding(_suggestedRecipesList)
                .For(v => v.ItemClick)
                .To((RecipeSuggestionsViewModel vm) => vm.ShowRecipeDetailCommand)
                .Apply();
        }
    }
}