using Sooduskorv_MVC.Aids.Reflection;
using Catalog.Data.Product;
using Catalog.Data.ProductFeature;
using Catalog.Domain.Catalog;
using Catalog.Domain.Common;
using Catalog.Domain.ProductFeature;
using System.Collections.Generic;

namespace Catalog.Domain.Product
{
    public abstract class BaseProductType : DescribedEntity<ProductTypeData>, IProductType
    {

        internal static string productTypeId => GetMember.Name<FeatureTypeData>(x => x.ProductTypeId);

        protected BaseProductType(ProductTypeData d = null) : base(d) { }

        public IReadOnlyList<FeatureType> Features =>
            new GetFrom<IFeatureTypesRepository, FeatureType>().ListBy(productTypeId, Id);

        public ProductKind ProductKind => Data?.ProductKind ?? ProductKind.Unspecified;

        //public IReadOnlyList<BasePrice> RelatedPrices =>
        //    new GetFrom<IPricesRepository, BasePrice>().ListBy(productTypeId, Id);


    }
}
