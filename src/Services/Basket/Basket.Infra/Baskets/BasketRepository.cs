using Basket.Data.Baskets;
using Basket.Domain.Baskets;
using Basket.Infra.Common;

namespace Basket.Infra.Baskets
{
    public class BasketRepository : UniqueEntityRepository<Domain.Baskets.Basket, BasketData>,
        IBasketRepository
    {
        public BasketRepository() : this(null) { }
        public BasketRepository(BasketDbContext c = null) : base(c, c?.Baskets) { }
    }
}