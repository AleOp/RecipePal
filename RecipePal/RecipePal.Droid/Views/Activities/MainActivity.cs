using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using RecipePal.Core.ViewModels;
using RecipePal.Droid.Views.Fragments;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace RecipePal.Droid.Views.Activities
{
    [Activity(Theme = "@style/AppTheme.Base")]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        private bool _isSearchActionVisible = true;
        private Toolbar _toolbar;
        private TabLayout _tabLayout;

        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);

            SetContentView(Resource.Layout.activity_main);

            var viewPager = SetupViewPager();

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _toolbar.Title = "Match";

            SetupTabLayout(viewPager);

            SetSupportActionBar(_toolbar);
        }

        private void SetupTabLayout(ViewPager viewPager)
        {
            _tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            _tabLayout.SetupWithViewPager(viewPager);
            _tabLayout.TabSelected += (sender, args) => { _toolbar.Title = args.Tab.Text; };

            SetupTabsIcon();
        }

        private ViewPager SetupViewPager()
        {
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            if (viewPager != null)
            {
                var adapter = new MvxCachingFragmentStatePagerAdapter(this, SupportFragmentManager, new[]
                {
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Match", typeof(MatchRecipeFragment),
                        typeof(MatchRecipeViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Categories", typeof(CategoriesFragment),
                        typeof(CategoriesViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Favorites", typeof(FavoritesFragment),
                        typeof(FavoritesViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Settings", typeof(SettingsFragment),
                        typeof(SettingsViewModel))
                });
                viewPager.Adapter = adapter;
                viewPager.PageSelected += (sender, args) =>
                {
                    _isSearchActionVisible = args.Position == 0;
                    InvalidateOptionsMenu();
                };
            }
            return viewPager;
        }

        private void SetupTabsIcon()
        {
            var matchTabView = new ImageView(this);
            var categoryTabView = new ImageView(this);
            var favoritesTabView = new ImageView(this);
            var settingsTabView = new ImageView(this);

            matchTabView.SetImageResource(Resource.Drawable.match_tab);
            categoryTabView.SetImageResource(Resource.Drawable.category_tab);
            favoritesTabView.SetImageResource(Resource.Drawable.favorites_tab);
            settingsTabView.SetImageResource(Resource.Drawable.settings_tab);

            _tabLayout.GetTabAt(0).SetCustomView(matchTabView);
            _tabLayout.GetTabAt(1).SetCustomView(categoryTabView);
            _tabLayout.GetTabAt(2).SetCustomView(favoritesTabView);
            _tabLayout.GetTabAt(3).SetCustomView(settingsTabView);
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_search_item, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_search)
            {
                var intent = new Intent(this, typeof(FoodSearchActivity));
                StartActivity(intent);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            menu.FindItem(Resource.Id.action_search)?.SetVisible(_isSearchActionVisible);
            return base.OnPrepareOptionsMenu(menu);
        }
    }
}