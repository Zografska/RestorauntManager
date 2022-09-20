using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Model.DTOs;
using RestaurantManager.Pages.Base;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Reservations
{
    public class ReservationsPageViewModel : PageViewModelBase
    {
        private readonly IReservationService _reservationService;

        public ICommand DateTappedCommand { get; }
        public ICommand AddReservationCommand { get; }
        public ICommand ChangeDateCommand { get; }

        private ObservableCollection<ReservationDayDTO> _calendarDays;

        public ObservableCollection<ReservationDayDTO> CalendarDays
        {
            get => _calendarDays;
            set => SetProperty(ref _calendarDays, value);
        }

        private DateTime _currentDate;

        public DateTime CurrentDate
        {
            get => _currentDate;
            set => SetProperty(ref _currentDate, value);
        }

        public ReservationsPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, INetworkService networkService, IReservationService reservationService)
            : base(navigationService, popupService, authService, networkService)
        {
            Title = "Reservations";
            _reservationService = reservationService;
            DateTappedCommand = new SingleClickCommand<DateTime>(OpenReservationPopup);
            AddReservationCommand = new SingleClickCommand(AddReservation);
            ChangeDateCommand = new SingleClickCommand<string>(ChangeDate);
            CurrentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private async void ChangeDate(string sign)
        {
            if (sign == XamlConstants.Plus)
            {
                CurrentDate = new DateTime(CurrentDate.Year, CurrentDate.Month + 1, 1);
            }
            else
            {
                CurrentDate = new DateTime(CurrentDate.Year, CurrentDate.Month - 1, 1);
            }

            await RefreshCalendar();
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await RefreshCalendar();
        }

        private async Task RefreshCalendar()
        {
            var reservations = await _reservationService.GetAll();
            CalendarDays = CurrentDate.ToCalendarData(reservations);
        }

        private async void AddReservation()
        {
            await PopupService.ShowPopupAsync(nameof(ReservationCNIPopup), new PopupParameters
            {
                { Constants.NavigationConstants.Service, _reservationService }
            });

            SingleClickCommand.ResetLastClick();
        }

        private async void OpenReservationPopup(DateTime date)
        {
            await NavigationService.NavigateTo<ReservationDayDetailsPage>(new NavigationParameters
                { { Constants.NavigationConstants.Date, date } });

            SingleClickCommand.ResetLastClick();
        }
    }
}