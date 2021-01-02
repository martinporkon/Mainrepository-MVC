using Sooduskorv_MVC.Aids.Reflection;
using Catalog.Data.CatalogedProducts;
using Catalog.Data.CatalogEntries;
using Catalog.Domain.Common;
using Catalog.Domain.Product;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Domain.Catalog
{
    public sealed class CatalogEntry : DescribedEntity<CatalogEntryData>
    {

        internal static string entryId
            => GetMember.Name<CatalogedProductData>(x => x.CatalogEntryId);

        public CatalogEntry(CatalogEntryData d = null) : base(d) { }

        public string CatalogId => data?.CatalogId ?? Unspecified;

        public string CategoryId => data?.CategoryId ?? Unspecified;

        public ProductCategory Category =>
            new GetFrom<IProductCategoriesRepository, ProductCategory>().ById(CategoryId);

        public IReadOnlyList<CatalogedProduct> CatalogedProductTypes =>
            new GetFrom<ICatalogedProductsRepository, CatalogedProduct>().ListBy(entryId, Id);

        public IReadOnlyList<IProductType> ProductTypes
            => CatalogedProductTypes.Select(e => e.ProductType).ToList();
    }
}
