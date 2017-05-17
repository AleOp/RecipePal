using System;
using CoreGraphics;
using UIKit;

namespace RecipePal.iOS.Views.Helpers
{
    public static class TableAdditionalStyling
    {
        public static void ChangeBackgroundColor(UITableView tableView)
        {
            tableView.BackgroundColor = UIColor.FromRGB(243, 243, 243);
        }

        public static void SetFontForTableSection(UIView headerView)
        {
            var header = headerView as UITableViewHeaderFooterView;
            if (header != null)
                header.TextLabel.Font = UIFont.FromName("Noteworthy-Bold", 17);
        }

        public static void SetFontForCustomTableSection(UILabel label)
        {
            if (label != null)
                label.Font = UIFont.FromName("Noteworthy-Bold", 17);
        }

        public static void SetLoadingView(string loadingText, UIView tableView,
            UINavigationController navigationController,
            out UIView loadingView, out UILabel loadingLabel, out UIActivityIndicatorView spinner)
        {
            nfloat width = 120;
            nfloat height = 30;
            nfloat x = tableView.Frame.Width / 2 - width / 2;
            nfloat y = tableView.Frame.Height / 2 - height / 2f -
                       (navigationController?.NavigationBar.Frame.Height ?? 0);

            loadingView = new UIView {Frame = new CGRect(x, y, width, height)};

            loadingLabel = new UILabel
            {
                TextColor = UIColor.Gray,
                TextAlignment = UITextAlignment.Center,
                Text = loadingText,
                Font = UIFont.FromName("Noteworthy", 26),
                Frame = new CGRect(0, 0, 140, 40)
            };

            spinner = new UIActivityIndicatorView
            {
                ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray,
                Frame = new CGRect(0, 0, 40, 40)
            };

            spinner.StartAnimating();

            loadingView.AddSubviews(spinner, loadingLabel);
            tableView.AddSubview(loadingView);
        }

        public static void SetEmptyTablePlaceholder(string text, UITableView tableView, nfloat navBarHeight,
            out UIView placeholderView)
        {
            placeholderView = new UIView(new CGRect(0, 0, tableView.Bounds.Width, tableView.Bounds.Height));

            var label = new UILabel(new CGRect(tableView.Bounds.Width / 2 - 200 / 2,
                tableView.Bounds.Height / 2 - 100 / 2 - navBarHeight, 200,
                100))
            {
                Text = text,
                TextAlignment = UITextAlignment.Center,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 3,
                TextColor = UIColor.Gray,
                Font = UIFont.FromName("Noteworthy", 17)
            };

            placeholderView.AddSubview(label);
            tableView.AddSubview(placeholderView);
        }
    }
}