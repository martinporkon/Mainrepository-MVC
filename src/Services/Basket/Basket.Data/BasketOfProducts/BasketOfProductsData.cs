using CommonData;

namespace Basket.Data.BasketOfProducts
{
    public sealed class BasketOfProductsData : PeriodData
    {
        public string BasketId { get; set; }
        public string ProductOfPartyId { get; set; }
    }
}