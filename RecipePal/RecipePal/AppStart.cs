using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RecipePal.Core.Services.Interfaces;
using RecipePal.Core.ViewModels;

namespace RecipePal.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            var user = Mvx.Resolve<IAzureSignUpService>().CheckForUser();

            switch (user)
            {
                case false:
                    ShowViewModel<LoginViewModel>();
                    break;
                case true:
                    ShowViewModel<MainViewModel>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(user));
            }
        }
    }
}