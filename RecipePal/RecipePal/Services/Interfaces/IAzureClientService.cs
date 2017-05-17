using Microsoft.WindowsAzure.MobileServices;

namespace RecipePal.Core.Services.Interfaces
{
    public interface IAzureClientService
    {
        IMobileServiceClient CurrentClient { get; set; }
    }
}