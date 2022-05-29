using System;

namespace RestaurantManager.Model
{
    public class Reservation : ModelBase
    {
        public DateTime ReservationDate { get; set; }
        public string Name { get; set; }
        public int NumberInParty { get; set; }
        public bool IsCancelled { get; set; }
        
        public Reservation()
        {
            ReservationDate = DateTime.Now;
            IsCancelled = false;
        }
    }
}