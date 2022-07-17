using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Base
{
    public class PageViewModelBase : ViewModelBase
    {
        protected readonly IAuthService AuthService;
        public PageViewModelBase(INavigationService navigationService, IPopupService popupService, IAuthService authService)
            : base(navigationService, popupService)
        {
            AuthService = authService;
        }
    }
}