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
    }
}