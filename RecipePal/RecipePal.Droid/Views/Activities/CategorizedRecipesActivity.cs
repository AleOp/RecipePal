using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecipePal.Core.Converters;
using RecipePal.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace RecipePal.Droid.Views.Activities
{
    [Activity(Theme = "@style/AppTheme.Base")]
    public class CategorizedRecipesActivity : MvxAppCompatActivity<CategorizedRecipesViewModel>
    {
        private TextView _emptyPlaceholder;
        private MvxRecyclerView _categorizedRecipesList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_categorized_recipes);

            _emptyPlaceholder = FindViewById<TextView>(Resource.Id.empty_categorized_recipes_list_view);
           
            SetupCategoryRecipeList();
            SetupToolbar();

            CreateBindings();
        }

        private void SetupCategoryRecipeList()
        {
            _categorizedRecipesList = FindViewById<MvxRecyclerView>(Resource.Id.categorized_recipes_list);
            var adapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.recipe_item);
            _categorizedRecipesList.SetAdapter(adapter);
        }

        private void SetupToolbar()
        {
            var toolBar = FindViewById<Toolbar>(Resource.Id.categorized_activity_toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolBar.NavigationClick += (sender, args) => { ViewModel.AndroidCloseHandler(); };
        }

        private void CreateBindings()
        {
            this.CreateBinding(_categorizedRecipesList)
                .For(v => v.ItemsSource)
                .To((CategorizedRecipesViewModel vm) => vm.CategorizedRecipesList)
                .Apply();
            this.CreateBinding(SupportActionBar)
                .For(v => v.Title)
                .To((CategorizedRecipesViewModel vm) => vm.CategoryTitle)
                .Apply();
            this.CreateBinding(_categorizedRecipesList)
                .For(v => v.ItemClick)
                .To((CategorizedRecipesViewModel vm) => vm.ShowRecipeDetailCommand)
                .Apply();
            this.CreateBinding(_emptyPlaceholder)
                .For(v => v.Visibility)
                .To((CategorizedRecipesViewModel vm) => vm.IsTableNotEmpty)
                .WithConversion(new DroidListPlaceholderVisibilityConverter(), null)
                .Apply();
        }
    }
}