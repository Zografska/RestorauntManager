using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShiftPopup : BasePopup
    {
        public ShiftPopup()
        {
            InitializeComponent();
        }
    }
}