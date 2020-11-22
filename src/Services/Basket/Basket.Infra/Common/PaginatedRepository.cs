using Basket.Domain.Common;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Infra.Common
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IEntity<TData>
        where TData : PeriodData
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }

        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s) { }
    }
}