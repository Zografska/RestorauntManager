using System; 
using System.Globalization;
using Xamarin.Forms;

namespace RestaurantManager.Converters
{
    public class DateWithoutTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = value is DateTime ? (DateTime) value : default;
            return date.ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}