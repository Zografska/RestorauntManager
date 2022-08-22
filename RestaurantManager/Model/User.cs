namespace RestaurantManager.Model
{
    public class User : ModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                SetProperty(ref  _name, value);
            }
            
        }

        public string Surname { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
    }
}