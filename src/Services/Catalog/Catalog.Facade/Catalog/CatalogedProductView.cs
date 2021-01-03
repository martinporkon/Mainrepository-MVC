using System.ComponentModel;
using Catalog.Facade.Common;

namespace Catalog.Facade.Catalog
{
    public sealed class CatalogedProductView : NamedEntityView
    {
        [DisplayName("Catalog Entry")]
        public string CatalogEntryId { get; set; }

        [DisplayName("Product Type")]
        public string ProductTypeId { get; set; }
    }
}
