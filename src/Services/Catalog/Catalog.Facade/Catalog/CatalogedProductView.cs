using System.ComponentModel;
using Catalog.Facade.Price;

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
