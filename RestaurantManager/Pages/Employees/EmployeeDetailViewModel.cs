using System.IO;
using System.Net;
using Prism.Common;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Employees
{
    public class EmployeeDetailViewModel : ViewModelBase
    {
        private User _employee;
        public ImageSource ImageSource { get; set; }
        public User Employee
        {
            get => _employee;
            set => SetProperty(ref _employee, value);
        }
        public EmployeeDetailViewModel(INavigationService navigationService, IPopupService popupService, INetworkService networkService) : base(navigationService, popupService, networkService)
        {
            Title = "Employee Detail";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var webClient = new WebClient();
            User employee;
            parameters.TryGetValue("employee", out employee);
            Employee = employee;

            byte[] imgBytes = webClient.DownloadData(employee.PhotoUrl);
            ImageSource = ImageSource.FromStream(() => new MemoryStream(imgBytes));
        }
    }
}