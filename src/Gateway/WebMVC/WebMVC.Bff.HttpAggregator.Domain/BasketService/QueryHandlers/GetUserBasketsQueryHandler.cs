using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.BasketService;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandHandlers;
using WebMVC.HttpAggregator.Domain.BasketService.QueryRequests;

namespace WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers
{
    public class GetUserBasketsQueryHandler : IRequestHandler<GetUserBasketsQuery, IEnumerable<BasketDto>>// + userId
    {
        private readonly IBasketService<BasketView> _basketService;

        public GetUserBasketsQueryHandler()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BasketDto>> Handle(GetUserBasketsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}