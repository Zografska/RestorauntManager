using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Authentication.Signup;
using RestaurantManager.Pages.Base;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Login
{
    public class LoginPageViewModel : PageViewModelBase
    {
        private readonly IAuthService _authService;
        
        public string Username { get; set; }
        public string Password { get; set; }
        
        public ICommand LoginCommand { get; set; }
        public ICommand NavigateToSignupCommand { get; set; }
        
        public LoginPageViewModel(INavigationService navigationService, IPopupService popupService, IAuthService auth) : base(navigationService, popupService)
        {
            _authService = auth;
            LoginCommand = new SingleClickCommand(Login);
            NavigateToSignupCommand = new SingleClickCommand(NavigateToSignup);
        }

        private async void NavigateToSignup()
        {
            try
            {
                await NavigationService.NavigateTo<SignupPage>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async void Login()
        {
            if (Username.IsNullOrEmpty() || Password.IsNullOrEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed",
                    "Login unsuccessful. \n Please try again", "OK");
                return;
            }
            
            var token = await _authService.LoginWithEmailPassword(Username, Password);
            if (!token.IsNullOrEmpty())
            {
                await NavigationService.NavigateTo<WelcomePage>();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed",
                    "Login unsuccessful. \n Please try again", "OK");
            }
        }
    }
}