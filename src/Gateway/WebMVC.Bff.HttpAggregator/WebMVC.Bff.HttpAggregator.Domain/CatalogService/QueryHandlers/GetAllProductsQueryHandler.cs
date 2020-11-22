using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.DTO;
using WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryRequest;

namespace WebMVC.HttpAggregator.Infra.Catalog.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly ICatalogServiceRepository _catalogServiceRepository;

        public GetAllProductsQueryHandler(ICatalogServiceRepository catalogServiceRepository)
        {
            _catalogServiceRepository = catalogServiceRepository;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            // TODO Get all products from the Catalog Service

            var baz = _catalogServiceRepository.GetAll().Result;

            return baz;
        }
    }
}