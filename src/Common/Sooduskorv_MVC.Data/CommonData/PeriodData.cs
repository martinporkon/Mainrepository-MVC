using System;

namespace Sooduskorv_MVC.Data.CommonData
{
    public abstract class PeriodData/* : UniqueEntityData*/
    {
        /*public Maybe<DateTime> ValidFrom { get; set; }
        public Maybe<DateTime> ValidTo { get; set; }*/

        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}