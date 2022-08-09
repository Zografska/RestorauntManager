using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Pages.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        public static readonly BindableProperty ContentValueProperty =
            BindableProperty.Create(nameof(ContentValue), typeof(View), typeof(BasePage),new ContentView());
        
        public View ContentValue
        {
            get => (View)GetValue(ContentValueProperty);
            set => SetValue(ContentValueProperty, value);
        }
        public BasePage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}