using System;

namespace RestaurantManager.Model.DTOs
{
    public class ReservationDayDTO
    {
        public string Day { get; }
        public DateTime Value { get; }
        public string Position { get; }
        public bool HasReservations { get; }
        

        public ReservationDayDTO (DateTime date, bool hasReservations)
        {
            Day = date.Day.ToString();
            Position = ((date.Day - 1) % 7).ToString();
            Value = date;
            HasReservations = hasReservations;
        }
    }
}