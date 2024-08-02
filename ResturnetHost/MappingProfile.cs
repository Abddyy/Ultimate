using AutoMapper;
using Restaurant.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FoodItem, FoodItemDto>();
        CreateMap<FoodItemDto, FoodItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<AddFoodDto, FoodItem>();
        CreateMap<UpdateFoodDto, FoodItem>();

        CreateMap<DrinkItem, DrinkItemDto>();
        CreateMap<DrinkItemDto, DrinkItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<AddDrinkDto, DrinkItem>();
        CreateMap<UpdateDrinkDto, DrinkItem>();
    }
}
