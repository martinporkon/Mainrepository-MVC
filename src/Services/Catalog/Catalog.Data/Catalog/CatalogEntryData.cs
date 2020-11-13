using CommonData;
using Sooduskorv_MVC.Data.CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.CatalogEntries
{
    public sealed class CatalogEntryData:DescribedEntityData
    {
        public string CatalogId { get; set; }
        public string CategoryId { get; set; }
    }
}
