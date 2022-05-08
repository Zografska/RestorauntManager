using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Base
{
    public class PageViewModelBase : ViewModelBase
    {
        public PageViewModelBase(INavigationService navigationService, IPopupService popupService) : base(navigationService, popupService)
        {
        }
    }
}