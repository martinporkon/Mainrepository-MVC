using System;
using Quantity.Domain.Common;

namespace Web.Domain.DTO.Common
{
    public class PeriodEntityData : BaseEntity
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}