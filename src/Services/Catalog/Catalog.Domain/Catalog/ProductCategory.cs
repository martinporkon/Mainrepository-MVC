using Catalog.Data.Product;
using Catalog.Domain.Common;

namespace Catalog.Domain.Catalog
{
    public sealed class ProductCategory : DescribedEntity<ProductCategoryData>
    {

        public ProductCategory(ProductCategoryData d = null) : base(d) { }

        public string BaseCategoryId => data?.BaseCategoryId ?? Unspecified;

        public ProductCategory BaseCategory =>
            new GetFrom<IProductCategoriesRepository, ProductCategory>().ById(BaseCategoryId);

    }
}
