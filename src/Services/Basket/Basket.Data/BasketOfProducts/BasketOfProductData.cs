using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Data.BasketOfProducts
{
    public sealed class BasketOfProductData : DescribedEntityData
    {
        public string BasketId { get; set; }
        public string ProductOfPartyId { get; set; }
    }
}