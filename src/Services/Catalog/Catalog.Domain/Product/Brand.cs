using Catalog.Data.Product;
using Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public sealed class Brand : DescribedEntity<BrandData>
    {
        public Brand(BrandData d) : base(d) { }
    }
}
