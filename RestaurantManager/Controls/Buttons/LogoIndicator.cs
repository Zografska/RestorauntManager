using Xamarin.Forms;

namespace RestaurantManager.Controls.Buttons
{
    public class LogoIndicator : Button
    {
        public static readonly BindableProperty IsNetworkConnectedProperty = BindableProperty.Create(nameof(IsNetworkConnected), typeof(bool),
            typeof(LogoIndicator), true, propertyChanged: (bindable, value, newValue) =>
            {
                var logoLabel = bindable as LogoIndicator;
                Color toColor = (bool)newValue ? Color.LightSkyBlue : Color.LightCoral;
                if (logoLabel != null) logoLabel.TextColor = toColor;
            });
        public bool IsNetworkConnected
        {
            get { return (bool)GetValue(IsNetworkConnectedProperty); }
            set { SetValue(IsNetworkConnectedProperty, value); }
        }
    }
}