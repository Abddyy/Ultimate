using AutoMapper;
using Restaurant.Contracts;
using Restaurant.Domain;

public class FoodService : IFoodService
{
    private int _nextId = 1;
    private readonly IMapper _mapper;
    private List<FoodItem> _foodItems = new List<FoodItem>();

    public FoodService(IMapper mapper)
    {
        _mapper = mapper;
        _foodItems.Add(new FoodItem { Id = _nextId++, Name = "Burger", Price = 30 });
        _foodItems.Add(new FoodItem { Id = _nextId++, Name = "Pizza", Price = 50 });
        _foodItems.Add(new FoodItem { Id = _nextId++, Name = "Falafel", Price = 4 });
    }

    public List<FoodItemDto> GetFoodItems()
    {
        return _mapper.Map<List<FoodItemDto>>(_foodItems);
    }
    public void AddFoodItem(AddFoodDto foodItemDto)
    {
        var foodItem = _mapper.Map<FoodItem>(foodItemDto);
        foodItem.Id = _nextId++;
        _foodItems.Add(foodItem);
    }

    public bool DeleteFoodItem(int id)
    {
        var item = _foodItems.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }

        item.MarkAsDeleted();
        _foodItems.Remove(item);
        return true;
    }

    public bool UpdateFoodItem(int id, UpdateFoodDto updatedFoodItemDto)
    {
        var item = _foodItems.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }

        _mapper.Map(updatedFoodItemDto, item);
        return true;
    }
}