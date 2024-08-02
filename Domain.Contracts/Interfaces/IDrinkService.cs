 namespace Restaurant.Contracts
{
    public interface IDrinkService
    {
        List<DrinkItemDto> GetDrinkItemDtos();
        bool DeleteDrinkItem(int id);
        void AddDrinkItem(AddDrinkDto drinkItemDto);
        bool UpdateDrinkItem(int id, UpdateDrinkDto drinkItemDto);
    }
}
