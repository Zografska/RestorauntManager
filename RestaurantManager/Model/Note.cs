using System;

namespace RestaurantManager.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public string Creator { get; set; }

        public Note()
        {
            //TODO: remove when implementing Firebase
            Id = new Random().Next();
            LastModified = DateTime.Now;
        }
    }
}