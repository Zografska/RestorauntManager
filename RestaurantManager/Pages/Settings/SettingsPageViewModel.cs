
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Settings
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public ICommand OnRadioButtonClickCommand { get; }
        public SettingsPageViewModel(INavigationService navigationService, IPopupService popupService, INetworkService networkService) : base(navigationService, popupService, networkService)
        {
            Title = "Settings";
            OnRadioButtonClickCommand = new Command<string>(OnRadioButtonClick);
        }

        private void OnRadioButtonClick(string value)
        {
            switch (value)
            {
                case "System":
                    Utility.Settings.Theme = 0;
                    break;
                case "Light":
                    Utility.Settings.Theme = 1;
                    break;
                case "Dark":
                    Utility.Settings.Theme = 2;
                    break;
            }
            
            Theme.SetTheme();
        }
    }
}