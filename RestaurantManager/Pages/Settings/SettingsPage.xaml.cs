using RestaurantManager.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Pages.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            switch (Utility.Settings.Theme)
            {
                case 0:
                    RadioButtonSystem.IsChecked = true;
                    break;
                case 1:
                    RadioButtonLight.IsChecked = true;
                    break;
                case 2:
                    RadioButtonDark.IsChecked = true;
                    break;
            }
        }
        
        bool loaded;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loaded = true;
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!loaded)
                return;

            if (!e.Value)
                return;

            var val = (sender as RadioButton)?.Value as string;
            if (string.IsNullOrWhiteSpace(val))
                return;

            switch (val)
            {
                case "System":
                    Utility.Settings.Theme = 0;
                    break;
                case "Light":
                    Utility.Settings.Theme = 1;
                    break;
                case "Dark":
                    Utility.Settings.Theme = 2;
                    break;
            }

            Theme.SetTheme();
        }
    }
}