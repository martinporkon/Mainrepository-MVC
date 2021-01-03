using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;
using Sooduskorv_MVC.Aids.Extensions;

namespace Quantity.Infra {

    public sealed class UnitRulesRepository : PaginatedRepository<UnitRules, UnitRulesData>, IUnitRulesRepository
    {

        public UnitRulesRepository(QuantityDbContext c = null) : base(c, c?.UnitRules) { }

        public override UnitRules toDomainObject(UnitRulesData d) => new UnitRules(d);

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