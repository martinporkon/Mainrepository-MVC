using AutoMapper;
using WebMVC.Domain.DTO.BasketService;

namespace WebMVC.Facade.BasketView
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