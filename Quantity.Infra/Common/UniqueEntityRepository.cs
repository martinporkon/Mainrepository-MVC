using System.Threading.Tasks;
using CommonData;
using Microsoft.EntityFrameworkCore;
using Quantity.Domain.Common;

namespace Quantity.Infra.Common {

    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IEntity<TData>
        where TData : PeriodData, new() {// TODO Must be UniqueEntityData.

        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

    

        protected override async Task<TData> getData(string id)
            => await dbSet.FirstOrDefaultAsync(m => m.Id == id);

        protected override TData getDataById(TData d) => dbSet.Find(d.Id);

    }

}
