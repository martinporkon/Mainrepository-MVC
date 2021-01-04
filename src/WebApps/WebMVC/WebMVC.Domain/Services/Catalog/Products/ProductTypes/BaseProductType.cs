using System.Collections.Generic;
using Web.Domain.Common;
using Web.Domain.Common.Catalog.Products;
using Web.Domain.DTO.CatalogService;

namespace Web.Domain.Services.Catalog.Products.ProductTypes
{
    public class BaseProductType : DescribedEntity<ProductTypeDto>, IProductType
    {
        protected BaseProductType(ProductTypeDto d = null) : base(d) { }
        public IReadOnlyList<FeatureType> Features { get; }
        public ProductKind ProductKind => Data?.ProductKind ?? ProductKind.Unspecified;
    }
}