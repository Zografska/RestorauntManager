using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestaurantManager.Model;
using RestaurantManager.Model.DTOs;

namespace RestaurantManager.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds = 0,
            int milliseconds = 0)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        public static DateTime ChangeDate(this DateTime dateTime, int year, int month, int day, TimeSpan time)
        {
            return new DateTime(
                year,
                month,
                day,
                time.Hours,
                time.Minutes,
                time.Seconds,
                time.Milliseconds,
                dateTime.Kind);
        }

        public static List<DateTime> GetDates(this DateTime dateTime)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(dateTime.Year, dateTime.Month)) // Days: 1, 2 ... 31 etc.
                .Select(day => new DateTime(dateTime.Year, dateTime.Month, day)) // Map each day to a date
                .ToList(); // Load dates into a list
        }

        public static ObservableCollection<ReservationDayDTO> ToCalendarData(this DateTime forMonth,
            ObservableCollection<Reservation> reservations)
        {
            var monthDates = forMonth.GetDates();
            return monthDates.Select(x =>
                new ReservationDayDTO(x,
                    reservations.Any(reservation => reservation.ReservationDate.EqualsByDate(x.Date)))).ToObservableCollection();
        }

        private static readonly ObservableCollection<string> WEEKDAYS = new ObservableCollection<string>
        {
            "M","T","W","T","F","S","S"
        };

        public static ObservableCollection<string> GetWeekdays(this DateTime firstDay)
        {
            var dayOfWeek = firstDay.Date.DayOfWeek is int ? (int)firstDay.Date.DayOfWeek + 1: 1;
            ObservableCollection<string> weekdays = WEEKDAYS.Skip(dayOfWeek).Concat(WEEKDAYS.Take(dayOfWeek)).ToObservableCollection();
            return weekdays;
        }

        public static bool IsDefaultDate(this DateTime dateTime)
        {
            return dateTime == default;
        }

        public static bool EqualsByDate(this DateTime d1, DateTime d2)
        {
            return d1.Day.Equals(d2.Day) && d1.Month.Equals(d2.Month) && d1.Year.Equals(d2.Year);
        }
    }
}