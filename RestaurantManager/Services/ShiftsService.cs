using System;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ShiftsService : BaseCrudService, IShiftsService 
    {
        public ShiftsService(DatabaseServiceRemote databaseServiceRemote) : base(databaseServiceRemote)
        {
        }
        
        // TODO: Ask Vlado why this date is updated upon update?
        public override async Task<bool> Update<T>(T updatedEntity)
        {
            var shift = updatedEntity as Shift;
            if (shift == null)
            {
                return false;
            }
            shift.Date = DateTime.Now;
            return await base.Update(shift);
        }
    }
}