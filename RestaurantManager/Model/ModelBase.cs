using System;
using System.Text.Json;

namespace RestaurantManager.Model
{
    public abstract class ModelBase
    {
        public int Id { get; set; }

        public ModelBase()
        {
            //TODO: remove when implementing Firebase
            Id = new Random().Next();
        }

        protected string Serialize<T>(T model)
        {
            return JsonSerializer.Serialize(model);
        }
    }
}