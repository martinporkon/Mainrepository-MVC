using Basket.Data.BasketOfProducts;
using Basket.Domain.Common;

namespace Basket.Domain.BasketOfProducts
{
    public abstract class BasketOfProduct : DefinedEntity<BasketOfProductData>
    {
        protected BasketOfProduct() : this(null) { }

        protected BasketOfProduct(BasketOfProductData data) : base(data) { }
    }
}