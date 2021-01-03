using System.ComponentModel;

namespace Catalog.Facade.Product
{
    public sealed class ProductCategoryView:PeriodView
    {
        [DisplayName("Base category")]
        public string BaseCategoryId { get; set; }
    }
}
