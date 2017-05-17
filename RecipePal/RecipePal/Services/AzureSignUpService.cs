using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using RecipePal.Core.Helpers;
using RecipePal.Core.Services.Interfaces;
using Xamarin.Auth;


namespace RecipePal.Core.Services
{
    public class AzureSignUpService : IAzureSignUpService
    {
        private readonly ILoginWithProviderService _loginHelper;
        private readonly IMobileServiceClient _client;

        private readonly AccountStore _accountStore;


        public AzureSignUpService(ILoginWithProviderService loginHelper, IAzureClientService azureClient)
        {
            _loginHelper = loginHelper;
            _accountStore = AccountStore.Create();
            _client = azureClient.CurrentClient;

        }

        public async Task LogoutAsync()
        {
            if (_client.CurrentUser?.MobileServiceAuthenticationToken == null)
                return;

            // Invalidate the token on the mobile backend
            var authUri = new Uri($"{_client.MobileAppUri}/.auth/logout");
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-ZUMO-AUTH", _client.CurrentUser.MobileServiceAuthenticationToken);
                await httpClient.GetAsync(authUri);
            }

            // Remove the token from the cache
            RemoveTokenFromSecureStore();

            // Remove the token from the MobileServiceClient
            await _client.LogoutAsync();
        }


        public bool CheckForUser()
        {
            _client.CurrentUser = RetrieveTokenFromSecureStore();

            return _client.CurrentUser != null;
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            if (CheckForUser())
            {
                try
                {
                    var refreshed = await _client.RefreshUserAsync();
                    if (refreshed != null)
                    {
                        StoreTokenInSecureStore(refreshed);
                        return refreshed;
                    }
                }
                catch (Exception refreshException)
                {
                    Debug.WriteLine($"Could not refresh token: {refreshException.Message}");
                }

                if (!IsTokenExpired(_client.CurrentUser.MobileServiceAuthenticationToken))
                {
                    return _client.CurrentUser;
                }
            }

            try
            {
                await _loginHelper.LoginAsync(provider, _client);
            }
            catch (Exception e)
                when (e.GetType() == typeof(InvalidOperationException) || e.Message.Contains("canceled by the user"))
            {
                return null;
            }

            if (_client.CurrentUser != null)
            {
                // We were able to successfully log in
                StoreTokenInSecureStore(_client.CurrentUser);
            }
            return _client.CurrentUser;
        }

        private MobileServiceUser RetrieveTokenFromSecureStore()
        {
            var accounts = _accountStore.FindAccountsForService(AppUrlConsts.AppServiceId);

            if (accounts == null) return null;

            foreach (var acct in accounts)
            {
                string token;

                if (acct.Properties.TryGetValue(AppUrlConsts.AppUserTokenKey, out token))
                {
                    return new MobileServiceUser(acct.Username)
                    {
                        MobileServiceAuthenticationToken = token
                    };
                }
            }

            return null;
        }

        private void StoreTokenInSecureStore(MobileServiceUser user)
        {
            var account = new Account(user.UserId);
            account.Properties.Add(AppUrlConsts.AppUserTokenKey, user.MobileServiceAuthenticationToken);
            _accountStore.Save(account, AppUrlConsts.AppServiceId);
        }

        private void RemoveTokenFromSecureStore()
        {
            var accounts = _accountStore.FindAccountsForService(AppUrlConsts.AppServiceId);
            if (accounts != null)
            {
                foreach (var acct in accounts)
                {
                    _accountStore.Delete(acct, AppUrlConsts.AppServiceId);
                }
            }
        }

        private bool IsTokenExpired(string token)
        {
            // Get just the JWT part of the token (without the signature).
            var jwt = token.Split('.')[1];

            // Undo the URL encoding.
            jwt = jwt.Replace('-', '+').Replace('_', '/');
            switch (jwt.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    jwt += "==";
                    break;
                case 3:
                    jwt += "=";
                    break;
                default:
                    throw new ArgumentException("The token is not a valid Base64 string.");
            }

            // Convert to a JSON String
            var bytes = Convert.FromBase64String(jwt);
            var jsonString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            // Parse as JSON object and get the exp field value,
            // which is the expiration date as a JavaScript primative date.
            var jsonObj = JObject.Parse(jsonString);
            var exp = Convert.ToDouble(jsonObj["exp"].ToString());

            // Calculate the expiration by adding the exp value (in seconds) to the
            // base date of 1/1/1970.
            var minTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var expire = minTime.AddSeconds(exp);
            return (expire < DateTime.UtcNow);
        }
    }
}