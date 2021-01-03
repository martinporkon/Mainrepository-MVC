using Catalog.Data.Product;

namespace Catalog.Domain.Product
{
    public sealed class ProductType : BaseProductType
    {

        public ProductType() : this(null) { }
        public ProductType(ProductTypeData d = null) : base(d) { }

    }
}
