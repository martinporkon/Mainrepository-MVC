/*using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.DTO;
using WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryRequest;
using WebMVC.Bff.HttpAggregator.Infra.Repositories;

namespace WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly ICatalogServiceRepository _catalogServiceRepository;

        public GetProductByIdQueryHandler(ICatalogServiceRepository catalogServiceRepository)
        {
            _catalogServiceRepository = catalogServiceRepository;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            // TODO Get a product from the Catalog Service
            var id = "";
            var baz = _catalogServiceRepository.GetById(id).Result;

            return baz;
        }
    }
}*/