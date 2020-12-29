using System.Collections.Generic;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Domain.CatalogService.QueryRequest
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string ProductId { get; set; }
    }
}