using System.ComponentModel;
using Catalog.Facade.Price;

namespace Catalog.Facade.Catalog
{
    public sealed class CatalogEntryView:PeriodView
    {
        [DisplayName("Catalog")]
        public string CatalogId { get; set; }

        [DisplayName("Category")]
        public string CategoryId { get; set; }
    }
}
