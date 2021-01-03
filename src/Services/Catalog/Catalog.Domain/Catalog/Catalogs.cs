using Sooduskorv_MVC.Aids.Reflection;
using Catalog.Data.Catalog;
using Catalog.Data.CatalogEntries;
using Catalog.Domain.Common;
using System.Collections.Generic;

namespace Catalog.Domain.Catalog
{
    public sealed class Catalogs : DescribedEntity<CatalogData>
    {

        internal static string catalogId => GetMember.Name<CatalogEntryData>(x => x.CatalogId);

        public Catalogs(CatalogData d = null) : base(d) { }

        public IReadOnlyList<CatalogEntry> CatalogEntries =>
            new GetFrom<ICatalogEntriesRepository, CatalogEntry>().ListBy(catalogId, Id);

    }
}
