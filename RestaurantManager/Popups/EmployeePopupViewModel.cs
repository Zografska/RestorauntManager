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
    public class EmployeePopupViewModel : BasePopupViewModel
    {
        public IEmployeeService EmployeeService { get; set; }
        private Employee _employee;

        public Employee Employee
        {
            get => _employee;
            set => SetProperty(ref _employee, value);
        }

        private bool _isDeletePossible;

        public bool IsDeletePossible
        {
            get => _isDeletePossible;
            set => SetProperty(ref _isDeletePossible, value);
        }

        public ICommand SaveCommand { get; }
        public Command DeleteCommand { get; }

        public EmployeePopupViewModel(INavigationService navigationService, IPopupService popupService,
            IEmployeeService employeeService) : base(navigationService, popupService)
        {
            EmployeeService = employeeService;
            SaveCommand = new Command(SaveEmployee);
            DeleteCommand = new Command(DeleteEmployee);
        }

        public override void OnPopupOpened(IPopupParameters parameters)
        {
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }

        private void InitPopup(IPopupParameters parameters)
        {
            Employee employee;
            parameters.TryGetValue("Item", out employee);

            if (employee != null)
            {
                IsDeletePossible = true;
            }

            Employee = employee ?? new Employee();
        }

        private async void SaveEmployee()
        {
            var updatedEmployee = await EmployeeService.Save(Employee);
            var parameters = new PopupParameters {{Constants.NavigationConstants.ItemUpdated, updatedEmployee}};
            UpdateCommand.Execute(parameters);
        }

        private async void DeleteEmployee()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Delete Employee",
                "Do you want to delete this employee?", "Yes", "No");
            if (answer)
            {
                var itemDeleted = await EmployeeService.RemoveById(Employee.Id);
                var parameters = new PopupParameters() {{Constants.NavigationConstants.ItemDeleted, itemDeleted}};
                UpdateCommand.Execute(parameters);
            }
        }
    }
}