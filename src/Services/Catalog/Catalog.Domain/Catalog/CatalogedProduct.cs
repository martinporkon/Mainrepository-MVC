using Catalog.Data.CatalogedProducts;
using Catalog.Domain.Common;
using Catalog.Domain.Product;

namespace Catalog.Domain.Catalog
{
    public sealed class CatalogedProduct : Entity<CatalogedProductData> {

        public CatalogedProduct(CatalogedProductData d = null) : base(d) { }

        public string CatalogEntryId => data?.CatalogEntryId ?? Unspecified;
        
        public string ProductTypeId => data?.ProductTypeId ?? Unspecified;

        public CatalogEntry CatalogEntry =>
            new GetFrom<ICatalogEntriesRepository, CatalogEntry>().ById(CatalogEntryId);

        public IProductType ProductType =>
            new GetFrom<IProductTypesRepository, IProductType>().ById(ProductTypeId);

    }
}
