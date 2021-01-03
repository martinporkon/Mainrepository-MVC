

using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.Prices
{
    public sealed class PriceData : NameEntityData
    {
        public decimal Amount { get; set; }
        public string CurrencyId { get; set; }
        public string ProductInstanceId { get; set; }
    }
}