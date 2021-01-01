
using Catalog.Data.Prices;
using Catalog.Domain.Catalog;
using Catalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Prices
{
    public sealed class Price : UniqueEntity<PriceData>
    {
        
        public Price(PriceData d) : base(d) { }
    }
}
