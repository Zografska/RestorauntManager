using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ReservationService : BaseCrudService<Reservation>, IReservationService
    {
        public ReservationService(DatabaseServiceRemote databaseServiceRemote) : base(databaseServiceRemote)
        {
        }
    }
}