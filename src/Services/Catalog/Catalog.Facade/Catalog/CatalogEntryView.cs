using System.ComponentModel;
using Catalog.Facade.Common;

namespace Catalog.Facade.Catalog
{
    public sealed class CatalogEntryView : NamedEntityView
    {
        [DisplayName("Catalog")]
        public string CatalogId { get; set; }

        [DisplayName("Category")]
        public string CategoryId { get; set; }
    }
}