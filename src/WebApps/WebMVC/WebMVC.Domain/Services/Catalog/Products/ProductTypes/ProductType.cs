using Web.Domain.DTO.CatalogService;

namespace Web.Domain.Services.Catalog.Products.ProductTypes
{
    public class ProductType : BaseProductType
    {
        public ProductType() : this(null) { }
        public ProductType(ProductTypeDto d = null) : base(d) { }
    }
}