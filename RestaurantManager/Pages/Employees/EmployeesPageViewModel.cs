using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Employees
{
    public class EmployeesPageViewModel : ListViewModel<User>
    {
        public ICommand NavigateToEmployeeDetailsCommand { get; }
        protected EmployeesPageViewModel(INavigationService navigationService, IPopupService popupService, DatabaseServiceRemote databaseServiceRemote, INetworkService networkService) : base(navigationService, popupService, databaseServiceRemote, networkService)
        {
            Title = "Employees";
            NavigateToEmployeeDetailsCommand = new Command<User>(NavigateToEmployeeDetails);
        }


        private async void NavigateToEmployeeDetails(User employee)
        {
            await NavigationService.NavigateTo<EmployeeDetail>(new NavigationParameters()
            {
                {
                    "employee", employee
                }
            });
            SingleClickCommand.ResetLastClick();
        }
    }
}