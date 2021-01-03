using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandHandlers;

namespace WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandRequests
{
    public sealed class AddToBasketCommand : IRequest<object>, IRequest<BasketDto>
    {
    }
}