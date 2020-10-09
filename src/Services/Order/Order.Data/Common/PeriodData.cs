using System;

namespace Order.Data.Common
{
    public abstract class PeriodData : UniqueEntityData
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}