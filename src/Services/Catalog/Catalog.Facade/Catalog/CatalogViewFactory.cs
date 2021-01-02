using Catalog.Data.Catalog;
using Catalog.Domain.Catalog;
using Sooduskorv_MVC.Aids.Methods;

namespace Catalog.Facade.Catalog
{
    public class CatalogViewFactory
    {
        public static Catalogs Create(CatalogView v)
        {
            var d = new CatalogData();
            Copy.Members(v, d);

            return new Catalogs(d);
        }

        public static CatalogView Create(Catalogs o)
        {
            var v = new CatalogView();

            Copy.Members(o?.Data, v);

            return v;
        }
    }
}
