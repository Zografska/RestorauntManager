using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Base;
using RestaurantManager.Pages.Notes;
using RestaurantManager.Pages.Reservations;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Welcome
{
    public class WelcomePageViewModel : PageViewModelBase
    {
        public ICommand NavigateToNotesCommand { get; }
        public ICommand NavigateToShiftsCommand { get; }
        public ICommand NavigateToReservationsCommand { get; }
        public ICommand LogoutCommand { get; }

        public WelcomePageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService) : base(navigationService, popupService, authService)
        {
            Title = "Restaurant Manager";
            NavigateToNotesCommand = new SingleClickCommand(NavigateToNotesPage);
            NavigateToShiftsCommand = new SingleClickCommand(NavigateToShiftsPage);
            NavigateToReservationsCommand = new SingleClickCommand(NavigateToReservationsPage);
            LogoutCommand = new SingleClickCommand(Logout);
        }

        private void Logout()
        {
            var successful = AuthService.Logout();
            if (successful)
            {
                NavigationService.GoBackToRootAsync();
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.LogoutUnsuccessful);
            }
        }

        private async void NavigateToReservationsPage()
        {
            await NavigationService.NavigateTo<ReservationsPage>();
        }

        private async void NavigateToNotesPage()
        {
            await NavigationService.NavigateTo<NotesPage>();
        }

        private async void NavigateToShiftsPage()
        {
            await NavigationService.NavigateTo<ShiftsPage>();
        }
    }
}