using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Pages.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseHeaderView
    {
        public static readonly BindableProperty AreInterfaceButtonsVisibleProperty =
            BindableProperty.Create(nameof(AreInterfaceButtonsVisible), typeof(bool), typeof(BaseHeaderView), default(bool), BindingMode.TwoWay);
        public bool AreInterfaceButtonsVisible
        {
            get { return (bool)GetValue(AreInterfaceButtonsVisibleProperty); }
            set { SetValue(AreInterfaceButtonsVisibleProperty, value); }
        }

        public BaseHeaderView()
        {
            InitializeComponent();
        }
    }
}