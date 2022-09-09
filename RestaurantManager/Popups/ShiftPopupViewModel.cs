using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ShiftPopupViewModel : EditPopupViewModel<Shift>
    {
        public IShiftsService ShiftsService { get; set; }
        public IProfileService ProfileService { get; set; }
        private Shift _shift;

        public Shift Shift
        {
            get => _shift;
            set => SetProperty(ref _shift, value);
        }

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private bool _isDeletePossible;
        public bool IsDeletePossible
        {
            get => _isDeletePossible;
            set => SetProperty(ref _isDeletePossible, value);
        }

        public ICommand SaveCommand { get; }
        public Command DeleteCommand { get; }
        public ICommand OnUserSelectionCommand { get; }


        public ShiftPopupViewModel(INavigationService navigationService, IPopupService popupService,
            IShiftsService shiftsService, INetworkService networkService, IProfileService profileService) 
            : base(navigationService, popupService, networkService)
        {
            ShiftsService = shiftsService;
            ProfileService = profileService;
            SaveCommand = new Command(SaveShift);
            DeleteCommand = new Command(DeleteShift);
            OnUserSelectionCommand = new Command<int>(OnUserSelection);
        }

        public override void OnPopupOpened(IPopupParameters parameters)
        {
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }

        private async void InitPopup(IPopupParameters parameters)
        {
            Shift shift;
            parameters.TryGetValue("Item", out shift);

            if (shift != null)
            {
                IsDeletePossible = true;
            }
            Users = await ProfileService.GetAll();

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
                var itemDeleted = await ShiftsService.RemoveById(Shift.Id);
                var parameters = new PopupParameters() { {  Constants.NavigationConstants.ItemDeleted, itemDeleted } };
                UpdateCommand.Execute(parameters);
            }
        }

        private void OnUserSelection(int selectedIndex)
        {
            Shift.User = Users[selectedIndex].FullName;
        }

    }
}