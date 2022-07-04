using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ShiftPopupViewModel : BasePopupViewModel
    {
        public IShiftsService ShiftsService { get; set; }
        private Shift _shift;

        public Shift Shift
        {
            get => _shift;
            set => SetProperty(ref _shift, value);
        }
        
        private bool _isDeletePossible;
        public bool IsDeletePossible
        {
            get => _isDeletePossible;
            set => SetProperty(ref _isDeletePossible, value);
        }

        public ICommand SaveCommand { get; }
        public Command DeleteCommand { get; }

        public ShiftPopupViewModel(INavigationService navigationService, IPopupService popupService,
            IShiftsService shiftsService) : base(navigationService, popupService)
        {
            ShiftsService = shiftsService;
            SaveCommand = new Command(SaveShift);
            DeleteCommand = new Command(DeleteShift);
        }

        public override void OnPopupOpened(IPopupParameters parameters)
        {
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }

        private void InitPopup(IPopupParameters parameters)
        {
            Shift shift;
            parameters.TryGetValue("Item", out shift);

            if (shift != null)
            {
                IsDeletePossible = true;
            }

            Shift = shift ?? new Shift();
        }
        private async void SaveShift()
        {
            var updatedShift = await ShiftsService.Save(Shift);
            var parameters = new PopupParameters { { Constants.NavigationConstants.ItemUpdated, updatedShift } };
            UpdateCommand.Execute(parameters);
        }
        
        private async void DeleteShift()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Delete Shift", "Do you want to delete this shift?", "Yes", "No");
            if (answer)
            {
                var itemDeleted = await ShiftsService.RemoveById<Shift>(Shift.Id);
                var parameters = new PopupParameters() { {  Constants.NavigationConstants.ItemDeleted, itemDeleted } };
                UpdateCommand.Execute(parameters);
            }
        }
    }
}