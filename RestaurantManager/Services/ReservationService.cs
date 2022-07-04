using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ReservationService : BaseCrudService, IReservationService
    {
        public ReservationService(DatabaseServiceRemote databaseServiceRemote) : base(databaseServiceRemote)
        {
            // Entities = new List<Reservation>()
            // {
            //     new Reservation { Name = "Alex", NumberInParty = 3, ReservationDate = RandomDay() },
            //     new Reservation { Name = "Zogsi", NumberInParty = 2, ReservationDate = RandomDay() },
            //     new Reservation { Name = "Vlado", NumberInParty = 4, ReservationDate = RandomDay() },
            //     new Reservation { Name = "Baze", NumberInParty = 5, ReservationDate = RandomDay() },
            // };
        }
    }
}