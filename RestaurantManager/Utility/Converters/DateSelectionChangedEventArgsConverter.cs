using System;
using System.Globalization;
using Xamarin.Forms;
using XCalendar.Models;

namespace RestaurantManager.Converters
{
    public class DateSelectionChangedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateSelectionChangedEventArgs = value as DateSelectionChangedEventArgs;
            if (dateSelectionChangedEventArgs == null)
            {
                throw new ArgumentException("Expected value to be of type DateSelectionChangedEventArgs", nameof(value));
            }
            return dateSelectionChangedEventArgs.CurrentSelection[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}