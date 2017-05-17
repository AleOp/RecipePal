using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace RecipePal.Core.Services.Interfaces
{
    public interface ILoginWithProviderService
    {
        Task LoginAsync(MobileServiceAuthenticationProvider provider, IMobileServiceClient client);
    }
}