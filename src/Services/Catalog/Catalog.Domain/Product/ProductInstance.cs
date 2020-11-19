using Catalog.Data.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public sealed class ProductInstance : BaseProductInstance<ProductType>
    {


        public ProductInstance(ProductInstanceData d = null) : base(d) { }

        public override ProductType Type => type as ProductType;

    }
}
