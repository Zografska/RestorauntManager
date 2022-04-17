using System;

namespace RestaurantManager.Model
{
    public class ToDo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DueDate { get; set; }

        public ToDo()
        {
            DateCreated = DateTime.Now;
        }
    }
}