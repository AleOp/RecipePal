using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Plugins.Visibility;
using RecipePal.Core.Converters;
using RecipePal.Core.ViewModels;

namespace RecipePal.Droid.Views.Fragments
{
    public class MatchRecipeFragment : MvxFragment<MatchRecipeViewModel>
    {
        private Button _matchButton;
        private MvxRecyclerView _matchRecipeList;
        private TextView _emptyPlaceholder;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.match_recipe_fragment, null);

            _matchButton = view.FindViewById<Button>(Resource.Id.match_food_button);      
            _emptyPlaceholder = view.FindViewById<TextView>(Resource.Id.empty_food_list_view);

            SetupList(view);
            CreateBindings();

            return view;
        }

        private void SetupList(View view)
        {
            _matchRecipeList = view.FindViewById<MvxRecyclerView>(Resource.Id.chosen_food_list);
            var adapter = new MvxRecyclerAdapter((IMvxAndroidBindingContext) BindingContext);
            adapter.ItemTemplateSelector = new MvxDefaultTemplateSelector(Resource.Layout.matched_food_item);
            _matchRecipeList.SetAdapter(adapter);
        }

        private void CreateBindings()
        {
            this.CreateBinding(_matchRecipeList)
                .For(v => v.ItemsSource)
                .To((MatchRecipeViewModel vm) => vm.FoodStuff)
                .Apply();
            this.CreateBinding(_matchButton)
                .For(v => v.Visibility)
                .To((MatchRecipeViewModel vm) => vm.IsEnoughFood)
                .WithConversion(new MvxVisibilityValueConverter(), null)
                .Apply();
            this.CreateBinding(_matchButton)
                .For("Click")
                .To((MatchRecipeViewModel vm) => vm.MatchRecipiesAsyncCommand)
                .Apply();
            this.CreateBinding(_emptyPlaceholder)
                .For(v => v.Visibility)
                .To((MatchRecipeViewModel vm) => vm.IsTableNotEmpty)
                .WithConversion(new DroidListPlaceholderVisibilityConverter(), null)
                .Apply();
        }
    }
}