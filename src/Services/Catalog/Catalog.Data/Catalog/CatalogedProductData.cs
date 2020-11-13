using CommonData;
using Sooduskorv_MVC.Data.CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.CatalogedProducts
{
    public sealed class CatalogedProductData :PeriodData
    {
        public string CatalogEntryId { get; set; }
        public string ProductTypeId { get; set; }
    }
}
