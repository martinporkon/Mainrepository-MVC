using Basket.Domain.Common;
using Basket.Data.Baskets;

namespace Basket.Domain.Baskets
{
    public abstract class Basket2 : DefinedEntity<BasketData>, IAggregateRoot// TODO
    {
        protected Basket2() : this(null) { }

        protected Basket2(BasketData data) : base(data) { }
    }
}