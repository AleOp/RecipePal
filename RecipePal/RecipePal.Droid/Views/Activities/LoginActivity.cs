using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using RecipePal.Core.ViewModels;
using RecipePal.Droid.Services;

namespace RecipePal.Droid.Views.Activities
{
    [Activity(Label = "LoginActivity", LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, Theme = "@style/AppTheme"
      )]
    public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
    {
        private Button _facebookLoginButton;
        private Button _googleLoginButton;
        private Button _microsoftLoginButton;
        private Button _signIn;

        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);

            SetContentView(Resource.Layout.activity_login);

            _facebookLoginButton = FindViewById<Button>(Resource.Id.facebook_login);
            _googleLoginButton = FindViewById<Button>(Resource.Id.google_login);
            _microsoftLoginButton = FindViewById<Button>(Resource.Id.microsoft_login);
            _signIn = FindViewById<Button>(Resource.Id.sign_in_button);

            LoginWithProviderServiceDroid.ApplicationContext = this;

            SetSigninEvent();

            var set = this.CreateBindingSet<LoginActivity, LoginViewModel>();

            set.Bind(_facebookLoginButton)
                .For("Click")
                .To(vm => vm.LoginAsyncCommand)
                .CommandParameter(MobileServiceAuthenticationProvider.Facebook);
            set.Bind(_googleLoginButton)
                .For("Click")
                .To(vm => vm.LoginAsyncCommand)
                .CommandParameter(MobileServiceAuthenticationProvider.Google);
            set.Bind(_microsoftLoginButton)
                .For("Click")
                .To(vm => vm.LoginAsyncCommand)
                .CommandParameter(MobileServiceAuthenticationProvider.MicrosoftAccount);
            set.Apply();
        }

        private void SetSigninEvent()
        {
            _signIn.Click += (sender, args) =>
            {
                _microsoftLoginButton.Animate().Alpha(1f);
                _facebookLoginButton.Animate().Alpha(1f);
                _googleLoginButton.Animate().Alpha(1f);
                _signIn.Animate().Alpha(0);
            };
        }
    }
}