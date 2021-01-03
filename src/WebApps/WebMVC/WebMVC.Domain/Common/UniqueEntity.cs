using Web.Domain.DTO.Common;

namespace Web.Domain.Common
{
    public class UniqueEntity<T> : Entity<T>, IUniqueDto<T> where T : UniqueEntityDto, new()
    {
        protected internal UniqueEntity(T d = null) : base(d) { }

        public virtual string Id => Data?.Id ?? Unspecified;
    }
}