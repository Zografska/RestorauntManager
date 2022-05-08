using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Shifts
{
    public class ShiftsViewModel : PageViewModelBase
    {
        private IShiftsService ShiftsService;
        private ObservableCollection<Shift> _shifts = new ObservableCollection<Shift>();
        public ObservableCollection<Shift> Shifts
        {
            get => _shifts;
            set => SetProperty(ref _shifts, value);
        }
        
        public ICommand ItemTappedCommand { get; }
        
        public ICommand AddShiftCommand { get; }
        
        public ShiftsViewModel(INavigationService navigationService, IPopupService popupService, IShiftsService shiftsService) : base(navigationService, popupService)
        {
            Title = "Shifts";
            ShiftsService = shiftsService;
            Shifts = ShiftsService.GetAllShifts();
            ItemTappedCommand = new SingleClickCommand<object>(ShowShiftPopup);
            AddShiftCommand = new SingleClickCommand(ShowCniPopup);
        }
        
        private async void ShowCniPopup()
        {
            IPopupResult result = await PopupService.ShowPopupAsync("ShiftPopup", new PopupParameters {{"Item", null}});
            
            HandlePopupResult(result.Parameters);
        }
        private async void ShowShiftPopup(object tappedShift)
        {
            var shift = tappedShift as Shift;
            
            IPopupResult result = await PopupService.ShowPopupAsync("ShiftPopup", new PopupParameters {{"Item", shift}});
            HandlePopupResult(result.Parameters, shift);
        }
        
        private void HandlePopupResult(IPopupParameters resultParameters, Shift oldShift = null)
        {
            Shift shift;
            if (resultParameters.TryGetValue(Constants.NavigationConstants.ItemUpdated, out shift))
            {
                if (oldShift != null)
                {
                    int index = Shifts.IndexOf(oldShift);
                    Shifts.Remove(oldShift);
                    Shifts.Insert(index, shift);
                }
                else
                {
                    Shifts.Add(shift);
                }
            }
            else if (resultParameters.ContainsKey(Constants.NavigationConstants.ItemDeleted))
            {
                Shifts.Remove(oldShift);
            }
        }
    }
}