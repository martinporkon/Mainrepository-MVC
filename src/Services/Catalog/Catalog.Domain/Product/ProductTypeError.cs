using Catalog.Data.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public sealed class ProductTypeError : BaseProductType
    {

        public ProductTypeError(ProductTypeData d = null) : base(d) { }

    }
}
