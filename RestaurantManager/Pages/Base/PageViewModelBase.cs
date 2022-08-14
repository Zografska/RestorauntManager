using System;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Base
{
    public class PageViewModelBase : ViewModelBase
    {
        protected readonly IAuthService AuthService;
        public PageViewModelBase(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, INetworkService networkService)
            : base(navigationService, popupService, networkService)
        {
            AuthService = authService;
            Title = "RestaurantManager";
        }
    }
}