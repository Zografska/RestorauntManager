using System;

namespace RestaurantManager.Extensions
{
    public static class CommandExtension
    {
        public static bool IsValidParameter<T>(this object parameter)
        {
            if (parameter != null)
            {
                // The parameter isn't null, so we don't have to worry whether null is a valid option
                return parameter is T;
            }

            var t = typeof(T);

            // The parameter is null. Is T Nullable?
            if (Nullable.GetUnderlyingType(t) != null)
            {
                return true;
            }

            // Not a Nullable, if it's a value type then null is not valid
            return !t.GetType().IsValueType;
        }
    }
}