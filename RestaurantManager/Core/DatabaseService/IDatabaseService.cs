using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Core.DatabaseService
{
    public interface IDatabaseService
    {
        Task<List<T>> GetAll<T>() where T : ModelBase;
        
        Task<string> Add<T>(string serializedData) where T : ModelBase;
        
        Task<T> Get<T>(int id) where T : ModelBase;
        
        Task<bool> Update<T>(int id, string serializedData) where T : ModelBase;

        Task<bool> Delete<T>(int id) where T : ModelBase;
    }
}