using Web.Domain.Common;
using Web.Domain.DTO.CatalogService;

namespace Web.Domain.Services.Catalog.Products.ProductTypes
{
    public class FeatureType : DescribedEntity<FeatureTypeDto>
    {
        public FeatureType(FeatureTypeDto d = null) : base(d) { }

        public string ProductTypeId => Data?.ProductTypeId ?? Unspecified;

        public bool IsMandatory => Data?.IsMandatory ?? false;

        public int NumericCode => data?.NumericCode ?? UnspecifiedInteger;
    }
}