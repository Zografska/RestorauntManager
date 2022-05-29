using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Extensions;
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
        public ICommand NavigateToShiftsCommand { get; set; }
        
        public ICommand NavigateToReservationsCommand { get; }

        protected IPopupService PopupService { get; private set; }
        public WelcomePageViewModel(INavigationService navigationService, IPopupService popupService) : base(navigationService, popupService)
        {
            Title = "WelcomePage";
            NavigateToNotesCommand = new Command(NavigateToNotesPage);
            NavigateToShiftsCommand = new Command(NavigateToShiftsPage);
            NavigateToReservationsCommand = new Command(NavigateToReservationsPage);
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