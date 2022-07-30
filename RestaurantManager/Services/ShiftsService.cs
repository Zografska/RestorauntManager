using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;

namespace RestaurantManager.Services
{
    public class ShiftsService : BaseCrudService<Shift>, IShiftsService 
    {
        public ShiftsService(DatabaseServiceRemote databaseServiceRemote, IAuthService authService,
            INetworkService networkService) : base(databaseServiceRemote, authService, networkService)
        { }
    }
}