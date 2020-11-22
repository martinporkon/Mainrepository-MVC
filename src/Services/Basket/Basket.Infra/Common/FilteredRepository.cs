using Basket.Domain.Common;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Infra.Common
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TDomain : IEntity<TData>
        where TData : PeriodData
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        protected FilteredRepository(DbContext c, DbSet<TData> s) : base(c, s) { }
    }
}