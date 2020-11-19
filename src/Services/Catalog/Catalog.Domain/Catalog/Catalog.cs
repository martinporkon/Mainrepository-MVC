﻿using Aids.Reflection;
using Catalog.Data.Catalog;
using Catalog.Data.CatalogEntries;
using Catalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Catalog
{
    public sealed class Catalog : DescribedEntity<CatalogData>
    {

        internal static string catalogId => GetMember.Name<CatalogEntryData>(x => x.CatalogId);

        public Catalog(CatalogData d = null) : base(d) { }

        public IReadOnlyList<CatalogEntry> CatalogEntries =>
            new GetFrom<ICatalogEntriesRepository, CatalogEntry>().ListBy(catalogId, Id);

    }
}
