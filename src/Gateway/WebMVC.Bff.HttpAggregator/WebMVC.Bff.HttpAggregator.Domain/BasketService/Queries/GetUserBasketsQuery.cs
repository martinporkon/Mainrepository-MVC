using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebMVC.Bff.HttpAggregator.Infra.Repositories;
using WebMVC.HttpAggregator.Facade.DTO;

namespace WebMVC.HttpAggregator.Infra.Basket.Queries
{
    public class GetUserBasketsQuery : IRequest<IEnumerable<BasketView>>
    {
        public string Id { get; set; }
        public GetUserBasketsQuery(string id)
        {
            Id = id;
        }
    }

    public class GetUserBasketsQueryHandler : IRequestHandler<GetUserBasketsQuery, IEnumerable<BasketView>>
    {
        private readonly IBasketService<BasketView> _basketService;

        public GetUserBasketsQueryHandler(IBasketService<BasketView> basketService)
        {
            _basketService = basketService;
        }
        public Task<IEnumerable<BasketView>> Handle(GetUserBasketsQuery request, CancellationToken cancellationToken)
        {
            var vastus = _basketService.Get("id");

            throw new NotImplementedException();
        }
    }
}