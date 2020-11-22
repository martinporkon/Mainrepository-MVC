using Basket.Domain.Common;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Infra.Common
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TDomain : IEntity<TData>
        where TData : PeriodData
    {
        public string SortOrder { get; set; }

        protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s) { }
    }
}