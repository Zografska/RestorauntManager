using System;

namespace RestaurantManager.Utility
{
    public class GenericHelpers
    {
        public static T GetInstance<T>(string type)
        {
            return (T)Activator.CreateInstance(Type.GetType(type));
        }
    }
}