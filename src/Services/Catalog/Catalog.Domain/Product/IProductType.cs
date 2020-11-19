using Catalog.Data.Product;
using Catalog.Domain.Common;
using Catalog.Domain.ProductFeature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public interface IProductType : IDescribedEntity<ProductTypeData>
    {

        IReadOnlyList<FeatureType> Features { get; }
        public ProductKind ProductKind { get; }
    }
}
