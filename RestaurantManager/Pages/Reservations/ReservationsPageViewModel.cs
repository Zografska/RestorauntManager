using System;
using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Pages.Base;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Reservations
{
    public class ReservationsPageViewModel : PageViewModelBase
    {
        private ObservableCollection<string> _items = new ObservableCollection<string>()
        {
            "1","2","3","4","5","6","7"
        };
        public ObservableCollection<string> Week1
        {
            get => _items;
            set => SetProperty(ref _items, value);
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
        public Command DateTappedCommand { get; }
        public ReservationsPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, INetworkService networkService) 
            : base(navigationService, popupService, authService, networkService)
        {
            Title = "Reservations";
            DateTappedCommand = new Command<DateTime>(OpenReservationPopup);
        }

        private void OpenReservationPopup(DateTime date)
        {
            PopupService.ShowPopupAsync(nameof(ReservationPopup), new PopupParameters {{"Date", date}} );
        }
    }
}