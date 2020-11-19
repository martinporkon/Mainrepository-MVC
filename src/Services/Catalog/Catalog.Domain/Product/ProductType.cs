using Catalog.Data.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public sealed class ProductType : BaseProductType
    {

        public ProductType() : this(null) { }
        public ProductType(ProductTypeData d = null) : base(d) { }

    }
}
