using System;
using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Pages.Base;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Reservations
{
    public class ReservationsPageViewModel : PageViewModelBase
    {
        private ObservableCollection<string> _items = new ObservableCollection<string>()
        {
            "1","22","3","4","5","6","7"
        };
        public ObservableCollection<string> Week1
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        
        private ObservableCollection<DayOfWeek> _week = new ObservableCollection<DayOfWeek>()
        {
           new DayOfWeek(new DateTime(2022,8,1)),
           new DayOfWeek(new DateTime(2022,8,2)),
           new DayOfWeek(new DateTime(2022,8,3)),
           new DayOfWeek(new DateTime(2022,8,4)),
           new DayOfWeek(new DateTime(2022,8,5)),
           new DayOfWeek(new DateTime(2022,8,6)),
           new DayOfWeek(new DateTime(2022,8,7))
        };
        
        public ObservableCollection<DayOfWeek> WeekElements
        {
            get => _week;
            set => SetProperty(ref _week, value);
        }
        
        private ObservableCollection<string> _daysOfWeek = new ObservableCollection<string>()
        {
            "M","T","W","T","F","S","S"
        };
        public ObservableCollection<string> DaysOfWeek
        {
            get => _daysOfWeek;
            set => SetProperty(ref _daysOfWeek, value);
        }

        private readonly IReservationService _reservationService;
        
        public Command DateTappedCommand { get; }
        public Command AddReservationCommand { get; }
        public ReservationsPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, INetworkService networkService, IReservationService reservationService) 
            : base(navigationService, popupService, authService, networkService)
        {
            Title = "Reservations";
            _reservationService = reservationService;
            DateTappedCommand = new Command<DateTime>(OpenReservationPopup);
            AddReservationCommand = new Command(AddReservation);
        }

        private async void AddReservation()
        {
            await PopupService.ShowPopupAsync(nameof(ReservationCNIPopup), new PopupParameters {
                { Constants.NavigationConstants.Service, _reservationService }} );
        }

        private async void OpenReservationPopup(DateTime date)
        {
        }
    }
}

public class DayOfWeek
{
    public string Day { get; set; }
    public DateTime Value { get; set; }
    public string Position { get; set; }

    public DayOfWeek(DateTime date)
    {
        Day = date.Day.ToString();
        Position = ((date.Day - 1) % 7).ToString();
        Value = date;
    }
}