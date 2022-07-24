using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Signup
{
    public class SignupPageViewModel : PageViewModelBase
    {
        private readonly IProfileService _profileService;
        public ICommand SignUpCommand { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public SignupPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, IProfileService profileService) : base(navigationService, popupService, authService)
        {
            SignUpCommand = new SingleClickCommand(SignUpUser);
            _profileService = profileService;
        }

        private async void SignUpUser()
        {
            if (Name.IsNullOrEmpty() || Surname.IsNullOrEmpty() || Password.IsNullOrEmpty() || Email.IsNullOrEmpty())
            {
                DisplayAlert("Fill in all the blanks");
                return;
            }
            
            var result = await AuthService.SignUpWithEmailPassword(Email, Password);
            if (!result.IsNullOrEmpty())
            {
                _ = _profileService.CreateUser(result, Name, Surname, Email);
            }
            var resultMessage = !result.IsNullOrEmpty() ? "User is successfully signed in" : "User is not signed in";
            DisplayAlert(resultMessage);
            await NavigationService.GoBackAsync();
        }
    }
}