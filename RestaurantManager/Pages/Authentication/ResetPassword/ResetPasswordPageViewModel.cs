using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.ResetPassword
{
    public class ResetPasswordPageViewModel : PageViewModelBase
    {
        public ICommand ResetPasswordCommand { get; }
        public string Email { get; set; }
        public ResetPasswordPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, INetworkService networkService) 
            : base(navigationService, popupService, authService, networkService)
        {
            ResetPasswordCommand = new SingleClickCommand(ResetPassword);
        }

        private async void ResetPassword()
        {
            if (Email.IsNullOrEmpty())
            {
                return;
            }
            await AuthService.ResetPassword(Email);
            DisplayAlert(Constants.AlertConstants.ResetInstructionsSent);
        }
    }
}