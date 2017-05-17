using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Converters;
using RecipePal.Core.Messages;
using RecipePal.Core.ViewModels;
using RecipePal.Droid.Views.Helpers;

namespace RecipePal.Droid.Views.Activities
{
    [Activity(Theme = "@style/AppTheme.Base")]
    public class RecipeDetailActivity : MvxAppCompatActivity<RecipeDetailViewModel>
    {
        private MvxSubscriptionToken _favoriteBtnToken;
        private bool _isFavorite;
        private MvxRecyclerView _recipeDetailList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_recipe_list);

            _favoriteBtnToken = Mvx.Resolve<IMvxMessenger>()
                .Subscribe<ChangeFavoriteBtnImageMessage>(ChangeFavoriteBtnImageMessageHandler);

            SetupRecipeList();
            SetupToolbar();
            CreateBindings();
        }

        private void SetupRecipeList()
        {
            _recipeDetailList = FindViewById<MvxRecyclerView>(Resource.Id.recipes_list);
            var adapter = new RecipeDetailAdapter(ViewModel, (IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new RecipeDetailTemplateSelector();
            _recipeDetailList.SetAdapter(adapter);
        }

        private void SetupToolbar()
        {
            var toolBar = FindViewById<Toolbar>(Resource.Id.recipe_activity_toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolBar.NavigationClick += (sender, args) => { ViewModel.AndroidCloseHandler(); };
            toolBar.MenuItemClick += async (sender, args) =>
            {
                await ViewModel.ToggleFavoriteAsyncCommand.ExecuteAsync();
            };
        }

        private void CreateBindings()
        {
            this.CreateBinding(_recipeDetailList)
                .For(v => v.ItemsSource)
                .To((RecipeDetailViewModel vm) => vm.RecipeDictionary)
                .WithConversion(new RecipeDetailItemSourceValueConverter(), null)
                .Apply();

            this.CreateBinding(SupportActionBar)
                .For(v => v.Title)
                .To((RecipeDetailViewModel vm) => vm.Title)
                .Apply();
        }

        private void ChangeFavoriteBtnImageMessageHandler(ChangeFavoriteBtnImageMessage obj)
        {
            _isFavorite = obj.IsRecipeFavorite;
            InvalidateOptionsMenu();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.favorite_btn_item, menu);
            return true;
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            menu.FindItem(Resource.Id.action_favorite)
                ?.SetIcon(_isFavorite ? Resource.Drawable.favorite_icon_filled : Resource.Drawable.favorite_icon);
            return base.OnPrepareOptionsMenu(menu);
        }
    }
}