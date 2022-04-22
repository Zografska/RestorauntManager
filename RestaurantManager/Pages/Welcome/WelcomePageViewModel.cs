using System.Reflection;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Extensions;
using RestaurantManager.Pages;
using Xamarin.Forms;

namespace RestaurantManager
{
    public class WelcomePageViewModel : ViewModelBase
    {
        public ICommand NavigateToNotesCommand { get; }
        public WelcomePageViewModel(INavigationService navigationService) : base(navigationService)
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