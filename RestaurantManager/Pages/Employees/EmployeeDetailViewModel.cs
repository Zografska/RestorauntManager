using Prism.Common;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Employees
{
    public class EmployeeDetailViewModel : ViewModelBase
    {
        public User Employee { get; set; }
        public EmployeeDetailViewModel(INavigationService navigationService, IPopupService popupService, INetworkService networkService) : base(navigationService, popupService, networkService)
        {
            Title = "Employee Detail";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            User employee;
            parameters.TryGetValue("employee", out employee);
            Employee = employee;
        }
    }
}