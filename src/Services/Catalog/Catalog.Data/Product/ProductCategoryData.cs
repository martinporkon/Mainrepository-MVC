using CommonData;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.Product
{
    public sealed class ProductCategoryData : DescribedEntityData { 
        public string BaseCategoryId { get; set; }
    }
}