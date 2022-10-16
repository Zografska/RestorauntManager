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
        private IShiftsService ShiftsService { get; }
        private IProfileService ProfileService { get; }
        
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public ICommand OnUserSelectionCommand { get; }

        public ShiftPopupViewModel(INavigationService navigationService, IPopupService popupService,
            IShiftsService shiftsService, INetworkService networkService, IProfileService profileService) 
            : base(navigationService, popupService, networkService)
        {
            ShiftsService = shiftsService;
            ProfileService = profileService;
            OnUserSelectionCommand = new Command<int>(OnUserSelection);
        }

        public override void OnPopupOpened(IPopupParameters parameters)
        {
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }

        protected override async void InitPopup(IPopupParameters parameters)
        {
            base.InitPopup(parameters);
            Users = await ProfileService.GetAll();
        }

        private void OnUserSelection(int selectedIndex)
        {
            Item.User = Users[selectedIndex].FullName;
        }

    }
}