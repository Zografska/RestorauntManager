using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Extensions;
using RestaurantManager.Pages;
using RestaurantManager.Pages.Base;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public class WelcomePageViewModel : PageViewModelBase
    {
        public ICommand NavigateToNotesCommand { get; }
        
        protected IPopupService PopupService { get; private set; }
        public WelcomePageViewModel(INavigationService navigationService, IPopupService popupService) : base(navigationService, popupService)
        {
            Title = "WelcomePage";
            NavigateToNotesCommand = new Command(NavigateToNotesPage);
        }

        private async void NavigateToNotesPage()
        {
            await NavigationService.NavigateTo<NotesPage>();
        }
    }
}