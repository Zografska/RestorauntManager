using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
namespace RestaurantManager
{
    public class DatabaseServiceRemote : IDatabaseService 
    {
        //TODO: make this singleton
        private readonly FirebaseClient _firebase = new FirebaseClient("https://restaurantmanagerdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<List<T>> GetAll<T>() where T : ModelBase
        {
            return (await _firebase
                .Child(nameof(T))
                .OnceAsync<T>()).Select(entity => entity.Object).ToList();
        }

        public async Task<string> Add<T>(string serializedData) where T : ModelBase
        {
            var result =  await _firebase
                .Child(nameof(T))
                .PostAsync(serializedData);
            return result.Object;
        }

        public async Task<T> Get<T>(int id) where T : ModelBase
        {
            var allEntities = await GetAll<T>();
            return allEntities.FirstOrDefault(a => a.Id == id);
        }

        public async Task<bool> Update<T>(int id, string serializedData) where T : ModelBase
        {
            var result = await Delete<T>(id);
            if (result)
            {
                await Add<T>(serializedData);
                return true;
            }

            return false;
        }

        public async Task<bool> Delete<T>(int id) where T : ModelBase
        {
            var toDeletePerson = (await _firebase
                .Child(nameof(T))
                .OnceAsync<T>()).FirstOrDefault(a => a.Object.Id == id);
            if (toDeletePerson == null) return false;
            
            await _firebase.Child(nameof(T)).Child(toDeletePerson.Key).DeleteAsync();
            return true;
        }

    }
}