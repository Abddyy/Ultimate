namespace Restaurant.Domain
{
    public class DrinkItem : BaseEntity
    {
        //constructors 
        public DrinkItem() { }
        public DrinkItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
