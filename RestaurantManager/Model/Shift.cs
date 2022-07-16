using System;
using RestaurantManager.Enums;

namespace RestaurantManager.Model
{
    public class Shift : ModelBase
    {
        public string User { get; set; }
        public int Hours { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public Shift()
        {
            Date = DateTime.Now;
        }
    }
}