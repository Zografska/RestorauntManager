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
        private IShiftsService ShiftsService { get; set; }

        public ShiftsViewModel(INavigationService navigationService, IPopupService popupService, IShiftsService shiftsService) : base(navigationService, popupService)
        {
            Title = "Shifts";
            ShiftsService = shiftsService;
            Items = new ObservableCollection<Shift>(ShiftsService.GetAll());
            PopupName = nameof(ShiftPopup);
        }
    }
}