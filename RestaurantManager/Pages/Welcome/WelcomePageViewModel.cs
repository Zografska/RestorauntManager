using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Pages;
using RestaurantManager.Pages.Base;
using RestaurantManager.Pages.Reservations;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public class WelcomePageViewModel : PageViewModelBase
    {
        public ICommand NavigateToNotesCommand { get; }
        public ICommand NavigateToShiftsCommand { get; }
        public ICommand NavigateToReservationsCommand { get; }
        public ICommand NavigateToEmployeesCommand { get; }

        public WelcomePageViewModel(INavigationService navigationService, IPopupService popupService, DatabaseServiceRemote databaseServiceRemote) : base(navigationService, popupService)
        {
            Title = "Restaurant Manager";
            NavigateToNotesCommand = new Command(NavigateToNotesPage);
            NavigateToShiftsCommand = new Command(NavigateToShiftsPage);
            NavigateToReservationsCommand = new Command(NavigateToReservationsPage);
            NavigateToEmployeesCommand = new Command(NavigateToEmployeesPage);
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

        private async void NavigateToEmployeesPage()
        {
            await NavigationService.NavigateTo<EmployeesPage>();
        }
    }
}