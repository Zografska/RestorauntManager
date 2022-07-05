using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface IServiceBase<T> where T : ModelBase
    {
        Task<T> GetById(int id);
        Task<bool> Update(T note);
        Task<ObservableCollection<T>> GetAll();
        Task<bool> RemoveById(int id);
        Task<T> Add(T entity);
        Task<T> Save(T entity);
    }
}