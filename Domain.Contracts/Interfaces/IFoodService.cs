namespace Restaurant.Contracts
{
    public interface IFoodService
    {
        List<FoodItemDto> GetFoodItems();
        bool DeleteFoodItem(int id);
        void AddFoodItem(AddFoodDto foodItemDto);
        bool UpdateFoodItem(int id, UpdateFoodDto foodItemDto);
    }
}
