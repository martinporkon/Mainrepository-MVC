using Sooduskorv_MVC.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catalog.Facade.Price
{
    public sealed class PriceView:DescribedEntityView
    {
        public decimal Amount { get; set; }
        [DisplayName("Currency")]
        public string CurrencyId { get; set; }
        [DisplayName("Product")]
        public string ProductInstanceId { get; set; }
    }
}
