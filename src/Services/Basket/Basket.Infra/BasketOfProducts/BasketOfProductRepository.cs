using Basket.Data.BasketOfProducts;
using Basket.Infra.Common;
using Basket.Domain.BasketOfProducts;

namespace Basket.Infra.BasketOfProducts
{
    public class BasketOfProductRepository : UniqueEntityRepository<BasketOfProduct, BasketOfProductData>, IBasketOfProductRepository
    {
        public BasketOfProductRepository() : this(null) { }
        public BasketOfProductRepository(BasketDbContext c = null) : base(c, c?.BasketOfProducts) { }
    }
}