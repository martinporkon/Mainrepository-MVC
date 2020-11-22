using System;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.HttpAggregator.Facade.DTO;
using WebMVC.HttpAggregator.Infra.Common;

namespace WebMVC.HttpAggregator.Infra.Basket.Commands
{
    public class DeleteBasketCommand : IRequestWrapper<BasketView> { }

    public class DeleteBasketCommandHandler : IHandlerWrapper<DeleteBasketCommand, BasketView>
    {
        public Task<Response<BasketView>> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {

            // TODO post basket

            throw new NotImplementedException();
        }
    }
}