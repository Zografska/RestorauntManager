using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;

namespace RestaurantManager.Services
{
    public class ReservationService : BaseCrudService<Reservation>, IReservationService
    {
        public ReservationService(DatabaseServiceRemote databaseServiceRemote, IAuthService authService,
            INetworkService networkService) : base(databaseServiceRemote, authService, networkService)
        { }

        public async Task<ObservableCollection<Reservation>> GetAllByDate(DateTime dateTime)
        {
            var reservations = await GetAll();
            return reservations.Where(reservation 
                => reservation.ReservationDate.Date.EqualsByDate(dateTime.Date)).ToObservableCollection();
        }
    }
}