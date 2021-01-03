using Catalog.Data.Product;
using Catalog.Domain.Service;

namespace Catalog.Domain.Product
{
    public static class ProductTypeFactory
    {

        public static IProductType Create(ProductTypeData d)
        {
            if (d is null) return error(null);

            return d.ProductKind switch
            {
                ProductKind.Unspecified => error(d),
                ProductKind.Product => new ProductType(d),
                //ProductKind.MeasuredProduct => new MeasuredProductType(d),
                ProductKind.Service => new ServiceType(d),
                _ => error(d)
            };
        }
        private static IProductType error(ProductTypeData d) => new ProductTypeError(d);

    }
}
