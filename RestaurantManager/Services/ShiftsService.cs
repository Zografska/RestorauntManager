using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DryIoc;
using RestaurantManager.Enums;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ShiftsService : IShiftsService
    {
        public List<Shift> Shifts { get; set; }

        public ShiftsService()
        {
            Shifts = new List<Shift>
            {
                new Shift{ User = "Steve", Type = ShiftType.Daily, Hours = 8, Date = DateTime.Now},
                new Shift{ User = "John", Type = ShiftType.Daily, Hours = 8, Date = DateTime.Now},
                new Shift{ User = "Lucas", Type = ShiftType.Nightly, Hours = 8, Date = DateTime.Now},
                new Shift{ User = "Tom", Type = ShiftType.Nightly, Hours = 8, Date = DateTime.Now}
            };
        }
        
        public Shift GetById(int id)
        {
            return Shifts.FirstOrDefault(x => x.Id.Equals(id)).ThrowIfNull();
        }

        public bool UpdateShift(Shift updatedShift)
        {
            var oldShift = GetById(updatedShift.Id);
            if (updatedShift.Equals(oldShift))
            {
                return true;
            }

            if (Shifts.Remove(oldShift))
            {
                AddShift(updatedShift);
                return true;
            }

            return false;
        }

        public ObservableCollection<Shift> GetAllShifts()
        {
            return new ObservableCollection<Shift>(Shifts);
        }

        public bool RemoveShiftById(int id)
        {
            var shift = GetById(id);
            return RemoveShift(shift);
        }

        public bool RemoveShift(Shift shift)
        {
            return Shifts.Remove(shift);
        }

        public Shift AddShift(Shift shift)
        {
            Shifts.Add(shift);
            return shift;
        }
        
        public Shift SaveShift(Shift shift)
        {
            var updateComplete = UpdateShift(shift);
            if (!updateComplete)
            {
                AddShift(shift);
            }

            return shift;
        }
        
        
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(gen.Next(range));
        }
    }
}