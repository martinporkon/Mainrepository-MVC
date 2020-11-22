using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryRequest
{
    public class GetProductByIdQuery : IRequest<ProductDto> { }
}