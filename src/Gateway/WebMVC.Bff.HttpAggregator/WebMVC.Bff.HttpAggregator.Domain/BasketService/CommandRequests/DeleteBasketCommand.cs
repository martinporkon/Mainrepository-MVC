using System;
using System.Threading;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using WebMVC.HttpAggregator.Infra.Common;

namespace WebMVC.HttpAggregator.Infra.Basket.Commands
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