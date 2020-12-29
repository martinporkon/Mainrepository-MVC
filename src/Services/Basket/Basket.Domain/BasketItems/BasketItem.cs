using Basket.Domain.Common;

namespace Basket.Domain.Baskets
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string CatalogItemId { get; set; }
        public string BasketId { get; set; }

        public BasketItem(string catalogItemId, string quantity, decimal unitPrice)
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
        }
    }
}