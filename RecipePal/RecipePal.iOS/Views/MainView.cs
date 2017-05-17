using System;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Support.Views;
using MvvmCross.iOS.Views;
using RecipePal.Core.ViewModels;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main"),
     MvxTabPresentation(MvxTabPresentationMode.Root)]
    public partial class MainView : MvxBaseTabBarViewController<MainViewModel>
    {
        private bool _isPresentedFirstTime = true;

        public MainView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
           
                       
            if (ViewModel != null && _isPresentedFirstTime)
            {
                _isPresentedFirstTime = false;
                 ViewModel.ShowInitialViewModelsCommand.Execute();
            }
        }
    }
}