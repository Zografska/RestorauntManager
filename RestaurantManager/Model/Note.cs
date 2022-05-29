using System;

namespace RestaurantManager.Model
{
    public class Note : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public string Creator { get; set; }

        public Note()
        {
            LastModified = DateTime.Now;
        }
    }
}