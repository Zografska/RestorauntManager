using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;

namespace RestaurantManager.Services
{
    public class ReservationService : BaseCrudService<Reservation>, IReservationService
    {
        public ReservationService(DatabaseServiceRemote databaseServiceRemote, IAuthService authService,
            INetworkService networkService) : base(databaseServiceRemote, authService, networkService)
        { }
    }
}