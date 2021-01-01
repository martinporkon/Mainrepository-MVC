
using CommonData;

namespace Quantity.Domain.Common {

    public abstract class UniqueEntity<T> : Entity<T>, IUniqueEntity<T> where T : PeriodData {

        protected internal UniqueEntity(T d = null) : base(d) { }

        public virtual string Id => Data?.Id?? Unspecified;

    }

}
