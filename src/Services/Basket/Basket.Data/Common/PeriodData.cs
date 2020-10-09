using System;

namespace Basket.Data.Common
{
    public abstract class PeriodData : UniqueEntityData
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}