using Basket.Data.Common;

namespace Basket.Data.BasketOfProduct
{
    public sealed class BasketOfProductsData : PeriodData
    {
        public string BasketId { get; set; }
        public string ProductOfPartyId { get; set; }
    }
}