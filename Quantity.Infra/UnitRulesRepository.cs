using System.Threading.Tasks;
using Aids.Extensions;
using Microsoft.EntityFrameworkCore;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;

namespace Quantity.Infra {

    public sealed class UnitRulesRepository : PaginatedRepository<UnitRules, UnitRulesData>, IUnitRulesRepository
    {

        public UnitRulesRepository(QuantityDbContext c = null) : base(c, c?.UnitRules) { }

        protected internal override UnitRules toDomainObject(UnitRulesData d) => new UnitRules(d);

        protected override async Task<UnitRulesData> getData(string id)
        {
            var systemOfUnitsId = id.GetHead();
            var unitId = id.GetTail();

            return await dbSet.SingleOrDefaultAsync(x => x.SystemOfUnitsId == systemOfUnitsId && x.UnitId == unitId);
        }
        protected override UnitRulesData getDataById(UnitRulesData d)
            => dbSet.Find(d.SystemOfUnitsId, d.UnitId);

    }

}