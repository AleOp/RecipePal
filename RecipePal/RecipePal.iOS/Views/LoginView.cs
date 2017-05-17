using System;
using CoreGraphics;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.Presenters;
using MvvmCross.iOS.Views;
using RecipePal.Core.ViewModels;
using UIKit;

namespace RecipePal.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Login"),
     MvxTabPresentation(MvxTabPresentationMode.Root)]
    public partial class LoginView : MvxViewController<LoginViewModel>
    {
        private bool _wasAnimated;
        private CGPoint[] _oldButtonCenters;

        public LoginView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ClearNavigationStack();
            PrepareViews();
            CreateBindings();

            View.AddGestureRecognizer(new UITapGestureRecognizer(RevertAnimationChanges) {NumberOfTapsRequired = 1});
        }

        private void PrepareViews()
        {
            LoginPlaceholder.ImageUrl = "https://image.ibb.co/i0QK1Q/Recipe_Pal_Logo.png";

            ApplyMotionEffect(LoginPlaceholder, 50f);
            SetLoginBtnEvent();
        }

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(FacebookBtn)
                .To(vm => vm.LoginAsyncCommand)
                .CommandParameter(MobileServiceAuthenticationProvider.Facebook);
            set.Bind(GoogleBtn)
                .To(vm => vm.LoginAsyncCommand)
                .CommandParameter(MobileServiceAuthenticationProvider.Google);
            set.Bind(MicrosoftBtn)
                .To(vm => vm.LoginAsyncCommand)
                .CommandParameter(MobileServiceAuthenticationProvider.MicrosoftAccount);
            set.Apply();
        }

        private void SetLoginBtnEvent()
        {
            LoginBtn.TouchUpInside += (sender, args) =>
            {
                if (_oldButtonCenters == null)
                {
                    _oldButtonCenters = new[] {FacebookBtn.Center, GoogleBtn.Center, MicrosoftBtn.Center};
                }

                UIView.AnimateNotify(1, 0, 0.6f, 0f, UIViewAnimationOptions.CurveEaseOut, () =>
                {
                    FacebookBtn.Alpha = 1;
                    GoogleBtn.Alpha = 1;
                    MicrosoftBtn.Alpha = 1;
                    LoginTitle.Alpha = 0;
                    LoginDesc.Alpha = 0;
                    LoginBtn.Alpha = 0;


                    FacebookBtn.Center = new CGPoint(View.Bounds.Left + FacebookBtn.Bounds.Width / 2 + 20,
                        View.Center.Y);
                    GoogleBtn.Center = new CGPoint(View.Center.X, View.Center.Y);
                    MicrosoftBtn.Center = new CGPoint(View.Bounds.Right - MicrosoftBtn.Bounds.Width / 2 - 20,
                        View.Center.Y);
                }, null);

                _wasAnimated = true;
            };
        }

        private void ApplyMotionEffect(UIView view, nfloat magnitude)
        {
            var xMotion = new UIInterpolatingMotionEffect("center.x",
                UIInterpolatingMotionEffectType.TiltAlongHorizontalAxis);
            var yMotion = new UIInterpolatingMotionEffect("center.y",
                UIInterpolatingMotionEffectType.TiltAlongVerticalAxis);

            xMotion.MinimumRelativeValue = FromObject(-magnitude);
            xMotion.MaximumRelativeValue = FromObject(magnitude);
            yMotion.MinimumRelativeValue = FromObject(-magnitude);
            yMotion.MaximumRelativeValue = FromObject(magnitude);

            var motionGroup = new UIMotionEffectGroup {MotionEffects = new UIMotionEffect[] {xMotion, yMotion}};

            view.AddMotionEffect(motionGroup);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(true, false);

            RevertAnimationChanges();
        }

        private void RevertAnimationChanges()
        {
            if (_wasAnimated)
            {
                UIView.AnimateNotify(1, 0, 1f, 0f, UIViewAnimationOptions.CurveEaseIn, () =>
                {
                    FacebookBtn.Alpha = 0;
                    GoogleBtn.Alpha = 0;
                    MicrosoftBtn.Alpha = 0;
                    LoginTitle.Alpha = 1;
                    LoginDesc.Alpha = 1;
                    LoginBtn.Alpha = 0.6f;

                    FacebookBtn.Center = _oldButtonCenters[(int) Buttons.Facebook];
                    GoogleBtn.Center = _oldButtonCenters[(int) Buttons.Google];
                    MicrosoftBtn.Center = _oldButtonCenters[(int) Buttons.Microsoft];
                }, null);
                _wasAnimated = false;
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NavigationController.SetNavigationBarHidden(false, false);
        }

        private void ClearNavigationStack()
        {
            var viewControllers = NavigationController.ViewControllers;
            foreach (var vc in viewControllers)
            {
                if (vc.GetType() != GetType())
                {
                    vc.RemoveFromParentViewController();
                }
            }

            NavigationItem.HidesBackButton = true;
        }

        private enum Buttons
        {
            Facebook,
            Google,
            Microsoft
        }
    }
}