using Basket.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Infra.Common
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IEntity<TData>
        where TData : PeriodData// TODO
    {
        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s) { }
    }
}