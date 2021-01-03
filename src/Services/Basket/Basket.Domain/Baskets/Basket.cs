using Basket.Domain.Common;
using Basket.Data.Baskets;

namespace Basket.Domain.Baskets
{
    public abstract class Basket : DefinedEntity<BasketData>
    {
        protected Basket() : this(null) { }

        protected Basket(BasketData data) : base(data) { }
    }
}