using AutoMapper;
using Restaurant.Domain;
public class MappingFood : Profile
{
    public MappingFood()
    {
        CreateMap<AddFoodDto, FoodItem>();
        CreateMap<FoodItem, FoodItemDto>();
        CreateMap<UpdateFoodDto, FoodItem>();
        CreateMap<FoodItemDto, FoodItem>().ForMember(dest => dest.Id, opt => opt.Ignore());

    }
}
