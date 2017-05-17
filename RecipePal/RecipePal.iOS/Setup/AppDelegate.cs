using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace RecipePal.iOS.Setup
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ChangeControlsFont();

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;
        }

        private static void ChangeControlsFont()
        {
            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes {Font = UIFont.FromName("Noteworthy-Bold", 11)},
                UIControlState.Normal & UIControlState.Selected);
            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes {Font = UIFont.FromName("Noteworthy", 17)},
                UIControlState.Normal & UIControlState.Selected);
            UINavigationBar.Appearance.TitleTextAttributes =
                new UIStringAttributes {Font = UIFont.FromName("Noteworthy-Bold", 17f)};
            UIWindow.Appearance.TintColor = UIColor.Red;
        }
    }
}