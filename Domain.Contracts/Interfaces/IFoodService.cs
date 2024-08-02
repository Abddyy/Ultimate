namespace Restaurant.Contracts
{
    public interface IFoodService
    {
        List<FoodItemDto> GetFoodItems();
        void AddFoodItem(AddFoodDto foodItemDto);
        bool UpdateFoodItem(string name, UpdateFoodDto foodItemDto);
        bool DeleteFoodItem(string name);
    }
}
