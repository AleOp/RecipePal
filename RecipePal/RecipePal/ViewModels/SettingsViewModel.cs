using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Messages;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        private readonly IAzureSignUpService _azureSignUpService;
        private readonly IRepository _repository;

        private IMvxAsyncCommand _deleteDbAsyncCommand;
        private IMvxAsyncCommand _logoutCommand;
        private IList<string> _settingsList;
        private IMvxAsyncCommand _settingsOptionCommand;

        public SettingsViewModel(IAzureSignUpService azureSignUpService, IRepository repository)
        {
            _azureSignUpService = azureSignUpService;
            _repository = repository;

            SettingsList = new List<string>
            {
                "Log out",
                "Delete all recipes from the database"
            };
        }

        public IMvxAsyncCommand LogoutAsyncCommand
        {
            get
            {
                _logoutCommand = _logoutCommand ?? new MvxAsyncCommand(LogoutAsyncCommandHandler);
                return _logoutCommand;
            }
        }

        public IMvxAsyncCommand DeleteDbAsyncCommand
        {
            get
            {
                _deleteDbAsyncCommand = _deleteDbAsyncCommand ?? new MvxAsyncCommand(DeleteDbAsyncCommandHandler);
                return _deleteDbAsyncCommand;
            }
        }

        public IMvxAsyncCommand SettingsOptionCommand
        {
            get
            {
                _settingsOptionCommand = _settingsOptionCommand ?? new MvxAsyncCommand<string>(InvokeSettingsOptionAsyncCommandHandler);
                return _settingsOptionCommand;
            }
        }
     

        public IList<string> SettingsList
        {
            get { return _settingsList; }
            set { SetProperty(ref _settingsList, value); }
        }

        private async Task LogoutAsyncCommandHandler()
        {
            await _azureSignUpService.LogoutAsync();
            ShowViewModel<LoginViewModel>();
        }

        private async Task DeleteDbAsyncCommandHandler()
        {
            //TODO show success meassage
            var isSuccesseded = await _repository.DeleteDataFromDatabase();
            if (isSuccesseded)
                Mvx.Resolve<IMvxMessenger>().Publish(new RefreshDataSetsMessage(this));
        }

        private async Task InvokeSettingsOptionAsyncCommandHandler(string arg)
        {
            if (string.Equals(arg, SettingsList[0]))
            {
                await LogoutAsyncCommand.ExecuteAsync();
            }
            else
            {
                await DeleteDbAsyncCommand.ExecuteAsync();
            }
        }
    }
}