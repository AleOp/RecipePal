using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Converters;
using RecipePal.Core.Messages;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using RecipePal.iOS.Views.Sources;
using UIKit;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main"),
     MvxTabPresentation(MvxTabPresentationMode.Child)]
    public partial class RecipeDetailView : MvxTableViewController<RecipeDetailViewModel>
    {
        private readonly NSString CellId = new NSString("RecipeDetailCell");
        private readonly nfloat _headerViewHeight = 200;
        private UIView _headerView;
        private MvxSubscriptionToken _favoriteBtnImgToken;

        public RecipeDetailView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableAdditionalStyling.ChangeBackgroundColor(TableView);

            _favoriteBtnImgToken = Mvx.Resolve<IMvxMessenger>()
                .Subscribe<ChangeFavoriteBtnImageMessage>(ChangeFavoriteBtnImageHandler);

            AdjustTableViewForStretchyHeader();

            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 180f;

            CreateBindings();
        }

        private void AdjustTableViewForStretchyHeader()
        {
            _headerView = TableView.TableHeaderView;

            TableView.TableHeaderView = null;
            TableView.AddSubview(_headerView);
            TableView.ContentInset = new UIEdgeInsets(
                _headerViewHeight + NavigationController?.NavigationBar?.Bounds.Height ?? 0, 0, 0, 0);
            TableView.ContentOffset = new CGPoint(0, -_headerViewHeight);
        }

        private void CreateBindings()
        {
            var source =
                new RecipeDetailDataSource(TableView, CellId, ViewModel, _headerView, _headerViewHeight);

            this.CreateBinding(source)
                .For(v => v.ItemsSource)
                .To((RecipeDetailViewModel vm) => vm.RecipeDictionary)
                .WithConversion(new RecipeDetailItemSourceValueConverter(), null)
                .Apply();
            this.CreateBinding(NavigationItem)
                .For(v => v.Title)
                .To((RecipeDetailViewModel vm) => vm.Title)
                .Apply();
            this.CreateBinding(RecipeImage)
                .For(v => v.ImageUrl)
                .To((RecipeDetailViewModel vm) => vm.ImageUrl)
                .Apply();
            this.CreateBinding(FavoriteButton)
                .For("TouchUpInside")
                .To((RecipeDetailViewModel vm) => vm.ToggleFavoriteAsyncCommand)
                .Apply();


            TableView.Source = source;
            TableView.ReloadData();
        }

        private void ChangeFavoriteBtnImageHandler(ChangeFavoriteBtnImageMessage obj)
        {
            var image = obj.IsRecipeFavorite
                ? UIImage.FromBundle("MiscellaneousImg/FavoriteBtnFilled")
                : UIImage.FromBundle("MiscellaneousImg/FavoriteBtn");

            FavoriteButton.SetImage(image, UIControlState.Normal);
        }
    }
}