using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandHandlers;

namespace WebMVC.HttpAggregator.Domain.BasketService.QueryRequests
{
    public class GetUserBasketByIdQuery : IRequest<BasketDto>
    {
        public string BasketId { get; set; }
    }
}