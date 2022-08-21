using System;

namespace RestaurantManager.Model
{
    public class Reservation : ModelBase
    {
        public DateTime ReservationDate { get; set; }
        public string OnName { get; set; }
        public int NumberOfPeople { get; set; }
        public bool IsCancelled { get; set; }
        
        public Reservation()
        {
            IsCancelled = false;
        }
    }
}