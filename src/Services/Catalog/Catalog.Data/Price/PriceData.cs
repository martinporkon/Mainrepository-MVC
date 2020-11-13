﻿using CommonData;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.Price
{
    public sealed class PriceData : PeriodData{
        public decimal Amount { get; set; }
        public string CurrencyId { get; set; }
        public string ProductTypeId { get; set; }
    }
}