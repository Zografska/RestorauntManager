using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using RestaurantManager.Extensions;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class BaseCrudService : IServiceBase
    {
        private readonly DatabaseServiceRemote _databaseServiceRemote;
        protected BaseCrudService(DatabaseServiceRemote databaseServiceRemote)
        {
            _databaseServiceRemote = databaseServiceRemote;
        }

        public async Task<T> GetById<T>(int id) where T : ModelBase
        {
            return await _databaseServiceRemote.Get<T>(id);
        }

        public virtual async Task<bool> Update<T>(T updatedEntity) where T : ModelBase
        {
            return await _databaseServiceRemote.Update(updatedEntity);
        }

        public async Task<ObservableCollection<T>> GetAll<T>() where T : ModelBase
        {
            return await _databaseServiceRemote.GetAll<T>();
        }

        public async Task<bool> RemoveById<T>(int id) where T : ModelBase
        {
            return await _databaseServiceRemote.Delete<T>(id);
        }

        public async Task<T> Add<T>(T entity) where T : ModelBase
        {
            var serializedResult = await _databaseServiceRemote.Add<T>(entity.ToJson());
            return JsonSerializer.Deserialize<T>(serializedResult);
        }

        public virtual async Task<T> Save<T>(T entity) where T : ModelBase
        {
            var updateComplete = await Update(entity);
            if (!updateComplete)
            {
                await Add(entity);
            }

            return entity;
        }
        
        //For mocking data only
        //TODO: Remove this when integration with API is done
        private Random gen = new Random();
        protected DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(gen.Next(range));
        }
    }
}