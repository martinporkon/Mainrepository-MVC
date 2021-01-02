using Catalog.Data.Product;

namespace Catalog.Domain.Product
{
    public sealed class ProductInstance : BaseProductInstance<ProductType>
    {


        public ProductInstance(ProductInstanceData d = null) : base(d) { }

        public override ProductType Type => type as ProductType;

    }
}
