using Android.OS;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecipePal.Core.ViewModels;

namespace RecipePal.Droid.Views.Fragments
{
    public class CategoriesFragment : MvxFragment<CategoriesViewModel>
    {
        private MvxRecyclerView _categoriesList;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.single_list_fragment, null);

            SetupList(view);
            CreateBindings();

            return view;
        }

        private void SetupList(View view)
        {
            _categoriesList = view.FindViewById<MvxRecyclerView>(Resource.Id.single_list);
            var adapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.category_item);
            _categoriesList.SetAdapter(adapter);
        }

        private void CreateBindings()
        {
            this.CreateBinding(_categoriesList)
                .For(v => v.ItemsSource)
                .To((CategoriesViewModel vm) => vm.CategoriesList)
                .Apply();
            this.CreateBinding(_categoriesList)
                .For(v => v.ItemClick)
                .To((CategoriesViewModel vm) => vm.ShowCategorizedRecipesCommand)
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