using System;
using System.Collections.Generic;
using System.Linq;
using CoreAnimation;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Messages;
using RecipePal.iOS.Views.Helpers;
using UIKit;

namespace RecipePal.iOS.Views.Sources
{
    public class MatchRecipeViewDataSource : MvxTableViewSource
    {
        private readonly NSString _cellId;

        public MatchRecipeViewDataSource(UITableView tableView, NSString cellId) : base(tableView)
        {
            _cellId = cellId;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(_cellId);
        }

        public override async void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            cell.Alpha = 0;
            cell.Layer.Transform = CATransform3D.MakeTranslation(-500, 0, 0);

            await UIView.AnimateAsync(0.5, () =>
            {
                cell.Alpha = 1;
                cell.Layer.Transform = CATransform3D.Identity;
            });
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle,
            NSIndexPath indexPath)
        {
            if (editingStyle == UITableViewCellEditingStyle.Delete)
                Mvx.Resolve<IMvxMessenger>().Publish(
                    new DeleteFoodMessage(this, ((ICollection<string>) ItemsSource).ElementAt(indexPath.Row)));
        }

        public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
        {
            TableAdditionalStyling.SetFontForTableSection(headerView);
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableViewCellEditingStyle.Delete;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 0;
        }
    }
}