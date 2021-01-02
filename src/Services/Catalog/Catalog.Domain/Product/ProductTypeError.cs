using Catalog.Data.Product;

namespace Catalog.Domain.Product
{
    public sealed class ProductTypeError : BaseProductType
    {

        public ProductTypeError(ProductTypeData d = null) : base(d) { }

    }
}
