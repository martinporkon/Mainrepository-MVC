using Aids.Methods;
using Catalog.Data.Product;
using Catalog.Domain.Product;

namespace Catalog.Facade.Product
{

    public static class ProductTypeViewFactory
    {

        public static ProductTypeView Create(IProductType o)
        {
            var v = new ProductTypeView();
            Copy.Members(o.Data, v);

            return v;
        }

        public static IProductType Create(ProductTypeView v)
        {
            var d = new ProductTypeData();
            Copy.Members(v, d);

            return ProductTypeFactory.Create(d);
        }
    }
}