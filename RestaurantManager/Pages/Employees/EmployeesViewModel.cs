using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Employees
{
    public class EmployeesViewModel : ListViewModel<Employee>
    {
        protected EmployeesViewModel(INavigationService navigationService, IPopupService popupService, DatabaseServiceRemote databaseServiceRemote) : base(navigationService, popupService, databaseServiceRemote)
        {
            Title = "Employees";
            PopupName = nameof(EmployeePopup);
        }
    }
}