using AutoMapper;
using Web.Domain.DTO.BasketService;

namespace Web.Facade.Baskets.BasketView
{
    public class BasketViewFactoryProfile : Profile
    {
        public BasketViewFactoryProfile()
        {
            CreateMap<BasketView, BasketDto>()
                .ForMember(d => d.Name,
                    opt
                        => opt.MapFrom(src => $"{src.Id} {src.Id}"));
        }
    }
}