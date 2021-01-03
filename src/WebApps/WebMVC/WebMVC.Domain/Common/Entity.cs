using System;
using Web.Domain.DTO.Common;

namespace Web.Domain.Common
{
    public class Entity<TData> : ValueObject<TData>, IDto<TData> where TData : PeriodEntityDto, new()
    {
        protected internal Entity(TData d = null) : base(d) { }

        public virtual DateTime ValidFrom => Data?.ValidFrom ?? UnspecifiedValidFrom;

        public virtual DateTime ValidTo => Data?.ValidTo ?? UnspecifiedValidTo;
    }
}