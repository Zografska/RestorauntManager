using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Authentication.Signup;
using RestaurantManager.Pages.Base;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Login
{
    public class LoginPageViewModel : PageViewModelBase
    {
        private readonly IAuthService _authService;
        private string _username { get; set; }
        private string _password { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand NavigateToSignupCommand { get; set; }
        
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(Username);
            }
        } 
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(Password);
            }
        }
        
        public LoginPageViewModel(INavigationService navigationService, IPopupService popupService, IAuthService auth) : base(navigationService, popupService)
        {
            _authService = auth;
            LoginCommand = new SingleClickCommand(Login);
            NavigateToSignupCommand = new SingleClickCommand(NavigateToSignup);
        }

        private async void NavigateToSignup()
        {
            await NavigationService.NavigateTo<SignupPage>();
        }

        private async void Login()
        {
            if (Username.IsNullOrEmpty() || Password.IsNullOrEmpty())
            {
                DisplayAlert(Constants.AlertConstants.ValidationAlert);
                return;
            }
            
            var token = await _authService.LoginWithEmailPassword(Username, Password);
            if (!token.IsNullOrEmpty())
            {
                await NavigationService.NavigateTo<WelcomePage>();
                ClearCredentials();
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.LoginUnsuccessfulAlert);
            }
        }

        private void ClearCredentials()
        {
            Username = Password = string.Empty;
        }
    }
}