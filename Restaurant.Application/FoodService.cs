using AutoMapper;
using Restaurant.Contracts;
using Restaurant.Domain;

public class FoodService : IFoodService
{
    private readonly IMapper _mapper;
    private List<FoodItem> _foodItems = new List<FoodItem>();
    private int _nextId = 1;

    public FoodService(IMapper mapper)
    {
        _mapper = mapper;
        // Seed with initial data
        _foodItems.Add(new FoodItem(1, "burger", 30) { Id = _nextId++ });
        _foodItems.Add(new FoodItem(2, "pizza", 50) { Id = _nextId++ });
        _foodItems.Add(new FoodItem(3, "falafel", 4) { Id = _nextId++ });
    }

    public List<FoodItemDto> GetFoodItems()
    {
        return _mapper.Map<List<FoodItemDto>>(_foodItems);
    }

    public void AddFoodItem(AddFoodDto foodItemDto)
    {
        var foodItem = _mapper.Map<FoodItem>(foodItemDto);
        foodItem.Id = _nextId++; // Set a new unique Id
        _foodItems.Add(foodItem);
    }

    public bool DeleteFoodItem(string name)
    {
        var item = _foodItems.FirstOrDefault(f => f.Name == name && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }

        item.MarkAsDeleted();
        _foodItems.Remove(item);
        return true;
    }

    public bool UpdateFoodItem(string name, UpdateFoodDto updatedFoodItemDto)
    {
        var item = _foodItems.FirstOrDefault(f => f.Name == name && !f.IsDeleted);
        if (item == null)
        {
            return false;
        }

        _mapper.Map(updatedFoodItemDto, item);
        return true;
    }
}