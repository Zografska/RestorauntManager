using System.Linq;
using RestaurantManager.Extensions;
using Xamarin.Forms;

namespace RestaurantManager.Controls
{
    public class NumberPicker : Picker
    {
        
        public static readonly BindableProperty FromProperty = BindableProperty.Create(nameof(From), typeof(int),
            typeof(NumberPicker), 1, propertyChanged: SetItemSource);

        public int From
        {
            get { return (int)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }
        
        public static readonly BindableProperty ToProperty = BindableProperty.Create(nameof(To), typeof(int),
            typeof(NumberPicker), 10);
        public int To
        {
            get { return (int)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        private static void SetItemSource(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is NumberPicker numberPicker)) return;
                
            if ((int)newValue == 0) return;
            if (numberPicker.From < numberPicker.To) return;

            numberPicker.ItemsSource = Enumerable.Range(numberPicker.From, numberPicker.To).ToObservableCollection();
        }

        public NumberPicker()
        {
            ItemsSource = Enumerable.Range(From, To).ToObservableCollection();
        }
    }
}