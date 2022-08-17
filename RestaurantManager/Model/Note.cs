using System;
using System.Collections;
using System.Globalization;

namespace RestaurantManager.Model
{
    public class Note : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public string CreatorUid { get; set; }
        public string[] UsersSharedWith { get; set; }

        public Note()
        {
            LastModified = DateTime.Now;
        }
    }
}