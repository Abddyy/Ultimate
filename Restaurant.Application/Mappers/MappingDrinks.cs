using AutoMapper;
using Restaurant.Domain;
public class MappingDrinks : Profile
{
    public MappingDrinks()
    {
        CreateMap<AddDrinkDto, DrinkItem>();
        CreateMap<DrinkItem, DrinkItemDto>();
        CreateMap<UpdateDrinkDto, DrinkItem>();
        CreateMap<DrinkItemDto, DrinkItem>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}

