using CommonData;

namespace Catalog.Data.Products
{
    public sealed class ProductData : DescribedEntityData
    {
        // All products
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string PartyId { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Supplier { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Measure { get; set; }
        public string Code { get; set; }
        public string Composition { get; set; }
        public string Image { get; set; }
    }
}