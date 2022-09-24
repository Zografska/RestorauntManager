using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Employees
{
    public class EmployeesPageViewModel : ListViewModel<User>
    {
        public ICommand NavigateToEmployeeDetailsCommand { get; }
        protected EmployeesPageViewModel(INavigationService navigationService, IPopupService popupService, DatabaseServiceRemote databaseServiceRemote, INetworkService networkService, IProfileService profileService) : base(navigationService, popupService, databaseServiceRemote, networkService)
        {
            Title = "Employees";
            _service = profileService;
            NavigateToEmployeeDetailsCommand = new Command<User>(NavigateToEmployeeDetails);
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            if (NetworkService.IsNetworkConnected())
            {
                Items = await _databaseServiceRemote.GetAll<User>();
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
        }

        private async void NavigateToEmployeeDetails(User employee)
        {
            await NavigationService.NavigateTo<EmployeeDetail>(new NavigationParameters
            {
                {
                    Constants.NavigationConstants.Employee, employee
                }
            });
            SingleClickCommand.ResetLastClick();
        }
    }
}