using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class ShiftsViewModel : ListViewModel<Shift>
    {
        public ShiftsViewModel(INavigationService navigationService, IPopupService popupService,
            DatabaseServiceRemote databaseServiceRemote, INetworkService networkService) 
            : base(navigationService, popupService, databaseServiceRemote, networkService)
        {
            Title = "Shifts";
            PopupName = nameof(ShiftPopup);
        }
    }
}