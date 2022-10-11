using System.Data;
using Xamarin.Forms;

namespace RestaurantManager.Controls
{
    public class CustomListView : ListView
    {
        public CustomListView()
        {
            ItemSelected += (sender, args) =>
            {
                if (args.SelectedItem == null) return;
                SelectedItem = null;
            };
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(ItemsSource))
            {
                IsVisible = ItemsSource != null && ItemsSource.GetEnumerator().MoveNext();
            }
        }
    }
}