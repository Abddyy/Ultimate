using AutoMapper;
using Restaurant.Contracts;
using Restaurant.Domain;

public class DrinkService : IDrinkService
{
    private int _nextId = 1;
    private readonly IMapper _mapper;
    private List<DrinkItem> _drinkItems = new List<DrinkItem>();
    public DrinkService(IMapper mapper)
    {
        _mapper = mapper;
        _drinkItems.Add(new DrinkItem { Id = _nextId++, Name = "Cola", Price = 5 });
        _drinkItems.Add(new DrinkItem { Id = _nextId++, Name = "XL", Price = 10 });
        _drinkItems.Add(new DrinkItem { Id = _nextId++, Name = "Water", Price = 1 });
    }

    public void AddDrinkItem(AddDrinkDto drinkItemDto)
    {
        var drinkItem = _mapper.Map<DrinkItem>(drinkItemDto);
        drinkItem.Id = _nextId++;
        _drinkItems.Add(drinkItem);
    }

    public bool DeleteDrinkItem(int id)
    {
        var item = _drinkItems.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
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
    public bool UpdateDrinkItem(int id, UpdateDrinkDto drinkItemDto)
    {
        var item = _drinkItems.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }
        _mapper.Map(drinkItemDto, item);
        return true;
    }
}
