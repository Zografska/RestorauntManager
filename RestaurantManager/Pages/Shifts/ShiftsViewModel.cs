using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class ShiftsViewModel : ListViewModel<Shift>
    {
        public ShiftsViewModel(INavigationService navigationService, IPopupService popupService,
            DatabaseServiceRemote databaseServiceRemote) : base(navigationService, popupService, databaseServiceRemote )
        {
            Title = "Shifts";
            PopupName = nameof(ShiftPopup);
        }
    }
}