using System;
using System.Threading;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using WebMVC.Bff.HttpAggregator.Domain.Common;

namespace WebMVC.Bff.HttpAggregator.Domain.BasketService.CommandRequests
{
    public class DeleteBasketCommand : IRequestWrapper<BasketView> { }

    public class DeleteBasketCommandHandler : IHandlerWrapper<DeleteBasketCommand, BasketView>
    {
        public Task<Response<BasketView>> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {

            // TODO delete basket

            throw new NotImplementedException();
        }
    }
}