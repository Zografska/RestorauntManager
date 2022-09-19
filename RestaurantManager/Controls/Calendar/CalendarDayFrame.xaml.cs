using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Controls.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarDayFrame
    {
        public static readonly BindableProperty FrameTappedCommandProperty =
            BindableProperty.Create(nameof(FrameTappedCommand), typeof(ICommand), typeof(CalendarDayFrame));
        public ICommand FrameTappedCommand
        {
            get { return (ICommand)GetValue(FrameTappedCommandProperty); }
            set { SetValue(FrameTappedCommandProperty, value); }
        }
        
        public CalendarDayFrame()
        {
            InitializeComponent();
        }
    }
}