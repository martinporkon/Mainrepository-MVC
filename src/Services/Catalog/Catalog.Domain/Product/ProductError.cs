using Catalog.Data.Product;

namespace Catalog.Domain.Product
{
    public sealed class ProductError : BaseProductInstance<IProductType>
    {

        public ProductError(ProductInstanceData d = null) : base(d) { }

        public override IProductType Type => type;

    }
}
