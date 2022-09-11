using Xamarin.Forms;

namespace RestaurantManager.Controls
{
    public class BoxViewStopper:BoxView
    {
        public BoxViewStopper()
        {
            Color = Color.FromHex("#7da5f5");
            Margin = 5;
            VerticalOptions = LayoutOptions.Center;
            HeightRequest = 2;
        }
    }
}