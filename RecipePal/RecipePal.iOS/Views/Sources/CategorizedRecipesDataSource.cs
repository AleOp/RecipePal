using System;
using System.Collections.Generic;
using System.Linq;
using CoreAnimation;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Models;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using UIKit;

namespace RecipePal.iOS.Views.Sources
{
    public class CategorizedRecipesDataSource : MvxTableViewSource
    {
        private readonly CategorizedRecipesViewModel _viewModel;
        private readonly NSString _cellId;
        private int _animatedRow = -1;

        public CategorizedRecipesDataSource(UITableView tableView, NSString cellId, CategorizedRecipesViewModel viewModel) : base(tableView)
        {
            _cellId = cellId;
            _viewModel = viewModel;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {

            return tableView.DequeueReusableCell(_cellId);
        }

        public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
        {
            TableAdditionalStyling.SetFontForTableSection(headerView);
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            if (_animatedRow < indexPath.Row)
            {
                cell.Alpha = 0;
                cell.Layer.Transform = CATransform3D.MakeTranslation(-500, 0, 0);

                UIView.Animate(1, () =>
                {
                    cell.Alpha = 1;
                    cell.Layer.Transform = CATransform3D.Identity;
                });
                _animatedRow++;
            }
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 0;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            _viewModel.ShowRecipeDetailCommand.Execute(((ICollection<Recipe>)ItemsSource).ElementAt(indexPath.Row));
        }
    }
}