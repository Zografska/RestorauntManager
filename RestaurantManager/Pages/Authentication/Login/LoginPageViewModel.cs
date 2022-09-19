using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Authentication.ResetPassword;
using RestaurantManager.Pages.Authentication.Signup;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Login
{
    public class LoginPageViewModel : PageViewModelBase
    {
        private readonly string SADMIN_EMAIL = "aleksandrazografska@halicea.com";
        private readonly string SADMIN_PASS = "-1380954559";
        private readonly IGoogleClientManager _googleClientManager;
        private readonly IProfileService _profileService;
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

        public ICommand LoginWithGoogleCommand { get; }

        public LoginPageViewModel(INavigationService navigationService, IPopupService popupService, 
            IAuthService authService, INetworkService networkService, IProfileService profileService) 
            : base(navigationService, popupService, authService, networkService)
        {
            LoginCommand = new SingleClickCommand(Login, () => IsLoginPossible);
            NavigateToSignupCommand = new SingleClickCommand(NavigateToSignup);
            NavigateToResetPasswordCommand = new SingleClickCommand(NavigateToResetPassword);
            LoginAsSadminCommand = new SingleClickCommand(LoginAsSadmin);
            LoginWithGoogleCommand = new AsyncCommand(LoginWithGoogle);
            _googleClientManager = CrossGoogleClient.Current;
            _profileService = profileService;
            
            IsBackButtonVisible = false;
            IsLogoutButtonVisible = false;
        }

        private async Task LoginWithGoogle()
        {
            try 
            {
                if (NetworkService.IsNetworkConnected())
                {
                    GoogleResponse<GoogleUser> googleResponse = await _googleClientManager.LoginAsync();
                    if (googleResponse.Status == GoogleActionStatus.Completed)
                    {
                        GoogleUser googleUser = googleResponse.Data;
                        var userExists = await _profileService.IsUserExistent(googleUser.Email);
                        Username = googleUser.Email;
                        Password = _profileService.GetGoogleUserPassword(googleUser.Email);
                        if (userExists)
                        {
                            Login();
                        }
                        else
                        {
                            var result = await AuthService.SignUpWithEmailPassword(Username,
                                Password);

                            if (!result.IsNullOrEmpty())
                            {
                                await _profileService.CreateUser(result, googleUser.GivenName, googleUser.FamilyName,
                                    Username);
                            }
                            else
                            {
                                DisplayAlert("Failed to create user, please try again");
                            }

                            Login();
                        }
                        // we use the sign in just for providing user login information, we logout since it's no longer needed
                        _googleClientManager.Logout();
                    }
                }
            }
            catch (Exception e)
            {
                DisplayAlert(e.Message);
            }
        }

        private async void LoginAsSadmin()
        {
            if (NetworkService.IsNetworkConnected())
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
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
            SingleClickCommand.ResetLastClick();
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
            if (NetworkService.IsNetworkConnected())
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
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
            SingleClickCommand.ResetLastClick();
        }

        private void ClearCredentials()
        {
            Username = Password = string.Empty;
        }
    }
}