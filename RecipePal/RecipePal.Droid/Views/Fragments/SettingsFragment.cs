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
    public class SettingsFragment : MvxFragment<SettingsViewModel>
    {
        private MvxRecyclerView _settingsList;

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
            _settingsList = view.FindViewById<MvxRecyclerView>(Resource.Id.single_list);
            var adapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.settings_item);
            _settingsList.SetAdapter(adapter);
        }

        private void CreateBindings()
        {
            this.CreateBinding(_settingsList)
                .For(v => v.ItemsSource)
                .To((SettingsViewModel vm) => vm.SettingsList)
                .Apply();
            this.CreateBinding(_settingsList)
                .For(v => v.ItemClick)
                .To((SettingsViewModel vm) => vm.SettingsOptionCommand)
                .Apply();
        }
    }
}