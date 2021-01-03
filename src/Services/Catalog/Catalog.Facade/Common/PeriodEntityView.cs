using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Catalog.Domain.Common;

namespace Catalog.Facade.Common
{
    public abstract class PeriodEntityView : BaseEntity
    {

        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? From { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? To { get; set; }

        public abstract string GetId();
    }
}