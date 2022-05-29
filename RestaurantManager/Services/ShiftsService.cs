using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DryIoc;
using RestaurantManager.Enums;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ShiftsService : BaseCrudService<Shift>, IShiftsService 
    {
        public ShiftsService()
        {
            Entities = new List<Shift>
            {
                new Shift{ User = "Steve", Type = ShiftType.Daily, Hours = 8, Date = DateTime.Now},
                new Shift{ User = "John", Type = ShiftType.Daily, Hours = 8, Date = DateTime.Now},
                new Shift{ User = "Lucas", Type = ShiftType.Nightly, Hours = 8, Date = DateTime.Now},
                new Shift{ User = "Tom", Type = ShiftType.Nightly, Hours = 8, Date = DateTime.Now}
            };
        }
        
        public override bool Update(Shift updatedEntity)
        {
            updatedEntity.Date = DateTime.Now;
            return base.Update(updatedEntity);
        }
    }
}