
using Sooduskorv_MVC.Data.CommonData;

namespace Quantity.Domain.Common {

    public abstract class UniqueEntity<T> : Entity<T>, IUniqueEntity<T> where T : PeriodData, new() {

        protected internal UniqueEntity(T d = null) : base(d) { }

        public virtual string Id => Data?.Id?? Unspecified;

    }

}
