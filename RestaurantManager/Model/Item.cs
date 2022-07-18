namespace RestaurantManager.Model
{
    public class Item : ModelBase
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}