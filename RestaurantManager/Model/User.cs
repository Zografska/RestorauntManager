namespace RestaurantManager.Model
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
    }
}