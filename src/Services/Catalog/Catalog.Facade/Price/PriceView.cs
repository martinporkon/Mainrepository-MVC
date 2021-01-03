using System.ComponentModel;

namespace Catalog.Facade.Price
{
    public sealed class PriceView : PeriodView
    {
        public decimal Amount { get; set; }
        [DisplayName("Currency")]
        public string CurrencyId { get; set; }
        [DisplayName("Product")]
        public string ProductInstanceId { get; set; }
    }

    public class PeriodView
    {
    }
}
