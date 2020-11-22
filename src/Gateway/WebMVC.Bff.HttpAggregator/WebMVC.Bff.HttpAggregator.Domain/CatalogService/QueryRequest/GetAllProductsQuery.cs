using System.Collections.Generic;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryRequest
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>> { }
}