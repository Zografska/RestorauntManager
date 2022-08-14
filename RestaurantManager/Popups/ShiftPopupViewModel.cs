using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ShiftPopupViewModel : EditPopupViewModel<Shift>
    {
        public ShiftPopupViewModel(INavigationService navigationService, IPopupService popupService,
            INetworkService networkService) : base(navigationService, popupService, networkService)
        {
        }
    }
}