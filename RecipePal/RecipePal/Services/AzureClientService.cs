using Microsoft.WindowsAzure.MobileServices;
using RecipePal.Core.Helpers;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.Services
{
    public class AzureClientService : IAzureClientService
    {
        private IMobileServiceClient _client;
        public IMobileServiceClient CurrentClient {
            get
            {
                _client = _client ?? new MobileServiceClient(AppUrlConsts.AppUrl);
                return _client;             
            }
            set
            {
                if(_client == null)
                    _client = value;
            }
        }
    }
}