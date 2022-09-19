using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface IReservationService : IServiceBase<Reservation>
    {
        Task<ObservableCollection<Reservation>> GetAllByDate(DateTime value);
    }
}