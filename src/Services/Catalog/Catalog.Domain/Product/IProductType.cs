using Catalog.Data.Product;
using Catalog.Domain.Common;
using Catalog.Domain.ProductFeature;
using System.Collections.Generic;

namespace Catalog.Domain.Product
{
    public interface IProductType : IDescribedEntity<ProductTypeData>
    {

        IReadOnlyList<FeatureType> Features { get; }
        public ProductKind ProductKind { get; }
    }
}
