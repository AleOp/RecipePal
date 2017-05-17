using Microsoft.WindowsAzure.MobileServices;
using RecipePal.Core.Services.Interfaces;
using UIKit;
using Task = System.Threading.Tasks.Task;

namespace RecipePal.iOS.Services
{
    public class LoginWithProviderServiceIos : ILoginWithProviderService
    {

        public async Task LoginAsync(MobileServiceAuthenticationProvider provider, IMobileServiceClient client)
        {
            var rootViewController =
                UIApplication.SharedApplication.KeyWindow.RootViewController;

            await client.LoginAsync(rootViewController, provider);
        }
    }
}