using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Pages.Base;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Notes
{
    public class NotesTabbedPageViewModel : PageViewModelBase
    {
        public NotesTabbedPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService) : base(navigationService, popupService, authService)
        {
        }
    }
}