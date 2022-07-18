using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class InventoryPageViewModel : ListViewModel<Item>
    {
        public InventoryPageViewModel(INavigationService navigationService, IPopupService popupService, DatabaseServiceRemote databaseServiceRemote) : base(navigationService, popupService, databaseServiceRemote)
        {
            Title = "Inventory";
            PopupName = nameof(InventoryPopup);
        }
    }
}