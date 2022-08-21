using System;

namespace RestaurantManager.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds = 0, int milliseconds = 0)
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
    }
}