/*using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using MediatR;
using WebMVC.Bff.HttpAggregator.Core.Errors;
using WebMVC.Bff.HttpAggregator.Domain.DTO;
using WebMVC.HttpAggregator.Infra.Basket.Queries;

namespace WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers
{
    public class GetUserBasketsQueryHandler : IRequestHandler<GetUserBasketsQuery, IEnumerable<BasketDto>>// + userId
    {
        /*private readonly IBasketService<BasketView> _basketService;#1#

        /*public GetUserBasketsQueryHandler(IBasketService<BasketView> basketService)
        {
            _basketService = basketService;
        }#1#

        public Task<IEnumerable<BasketDto>> Handle(GetUserBasketsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}*/