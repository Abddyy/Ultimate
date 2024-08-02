using AutoMapper;
using Restaurant.Contracts;
using Restaurant.Domain;

public class DrinkService : IDrinkService
{
    private readonly IMapper _mapper;
    private List<DrinkItem> _drinkItems = new List<DrinkItem>();
    private int _nextId = 1;
    public DrinkService(IMapper mapper)
    {
        _mapper = mapper;
        _drinkItems.Add(new DrinkItem(1, "Cola", 5) { Id = _nextId++ });
        _drinkItems.Add(new DrinkItem(2, "XL", 10) { Id = _nextId++ });
        _drinkItems.Add(new DrinkItem(3, "water", 1) { Id = _nextId++ });
    }

    public void AddDrinkItem(AddDrinkDto drinkItemDto)
    {
        var drinkItem = _mapper.Map<DrinkItem>(drinkItemDto);
        drinkItem.Id = _nextId++;
        _drinkItems.Add(drinkItem);
    }

    public bool DeleteDrinkItem(string name)
    {
        var item = _drinkItems.FirstOrDefault(f => f.Name == name && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }

        item.MarkAsDeleted();
        _drinkItems.Remove(item);
        return true;
    }

    public List<DrinkItemDto> GetDrinkItemDtos()
    {
        return _mapper.Map<List<DrinkItemDto>>(_drinkItems);
    }

    public bool UpdateDrinkItem(string name, UpdateDrinkDto drinkItemDto)
    {
        var item = _drinkItems.FirstOrDefault(f => f.Name == name && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }

        _mapper.Map(drinkItemDto, item);
        return true;
    }
}
