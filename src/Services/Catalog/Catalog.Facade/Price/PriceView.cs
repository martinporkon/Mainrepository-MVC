using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    public abstract class PeriodView
    {
        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }

        /*
        public abstract string GetId();*/
    }
}
