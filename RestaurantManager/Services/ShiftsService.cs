using System;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ShiftsService : BaseCrudService<Shift>, IShiftsService 
    {
        public ShiftsService(DatabaseServiceRemote databaseServiceRemote) : base(databaseServiceRemote)
        {
        }
    }
}