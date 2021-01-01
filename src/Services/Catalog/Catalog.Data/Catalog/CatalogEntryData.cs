using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.CatalogEntries
{
    public sealed class CatalogEntryData:DescribedEntityData
    {
        public string CatalogId { get; set; }
        public string CategoryId { get; set; }
    }
}
