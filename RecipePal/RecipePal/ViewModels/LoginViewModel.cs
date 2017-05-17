using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Core.ViewModels;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public static MobileServiceAuthenticationProvider ChosenProvider = MobileServiceAuthenticationProvider.Facebook;
        private readonly IAzureSignUpService _signUpService;
        private MvxAsyncCommand<MobileServiceAuthenticationProvider> _signInAsyncCommand;

        public LoginViewModel(IAzureSignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        public IMvxAsyncCommand LoginAsyncCommand
        {
            get
            {
                _signInAsyncCommand = _signInAsyncCommand ??
                                      new MvxAsyncCommand<MobileServiceAuthenticationProvider>(SignInUserAsync);
                return _signInAsyncCommand;
            }
        }

        private async Task SignInUserAsync(MobileServiceAuthenticationProvider provider)
        {
            ChosenProvider = provider;

            var user = await _signUpService.LoginAsync(ChosenProvider);
            if (user != null)
                ShowViewModel<MainViewModel>();
        }
    }
}