using Aids.Reflection;
using Catalog.Data.Product;
using Catalog.Data.ProductFeature;
using Catalog.Domain.Catalog;
using Catalog.Domain.Common;
using Catalog.Domain.Prices;
using Catalog.Domain.ProductFeature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public abstract class BaseProductInstance<TType> : DescribedEntity<ProductInstanceData>, IProductInstance where TType : IProductType
    {

        internal string productId => GetMember.Name<FeatureInstanceData>(x => x.ProductId);


        protected BaseProductInstance(ProductInstanceData d = null) : base(d) { }

        public string TypeId => Data?.ProductKind.ToString() ?? Unspecified;

        public abstract TType Type { get; }

        protected internal IProductType type => new GetFrom<IProductTypesRepository, IProductType>().ById(TypeId);

        public ProductKind ProductKind { get; }
        public string ProductTypeId { get; }


        //public virtual IReadOnlyList<FeatureInstance> Features =>
        //    new GetFrom<IFeaturesRepository, FeatureInstance>().ListBy(productId, Id);

        //public IReadOnlyList<BasePrice> RelatedPrices =>
        //    new GetFrom<IPricesRepository, BasePrice>().ListBy(productId, Id);


    }
}
