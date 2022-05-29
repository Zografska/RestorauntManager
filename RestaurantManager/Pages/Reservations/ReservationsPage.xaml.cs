using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Models;

namespace RestaurantManager.Pages.Reservations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationsPage
    {
        public ReservationsPage()
        {
            InitializeComponent();
        }

        private void CalendarView_OnDateSelectionChanged(object sender, DateSelectionChangedEventArgs e)
        {
            
        }
    }
}