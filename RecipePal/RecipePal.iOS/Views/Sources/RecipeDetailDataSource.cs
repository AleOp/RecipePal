using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Helpers;
using RecipePal.Core.Models;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Resources.CustomCells;
using RecipePal.iOS.Views.Helpers;
using UIKit;

namespace RecipePal.iOS.Views.Sources
{
    public class RecipeDetailDataSource : MvxTableViewSource
    {
        private readonly NSString _cellId;
        private readonly RecipeDetailViewModel _viewModel;
        private readonly UIView _headerView;
        private readonly nfloat _headerViewHeight;


        public RecipeDetailDataSource(UITableView tableView, NSString cellId, RecipeDetailViewModel viewModel,
            UIView headerView, nfloat headerViewHeight) : base(tableView)
        {
            _cellId = cellId;
            _viewModel = viewModel;
            _headerView = headerView;
            _headerViewHeight = headerViewHeight;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            switch (indexPath.Row)
            {
                case 0:
                    var recipeCell = (RecipeDetailCell) tableView.DequeueReusableCell("RecipeDetailCell");
                    var recipe = _viewModel.RecipeDictionary[(int) RecipeDictionaryKey.Recipe]
                        .Cast<Recipe>()
                        .FirstOrDefault();
                    recipeCell.FillCellWithData(recipe);
                    return recipeCell;
                case 1:
                    var ingredientsCell =
                        (RecipeIngredientsCell) tableView.DequeueReusableCell("RecipeIngredientsCell");
                    ingredientsCell.FillCellWithData(_viewModel.RecipeDictionary);
                    return ingredientsCell;
                case 2:
                    var recipeDescCell = (RecipeDescriptionCell) tableView.DequeueReusableCell("RecipeDescriptionCell");
                    var recipeDesc = _viewModel.RecipeDictionary[(int) RecipeDictionaryKey.Recipe]
                        .Cast<Recipe>()
                        .FirstOrDefault();
                        recipeDescCell.FillCellWithData(recipeDesc.Description);
                    
                    return recipeDescCell;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
        {
            TableAdditionalStyling.SetFontForTableSection(headerView);
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 0;
        }

        public override void Scrolled(UIScrollView scrollView)
        {
            var headerRect = new CGRect(0, -_headerViewHeight, TableView.Bounds.Width, _headerViewHeight);
            if (TableView.ContentOffset.Y < -_headerViewHeight)
            {
                headerRect.Y = TableView.ContentOffset.Y;
                headerRect.Size = new CGSize(headerRect.Size.Width, -TableView.ContentOffset.Y);
            }
            _headerView.Frame = headerRect;
        }
    }
}