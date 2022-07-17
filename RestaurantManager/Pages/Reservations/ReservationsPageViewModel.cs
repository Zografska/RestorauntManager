using System;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Pages.Base;
using RestaurantManager.Popups;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Reservations
{
    public class ReservationsPageViewModel : PageViewModelBase
    {
        public Command DateTappedCommand { get; }
        public ReservationsPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService) : base(navigationService, popupService, authService)
        {
            Title = "Reservations";
            DateTappedCommand = new Command<DateTime>(OpenReservationPopup);
        }

        private void OpenReservationPopup(DateTime date)
        {
            PopupService.ShowPopupAsync(nameof(ReservationPopup), new PopupParameters {{"Date", date}} );
        }
    }
}