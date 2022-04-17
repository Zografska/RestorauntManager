using System.Reflection;
using Prism.Navigation;

namespace RestaurantManager
{
    public class WelcomePageViewModel : ViewModelBase
    {
        public WelcomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "WelcomePage";
        }
    }
}