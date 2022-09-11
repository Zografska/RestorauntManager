using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ReservationCNIPopupViewModel : EditPopupViewModel<Reservation>
    {
        public ICommand PartyPickedCommand { get; set; }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set
            {
                SetProperty(ref _time, value);
                if (Time != TimeSpan.MinValue && Item != null)
                {
                    Item.ReservationDate = Item.ReservationDate.ChangeTime(value.Hours, value.Minutes);
                }
            }
        }
        
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                SetProperty(ref _date, value);
                if (Date != DateTime.MinValue && Item != null)
                {
                    Item.ReservationDate = Item.ReservationDate.ChangeDate(value.Year, value.Month, value.Day, Time);
                }
            }
        }
        
        public ReservationCNIPopupViewModel(INavigationService navigationService, IPopupService popupService,
            INetworkService networkService) : base(navigationService,
            popupService, networkService)
        {
            PartyPickedCommand = new Command<int>(PartyPicked);
        }

        protected override void InitPopup(IPopupParameters parameters)
        {
            base.InitPopup(parameters);
            
            var todayDate = Item.ReservationDate;
            Time = todayDate.TimeOfDay;
            Date = todayDate;
        }

        private void PartyPicked(int numberOfPeople)
        {
            Item.NumberOfPeople = numberOfPeople;
        }
    }
}