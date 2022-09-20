using System;
using System.Collections.Generic;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Pages.Base;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Reservations
{
    public class ReservationDayDetailsPageViewModel : ListViewModel<Reservation>
    {
        private readonly IReservationService _reservationService;
        private readonly IPushNotificationsLocal _pushNotificationsLocal;

        private DateTime Day { get; set; }

        protected ReservationDayDetailsPageViewModel(IPushNotificationsLocal pushNotificationsLocal,
            INavigationService navigationService, IPopupService popupService,
            DatabaseServiceRemote databaseServiceRemote, INetworkService networkService,
            IReservationService reservationService)
            : base(navigationService, popupService, databaseServiceRemote, networkService)
        {
            _pushNotificationsLocal = pushNotificationsLocal;
            _reservationService = reservationService;
            _service = reservationService;
            Title = "Reservations";
            PopupName = nameof(ReservationCNIPopup);
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            if (NetworkService.IsNetworkConnected())
            {
                parameters.TryGetValue<DateTime>(Constants.NavigationConstants.Date, out var date);
                Day = date;

                if (!date.IsDefaultDate())
                {
                    Items = await _reservationService.GetAllByDate(date);
                }
                else
                {
                    await NavigationService.GoBackAsync();
                }
            }
            else
            {
                DisplayAlert("Connect to internet to load reservations!");
            }
        }

        protected override Reservation HandlePopupResult(IPopupParameters resultParameters, Reservation oldItem = null)
        {
            var newReservation = base.HandlePopupResult(resultParameters, oldItem);
            if (oldItem != null)
            {
                if (!Day.EqualsByDate(newReservation?.ReservationDate ?? default))
                {
                    Items.Remove(newReservation);
                }
            }

            if (newReservation != null)
                _pushNotificationsLocal.SendNotification("Reservation soon!",
                    $"Reservation for {newReservation.NumberOfPeople} comming up in 1 minute. Name: {newReservation.OnName}",
                    newReservation.ReservationDate.AddSeconds(60));

            return newReservation;
        }
    }
}