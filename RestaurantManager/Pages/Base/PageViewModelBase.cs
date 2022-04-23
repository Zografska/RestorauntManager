using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Base
{
    public class PageViewModelBase : ViewModelBase
    {
        protected IPopupService PopupService;
        
        public PageViewModelBase(INavigationService navigationService, IPopupService popupService) : base(navigationService)
        {
            PopupService = popupService;
        }
    }
}