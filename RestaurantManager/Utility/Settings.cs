using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantManager.Utility
{
    public static class Settings
    {
        // 0 = default, 1 = light, 2 = dark
        const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set
            {
                Preferences.Set(nameof(Theme), value);
                switch (value)
                {
                    //default
                    case 0:
                        App.Current.UserAppTheme = OSAppTheme.Unspecified;
                        break;
                    //light
                    case 1:
                        App.Current.UserAppTheme = OSAppTheme.Light;
                        break;
                    //dark
                    case 2:
                        App.Current.UserAppTheme = OSAppTheme.Dark;
                        break;
                }
            } 
        }
    }
}