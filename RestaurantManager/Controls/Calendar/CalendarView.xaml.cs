using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RestaurantManager.Extensions;
using RestaurantManager.Model.DTOs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Controls.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView
    {
        public static readonly BindableProperty FrameTappedCommandProperty =
            BindableProperty.Create(nameof(FrameTappedCommand), typeof(ICommand), typeof(CalendarView));
        
        public static readonly BindableProperty CurrentDateProperty =
            BindableProperty.Create(nameof(CurrentDate), typeof(DateTime), typeof(CalendarView),
                propertyChanged: (bindable, value, newValue) =>
                {
                    if(!(bindable is CalendarView calendar)) return;
                    var date = newValue is DateTime ? (DateTime)newValue : default;
                    calendar.Weekdays = date.GetWeekdays();
                });
        
        public static readonly BindableProperty DaysOfWeekProperty =
            BindableProperty.Create(nameof(DaysOfWeek), typeof(ObservableCollection<ReservationDayDTO>), 
                typeof(CalendarView), propertyChanged: (bindable, value, newValue) =>
                {
                    if(!(bindable is CalendarView calendar)) return;
                    var days = newValue as ObservableCollection<ReservationDayDTO>;
                    calendar.Week1 = days.Take(7).ToObservableCollection();
                    calendar.Week2 = days.Skip(7).Take(7).ToObservableCollection();
                    calendar.Week3 = days.Skip(14).Take(7).ToObservableCollection();
                    calendar.Week4 = days.Skip(21).Take(7).ToObservableCollection();
                    calendar.Week5 = days.Skip(28).FillGrid();
                });
        
        public ICommand FrameTappedCommand
        {
            get => (ICommand)GetValue(FrameTappedCommandProperty);
            set => SetValue(FrameTappedCommandProperty, value);
        }
        
        public DateTime CurrentDate
        {
            get => (DateTime)GetValue(CurrentDateProperty);
            set => SetValue(CurrentDateProperty, value);
        }

        public ObservableCollection<ReservationDayDTO> DaysOfWeek
        {
            get => (ObservableCollection<ReservationDayDTO>)GetValue(DaysOfWeekProperty);
            set => SetValue(DaysOfWeekProperty, value);
        }
        
        public CalendarView()
        {
            InitializeComponent();
        }

        private ObservableCollection<ReservationDayDTO> _week1 { get; set; }

        public ObservableCollection<ReservationDayDTO> Week1
        {
            get => _week1;
            set
            {
                _week1 = value;
                OnPropertyChanged(nameof(Week1));
            }
        }
        
        private ObservableCollection<ReservationDayDTO> _week2 { get; set; }

        public ObservableCollection<ReservationDayDTO> Week2
        {
            get => _week2;
            set
            {
                _week2 = value;
                OnPropertyChanged(nameof(Week2));
            }
        }
        
        private ObservableCollection<ReservationDayDTO> _week3 { get; set; }

        public ObservableCollection<ReservationDayDTO> Week3
        {
            get => _week3;
            set
            {
                _week3 = value;
                OnPropertyChanged(nameof(Week3));
            }
        }
        
        private ObservableCollection<ReservationDayDTO> _week4 { get; set; }

        public ObservableCollection<ReservationDayDTO> Week4
        {
            get => _week4;
            set
            {
                _week4 = value;
                OnPropertyChanged(nameof(Week4));
            }
        }
        
        private ObservableCollection<ReservationDayDTO> _week5 { get; set; }

        public ObservableCollection<ReservationDayDTO> Week5
        {
            get => _week5;
            set
            {
                _week5 = value;
                OnPropertyChanged(nameof(Week5));
            }
        }

        public ObservableCollection<string> _weekdays { get; set; }
        public ObservableCollection<string> Weekdays
        {
            get => _weekdays;
            set
            {
                _weekdays = value;
                OnPropertyChanged(nameof(Weekdays));
            }
        }
    }
}