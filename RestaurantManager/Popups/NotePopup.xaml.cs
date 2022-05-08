using RestaurantManager.PopUps;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePopup : BasePopup
    {
        public NotePopup()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            
        }
    }
}