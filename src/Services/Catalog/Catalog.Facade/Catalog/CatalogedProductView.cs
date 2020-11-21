using Sooduskorv_MVC.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catalog.Facade.Catalog
{
    public sealed class CatalogedProductView:PeriodView
    {
        [DisplayName("Catalog Entry")]
        public string CatalogEntryId { get; set; }

        [DisplayName("Product Type")]
        public string ProductTypeId { get; set; }
    }
}
