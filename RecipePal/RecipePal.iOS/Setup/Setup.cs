using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using RecipePal.Core;
using RecipePal.Core.Services.Interfaces;
using RecipePal.iOS.Services;
using UIKit;

namespace RecipePal.iOS.Setup
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<ILoginWithProviderService, LoginWithProviderServiceIos>();
            return new App();

        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            var presenter = new MvxTabsViewPresenter((MvxApplicationDelegate) ApplicationDelegate, Window);
            Mvx.RegisterSingleton<IMvxTabBarPresenter>(presenter);

            return presenter;
        }
    }
}