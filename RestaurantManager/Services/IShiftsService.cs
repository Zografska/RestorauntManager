using System.Collections.ObjectModel;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface IShiftsService
    {
        Shift GetById(int id);
        bool UpdateShift(Shift shift);
        ObservableCollection<Shift> GetAllShifts();
        bool RemoveShiftById(int id);
        bool RemoveShift(Shift shift);
        Shift AddShift(Shift shift);
        Shift SaveShift(Shift shift);
    }
}