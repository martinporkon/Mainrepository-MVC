using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandRequests;
using WebMVC.Bff.HttpAggregator.Domain.Common;

namespace WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandHandlers
{
    public class AddToBasketCommandHandler : BaseRequest, IRequestHandler<AddToBasketCommand, BasketDto>
    {
        /*private readonly global::Catalog.Domain.IRepository<Catalog> _catalogRepository;*/
        private readonly IRepository<Catalog> _catalogRepository;// TODO fix namespaces

        public AddToBasketCommandHandler(IRepository<Catalog> catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<BasketDto> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    public class BasketDto
    {
    }
}