using AutoMapper;
using Web.Domain.DTO.BasketService;

namespace Web.Facade.Basket.Baskets
{
    public class BasketViewFactoryProfile : Profile
    {
        public BasketViewFactoryProfile()
        {
            CreateMap<BasketsView, BasketDto>()
                .ForMember(d => d.Name,
                    opt
                        => opt.MapFrom(src => $"{src.Id} {src.Id}"));
        }
    }
}