 namespace Restaurant.Contracts
{
    public interface IDrinkService
    {
        List<DrinkItemDto> GetDrinkItemDtos();
        void AddDrinkItem(AddDrinkDto drinkItemDto);
        bool UpdateDrinkItem(string name, UpdateDrinkDto drinkItemDto);
        bool DeleteDrinkItem(string name);
    }
}
