using Xamarin.Forms;

namespace RestaurantManager.Controls
{
    public class BoxViewStopper:BoxView
    {
        public BoxViewStopper()
        {
            Color = Color.LightBlue;
            Margin = 5;
            VerticalOptions = LayoutOptions.Center;
            HeightRequest = 2;
        }
    }
}