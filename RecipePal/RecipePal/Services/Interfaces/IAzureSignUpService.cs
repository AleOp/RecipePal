using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace RecipePal.Core.Services.Interfaces
{
    public interface IAzureSignUpService
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider);
        Task LogoutAsync();
        bool CheckForUser();
    }
}