using System;

namespace Catalog.Data.Common
{
    public abstract class PeriodData : UniqueEntityData
    {
        /*public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }*/
        public  DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}