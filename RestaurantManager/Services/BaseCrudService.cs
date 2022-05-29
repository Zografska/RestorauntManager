using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class BaseCrudService<T> : IServiceBase<T> where T : ModelBase
    {
        public List<T> Entities { get; set; }

        public T GetById(int id)
        {
            var result = Entities.FirstOrDefault(x => x.Id.Equals(id));
            return result;
        }

        public virtual bool Update(T updatedEntity)
        {
            var entity = Entities.FirstOrDefault(x => x.Id.Equals(updatedEntity.Id));
            if (entity == null)
            {
                return false;
            }
            Entities.Remove(entity);
            Entities.Add(updatedEntity);
            return true;
        }

        public ObservableCollection<T> GetAll()
        {
            return new ObservableCollection<T>(Entities);
        }

        public bool RemoveById(int id)
        {
            var entity = GetById(id);
            return Remove(entity);
        }

        public bool Remove(T entity)
        {
            return Entities.Remove(entity);
        }

        public T Add(T entity)
        {
            Entities.Add(entity);
            return entity;
        }

        public virtual T Save(T entity)
        {
            var updateComplete = Update(entity);
            if (!updateComplete)
            {
                Add(entity);
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