using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.CatalogedProducts
{
    public sealed class CatalogedProductData :PeriodData
    {
        public string CatalogEntryId { get; set; }
        public string ProductTypeId { get; set; }
    }
}
