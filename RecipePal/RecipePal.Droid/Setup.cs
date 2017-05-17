using Android.Content;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using RecipePal.Core;
using RecipePal.Core.Services.Interfaces;
using RecipePal.Droid.Services;

namespace RecipePal.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<ILoginWithProviderService, LoginWithProviderServiceDroid>();
            return new App();
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }
    }
}