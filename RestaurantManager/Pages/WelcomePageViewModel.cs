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
        //TODO: Bind Command
        public ICommand OpenItemCommand { get; }
        public WelcomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "WelcomePage";
            
            // Add Throttle
            OpenItemCommand = new Command(NavigateToTodoPage);
        }

        private async void NavigateToTodoPage()
        {
            await NavigationService.NavigateTo<ToDoPage>();
        }
    }
}