using System;

namespace Data.CommonData
{
    public abstract class PeriodData : UniqueEntityData
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}