using Aids.Methods;
using Catalog.Data.Product;
using Catalog.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Facade.Product
{
    public static class ProductInstanceViewFactory
    {

        public static ProductInstanceView Create(IProductInstance o)
        {
            var v = new ProductInstanceView();
            Copy.Members(o.Data, v);

            return v;
        }

        public static IProductInstance Create(ProductInstanceView v)
        {
            var d = new ProductInstanceData();
            Copy.Members(v, d);

            return ProductFactory.Create(d);
        }

    }

}
