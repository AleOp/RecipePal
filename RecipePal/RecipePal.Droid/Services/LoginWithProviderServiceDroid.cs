using System.Threading.Tasks;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Droid.Services
{
    public class LoginWithProviderServiceDroid:ILoginWithProviderService
    {
        public static Context ApplicationContext;
        public async Task LoginAsync(MobileServiceAuthenticationProvider provider, IMobileServiceClient client)
        {
            await client.LoginAsync(ApplicationContext,provider);
        }
    }
}