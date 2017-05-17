using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecipePal.Core.Converters;
using RecipePal.Core.ViewModels;

namespace RecipePal.Droid.Views.Fragments
{
    public class FavoritesFragment : MvxFragment<FavoritesViewModel>
    {
        private MvxRecyclerView _favoritesList;
        private TextView _emptyPlaceholder;
        private View _view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            _view = this.BindingInflate(Resource.Layout.favorites_fragment, null);
       
            _emptyPlaceholder = _view.FindViewById<TextView>(Resource.Id.empty_favorites_list_view);
            SetupList();
            CreateBindings();

            return _view;
        }

        private void SetupList()
        {
            _favoritesList = _view.FindViewById<MvxRecyclerView>(Resource.Id.favorites_list);
            var adapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.recipe_item);
            _favoritesList.SetAdapter(adapter);
        }

        private void CreateBindings()
        {
            this.CreateBinding(_favoritesList)
                .For(v => v.ItemsSource)
                .To((FavoritesViewModel vm) => vm.FavoriteRecipes)
                .Apply();
            this.CreateBinding(_favoritesList)
                .For(v => v.ItemClick)
                .To((FavoritesViewModel vm) => vm.ShowRecipeDetailCommand)
                .Apply();
            this.CreateBinding(_emptyPlaceholder)
                .For(v => v.Visibility)
                .To((FavoritesViewModel vm) => vm.IsTableNotEmpty)
                .WithConversion(new DroidListPlaceholderVisibilityConverter(), null)
                .Apply();
        }

        public override async void OnResume()
        {
            base.OnResume();
            var refreshDataSet = ViewModel?.RefreshDataSet();
            if (refreshDataSet != null) await refreshDataSet;
        }
    }
}