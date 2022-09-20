using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Base;
using RestaurantManager.Pages.Employees;
using RestaurantManager.Pages.Notes;
using RestaurantManager.Pages.Reservations;
using RestaurantManager.Pages.Settings;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Essentials;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Welcome
{
    public class WelcomePageViewModel : PageViewModelBase
    {
        private readonly IProfileService _profileService;
        public ICommand NavigateToNotesCommand { get; }
        public ICommand NavigateToShiftsCommand { get; }
        public ICommand NavigateToReservationsCommand { get; }
        public ICommand NavigateToEmployeesCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand MapClickCommand { get; }

        public WelcomePageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, IProfileService profileService, INetworkService networkService) 
            : base(navigationService, popupService, authService, networkService)
        {
            Title = "Restaurant Manager";
            NavigateToNotesCommand = new SingleClickCommand(NavigateToNotesPage);
            NavigateToShiftsCommand = new SingleClickCommand(NavigateToShiftsPage);
            NavigateToReservationsCommand = new SingleClickCommand(NavigateToReservationsPage);
            NavigateToSettingsCommand = new SingleClickCommand(NavigateToSettingsPage);
            NavigateToEmployeesCommand = new SingleClickCommand(NavigateToEmployeesPage);
            MapClickCommand = new SingleClickCommand(NavigateToRestaurant);
            LogoutCommand = new SingleClickCommand(Logout);
            _profileService = profileService;
            IsBackButtonVisible = false;
        }

        private void Logout()
        {
            if (NetworkService.IsNetworkConnected())
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
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
            SingleClickCommand.ResetLastClick();
        }

        private async void NavigateToReservationsPage()
        {
            await NavigationService.NavigateTo<ReservationsPage>();
            SingleClickCommand.ResetLastClick();
        }

        private async void NavigateToNotesPage()
        {
            await NavigationService.NavigateTo<NotesPage>();
            SingleClickCommand.ResetLastClick();
        }

        private async void NavigateToShiftsPage()
        {
            await NavigationService.NavigateTo<ShiftsPage>();
            SingleClickCommand.ResetLastClick();
        }

        private async void NavigateToRestaurant()
        {
            var location = new Location(42.00417398712801, 21.409539851372777);
            var options = new MapLaunchOptions{ Name = "FCSE Building"};

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private async void NavigateToEmployeesPage()
        {
            await NavigationService.NavigateTo<EmployeesPage>();
            SingleClickCommand.ResetLastClick();
        }

        private async void NavigateToSettingsPage()
        {
            await NavigationService.NavigateTo<SettingsPage>();
            SingleClickCommand.ResetLastClick();
        }
    }
}