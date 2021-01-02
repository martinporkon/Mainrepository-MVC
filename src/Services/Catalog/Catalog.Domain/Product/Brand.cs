using Catalog.Data.Product;
using Catalog.Domain.Catalog;

namespace Catalog.Domain.Product
{
    public sealed class Brand : DescribedEntity<BrandData>
    {
        public Brand(BrandData d) : base(d) { }
    }
}
