using Catalog.Data.Product;
using Catalog.Domain.Product;
using Sooduskorv_MVC.Aids.Methods;

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
