using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Pages.Base;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Signup
{
    public class SignupPageViewModel : PageViewModelBase
    {
        private readonly IAuthService _authService;
        public ICommand SignUpCommand { get; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public SignupPageViewModel(INavigationService navigationService, IPopupService popupService, IAuthService authService) : base(navigationService, popupService)
        {
            SignUpCommand = new SingleClickCommand(SignUpUser);
            _authService = authService;
        }

        private async void SignUpUser()
        {
            // Add Validation
           var result = await _authService.SignUpWithEmailPassword(Email, Password);
           var resultMessage = result ? "User is successfully signed in" : "User is not signed in";
           await Application.Current.MainPage.DisplayAlert("SignUp", resultMessage,"OK");
           await NavigationService.GoBackAsync();
        }
    }
}