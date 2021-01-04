using Web.Domain.Common.Catalog.Products;
using Web.Domain.DTO.CatalogService;

namespace Web.Domain.Services.Catalog.Products.ProductTypes
{
    public static class ProductTypeFactory
    {

        public static IProductType Create(ProductTypeDto d)
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
        private static IProductType error(ProductTypeDto d) => new ProductTypeError(d);

    }
}