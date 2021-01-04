using System.Collections.Generic;
using Web.Domain.Common;
using Web.Domain.Common.Catalog.Products;
using Web.Domain.DTO.CatalogService;

namespace Web.Domain.Services.Catalog.Products.ProductTypes
{
    public interface IProductType : IDescribedEntity<ProductTypeDto>
    {
        IReadOnlyList<FeatureType> Features { get; }
        public ProductKind ProductKind { get; }
    }
}