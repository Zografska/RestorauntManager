
using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Settings
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(INavigationService navigationService, IPopupService popupService) : base(navigationService, popupService)
        {
            Title = "Settings";
        }
    }
}