using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Authentication.ResetPassword;
using RestaurantManager.Pages.Authentication.Signup;
using RestaurantManager.Pages.Base;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Login
{
    public class LoginPageViewModel : PageViewModelBase
    {
        private readonly string SADMIN_EMAIL = "aleksandrazografska@halicea.com";
        private readonly string SADMIN_PASS = "zografska1";
        private string _username { get; set; }
        private string _password { get; set; }
        private bool _usernameValid { get; set; }
        private bool _passwordValid { get; set; }

        public bool IsLoginPossible => _usernameValid && _passwordValid;
        public ICommand LoginCommand { get; set; }
        public ICommand LoginAsSadminCommand { get; set; }
        public ICommand NavigateToSignupCommand { get; set; }
        public ICommand NavigateToResetPasswordCommand { get; set; }
        public bool PasswordValid
        {
            set
            {
                _passwordValid = value && !Username.IsNullOrEmpty();
                RaisePropertyChanged(nameof(IsLoginPossible));
            }
        } 
        public bool UsernameValid
        {
            set
            {
                _usernameValid = value && !Password.IsNullOrEmpty();
                RaisePropertyChanged(nameof(IsLoginPossible));
            }
        } 
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        } 
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        
        public LoginPageViewModel(INavigationService navigationService, IPopupService popupService, IAuthService auth) 
            : base(navigationService, popupService, auth)
        {
            LoginCommand = new SingleClickCommand(Login, () => IsLoginPossible);
            NavigateToSignupCommand = new SingleClickCommand(NavigateToSignup);
            NavigateToResetPasswordCommand = new SingleClickCommand(NavigateToResetPassword);
            LoginAsSadminCommand = new SingleClickCommand(LoginAsSadmin);
        }

        private async void LoginAsSadmin()
        {
            var token = await AuthService.LoginWithEmailPassword(SADMIN_EMAIL, SADMIN_PASS);
            if (!token.IsNullOrEmpty())
            {
                await NavigationService.NavigateTo<WelcomePage>();
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.LoginUnsuccessfulAlert);
            }
        }

        private async void NavigateToResetPassword()
        {
            await NavigationService.NavigateTo<ResetPasswordPage>();
        }

        private async void NavigateToSignup()
        {
            await NavigationService.NavigateTo<SignupPage>();
        }

        private async void Login()
        {
            var token = await AuthService.LoginWithEmailPassword(Username, Password);
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