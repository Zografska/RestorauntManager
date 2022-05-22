using System;

namespace RestaurantManager.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public bool IsCancelled { get; set; }
    }
}