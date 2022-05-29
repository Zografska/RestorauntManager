using System;

namespace RestaurantManager.Model
{
    public class ModelBase
    {
        public int Id { get; set; }

        public ModelBase()
        {
            //TODO: remove when implementing Firebase
            Id = new Random().Next();
        }
    }
}