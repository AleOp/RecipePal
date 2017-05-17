using System;
using Foundation;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Views;
using RecipePal.Core.ViewModels;
using RecipePal.iOS.Views.Helpers;
using UIKit;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main"),
     MvxTabPresentation(MvxTabPresentationMode.Tab, "Settings", "TabImages/Settings", true)]
    public partial class SettingsView : MvxTableViewController<SettingsViewModel>
    {
        public SettingsView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableAdditionalStyling.ChangeBackgroundColor(TableView);
          
            Title = "Settings";
        }

        public override async void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 0:
                    var logoutTask = ViewModel?.LogoutAsyncCommand.ExecuteAsync();
                    if (logoutTask != null)
                        await logoutTask;
                    break;
                case 1:
                    var deleteDbTask = ViewModel?.DeleteDbAsyncCommand.ExecuteAsync();
                    if (deleteDbTask != null)
                        await deleteDbTask;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }

            TableView.DeselectRow(indexPath, true);
        }
    }
}