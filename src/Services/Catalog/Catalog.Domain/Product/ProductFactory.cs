using Catalog.Data.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Product
{
    public static class ProductFactory
    {
        public static IProductInstance Create(ProductInstanceData d)
        {
            if (d is null) return error(null);

            return d.ProductKind switch
            {
                ProductKind.Unspecified => error(d),
                ProductKind.Product => new ProductInstance(d),
                //ProductKind.MeasuredProduct => new MeasuredProduct(d),
                //ProductKind.Service => new Service(d),
                _ => error(d)
            };
        }
        private static IProductInstance error(ProductInstanceData d) => new ProductError(d);
    }
}
