using Web.Domain.DTO.Common;

namespace Web.Domain.Common
{
    public class NamedEntity<T> : UniqueEntity<T>, INamedEntity<T> where T : NamedEntityDto, new()
    {
        protected internal NamedEntity(T d = null) : base(d) { }
        public virtual string Name => Data?.Name ?? Unspecified;
        public virtual string Code => Data?.Code ?? Unspecified;
    }
}