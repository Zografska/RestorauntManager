using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace RestaurantManager.Controls
{
    public class LogoButton : Button
    {
        public static readonly BindableProperty IsNetworkConnectedProperty = BindableProperty.Create(nameof(IsNetworkConnected), typeof(bool),
            typeof(LogoButton), true, propertyChanged: (bindable, value, newValue) =>
            {
                var logoLabel = bindable as LogoButton;
                Color toColor = (bool)newValue ? Color.LightSkyBlue : Color.LightCoral;
                logoLabel.ColorTo(toColor);
            });
        public bool IsNetworkConnected
        {
            get { return (bool)GetValue(IsNetworkConnectedProperty); }
            set { SetValue(IsNetworkConnectedProperty, value); }
        }
    }
}