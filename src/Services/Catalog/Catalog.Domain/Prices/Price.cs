using Catalog.Data.Price;
using Catalog.Domain.Common;

namespace Catalog.Domain.Prices
{
    public sealed class Price : UniqueEntity<PriceData>
    {
        
        public Price(PriceData d) : base(d) { }
    }
}
