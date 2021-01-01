using CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonData
{
    public abstract class PricedEntityData : PeriodData
    {
        public decimal Price { get; set; }
    }
}
