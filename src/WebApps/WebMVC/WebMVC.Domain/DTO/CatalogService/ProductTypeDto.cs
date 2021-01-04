using Sooduskorv_MVC.Data.CommonData;
using Web.Domain.Common.Catalog.Products;

namespace Web.Domain.DTO.CatalogService
{
    public class ProductTypeDto : DescribedEntityData
    {
        public ProductKind ProductKind { get; set; }
        public double Amount { get; set; }
        public string UnitId { get; set; }
        public string BrandId { get; set; }
        public string CountryOfOriginId { get; set; }
        public string BarCode { get; set; }
        public string Image { get; set; }
        public ProductDescriptionDto DescriptionData { get; set; }
    }
}