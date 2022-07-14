using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using RestaurantManager.Core;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
namespace RestaurantManager
{
    public class DatabaseServiceRemote : IDatabaseService 
    {
        private readonly FirebaseClient _firebase = new FirebaseClient(Configuration.DatabaseUrl);

        public async Task<ObservableCollection<T>> GetAll<T>() where T : ModelBase
            => (await _firebase
                .Child(typeof(T).Name)
                .OnceAsync<T>())
                .Select(entity => entity.Object)
                .ToObservableCollection();

        public async Task<string> Add<T>(string serializedData) where T : ModelBase
        {
            var result =  await _firebase
                .Child(typeof(T).Name)
                .PostAsync(serializedData);
            return result.Object;
        }

        public async Task<T> Get<T>(int id) where T : ModelBase
        {
            var allEntities = await GetAll<T>();
            return allEntities.FirstOrDefault(a => a.Id == id);
        }

        public async Task<bool> Update<T>(T updatedEntity) where T : ModelBase
        {
            var entityToUpdate = (await _firebase
                .Child(typeof(T).Name)
                .OnceAsync<T>())
                .FirstOrDefault(a => a.Object.Id == updatedEntity.Id);

            if (entityToUpdate == default)
                return false;
            
            await _firebase
                .Child(typeof(T).Name)
                .Child(entityToUpdate.Key)
                .PutAsync(updatedEntity);
            return true;
        }

        public async Task<bool> Delete<T>(int id) where T : ModelBase
        {
            var toDeleteEntity = (await _firebase
                .Child(typeof(T).Name)
                .OnceAsync<T>())
                .FirstOrDefault(a => a.Object.Id == id);
            if (toDeleteEntity == null) return false;
            
            await _firebase.Child(typeof(T).Name).Child(toDeleteEntity.Key).DeleteAsync();
            return true;
        }
    }
}