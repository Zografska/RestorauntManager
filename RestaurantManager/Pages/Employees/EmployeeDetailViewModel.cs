using System;
using System.IO;
using System.Net;
using Prism.Common;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Employees
{
    public class EmployeeDetailViewModel : ViewModelBase
    {
        private User _employee;
        private ImageSource _imageSource;

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public User Employee
        {
            get => _employee;
            set => SetProperty(ref _employee, value);
        }

        public EmployeeDetailViewModel(INavigationService navigationService, IPopupService popupService,
            INetworkService networkService) : base(navigationService, popupService, networkService)
        {
            Title = "Employee Detail";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var webClient = new WebClient();
            User employee;
            parameters.TryGetValue(Constants.NavigationConstants.Employee, out employee);
            Employee = employee;

            if (NetworkService.IsNetworkConnected())
            {
                try
                {
                    var imgBytes = webClient.DownloadData(
                        $"https://firebasestorage.googleapis.com/v0/b/restaurantmanagerdb.appspot.com/o{new Uri($"https://{employee.PhotoUrl}").PathAndQuery}?alt=media");
                    ImageSource = ImageSource.FromStream(() => new MemoryStream(imgBytes));
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
        }
    }
}