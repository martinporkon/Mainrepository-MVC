using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.ProductOfParty
{
    public sealed class ProductsOfPartyData : PeriodData
    {
        public string ProductId { get; set; }
        public string PartyId { get; set; }
        public string PriceId { get; set; }
        public string Id { get; set; }
    }
}