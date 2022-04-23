
using RestaurantManager.PopUps;
using Xamarin.Forms.Xaml;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePopup : BasePopup
    {
        public NotePopup() 
        {
            InitializeComponent();
        }
    }
}