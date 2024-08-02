namespace Restaurant.Domain
{
    public class FoodItem : BaseEntity
    {
        //constructors
        public FoodItem() { }
        public FoodItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
