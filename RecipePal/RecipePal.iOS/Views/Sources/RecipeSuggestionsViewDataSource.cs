using System;
using System.Collections.Generic;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Models;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using UIKit;

namespace RecipePal.iOS.Views.Sources
{
    public class RecipeSuggestionsViewDataSource : MvxTableViewSource
    {
        private readonly NSString _cellId;
        private readonly RecipeSuggestionsViewModel _viewModel;
        private int _animatedRow;
        private int _currentSection = -1;

        public RecipeSuggestionsViewDataSource(UITableView tableView, NSString cellId,
            RecipeSuggestionsViewModel viewModel) : base(tableView)
        {
            _cellId = cellId;
            _viewModel = viewModel;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return section == 0
                ? _viewModel.MatchedRecipesList[0].Count
                : _viewModel.MatchedRecipesList[1].Count;
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
            label.Text = section == 0 ? "Matched recipes" : "Recipes you might also like";
            label.TextColor = UIColor.White;

            TableAdditionalStyling.SetFontForCustomTableSection(label);

            returnedView.AddSubview(label);

            return returnedView;
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            if (_currentSection != indexPath.Section)
            {
                _currentSection = indexPath.Section;
                _animatedRow = -1;
            }

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

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(_cellId);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            _viewModel.ShowRecipeDetailCommand.Execute(
                ((ICollection<Recipe>) ItemsSource).ElementAt((indexPath.Section + 1) * indexPath.Row));
        }
    }
}