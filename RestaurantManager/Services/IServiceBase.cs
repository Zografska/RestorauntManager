using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface IServiceBase
    {
        Task<T> GetById<T>(int id) where T : ModelBase;
        Task<bool> Update<T>(T note) where T : ModelBase;
        Task<ObservableCollection<T>> GetAll<T>() where T : ModelBase;
        Task<bool> RemoveById<T>(int id) where T : ModelBase;
        Task<T> Add<T>(T entity) where T : ModelBase;
        Task<T> Save<T>(T entity) where T : ModelBase;
    }
}