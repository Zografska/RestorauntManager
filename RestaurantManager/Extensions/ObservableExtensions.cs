using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestaurantManager.Extensions
{
    public static class ObservableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> items)
        {
            if(items == null)
            {
                return new ObservableCollection<T>();
            }
            return new ObservableCollection<T>(items);
        } 
    }
}