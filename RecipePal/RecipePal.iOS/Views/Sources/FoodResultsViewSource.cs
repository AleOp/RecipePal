using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Models;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using UIKit;

namespace RecipePal.iOS.Views.Sources
{
    public class FoodResultsViewSource : MvxTableViewSource
    {
        private readonly NSString _cellId;
        private readonly FoodResultsViewModel _viewModel;

        public FoodResultsViewSource(UITableView tableView, NSString cellId, FoodResultsViewModel viewModel)
            : base(tableView)
        {
            _cellId = cellId;
            _viewModel = viewModel;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var accessoryButton = new UIButton(UIButtonType.ContactAdd);
            accessoryButton.UserInteractionEnabled = false;

            var cell = TableView.DequeueReusableCell(_cellId);
            cell.TextLabel.Text = ((Ingredient) item).Name;
            cell.AccessoryView = accessoryButton;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _viewModel?.AddFoodCommand.Execute(_viewModel.FoodList[indexPath.Row]);
            MatchRecipeView.DismissSearchOnAddFood();
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 30;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var returnedView = new UIView(new CGRect(0, 0, tableView.Bounds.Size.Width, 28));
            returnedView.BackgroundColor = UIColor.Red;

            var label = new UILabel(new CGRect(10, 0, tableView.Bounds.Size.Width - 10, 20));
            label.Center = new CGPoint(label.Center.X, returnedView.Frame.Size.Height / 2);
            label.Text = section == 0 ? "Results" : "";
            label.TextColor = UIColor.White;

            TableAdditionalStyling.SetFontForCustomTableSection(label);

            returnedView.AddSubview(label);

            return returnedView;
        }
    }
}