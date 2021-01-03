using Catalog.Data.CatalogEntries;
using Catalog.Domain.Catalog;
using Sooduskorv_MVC.Aids.Methods;

namespace Catalog.Facade.Catalog
{
    public static class CatalogEntryViewFactory
    {
        public static CatalogEntryView Create(CatalogEntry o)
        {
            var v = new CatalogEntryView();
            Copy.Members(o.Data, v);

            return v;
        }
        public static CatalogEntry Create(CatalogEntryView v)
        {
            var d = new CatalogEntryData();
            Copy.Members(v, d);

            return new CatalogEntry(d);
        }
    }
}
