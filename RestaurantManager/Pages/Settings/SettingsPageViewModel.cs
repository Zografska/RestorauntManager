
using Prism.Navigation;
using RestaurantManager.Services.Network;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Settings
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(INavigationService navigationService, IPopupService popupService, INetworkService networkService) : base(navigationService, popupService, networkService)
        {
            Title = "Settings";
        }
    }
}