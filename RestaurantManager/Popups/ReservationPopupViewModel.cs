using Prism.Navigation;
using RestaurantManager.PopUps;
using RestaurantManager.Services.Network;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ReservationPopupViewModel : BasePopupViewModel
    {
        public ReservationPopupViewModel(INavigationService navigationService, IPopupService popupService, 
            INetworkService networkService) : base(navigationService, popupService, networkService)
        {
        }
    }
}