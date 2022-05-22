using Prism.Navigation;
using RestaurantManager.PopUps;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ReservationPopupViewModel : BasePopupViewModel
    {
        public ReservationPopupViewModel(INavigationService navigationService, IPopupService popupService) : base(navigationService, popupService)
        {
        }
    }
}