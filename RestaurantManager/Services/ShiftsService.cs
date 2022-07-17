using System;
using System.Threading.Tasks;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ShiftsService : BaseCrudService<Shift>, IShiftsService 
    {
        public ShiftsService(DatabaseServiceRemote databaseServiceRemote, IAuthService authService) 
            : base(databaseServiceRemote, authService)
        {
        }
    }
}