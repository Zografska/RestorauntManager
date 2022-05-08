using System;
using RestaurantManager.Enums;

namespace RestaurantManager.Model
{
    public class Shift
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int Hours { get; set; }
        public ShiftType Type { get; set; }
        public DateTime Date { get; set; }

        public Shift()
        {
            Id = new Random().Next();
            Date = DateTime.Now;
        }
    }
}