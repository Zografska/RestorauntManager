using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Pages;
using RestaurantManager.Pages.Base;
using RestaurantManager.Pages.Reservations;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public class WelcomePageViewModel : PageViewModelBase
    {
        private readonly IAuthService _authService;
        public ICommand NavigateToNotesCommand { get; }
        public ICommand NavigateToShiftsCommand { get; }
        public ICommand NavigateToReservationsCommand { get; }
        public ICommand LogoutCommand { get; }

        public WelcomePageViewModel(INavigationService navigationService, IPopupService popupService, IAuthService authService) : base(navigationService, popupService)
        {
            Title = "WelcomePage";
            _authService = authService;
            NavigateToNotesCommand = new SingleClickCommand(NavigateToNotesPage);
            NavigateToShiftsCommand = new SingleClickCommand(NavigateToShiftsPage);
            NavigateToReservationsCommand = new SingleClickCommand(NavigateToReservationsPage);
            LogoutCommand = new SingleClickCommand(Logout);
        }

        private void Logout()
        {
            _authService.Logout();
            NavigationService.GoBackToRootAsync();
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