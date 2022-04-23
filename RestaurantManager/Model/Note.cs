using System;

namespace RestaurantManager.Model
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DueDate { get; set; }

        public Note()
        {
            DateCreated = DateTime.Now;
        }
    }
}