using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ReservationPopupViewModel : EditPopupViewModel<Reservation>
    {
        public ReservationPopupViewModel(INavigationService navigationService, IPopupService popupService, 
            INetworkService networkService, IReservationService reservationService) : base(navigationService, popupService, networkService)
        { }
    }
}