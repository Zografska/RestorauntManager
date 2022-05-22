using System.Collections.ObjectModel;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface IServiceBase<T>
    {
        T GetById(int id);
        bool Update(T note);
        ObservableCollection<T> GetAll();
        bool RemoveById(int id);
        bool Remove(T entity);
        T Add(T entity);
        T Save(T entity);
    }
}